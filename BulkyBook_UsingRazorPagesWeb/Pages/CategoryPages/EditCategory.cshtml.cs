using BulkyBook_UsingRazorPagesWeb.Data;
using BulkyBook_UsingRazorPagesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook_UsingRazorPagesWeb.Pages.CategoryPages
{
    public class EditCategoryModel : PageModel
    {
        private readonly ApplicationDbContext db;
        [BindProperty]
        public Category category { get; set; }
        public EditCategoryModel(ApplicationDbContext db)
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
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "Please ensure that name cannot be same as display order");
                ModelState.AddModelError("category.DisplayOrder", "Please ensure that display order cannot be same as name");
            }
            if (ModelState.IsValid)
            {
                category.CreatedDateTime = DateTime.Now;
                db.Categories.Update(category);
                await db.SaveChangesAsync();
                TempData["success"] = "Category updated.";
                return RedirectToPage("/CategoryPages/Index");
            }
            return Page();
        }
    }
}
