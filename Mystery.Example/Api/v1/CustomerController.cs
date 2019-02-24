using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Common.Models.Customer;
using System.Web.Http;

namespace Mystery.Example.Api.v1
{
    using System;

    public class CustomerController : ApiController
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service) =>
            this.service = service ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        public IHttpActionResult GetCustomers() => this.Ok(this.service.GetAll());

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return this.Ok(this.service.Get(id));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomers([FromBody] CustomerRequestModel customer)
        {
            var createdCustomer = this.service.Create(customer);

            return this.CreatedAtRoute("Get", new { id = createdCustomer.Id }, createdCustomer);
        }
    }
}
