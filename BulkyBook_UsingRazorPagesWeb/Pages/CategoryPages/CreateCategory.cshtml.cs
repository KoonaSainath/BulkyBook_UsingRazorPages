using BulkyBook_UsingRazorPagesWeb.Data;
using BulkyBook_UsingRazorPagesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook_UsingRazorPagesWeb.Pages.CategoryPages
{
    public class CreateCategoryModel : PageModel
    {
        [BindProperty]
        public Category category { get; set; }
        private readonly ApplicationDbContext db;

        public CreateCategoryModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> OnPost()
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "Please ensure that name is not same as display order");
                ModelState.AddModelError("category.DisplayOrder", "Please ensure that display order is not same as name");
            }
            if (ModelState.IsValid)
            {
                await db.Categories.AddAsync(category);
                await db.SaveChangesAsync();
                TempData["success"] = "Category created.";
                return RedirectToPage("/CategoryPages/Index");
            }
            return Page();
        }
    }
}
