using System;
using System.Collections.Generic;

namespace EnalyserAssignment.DAL.Models
{
    public partial class Notes
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public bool NoteType { get; set; }
        public int? Size { get; set; }
    }
}
