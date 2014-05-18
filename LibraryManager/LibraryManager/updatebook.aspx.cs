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
    public partial class updatebook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            string isbn = DropDownList1.SelectedItem.ToString();
            string avail;
           
            if (available.Checked == true)
            {
                avail = "yes";
                b.updatebook(isbn, bname.Value, author.Value, publisher.Value, year.Value, "", avail);
                error.Text = "Book updated!";
            }
            else
            {
                avail = "no";
                error.Text = "Book is already borrowed!";
            }
            
            Users u = new Users();       
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Books b = new Books();
            DataTable dt = new DataTable();
            dt = b.getbookbyisbn(DropDownList1.SelectedItem.Value);
            foreach (DataRow row in dt.Rows)
            {
                bname.Value = row["bname"].ToString();
                author.Value = row["author"].ToString();
                publisher.Value = row["publisher"].ToString();
                year.Value = row["year"].ToString();
                if (row["available"].ToString() == "yes")
                {
                    available.Checked = true;
                }
            }
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            if (available.Checked == true)
            {
                Books b = new Books();
                b.deletebook(DropDownList1.SelectedItem.ToString());
                error.Text = "Book deleted!";
            }
            else
            {
                error.Text = "Book not deleted!";
            }
        }
    }
}