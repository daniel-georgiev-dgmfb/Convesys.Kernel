using Platform.Kernel.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace Platform.Kernel.Smtp.MailboxFilter
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