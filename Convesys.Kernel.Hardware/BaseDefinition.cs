using System;
namespace Twilight.Kernel.Communication.Common
{
	public abstract partial class BaseDefinition : TypeDefinition
	{
		/// <summary>
		/// Gets or sets the type of the object described by this definition to create.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public override Type Type { get; set; }
	}
}