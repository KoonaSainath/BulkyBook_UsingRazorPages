using BulkyBook_UsingRazorPagesWeb.Data;
using BulkyBook_UsingRazorPagesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook_UsingRazorPagesWeb.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        public List<Category> categories;
        private readonly ApplicationDbContext db;

        public IndexModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void OnGet()
        {
            categories = db.Categories.ToList();
        }
    }
}
