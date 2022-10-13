using Application;
using Application.Customers;
using Application.Customers.Commands;
using Application.Customers.Queries;
using Domain.Customers;
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
        private readonly ICommandHandler<CreateCustomerCommand> _createCustomerHandler;
        private readonly IQueryHandler<GetCustomerQuery, Customer?> _getCustomerHandler;

        public CustomersController(ILogger<CustomersController> logger, ICommandHandler<CreateCustomerCommand> createCustomerHandler, IQueryHandler<GetCustomerQuery, Customer?> getCustomerHandler)
        {
            _logger = logger;
            _createCustomerHandler = createCustomerHandler;
            _getCustomerHandler = getCustomerHandler;
        }

        [HttpGet]
        [Route("{customerId}", Name = Route.GetCustomer)]
        public async Task<IActionResult> Get(string customerId, CancellationToken ct)
        {
            var customer = await _getCustomerHandler.Handle(GetCustomerQuery.With(customerId), ct);

            if (customer != null)
            {
                return Ok(new { customerId = customer.Id });
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request, CancellationToken ct)
        {
            try
            {
                await _createCustomerHandler.Handle(CreateCustomerCommand.With(request.Name, request.CustomerId, request.Country), ct);
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
