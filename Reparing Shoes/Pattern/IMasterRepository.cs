using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public interface IMasterRepository
    {
        public string CreateMaster(MasterDTO master);
        public IEnumerable<MasterDTO> GetAllMasters();
        public Master GetById(int id);
        public bool DeleteCustomer(int id);
        public Master UpdateCustomer(int id, MasterDTO master);
    }
}
