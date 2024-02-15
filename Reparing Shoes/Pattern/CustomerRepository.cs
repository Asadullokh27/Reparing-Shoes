using Npgsql;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;
using Dapper;
using System.Reflection.Metadata;

namespace Reparing_Shoes.Pattern
{
    public class CustomerRepository : ICustomersRepository
    {
        private IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateCustomer(CustomerDTO createCustomer)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "insert into customers(fulla_name) values (@full_name)";
                    var parametr = new CustomerDTO
                    {
                        fullName = createCustomer.fullName
                    };
                    connection.Execute(query, parametr);

                }
                return "created";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int id, CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
