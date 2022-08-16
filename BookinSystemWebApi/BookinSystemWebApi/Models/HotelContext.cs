namespace BookinSystemWebApi.Models
{
    public class HotelContext:IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration configuration;
        public virtual DbSet<Branch>? Branch { get; set; }
        public virtual DbSet<Room>? Room { get; set; }
        public virtual DbSet<RoomType>? RoomType { get; set; }
        public virtual DbSet<RoomGallary>? RoomGallary  { get; set; }
        public virtual DbSet<Reservation>? Reservation { get; set; }
        public virtual DbSet<Customer>? Customer { get; set; }
        public virtual DbSet<Banner>? Banner { get; set; }

        public HotelContext()
        {

        }
        public HotelContext(DbContextOptions dbContextOptions,IConfiguration configuration) : base(dbContextOptions)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CS"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomGallary>().HasKey(c => new { c.RoomId, c.ImageSrc });
            base.OnModelCreating(modelBuilder);
        }
    }
}
