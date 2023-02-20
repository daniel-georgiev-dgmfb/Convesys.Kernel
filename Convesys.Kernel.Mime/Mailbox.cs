using System;
using System.Globalization;

namespace Twilight.Kernel.Mime
{
    public class Mailbox
    {
        public static readonly Mailbox Empty = new Mailbox(string.Empty, string.Empty);

        public Mailbox()
        {    
        }

        public Mailbox(string user, string host)
        {
            User = user;
            Host = host;
        }

        public Mailbox(string address)
        {
            address = address.Replace(" ", string.Empty);

            var index = address.IndexOf('@');

            User = address.Substring(0, index);
            Host = address.Substring(index + 1);
        }

        public string User { get; set; }

        public string Host { get; set; }

        public string DisplayName { get; set; }

        public string AsAddress()
        {
            if (string.IsNullOrWhiteSpace(User) || string.IsNullOrWhiteSpace(Host))
            {
                return null;
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}@{1}", User, Host);
        }
    }
}