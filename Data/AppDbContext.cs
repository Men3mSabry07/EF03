using EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace EF03.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountOwnership> AccountOwnerships { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connections.sqlConStr);
        }


        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Branch>()
                .HasKey(b => b.Code);

            Builder.Entity<Branch>()
                .HasOne(b => b.Manager)
                .WithOne(m => m.Branch)
                .HasForeignKey<Branch>(b => b.ManagerId)
                .IsRequired();

            Builder.Entity<Account>()
                .HasKey(a => a.AccountNumber);

            Builder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.BranchCode).IsRequired();

            // Composit Key
            Builder.Entity<AccountOwnership>()
                .HasKey(a => new{a.CustomerId, a.AccountNumber });

            Builder.Entity<AccountOwnership>()
                .HasOne(ao => ao.Customer)
                .WithMany(c => c.AccountOwnerships)
                .HasForeignKey(ao => ao.CustomerId).IsRequired();

            Builder.Entity<AccountOwnership>()
                .HasOne(ao => ao.Account)
                .WithMany(a => a.AccountOwnerships)
                .HasForeignKey(ao => ao.AccountNumber).IsRequired();

            Builder.Entity<Transaction>()
                .HasKey(t => t.TransactionNumber);

            Builder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountNumber).IsRequired();


            Seeding.Seed(Builder);
        }
    }
}
