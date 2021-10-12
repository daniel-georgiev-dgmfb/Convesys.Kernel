namespace Platform.Kernel.Communication.Connection
{
    public enum ConnectionStatus : byte
	{
		Disconnected,
		Connected,
		Reconnecting,
		Fault,
		Degraded
	}
}
