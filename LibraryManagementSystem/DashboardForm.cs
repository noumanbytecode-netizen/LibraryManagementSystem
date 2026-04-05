using System;
using System.Windows.Forms;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem
{
    public partial class DashboardForm : Form
    {
        private readonly User _currentUser;

        public DashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Safe if Load not connected
            this.Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (lblWelcome != null)
                lblWelcome.Text = $"Welcome: {_currentUser.Username} ({_currentUser.Role})";

            bool isLibrarian = _currentUser.Role == UserRole.Librarian;

            // Librarian/Admin: show only admin operations
            if (btnManageBooks != null) btnManageBooks.Visible = isLibrarian;
            if (btnManageMembers != null) btnManageMembers.Visible = isLibrarian;
            if (btnBorrowReturn != null) btnBorrowReturn.Visible = isLibrarian;

            // Member: show only My Borrows
            if (btnMyBorrows != null) btnMyBorrows.Visible = !isLibrarian;

            // Optional: disable as extra safety
            if (btnManageBooks != null) btnManageBooks.Enabled = isLibrarian;
            if (btnManageMembers != null) btnManageMembers.Enabled = isLibrarian;
            if (btnBorrowReturn != null) btnBorrowReturn.Enabled = isLibrarian;
            if (btnMyBorrows != null) btnMyBorrows.Enabled = !isLibrarian;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            // Extra safety: prevent member opening via any trick
            if (_currentUser.Role != UserRole.Librarian)
            {
                MessageBox.Show("Access denied.");
                return;
            }

            new ManageBooksForm().ShowDialog();
        }

        private void btnManageMembers_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Librarian)
            {
                MessageBox.Show("Access denied.");
                return;
            }

            new ManageMembersForm().ShowDialog();
        }

        private void btnBorrowReturn_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Librarian)
            {
                MessageBox.Show("Access denied.");
                return;
            }

            new BorrowReturnForm().ShowDialog();
        }

        private void btnMyBorrows_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != UserRole.Member)
            {
                MessageBox.Show("Access denied.");
                return;
            }

            new MyBorrowsForm(_currentUser).ShowDialog();
        }

        private void DashboardForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
