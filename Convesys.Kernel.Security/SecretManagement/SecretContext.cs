using System;

namespace Twilight.Kernel.Security.SecretManagement
{
    public class SecretContext
    {
        public SecretContext(string secretName)
        {
            if (String.IsNullOrWhiteSpace(secretName))
                throw new ArgumentNullException(secretName);
            this.SecretName = secretName;
        }
        public string SecretName { get; }
        public string Version { get; set; }
    }
}