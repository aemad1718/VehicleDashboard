using Microsoft.EntityFrameworkCore;
using System;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
