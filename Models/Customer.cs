using System;
using System.Collections.Generic;
using System.Linq;
namespace EF03.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateOnly DateOfBirth { get;  set; }
        public string Address { get;  set; }

        public string Email { get;  set; }

        public string PhoneNumber { get;  set; }

        public string CustomerType { get;  set; }

        public string NationalId { get;  set; }

        // Navigation Properties
        public ICollection<AccountOwnership> AccountOwnerships { get;  set; } = new List<AccountOwnership>();
    }
}
