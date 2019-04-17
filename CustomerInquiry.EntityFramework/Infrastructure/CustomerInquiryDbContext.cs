using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CustomerInquiry.Entities;
using CustomerInquiry.Entities.Base;
using CustomerInquiry.EntityFramework.Configurations;

namespace CustomerInquiry.EntityFramework.Infrastructure
{
    [DbConfigurationType(typeof(ContextConfiguration))]
    internal class CustomerInquiryDbContext : DbContext
    {
        #region Entity registrations

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion

        public CustomerInquiryDbContext() : base("CustomerInquiryDbContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<CustomerInquiryDbContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            modelBuilder.Ignore<Entity>();

            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new TransactionConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfigration());
        }
    }
}
