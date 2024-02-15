using Npgsql;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;
using Dapper;
using System.Reflection.Metadata;
using System.Diagnostics.Metrics;

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
                    string query = "insert into customer(full_name) values (@full_name)";
                    var parametr = new CustomerDTO
                    {
                        fullName = createCustomer.fullName
                    };
                    connection.Execute(query, parametr);

                }
                return "Succesfully created!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = $"delete from customer where id = @id";

                    connection.Execute(query, new { id });

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from customer";

                    var result = connection.Query<Customer>(query);

                    return result;
                }
            }
            catch
            {
                return Enumerable.Empty<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from customer where id = @id";

                    var result = connection.ExecuteReader(query, new { id });

                    return (Customer)result;
                }
            }
            catch
            {
                return (Customer)Enumerable.Empty<Customer>();
            }
        }

        public CustomerDTO UpdateCustomer(int id, CustomerDTO customer)
        {
            try
            {
                string query = "update customer set full_name = @fullName";
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(query, new CustomerDTO
                    {
                        fullName = customer.fullName!,
                        
                    });
                    return customer;

                }
            }
            catch
            {
                return (CustomerDTO)Enumerable.Empty<Master>();
            }
        }
    }
}
