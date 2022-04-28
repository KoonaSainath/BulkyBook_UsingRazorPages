using System.ComponentModel.DataAnnotations;

namespace BulkyBook_UsingRazorPagesWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        [Display(Name = "Category name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter display order")]
        [Range(1, maximum: 100, ErrorMessage = "Display order can only be from 1 to 100")]
        [Display(Name = "Display order")]
        public int? DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
