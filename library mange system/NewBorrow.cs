using library_mange_system;
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

namespace library_mange_system
{
    public partial class NewBorrow : Form
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
        public NewBorrow()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NewBorrow_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveBorrowToFile(_StudentName: Author.Text, guna2TextBox2.Text, guna2TextBox1.Text, book.Text);
            this.Hide();
        }
        public void SaveBorrowToFile(string _StudentName, string _StudentID, string _phoneNumber, string _BookId)
        {
            borrowModel newBorrow = new borrowModel
            {
                StudentName = _StudentName,
                StudentID = _StudentID,
                phoneNumber = _phoneNumber,
                BookId = _BookId
            };

            try
            {
                File.AppendAllText("borrow.txt", $"{newBorrow.StudentName}-{newBorrow.StudentID}-{newBorrow.phoneNumber}-{newBorrow.BookId}-{DateTime.Now.ToString()}\n");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to file: {ex.Message}");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
