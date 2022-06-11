using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspSneakers.DataAccess
{
    public class SneakersDbContext : DbContext
    {
        public SneakersDbContext(DbContextOptions options = null) : base(options)
        {

        }
        public IApplicationUser User { get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new { x.UserId, x.UseCaseId });
            modelBuilder.Entity<PriceProduct>().Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Order>().Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
           
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=asp;Integrated Security=True").UseLazyLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //}


        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<PriceProduct> PriceProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UserUseCaseLog> UserUseCaseLogs { get; set; }
    }
}
