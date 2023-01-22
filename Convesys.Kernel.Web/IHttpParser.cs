using System.Threading.Tasks;

namespace Convesys.Kernel.Web
{
    public interface IHttpParser<TModel>
    {
        Task<TModel> Parse(string source, bool throwOnFailure);
        bool TryParse(string source, out TModel result);
    }
}