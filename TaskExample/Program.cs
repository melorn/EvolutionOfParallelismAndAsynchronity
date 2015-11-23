using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Write something:");
			string input = Console.ReadLine();
			var task = Task.Run(() =>
			{
				StringBuilder sb = new StringBuilder();
				foreach (var item in input)
				{
					sb.Append(((char)(((int)item * DateTime.UtcNow.Millisecond) % 255)).ToString());
					Thread.Sleep(1000);
				}

				return sb.ToString();
			}).ContinueWith((result)=> {
				Console.WriteLine(result);
			});

			Console.WriteLine("And the output is:");
			Console.ReadLine();
		}
	}
}
