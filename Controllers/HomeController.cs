using Counselor.Data;
using Counselor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Counselor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Counselor()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Pricing()
        {
            return View();
        }

        public async Task<IActionResult> Blog()
        {
            var blogs = await _db.Blogs
                .Where(b => b.IsPublished)
                .OrderByDescending(b => b.PublishedDate)
                .ToListAsync();
            return View(blogs);
        }

        public async Task<IActionResult> BlogSingle(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null || !blog.IsPublished)
            {
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
