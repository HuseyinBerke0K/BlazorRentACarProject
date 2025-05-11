using AracKiralama.Models;
using YourProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace AracKiralama.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }
        public string Address { get; set; }
    }
    public class AppUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid RentOfficeId { get; set; }  
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }

        public string CreateAppUserCommand { get; set; }
    }


}

public class AuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser?> LoginAsync(string email, string password)
    {
        return await _context.AppUsers
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}

public class LoginAppUserCommand
{
    public string Email { get; set; }
    public string Password { get; set; }
}

