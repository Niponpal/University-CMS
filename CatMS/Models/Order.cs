using CatMS.Auth_IdentityModel;

namespace CatMS.Models
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Buyer contact details (snapshot at order time)
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long BuyerId { get; set; }
        public long CatId { get; set; }
        public IdentityModel.User Buyer { get; set; }
        public Cat Cat { get; set; }
    }
}
