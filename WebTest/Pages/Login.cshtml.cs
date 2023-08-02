using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WebTest.Models;

namespace WebTest.Pages
{
    public class LoginModel : PageModel
    {
        readonly IConfiguration _configuration;

        public Login loginData = new Login();

        public string connString;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public void OnPost()
        {
            string strUsername = Request.Form["username"];
            string strPassword = Request.Form["password"];
            string strRemember = Request.Form["chkRemember"];

            GetRec(strUsername, strPassword, strRemember);
        }

        void GetRec(string strUsername, string strPassword, string strRemember)
        {
            connString = _configuration.GetConnectionString("DBConnection");

            Login login = new Login();
            loginData = login.GetRec(connString, strUsername, strPassword);

            if (loginData.empId != 0 && loginData.username != null)
            {

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
                {
                    HttpContext.Session.SetString("username", loginData.username);
                    HttpContext.Session.SetInt32("EmpID", loginData.empId);
                    HttpContext.Session.SetInt32("Role", loginData.role);
                }

                var username = HttpContext.Session.GetString("username");
                var empID = HttpContext.Session.GetInt32("EmpID");
                var role = HttpContext.Session.GetInt32("Role");

                var cookieOp = new CookieOptions();

                if (strRemember == "on")
                {
                    // Add Cookies
                    cookieOp.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Append("WebTestUsername", strUsername, cookieOp);
                    Response.Cookies.Append("WebTestPassword", strPassword, cookieOp);
                }
                else
                {
                    // Delete Cookies
                    cookieOp.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Delete("WebTestUsername");
                    Response.Cookies.Delete("WebTestPassword");
                }

                var cookieUsername = Request.Cookies["WebTestUsername"];
                var cookiePassword = Request.Cookies["WebTestPassword"];

                if (role == 1)
                {
                    Response.Redirect("/Privacy", false);
                }
                else
                {
                    Response.Redirect("/Privacy", false);
                }
            }
            else
            {
                //string message = "Username or Password incorrect!";
                //ViewData["JavaScriptFunction"] = string.Format("showAlert('{0}');", message);
                ViewData["JavaScriptFunction"] = "showAlert();";
            }
        }
    }
}
