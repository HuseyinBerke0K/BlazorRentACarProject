using AracKiralama.Models;
using YourProject.Data;
using Microsoft.EntityFrameworkCore;

namespace YourProject.Models
{
    public class Product
    {
        public int  RentId { get; set; } // Primary key
        public string RentOfficeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; } 
    }
}