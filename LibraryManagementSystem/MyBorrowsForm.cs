using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    public partial class MyBorrowsForm : Form
    {
        private readonly User _user;

        // This constructor will be used from Dashboard:
        // new MyBorrowsForm(currentUser).ShowDialog();
        public MyBorrowsForm(User user)
        {
            InitializeComponent();
            _user = user;

            // Load event hookup (safe if you forgot to connect in designer)
            this.Load += MyBorrowsForm_Load;
        }

        private void MyBorrowsForm_Load(object sender, EventArgs e)
        {
            if (_user == null)
            {
                MessageBox.Show("User not provided.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_user.MemberId))
            {
                MessageBox.Show("This account is not linked to a MemberId.");
                return;
            }

            string memberId = _user.MemberId;

            var data = AppData.BorrowRecords
                .Where(r => r.MemberId == memberId)
                .Select(r => new
                {
                    r.RecordId,
                    BookTitle = AppData.Books.FirstOrDefault(b => b.BookId == r.BookId)?.Title,
                    r.BorrowDate,
                    r.ReturnDate,
                    Status = r.IsReturned ? "Returned" : "Borrowed"
                })
                .ToList();

            gridMyBorrows.DataSource = data;

            // Optional: make columns auto fit
            gridMyBorrows.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // You can keep this (not required for showing data)
        private void gridMyBorrows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
