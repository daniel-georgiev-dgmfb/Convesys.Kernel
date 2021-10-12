using Platform.Kernel.Authentication.Services;
using System.Threading.Tasks;

namespace Platform.Kernel.Authentication.AuthenticatonManagers
{
	public interface IAuthenticationManager
    {
        Task<UserInfoResult> FindUserByUserName(AuthenicationContext authenicationContext);
        Task<UserInfoResult> FindUserByEmail(AuthenicationContext authenicationContext);
    }
}