using System;
using System.Collections.Generic;
using System.Text;

namespace WebShoppie.Api.Contracts.Products
{
    public class ProductResponseContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int? AgeRating { get; set; }
        public int StockCount { get; set; }
    }
}
