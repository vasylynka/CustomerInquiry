using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Dal;
using Core.Infrastructure.Extensions;
using Core.Infrastructure.Helpers;
using CustomerInquiry.Services.Interfaces;
using CustomerInquiry.Services.Models.SearchModels;
using CustomerInquiry.Services.Models.ViewModels;
using CustomerInquiry.Services.SearchCriterias;

namespace CustomerInquiry.Services.Implementations
{
    public class CustomerInquiryService : ICustomerInquiryService
    {
        private const int CountOfTopRecentElements = 5;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public CustomerInquiryService(IUnitOfWorkAsync unitOfWork)
        {
            _unitOfWorkAsync = unitOfWork;
        }

        public async Task<CustomerViewModel> GetAsync(CustomerInquirySearchModel query)
        {
            query.ThrowNoValidIf(q => string.IsNullOrEmpty(q.Email) && !q.CustomerID.HasValue,
                "Bad Request");
            query.ThrowNoValidIf(q => !string.IsNullOrEmpty(q.Email) && !q.Email.IsValidEmail(),
                "Invalid Email");

            var searchPredicate = new CustomerInquirySearchCriteriaBuilder().Build(query);
            var customer = await _unitOfWorkAsync.LoadAsync(searchPredicate, x => x.Transactions);

            customer.ThrowIfNull("Customer Inquiry is not found");

            var recentTransactions = customer.Transactions
                .OrderByDescending(t => t.DateTime)
                .Take(CountOfTopRecentElements)
                .Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Currency = t.Currency.Code,
                    Date = Helper.Format(t.DateTime),
                    Status = t.Status.GetDescription()
                })
                .ToList();

            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.ContactEmail,
                Mobile = customer.MobileNo,
                Transactions = recentTransactions,
            };
        }
    }
}
