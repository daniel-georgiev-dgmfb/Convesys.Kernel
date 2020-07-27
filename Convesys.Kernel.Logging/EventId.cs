namespace Convesys.Kernel.Logging
{
    public struct EventId
    {
        public static implicit operator int(EventId eventId) => eventId.Id;
        public static implicit operator EventId(int eventId) => new EventId(eventId);
        public int Id { get; }
        public string Name { get; }
        public EventId(int id, string name = default)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}