using System.Threading.Tasks;

namespace Platform.Kernel.Data.ORM
{
    public interface IDbMapper<TBuilder>
    {
        Task Configure(TBuilder builder, IDbCustomConfiguration configuration);
    }
}