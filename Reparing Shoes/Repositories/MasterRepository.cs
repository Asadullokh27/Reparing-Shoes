using Dapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;
using System.Diagnostics.Metrics;

namespace Reparing_Shoes.Pattern
{
    public class MasterRepository : IMasterRepository
    {
        private readonly IConfiguration? _configuration;
        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        string IMasterRepository.CreateMaster(MasterDTO master)
        {

            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
           
                    string query = "insert into master(full_name,salary,working_hours,working_days) values (@fullName,@salary,@workingHours,@workingDays)";
                    var parametr = new MasterDTO
                    {
                        fullName = master.fullName,
                        salary = master.salary,
                        workingHours = master.workingHours,
                        workingDays = master.workingDays
                    };
                    
                    connection.Execute(query, parametr);

                }
                return "Successfully created!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        bool IMasterRepository.DeleteMaster(int id)
        {
            
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = $"delete from master where id = @id";

                    connection.Execute(query, new { id });

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerable<Master> IMasterRepository.GetAllMasters()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from master";

                    var result = connection.Query<Master>(query);

                    return result;
                }
            }
            catch
            {
                return Enumerable.Empty<Master>();
            }
        }

        Master IMasterRepository.GetById(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    string query = "select * from master where id = @id";

                    var result = connection.ExecuteReader(query, new { id });

                    return (Master)result;
                }
            }
            catch
            {
                return (Master)Enumerable.Empty<Master>();
            }
        }

        MasterDTO IMasterRepository.UpdateMaster(int id, MasterDTO master)
        {
            try
            {
                string query = "update master set full_name = @fullName,salary = @salary,working_hours = @workingHours,working_days = @workingDays";
                using (var connection = new NpgsqlConnection(_configuration!.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(query, new MasterDTO
                    {
                        fullName = master.fullName,
                        salary = master.salary,
                        workingHours = master.workingHours,
                        workingDays = master.workingDays
                    });
                    return master;

                }
            }
            catch
            {
                return (MasterDTO)Enumerable.Empty<Master>();
            }
        }
    }
}
