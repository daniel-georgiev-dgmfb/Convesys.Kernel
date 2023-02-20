using System.Net.Http.Headers;

namespace Platform.Kernel.Web
{
    public interface IAuthorisationHeaderBuilder
    {
        AuthenticationHeaderValue BuildAuthorisationHeader();
    }
}