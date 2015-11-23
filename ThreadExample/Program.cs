using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var exThread = new Thread(new ParameterizedThreadStart(DoWork));
			exThread.Start(5);
			//exThread.IsBackground = true;

			Console.WriteLine("I'm alive");
			Console.ReadLine();
		}

		public static void DoWork(object input)
		{
			int i = (int)input;
			Thread.Sleep(i*1000);
			Console.WriteLine("I'm done");
		}
	}
}
