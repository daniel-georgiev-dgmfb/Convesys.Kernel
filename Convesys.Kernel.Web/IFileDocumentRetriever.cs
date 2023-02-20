namespace Twilight.Kernel.Web
{
    public interface IFileDocumentRetriever : IResourceRetriever
    {
        long MaxResponseContentBufferSize { get; set; }
    }
}