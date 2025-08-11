using Microsoft.EntityFrameworkCore;
using MoneyFlow.Entities;

namespace MoneyFlow.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Transaction> Transactions { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(userEntity => 
        {
            userEntity.HasKey(user => user.UsrerId);
            userEntity.Property(user => user.UsrerId).ValueGeneratedOnAdd();

            userEntity.HasData(
                new User { UsrerId = 1, FullName = "Jhon Smith", Email = "jhon@gmail.com", Password = "password123" }
            );
        });

        modelBuilder.Entity<Service>(serviceEntity => 
        {
            serviceEntity.HasKey(service => service.ServiceId);
            serviceEntity.Property(user => user.ServiceId).ValueGeneratedOnAdd();

            serviceEntity.HasOne(entity => entity.User).WithMany(user => user.Services).HasForeignKey(service => service.UserId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Transaction>(transactionEntity =>
        {
            transactionEntity.HasKey(transaction => transaction.TransactionId);
            transactionEntity.Property(transaction => transaction.TransactionId).ValueGeneratedOnAdd();

            transactionEntity.HasOne(entity => entity.Service).WithMany().HasForeignKey(service => service.ServiceId).OnDelete(DeleteBehavior.Restrict);
            transactionEntity.HasOne(entity => entity.User).WithMany(user => user.Transactions).HasForeignKey(user => user.UserId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}
