using System;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Smtp
{
    public interface ISmtpServer
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}