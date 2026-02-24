using ConnectPlus.API.Models;

namespace ConnectPlus.API.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        void CreateCustomer(Customer customer);
    }
}