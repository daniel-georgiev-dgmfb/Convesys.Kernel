﻿using Platform.Kernel.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Platform.Kernel.Initialisation
{
	/// <summary>
	/// Initialises the server
	/// </summary>
	public interface IServerInitialiser
	{
        ICollection<string> InitialiserTypes { get; }
		Task Initialise(IDependencyResolver dependencyResolver);
        Task Initialise(IDependencyResolver dependencyResolver, Func<IInitialiser, bool> condition);
        Task Initialise(IEnumerable<IInitialiser> initialisers, IDependencyResolver dependencyResolver, Func<IInitialiser, bool> condition);
    }
}