using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LibraryManager
{
    public partial class searchbyISBN : System.Web.UI.Page
    {
        List<String> bookproperties = new List<string>();
        Book _book;
        protected void Page_Load(object sender, EventArgs e)
        {
            //unit testing for list dynamic add using HTMLGenericControl
            
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
                    foreach (var property in bookproperties)
                    {
                        HtmlGenericControl newLi = new HtmlGenericControl("li class=" + "list-group-item" + "");
                        newLi.InnerText = property;
                        book_details.Controls.Add(newLi);
                    }
                    //HtmlGenericControl foot = new HtmlGenericControl("label");
                    error.Text = "Book Fetched!";
                }
                else
                {
                    error.Text += (string)Session["booknotfetched"];
                    error.Enabled = true;
                }
            
            
        }

        private string padright(string x)
        {
            x = x.PadRight(x.Length + 8, ' ');
            return x;
        }
    }
}