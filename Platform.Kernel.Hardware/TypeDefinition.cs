using System;

namespace Platform.Kernel.Communication.Common
{
	public abstract class TypeDefinition : BaseModel, IMapPrivateProperty
	{
		/// <summary>
		/// Gets the type definition representing by AssemblyQualifiedName for this model.
		/// This property is protected as it's used by EF only.
		/// </summary>
		protected string QualifiedName
		{
			get
			{
				if (this.Type == null)
					return string.Empty;

				return this.Type.AssemblyQualifiedName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					return;

				//ToDo: Resolve this via TypeResolver not directly
				this.Type = Type.GetType(value, true);
			}
		}

		/// <summary>
		/// Gets or sets the type of this Instance.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		public abstract Type Type { get; set; }
	}
}