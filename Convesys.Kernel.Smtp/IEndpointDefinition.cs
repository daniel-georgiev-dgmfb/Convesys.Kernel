using System.Net;

namespace Convesys.Kernel.Smtp
{
    public interface IEndpointDefinition
    {
        /// <summary>
        /// The IP endpoint to listen on.
        /// </summary>
        IPEndPoint Endpoint { get; }

        /// <summary>
        /// Indicates whether the endpoint is secure by default.
        /// </summary>
        bool IsSecure { get; }
    }
}