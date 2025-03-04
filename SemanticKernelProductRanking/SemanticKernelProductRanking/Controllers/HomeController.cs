using Microsoft.AspNetCore.Mvc;
using SemanticKernelProductRanking.Services;
using SemanticKernelProductRanking.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SemanticKernelProductRanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly SemanticKernelService _semanticKernelService;

        public HomeController(SemanticKernelService semanticKernelService)
        {
            _semanticKernelService = semanticKernelService;
        }

        public async Task<IActionResult> Index(string keyword)
        {
            List<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = await _semanticKernelService.GetRankedProductsAsync(keyword);
            }

            return View(products);
        }
    }
}
