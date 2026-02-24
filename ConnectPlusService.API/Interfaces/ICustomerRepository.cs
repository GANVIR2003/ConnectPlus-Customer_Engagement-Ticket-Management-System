using ConnectPlus.API.Models;

namespace ConnectPlus.API.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer? GetByEmail(string email);
        void Add(Customer customer);
    }
}