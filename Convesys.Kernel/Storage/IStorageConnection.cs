using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Convesys.Kernel.Storage
{
    public interface IStorageConnection<TObject, TIdentifier> where TObject : class
    {
        Task<TObject> GetObjectAsync(TIdentifier Id);
        Task RemoveObjectAsync(TIdentifier Id);
    }
}
