using CatMS.Auth_IdentityModel;
using NuGet.Protocol.Plugins;
namespace CatMS.Models;
public class Cat
{
    public long Id { get; set; }             // Primary Key
    public string Name { get; set; }        // Cat Name
    public string Breed { get; set; }       // Breed type
    public int Age { get; set; }            // Age
    public string Gender { get; set; }      // Male / Female
    public decimal Price { get; set; }      // Price
    public string Color { get; set; }       // Color
    public string Description { get; set; } // Details
    public string ImageUrl { get; set; }    // Picture
    public DateTime PostedDate { get; set; }  // Date when posted
    public long SellerId { get; set; }         // Foreign Key to User
    public bool IsPubliced { get; set; }      // Is the cat listing public
    public IdentityModel.User Seller { get; set; } // Navigation property to User
    public ICollection<Order> Order { get; set; } // Navigation property to Orders
}

