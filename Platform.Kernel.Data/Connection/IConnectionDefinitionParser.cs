﻿namespace Platform.Kernel.Data.Connection
{
	public interface IConnectionDefinitionParser
	{
		/// <summary>
		///     Get connection definition
		/// </summary>
		IDbConnectionDefinition ConnectionDefinition { get; }
	}
}