using System.Threading.Tasks;

namespace Twilight.Kernel.Web.Authorisation
{
    public interface IBearerTokenParser
    {
        Task<TokenDescriptor> Parse(string source);
    }
}