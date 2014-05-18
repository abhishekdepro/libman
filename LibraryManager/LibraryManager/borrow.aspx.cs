using Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LibraryManager
{
    public class Content
    {
        
        public string Isbn
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string Publisher
        {
            get;
            set;
        }

        public string Available
        {
            get;
            set;
        }

        public int Copies
        {
            get;
            set;
        }
    }
    public partial class borrow : System.Web.UI.Page
    {
        string selected_isbn;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Content> contentResults = new List<Content>();
            Books b = new Books();
            DataTable dt = new DataTable();
            dt = b.getallbooks();
            string avail;
            int count = 1;
            foreach (DataRow row in dt.Rows)
            {
                //bname.Value row["bname"].ToString();
                //author.Value = row["author"].ToString();
                //publisher.Value = row["publisher"].ToString();
                //year.Value = row["year"].ToString();
                if((string)row["available"]=="yes"){
                    avail="🔴";
                }     
                
                else
                {
                    avail = "⃝";
                }
           //contentResults.Add(new Content() { Isbn = (string)row["isbn"], Title = (string)row["bname"], Author = (string)row["author"], Publisher = (string)row["publisher"], Copies=(int)row["copies"], Available = avail });
           TableRow trow = new TableRow();
           TableCell cell0 = new TableCell();
           TableCell cell1 = new TableCell();
           TableCell cell2 = new TableCell();
           TableCell cell3 = new TableCell();
           TableCell cell4 = new TableCell();
           TableCell cell5 = new TableCell();
           TableCell cell6 = new TableCell();
           if ((string)row["isbn"] != "000-select")
           {
               cell0.Text = (string)row["isbn"];

               count++;

               cell1.Text = (string)row["bname"];
               cell2.Text = (string)row["author"];
               cell3.Text = (string)row["publisher"];
               //cell4.Text = (string)row["year"];
               cell6.Text = avail;
               if (Convert.ToInt32(row["copies"]) == 0) { cell5.Text = ""; }
               else
               {
                   cell5.Text = Convert.ToInt32(row["copies"]).ToString();
               }
               trow.Cells.Add(cell0);
               trow.Cells.Add(cell1);
               trow.Cells.Add(cell2);
               trow.Cells.Add(cell3);

               trow.Cells.Add(cell5);
               trow.Cells.Add(cell6);
               myTable.Rows.Add(trow);
           }     
        }
        }

        protected void btnborrowbook_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            Users u = new Users();
            if (Session["user"] == null)
            {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {

                string user = Session["user"].ToString();
                if (u.hasbook(user) == false)
                {
                    b.borrowbook(selected_isbn);

                    u.updateuser(user, selected_isbn, DateTime.Today.Date);
                    Session["book"] = selected_isbn;
                    //error.Text = "Book no. " + selected_isbn + " has been granted to " + user + " on " + System.DateTime.Today.Date.ToShortDateString();

                    Response.Redirect("Address.aspx");
                }
                else
                {
                    error.Text = "Please return the book first";
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            selected_isbn = DropDownList1.SelectedItem.ToString();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Profile.aspx");
        }
        
    }
}