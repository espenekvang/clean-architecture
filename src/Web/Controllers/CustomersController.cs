using Application.Customer;
using Microsoft.AspNetCore.Mvc;
using Web.Requests;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        internal static class Route
        {
            public const string GetCustomer = "GetCustomer";
        }

        private readonly ILogger<CustomersController> _logger;
        private readonly CreateCustomerUseCase _createCustomerUseCase;

        public CustomersController(ILogger<CustomersController> logger, CreateCustomerUseCase createCustomerUseCase)
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
                var (success, customerId, message ) = _createCustomerUseCase.Create(request.Name, request.CustomerId, request.Country);

                if (success)
                {
                    _logger.LogInformation("Customer with id {0} created", customerId);
                    return CreatedAtRoute(Route.GetCustomer, new { customerId = customerId.Value }, customerId);
                }

                _logger.LogError(message);
                return BadRequest(message);

        }
    }
}
