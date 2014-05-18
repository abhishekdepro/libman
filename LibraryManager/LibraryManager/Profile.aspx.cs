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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) {
                Response.Redirect("/Account/Login.aspx");
            }
            else
            {
                string user = Session["user"].ToString();
                Label2.Text = user;
                Users u = new Users();
                Books b = new Books();
                if (u.hasbook(user) == true) { 
                    DataTable dt = u.getmybooks(user);
                //string avail;
                int count = 1;
                foreach (DataRow _row in dt.Rows)
                {
                    //bname.Value row["bname"].ToString();
                    //author.Value = row["author"].ToString();
                    //publisher.Value = row["publisher"].ToString();
                    //year.Value = row["year"].ToString();

                    //contentResults.Add(new Content() { Isbn = (string)row["isbn"], Title = (string)row["bname"], Author = (string)row["author"], Publisher = (string)row["publisher"], Available = avail });
                    string isbn = (string)_row["bid"];
                    DateTime doi = (DateTime)_row["doi"];
                    string dateofissue=doi.ToString("dd-MMM-yyyy");
                    DateTime dos=doi.AddDays(14);
                    string dateofsubmission = dos.ToString("dd-MMM-yyyy");
                    DataTable dat = b.getbookbyisbn(isbn);

                    foreach (DataRow row in dat.Rows)
                    {
                        //bname.Value row["bname"].ToString();
                        //author.Value = row["author"].ToString();
                        //publisher.Value = row["publisher"].ToString();
                        //year.Value = row["year"].ToString();

                        //contentResults.Add(new Content() { Isbn = (string)row["isbn"], Title = (string)row["bname"], Author = (string)row["author"], Publisher = (string)row["publisher"], Available = avail });


                        TableRow trow = new TableRow();
                        TableCell cell0 = new TableCell();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();
                        TableCell cell4 = new TableCell();
                        TableCell cell5 = new TableCell();
                        TableCell cell6 = new TableCell();
                        cell0.Text = (string)row["isbn"];
                        count++;

                        cell1.Text = (string)row["bname"];
                        cell2.Text = (string)row["author"];
                        cell3.Text = (string)row["publisher"];
                        cell4.Text = (string)row["year"];
                        cell5.Text = dateofissue;
                        cell6.Text = dateofsubmission;
                        trow.Cells.Add(cell0);
                        trow.Cells.Add(cell1);
                        trow.Cells.Add(cell2);
                        trow.Cells.Add(cell3);
                        trow.Cells.Add(cell4);
                        trow.Cells.Add(cell5);
                        trow.Cells.Add(cell6);
                        myTable.Rows.Add(trow);

                    }
                    DateTime today = DateTime.Today.Date;
                    double extradays= today.Subtract(dos).TotalDays;
                    if (extradays > 0)
                    {
                        error.Text = "Fine charged= ₹ " + extradays * 5;
                    }
                }
                }
            }
            
        }

        protected void btnborrowbook_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            Books b = new Books();
            string isbn=u.freeuser(Session["user"].ToString());
            b.returnbook(isbn);
            error.Text += "Book returned successfully!";
        }
    }
}