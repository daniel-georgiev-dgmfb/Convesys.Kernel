namespace Convesys.Kernel.Tests.L0.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Convesys.Kernel.Extensions;
    using Convesys.Kernel.Tests.L0.MockData;
    using NUnit.Framework;

    [TestFixture, Category("TypeExtensions")]
	public class KernelTypeExtensionTest
	{
		[Test]
		public void ToGenericTypeString()
		{
			// ARRANGE
			var list = new List<string>();
			// ACT
			var listTypeName = list.GetType().ToGenericTypeString();
			// ASSERT
			Assert.IsNotNull(listTypeName);
			Assert.AreEqual("List<String>", listTypeName);
		}

		[Test]
		public void ToGenericTypeString_null_type()
		{
			// ARRANGE

			// ACT

			// ASSERT
			Assert.Throws<ArgumentNullException>(() => TypeExtensions.ToGenericTypeString(null));
		}

        [Test]
        public void ToGenericTypeString_null()
        {
            // ARRANGE
            List<string> list = null;
            // ACT
            // ASSERT
            Assert.Throws(typeof(NullReferenceException), () => list.GetType().ToGenericTypeString());
        }

        [Test]
		public void ToGenericTypeString_notGeneric()
		{
			// ARRANGE
			var @int = 32;
			// ACT
			var listTypeName = @int.GetType().ToGenericTypeString();
			// ASSERT
			Assert.IsNotNull(listTypeName);
			Assert.AreEqual("Int32", listTypeName);
		}
        
		[Test]
		public void IsAssignableToGenericTypeTest()
		{
			//Act
			var result1 = typeof(GenericDerivedClass<>).IsAssignableToGenericType(typeof(GenericBaseClass<>));

			var result1_1 = typeof(GenericDerivedClass<>).IsAssignableToGenericType(typeof(IGenericInterface1<>));

			var result2 = typeof(GenericDerivedClass<>).IsAssignableToGenericType(typeof(IGenericInterface<>));

			var result3 = typeof(GenericDerivedClass<>).IsAssignableToGenericType(typeof(GenericDerivedClass<>));

			var result4 = typeof(GenericBaseClass<>).IsAssignableToGenericType(typeof(IGenericInterface<>));

			var result4_1 = typeof(GenericBaseClass<>).IsAssignableToGenericType(typeof(IGenericInterface1<>));

			var result5 = typeof(GenericBaseClass<>).IsAssignableToGenericType(typeof(GenericBaseClass<>));

			var result6 = typeof(IGenericInterface<>).IsAssignableToGenericType(typeof(IGenericInterface<>));

			//Assert
			Assert.True(result1);
			Assert.True(result1_1);
			Assert.True(result2);
			Assert.True(result3);
			Assert.True(result4);
			Assert.False(result4_1);
			Assert.True(result5);
			Assert.True(result6);
		}

		[Test]
		public void IsAssignableToGenericTypeTest_null_type()
		{
			Assert.Throws<ArgumentNullException>(() => TypeExtensions.IsAssignableToGenericType(null, typeof(GenericBaseClass<>)));
		}

		[Test]
		public void IsAssignableToGenericTypeTest_null_generic_type()
		{
			Assert.Throws<ArgumentNullException>(() => typeof(MockClassForReflectionSource).IsAssignableToGenericType(null));
		}

		[Test]
		public void IsAssignableToGenericTypeTest_instance()
		{
			//Arrange
			var baseClass = new GenericBaseClass<MockClassForReflectionSource>();

			var derivedClass = new GenericDerivedClass<MockEmptyClass>();

			//Act
			var result1 = derivedClass.GetType().IsAssignableToGenericType(typeof(GenericBaseClass<>));

			var result2 = derivedClass.GetType().IsAssignableToGenericType(typeof(IGenericInterface<>));

			var result2_1 = derivedClass.GetType().IsAssignableToGenericType(typeof(IGenericInterface1<>));

			var result3 = derivedClass.GetType().IsAssignableToGenericType(typeof(GenericDerivedClass<>));

			var result4 = baseClass.GetType().IsAssignableToGenericType(typeof(IGenericInterface<>));

			var result4_1 = baseClass.GetType().IsAssignableToGenericType(typeof(IGenericInterface1<>));

			var result5 = baseClass.GetType().IsAssignableToGenericType(typeof(GenericBaseClass<>));

			//Assert
			Assert.True(result1);
			Assert.True(result2);
			Assert.True(result2_1);
			Assert.True(result3);
			Assert.True(result4);
			Assert.False(result4_1);
			Assert.True(result5);
		}

		[Test]
		public void IsAssignableToGenericTypeObjectTest_instance()
		{
			//Arrange
			var baseClass = new GenericBaseClass<object>();

			//Act
			
			var result = baseClass.GetType().IsAssignableToGenericType(typeof(IGenericInterface<>).MakeGenericType(typeof(MockType)));

			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void IsAssignableToGenericTypeTest_GenericInterface()
		{
			// ARRAGE
			var t1 = typeof(IEnumerable<MockEmptyClass>);
			var t2 = typeof(IOrderedEnumerable<MockEmptyClass>);
			// ACT
			var isAssignable = t2.IsAssignableToGenericType(t1);
			// ASSERT
			Assert.IsTrue(isAssignable);
		}

		[Test]
		public void IsAssignableToGenericType_DifferentClassesSameGenericType()
		{
			// ARRAGE
			var t1 = typeof(Foo<MockEmptyClass>);
			var t2 = typeof(Bar<MockEmptyClass>);
			// ACT
			var isAssignable = t2.IsAssignableToGenericType(t1);
			// ASSERT
			Assert.IsFalse(isAssignable);
		}
        
		private class Foo<T> { }
		private class Bar<T> { }

		private class OptionalArgument
		{
			public OptionalArgument(string foo = "Test")
			{
				this.Foo = foo;
			}

			public string Foo { get; set; }
		}
	}
}