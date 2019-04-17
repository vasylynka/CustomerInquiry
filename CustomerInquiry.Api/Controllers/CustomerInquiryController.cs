using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerInquiry.Api.Infrastructure.ParameterBinding;
using CustomerInquiry.Services.Interfaces;
using CustomerInquiry.Services.Models.SearchModels;
using CustomerInquiry.Services.Models.ViewModels;

namespace CustomerInquiry.Api.Controllers
{
    [RoutePrefix("api/customer-inquiry")]
    public class CustomerInquiryController : ApiController
    {
        private readonly ICustomerInquiryService _customerInquiryService;

        public CustomerInquiryController(ICustomerInquiryService customerInquiryService)
        {
            _customerInquiryService = customerInquiryService;
        }

        [Route("")]
        [HttpGet]
        [ResponseType(typeof(CustomerViewModel))]
        public async Task<IHttpActionResult> Get([SearchQuery] CustomerInquirySearchModel query)
        {
            return Ok(await _customerInquiryService.GetAsync(query));
        }
    }
}