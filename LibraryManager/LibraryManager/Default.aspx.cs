using LibraryManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManager
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Book"] = null;
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (book_name.Value.ToString() != "")
            {
                string literal = @""+book_name.Value+@"";
                if (IsDigitsOnly(literal))
                {
                    searchbyisbn(literal);
                }
                else
                {
                    searchbytitle(literal);
                }
            }
           
            Response.Redirect("searchbyISBN.aspx");
        }

        List<String> booklist = new List<string>();

        public void searchbytitle(string literal){
            WebClient wc = new WebClient();
            Uri isbn = new Uri("https://www.googleapis.com/books/v1/volumes?q=" + literal, UriKind.Absolute);
            string json = wc.DownloadString(isbn);
            try
            {
                var container = JsonConvert.DeserializeObject(json) as JObject;
                //var _city = container["response"]["geocode"]["where"];

                List<JObject> result = container["items"].Children()
                                    .Cast<JObject>()

                                    .ToList();

                List<JProperty> lister = result[0]["volumeInfo"].Children()
                    .Cast<JProperty>().ToList();
                int index = lister.FindIndex(item => item.Name == "authors");
                List<JArray> authors = lister[index].Children()
                                    .Cast<JArray>()

                                    .ToList();
                Book book = new Book();
                var title = result[0]["volumeInfo"]["title"];
                var author = authors[0][0];
                if (null != result[0]["volumeInfo"]["publisher"])
                {
                    var publisher = result[0]["volumeInfo"]["publisher"];
                    book.Publisher = publisher.ToString();
                }
                var publishdate = result[0]["volumeInfo"]["publishedDate"];
                if (null != result[0]["volumeInfo"]["description"])
                {
                    var description = result[0]["volumeInfo"]["description"];
                    book.Description = description.ToString();
                }

                book.Title = title.ToString();
                book.Author = author.ToString();

                book.Year = publishdate.ToString();
                // book.Description = description.ToString();
                HttpContext.Current.Session["Book"] = book;
            }
            catch (Exception ex)
            {
                Session["booknotfetched"] = ex.Message;
            }
        }
        public void searchbyisbn(string literal)
        {
            WebClient wc = new WebClient();
            Uri isbn = new Uri("https://www.googleapis.com/books/v1/volumes?q=isbn:" + literal, UriKind.Absolute);
            string json=wc.DownloadString(isbn);
            try
            {
                var container = JsonConvert.DeserializeObject(json) as JObject;
                //var _city = container["response"]["geocode"]["where"];

                List<JObject> result = container["items"].Children()
                                    .Cast<JObject>()

                                    .ToList();

                List<JProperty> lister = result[0]["volumeInfo"].Children()
                    .Cast<JProperty>().ToList();
                int index = lister.FindIndex(item => item.Name=="authors");
                List<JArray> authors = lister[index].Children()
                                    .Cast<JArray>()

                                    .ToList();
                Book book = new Book();
                var title = result[0]["volumeInfo"]["title"];
                var author = authors[0][0];
                if (null != result[0]["volumeInfo"]["publisher"])
                {
                    var publisher = result[0]["volumeInfo"]["publisher"];
                    book.Publisher = publisher.ToString();
                }
                var publishdate = result[0]["volumeInfo"]["publishedDate"];
                if (null != result[0]["volumeInfo"]["description"])
                {
                    var description = result[0]["volumeInfo"]["description"];
                    book.Description = description.ToString();
                }
                
                book.Title = title.ToString();
                book.Author = author.ToString();
                
                book.Year = publishdate.ToString();
               // book.Description = description.ToString();
                HttpContext.Current.Session["Book"] = book;
            }
            catch (Exception ex)
            {
                Session["booknotfetched"] = ex.Message;
            }
        }

        private void IsbnCompletedDownload(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var container = JsonConvert.DeserializeObject(e.Result) as JObject;
                //var _city = container["response"]["geocode"]["where"];

                List<JObject> result = container["items"].Children()
                                    .Cast<JObject>()

                                    .ToList();
                var title = result[0]["volumeInfo"]["title"];
                Book book = new Book();
                book.Title = title.ToString();

                HttpContext.Current.Session["Book"] = book;

                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ran into a problem..Try again.");
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        protected void btnborrow_Click(object sender, EventArgs e)
        {

            if (Session["user"] != "")
            {
                Response.Redirect("/borrow.aspx");
            }
            
            else
                Response.Redirect("/Account/Login.aspx");
        }
    }
}