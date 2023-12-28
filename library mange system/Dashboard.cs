using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bunifu.UI.WinForms;
using MySql.Data.MySqlClient;
using TheArtOfDevHtmlRenderer.Core;
using static Guna.UI2.Native.WinApi;


namespace library_mange_system
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );
       public bool authors = false;
       public List<BookModel> booksList ;
      
        public Dashboard()
        {

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 23, 23));
            guna2Button2.CustomBorderColor = System.Drawing.Color.White;
            guna2Button3.CustomBorderColor = System.Drawing.Color.Transparent;
            guna2Button2.FillColor = System.Drawing.Color.DarkSlateGray;
            guna2Button3.FillColor = System.Drawing.Color.Transparent;
            label4.Text = "Dashboard";
            bunifuPages1.PageIndex = 0;
        
            // LoadBooks();
            // LoadBorrows();
            // LoadMembers();
            // LoadAuthors();
        }
        void LoadAuthors()
        {
          
        }
        void LoadMembers()
        {
      
        }
        void LoadBorrows()
        {
       
        }
        public void LoadBooks()
        {
           
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            guna2Button2.CustomBorderColor = System.Drawing.Color.White;
            guna2Button3.CustomBorderColor = System.Drawing.Color.Transparent;

            guna2Button2.FillColor = System.Drawing.Color.DarkSlateGray;
            guna2Button3.FillColor = System.Drawing.Color.Transparent;
            label4.Text = "Dashboard";


            bunifuPages1.PageIndex = 0;

        }
  private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button2.CustomBorderColor = System.Drawing.Color.Transparent;
            guna2Button3.CustomBorderColor = System.Drawing.Color.White;

            guna2Button2.FillColor = System.Drawing.Color.Transparent;
            guna2Button3.FillColor = System.Drawing.Color.DarkSlateGray;

            label4.Text = "Books";
             bunifuPages1.PageIndex = 1;

        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button2.CustomBorderColor = System.Drawing.Color.Transparent;
            guna2Button3.CustomBorderColor = System.Drawing.Color.Transparent;

            guna2Button2.FillColor = System.Drawing.Color.Transparent;
            guna2Button3.FillColor = System.Drawing.Color.Transparent;

              bunifuPages1.PageIndex = 2;

            label4.Text = "History";


        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BooksNum_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString("h:mm:ss");
            Date.Text = DateTime.Now.ToString("d/M/yyy");
            Day.Text = DateTime.Now.ToString("dddd");

            show_book_in_grid();
            show_borrow_in_grid();

        }
        private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                deleteBorrow(e.RowIndex);

            }
        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Button3_Click(Owner, e);

        }

         private void guna2Button9_Click(object sender, EventArgs e)
        {

            authors = true;
            LoadAuthors();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
         

        }


        private void guna2Button8_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.Show();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
           NewBorrow newBorrow = new NewBorrow();   
            newBorrow.Show();
        }
        void show_book_in_grid()
    {
            string data = File.ReadAllText("books.txt");
            List<string> lstData = data.Split('\n').ToList(); // Split by newline character instead of '-'

            var newList = new List<BookModel>();

            foreach (string item in lstData)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] bookInfo = item.Split('-');

                    if (bookInfo.Length >= 2)
                    {
                        newList.Add(new BookModel
                        {
                            BookName = bookInfo[0].Trim(),
                            Author = bookInfo[1].Trim(),
                            count = bookInfo[2].Trim(),
                            BookId = bookInfo[3].Trim()
                        });
                    }
                }
            }

            // Assuming bunifuDataGridView is bound to a list of BookModel
            bunifuDataGridView.DataSource = newList;
            label15.Text = newList.Count.ToString();
            label8.Text = newList.Count.ToString();

        }


        void show_borrow_in_grid()
        {
            string data = File.ReadAllText("borrow.txt");
            List<string> lstData = data.Split('\n').ToList(); // Split by newline character instead of '-'

            var newList = new List<borrowModel>();

            foreach (string item in lstData)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] bookInfo = item.Split('-');

                    if (bookInfo.Length >= 2)
                    {
                        newList.Add(new borrowModel
                        {
                            StudentName = bookInfo[0].Trim(),
                            StudentID = bookInfo[1].Trim(),
                            phoneNumber = bookInfo[2].Trim(),
                            BookId = bookInfo[3].Trim(),
                            Date = bookInfo[4].Trim()

                           
                        });
                    }
                }
            }

            // Assuming bunifuDataGridView is bound to a list of BookModel
            bunifuDataGridView2.DataSource = newList;
            BorrowNum.Text = newList.Count.ToString();
        }

        void deleteBorrow(int indexToDelete)
        {
            string data = File.ReadAllText("borrow.txt");
            List<string> lstData = data.Split('\n').ToList(); // Split by newline character instead of '-'

            if (indexToDelete >= 0 && indexToDelete < lstData.Count)
            {
                lstData.RemoveAt(indexToDelete);

                List<string> nonEmptyLines = lstData.Where(line => !string.IsNullOrEmpty(line)).ToList();

              //  File.WriteAllLines("borrow.txt", newList);
                // Write the modified list back to the file
                File.WriteAllLines("borrow.txt", nonEmptyLines);
            }
            else
            {
                Console.WriteLine("Invalid index to delete.");
            }
        }
    }
}




    