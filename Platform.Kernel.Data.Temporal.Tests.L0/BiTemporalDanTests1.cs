namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    //[TestFixture]
    //[Ignore("No db")]
    //public class BiTemporalDanTests1 : BusAndRavenAbstractContext
    //{
    //    private string _id = "dbf61188-4598-4264-a35e-de4970798127";

    //    protected override bool InitialiseBus
    //    {
    //        get
    //        {
    //            return false;
    //        }
    //    }

    //    protected override void Init()
    //    {
    //        base.Init();
    //    }

    //    [Test]
    //    public void Bitemparal_write_test()
    //    {
    //        var currentDate = new DateTime(2013, 1, 1);

    //        var surnameEffective = Interval.FromDate(currentDate, currentDate.AddMonths(2));

    //        var surnameTransaction = Interval.FromDate(currentDate);

    //        var employee = new Person() { Id = _id };

    //        employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

    //        var dateOfChange1 = currentDate.AddMonths(4);

    //        var surnameEffective1 = Interval.FromDate(dateOfChange1);

    //        var surnameTransaction1 = Interval.FromDate(dateOfChange1);

    //        // Start the edit
    //        employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);
 
    //        using (var session = DocumentStore.OpenSession())
    //        {
    //            session.Store(employee);
    //            session.SaveChanges();
    //        }
    //    }

    //    [Test]
    //    public void Bitemparal_read_test()
    //    {
    //        using (var session = DocumentStore.OpenSession())
    //        {
    //            var emp = session.Load<Person>("dbf61188-4598-4264-a35e-de4970798127");
    //        }
    //    }
    //}
}
