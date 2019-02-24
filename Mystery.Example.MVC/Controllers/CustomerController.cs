using Mystery.Example.BLL.Common.Interfaces;
using System.Web.Mvc;
using Mystery.Example.BLL.Common.Models.Customer;

namespace Mystery.Example.MVC.Controllers
{
    using System;

    public class CustomerController : Controller
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service) => this.service = service ?? throw new ArgumentNullException(nameof(service));

        public ActionResult AllCustomers() => View(this.service.GetAll());

        public ActionResult CreateCustomer() => View();

        [HttpPost]
        public ActionResult CreateCustomer(CustomerRequestModel customer) => View(this.service.Create(customer));
    }
}