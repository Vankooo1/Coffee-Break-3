using Microsoft.AspNetCore.Identity;

namespace CofeeBreak3.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
