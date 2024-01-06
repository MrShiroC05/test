using System.ComponentModel;

namespace test.Models
{
    [Owned]
    public class Extend
    {
        [DisplayName("จำนวน")]
        [Required(ErrorMessage = "โปรดป้อนข้อมูล")]
        [Range(1, 999, ErrorMessage = "โปรดให้ค่าจำนวนอยู่ระหว่าง {1} ถึง {2}")]
        public int Qut {  get; set; }

        [DisplayName("ราคา")]
        [Required(ErrorMessage = "โปรดป้อนข้อมูล")]
        [Range(1, 999, ErrorMessage = "โปรดให้ค่าจำนวนอยู่ระหว่าง {1} ถึง {2}")]
        public double Price { get; set; }
    }
}
