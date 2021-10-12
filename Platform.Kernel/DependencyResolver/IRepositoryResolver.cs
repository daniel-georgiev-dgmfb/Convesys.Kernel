using System;

namespace Platform.Kernel.DependencyResolver
{
    public interface IRepositoryResolver
	{
		object ResolveRepository(Type type);
	}
}
