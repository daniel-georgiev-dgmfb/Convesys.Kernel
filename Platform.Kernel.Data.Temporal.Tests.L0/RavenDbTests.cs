namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    //[TestFixture]
    //[Ignore("No db")]
    //public class RavenDbTests : IDisposable
    //{
    //    private DocumentStore _documentStore;

    //    [TestFixtureSetUp]
    //    public void TestFixtureSetUp()
    //    {
    //        //_documentStore = new DocumentStore() { Url = "http://localhost:8081" };
    //        //_documentStore.ConfigureForUnity();
    //        //_documentStore.Initialize();

    //        _documentStore = new EmbeddableDocumentStore
    //        {
    //            RunInMemory = true,
    //            UseEmbeddedHttpServer = false,
    //        };
    //        //Raven.Database.Server.NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(9991);
    //        //_documentStore.SetStudioConfigToAllowSingleDb();
    //        //_documentStore.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
    //        _documentStore.Initialize();
    //    }

    //    private IDocumentSession GetSession()
    //    {
    //        return _documentStore.OpenSession();
    //        //return _documentStore.OpenSession("DebugDataStoreName");
    //    }


    //    [Test]
    //    public void BitemporalCollection_StoreWithNoEditsAndLoadById_Current()
    //    {
    //        var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
    //        var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

    //        string id = "dbf61188-4598-4264-a35e-de4970798127";

    //        var currentDate = new DateTime(2013, 3, 1);
    //        var dataEffectiveDate = Interval.FromDate(currentDate);
    //        var dataTransactionDate = Interval.FromDate(currentDate);

    //        var employee = new Person() { Id = id };

    //        employee.Payments.Set(pe1.Code, new PermPayment() { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate);
    //        employee.Payments.Set(pe2.Code, new PermPayment() { Amount = 200.00M, PaymentType = pe2 }, dataEffectiveDate);

    //        using (var session = GetSession())
    //        {
    //            session.Store(employee);
    //            session.SaveChanges();
    //        }

    //        using (var session = GetSession())
    //        {
    //            var loadedEmployee = session.Load<Person>(id);

    //            Assert.NotNull(loadedEmployee);
    //            Assert.AreEqual(100.00M, loadedEmployee.Payments.Get(pe1.Code).Value.Amount);
    //            Assert.AreEqual(200.00M, loadedEmployee.Payments.Get(pe2.Code).Value.Amount);

    //            // shouldn't exist
    //            Assert.IsNull(loadedEmployee.Payments.Get(pe2.Code, dataEffectiveDate.Start.AddDays(-50)));
    //        }
    //    }

    //    [Test]
    //    public void BitemporalCollection_StoreWithNoEditsAndQueryByNonIdProperty_Current()
    //    {
    //        var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
    //        var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

    //        string id = "dbf61188-4598-4264-a35e-de4970798127";

    //        var currentDate = new DateTime(2013, 3, 1);
    //        var dataEffectiveDate = Interval.FromDate(currentDate);
    //        var dataTransactionDate = Interval.FromDate(currentDate);

    //        var employee = new Person() { Id = id };

    //        employee.Surname.Set("Hendrix", dataEffectiveDate);
    //        employee.Payments.Set(pe1.Code, new PermPayment() { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate);
    //        employee.Payments.Set(pe2.Code, new PermPayment() { Amount = 200.00M, PaymentType = pe2 }, dataEffectiveDate);

    //        using (var session = GetSession())
    //        {
    //            session.Store(employee);
    //            session.SaveChanges();
    //        }

    //        using (var session = GetSession())
    //        {
    //            var loadedEmployee = session.Query<Person>().Where(e => e.Surname.CurrentValue == "Hendrix").FirstOrDefault();

    //            Assert.NotNull(loadedEmployee);
    //            Assert.AreEqual(100.00M, loadedEmployee.Payments.Get(pe1.Code).Value.Amount);
    //            Assert.AreEqual(200.00M, loadedEmployee.Payments.Get(pe2.Code).Value.Amount);

    //            // shouldn't exist
    //            Assert.IsNull(loadedEmployee.Payments.Get(pe2.Code, dataEffectiveDate.Start.AddDays(-50)));
    //        }
    //    }


    //    [Test]
    //    public void BitemporalCollection_StoreAndLoadByIdWithOneEdit_Current()
    //    {
    //        var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
    //        var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

    //        string id = "dbf61188-4598-4264-a35e-de4970798127";

    //        var currentDate = new DateTime(2013, 3, 1);
    //        var dataEffectiveDate = Interval.FromDate(currentDate);
    //        var dataTransactionDate = Interval.FromDate(currentDate);

    //        var employee = new Person() { Id = id };

    //        employee.Payments.Set(pe1.Code, new PermPayment() { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate);
    //        employee.Payments.Set(pe2.Code, new PermPayment() { Amount = 200.00M, PaymentType = pe2 }, dataEffectiveDate);

    //        using (var session = GetSession())
    //        {
    //            session.Store(employee);
    //            session.SaveChanges();
    //        }

    //        var dataTransactionDateC1 = Interval.FromDate(currentDate.AddSeconds(1));
    //        using (var session = GetSession())
    //        {
    //            var loadedEmployee = session.Load<Person>(id);

    //            Assert.NotNull(loadedEmployee);
    //            Assert.AreEqual(100.00M, loadedEmployee.Payments.Get(pe1.Code).Value.Amount);
    //            Assert.AreEqual(200.00M, loadedEmployee.Payments.Get(pe2.Code).Value.Amount);

    //            // shouldn't exist
    //            Assert.IsNull(loadedEmployee.Payments.Get(pe2.Code, dataEffectiveDate.Start.AddDays(-50)));

    //            loadedEmployee.Payments.Set(pe1.Code, new PermPayment() { Amount = 321.00M, PaymentType = pe1 }, dataEffectiveDate, dataTransactionDateC1);

    //            session.SaveChanges();
    //        }


    //        using (var session = GetSession())
    //        {
    //            var loadedEmployee = session.Load<Person>(id);
    //            Assert.NotNull(loadedEmployee);
    //            Assert.AreEqual(321.00M, loadedEmployee.Payments.Get(pe1.Code, currentDate.AddHours(1), dataTransactionDateC1.Start).Value.Amount);
    //            Assert.IsNull(loadedEmployee.Payments.Get(pe1.Code, dataEffectiveDate.Start.AddDays(-50)));
    //        }
    //    }

    //    /// <summary>
    //    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    //    /// </summary>
    //    public void Dispose()
    //    {
    //        if (_documentStore != null)
    //        {
    //            _documentStore.Dispose();
    //        }
    //    }
    //}
}
