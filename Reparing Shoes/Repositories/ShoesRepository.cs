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
                        splitOn: "Id"
                    );

                    return result;
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Shoes>();
            }
        }

        public int Post(ShoesDTO shoes)
        {
            throw new NotImplementedException();
        }



        /* public int Post(ShoesDTO shoes)
         {
             try
             {
                 using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                 {
                     connection.Open();

                     string insertQuery = @"
                 INSERT INTO shoes (Name, status, left_time, instruction, deadLine, service_price, guarantee, master_id, customer_id)
                 VALUES (@Name, @Status, @LeftTime, @Instruction, @DeadTime, @ServicePrice, @Guarantee, @MasterId, @CustomerId);";

                     int rowsAffected = connection.Execute(insertQuery, new
                     {
                         shoes.Name,
                         shoes.status,
                         shoes.leftTime,
                         shoes.instruction,
                         shoes.deadTime,
                         shoes.service_price,
                         shoes.guarantee,
                         MasterId = shoes.Master?.Id, 
                         CustomerId = shoes.Customer?.Id 
                     });

                     return rowsAffected;
                 }
             }
             catch (Exception ex)
             {

                 return 0; 
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
                           master = master,
                           customer_id = shoes.customer_id

                       });
                       return shoes;

                   }
               }
               catch
               {
                   return (ShoesDTO)Enumerable.Empty<ShoesDTO>();
               }
          }*/

        public ShoesDTO UpdateShoes(ShoesDTO shoes)
        {
            throw new NotImplementedException();
        }
    }
}
