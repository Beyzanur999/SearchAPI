using Microsoft.EntityFrameworkCore;
using SemanticKernelProductRanking.Data;
using SemanticKernelProductRanking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemanticKernelProductRanking.Services
{
    public class SemanticKernelService
    {
        private readonly ApplicationDbContext _context;

        public SemanticKernelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetRankedProductsAsync(string keyword)
        {
            // Veritabanından tüm ürünleri çek
            var products = await _context.Products.ToListAsync();

            // Anahtar kelimeye göre filtreleme yap (basit bir eşleşme)
            return products
                .Where(p => p.Name.Contains(keyword) || p.Category.Contains(keyword) || p.Description.Contains(keyword))
                .OrderByDescending(p => p.Name.StartsWith(keyword)) // En alakalı olanları öne al
                .ToList();
        }
    }
}
