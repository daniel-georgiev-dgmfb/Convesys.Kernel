namespace Twilight.Kernel.Transport
{
    public class TransportConnection
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }

        public TransportConnection()
        {
            
        }

        public TransportConnection(string connectionString, string queueName)
        {
            ConnectionString = connectionString;
            QueueName = queueName;
        }
    }
}
