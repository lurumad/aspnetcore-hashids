using AspNetCore.Hashids;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly IEnumerable<CustomerDto> customers = new CustomerDto[]
            {
                new CustomerDto
                {
                    Id = 1,
                    NonHashid = 10000,
                    FirstName = "Luis",
                    LastName = "Ruiz"
                },
                new CustomerDto
                {
                    Id = 2,
                    NonHashid = 20000,
                    FirstName = "Unai",
                    LastName = "Zorrilla"
                }
            };

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:hashids}")]
        public ActionResult<CustomerDto> Get(
            [ModelBinder(typeof(HashidsModelBinder))] int id)
        {
            return Ok(customers.SingleOrDefault(c => c.Id == id));
        }
    }
}
