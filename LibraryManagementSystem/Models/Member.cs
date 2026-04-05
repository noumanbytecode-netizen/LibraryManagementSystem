using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public string MemberId { get; set; }   // e.g. M001
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
