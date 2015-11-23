using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EAPExample
{

	public class ComplexEventArgs : EventArgs
	{
		public string ComputedString { get; set; }
	}
	public class AsyncImplementation
	{

		public EventHandler<ComplexEventArgs> ComputationHappened;
		public void Compute(string direction)
		{
			ThreadPool.QueueUserWorkItem(DoComputation, direction);
		}

		public void DoComputation(object input)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var item in input.ToString())
			{
				sb.Append(((char)(((int)item * DateTime.UtcNow.Millisecond) % 255)).ToString());
				Thread.Sleep(1000);
			}

			OnResult(sb.ToString());
		}

		void OnResult(string result)
		{
			if (ComputationHappened != null)
				ComputationHappened(this, new ComplexEventArgs() { ComputedString = result });
		}
	}
}
