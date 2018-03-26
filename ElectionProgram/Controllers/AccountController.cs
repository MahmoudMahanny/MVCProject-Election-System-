using ElectionProgram.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

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
        public async Task<ActionResult> Registeration(RegistrationVM _User)
        {
            if (ModelState.IsValid == false)
            {
                return View(_User);
            }
            ApplicationUser AppUser = new ApplicationUser()
            {
                UserName = _User.UserName,
                PasswordHash = _User.Password,
                Email = _User.Email,
                Address = _User.Address,
                BirthDate = _User.BirthDate,
                Gender = _User.Gender,
                ImagePath = _User.ImagePath,
                NID = _User.NID,
                PhoneNumber = _User.Phone
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
                return RedirectToAction("LogIN", "Account", new { id = AppUser.Id });

            }
            return View(_User);

        }
        public ActionResult LogIN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIN(LogInVM _User)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUserManager manager = new ApplicationUserManager(
                    new ApplicationUserStore(new ApplicationDbContext())
                    );
                ApplicationUser AppUser = await manager.FindByNameAsync(_User.UserName);
                if (AppUser !=null)
                {
                    if (await manager.CheckPasswordAsync(AppUser,_User.Password))
                    {
                        IAuthenticationManager Authentication = HttpContext.GetOwinContext().Authentication;
                        ApplicationSignInManager signInManager = new ApplicationSignInManager(manager, Authentication);
                        await signInManager.SignInAsync(AppUser, false, false);
                        if (User.IsInRole("Admin"))
                        {
                            
                            return RedirectToAction("Edit", "Admins", new { id = AppUser.Id });
                        }
                        else
                        {
                            return RedirectToAction("MYPage", "Voters", new { id = AppUser.Id });
                        }
                    }
                    return View(_User);
                }
                return View(_User);
            }
            return View(_User);
        }
        public ActionResult LogOut(string id)
        {
            authentication.SignOut("ApplicationCookie");
            return View("Login");
        }
    }
}