﻿namespace Platform.Kernel.Tests.L0.MockData
{
	public class GenericBaseClass<T> : IGenericInterface<T> {}

	public class GenericDerivedClass<T> : GenericBaseClass<T>, IGenericInterface1<T> {}
}