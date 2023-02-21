using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.DBEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string NameAR { get; set; } = string.Empty;
        public string NameEN { get; set; } = string.Empty ;
        public string DescriptionAR { get; set; } = string.Empty;
        public string DescriptionEN { get; set; } = string.Empty;
        public double Price { get; set; }
        public double CostPrice { get; set; }
        public double PriceAfterDiscount { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
