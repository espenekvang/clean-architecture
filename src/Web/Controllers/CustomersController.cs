using Application;
using Application.Customers;
using Domain.Customers;
using Infrastructure.Customers;
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
        private readonly ICommandHandler<CreateCustomer> _createCustomerCommand;
        private readonly IQueryHandler<GetCustomer, Customer?> _getCustomerQuery;

        public CustomersController(ILogger<CustomersController> logger, ICommandHandler<CreateCustomer> createCustomerCommand, IQueryHandler<GetCustomer, Customer?> getCustomerQuery)
        {
            _logger = logger;
            _createCustomerCommand = createCustomerCommand;
            _getCustomerQuery = getCustomerQuery;
        }

        [HttpGet]
        [Route("{customerId}", Name = Route.GetCustomer)]
        public async Task<IActionResult> Get(string customerId, CancellationToken ct)
        {
            var customer = await _getCustomerQuery.Run(GetCustomer.With(customerId), ct);

            if (customer != null)
            {
                return Ok(new { customerId = customer.Id });
            }

            return NotFound(customerId);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request, CancellationToken ct)
        {
            try
            {
                await _createCustomerCommand.Handle(CreateCustomer.With(request.Name, request.CustomerId, request.Country), ct);
                return CreatedAtRoute(Route.GetCustomer, new { customerId = request.CustomerId }, request.CustomerId);
            }
            catch (TaskCanceledException cte)
            {
                _logger.LogError(cte, cte.Message);
                return StatusCode(499); //Client Closed Request
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Unable to create customer. Message was: {e.Message}");
                return BadRequest($"Unable to create customer because of: {e.Message}");
            }
        }
    }
}
