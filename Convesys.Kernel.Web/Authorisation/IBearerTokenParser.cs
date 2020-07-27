using System.Threading.Tasks;

namespace Convesys.Kernel.Web.Authorisation
{
    public interface IBearerTokenParser
    {
        Task<TokenDescriptor> Parse(string source);
    }
}