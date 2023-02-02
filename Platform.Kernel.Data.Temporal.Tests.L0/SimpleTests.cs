namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    [TestFixture]
    public class SimpleTests : IDisposable
    {
        //Date	Real world event	Database Action	What the database shows
        //April 3, 1975	John is born	Nothing	There is no person called John Doe
        //April 4, 1975	John's father officially reports John's birth	Inserted:Person(John Doe, Smallville)	John Doe lives in Smallville
        //August 26, 1994	After graduation, John moves to Bigtown, but forgets to register his new address	Nothing	John Doe lives in Smallville
        //December 26, 1994	Nothing	Nothing	John Doe lives in Smallville
        //December 27, 1994	John registers his new address	Updated:Person(John Doe, Bigtown)	John Doe lives in Bigtown
        //April 1, 2001	John dies	Deleted:Person(John Doe)	There is no person called John Doe
        
        //[TestFixtureSource()]
        //public void TestFixtureSetUp()
        //{
            
        //}

        [Test]
        public void Bitemporal_NoEdits_Current()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";
            var dob = new DateTime(1980, 5, 18);

            var employee = new Person() { Id = id };
            employee.Forename = "Jimi";
            employee.Surname.Set("Hendrix");
            employee.DateOfBirth = dob;
            var address = new Address() { Line1 = "1 Letzbe Avenue", Line2 = "Big Town", Line3 = "Big County", Postcode = "A12 34B" };
            employee.Address.Set(address);

            Assert.That(employee.Forename, Is.EqualTo("Jimi"));
            Assert.That(employee.DateOfBirth, Is.EqualTo(dob));

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            Assert.IsTrue(employee.Surname.HasValue(DateTime.Now));
            Assert.That(employee.Surname.Value(DateTime.Now), Is.EqualTo("Hendrix"));

            var pastDate = DateTime.Now.AddDays(-30);
            Assert.IsFalse(employee.Surname.HasValue(pastDate));
            Assert.IsNull(employee.Surname.Value(pastDate));

            var futureDate = DateTime.Now.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(futureDate));
            Assert.That(employee.Surname.Value(futureDate), Is.EqualTo("Hendrix"));

            // move the observer into the future
            var observerDateFuture = DateTime.Now.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(DateTime.Now, observerDateFuture));
            Assert.That(employee.Surname.Value(DateTime.Now, observerDateFuture), Is.EqualTo("Hendrix"));

            // move the observer into the past
            var observerDatePast = DateTime.Now.AddYears(-1);
            Assert.IsFalse(employee.Surname.HasValue(DateTime.Now, observerDatePast));
            Assert.IsNull(employee.Surname.Value(DateTime.Now, observerDatePast));
        }

        [Test]
        public void Bitemporal_NoEdits_Future()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";
            var dob = new DateTime(1980, 5, 18);
            var futureDate = new DateTime(2050, 1, 1);

            var employee = new Person() { Id = id };
            employee.Forename = "Jimi";
            employee.Surname.Set("Hendrix", Interval.FromDate(futureDate));
            employee.DateOfBirth = dob;
            var address = new Address() { Line1 = "1 Letzbe Avenue", Line2 = "Big Town", Line3 = "Big County", Postcode = "A12 34B" };
            employee.Address.Set(address, Interval.FromDate(futureDate));

            Assert.That(employee.Forename, Is.EqualTo("Jimi"));
            Assert.That(employee.DateOfBirth, Is.EqualTo(dob));

            Assert.IsFalse(employee.Surname.HasValue());
            Assert.IsNull(employee.Surname.CurrentValue);

            Assert.IsFalse(employee.Surname.HasValue(DateTime.Now));
            Assert.IsNull(employee.Surname.Value(DateTime.Now));

            var pastDate2 = DateTime.Now.AddDays(-30);
            Assert.IsFalse(employee.Surname.HasValue(pastDate2));
            Assert.IsNull(employee.Surname.Value(pastDate2));

            var futureDate2 = futureDate.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(futureDate2));
            Assert.That(employee.Surname.Value(futureDate2), Is.EqualTo("Hendrix"));

            // move the observer into the future
            var observerDateFuture = futureDate.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(futureDate2, observerDateFuture));
            Assert.That(employee.Surname.Value(futureDate2, observerDateFuture), Is.EqualTo("Hendrix"));

            // move the observer into the past
            var observerDatePast = DateTime.Now.AddYears(-1);
            Assert.IsFalse(employee.Surname.HasValue(futureDate2, observerDatePast));
            Assert.IsNull(employee.Surname.Value(futureDate2, observerDatePast));
        }

        [Test]
        public void Bitemporal_NoEdits_Past()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";
            var dob = new DateTime(1980, 5, 18);
            var pastDate = new DateTime(2010, 1, 1);

            var employee = new Person() { Id = id };
            employee.Forename = "Jimi";
            employee.Surname.Set("Hendrix", Interval.FromDate(pastDate));
            employee.DateOfBirth = dob;
            var address = new Address() { Line1 = "1 Letzbe Avenue", Line2 = "Big Town", Line3 = "Big County", Postcode = "A12 34B" };
            employee.Address.Set(address, Interval.FromDate(pastDate));

            Assert.That(employee.Forename, Is.EqualTo("Jimi"));
            Assert.That(employee.DateOfBirth, Is.EqualTo(dob));

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            Assert.IsTrue(employee.Surname.HasValue(DateTime.Now));
            Assert.That(employee.Surname.Value(DateTime.Now), Is.EqualTo("Hendrix"));

            var pastDate2 = pastDate.AddDays(-30);
            Assert.IsFalse(employee.Surname.HasValue(pastDate2));
            Assert.IsNull(employee.Surname.Value(pastDate2));

            var futureDate2 = pastDate.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(futureDate2));
            Assert.That(employee.Surname.Value(futureDate2), Is.EqualTo("Hendrix"));

            // move the observer into the future
            var observerDateFuture = pastDate.AddYears(5);
            Assert.IsTrue(employee.Surname.HasValue(futureDate2, observerDateFuture));
            Assert.That(employee.Surname.Value(futureDate2, observerDateFuture), Is.EqualTo("Hendrix"));

            // move the observer into the past
            var observerDatePast = pastDate.AddYears(-1);
            Assert.IsFalse(employee.Surname.HasValue(futureDate2, observerDatePast));
            Assert.IsNull(employee.Surname.Value(futureDate2, observerDatePast));
        }

        [Test]
        public void Bitemporal_OneEdit_Current()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var surnameEffective = Interval.FromDate(currentDate);
            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };
            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            var dateOfChange1 = currentDate.AddMonths(1);
            var surnameEffective1 = Interval.FromDate(dateOfChange1);
            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            // Start the edit
            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Thompson"));
            Assert.That(employee.Surname.Value(Interval.Now, currentDate), Is.EqualTo("Hendrix"));
        }

        [Test]
        public void Bitemporal_OneEdit_Future()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var surnameEffective = Interval.FromDate(currentDate);
            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };
            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            var dateOfChange1 = currentDate.AddMonths(1);
            var surnameEffective1 = Interval.FromDate(dateOfChange1);
            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            // Start the edit
            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Thompson"));
            Assert.That(employee.Surname.Value(Interval.Now, currentDate), Is.EqualTo("Hendrix"));
        }

        [Test]
        public void Bitemporal_OneEdit_Past()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var surnameEffective = Interval.FromDate(currentDate);
            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };
            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            var dateOfChange1 = currentDate.AddMonths(-1);
            var surnameEffective1 = Interval.FromDate(dateOfChange1);
            var surnameTransaction1 = Interval.FromDate(Interval.Now.AddDays(-1));

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Thompson"));
            Assert.That(employee.Surname.Value(Interval.Now, surnameTransaction1.Start.AddDays(-1)), Is.EqualTo("Hendrix"));
        }

        [Test]
        public void Bitemporal_TwoEdits_OneOverridingTheOther()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var surnameEffective = Interval.FromDate(currentDate);
            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };
            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            Assert.IsTrue(employee.Surname.HasValue());
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Hendrix"));

            var dateOfChange1 = currentDate.AddMonths(1);
            var surnameEffective1 = Interval.FromDate(dateOfChange1);
            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            // Start the edit
            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Thompson"));
            Assert.That(employee.Surname.Value(Interval.Now, currentDate), Is.EqualTo("Hendrix"));


            var dateOfChange2 = currentDate.AddMonths(1);
            var surnameEffective2 = Interval.FromDate(dateOfChange2);
            var surnameTransaction2 = Interval.FromDate(dateOfChange2);

            // Start the edit
            employee.Surname.Set("Clapton", surnameEffective2, surnameTransaction2);
            Assert.That(employee.Surname.CurrentValue, Is.EqualTo("Clapton"));
            Assert.That(employee.Surname.Value(Interval.Now, currentDate), Is.EqualTo("Hendrix"));
        }

        [Test]
        public void BitemporalCollection_NoEdits_Current()
        {
            var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
            var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 10), dataEffectiveDate);
            employee.Payments.Set(pe2.Code, new PermPayment(pe2, 10), dataEffectiveDate);

            Assert.That(100.00M == employee.Payments.Get(pe1.Code).Value.Amount);
            Assert.That(200.00M == employee.Payments.Get(pe2.Code).Value.Amount);

            // shouldn't exist
            Assert.IsNull(employee.Payments.Get(pe2.Code, dataEffectiveDate.Start.AddDays(-50)));
        }

        [Test]
        public void BitemporalCollection_NoEdits_Future()
        {
            var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
            var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = DateTime.Now.AddDays(60);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 100), dataEffectiveDate);

            // shouldn't exist as not valid until 60 days from now
            Assert.IsNull(employee.Payments.Get(pe1.Code));

            Assert.That(employee.Payments.Get(pe1.Code, currentDate.AddDays(1)).Value.Amount, Is.EqualTo(100.00M));
        }

        [Test]
        public void BitemporalCollection_NoEdits_Past()
        {
            var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
            var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = DateTime.Now.AddDays(-60);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Payments.Set(pe1.Code, new PermPayment(pe1,10) { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate);

            Assert.That(100.00M == employee.Payments.Get(pe1.Code).Value.Amount);

            Assert.IsNull(employee.Payments.Get(pe1.Code, currentDate.AddDays(-1)));
        }

        [Test]
        public void BitemporalCollection_TwoEdits_OneOverridingTheOther()
        {
            var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };
            var pe2 = new PayElement() { Code = "PE2", Name = "EE Pension" };

            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 3, 1);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 10) { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate);
            employee.Payments.Set(pe2.Code, new PermPayment(pe1, 10) { Amount = 200.00M, PaymentType = pe2 }, dataEffectiveDate);

            Assert.That(100.00M == employee.Payments.Get(pe1.Code).Value.Amount);
            Assert.That(200.00M == employee.Payments.Get(pe2.Code).Value.Amount);

            var dataTransactionDateC1 = Interval.FromDate(currentDate.AddSeconds(1));
            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 10) { Amount = 321.00M, PaymentType = pe1 }, dataEffectiveDate, dataTransactionDateC1);

            Assert.That(321.00M == employee.Payments.Get(pe1.Code, currentDate.AddHours(1), dataTransactionDateC1.Start).Value.Amount);
            Assert.IsNull(employee.Payments.Get(pe1.Code, dataEffectiveDate.Start.AddDays(-50)));


            var dataTransactionDateC2 = Interval.FromDate(currentDate.AddSeconds(2));
            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 10) { Amount = 543.00M, PaymentType = pe1 }, dataEffectiveDate, dataTransactionDateC1);

            Assert.That(employee.Payments.Get(pe1.Code, currentDate.AddHours(1), dataTransactionDateC2.Start).Value.Amount, Is.EqualTo(543.00M));
            Assert.IsNull(employee.Payments.Get(pe2.Code, dataEffectiveDate.Start.AddDays(-50)));

        }

        [Test]
        //[TestCase("Future transaction dates are not supported.", typeof(ArgumentOutOfRangeException))]
        public void BitemporalCollection_FutureTransaction_ThorwException()
        {
            var pe1 = new PayElement() { Code = "PE1", Name = "Company Car" };

            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = DateTime.Now.AddMonths(1);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Payments.Set(pe1.Code, new PermPayment(pe1, 10) { Amount = 100.00M, PaymentType = pe1 }, dataEffectiveDate, dataTransactionDate);
        }

        [Test]
        //[(typeof(ArgumentOutOfRangeException), UserMessage = "Future transaction dates are not supported.")]
        public void Bitemporal_FutureTransaction_ThorwException()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = DateTime.Now.AddMonths(1);
            var dataEffectiveDate = Interval.FromDate(currentDate);
            var dataTransactionDate = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", dataEffectiveDate, dataTransactionDate);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }
    }
}
