using System.Threading.Tasks;
using Twilight.Kernel.Data;

namespace Twilight.Kernel.Authentication.Services
{
    public interface ITokenProviderService<TUser, TKey> where TUser : class, IHasID
    {
        Task<string> GenerateUserToken(string purpose, TUser user);
    }
}