using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Persistence
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{   //Keyless:
        //    //modelBuilder.Entity<Class>().HasNoKey().ToView(null);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(Relationship.Create(modelBuilder));
        }

        //Create tables.
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<CartDetailProductAuxiliaryNn> CartDetailProductAuxiliaryNn { get; set; }
    }
}
