using System.Net.Http.Headers;

namespace Convesys.Kernel.Web
{
    public interface IAuthorisationHeaderBuilder
    {
        AuthenticationHeaderValue BuildAuthorisationHeader();
    }
}