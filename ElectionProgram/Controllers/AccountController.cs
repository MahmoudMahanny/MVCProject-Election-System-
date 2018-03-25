using ElectionProgram.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;


namespace ElectionProgram.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IAuthenticationManager authentication
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                //if(_signInManager==null)
                //{
                //    _signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                //}
                //return _signInManager;
            }
            private set { _signInManager = value; }
        }

        //userManager
        private ApplicationUserManager _UserManager;

        public ApplicationUserManager UserManager
        {
            get { return _UserManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>(); }
            set { _UserManager = value; }
        }

        // GET: Registerition
        public ActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registeration(RegistrationVM User)
        {
            if (ModelState.IsValid == false)
            {
                return View(User);
            }
            ApplicationUser AppUser = new ApplicationUser()
            {
                UserName = User.UserName,
                PasswordHash = User.Password,
                Email = User.Email,
                Address = User.Address,
                BirthDate = User.BirthDate,
                Gender = User.Gender,
                ImagePath = User.ImagePath,
                NID = User.NID,
                PhoneNumber = User.Phone
            };
            ApplicationUserStore store = new ApplicationUserStore(new ApplicationDbContext());
            ApplicationUserManager manager = new ApplicationUserManager(store);

            var identityResult = await manager.CreateAsync(AppUser, AppUser.PasswordHash );
            if (identityResult.Succeeded)
            {
               //var roleResult =  await manager.AddToRoleAsync(AppUser.Id,"Voter");
                IAuthenticationManager Authentication = HttpContext.GetOwinContext().Authentication;
                ApplicationSignInManager signInManager = new ApplicationSignInManager(manager, Authentication);
                await signInManager.SignInAsync(AppUser, false, false);
                return RedirectToAction("Index", "Voters");
            }
            return View(User);

        }
        public ActionResult LogIN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIN(LogInVM User)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUserManager manager = new ApplicationUserManager(
                    new ApplicationUserStore(new ApplicationDbContext())
                    );
                ApplicationUser AppUser = await manager.FindByNameAsync(User.UserName);
                if (AppUser !=null)
                {
                    if (await manager.CheckPasswordAsync(AppUser,User.Password))
                    {
                        IAuthenticationManager Authentication = HttpContext.GetOwinContext().Authentication;
                        ApplicationSignInManager signInManager = new ApplicationSignInManager(manager, Authentication);
                        await signInManager.SignInAsync(AppUser, false, false);
                        return RedirectToAction("Index", "Voters");
                    }
                    return View(User);
                }
                return View(User);
            }
            return View(User);
        }
        public ActionResult LogOut(string id)
        {
            authentication.SignOut("ApplicationCookie");
            return View("Login");
        }
    }
}