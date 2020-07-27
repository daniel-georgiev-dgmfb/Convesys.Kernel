using System;

namespace Convesys.Kernel.DependencyResolver
{
    public interface IRepositoryResolver
	{
		object ResolveRepository(Type type);
	}
}
