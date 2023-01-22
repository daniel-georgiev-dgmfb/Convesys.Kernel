namespace Convesys.Kernel.Reflection.Tests.L0.Extensions
{
    using System;
    using System.Threading.Tasks;
    using Convesys.Kernel.Reflection.Extensions;
    using Convesys.Kernel.Reflection.Tests.L0.MockData;
    using NUnit.Framework;

    [TestFixture, Category("ReflectionTypeExtensions")]
	public class TypeExtensionTest
	{
		[Test]
		public void GetInstanceMethodDelegate()
		{
			//Arrange
			var i = 0;
			var j = 0;
			var testClass = new MockClassForReflectionSource {Property1 = 1};

            //Act
            var method = testClass.GetType().GetInvoker("InstanceMethod2", typeof(Action));
			method(testClass, new object[] {new Action(() => i = 10)});
			method(testClass, new object[] {new Action(() => j = 100)});

			//Assert
			Assert.AreEqual(10, i);
			Assert.AreEqual(100, j);
		}

		[Test]
		public void GetInstanceAsyncMethodDelegate()
		{
			//Arrange
			var i = 0;
			var j = 0;
			var testClass = new MockClassForReflectionSource { Property1 = 1 };

			//Act
			var method = testClass.GetType().GetAsyncInvoker("AsyncMethod", typeof(Action));
			var task1 = method(testClass, new object[] { new Action(() => i = 10) });
			var task2 = method(testClass, new object[] { new Action(() => j = 100) });
			Task.WaitAll(task1, task2);
			//Assert
			Assert.AreEqual(10, i);
			Assert.AreEqual(100, j);
		}

		[Test]
		public void GetInstanceAsyncMethodDelegate_method_returning_task_int()
		{
			//Arrange
			var i = 0;
			var j = 0;
			var testClass = new MockClassForReflectionSource { Property1 = 1 };

			//Act
			var method = testClass.GetType().GetAsyncInvoker("AsyncMethod1", typeof(Action));
			var task1 = method(testClass, new object[] { new Action(() => i = 10) });
			var task2 = method(testClass, new object[] { new Action(() => j = 100) });
			Task.WaitAll(task1, task2);
			//Assert
			Assert.AreEqual(10, i);
			Assert.AreEqual(100, j);
		}

		[Test]
		public void GetInstanceMethodDelegate1()
		{
			//Arrange

			var testClass = new MockClassForReflectionSource {Property1 = 1};

			var testClass1 = new MockClassForReflectionSource {Property1 = 1};

			//Act
			var method = testClass.GetType().GetInvoker("InstanceMethod1", typeof(int), typeof(object));

			method(testClass, new object[] { 10, testClass });

			method(testClass, new object[] { 100, testClass1 });

			//Assert

			Assert.AreEqual(10, testClass.Property1);

			Assert.AreEqual(100, testClass1.Property1);
		}

		[Test]
		public void GetInstanceMethodDelegate_no_parameters()
		{
			//Arrange

			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act
			var method = testClass.GetType().GetInvoker("InstanceMethod3");

			method(testClass, new object[] {});

			//Assert

			Assert.AreEqual(-1, testClass.Property1);
		}

		[Test]
		public void GetInstanceMethodDelegate_null_type()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<ArgumentNullException>(() => TypeExtensions.GetInvoker(null, "InstanceMethod1", typeof(int), testClass.GetType()));
		}

		[Test]
		public void GetInstanceMethodDelegate_null_method_name()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<ArgumentNullException>(() => testClass.GetType().GetInvoker(null, typeof(int), testClass.GetType()));
		}

		[Test]
		public void GetInstanceMethodDelegate_empty_method_name()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<ArgumentNullException>(() => testClass.GetType().GetInvoker(string.Empty, typeof(int), testClass.GetType()));
		}

		[Test]
		public void GetInstanceMethodDelegate_no_method_found_wrong_params_number()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<MissingMethodException>(() => testClass.GetType().GetInvoker("InstanceMethod1", typeof(int), typeof(int), testClass.GetType()));
		}

		[Test]
		public void GetInstanceMethodDelegate_no_method_found_wrong_types()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<MissingMethodException>(() => testClass.GetType().GetInvoker("InstanceMethod1", typeof(bool), testClass.GetType()));
		}

		[Test]
		public void GetInstanceMethodDelegate_no_method_found_wrong_types1()
		{
			//Arrange
			var testClass = new MockClassForReflectionSource {Property1 = 1};

			//Act

			//Assert

			Assert.Throws<MissingMethodException>(() => testClass.GetType().GetInvoker("InstanceMethod1", testClass.GetType(), typeof(bool)));
		}
        
		[Test]
		public void GetInstansePropertyDelegateTest()
		{
			//Arrange
			var testType = new MockClassForReflectionSource {Property1 = 1};

			//Act
			var pDelegate = testType.GetType().GetInstancePropertyDelegate<int>("Property1");

			var value = pDelegate(testType);

			//Assert
			Assert.AreEqual(1, value);
		}

		[Test]
		public void GetStaticMethodDelegateTest()
		{
			//Arrange
			var testType = new MockClassForReflectionSource {Property1 = 1};

			//Act
			
			Assert.Throws<NotImplementedException>(() => testType.GetType().GetStaticFunctionDelegate<object, bool>("StaticMethod1"));

			//Assert
		}

		[Test]
		public void GetStaticPropertyDelegateTest()
		{
			//Arrange

			MockClassForReflectionSource.StaticProperty = 10;

			//Act
			
			var pDelegate = typeof(MockClassForReflectionSource).GetStaticPropertyDelegate<int>("StaticProperty");

			var value = pDelegate(null);

			//Assert

			Assert.AreEqual(10, value);
		}

		[Test]
		public void CreateDelegateForStaticMethodTryParseEnumTest()
		{
            //Arrange
            MockEnumSource result;
            //Act
            var del = TypeExtensions.CreateDelegateForStaticMethodTryParseEnum<MockEnumSource>(typeof(MockEnumSource));
            var success = del("Value2", out result);

            //Assert
            Assert.IsTrue(success);
            Assert.AreEqual(MockEnumSource.Value2, result);
		}
        
		[Test]
		public void New_MockModel()
		{
			// ARRANGE
			var type = typeof(MockEmptyClass);

			// ACT
			var instance = type.New<MockEmptyClass>();

			// ASSERT
			Assert.IsNotNull(instance);
		}

		[Test]
		public void New_OptionalArgument_WithoutValue()
		{
			// ARRANGE
			var type = typeof(OptionalArgument);

			// ACT
			var instance = type.New<OptionalArgument>();

			// ASSERT
			Assert.IsNotNull(instance);
			Assert.AreEqual("Test", instance.Foo);
		}

		[Test]
		public void New_OptionalArgument_WithValue()
		{
			// ARRANGE
			var type = typeof(OptionalArgument);

			// ACT
			var instance = type.New<OptionalArgument>("James");

			// ASSERT
			Assert.IsNotNull(instance);
			Assert.AreEqual("James", instance.Foo);
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