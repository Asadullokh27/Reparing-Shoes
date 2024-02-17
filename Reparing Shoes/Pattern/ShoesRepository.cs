using Dapper;
using Npgsql;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public class ShoesRepository : IShoesRepository
    {
        private IConfiguration _configuration;

        public ShoesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool DeleteShoes(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = $"delete from shoes where id = @id";

                    connection.Execute(query, new { id });

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Shoes> GetAllShoes()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = @"
                SELECT s.*, m.*, c.* 
                FROM shoes s 
                LEFT JOIN master m ON s.master_id = m.id 
                LEFT JOIN customer c ON s.customer_id = c.id;";

                    var result = connection.Query<Shoes, Master, Customer, Shoes>(
                        query,
                        (shoes, master, customer) =>
                        {
                            shoes.master = master;
                            shoes.customer = customer;
                            return shoes;
                        },
                        splitOn: "Id" // Assuming the Id is the primary key of the Shoes table
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately (logging, rethrowing, etc.)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Enumerable.Empty<Shoes>();
            }
        }

        public Shoes GetById(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from shoes where id = @id";

                    var result = connection.ExecuteReader(query, new { id });

                    return (Shoes)result;
                }
            }
            catch
            {
                return (Shoes)Enumerable.Empty<Shoes>();
            }
        }

        public ShoesDTO Post(ShoesDTO shoes)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "insert into shoes(Name,status,left_time,instruction,deadline,service_price,guarantee,master_id,customer_id) values (@Name,@status,@leftTime,@instruction,@deadTime,@service_price,@guarantee,@master,@customer)";
                    var parametr = new ShoesDTO
                    {
                        Name = shoes.Name,
                        status = shoes.status,
                        leftTime = shoes.leftTime,
                        instruction = shoes.instruction,
                        deadTime = shoes.deadTime,
                        service_price = shoes.service_price,
                        guarantee = shoes.guarantee,
                        master = shoes.master,
                        customer = shoes.customer,
                    };
                    connection.Execute(query, parametr);
                    return shoes;
                }
            }
            catch (Exception )
            {
                return (ShoesDTO)Enumerable.Empty<ShoesDTO>();
            }
        }

        public ShoesDTO UpdateShoes(ShoesDTO shoes,int id)
        {
            try
            {
                string query = $"update shoes set Name = @Name,status = @status,left_time = @leftTime,instruction = @instruction,deadline = @deadTime,service_price = @service_price,guarantee = @guarantee,master_id = @master ,customer_id = @customer where id = {id}";
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(query, new ShoesDTO
                    {
                        Name = shoes.Name,
                        status = shoes.status,
                        leftTime = shoes.leftTime,
                        instruction = shoes.instruction,
                        deadTime = shoes.deadTime,
                        service_price = shoes.service_price,
                        master = shoes.master,
                        customer = shoes.customer

                    });
                    return shoes;

                }
            }
            catch
            {
                return (ShoesDTO)Enumerable.Empty<ShoesDTO>();
            }
        }

        public ShoesDTO UpdateShoes(ShoesDTO shoes)
        {
            throw new NotImplementedException();
        }
    }
}
