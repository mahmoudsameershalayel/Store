using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.DBEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string NameAR { get; set; } = string.Empty;
        public string NameEN { get; set; } = string.Empty ;
        public string? Color { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }    
    }
}
