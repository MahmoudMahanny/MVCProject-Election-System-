using ElectionProgram.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionProgram
{
    //    public class ApplicationUserStore : UserStore<ApplicationUser>
    //    {
    //        public ApplicationUserStore(ApplicationDbContext context) : base(context)
    //        {

    //        }

    //    }
    //    public class ApplicationUserManager : UserManager<ApplicationUser>
    //    {
    //        public ApplicationUserManager(ApplicationUserStore Store ):base(Store)
    //        {

    //        }
    //    }
    //    public class ApplicationRoleStore :RoleStore<IdentityRole>
    //    {
    //        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
    //        {

    //        }

    //    }
    //    public class ApplicationRoleManager : RoleManager<IdentityRole>
    //    {
    //        public ApplicationRoleManager(ApplicationRoleStore Store) : base(Store)
    //        {

    //        }
    //    }
    //}

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager manager, IAuthenticationManager authenticationmanager) : base(manager, authenticationmanager)
        {

        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext owincontext)
        {
            return new ApplicationSignInManager(owincontext.GetUserManager<ApplicationUserManager>(),
            owincontext.Authentication
            );
        }
    }


    //UserStore ==>dbContext==>contection string ==>application User
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }
    //Manger ==>New User Store
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(ApplicationUserStore store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> option, IOwinContext owinContext)
        {
            return new ApplicationUserManager(new ApplicationUserStore(owinContext.Get<ApplicationDbContext>()));
        }
    }
    //Roles
    //UserStore ==>dbContext==>contection string ==>application User
    public class ApplicationRoleStore : RoleStore<ApplicationRoleModel>
    {
        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
        {

        }
    }
    //Manger ==>New User Store
    public class ApplicationRoleManager : RoleManager<ApplicationRoleModel>
    {
        public ApplicationRoleManager(ApplicationRoleStore store) : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> option, IOwinContext context)
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
        }
    }
}
    //Roles
    //UserStore ==>dbContext==>contection string ==>application User
    //    public class ApplicationRoleStore : RoleStore<ApplicationRoleModel>
    //    {
    //        public ApplicationRoleStore(ApplicationDbContext context) : base(context)
    //        {

//        }
//    }
//    //Manger ==>New User Store
//    public class ApplicationRoleManager : RoleManager<ApplicationRoleModel>
//    {
//        public ApplicationRoleManager(ApplicationRoleStore store) : base(store)
//        {
//        }

//        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> option, IOwinContext context)
//        {
//            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
//        }
//    }
//}