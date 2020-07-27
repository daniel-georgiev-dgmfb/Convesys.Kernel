using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Threading;
using System.Threading.Tasks;
using Convesys.Kernel.Mime;
using Convesys.Kernel.Smtp.Exceptions;

namespace Convesys.Kernel.Smtp
{
    public interface ISmtpRelayClient : IDisposable
    {
        IList<RecipientError> RecipientExceptions { get; }
        RelayEndpoint CurrentConnectedRelayEndpoint { get; }
        bool IsConnected { get; }
        bool IsAuthenticated { get; }
        HashSet<string> AuthenticationMechanisms { get; }
        RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; set; }
        Task ConnectAsync(RelayEndpoint relayEndpoint, TlsSecurityOption tlsSecurityOption, int timeout);
        Task AuthenticateAsync(ICredentials credentials, CancellationToken cancellationToken = default(CancellationToken));
        Task SendAsync(IMimeMessage message, Mailbox address, IEnumerable<Mailbox> recipients, CancellationToken cancellationToken = default(CancellationToken));
        Task DisconnectAsync(bool quit, CancellationToken cancellationToken = default(CancellationToken));
    }
}
