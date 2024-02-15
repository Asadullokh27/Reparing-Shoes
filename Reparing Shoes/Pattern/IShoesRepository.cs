using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public interface IShoesRepository
    {
        public ShoesDTO Post(ShoesDTO shoes);
        public IEnumerable<Shoes> GetAllShoes();
        

    }
}
