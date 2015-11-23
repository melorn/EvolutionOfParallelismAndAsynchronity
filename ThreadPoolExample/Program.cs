using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolExample
{
	class Program
	{
		static void Main(string[] args)
		{
			ThreadPool.QueueUserWorkItem(DoWork, 5);
			//HillClimbBagic();

			Console.WriteLine("I'm pool alive");
			Console.ReadLine();
		}
		public static void DoWork(object input)
		{
			int i = (int)input;
			Thread.Sleep(i * 1000);
			Console.WriteLine("I'm done");
		}

		#region HillClimb magic
		
		public static void HillClimbBagic()
		{
			for (int i = 0; i < 10000; i++)
			{
				ThreadPool.QueueUserWorkItem(DoWork, 5);
			}

			var counter = new Thread(new ThreadStart(NumThreadCount));
			counter.IsBackground = true;
			counter.Start();
		}

		public static void NumThreadCount()
		{
			int threadCount = Process.GetCurrentProcess().Threads.Count;

			while (true)
			{
				Thread.Sleep(10);
				int ct = Process.GetCurrentProcess().Threads.Count;
				if (ct != threadCount)
				{
					Console.WriteLine(ct);
					threadCount = ct;
				}
			}
		}

		#endregion
	}
}
