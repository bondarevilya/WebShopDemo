using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShopDemo.Core.Data.Models
{
    [Comment("Profuct to sell")]
    public class Product
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Comment("Product name")]
        public string Name { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        [Comment("Product price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Products in stock")]
        public int Quantity { get; set; }
    }
}
