using Bunifu.UI.WinForms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
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
using static Guna.UI2.Native.WinApi;

namespace library_mange_system
{

    public partial class AddBook : Form
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
        public AddBook()

        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        public AddBook(String Author2, String book2, String id2, String count2)

        {

            InitializeComponent();

            Author.Text = Author2;
            book.Text = book2;
            count.Text = count2;
            id.Text = id2;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Author.Text = "";
            book.Text = "";
            count.Text = "";
            id.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();

            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            BookModel bookModel = new BookModel();
            
           string Name = book.Text;
            string _Author = Author.Text;
            string BookId = id.Text;
            string _count = count.Text;
            AddBookToLibrary(Name, _Author,_count,BookId);
            this.Hide();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }

        private void book_TextChanged(object sender, EventArgs e)
        {

        }

        public void AddBookToLibrary(string title, string author, string _count, string bookId)
        {
            // Create a new BookModel instance
            BookModel newBook = new BookModel
            {
                BookName = title,
                Author = author,
                count = _count,
                BookId = bookId,
            };

            // Add the new book to the library
            try
            {
                File.AppendAllText("books.txt", $"{newBook.BookName}-{newBook.Author}-{newBook.count}-{newBook.BookId}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }
    }
}
