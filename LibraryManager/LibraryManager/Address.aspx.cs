using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManager
{
    public partial class Address : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Users u = new Users();
                DataTable dt = new DataTable();
                dt = u.getuser(Session["user"].ToString());
                foreach (DataRow row in dt.Rows)
                {
                    add.Text = row["address"].ToString();
                    
                    //DateTime _doi = (DateTime)row["doi"];
                    //_doi = _doi.AddDays(14);
                    //dos.Value = _doi.ToString("dd-MMM-yyyy");

                }
               // error.Text = "Please return the book first";
            }
        }

        protected void addr_Click(object sender, EventArgs e)
        {
            address.Value = add.Text;
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            //address.Value = addr.Text;
            error.Text = "Book no. " + Session["Book"].ToString() + " has been granted to " + Session["user"].ToString() + " on " + System.DateTime.Today.Date.ToShortDateString() + Environment.NewLine +
                   " This book will be delivered at: " + address.Value;
        }

       

    }
}