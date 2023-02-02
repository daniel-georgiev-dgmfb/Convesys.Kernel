using Platform.Kernel.Data.Temporal;

namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    public class Person
    {
        public Person()
        {
            Surname = new BitemporalProperty<string>();
            Address = new BitemporalProperty<Address>();
            Payments = new BitemporalCollection<PermPayment>();
        }

        public string Id { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Forename { get; set; }

        public BitemporalProperty<string> Surname { get; private set; }

        public BitemporalProperty<Address> Address { get; private set; }

        public BitemporalCollection<PermPayment> Payments { get; private set; }

    }
}
