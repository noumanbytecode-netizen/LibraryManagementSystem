using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    public partial class ManageBooksForm : Form
    {
        public ManageBooksForm()
        {
            InitializeComponent();
        }

        private void ManageBooksForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            gridBooks.DataSource = null;
            gridBooks.DataSource = AppData.Books.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTotal.Text.Trim(), out int total) || total < 0)
            {
                MessageBox.Show("Total copies must be a valid non-negative integer.");
                return;
            }

            string id = txtBookId.Text.Trim();
            if (string.IsNullOrWhiteSpace(id) || AppData.Books.Any(b => b.BookId == id))
            {
                MessageBox.Show("BookId is empty or already exists.");
                return;
            }

            var book = new Book
            {
                BookId = id,
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                TotalCopies = total,
                AvailableCopies = total
            };

            AppData.Books.Add(book);
            RefreshGrid();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtBookId.Text.Trim();
            var book = AppData.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            if (!int.TryParse(txtTotal.Text.Trim(), out int total) || total < 0)
            {
                MessageBox.Show("Total copies must be a valid non-negative integer.");
                return;
            }

            // Adjust available copies carefully
            int borrowed = book.TotalCopies - book.AvailableCopies;
            if (total < borrowed)
            {
                MessageBox.Show($"Cannot set total below already borrowed copies ({borrowed}).");
                return;
            }

            book.Title = txtTitle.Text.Trim();
            book.Author = txtAuthor.Text.Trim();
            book.TotalCopies = total;
            book.AvailableCopies = total - borrowed;

            RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtBookId.Text.Trim();
            var book = AppData.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return;

            // Prevent delete if borrowed
            if (book.AvailableCopies != book.TotalCopies)
            {
                MessageBox.Show("Cannot delete: book currently borrowed.");
                return;
            }

            AppData.Books.Remove(book);
            RefreshGrid();
            ClearInputs();
        }

        private void gridBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = gridBooks.Rows[e.RowIndex].DataBoundItem as Book;
            if (row == null) return;

            txtBookId.Text = row.BookId;
            txtTitle.Text = row.Title;
            txtAuthor.Text = row.Author;
            txtTotal.Text = row.TotalCopies.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearInputs();

        private void ClearInputs()
        {
            txtBookId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtTotal.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageBooksForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
