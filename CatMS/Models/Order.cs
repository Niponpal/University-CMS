namespace CatMS.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Buyer contact details (snapshot at order time)
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Foreign keys
        public int CatId { get; set; }
        public int BuyerId { get; set; }

        // Navigation properties
        public Buyer Buyer { get; set; }
        public Cat Cat { get; set; }
    }
}
