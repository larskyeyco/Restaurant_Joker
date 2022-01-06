using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_joker.Data.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        [Key]
        public int Id { get; set; }
        public int CompanyItemId { get; set; }
        [ForeignKey("CompanyItemId")]
        public virtual CompanyItem CompanyItem { get; set; }
        public string IndetityUserId { get; set; }
        [ForeignKey("IndetityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }
        [Range(1, 1000, ErrorMessage = "Please select a count between 1 and 100")]
        public int Count { get; set; }
    }
}