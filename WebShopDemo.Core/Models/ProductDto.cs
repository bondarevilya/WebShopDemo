using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShopDemo.Core.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Prodict indentifier
        /// </summary>
        
        public Guid ID { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Product price
        /// </summary>
        
        [Range(typeof(decimal), "0.1", "1000", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity in stock
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
