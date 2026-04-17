using Counselor.Data;
using Counselor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Counselor.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        // READ - Get all blogs
        [HttpGet]
        public async Task<IActionResult> Blogs()
        {
            var blogs = await _db.Blogs.OrderByDescending(b => b.CreatedAt).ToListAsync();
            return View(blogs);
        }

        // READ - Get single blog details
        [HttpGet]
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // CREATE - Show create form
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }

        // CREATE - Save new blog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(Blog model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatedAt = DateTime.UtcNow;
            model.PublishedDate = DateTime.UtcNow;
            _db.Blogs.Add(model);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = "Blog created successfully.";
            return RedirectToAction(nameof(Blogs));
        }

        // UPDATE - Show edit form
        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // UPDATE - Save changes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(int id, Blog model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Title = model.Title;
            blog.Content = model.Content;
            blog.Summary = model.Summary;
            blog.Author = model.Author;
            blog.PublishedDate = model.PublishedDate;
            blog.IsPublished = model.IsPublished;
            blog.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = "Blog updated successfully.";
            return RedirectToAction(nameof(Blogs));
        }

        // DELETE - Confirm deletion
        [HttpGet]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // DELETE - Execute deletion
        [HttpPost, ActionName("DeleteBlog")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBlogConfirmed(int id)
        {
            var blog = await _db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _db.Blogs.Remove(blog);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = "Blog deleted successfully.";
            return RedirectToAction(nameof(Blogs));
        }
    }
}
