using Dinner.Domain.Common.Models;
using Dinner.Domain.MenuAggregate;
using Dinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Dinner.Infrastructure.Persistence;

public class DinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public DinnerDbContext(DbContextOptions<DinnerDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Bills { get; set; } = null!;

    public DbSet<Menu> Dinners { get; set; } = null!;

    public DbSet<Menu> Guests { get; set; } = null!;

    public DbSet<Menu> Hosts { get; set; } = null!;

    public DbSet<Menu> Menus { get; set; } = null!;

    public DbSet<Menu> MenuReviews { get; set; } = null!;

    public DbSet<Menu> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
