using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface IGenericRepository
    {
        List<Entity> GetList<Entity>(Expression<Func<Entity, bool>> where = null, params Expression<Func<Entity, object>>[] navigationProperties) where Entity : class;
    }
}
