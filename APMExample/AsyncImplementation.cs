using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APMExample
{
	public class AsyncImplementation
	{
		public IAsyncResult BeginComlpexComputation(string direction, AsyncCallback callback, object state)
		{
			Func<string, string> del = ComlpexComputation;
			var asyncState = new AsyncState(del, state);
			return del.BeginInvoke(direction, callback, asyncState);
		}

		public string EndComlpexComputation(IAsyncResult result)
		{
			var asyncState = (AsyncState)result.AsyncState;
			var del = (Func<string, string>)asyncState.Del;
			return del.EndInvoke(result);
		}

		public string ComlpexComputation(string direction)
		{
			StringBuilder sb = new StringBuilder();
			foreach(var item in direction)
			{
				sb.Append(((char)(((int)item * DateTime.UtcNow.Millisecond) % 255)).ToString());
				Thread.Sleep(1000);
			}
			return sb.ToString();
		}
	}

	public class AsyncState
	{
		public Delegate Del { get; private set; }
		public object State { get; private set; }

		public AsyncState(Delegate del, object state)
		{
			Del = del;
			State = state;
		}
	}
}
