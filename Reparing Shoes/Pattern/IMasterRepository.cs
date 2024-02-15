using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public interface IMasterRepository
    {
        public string CreateMaster(MasterDTO master);
        public IEnumerable<Master> GetAllMasters();
        public Master GetById(int id);
        public bool DeleteMaster(int id);
        public MasterDTO UpdateMaster(int id, MasterDTO master);
    }
}
