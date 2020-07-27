namespace Convesys.Kernel.Caching
{
	using System;
	using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICacheProvider
	{
		event EventHandler WrittenTo;
		event EventHandler ReadFrom;

		object Get(string key);

		/// <summary>
		/// Gets the specified key.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		T Get<T>(string key);

        /// <summary>
        /// Try get a value from cache.
        /// </summary>
        /// <param name="key">item's key</param>
        /// <param name="item">item found or default</param>
        /// <returns>true if item is found, false otherwise</returns>
        bool TryGet(string key, out object item);
        bool TryGet<T>(string key, out T item);

        /// <summary>
        /// Get or add an item if it is not found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Item's key</param>
        /// <param name="factory">Factory to create the item</param>
        /// <param name="cancellationToken">Cancellation token to be abserved</param>
        /// <returns></returns>
        Task<T> GetOrAddAsync<T>(string key, Func<object, Task<T>> factory, CancellationToken cancellationToken);

        Task<T> GetOrAddAsync<T>(string key, Func<object, Task<T>> factory, ICacheEntryOptions policy, CancellationToken cancellationToken);

        /// <summary>
        /// Inserts value with specified key or updates if it already exists
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Put(string key, object value);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="policy"></param>

		void Put(string key, object value, ICacheEntryOptions policy);
		/// <summary>
		/// Deletes the value specified at key location.
		/// </summary>
		/// <param name="key">The key.</param>
		object Delete(string key);

		/// <summary>
		/// Creates an entry at the given key, throws an exception if that entry already exists.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		void Post(string key, object value);

		void Post(string key, object value, ICacheEntryOptions policy);

		/// <summary>
		/// Clears the entire cache
		/// </summary>
		void Clear();

		void Initialise();

		/// <summary>
		/// Determines whether the cache contains anything with the given key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		///   <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
		/// </returns>
		bool Contains(string key);

		IDictionary<string, T> TypeOf<T>();
	}
}
