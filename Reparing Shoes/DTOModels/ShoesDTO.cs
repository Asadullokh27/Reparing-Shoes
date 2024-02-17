using Reparing_Shoes.Models;

namespace Reparing_Shoes.DTOModels
{
    public class ShoesDTO
    {
        public string? Name { get; set; }

        public bool status { get; set; }

        public DateTime leftTime { get; set; }

        public string? instruction { get; set; }

        public DateTime deadTime { get; set; }

        public int service_price { get; set; }

        public string? guarantee { get; set; }

        public Master? master { get; set; }
        public object Master { get; internal set; }
        public Customer? customer { get; set; }
    }
}
