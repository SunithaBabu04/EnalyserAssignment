using EnalyserAssignment.DAL.Models;
using System.Collections.Generic;

namespace EnalyserAssignment.BAL
{
    public interface ICash
    {
        List<Notes> GetAllNotesDetails();
        List<CashWithdrawal> GetCash(int amount);
    }
}
