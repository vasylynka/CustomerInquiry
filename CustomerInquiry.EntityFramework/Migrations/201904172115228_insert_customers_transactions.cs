using System.Globalization;

namespace CustomerInquiry.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class insert_customers_transactions : DbMigration
    {
        private DateTime RandomDay(Random random)
        {
            var start = new DateTime(1995, 1, 1);
            var range = (DateTime.Today - start).Days;

            return start.AddDays(random.Next(range));
        }

        public override void Up()
        {
            var customerInsertStatement = $@"insert into Customers (Name, ContactEmail, MobileNo)";

            Sql($@"{customerInsertStatement} values ('ABC Aps', 'abc@aps.to', '1020233311')");
            Sql($@"{customerInsertStatement} values ('BBC Aps', 'bbc@aps.to', '2224446666')");
            Sql($@"{customerInsertStatement} values ('ERT Aps', 'ert@aps.to', '2223423422')");
            Sql($@"{customerInsertStatement} values ('RTY Aps', 'rty@aps.to', '7555653567')");
            Sql($@"{customerInsertStatement} values ('NTR Aps', 'ntr@aps.to', '96432567e7')");

            var transactionInsertStatement = $@"insert into Transactions 
                (CurrencyId, Status, CustomerId, DateTime, Amount)";

            Random random = new Random();
            var maxIdOfCurrencies = 33;
            var maxIsOfCustomers = 6;

            for (int i = 0; i < 50; i++)
            {

                Sql($@"{transactionInsertStatement} values (
                {random.Next(1, maxIdOfCurrencies)},
                {random.Next(0, 2)},
                {random.Next(1, maxIsOfCustomers)},
                '{RandomDay(random).ToString(CultureInfo.InvariantCulture)}',
                {random.Next(1, 10000) / 100.0m})");
            }
        }

        public override void Down()
        {
            Sql($@"delete Transactions");
            Sql($@"delete Customers");
        }
    }
}
