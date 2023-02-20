using System.Threading.Tasks;

namespace Twilight.Kernel.Data.ORM
{
    public interface IDbMapper<TBuilder>
    {
        Task Configure(TBuilder builder, IDbCustomConfiguration configuration);
    }
}