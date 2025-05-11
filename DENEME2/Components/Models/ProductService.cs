using YourProject.Models;
using YourProject.Data;
using Microsoft.EntityFrameworkCore;

public class ProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAvailableProductsAsync()
    {
        return await _context.Products
            .Where(p => p.IsAvailable && !p.IsDeleted)
            .ToListAsync();
    }
}
