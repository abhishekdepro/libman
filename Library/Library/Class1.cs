using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Books
    {
        SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
        //SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
           
        SqlCommand cmd;

        public DataTable getbookbyname(string name)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from Book where bname=@name", con);
            cmd.Parameters.AddWithValue("@name", name);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public void returnbook(string _isbn)
        {
            string cop;
            int _cop;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataTable t = getbookbyisbn(_isbn);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            foreach (DataRow row in t.Rows)
            {
                cop = (string)row["copies"];
                _cop = Convert.ToInt32(cop) + 1;
                cmd = new SqlCommand("update Book set available=@available,copies=@copies where isbn=@isbn", con);
                cmd.Parameters.AddWithValue("@available", "yes");
                cmd.Parameters.AddWithValue("@copies", _cop.ToString());
                cmd.Parameters.AddWithValue("@isbn", _isbn);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public void borrowbook(string _isbn)
        {
            string cop;
            int _cop;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataTable t = getbookbyisbn(_isbn);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            foreach (DataRow row in t.Rows)
            {
                cop = (string)row["copies"];
                _cop = Convert.ToInt32(cop)-1;

                cmd = new SqlCommand("update Book set available=@available,copies=@copies where isbn=@isbn", con);
                if (_cop == 0)
                {
                    cmd.Parameters.AddWithValue("@available", "no");
                }
                else {
                    cmd.Parameters.AddWithValue("@available", "yes");
                } cmd.Parameters.AddWithValue("@isbn", _isbn);
                cmd.Parameters.AddWithValue("@copies", _cop.ToString());
                cmd.ExecuteNonQuery();
                
            }
            con.Close();
        }

        
        public void addnewbook(string isbn, string name, string author, string publisher, string year, string available,string copies)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("insert into Book(isbn,bname,author,publisher,year,copies,available) values('" + isbn + "','" + name + "','" + author + "','" + publisher + "','" + year + "','" + copies + "','" + available + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updatebook(string isbn, string name, string author, string publisher, string year, string rating, string available)
        {
           // SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("update Book set bname=@name,author=@author,publisher=@publisher,year=@year,available=@avail where isbn=@isbn", con);
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@publisher", publisher);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@avail", available);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public DataTable getbookbyisbn(string _isbn)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from Book where isbn=@isbn",con);
            cmd.Parameters.AddWithValue("@isbn", _isbn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public DataTable getallbooks()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from Book", con);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }

        public void deletebook(string _isbn)
        {
           // SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("delete from Book where isbn=@isbn", con);
            cmd.Parameters.AddWithValue("@isbn", _isbn);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public class Users
    {
        public int foo;
        /*Add new user*/
        public void AddUser(string uid, string pass, string email, string contact, string address, string gender)
        {
           // SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("insert into Users(uname,pass,bid,doi,dos,email,contact,address,gender) values('" + uid + "','" + pass + "','" + "" + "','" + System.DateTime.Today.Date + "','" + System.DateTime.Today.Date +"','" + email + "','" + contact +"','" + address + "','" + gender + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        public DataTable getuser(string uid)
        {
            //SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("select * from Users where uname=@uid", con);
            cmd.Parameters.AddWithValue("@uid", uid);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        public string freeuser(string uid)
        {
    //        SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
          SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd, cmd1;
            SqlDataReader data;
            string isbn="";
            con.Open();
            cmd = new SqlCommand("select * from Users", con);
            //cmd.Parameters.AddWithValue("@uid",uid);
            data = cmd.ExecuteReader();
            while (data.Read() == true)
            {
                if (data[0].ToString() == uid)
                {
                    isbn = data[2].ToString();
                    break;
                }
                else
                    continue;
            }

            con.Close();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            
            cmd1 = new SqlCommand("update Users set bid=@bid,doi=@doi,dos=@dos where uname=@uname", con);
            cmd1.Parameters.AddWithValue("@bid","");
            cmd1.Parameters.AddWithValue("@doi", "");
            cmd1.Parameters.AddWithValue("@dos", "");
            cmd1.Parameters.AddWithValue("@uname", uid);
            cmd1.ExecuteNonQuery();
            con.Close();
            return isbn;
        }
        public void updateuser(string uid, string bid, DateTime doi)
        {
  //          SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
          SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("update Users set bid=@bid,doi=@date where uname=@uname", con);
            cmd.Parameters.AddWithValue("@bid", bid);
            cmd.Parameters.AddWithValue("@date", doi);
            cmd.Parameters.AddWithValue("@uname",uid);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable getmybooks(string uid)
        {
//            SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("select * from Users where uname=@uid", con);
            cmd.Parameters.AddWithValue("@uid", uid);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        }
        public bool hasbook(string uid)
        {
//            SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            SqlDataReader data;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd = new SqlCommand("select * from Users", con);
            //cmd.Parameters.AddWithValue("@uid",uid);
            data = cmd.ExecuteReader();
            while (data.Read() == true)
            {
                if (data[0].ToString() == uid && data[2].ToString()=="")
                {
                    foo = 1;
                    break;
                }
                else
                    continue;
            }
            con.Close();
            if (foo == 1)
                return false;
            else
                return true;
            
            
        }
        /*Sign In Credentials check*/
        public bool SignIn(string UserName, string Password)
        {
//           SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            SqlDataReader data;
            con.Open();
            cmd = new SqlCommand("select * from Users", con);
            data = cmd.ExecuteReader();
            while (data.Read() == true)
            {
                if (data[0].ToString() == UserName && data[1].ToString() == Password)
                {
                    foo = 1;
                    break;
                }
                else
                    continue;
            }
            if (foo == 1)
                return true;
            else
                return false;
        }
        /*Update User Info*/
        public void UpdateUser(string uid, string pass, string bid, DateTime doi, DateTime dos, string addr, string contact)
        {
//            SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");      
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("update Users set pass=@pass,bid=@bid,doi=@doi,dos=@dos,address=@addr,contact=@contact where uname=@uid", con);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@bid", bid);
            cmd.Parameters.AddWithValue("@doi", doi);
            cmd.Parameters.AddWithValue("@dos", dos);
            cmd.Parameters.AddWithValue("@addr", addr);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@uid",uid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*Delete an user*/
        public void DeleteUser(string uid)
        {
            //SqlConnection con = new SqlConnection("Data Source=VAIO\\SQLEXPRESS;Initial Catalog=librarymanager;Integrated Security=True");
            SqlConnection con = new SqlConnection("Data Source=rx1uuq7ctu.database.windows.net;Initial Catalog=libman_db;Persist Security Info=True;User ID=abhishek;Password=v0d@f0ne");
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand("delete from Users where uname=@uid", con);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
