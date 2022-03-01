using EnalyserAssignment.DAL.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EnalyserAssignment.BAL
{
    public class Cash : ICash
    {
        public readonly EnalyserATMContext _context;
        public Cash(EnalyserATMContext context)
        {
            _context = context;
        }
        public List<Notes> GetAllNotesDetails()
        {
            try
            {
                var notes = _context.Notes.ToList();
                return notes;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;            
            }
        }
        public List<CashWithdrawal> GetCash(int amount)
        {
            var cashWithdrawals = new List<CashWithdrawal>();
            try
            {
                var notes = _context.Notes.ToList().OrderByDescending(x => x.Amount);
                foreach (var note in notes)
                {
                    if (amount >= note.Amount)
                    {
                        var cashWithdrawal = new CashWithdrawal();
                        cashWithdrawal.Count = amount / note.Amount;
                        amount = amount - cashWithdrawal.Count * note.Amount;
                        cashWithdrawal.Amount = note.Amount;
                        cashWithdrawal.NoteType = note.NoteType;
                        cashWithdrawal.Size = note.Size;
                        cashWithdrawals.Add(cashWithdrawal);
                    }
                }
                return cashWithdrawals;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
