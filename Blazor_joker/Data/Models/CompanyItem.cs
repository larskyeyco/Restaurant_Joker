using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_joker.Data.Models
{
    public class CompanyItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Item Description")]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        [Display(Name = "Item Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater then 1$.")]
        public double Price { get; set; }
        [Display(Name = "Company Type")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}