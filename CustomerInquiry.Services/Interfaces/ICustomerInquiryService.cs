using System.Threading.Tasks;
using CustomerInquiry.Services.Models.SearchModels;
using CustomerInquiry.Services.Models.ViewModels;

namespace CustomerInquiry.Services.Interfaces
{
    public interface ICustomerInquiryService
    {
        /// <summary>
        /// Get customer info by email and identifier
        /// </summary>
        Task<CustomerViewModel> GetAsync(CustomerInquirySearchModel query);
    }
}
