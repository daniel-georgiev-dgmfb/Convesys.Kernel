namespace Twilight.Kernel.Reflection.Tests.L0.MockData
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;

	public class MockClassForReflectionSource
	{
		public static int StaticProperty { get; set; }

		public int Property1 { get; set; }

		public MockClassForReflectionSource TestMethod<T>(T arg)
		{
			return new MockClassForReflectionSource {Property1 = 10};
		}

		public static bool StaticMethod1(object o)
		{
			return true;
		}

		public void InstanceMethod(object o) {}

		public void InstanceMethod1(int p1, object o)
		{
			var testClass = o as MockClassForReflectionSource;

			testClass.Property1 = p1;
		}

		public void InstanceMethod2(Action ac)
		{
			ac();
		}

		public async Task AsyncMethod(Action ac)
		{
			await Task.Run(() => Thread.Sleep(100));
			ac();
		}

		public async Task<int> AsyncMethod1(Action ac)
		{
			await Task.Run(() => Thread.Sleep(100));
			ac();
			return 0;
		}

		public void InstanceMethod3()
		{
			this.Property1 = -1;
		}
	}
}