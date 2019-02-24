using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Common.Models.Customer;
using Mystery.Example.BLL.Conveter.Customer;
using Mystery.Example.DAL.Common.Interfaces;
using Mystery.Example.DAL.Common.Models.Customer;
using System.Collections.Generic;
using System.Linq;

namespace Mystery.Example.BLL.Services
{
    using System;

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public CustomerService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var repository = unitOfWork.GetGenericRepository<CustomerDbModel, int>();

                return repository.GetAll().Select(ConvertCustomerDbModel.ToModel);
            }
        }

        public CustomerModel Get(int id)
        {
            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var repository = unitOfWork.GetGenericRepository<CustomerDbModel, int>();

                return ConvertCustomerDbModel.ToModel(repository.Get(id));
            }
        }

        public CustomerModel Create(CustomerRequestModel customer)
        {
            var customerDbModel = ConvertCustomerView.ToDbModel(customer);

            using (var unitOfWork = this.unitOfWorkFactory.Create())
            {
                var repository = unitOfWork.GetGenericRepository<CustomerDbModel, int>();

                repository.Add(customerDbModel);

                unitOfWork.SaveChanges();
            }

            return ConvertCustomerDbModel.ToModel(customerDbModel);
        }
    }
}
