using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIDto.Products
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameAR { get; set; }
        [Required]
        public string NameEN { get; set; }
        [Required]
        public string DescriptionAR { get; set; }
        [Required]
        public string DescriptionEN { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double CostPrice { get; set; }
        public double? PriceAfterDiscount { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
