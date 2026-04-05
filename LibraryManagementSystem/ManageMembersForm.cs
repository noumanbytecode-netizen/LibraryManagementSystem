using System;
using System.Linq;
using System.Windows.Forms;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Security;

namespace LibraryManagementSystem
{
    public partial class ManageMembersForm : Form
    {
        public ManageMembersForm()
        {
            InitializeComponent();
            this.Load += ManageMembersForm_Load;

            if (gridMembers != null)
                gridMembers.CellClick += gridMembers_CellClick;

            // numeric-only for MemberId
            if (txtMemberId != null)
                txtMemberId.KeyPress += txtMemberId_KeyPress;
        }

        private void ManageMembersForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            gridMembers.DataSource = null;
            gridMembers.DataSource = AppData.Members.ToList();
        }

        // allow only digits in MemberId
        private void txtMemberId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;   // backspace etc.
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();
            string fullName = txtFullName.Text.Trim();   // username
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();   // separate password

            if (string.IsNullOrWhiteSpace(memberId) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("MemberId, Member Name and Password are required.");
                return;
            }

            if (!memberId.All(char.IsDigit))
            {
                MessageBox.Show("MemberId must be numbers only.");
                return;
            }

            // MemberId unique
            if (AppData.Members.Any(m => m.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("MemberId already exists.");
                return;
            }

            // Username (FullName) unique for login
            if (AppData.Users.Any(u => u.Username.Equals(fullName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("This Member Name already exists as username. Use different name.");
                return;
            }

            // Add Member
            AppData.Members.Add(new Member
            {
                MemberId = memberId,
                FullName = fullName,
                Phone = phone
            });

            // Create login: Username = Name, Password = txtPassword
            AppData.Users.Add(new User
            {
                Username = fullName,
                PasswordHash = PasswordHelper.Sha256(password),
                Role = UserRole.Member,
                MemberId = memberId
            });

            RefreshGrid();
            ClearInputs();
            MessageBox.Show("Member added. Login created.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();
            string newName = txtFullName.Text.Trim();
            string newPhone = txtPhone.Text.Trim();
            string newPassword = txtPassword.Text.Trim(); // optional

            if (string.IsNullOrWhiteSpace(memberId) || string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("MemberId and Member Name are required.");
                return;
            }

            if (!memberId.All(char.IsDigit))
            {
                MessageBox.Show("MemberId must be numbers only.");
                return;
            }

            var mem = AppData.Members.FirstOrDefault(m => m.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase));
            if (mem == null)
            {
                MessageBox.Show("Member not found.");
                return;
            }

            var user = AppData.Users.FirstOrDefault(u => u.Role == UserRole.Member && u.MemberId == memberId);

            // If changing username, ensure uniqueness
            if (user != null &&
                !user.Username.Equals(newName, StringComparison.OrdinalIgnoreCase) &&
                AppData.Users.Any(u => u.Username.Equals(newName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Cannot update: this Member Name already used as username.");
                return;
            }

            // Update Member
            mem.FullName = newName;
            mem.Phone = newPhone;

            // Update login
            if (user != null)
            {
                user.Username = newName;

                // Only update password if typed
                if (!string.IsNullOrWhiteSpace(newPassword))
                    user.PasswordHash = PasswordHelper.Sha256(newPassword);
            }

            RefreshGrid();
            ClearInputs();
            MessageBox.Show("Member updated.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();

            if (string.IsNullOrWhiteSpace(memberId))
            {
                MessageBox.Show("Enter MemberId.");
                return;
            }

            var mem = AppData.Members.FirstOrDefault(m => m.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase));
            if (mem == null)
            {
                MessageBox.Show("Member not found.");
                return;
            }

            bool hasActive = AppData.BorrowRecords.Any(r => r.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase) && !r.IsReturned);
            if (hasActive)
            {
                MessageBox.Show("Cannot delete: member has borrowed books not returned.");
                return;
            }

            var user = AppData.Users.FirstOrDefault(u => u.Role == UserRole.Member && u.MemberId == memberId);
            if (user != null)
                AppData.Users.Remove(user);

            AppData.Members.Remove(mem);

            RefreshGrid();
            ClearInputs();
            MessageBox.Show("Member + login deleted.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void gridMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gridMembers.Rows[e.RowIndex].DataBoundItem as Member;
            if (row == null) return;

            txtMemberId.Text = row.MemberId;
            txtFullName.Text = row.FullName;
            txtPhone.Text = row.Phone;

            // Never show password
            txtPassword.Clear();
        }

        private void ClearInputs()
        {
            txtMemberId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
        }

        // Keep these three methods to satisfy Designer event wiring (no errors)
        private void txtMemberId_TextChanged(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageMembersForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
