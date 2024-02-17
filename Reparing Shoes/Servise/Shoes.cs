using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Reparing_Shoes.Models;
using Reparing_Shoes.Pattern;
using System.Runtime.CompilerServices;

namespace Reparing_Shoes.Servise
{
    public class Shoes : IShoescs
    {
        private readonly IShoesRepository _shoescs;

        public Shoes(IShoesRepository shoescs)
        {
            _shoescs = shoescs;
        }

        public Shoes GetByID(int id) => _shoescs.GetAllShoes().FirstOrDefault(x => x.Id == id);
    }

}
