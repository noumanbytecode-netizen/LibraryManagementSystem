using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Security;
using LibraryManagementSystem.Storage;

namespace LibraryManagementSystem.Data
{
    public static class AppData
    {
        public static List<User> Users = new List<User>();
        public static List<Book> Books = new List<Book>();
        public static List<Member> Members = new List<Member>();
        public static List<BorrowRecord> BorrowRecords = new List<BorrowRecord>();

        public static void LoadAll()
        {
            Users = JsonStore.Load<User>("Users.json");
            Books = JsonStore.Load<Book>("Books.json");
            Members = JsonStore.Load<Member>("Members.json");
            BorrowRecords = JsonStore.Load<BorrowRecord>("BorrowRecords.json");

            // Ensure admin exists always
            EnsureAdmin();
        }

        public static void SaveAll()
        {
            JsonStore.Save("Users.json", Users);
            JsonStore.Save("Books.json", Books);
            JsonStore.Save("Members.json", Members);
            JsonStore.Save("BorrowRecords.json", BorrowRecords);
        }

        private static void EnsureAdmin()
        {
            // Create admin if not exists
            if (!Users.Any(u => u.Username.Equals("admin") && u.Role == UserRole.Librarian))
            {
                Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = PasswordHelper.Sha256("admin123"),
                    Role = UserRole.Librarian
                });
            }
        }

        // Keep this for first-time sample ONLY if you want (optional)
        public static void Seed()
        {
            // If books/members empty, you can put sample data here.
            // Otherwise keep empty.
        }
    }
}
