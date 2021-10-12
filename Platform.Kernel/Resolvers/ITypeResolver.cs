using System;

namespace Platform.Kernel.Resolvers
{
    public interface ITypeResolver
    {
        Type ResolverUnderlyingType(Type type);
    }
}