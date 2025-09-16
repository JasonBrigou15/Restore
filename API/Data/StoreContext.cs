using API.Entities;
using API.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }
    public required DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole { Id = "ce3b7062-e8ca-45b0-b0b4-5c475d47f2c5", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id = "ac92a1fa-e7b2-484f-9e28-7dcbaae07191", Name = "Admin", NormalizedName = "ADMIN" }
            );
    }
}

