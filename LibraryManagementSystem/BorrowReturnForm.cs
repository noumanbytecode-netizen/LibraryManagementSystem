using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    public partial class BorrowReturnForm : Form
    {
        public BorrowReturnForm()
        {
            InitializeComponent();

            // Do NOT hook btnBorrow / btnReturnSelected clicks here,
            // because Designer already hooks them -> otherwise double message boxes.

            this.Load += BorrowReturnForm_Load;
        }

        private void BorrowReturnForm_Load(object sender, EventArgs e)
        {
            LoadCombos();
            RefreshGrid();
        }

        private void LoadCombos()
        {
            cmbBooks.DataSource = null;
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "BookId";
            cmbBooks.DataSource = AppData.Books.ToList();

            cmbMembers.DataSource = null;
            cmbMembers.DisplayMember = "FullName";
            cmbMembers.ValueMember = "MemberId";
            cmbMembers.DataSource = AppData.Members.ToList();

            if (AppData.Books.Count == 0)
                MessageBox.Show("No books found. Please add books in Manage Books.");

            if (AppData.Members.Count == 0)
                MessageBox.Show("No members found. Please add members in Manage Members.");
        }

        private void RefreshGrid()
        {
            var data = AppData.BorrowRecords
                .Select(r => new
                {
                    r.RecordId,
                    r.BookId,
                    BookTitle = AppData.Books.FirstOrDefault(b => b.BookId == r.BookId)?.Title,
                    r.MemberId,
                    MemberName = AppData.Members.FirstOrDefault(m => m.MemberId == r.MemberId)?.FullName,
                    r.BorrowDate,
                    r.ReturnDate,
                    Status = r.IsReturned ? "Returned" : "Borrowed"
                })
                .ToList();

            gridBorrows.DataSource = null;
            gridBorrows.DataSource = data;
            gridBorrows.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedValue == null || cmbMembers.SelectedValue == null)
            {
                MessageBox.Show("Select a book and a member.");
                return;
            }

            string bookId = cmbBooks.SelectedValue.ToString();
            string memberId = cmbMembers.SelectedValue.ToString();

            var book = AppData.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            if (book.AvailableCopies <= 0)
            {
                MessageBox.Show("No copies available for this book.");
                return;
            }

            bool already = AppData.BorrowRecords.Any(r => r.BookId == bookId && r.MemberId == memberId && !r.IsReturned);
            if (already)
            {
                MessageBox.Show("This member already borrowed this book and has not returned it.");
                return;
            }

            string newId = "R" + (AppData.BorrowRecords.Count + 1).ToString("D4");

            AppData.BorrowRecords.Add(new BorrowRecord
            {
                RecordId = newId,
                BookId = bookId,
                MemberId = memberId,
                BorrowDate = DateTime.Now
            });

            book.AvailableCopies -= 1;

            RefreshGrid();
            MessageBox.Show("Borrowed successfully.");
        }

        private void btnReturnSelected_Click(object sender, EventArgs e)
        {
            if (gridBorrows.CurrentRow == null)
            {
                MessageBox.Show("Select a borrow record from the table.");
                return;
            }

            var cellValue = gridBorrows.CurrentRow.Cells["RecordId"]?.Value;
            if (cellValue == null)
            {
                MessageBox.Show("RecordId column not found in the grid. Refresh and try again.");
                return;
            }

            string recordId = cellValue.ToString();
            var rec = AppData.BorrowRecords.FirstOrDefault(r => r.RecordId == recordId);

            if (rec == null)
            {
                MessageBox.Show("Borrow record not found.");
                return;
            }

            if (rec.IsReturned)
            {
                MessageBox.Show("This record is already returned.");
                return;
            }

            rec.ReturnDate = DateTime.Now;

            var book = AppData.Books.FirstOrDefault(b => b.BookId == rec.BookId);
            if (book != null)
                book.AvailableCopies += 1;

            RefreshGrid();
            MessageBox.Show("Returned successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
