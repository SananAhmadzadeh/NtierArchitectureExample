namespace NtierArchitecture.DataAccess.EFCore
{
    public class ExampleDbContext : IdentityDbContext<AppUser<Guid>>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
