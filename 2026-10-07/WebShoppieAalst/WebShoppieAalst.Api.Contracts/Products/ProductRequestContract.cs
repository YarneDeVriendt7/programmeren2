using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebShoppie.Api.Contracts.Products
{
    public class ProductRequestContract
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int? AgeRating { get; set; }
        [Required]
        public int StockCount { get; set; }
    }
}
