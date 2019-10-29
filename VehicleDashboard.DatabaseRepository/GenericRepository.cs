using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VehicleDashboard.CrossCutting;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.DatabaseRepository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly ILoggerService _loggerService;

        public IDbContext _context { get; set; }

        public GenericRepository(IDbContext context, ILoggerService loggerService)
        {
            _context = context;
            _loggerService = loggerService;
        }

        public List<Entity> GetList<Entity>(Expression<Func<Entity, bool>> where = null, params Expression<Func<Entity, object>>[] navigationProperties) where Entity : class
        {
            try
            {
                IQueryable<Entity> dbQuery = _context?.Set<Entity>();

                if (dbQuery == null)
                {
                    throw new NullReferenceException();
                }

                // Apply where expression.
                if (where != null)
                {
                    dbQuery = dbQuery.Where(where);
                }

                // Include navigation properties on the DbSet (eager loading).
                if (navigationProperties == null || navigationProperties.Length <= 0) return dbQuery?.ToList();

                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current?.Include(navigationProperty));

                return dbQuery?.ToList();
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.ToString());

                throw;
            }
        }

    }
}
