namespace CustomerInquiry.Services.Models.ViewModels
{
    public class TransactionViewModel : IdentityViewModel
    {
        public string Date { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }
    }
}
