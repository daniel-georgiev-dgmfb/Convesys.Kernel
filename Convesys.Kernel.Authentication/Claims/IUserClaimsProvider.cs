using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Convesys.Kernel.Authentication.Claims
{
    public interface IUserClaimsProvider<TUser>
    {
        Task<IDictionary<string, ClaimsIdentity>> GenerateUserIdentitiesAsync(TUser user, IEnumerable<string> authenticationTypes);
    }
}
