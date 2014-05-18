using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManager.Models
{
    public class Book
    {
        private string title;
        private string isbn;
        private string author;
        private string publisher;
        private string year;
        private string description;
        public string Title{ get; set;}
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    }
}