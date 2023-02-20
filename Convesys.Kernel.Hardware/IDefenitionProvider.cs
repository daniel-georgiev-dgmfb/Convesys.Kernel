using System.Threading.Tasks;

namespace Twilight.Kernel.Communication.Common
{
    public interface IDefinitionProvider<TDefinition> where TDefinition : BaseDefinition
    {
        Task<TDefinition> GetDefinition(DefinitionContext<TDefinition> definitionContextDescriptor);
    }
}