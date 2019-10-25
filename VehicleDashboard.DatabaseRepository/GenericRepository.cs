using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VehicleDashboard.DatabaseRepositoryInterface;

namespace VehicleDashboard.DatabaseRepository
{
    public class GenericRepository : IGenericRepository
    {
        public IDbContext _context { get; set; }

        public GenericRepository(IDbContext context)
        {
            _context = context;
        }

        public List<Entity> GetList<Entity>(Expression<Func<Entity, bool>> where = null, params Expression<Func<Entity, object>>[] navigationProperties) where Entity : class
        {
            try
            {
                IQueryable<Entity> dbQuery = _context.Set<Entity>();

                // Apply where expression.
                if (where != null)
                {
                    dbQuery = dbQuery.Where(where);
                }

                // Include navigation properties on the DbSet (eager loading).
                if (navigationProperties != null)
                {
                    foreach (Expression<Func<Entity, object>> navigationProperty in navigationProperties)
                    {
                        dbQuery = dbQuery.Include(navigationProperty);
                    }
                }

                return dbQuery.ToList();
            }
            catch (Exception ex)
            {
                throw;
                //ToDo:: log exceptions.
            }
        }

    }
}
