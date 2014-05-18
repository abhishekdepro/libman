
using Library;
using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManager
{
    public partial class newbook : System.Web.UI.Page
    {
        Book _book=new Book();
        List<String> bookproperties = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].ToString() != "admin")
                Response.Redirect("/Account/Login.aspx");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            _Default d1 = new _Default();
            HttpContext.Current.Session["Book"] = null;
            d1.searchbyisbn(isbn.Value.ToString());

            _book = (Book)HttpContext.Current.Session["Book"];
            error.Enabled = false;
            if (_book != null)
            {
                string title = "Title :";
                title = title.PadRight(title.Length + 8, ' ');
                title += _book.Title;
                bookproperties.Add(title);
                bookproperties.Add("Author :          " + _book.Author);
                bookproperties.Add("Publisher :       " + _book.Publisher);
                bookproperties.Add("Published year:   " + _book.Year);
                bookproperties.Add("Description:  " + _book.Description);


                bname.Value = _book.Title;
                author.Value = _book.Author;
                publisher.Value = _book.Publisher;
                year.Value = _book.Year;
                //HtmlGenericControl foot = new HtmlGenericControl("label");
                error.Text = "Book Fetched!";
            }
            else
            {
                error.Text = "No matches found!";
                author.Value = "";
                bname.Value = "";
                publisher.Value = "";
                year.Value = "";
            }
        }

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            Books b = new Books();
            //b.createtableBook();
            b.addnewbook(isbn.Value, bname.Value, author.Value, publisher.Value, year.Value, "yes", copies.Value);
            error.Text = "New Book added!";
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/updatebook.aspx");
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/updatebook.aspx");
        }

        protected void btnusrupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/updateuser.aspx");
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("/updateuser.aspx");
        }
    }
}