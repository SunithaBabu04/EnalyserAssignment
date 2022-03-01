using System;
using System.Collections.Generic;
using System.Text;

namespace EnalyserAssignment.DAL.Models
{
    public class CashWithdrawal
    {
        public int Amount { get; set; }
        public int Count { get; set; }
        public bool NoteType { get; set; }
        public int? Size { get; set; }
    }
}
