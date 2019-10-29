using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VehicleDashboard.DatabaseRepositoryInterface
{
    public interface IGenericRepository
    {
        List<TEntity> GetList<TEntity>(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] navigationProperties) where TEntity : class;
    }
}
