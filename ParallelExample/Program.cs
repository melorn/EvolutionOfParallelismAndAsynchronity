using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var baseData = Enumerable.Range(0, 1000000);
			var l = new ConcurrentStack<int>();

			//SoftRandomByParallelism
			Parallel.ForEach(baseData, (input) =>
			{
				l.Push(input);
			});

			for (int i = 0; i < 100; i++)
			{
				int ov = 0;
				if (l.TryPop(out ov))
				{
					Console.WriteLine(ov);
				}
			}

			//FindMinimumAfterComputation();

			Console.ReadLine();
		}

		#region FindMinimumAfterComputation

		public static void FindMinimumAfterComputation()
		{
			var collection = Enumerable.Range(0, 1000000).Select(t => (double)t);
			double min = double.MaxValue;
			// Make a "lock" object
			object syncObject = new object();
			Parallel.ForEach(
				collection,
				// First, we provide a local state initialization delegate.
				() => double.MaxValue,
				// Next, we supply the body, which takes the original item, loop state,
				// and local state, and returns a new local state
				(item, loopState, localState) =>
				{
				//This is the complex computation
				double value = item % 333;
					return System.Math.Min(localState, value);
				},
				// Finally, we provide an Action<TLocal>, to "merge" results together
				localState =>
				{
				// This requires locking, but it's only once per used thread
				lock (syncObject)
						min = System.Math.Min(min, localState);
				}
			);

			Console.WriteLine(min);
		}

		#endregion
	}
}
