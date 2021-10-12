using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Platform.Kernel.Smtp.Exceptions
{
    [Serializable]
    public class RecipientsNotAcceptedException : Exception
    {
        private readonly IList<RecipientError> _recipientErrors;

        public RecipientsNotAcceptedException(IList<RecipientError> recipientErrors)
            : base($"The following recipients were not accepted: {string.Join(", ", recipientErrors.Select(x => x.EmailAddress.AsAddress()))}")
        {
            _recipientErrors = recipientErrors;
        }

        public RecipientsNotAcceptedException(string message, IList<RecipientError> recipientErrors)
            : base(message)
        {
            _recipientErrors = recipientErrors;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("RecipientErrors", _recipientErrors, typeof(IList<RecipientError>));
            base.GetObjectData(info, context);
        }
    }
}
