using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF03.Models
{
        public class Branch
        {
            public string Code { get; set; }

            public string Name { get; set; }

            public string Address { get; set; }

            public string PhoneNumber { get; set; }

        // Foreign Key
        public int ManagerId { get; set; }

        // Navigation Property
        public Manager Manager { get; set; } = null!;

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
