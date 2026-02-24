//Duplicate Prevention
using ConnectPlus.API.Interfaces;
using ConnectPlus.API.Models;
using ConnectPlus.API.Exceptions;

namespace ConnectPlus.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public void CreateCustomer(Customer customer)
        {
            var existing = _repository.GetByEmail(customer.Email!);

            if (existing != null)
                throw new DuplicateCustomerException(
    "A customer with this email already exists.");

            customer.CreatedDate = DateTime.Now;
            _repository.Add(customer);
        }
    }
}