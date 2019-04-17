using System.Collections.Generic;

namespace CustomerInquiry.Entities
{
    public class Customer
    {
        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactEmail { get; set; }

        public string MobileNo { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
