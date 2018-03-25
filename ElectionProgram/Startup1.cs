using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
<<<<<<< HEAD
=======
using Microsoft.Owin.Security.Cookies;
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d

[assembly: OwinStartup(typeof(ElectionProgram.Startup1))]

namespace ElectionProgram
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
<<<<<<< HEAD
=======
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
            
            });
>>>>>>> 73a3ae920ba22808a8fc5074d785fa93062bce4d
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
