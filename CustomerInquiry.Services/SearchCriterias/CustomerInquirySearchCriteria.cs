using Core.Infrastructure.Dal.Criterias;
using CustomerInquiry.Entities;
using CustomerInquiry.Services.Models.SearchModels;

namespace CustomerInquiry.Services.SearchCriterias
{
    internal class CustomerInquirySearchCriteriaBuilder : BaseCriteriaBuilder<Customer, CustomerInquirySearchModel>
    {
        public CustomerInquirySearchCriteriaBuilder()
        {
            AddCriteria(m => c => m.Email == c.ContactEmail)
                .When(m => !string.IsNullOrEmpty(m.Email));

            AddCriteria(m => c => m.CustomerID == c.Id)
                .When(m => m.CustomerID.HasValue);
        }
    }
}
