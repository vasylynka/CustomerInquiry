using System.Collections.Generic;

namespace CustomerInquiry.Services.Models.ViewModels
{
    public class CustomerViewModel : IdentityViewModel
    {
        public int CustomerID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public ICollection<TransactionViewModel> Transactions { get; set; }
    }
}
