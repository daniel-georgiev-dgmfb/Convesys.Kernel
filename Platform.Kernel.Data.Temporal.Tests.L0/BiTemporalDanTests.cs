namespace Platform.Kernel.Data.Temporal.Tests.L0
{
    [TestFixture]
    //[Ignore]
    public partial class BiTemporalDanTests
    { 
        [Test]
        public void Bitemporal_OneEdit_WithGap_Past()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate, currentDate.AddMonths(2));
            
            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };
            
            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = currentDate.AddMonths(4);
            
            var surnameEffective1 = Interval.FromDate(dateOfChange1);
            
            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            // Start the edit
            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);

            Assert.AreEqual("Thompson", employee.Surname.CurrentValue);

            var testdate = new DateTime(2013, 2, 1);

            Assert.AreEqual("Hendrix", employee.Surname.Value(testdate));

            Assert.AreEqual("Hendrix", employee.Surname.Value(testdate, currentDate));

            Assert.Null(employee.Surname.Value(dateOfChange1.AddMonths(1), testdate));

            Assert.Null(employee.Surname.Value(Interval.Now, testdate));

            
        }

        [Test]
        public void Bitemporal_Edit_Contains_Past()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate);

            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = currentDate.AddMonths(4);

            var surnameEffective1 = Interval.FromDate(dateOfChange1, dateOfChange1.AddMonths(3));

            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1);

            Assert.IsNull(employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(currentDate.AddMonths(1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, currentDate.AddMonths(1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(dateOfChange1.AddMonths(1)));

            Assert.Null(employee.Surname.Value(Interval.Now, dateOfChange1.AddMonths(1)));
        }

        [Test]
        public void Bitemporal_multiple_temporary_nested()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";
            
            var employee = new Person() { Id = id };

            var dateOfChange0 = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(dateOfChange0);

            var surnameTransaction = Interval.FromDate(dateOfChange0);

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            //a new record
            var dateOfChangeStart1 = new DateTime(2010, 3, 1);

            var dateOfChangeEnd1 = new DateTime(2010, 12, 1);
            
            var surnameEffective1 = Interval.FromDate(dateOfChangeStart1, dateOfChangeEnd1);

            var surnameTransaction1 = Interval.FromDate(dateOfChangeStart1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //a new record
            var dateOfChangeStart2 = new DateTime(2010, 6, 1);

            var dateOfChangeEnd2 = new DateTime(2010, 9, 1);

            var surnameEffective2 = Interval.FromDate(dateOfChangeStart2, dateOfChangeEnd2);

            var surnameTransaction2 = Interval.FromDate(dateOfChangeStart2);

            employee.Surname.Set("Georgiev", surnameEffective2, surnameTransaction2, true);

            //a new record
            var dateOfChangeStart3 = new DateTime(2010, 8, 1);

            var dateOfChangeEnd3 = new DateTime(2010, 10, 1);

            var surnameEffective3 = Interval.FromDate(dateOfChangeStart3, dateOfChangeEnd3);

            var surnameTransaction3 = Interval.FromDate(dateOfChangeStart3);

            employee.Surname.Set("Georgiev1", surnameEffective3, surnameTransaction3, true);

            //a new record
            var dateOfChangeStart4 = new DateTime(2011, 1, 1);

            var dateOfChangeEnd4 = new DateTime(2011, 3, 1);

            var surnameEffective4 = Interval.FromDate(dateOfChangeStart4, dateOfChangeEnd4);

            var surnameTransaction4 = Interval.FromDate(dateOfChangeStart4);

            employee.Surname.Set("Georgiev2", surnameEffective4, surnameTransaction4, true);

            //Assertions
            Assert.AreEqual("Hendrix", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 5, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.AreEqual("Georgiev2", employee.Surname.Value(new DateTime(2011, 2, 1)));

            Assert.AreEqual("Georgiev1", employee.Surname.Value(new DateTime(2010, 9, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2011, 4, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, Interval.Now));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, new DateTime(2010, 2, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2010, 7, 1)));
        }

        [Test]
        public void Bitemporal_one_temporary__two_continuous_nested()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var employee = new Person() { Id = id };

            var dateOfChange0 = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(dateOfChange0);

            var surnameTransaction = Interval.FromDate(dateOfChange0);

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            //a new record
            var dateOfChangeStart1 = new DateTime(2010, 3, 1);

            var dateOfChangeEnd1 = new DateTime(2010, 12, 1);

            var surnameEffective1 = Interval.FromDate(dateOfChangeStart1, dateOfChangeEnd1);

            var surnameTransaction1 = Interval.FromDate(dateOfChangeStart1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //a new record
            var dateOfChangeStart2 = new DateTime(2010, 6, 1);

            //var dateOfChangeEnd2 = new DateTime(2010, 9, 1);

            var surnameEffective2 = Interval.FromDate(dateOfChangeStart2);

            var surnameTransaction2 = Interval.FromDate(dateOfChangeStart2);

            employee.Surname.Set("Georgiev", surnameEffective2, surnameTransaction2);

            //Assertions
            Assert.AreEqual("Georgiev", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 5, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 9, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2011, 2, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2011, 4, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(Interval.Now, Interval.Now));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, new DateTime(2010, 2, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2010, 7, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 9, 1), new DateTime(2010, 2, 1)));
        }

        [Test]
        public void Bitemporal_Edit_one_temporary_one_continuous()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2013, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate);

            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = currentDate.AddMonths(4);

            var surnameEffective1 = Interval.FromDate(dateOfChange1, dateOfChange1.AddMonths(3));

            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            Assert.AreEqual("Hendrix", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(currentDate.AddMonths(1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, currentDate.AddMonths(1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(dateOfChange1.AddMonths(1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, currentDate));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, dateOfChange1.AddMonths(1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, dateOfChange1.AddMonths(1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2013, 6, 1), new DateTime(2013, 7, 1)));
        }

        [Test]
        public void Bitemporal_one_temporary__two_continuous_nested_efective_in_the_pass()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var employee = new Person() { Id = id };

            var dateOfChange0 = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(dateOfChange0);

            var surnameTransaction = Interval.FromDate(dateOfChange0);

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            //a new record
            var dateOfChangeStart1 = new DateTime(2010, 5, 1);

            var dateOfChangeEnd1 = new DateTime(2010, 8, 1);

            var surnameEffective1 = Interval.FromDate(dateOfChangeStart1, dateOfChangeEnd1);

            var surnameTransaction1 = Interval.FromDate(dateOfChangeStart1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //a new record
            var dateOfChangeStart2 = new DateTime(2010, 6, 1);

            var surnameEffective2 = Interval.FromDate(new DateTime(2010, 3, 1));

            var surnameTransaction2 = Interval.FromDate(dateOfChangeStart2);

            employee.Surname.Set("Georgiev", surnameEffective2, surnameTransaction2);

            //Assertions
            Assert.AreEqual("Georgiev", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2010, 4, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2010, 9, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2011, 2, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2011, 4, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(Interval.Now, Interval.Now));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 4, 1), new DateTime(2010, 4, 1, 6, 0, 0)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2010, 4, 1), new DateTime(2010, 9, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(Interval.Now, new DateTime(2010, 2, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2010, 7, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 9, 1), new DateTime(2010, 2, 1)));
        }

        [Test]
        public void Bitemporal_one_temporary_operlips_both__two_continuous_with_end_effective_date_not_overlaping()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var employee = new Person() { Id = id };

            var dateOfChange0 = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(dateOfChange0, new DateTime(2010,5,1));

            var surnameTransaction = Interval.FromDate(dateOfChange0);

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            //a new record
            var dateOfChangeStart1 = new DateTime(2010, 3, 1);

            var dateOfChangeEnd1 = new DateTime(2010, 9, 1);

            var surnameEffective1 = Interval.FromDate(dateOfChangeStart1, dateOfChangeEnd1);

            var surnameTransaction1 = Interval.FromDate(dateOfChangeStart1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //a new record
            var dateOfChangeStart2 = new DateTime(2010, 8, 1);

            var surnameEffective2 = Interval.FromDate(dateOfChangeStart2, new DateTime(2010, 11, 1));

            var surnameTransaction2 = Interval.FromDate(dateOfChangeStart2);

            employee.Surname.Set("Georgiev", surnameEffective2, surnameTransaction2);

            //Assertions
            Assert.Null(employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 4, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 9, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2010, 4, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 4, 1), new DateTime(2010, 9, 1)));

            Assert.Null(employee.Surname.Value(Interval.Now, new DateTime(2010, 2, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2010, 7, 1)));

            Assert.Null(employee.Surname.Value(new DateTime(2010, 9, 1), new DateTime(2010, 2, 1)));

            Assert.Null(employee.Surname.Value(new DateTime(2010, 2, 1), new DateTime(2009, 7, 1)));
        }

        [Test]
        public void Bitemporal_Edit_one_temporary_with_effective_in_past_one_continuous()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate);

            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = new DateTime(2010, 6, 1);

            var surnameEffective1 = Interval.FromDate(new DateTime(2010, 3, 1), new DateTime(2010, 10, 1));

            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //Assertions

            Assert.AreEqual("Hendrix", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 4, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 4, 1), new DateTime(2010, 5, 1)));

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 4, 1), new DateTime(2010, 2, 1)));
        }

        [Test]
        public void Bitemporal_Edit_one_temporary_one_continuous_with_end_effective_date()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate, new DateTime(2010, 6, 1));

            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = new DateTime(2010, 3, 1);

            var surnameEffective1 = Interval.FromDate(new DateTime(2010, 3, 1), new DateTime(2010, 10, 1));

            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            //Assertions

            Assert.Null(employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 5, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.Null(employee.Surname.Value(new DateTime(2010, 7, 1) ,new DateTime(2010, 2, 1)));
        }

        [Test]
        public void Bitemporal_Edit_one_temporary_two_continuous_one_with_end_effective_date()
        {
            string id = "dbf61188-4598-4264-a35e-de4970798127";

            var currentDate = new DateTime(2010, 1, 1);

            var surnameEffective = Interval.FromDate(currentDate, new DateTime(2010, 6, 1));

            var surnameTransaction = Interval.FromDate(currentDate);

            var employee = new Person() { Id = id };

            employee.Surname.Set("Hendrix", surnameEffective, surnameTransaction);

            var dateOfChange1 = new DateTime(2010, 3, 1);

            var surnameEffective1 = Interval.FromDate(new DateTime(2010, 3, 1), new DateTime(2010, 10, 1));

            var surnameTransaction1 = Interval.FromDate(dateOfChange1);

            employee.Surname.Set("Thompson", surnameEffective1, surnameTransaction1, true);

            var surnameEffective2 = Interval.FromDate(new DateTime(2010, 8, 1));

            var surnameTransaction2 = Interval.FromDate(new DateTime(2010, 8, 1));

            employee.Surname.Set("Georgiev", surnameEffective2, surnameTransaction2);

            //Assertions

            Assert.AreEqual("Georgiev", employee.Surname.CurrentValue);

            Assert.AreEqual("Hendrix", employee.Surname.Value(new DateTime(2010, 2, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 5, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 7, 1)));

            Assert.AreEqual("Thompson", employee.Surname.Value(new DateTime(2010, 9, 1)));

            Assert.Null(employee.Surname.Value(new DateTime(2010, 7, 1), new DateTime(2010, 2, 1)));

            Assert.AreEqual("Georgiev", employee.Surname.Value(new DateTime(2010, 12, 1), new DateTime(2010, 9, 1)));

            Assert.Null(employee.Surname.Value(new DateTime(2010, 12, 1), new DateTime(2010, 7, 1)));
        }
    }
}
