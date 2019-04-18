using System.Data.Entity.Migrations;
using System.Linq;
using CustomerInquiry.Entities;

namespace CustomerInquiry.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.CustomerInquiryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infrastructure.CustomerInquiryDbContext context)
        {
            var isUpdated = false;
            
            if (!context.Set<Currency>().Any())
            {
                context.Set<Currency>().AddOrUpdate(x => x.Id,
                    new Currency { Code = "AUD" },
                    new Currency { Code = "BGN" },
                    new Currency { Code = "BRL" },
                    new Currency { Code = "CAD" },
                    new Currency { Code = "CHF" },
                    new Currency { Code = "CNY" },
                    new Currency { Code = "CZK" },
                    new Currency { Code = "DKK" },
                    new Currency { Code = "EUR" },
                    new Currency { Code = "GBP" },
                    new Currency { Code = "HKD" },
                    new Currency { Code = "HRK" },
                    new Currency { Code = "HUF" },
                    new Currency { Code = "IDR" },
                    new Currency { Code = "ILS" },
                    new Currency { Code = "INR" },
                    new Currency { Code = "ISK" },
                    new Currency { Code = "JPY" },
                    new Currency { Code = "KRW" },
                    new Currency { Code = "MXN" },
                    new Currency { Code = "MYR" },
                    new Currency { Code = "NOK" },
                    new Currency { Code = "NZD" },
                    new Currency { Code = "PHP" },
                    new Currency { Code = "PLN" },
                    new Currency { Code = "RON" },
                    new Currency { Code = "RUB" },
                    new Currency { Code = "SEK" },
                    new Currency { Code = "SGD" },
                    new Currency { Code = "THB" },
                    new Currency { Code = "TRY" },
                    new Currency { Code = "USD" },
                    new Currency { Code = "ZAR" });

                isUpdated = true;
            }

            if (isUpdated)
                context.SaveChanges();
        }
    }
}
