using Microsoft.EntityFrameworkCore;
using TodoSubscriptionApp.Models;
namespace TodoSubscriptionApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems {get;set;}
    public DbSet<UserSubscription> UserSubscriptions {get;set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}
