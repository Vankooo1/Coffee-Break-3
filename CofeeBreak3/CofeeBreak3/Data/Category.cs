namespace CofeeBreak3.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime RegisterON { get; set; }

        public ICollection<Cofee> Cofees { get; set; }



         
    }
}
