﻿using System;
using CustomerInquiry.Entities.Types;

namespace CustomerInquiry.Entities
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int CurrencyId { get; set; }

        public Status Status { get; set; }

        public int CustomerId { get; set; }

        public decimal Amount { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
