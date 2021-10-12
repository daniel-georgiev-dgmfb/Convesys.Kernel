using System.Security.Claims;
using System.Threading.Tasks;

namespace Platform.Kernel.Authentication.Claims
{
    public interface IClaimsIdentityMapper<TResult>
    {
        Task<TResult> MapIClaimsIdentity(ClaimsIdentity identity);
    }
}