using System.Threading.Tasks;
using Twilight.Kernel.Authentication.Services;

namespace Twilight.Kernel.Authentication.AuthenticatonManagers
{
    public interface IAuthenticationManager
    {
        Task<UserInfoResult> FindUserByUserName(AuthenicationContext authenicationContext);
        Task<UserInfoResult> FindUserByEmail(AuthenicationContext authenicationContext);
    }
}