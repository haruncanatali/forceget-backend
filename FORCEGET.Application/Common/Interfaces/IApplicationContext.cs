using FORCEGET.Domain.Entities;
using FORCEGET.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.Common.Interfaces;

public interface IApplicationContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Offer> Offers { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}