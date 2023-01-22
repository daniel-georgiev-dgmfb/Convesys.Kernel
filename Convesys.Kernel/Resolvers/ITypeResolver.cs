using System;

namespace Convesys.Kernel.Resolvers
{
    public interface ITypeResolver
    {
        Type ResolverUnderlyingType(Type type);
    }
}