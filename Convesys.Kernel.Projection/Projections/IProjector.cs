using Twilight.Kernel.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Twilight.Kernel.Projections
{
    public interface IProjector<TEntity> : IDisposable where TEntity : BaseModel
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Guid id);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
    }
}