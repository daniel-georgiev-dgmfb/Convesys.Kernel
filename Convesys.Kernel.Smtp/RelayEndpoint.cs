namespace Twilight.Kernel.Smtp
{
    public class RelayEndpoint
    {
        private const int DefaultPort = 25;

        public int Port { get; set; }
        public string ServerName { get; set; }

        public RelayEndpoint()
        {
            
        }

        public RelayEndpoint(string serverName, int port = DefaultPort)
        {
            ServerName = serverName;
            Port = port;
        }

        public override string ToString()
        {
            return $"{ServerName}:{Port}";
        }

        protected bool Equals(RelayEndpoint other)
        {
            if (other == null) return false;
            return Port == other.Port && string.Equals(ServerName, other.ServerName);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Port * 397) ^ (ServerName != null ? ServerName.GetHashCode() : 0);
            }
        }
    }
}
