using BulkyBook_UsingRazorPagesWeb.Data;
using BulkyBook_UsingRazorPagesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook_UsingRazorPagesWeb.Pages.CategoryPages
{
    public class DeleteCategoryModel : PageModel
    {
        [BindProperty]
        public Category category { get; set; }
        private readonly ApplicationDbContext db;
        public DeleteCategoryModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            category = await db.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            db.Remove(category);
            await db.SaveChangesAsync();
            return RedirectToPage("/CategoryPages/Index");
        }
    }
}
