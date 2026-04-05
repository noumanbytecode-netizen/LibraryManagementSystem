using System;

namespace LibraryManagementSystem.Models
{
    public class BorrowRecord
    {
        public string RecordId { get; set; }   // e.g. R0001
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
    }
}
