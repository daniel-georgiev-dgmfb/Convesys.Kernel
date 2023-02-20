using System;
using Twilight.Kernel.Security.Configuration;

namespace Twilight.Kernel.Security.Validation
{
    public interface ICertificateValidationConfigurationProvider : IDisposable
    {
        CertificateValidationConfiguration GetConfiguration(string federationPartyId);
        BackchannelConfiguration GeBackchannelConfiguration(string federationPartyId);
        BackchannelConfiguration GeBackchannelConfiguration(Uri partyUri);
    }
}