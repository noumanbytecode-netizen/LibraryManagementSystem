using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public enum UserRole
    {
        Librarian = 1,
        Member = 2
    }

    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }   // store hash, not plain password
        public UserRole Role { get; set; }
        public string MemberId { get; set; }       // only for Member role (optional)
    }
}

