using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Persistence
{
    public class Relationship
    {
        public static ModelBuilder Create(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            //Composite Key:
            modelBuilder.Entity<Card>()
            .HasKey(k => new { k.Email, k.NumberCard });

            // [ Entity Relationship:

            // { User email foreign keys 1:N
            modelBuilder.Entity<Card>()
            .HasOne<User>(g => g.User)
            .WithMany(s => s.Card)
            .HasForeignKey(s => s.Email);

            modelBuilder.Entity<Address>()
            .HasOne<User>(g => g.User)
            .WithMany(s => s.Address)
            .HasForeignKey(s => s.Email);

            modelBuilder.Entity<Cart>()
            .HasOne<User>(g => g.User)
            .WithMany(s => s.Cart)
            .HasForeignKey(s => s.Email);

            modelBuilder.Entity<Purchase>()
            .HasOne<User>(g => g.User)
            .WithMany(s => s.Purchase)
            .HasForeignKey(s => s.Email);
            // }

            // { Cart IdCart foreign key 1:N
            modelBuilder.Entity<CartDetail>()
            .HasOne<Cart>(g => g.Cart)
            .WithMany(s => s.CartDetail)
            .HasForeignKey(s => s.IdCart);
            // }

            // { CartDetailProduct Aux foreign key 1:N (N:N)
            modelBuilder.Entity<CartDetailProductAuxiliaryNn>()
            .HasOne<CartDetail>(g => g.CartDetail)
            .WithMany(s => s.CartDetailProductAuxiliaryNn)
            .HasForeignKey(s => s.IdCartDetail);

            modelBuilder.Entity<CartDetailProductAuxiliaryNn>()
            .HasOne<Product>(g => g.Product)
            .WithMany(s => s.CartDetailProductAuxiliaryNn)
            .HasForeignKey(s => s.IdProduct);
            // }

            // { Product IdProduct foreign key 1:N
            modelBuilder.Entity<Comment>()
           .HasOne<Product>(g => g.Product)
           .WithMany(s => s.Comment)
           .HasForeignKey(s => s.IdProduct);
            // }

            // { Category IdCategory foreign key 1:N
            modelBuilder.Entity<Product>()
           .HasOne<Category>(g => g.Category)
           .WithMany(s => s.Product)
           .HasForeignKey(s => s.IdCategory);
            // }

            // { Purchase IdCart 1:1
            modelBuilder.Entity<Cart>()
           .HasOne<Purchase>(g => g.Purchase)
           .WithOne(s => s.Cart)
           .HasForeignKey<Purchase>(s => s.IdCart);
            // }

            //}
            return modelBuilder;
        }
    }
}
