using Domain.MeteringPoint;
using Domain.ValueTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using UseCase.Customer;
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
            public const string GetMeteringPoints = "GetMeteringPoints";
        }

        private readonly ILogger<CustomersController> _logger;
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly GetCustomerUseCase _getCustomerUseCase;

        public CustomersController(ILogger<CustomersController> logger, CreateCustomerUseCase createCustomerUseCase, GetCustomerUseCase getCustomerUseCase)
        {
            _logger = logger;
            _createCustomerUseCase = createCustomerUseCase;
            _getCustomerUseCase = getCustomerUseCase;
        }

        [HttpGet]
        [Route("{customerId}", Name = Route.GetCustomer)]
        public IActionResult Get(string customerId)
        {
            var customer = _getCustomerUseCase.Get(CustomerId.From(customerId));
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound(customerId);
            }
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

        [HttpGet]
        [Route("{customerId}/meteringpoints", Name = Route.GetMeteringPoints)]
        public IList<MeteringPointEntity> GetMeteringPoints(string customerId)
        {
            var customer = _getCustomerUseCase.Get(CustomerId.From(customerId));

            return customer != null ? customer.MeteringPoints : Enumerable.Empty<MeteringPointEntity>().ToList();
        }
    }
}
