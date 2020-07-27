using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Convesys.Kernel.Data.Tenancy;

namespace Convesys.Kernel.Data.ORM
{
    public interface IDbCustomConfiguration
    {
        ICollection<ISeeder> Seeders { get; }
        Func<IEnumerable<Type>> ModelsFactory { get; }
        Func<IEnumerable<IDbMapper>> ModelMappers { get; }
        string Schema { get; }
        string ModelKey { get; }
        Task ConfigureOptions<T>(T options);
    }
}