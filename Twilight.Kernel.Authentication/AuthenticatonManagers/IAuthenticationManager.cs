using System.Threading.Tasks;
using Convesys.Kernel.Authentication.Services;

namespace Convesys.Kernel.Authentication.AuthenticatonManagers
{
    public interface IAuthenticationManager
    {
        Task<UserInfoResult> FindUserByUserName(AuthenicationContext authenicationContext);
        Task<UserInfoResult> FindUserByEmail(AuthenicationContext authenicationContext);
    }
}