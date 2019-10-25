using Microsoft.EntityFrameworkCore;
using System;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface IDbContext : IDisposable
    {
        DbSet<Entity> Set<Entity>() where Entity : class;

        int SaveChanges();
    }
}
