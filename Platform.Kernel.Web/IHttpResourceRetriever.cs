using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace Platform.Kernel.Web
{
	/// <summary>
	/// Provides properties to configure Http client
	/// </summary>
	public interface IHttpResourceRetriever : IResourceRetriever
    {
        /// <summary>
        /// If set to true secure connections is required.
        /// </summary>
        bool RequireHttps { get; set; }
        /// <summary>
        /// Gets or sets the timeout
        /// </summary>
        TimeSpan Timeout { get; set; }
        /// <summary>
        /// Gets or sets maximum response content buffer size
        /// </summary>
        long MaxResponseContentBufferSize { get; set; }
        /// <summary>
        /// Delegate to add headers
        /// </summary>
        Action<HttpRequestHeaders> HeadersHandler { set; }
        /// <summary>
        /// Sets custom configurator
        /// </summary>
        ICustomConfigurator<IHttpResourceRetriever> HttpDocumentRetrieverConfigurator { set; }
        /// <summary>
        /// Gets cookies collection
        /// </summary>
        ICollection<Cookie> Cookies { get; }
    }
}