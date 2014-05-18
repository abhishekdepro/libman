using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using LibraryManager.Models;
using Library;
using System.Data;

namespace LibraryManager.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            
            //Session["user"] = null;
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            if (Session["user"] == null)
            {

            }
            else
            {
                UserName.Text = Session["user"].ToString();
                error.Text = "Already logged in!";
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            Session["user"] = null;
            Users u = new Users();
            if(u.SignIn(UserName.Text,Password.Text)==true)
            {
                //Context.User.Identity.Name = UserName.Text;
                Session["user"] = UserName.Text;
                if (UserName.Text == "admin")
                {
                    Response.Redirect("/newbook.aspx");
                }
                else
                {
                    Response.Redirect("/Profile.aspx");
                }
            }
            else
            {
                error.Text = "Wrong credentials!";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            UserName.Text = "";
            Password.Text = "";
            error.Text = "Successfully logged out!";
        }

        protected void forget_password_CheckedChanged(object sender, EventArgs e)
        {
            string pass = "", to="";
               if (forget_password.Checked == true)
               {
                   if (UserName.Text != "")
                   {
             

                    mail m = new mail();
                    Users u = new Users();
                    DataTable dt = u.getuser(UserName.Text);
                    foreach (DataRow row in dt.Rows)
                    {
                        pass = row["pass"].ToString();
                        to = row["email"].ToString();
                    }
                    m.recoverpassword(to, pass);
                    error.Text = "Please check your email id for password!";
                   }
                   else
                   {
                       error.Text = "Enter username first!";
                   }
            }
            
        }
    }
}