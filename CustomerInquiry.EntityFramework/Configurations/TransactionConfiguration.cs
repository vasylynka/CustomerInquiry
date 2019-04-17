using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CustomerInquiry.Entities;

namespace CustomerInquiry.EntityFramework.Configurations
{
    internal class TransactionConfiguration : EntityTypeConfiguration<Transaction>
    {
        public TransactionConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Amount).HasPrecision(18, 2).IsRequired();
            Property(x => x.Status).IsRequired();
            Property(x => x.DateTime).IsRequired();

            HasRequired(x => x.Currency).WithMany().HasForeignKey(f => f.CurrencyId);
            HasRequired(x => x.Customer).WithMany(x => x.Transactions).HasForeignKey(f => f.CustomerId);
        }
    }
}
