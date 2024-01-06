using System.ComponentModel;

namespace test.Models
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("หมวดหมู่")]
        [Required(ErrorMessage = "โปรดป้อนข้อมูล")]
        public string Name { get; set; }
    }
}
