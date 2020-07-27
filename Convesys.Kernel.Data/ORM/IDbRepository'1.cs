using System;
using Convesys.Kernel.Data.DataRepository;

namespace Convesys.Kernel.Data.ORM
{
    /// <summary>
    ///  Database repository
    /// </summary>
    public interface IDbRepository<T> : IDbRepository, IRepository<T, Guid>
		where T : class, IHasID<Guid>
	{
	}
}