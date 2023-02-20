using System.Net.Http;
using System.Net.Http.Headers;

namespace Twilight.Kernel.Web.Authorisation
{
    public interface IBearerTokenContext
    {
        string GrantType { get; }
        HttpContent Content { get; }
        Endpoint Endpoint { get; }
        void HeaderHandler(HttpRequestHeaders headers);
        string ContextKey();
    }
}