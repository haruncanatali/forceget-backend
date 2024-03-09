using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Domain.Base;
using FORCEGET.Domain.Entities;
using FORCEGET.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Persistence
{
    public class ApplicationContext : IdentityDbContext<User, Role, long, IdentityUserClaim<long>,
            UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>,
        IApplicationContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Entities

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        
        #endregion

        #region Identity User Tables

        public DbSet<User> Users
        {
            get { return base.Users; }
            set { }
        }

        public DbSet<Role> Roles
        {
            get { return base.Roles; }
            set { }
        }

        public DbSet<UserRole> UserRoles
        {
            get { return base.UserRoles; }
            set { }
        }
        
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            if(_currentUserService!= null)
            {
				foreach (var entry in ChangeTracker.Entries<BaseEntity>())
				{
					switch (entry.State)
					{
						case EntityState.Added:
							entry.Entity.CreatedBy = _currentUserService.UserId;
							entry.Entity.CreatedAt = DateTime.Now;
							break;
					}
				}
			}
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}