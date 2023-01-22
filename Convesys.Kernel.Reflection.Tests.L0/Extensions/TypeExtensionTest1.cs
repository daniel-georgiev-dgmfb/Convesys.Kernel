namespace Convesys.Kernel.Reflection.Tests.L0.Extensions
{
    using System;
    using Convesys.Kernel.Reflection.Extensions;
    using Convesys.Kernel.Reflection.Tests.L0.MockData;
    using NUnit.Framework;

    [TestFixture, Category("ReflectionTypeExtension")]
	public class TypeExtensionTest1
	{
		[Test]
		public void GetNestedPropertiesDelegateTest()
		{
			//Arrange
			var target = new MockType
			{
				MockNestedType = new MockNestedType
					{
						PropertyValue = 10,
						PropertyString = "Test",
						PropertyObject = new MockEmptyClass(),
						MockNestedType1 = new MockNestedType1 { PropertyString = "test1", PropertyValue = 123, PropertyObject = null }
					}
			};
			//Act

			//level 3 depth, the same type result(value => value)
			var func = TypeExtensions.GetInstancePropertyDelegate<int>(typeof(MockType), "MockNestedType.MockNestedType1.PropertyValue");

			//level 3 depth, (value => object)
			var func1 = TypeExtensions.GetInstancePropertyDelegate<object>(typeof(MockType), "MockNestedType.MockNestedType1.PropertyValue");

			var result = func(target);

			var result1 = func1(target);

			//Assert
			Assert.AreEqual(typeof(int), result.GetType());

			Assert.AreEqual(123, result);

			Assert.AreEqual(123, result1);
		}

		[Test]
		public void GetStaticPropertyDelegateTest()
		{
			//Arrange
			MockType.StaticProperty = 10;

			//Act

			//level 3 depth, the same type result(value => value)
			var func = TypeExtensions.GetStaticPropertyDelegate<int>(typeof(MockType), "StaticProperty");

			var result = func(null);


			//Assert
			Assert.AreEqual(typeof(int), result.GetType());

			Assert.AreEqual(10, result);

		}


		[Test]
		public void GetStaticPropertyDelegateTest_null_type()
		{
			//Arrange
			
			//Act

			//Assert
			Assert.Throws<ArgumentNullException>(() => TypeExtensions.GetStaticPropertyDelegate<int>(null, "StaticProperty"));
		}

		[Test]
		public void GetStaticPropertyDelegateTest_property_not_found()
		{
			//Arrange

			//Act

			//Assert
			Assert.Throws<InvalidOperationException>(() => TypeExtensions.GetStaticPropertyDelegate<int>(typeof(MockType), "StaticProperty1"));
		}

		[Test]
		public void GetNestedPropertiesDelegateTest_wrong_path_property_not_exist()
		{
			//Arrange
			var target = new MockType
			{
				MockNestedType = new MockNestedType
				{
					PropertyValue = 10,
					PropertyString = "Test",
					PropertyObject = new MockEmptyClass(),
					MockNestedType1 = new MockNestedType1 { PropertyString = "test1", PropertyValue = 123, PropertyObject = null }
				}
			};
			
			//Assert
			Assert.Throws<ArgumentException>(() => TypeExtensions.GetInstancePropertyDelegate<int>(typeof(MockType), "MockNestedType.MockNestedType1.PropertyValue1"));
		}

		[Test]
		public void GetNestedPropertiesDelegateTest_wrong_path_property_no_object()
		{
			//Arrange
			var target = new MockType
			{
				MockNestedType = new MockNestedType
				{
					PropertyValue = 10,
					PropertyString = "Test",
					PropertyObject = new MockEmptyClass(),
					MockNestedType1 = new MockNestedType1 { PropertyString = "test1", PropertyValue = 123, PropertyObject = null }
				}
			};
			
			//Assert
			Assert.Throws<ArgumentException>(() => TypeExtensions.GetInstancePropertyDelegate<int>(typeof(MockType), "MockNestedType.PropertyValue.PropertyValue"));
		}

		[Test]
		public void GetNestedPropertiesDelegateTest__null_type()
		{
			//Assert
			Assert.Throws<ArgumentNullException>(() => TypeExtensions.GetInstancePropertyDelegate<int>(null, "MockNestedType.PropertyValue.PropertyValue"));
		}

		[Test]
		public void GetNestedPropertiesDelegateTest_null_path()
		{
			//Assert
			Assert.Throws<ArgumentNullException>(() => TypeExtensions.GetInstancePropertyDelegate<int>(typeof(MockType), null));
		}

		#region assign delegate tests
		[Test]
		public void GetAssignPropertyDelegateTest()
		{
			//Arrange
			var target = new MockType
			{
				MockNestedType = new MockNestedType
				{
					PropertyValue = 10,
					PropertyString = "Test",
					PropertyObject = new MockEmptyClass(),
					MockNestedType1 = new MockNestedType1 { PropertyString = "test1", PropertyValue = 123, PropertyObject = null }
				}
			};
			//Act

			//level 3 depth, the same type result(value => value)
			var func = TypeExtensions.GetAssignPropertyDelegate(typeof(MockType), "PropertyValue");

			//level 3 depth, (value => object)
			var func1 = TypeExtensions.GetAssignPropertyDelegate(typeof(MockType), "MockNestedType.MockNestedType1.PropertyValue");

			func(target, 100);

			func1(target, 1000);

			//Assert
			
			Assert.AreEqual(100, target.PropertyValue);

			Assert.AreEqual(1000, target.MockNestedType.MockNestedType1.PropertyValue);
		}
		#endregion

		#region Try parse
		[Test]
		public void TryParseDelegateTests_primitive()
		{
			//ARRANGE
			//ACT
			var del = TypeExtensions.GetDelegateTryParse(typeof(int));
			var param = new object[] { "2", null };
			var result = del.DynamicInvoke(param);
			var value = param[1];
			//ASSERT
			Assert.AreEqual(typeof(int), value.GetType());
			Assert.True((bool)result);
		}

		[Test]
		public void TryParseDelegateTests_No_try_parse()
		{
			//ARRANGE
			//ACT
			var del = TypeExtensions.GetDelegateTryParse(typeof(string));
			
			//ASSERT
			Assert.IsNull(del);
		}
		#endregion
	}
}