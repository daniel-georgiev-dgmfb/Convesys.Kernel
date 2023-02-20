using System;

namespace Twilight.Kernel.DependencyResolver
{
    public interface IRepositoryResolver
	{
		object ResolveRepository(Type type);
	}
}
