namespace CofeeBreak3.Data
{
    public class CoffeType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegisterON { get; set; }

        public ICollection<Cofee>Cofees { get; set; }

    }
}
