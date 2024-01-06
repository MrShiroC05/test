using System.ComponentModel;

namespace test.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int IdFood { get; set; }
        public string IdUser { get; set; }
        [DisplayName("ชื่ออาหาร")]
        public string Name { get; set; }
        public Extend ExtendCart { get; set; }
    }
}
