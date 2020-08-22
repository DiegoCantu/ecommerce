using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Persistence
{
    public class ContextDb: DbContext
    {
        //Keyless
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Class>().HasNoKey().ToView(null);
        }

        public ContextDb(DbContextOptions<ContextDb> options): base(options) { }
        //Create tables.
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartDetail> CartDetail { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<ecommerce.Models.Address> Address { get; set; }
        public DbSet<ecommerce.Models.Card> Card { get; set; }
    }
}
