using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }

        public decimal CurrentBalance { get; set; }

        public string AccountType { get; set; } = string.Empty;
        public DateTime OpeningDate { get; set; }
        // forign Key
        public string BranchCode { get; set; }

        // Navigation Property
        public Branch Branch { get; set; }
        public ICollection<AccountOwnership> AccountOwnerships { get; set; } = new List<AccountOwnership>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}