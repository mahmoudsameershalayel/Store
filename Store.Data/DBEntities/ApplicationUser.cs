using Microsoft.AspNetCore.Identity;
using Store.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.DBEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }
        public string? ImageName { get; set; } = "";
        public string? JopTitle { get; set; }
        public string? Description { get; set; }
        public List<ShoppingCart> _ShoppingCarts { get; set; }
    }
}
