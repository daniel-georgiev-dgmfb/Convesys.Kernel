using System;
using Twilight.Kernel.Data.DataRepository;

namespace Twilight.Kernel.Data.ORM
{
    /// <summary>
    ///  Database repository
    /// </summary>
    public interface IDbRepository<T> : IDbRepository, IRepository<T, Guid>
		where T : class, IHasID<Guid>
	{
	}
}