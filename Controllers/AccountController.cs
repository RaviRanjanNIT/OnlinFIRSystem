using Dapper;
using OnlinFIRSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlinFIRSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        OnlineFIREntities db = new OnlineFIREntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(UserDetail newuser)
        {
            string sqlPSInsert = "INSERT INTO UserDetails (UserName,Email,Password,Status,CreatedBy,CreatedOn) " +
                                       "Values (@UserName,@Email,@Password,@Status,@CreatedBy,@CreatedOn)";

            var connection = new SqlConnection(AppConnection.ConnectionString);
            {
                connection.Open();
                var affectedRows = connection.Execute(sqlPSInsert,
                    new
                    {
                        UserName = newuser.UserName,
                        Email = newuser.Email,
                        Password= newuser.Password,
                        Status = "Active",
                        CreatedBy = "0",
                        CreatedOn = DateTime.Now,
                    });
                connection.Close();
            }
            return RedirectToAction("Login");
            //return View();
        }
        public ActionResult Login()
            
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail user)
        {

            if (user != null)
            {
                if (db.UserDetails.Any(x => x.UserName == user.UserName && x.Password == user.Password))
                {
                    FormsAuthentication.SetAuthCookie("mycookie", false);
                    return View("~/Admin/Index");
                }
                else
                {
                    return View("Login");
                }
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        
    }
}