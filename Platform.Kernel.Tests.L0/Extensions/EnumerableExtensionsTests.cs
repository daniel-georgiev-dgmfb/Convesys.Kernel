using NUnit.Framework;
using Platform.Kernel.Extensions;
using System;

namespace Platform.Kernel.Tests.L0.Extensions
{
	[TestFixture(Category = "EnumerableExtensionsTests")]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Aggregate_argument_null_exception()
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.Aggregate(null));
        }

        [Test]
        public void Aggregate_strings_to_a_single_string()
        {
            //ARRANGE
            var expected = "1\r\n2";
            var source = new[] { "1", "2" };
            //ACT
            var result = EnumerableExtensions.Aggregate(source);
            //ASSERT
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ForEach_argument_null_exception()
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<ArgumentNullException>(() => EnumerableExtensions.ForEach<int>(null, i => { }));
        }

        [Test]
        public void ForEach_action_null_test()
        {
            //ARRANGE
            var agreggate = 0;
            var expected = 0;
            var source = new[] { 1, 2 };
            //ACT
            EnumerableExtensions.ForEach(source, null);
            //ASSERT
            Assert.AreEqual(expected, agreggate);
        }

        [Test]
        public void ForEach_test()
        {
            //ARRANGE
            var agreggate = 0;
            var expected = 3;
            var source = new[] { 1, 2 };
            //ACT
            EnumerableExtensions.ForEach(source, i => { agreggate += i; });
            //ASSERT
            Assert.AreEqual(expected, agreggate);
        }
    }
}
