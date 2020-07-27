using Convesys.Kernel.Smtp.Authentication;
using Convesys.Kernel.Smtp.Storage;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Convesys.Kernel.Smtp.MailboxFilter;
using Convesys.Kernel.Smtp.Transport;
using Convesys.Kernel.Smtp.Validation;

namespace Convesys.Kernel.Smtp
{
    public interface ISmtpServerOptions
    {
        int MaxMessageSize { get; }

        int MaxRetryCount { get; }

        string ServerName { get; }

        X509Certificate ServerCertificate { get; }

        IReadOnlyList<IEndpointDefinition> Endpoints { get; }

        ICollection<IMessageValidator> MessageValidators { get; set; }

        ICollection<IMessageStore> MessageStores { get; set; }

        ICollection<IMailboxFilter> MailboxFilters { get; set; }

        ICollection<IMessageTransport> MessageTransports { get; set; }

        IUserAuthenticator UserAuthenticator { get; }

        bool AllowUnsecureAuthentication { get; }

        bool AuthenticationRequired { get; }

        SslProtocols SupportedSslProtocols { get; }

        TimeSpan CommandWaitTimeout { get; }

        int NetworkBufferSize { get; }

        TimeSpan NetworkBufferReadTimeout { get; }
    }
}