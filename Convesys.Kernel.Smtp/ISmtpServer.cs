using System;
using System.Threading;
using System.Threading.Tasks;

namespace Convesys.Kernel.Smtp
{
    public interface ISmtpServer
    {
        Task StartAsync(CancellationToken cancellationToken);
    }
}