using Mystery.Example.BLL.Common.Models.Customer;
using System;
using System.Collections.Generic;

namespace Mystery.Example.BLL.Common.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAll();

        CustomerModel Get(int id);

        CustomerModel Create(CustomerRequestModel customer);
    }
}