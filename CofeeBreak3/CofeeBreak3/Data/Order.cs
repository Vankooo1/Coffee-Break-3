using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace CofeeBreak3.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSum{ get; set; }
        public DateTime RegisterOn { get; set; }

        public int CofeeId { get; set; }
        public Cofee Cofees { get; set; }

        public string UserId { get; set; }
        public User Users { get; set; }
        
    }
}
