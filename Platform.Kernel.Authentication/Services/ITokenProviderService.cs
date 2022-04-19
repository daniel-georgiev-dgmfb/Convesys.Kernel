using Platform.Kernel.Data;
using System.Threading.Tasks;

namespace Platform.Kernel.Authentication.Services
{
	public interface ITokenProviderService<TUser, TKey> where TUser : class, IHasID
    {
        Task<string> GenerateUserToken(string purpose, TUser user);
    }
}