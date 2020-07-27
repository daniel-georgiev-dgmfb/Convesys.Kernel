using System.Net.Http.Headers;

namespace Glasswall.Kernel.Web
{
    public interface IAuthorisationHeaderBuilder
    {
        AuthenticationHeaderValue BuildAuthorisationHeader();
    }
}