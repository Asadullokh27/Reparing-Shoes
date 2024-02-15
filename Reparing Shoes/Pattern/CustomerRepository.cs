using Npgsql;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;
using Dapper;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

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
                    string query = "insert into customer(fulla_name) values (@full_name)";
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
            
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                string query = "select * from customer";
                var result = connection.Query<CustomerDTO>(query);

                return result;

            }

        }

        public Customer GetById(int id)
        {
          
            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sql = "select * from customer where id = @id;";
                connection.Execute(sql, new CustomerDTO
                {
                    Id = Customer.,
                });

                return viewModel;

            }
        }

        public Customer UpdateCustomer(int id, CustomerDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
