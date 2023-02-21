using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIDto.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        public string NameAR { get; set; } 
        [Required]
        public string NameEN { get; set; }
        public string Color { get; set; }

    }
}
