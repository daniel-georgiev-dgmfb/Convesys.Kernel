using System;

namespace Twilight.Kernel.Resolvers
{
    public interface ITypeResolver
    {
        Type ResolverUnderlyingType(Type type);
    }
}