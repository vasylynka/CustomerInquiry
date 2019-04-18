using Core.Infrastructure.Common;

namespace CustomerInquiry.Services.Models.SearchModels
{
    public class CustomerInquirySearchModel : ISearchModel
    {
        public int? CustomerID { get; set; }
        
        public string Email { get; set; }
    }
}
