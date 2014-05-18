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
    public partial class updateuser : System.Web.UI.Page
    {
        string user,isbn;
        string name, author, publisher, year;
        bool available;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            //Books b = new Books();
            DateTime date = Convert.ToDateTime(doi.Value);
            DateTime dos = date.AddDays(14);
            
            
            u.UpdateUser(DropDownList1.SelectedItem.ToString(),pass.Value, bid.Value, date,dos,addr.Value,contact.Value);
            error.Text = "User Updated";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Users b = new Users();
            user = DropDownList1.SelectedItem.ToString();
            DataTable dt = new DataTable();
            dt = b.getuser(DropDownList1.SelectedItem.Value);
            foreach (DataRow row in dt.Rows)
            {
                pass.Value = row["pass"].ToString();
                bid.Value = row["bid"].ToString();
                isbn = row["bid"].ToString();
                addr.Value = row["address"].ToString();
                contact.Value = row["contact"].ToString();
                doi.Value = row["doi"].ToString();
                DateTime _doi=(DateTime)row["doi"];
                _doi=_doi.AddDays(14);
                dos.Value = _doi.ToString("dd-MMM-yyyy");

            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            if (bid.Value == "")
            {
                Users u = new Users();
                u.DeleteUser(DropDownList1.SelectedItem.ToString());
                error.Text = "User Deleted!";
            }
            else
            {
                error.Text = "Return book first";
            }
        }
    }
}