using System.ComponentModel;

namespace test.Models
{
    public class Food
    {
        public Food()
        {
            ExtendFood = new();
        }
        public int Id {  get; set; }

        [DisplayName("ชื่ออาหาร")]
        [Required(ErrorMessage = "โปรดป้อนข้อมูล")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("รูปปกอาหาร")]
        [Required(ErrorMessage = "โปรดป้อนข้อมูล")]
        public string Image { get; set; }
        public Extend ExtendFood { get; set; }
        // Category
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

    }
}
