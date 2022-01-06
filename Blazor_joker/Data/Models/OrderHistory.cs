using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_joker.Data.Models
{
    public class OrderHistory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual OrderInformation OrderInformation { get; set; }
    }
}