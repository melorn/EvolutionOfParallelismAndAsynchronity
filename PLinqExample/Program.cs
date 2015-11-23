using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLinqExample
{
	class Program
	{
		static void Main(string[] args)
		{
			var baseData = Enumerable.Range(0, 1000000);


			var rSeq = from u in baseData
						 where u % 10 == 0
						 select u.ToString();

			var result = from u in baseData.AsParallel().WithDegreeOfParallelism(4)
						 where u % 10 == 0
						 select u.ToString();

			Console.WriteLine(rSeq.Take(10).Aggregate((c, n) => c + ", " + n));
			Console.WriteLine(result.Take(10).Aggregate((c, n) => c + ", " + n));
			Console.ReadLine();
		}
	}
}
