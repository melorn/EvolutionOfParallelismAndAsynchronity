using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APMExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var bm = new AsyncImplementation();
			Console.WriteLine("Write something:");
			string input = Console.ReadLine();

			bm.BeginComlpexComputation(input, ComplexCallback, bm);
			Console.WriteLine("And the output is:");
			Console.ReadLine();
		}

		static void ComplexCallback(IAsyncResult result)
		{
			var asyncState = (AsyncState)result.AsyncState;
			string output = ((AsyncImplementation)asyncState.State).EndComlpexComputation(result);			
			Console.WriteLine(output);
		}
	}
}
