using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksLinqWinForm
{
    public partial class LinqForm : Form
    {
        public LinqForm()
        {
            InitializeComponent();
        }

        //Initialize the form with the required data
        private void Form1_Load(object sender, EventArgs e)
        {
            //Get the database context
            BooksLinqWinForm.BooksEntities bookDBContxt = new BooksLinqWinForm.BooksEntities();

            //Titles and authors query
            var TitlesAndAuths = from authors in bookDBContxt.Authors
                       from books in authors.Titles
                       orderby books.Title1
                       select new { books.Title1, authors.FirstName, authors.LastName };
            outputWindow.AppendText("Titles and Authors:\r\n\r\n");

            foreach(var item in TitlesAndAuths)
            {
                outputWindow.AppendText(item.Title1 + " " + item.FirstName + " " + item.LastName + "\r\n");
            }

            //Titles and authors query sorted by title
            var AuthsAndTitlesSort = from authors in bookDBContxt.Authors
                       from books in authors.Titles
                       orderby books.Title1, authors.LastName, authors.FirstName
                       select new { books.Title1, authors.FirstName, authors.LastName };

            outputWindow.AppendText("\r\n\r\nAuthors and titles with authors sorted for each title:\r\n\r\n");
            
            foreach (var item in AuthsAndTitlesSort)
            {
                outputWindow.AppendText(item.Title1 + " " + item.FirstName + " " + item.LastName + "\r\n");
            }
            
            //Titles query grouped by authors
            var TitlesGrouped = from books in bookDBContxt.Titles
                        orderby books.Title1
                        select new
                        {
                            bookTitle = books.Title1,
                            //Grouping
                            authors = from auth in books.Authors
                                      orderby auth.LastName, auth.FirstName
                                      select new { auth.FirstName, auth.LastName }
                        };

            outputWindow.AppendText("\r\n\r\nTitles grouped by author:\r\n\r\n");
            
            foreach (var title in TitlesGrouped)
            {
                outputWindow.AppendText(title.bookTitle + ":\r\n");
                foreach(var auth in title.authors)
                {
                    outputWindow.AppendText(auth.FirstName + " " + auth.LastName + "\r\n");
                }
                outputWindow.AppendText("\r\n");
            }

            int A = 1;
            double B = 4.5;
            //A is coerced to a double since C is a double and 
            //A can be implicitly cast to a double according
            //to the c# rules
            double C = A + B;


        }
    }
}
