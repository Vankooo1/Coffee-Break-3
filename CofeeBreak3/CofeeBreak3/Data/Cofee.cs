using System.ComponentModel.DataAnnotations.Schema;

namespace CofeeBreak3.Data
{
    public class Cofee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName="decimal(10, 2)")]
        public decimal Price { get; set; }
        public DateTime RegisterON { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public int CoffeTypeId { get; set; }
        public CoffeType CoffeTypes { get; set; }

        public ICollection<Order>Orders { get; set; }

    }
}
