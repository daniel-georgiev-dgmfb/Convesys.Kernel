using Platform.Kernel.Communication.Common;
using System;
using System.Threading.Tasks;

namespace Platform.Kernel.Communication.Connection
{
	public interface IConnection : IDisposable
	{
		#region Properties

		/// <summary>
		///     Gets the connection definition.
		/// </summary>
		/// <value>
		///     The connection definition.
		/// </value>
		IDefinitionProvider<ConnectionDefinition> ConnectionDefinitionProvider { get; }

		/// <summary>
		///     Used to subscribe to connection events.
		/// </summary>
		/// <value>
		///     The connection.
		/// </value>
		IObservable<ConnectionStatus> ConnectionState { get; }

		#endregion

		/// <summary>
		///     Connects the specified IP address.
		/// </summary>
		/// <returns></returns>
		Task<bool> Connect();

		/// <summary>
		///     Disconnects this instance.
		/// </summary>
		/// <returns></returns>
		Task<bool> Disconnect();
	}
}
