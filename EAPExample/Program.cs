﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPExample
{


	class Program
	{
		static void Main(string[] args)
		{
			var bm = new AsyncImplementation();
			Console.WriteLine("Write something:");
			string input = Console.ReadLine();
			bm.Compute(input);

			bm.ComputationHappened += (_, output) => Console.WriteLine(output.ComputedString);
			Console.WriteLine("And the output is:");
			Console.ReadLine();
		}
	}
}
