using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Constrains
{
    public class CartProductsConstrains : IEntityTypeConfiguration<ShoppingCartProducts>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProducts> builder)
        {
            builder.HasOne(x => x._Product)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x._Product.Id);

            builder.HasOne(x => x._ShoppingCart)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.ShoppingCartId);
        }
    }
}
