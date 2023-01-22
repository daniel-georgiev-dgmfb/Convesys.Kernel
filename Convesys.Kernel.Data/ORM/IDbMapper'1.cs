using System.Threading.Tasks;

namespace Convesys.Kernel.Data.ORM
{
    public interface IDbMapper<TBuilder>
    {
        Task Configure(TBuilder builder, IDbCustomConfiguration configuration);
    }
}