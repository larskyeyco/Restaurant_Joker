using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_joker.Data.Models
{
    public class OrderInformation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string AdditionalInstructions { get; set; }
        public string IndetityUserId { get; set; }
        [ForeignKey("IndetityUserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}