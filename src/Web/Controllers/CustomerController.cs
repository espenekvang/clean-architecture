using Microsoft.AspNetCore.Mvc;
using UseCase.Customer;
using Web.Requests;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        internal static class Route
        {
            public const string GetCustomer = "GetCustomer";
        }

        private readonly ILogger<CustomerController> _logger;
        private readonly CreateCustomerUseCase _createCustomerUseCase;

        public CustomerController(ILogger<CustomerController> logger, CreateCustomerUseCase createCustomerUseCase)
        {
            _logger = logger;
            _createCustomerUseCase = createCustomerUseCase;
        }

        [HttpGet]
        [Route("{customerId}", Name = Route.GetCustomer)]
        public IActionResult Get(string customerId)
        {
            return Ok(customerId);
        }

        [HttpPost]
        public IActionResult Create(CreateCustomerRequest request)
        {
            try
            {
                var customer = _createCustomerUseCase.Create(request.Name, request.CustomerId, request.Country);
                _logger.LogInformation("Customer with id {0} created", customer.Id);
             
                return CreatedAtRoute(Route.GetCustomer, new { customerId = customer.Id.Value }, customer);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to create customer");
                return BadRequest(e.Message);
            }
        }
    }
}
