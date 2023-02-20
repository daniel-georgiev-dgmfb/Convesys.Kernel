using System.Threading;
using System.Threading.Tasks;
using Twilight.Kernel.Mime;

namespace Twilight.Kernel.Smtp.MailboxFilter
{
    public interface IMailboxFilter
    {
        Task<MailboxFilterResult> CanAcceptFromAsync(
            ISessionContext context, 
            Mailbox from, 
            CancellationToken cancellationToken);

        Task<MailboxFilterResult> CanDeliverToAsync(
            ISessionContext context, 
            Mailbox to, 
            Mailbox from, 
            CancellationToken cancellationToken);
    }
}