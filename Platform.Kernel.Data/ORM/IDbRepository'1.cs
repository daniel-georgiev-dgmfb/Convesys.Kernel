using Platform.Kernel.Data.DataRepository;
using System;

namespace Platform.Kernel.Data.ORM
{
	/// <summary>
	///  Database repository
	/// </summary>
	public interface IDbRepository<T> : IDbRepository, IRepository<T, Guid>
		where T : class, IHasID<Guid>
	{
	}
}