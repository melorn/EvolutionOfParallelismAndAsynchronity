using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoAsynchronity
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Started!");

			int value = 0;
			for(int i=0; i < 10000; i++)
			{
				for (int j = 0; j < 10000; j++)
				{
					value = (int)(Math.Sin(i) * Math.Cos(j));
				}
			}

			Console.WriteLine("Waiting for input:");
			Console.ReadLine();
		}
	}
}
