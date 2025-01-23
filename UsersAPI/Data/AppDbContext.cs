using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .ToTable("users") 
            .Property(u => u.Id)
            .HasColumnName("id") 
            .IsRequired() 
            .ValueGeneratedOnAdd(); 

        modelBuilder.Entity<UserModel>()
            .Property(u => u.Name)
            .HasColumnName("name")  
            .IsRequired();

        modelBuilder.Entity<UserModel>()
            .Property(u => u.Email)
            .HasColumnName("email")
            .IsRequired();

        modelBuilder.Entity<UserModel>()
            .Property(u => u.CreatedAt)
            .HasColumnName("createdAt")  
            .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'America/Sao_Paulo'");

        modelBuilder.Entity<UserModel>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}