using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public interface ICustomersRepository
    {
        public string CreateCustomer(CustomerDTO createCustomer);
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetById(int id);
        public bool DeleteCustomer(int id);
        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer);
    }
}
