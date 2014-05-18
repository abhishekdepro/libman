using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using LibraryManager.Models;
using Library;

namespace LibraryManager.Account
{
    public partial class Register : Page
    {
        string gender = "M";
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (UserName.Text != "")
            {
                Users u = new Users();
                if (female.Checked == true)
                    gender = "F";

                u.AddUser(UserName.Text, Password.Text, Email.Text, Contact.Text, Address.Text, gender);
                error.Text = "Successfully registered!";
            }
            else 
            {
                ErrorMessage.Text = "Please try again";
            }
        }
    }
}