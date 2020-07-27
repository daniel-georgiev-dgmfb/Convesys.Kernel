using System;
using System.Linq;

namespace Convesys.Kernel.Projections
{
    public interface IProjector<TModel> : IDisposable where TModel : class
    {
        IQueryable<TModel> GetAll();
    }
}