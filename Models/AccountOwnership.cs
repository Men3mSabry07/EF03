using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Models
{
    public class AccountOwnership
    {
        // Foreign Keys
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }

        // Navigation Properties
        public Customer Customer { get; set; }

        public Account Account { get; set; }

        // Relationship Attributes
        public DateTime OwnershipStartDate { get; set; }

        public string OwnershipType { get; set; }

        public string AccountStatus { get; set; }
    }
}
