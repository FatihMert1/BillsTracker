namespace Tracker.Entity.Entities
{
    public class Bills
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}