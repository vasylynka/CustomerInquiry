using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CustomerInquiry.Entities;

namespace CustomerInquiry.EntityFramework.Configurations
{
    internal class CustomerConfigration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(x => x.Name).HasMaxLength(30).IsRequired();
            Property(x => x.ContactEmail).HasMaxLength(25).IsRequired();
            Property(x => x.MobileNo).HasMaxLength(10).IsRequired();
        }
    }
}
