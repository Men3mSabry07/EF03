using EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace EF03.Data
{
    public static class Seeding
    {
        public static void Seed(ModelBuilder Builder)
        {
            // Seed Managers
            Builder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 3,
                    FullName = "Abdelmenem Sabry Abdelaty",
                    Email = "men3m@gmail.com",
                    PhoneNumber = "01141562494",
                    HireDate = new DateTime(2005, 8, 16)
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Omar Ali",
                    Email = "omar@gmail.com",
                    PhoneNumber = "01098765432",
                    HireDate = new DateTime(2021, 5, 10)
                }
            );

            // Seed Branches
            Builder.Entity<Branch>().HasData(
                new Branch
                {
                    Code = "BR01",
                    Name = "Assiut Branch",
                    Address = "Assiut, Egypt",
                    PhoneNumber = "01028841318",
                    ManagerId = 3
                },
                new Branch
                {
                    Code = "BR02",
                    Name = "Cairo Branch",
                    Address = "Cairo, Egypt",
                    PhoneNumber = "01141562494",
                    ManagerId = 2
                }
            );
        }
    }
}
