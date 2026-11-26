using System;
using Microsoft.EntityFrameworkCore;
using EF03.Data;
using EF03.Models;

namespace EF03
{
    internal class Program
    {
        static void AddCustomer()
        {
            using AppDbContext db = new AppDbContext();

            Console.Write("Full Name: ");
            string fullName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(fullName))
            {
                Console.Write("Invalid Name. Enter again: ");
                fullName = Console.ReadLine();
            }

            Console.Write("National ID: ");
            string nationalId = Console.ReadLine();

            while (db.Customers.Any(x => x.NationalId == nationalId)
                   || nationalId.Length != 14
                   || !nationalId.All(char.IsDigit))
            {
                Console.Write("National ID already exists or invalid. Enter again: ");
                nationalId = Console.ReadLine();
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.Write("Invalid Email. Enter again: ");
                email = Console.ReadLine();
            }

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(phone) || phone.Length != 11)
            {
                Console.Write("Invalid Phone. Enter again: ");
                phone = Console.ReadLine();
            }

            Console.Write("Address: ");
            string address = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.Write("Invalid Address. Enter again: ");
                address = Console.ReadLine();
            }

            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            DateOnly dateOfBirth;

            while (!DateOnly.TryParse(Console.ReadLine(), out dateOfBirth)
                   || dateOfBirth >= DateOnly.FromDateTime(DateTime.Today))
            {
                Console.Write("Invalid Date. Enter a valid Date of Birth: ");
            }

            Console.WriteLine("Customer Type:");
            Console.WriteLine("1) Individual");
            Console.WriteLine("2) Business");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                   || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid Choice. Enter 1 or 2: ");
            }

            string customerType = choice == 1 ? "Individual" : "Business";

            Customer customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                DateOfBirth = dateOfBirth,
                CustomerType = customerType
            };

            db.Customers.Add(customer);
            db.SaveChanges();

            Console.WriteLine("Customer Added Successfully!");
            Console.WriteLine("Customer ID: " + customer.Id);
        }
        static void OpenAccount()
        {
            using AppDbContext db = new AppDbContext();

            // Account Number
            Console.Write("Enter Account Number: ");
            int accountNumber;

            while (!int.TryParse(Console.ReadLine(), out accountNumber)
                   || accountNumber <= 0
                   || db.Accounts.Any(x => x.AccountNumber == accountNumber))
            {
                Console.Write("Invalid or existing Account Number. Enter again: ");
            }

            // Account Type
            Console.WriteLine("Account Type:");
            Console.WriteLine("1) Saving");
            Console.WriteLine("2) Current");
            Console.WriteLine("3) Business");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                   || choice < 1 || choice > 3)
            {
                Console.Write("Invalid Choice. Enter 1, 2, or 3: ");
            }

            string accountType = "";

            if (choice == 1)
                accountType = "Saving";
            else if (choice == 2)
                accountType = "Current";
            else
                accountType = "Business";

            // Branch Code
            Console.Write("Enter Branch Code: ");
            string branchCode = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(branchCode)
                   || !db.Branches.Any(x => x.Code == branchCode))
            {
                Console.Write("Branch does not exist. Enter another Branch Code: ");
                branchCode = Console.ReadLine();
            }

            // Customer ID
            Console.Write("Enter Customer ID: ");
            int customerId;

            while (!int.TryParse(Console.ReadLine(), out customerId)
                   || !db.Customers.Any(x => x.Id == customerId))
            {
                Console.Write("Customer does not exist or invalid ID. Enter again: ");
            }

            // Ownership Type
            Console.WriteLine("Ownership Type:");
            Console.WriteLine("1) Primary");
            Console.WriteLine("2) CoHolder");

            int ownershipChoice;

            while (!int.TryParse(Console.ReadLine(), out ownershipChoice)
                   || (ownershipChoice != 1 && ownershipChoice != 2))
            {
                Console.Write("Invalid Choice. Enter 1 or 2: ");
            }

            string ownershipType = ownershipChoice == 1 ? "Primary" : "CoHolder";

            // Create Account
            Account account = new Account
            {
                AccountNumber = accountNumber,
                CurrentBalance = 0,
                AccountType = accountType,
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };

            // Create Account Ownership
            AccountOwnership ownership = new AccountOwnership
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipStartDate = DateTime.Now,
                OwnershipType = ownershipType,
                AccountStatus = "Active"
            };

            db.Accounts.Add(account);
            db.AccountOwnerships.Add(ownership);

            db.SaveChanges();

            Console.WriteLine("Account Opened Successfully!");
            Console.WriteLine("Account Number: " + accountNumber);
        }
        static void UpdateAccountStatus()
        {
            using AppDbContext db = new AppDbContext();

            Console.Write("Enter Account Number: ");
            int accountNumber;

            while (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.Write("Invalid Account Number. Enter again: ");
            }

            Console.Write("Enter Customer ID: ");
            int customerId;

            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.Write("Invalid Customer ID. Enter again: ");
            }

            AccountOwnership ownership = db.AccountOwnerships.Find(customerId, accountNumber);

            if (ownership == null)
            {
                Console.WriteLine("Account Ownership Not Found!");
                return;
            }

            Console.WriteLine("New Account Status:");
            Console.WriteLine("1) Active");
            Console.WriteLine("2) Closed");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice)
                   || (choice != 1 && choice != 2))
            {
                Console.Write("Invalid Choice. Enter 1 or 2: ");
            }

            ownership.AccountStatus = choice == 1 ? "Active" : "Closed";

            db.SaveChanges();

            Console.WriteLine("Account Status Updated Successfully!");
        }
        static void RemoveAccountFromCustomer()
        {
            using AppDbContext db = new AppDbContext();

            Console.Write("Enter Account Number: ");
            int accountNumber;

            while (!int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Console.Write("Invalid Account Number. Enter again: ");
            }

            Console.Write("Enter Customer ID: ");
            int customerId;

            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.Write("Invalid Customer ID. Enter again: ");
            }

       
            AccountOwnership ownership = db.AccountOwnerships.Find(customerId, accountNumber);

            if (ownership == null)
            {
                Console.WriteLine("Account Ownership Not Found!");
                return;
            }

            db.AccountOwnerships.Remove(ownership);

            db.SaveChanges();

            Console.WriteLine("Account Removed From Customer Successfully!");
        }
        static void ViewCustomers()
        {
            using AppDbContext db = new AppDbContext();

            List<Customer> customers = db.Customers
                .Include(c => c.AccountOwnerships)
                .ThenInclude(ao => ao.Account)
                .ThenInclude(a => a.Branch)
                .ToList();

            Console.WriteLine("\n--- All Customers ---");

            foreach (Customer customer in customers)
            {
                Console.WriteLine(
                    $"\n#{customer.Id} {customer.FullName} ({customer.CustomerType})");

                if (customer.AccountOwnerships.Count == 0)
                {
                    Console.WriteLine("    (no accounts)");
                    continue;
                }

                foreach (AccountOwnership ownership in customer.AccountOwnerships)
                {
                    Account account = ownership.Account;

                    Console.WriteLine(
                        $"    {account.AccountNumber,-10} " +
                        $"{account.AccountType,-10} " +
                        $"Balance: {account.CurrentBalance,12:N2}   " +
                        $"{ownership.OwnershipType,-8} " +
                        $"{ownership.AccountStatus,-8} " +
                        $"@ {account.Branch.Name}");
                }
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("       National Bank - Management");
                Console.WriteLine("==========================================");
                Console.WriteLine("1) Add a new Customer");
                Console.WriteLine("2) Open a new Account for a Customer");
                Console.WriteLine("3) Update Account Status (Active / Closed)");
                Console.WriteLine("4) Remove an Account from a Customer");
                Console.WriteLine("5) List all Customers (with accounts)");
                Console.WriteLine("0) Exit");
                Console.WriteLine("------------------------------------------");

                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Choice!");
                    continue;
                }

                if (choice == 0)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;

                    case 2:
                        OpenAccount();
                        break;

                    case 3:
                        UpdateAccountStatus();
                        break;

                    case 4:
                        RemoveAccountFromCustomer();
                        break;

                    case 5:
                        ViewCustomers();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
