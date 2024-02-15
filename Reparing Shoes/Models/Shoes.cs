namespace Reparing_Shoes.Models
{
    public class Shoes
    {
        public int Id { get; set; }
        public string ? Name { get; set; }

        public bool status { get; set; }

        public DateTime leftTime { get; set; }

        public string ? instruction { get; set; }

        public DateTime deadLine { get; set; }

        public int service_price { get; set; }

        public string ?guarantee { get; set; }

        public Master ? master { get; set; }

        public Customer ? customer { get; set; }
     }
}
