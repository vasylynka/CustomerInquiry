using System.Collections.Generic;
using CustomerInquiry.Entities.Base;

namespace CustomerInquiry.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }
        
        public string Name { get; set; }

        public string ContactEmail { get; set; }

        public string MobileNo { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
