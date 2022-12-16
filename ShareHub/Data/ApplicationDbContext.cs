using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShareHub.Data
{
    public class ShareHubDbContext : IdentityDbContext
    {

        // TODO: These need to be refactored.
        private IdentityUser AgentUser { get; set; }

        private IdentityUser GuestUser { get; set; }

        private Agent Agent { get; set; }

        private Category ScienceCategory { get; set; }

        private Category ReligionCategory { get; set; }

        private Category GeneralCategory { get; set; }

        // TODO: These are leftover from workshop, need to be reworked.
        private Book FirstBooks { get; set; }

        private Book SecondBooks { get; set; }

        private Book ThirdBooks { get; set; }

        // DbSets for tables
        public DbSet<Book> Books { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Agent> Agents { get; init; }

        public ShareHubDbContext(DbContextOptions<ShareHubDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehaviour.Restrict);


            modelBuilder
                .Entity<Book>()
                .HasOne(b => b.Agent)
                .WithMany()
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehaviour.Restrict);

            base.OnModelCreating(modelBuilder);

            // Use this to seed initial data.
            //
            // SeedUsers();
            // modelBuilder.Entity<IdentityUser>()
            //              .HasData(this.AgentUser, this.GuestUser);
            //
            // SeedAgent();
            // modelBuilder.Entity<Agent>()
            //              .HasData(this.Agent);
            //
            // SeedCategories();
            // modelBuilder.Entity<Category>()
            //              .HasData(this.Categories);
            //
            // SeedUsers();
            // modelBuilder.Entity<IdentityUser>()
            //              .HasData(this.AgentUser, this.GuestUser);

        }

        // TODO: Update with valid seed data.
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            this.AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            this.AgentUser.PasswordHash = hasher.HashPassword(this.AgentUser, "agent123");

            this.GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            this.GuestUser.PasswordHash = hasher.HashPassword(this.AgentUser, "guest123");
        }

        // TODO: Update with valid seed data.
        private void SeedAgent()
        {
            this.Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = this.AgentUser.Id
            };
        }

        // TODO: Update with valid seed data.
        private void SeedCategories()
        {
            this.CottageCategory = new Category()
            {
                Id = 1,
                Name = "Cottage"
            };

            this.SingleCategory = new Category()
            {
                Id = 2,
                Name = "Single-Family"
            };

            this.DuplexCategory = new Category()
            {
                Id = 3,
                Name = "Duplex"
            };
        }

        // TODO: Update with valid seed data.
        private void SeedHouses()
        {
            this.FirstHouse = new Book()
            {
                Id = 1,
                Title = "Big Book Marina",
                Location = "North London, UK (near the border)",
                Description = "A big house for your whole family. Don't miss to buy a house with three bedrooms.",
                ImageUrl = "https://www.luxury-architecture.net/wp-content/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg",
                PricePerMonth = 2100.00M,
                CategoryId = this.DuplexCategory.Id,
                AgentId = this.Agent.Id,
                RenterId = this.GuestUser.Id
            };

            this.SecondHouse = new Book()
            {
                Id = 2,
                Title = "Family Book Comfort",
                Location = "Near the Sea Garden in Burgas, Bulgaria",
                Description = "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.",
                ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1",
                PricePerMonth = 1200.00M,
                CategoryId = this.SingleCategory.Id,
                AgentId = this.Agent.Id
            };

            this.ThirdHouse = new Book()
            {
                Id = 3,
                Title = "Grand Book",
                Location = "Boyana Neighbourhood, Sofia, Bulgaria",
                Description = "This luxurious house is everything you will need. It is just excellent.",
                ImageUrl = "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg",
                PricePerMonth = 2000.00M,
                CategoryId = this.SingleCategory.Id,
                AgentId = this.Agent.Id
            };
        }
    }
}