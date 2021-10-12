using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phase_three_final_project.Models;

namespace Phase_three_final_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext context;
        public ProductController()
        {
            context = new ApplicationDBContext();
        }
        public IActionResult Index()
        {
            var products = context.Product.ToList();
            return View(products);
        }

        public async Task<IActionResult> DetailsAsync(int? id)
        {
            var products = context.Product.Find(id);

            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Product
                .Include(p => p.Description)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
