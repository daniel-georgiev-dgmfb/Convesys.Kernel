using System.IO;
using System.Threading.Tasks;

namespace Platform.Kernel.Compression
{
    public interface ICompressor
    {
        Task<Stream> Compress(Stream stream);
        Task<Stream> Decompress(Stream stream);
    }
}
