using Reparing_Shoes.DTOModels;
using Reparing_Shoes.Models;

namespace Reparing_Shoes.Pattern
{
    public interface IShoesRepository
    {
        public int Post(ShoesDTO shoes);
        public IEnumerable<Shoes> GetAllShoes();
       
        public bool DeleteShoes(int Id);
        public ShoesDTO UpdateShoes(ShoesDTO shoes);
    }
}
