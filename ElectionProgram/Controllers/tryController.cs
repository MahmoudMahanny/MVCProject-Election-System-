using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectionProgram.Models;
using System.Data.Entity;

namespace ElectionProgram.Controllers
{
    public class tryController : Controller
    {
        // GET: try
        public ActionResult Index()
        {
            DataContext context = new DataContext();
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
            Account acc = new Account { UserName = "mohamed", Password = "123123" };
            context.Account.Add(acc);
            context.SaveChanges();
            return View();
        }
    }
}