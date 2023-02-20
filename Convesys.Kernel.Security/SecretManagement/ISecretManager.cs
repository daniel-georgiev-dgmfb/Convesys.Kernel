using System.Threading.Tasks;

namespace Twilight.Kernel.Security.SecretManagement
{
    public interface ISecretManager
    {
        Task<string> GetSecret(SecretContext secretContext);
        Task<string> GetSecret(string secretName);
        Task<string> GetSecret(string secretName, string version);
    }
}