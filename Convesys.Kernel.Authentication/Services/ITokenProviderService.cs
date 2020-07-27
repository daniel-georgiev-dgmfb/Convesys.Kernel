using System.Threading.Tasks;
using Convesys.Kernel.Data;

namespace Convesys.Kernel.Authentication.Services
{
    public interface ITokenProviderService<TUser, TKey> where TUser : class, IHasID
    {
        Task<string> GenerateUserToken(string purpose, TUser user);
    }
}