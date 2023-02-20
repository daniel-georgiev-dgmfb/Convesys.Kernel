using System.Net.Http.Headers;

namespace Twilight.Kernel.Web
{
    public interface IAuthorisationHeaderBuilder
    {
        AuthenticationHeaderValue BuildAuthorisationHeader();
    }
}