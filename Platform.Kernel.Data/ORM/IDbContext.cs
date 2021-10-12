using System;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Kernel.Data.ORM
{
    /// <summary>
    /// Exposed methods to interacts with database context
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IDbContext : IDisposable
	{
        IDbCustomConfiguration CustomConfiguration { get; }
        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> Set<T>() where T : class;

		/// <summary>
		/// Saves the changes.
		/// </summary>
		/// <returns></returns>
		int SaveChanges();

        Task<int> SaveChangesAsync();

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        T Add<T>(T item) where T : class;

		/// <summary>
		/// Removes the specified item.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item">The item.</param>
		/// <returns></returns>
		bool Remove<T>(T item) where T : class;
	}
}