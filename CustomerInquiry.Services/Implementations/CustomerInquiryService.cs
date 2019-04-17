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
            var searchPredicate = new CustomerInquirySearchCriteriaBuilder().Build(query);
            var customer = await _unitOfWorkAsync.LoadAsync(searchPredicate, x => x.Transactions);

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
                CustomerID = customer.Id,
                Name = customer.Name,
                Email = customer.ContactEmail,
                Mobile = customer.MobileNo,
                Transactions = recentTransactions,
            };
        }
    }
}
