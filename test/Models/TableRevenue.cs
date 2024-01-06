namespace test.Models
{
    public class TableRevenue
    {
        public string UserId { get; set; }
        public IdentityUser? User { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set;}
    }
}
