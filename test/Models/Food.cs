namespace test.Models
{
    public class Food
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        // Category
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
