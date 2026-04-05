
namespace LibraryManagementSystem
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageBooks = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMyBorrows = new System.Windows.Forms.Button();
            this.btnBorrowReturn = new System.Windows.Forms.Button();
            this.btnManageMembers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(200, 49);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(118, 29);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "welcome";
            // 
            // btnManageBooks
            // 
            this.btnManageBooks.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnManageBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBooks.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageBooks.Location = new System.Drawing.Point(12, 88);
            this.btnManageBooks.Name = "btnManageBooks";
            this.btnManageBooks.Size = new System.Drawing.Size(186, 65);
            this.btnManageBooks.TabIndex = 1;
            this.btnManageBooks.Text = "ManageBooks";
            this.btnManageBooks.UseVisualStyleBackColor = false;
            this.btnManageBooks.Click += new System.EventHandler(this.btnManageBooks_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Red;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(462, 293);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(108, 47);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMyBorrows
            // 
            this.btnMyBorrows.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnMyBorrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyBorrows.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMyBorrows.Location = new System.Drawing.Point(236, 152);
            this.btnMyBorrows.Name = "btnMyBorrows";
            this.btnMyBorrows.Size = new System.Drawing.Size(220, 73);
            this.btnMyBorrows.TabIndex = 3;
            this.btnMyBorrows.Text = "MyBorrows";
            this.btnMyBorrows.UseVisualStyleBackColor = false;
            this.btnMyBorrows.Click += new System.EventHandler(this.btnMyBorrows_Click);
            // 
            // btnBorrowReturn
            // 
            this.btnBorrowReturn.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBorrowReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrowReturn.Location = new System.Drawing.Point(12, 172);
            this.btnBorrowReturn.Name = "btnBorrowReturn";
            this.btnBorrowReturn.Size = new System.Drawing.Size(186, 64);
            this.btnBorrowReturn.TabIndex = 4;
            this.btnBorrowReturn.Text = "BorrowReturn";
            this.btnBorrowReturn.UseVisualStyleBackColor = false;
            this.btnBorrowReturn.Click += new System.EventHandler(this.btnBorrowReturn_Click);
            // 
            // btnManageMembers
            // 
            this.btnManageMembers.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnManageMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageMembers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageMembers.Location = new System.Drawing.Point(12, 253);
            this.btnManageMembers.Name = "btnManageMembers";
            this.btnManageMembers.Size = new System.Drawing.Size(186, 65);
            this.btnManageMembers.TabIndex = 5;
            this.btnManageMembers.Text = "ManageMembers";
            this.btnManageMembers.UseVisualStyleBackColor = false;
            this.btnManageMembers.Click += new System.EventHandler(this.btnManageMembers_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(161, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Library Management System";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 365);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnManageMembers);
            this.Controls.Add(this.btnBorrowReturn);
            this.Controls.Add(this.btnMyBorrows);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageBooks);
            this.Controls.Add(this.lblWelcome);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageBooks;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMyBorrows;
        private System.Windows.Forms.Button btnBorrowReturn;
        private System.Windows.Forms.Button btnManageMembers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}