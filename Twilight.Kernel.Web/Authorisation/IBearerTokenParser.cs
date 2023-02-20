using System.Threading.Tasks;

namespace Platform.Kernel.Web.Authorisation
{
    public interface IBearerTokenParser
    {
        Task<TokenDescriptor> Parse(string source);
    }
}