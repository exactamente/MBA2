using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[] value;
			UInt64 val = 9223372036854775808; // 9223372036854775807
			Console.WriteLine(ToInt64(val));
			Console.ReadLine();
		}

		private static unsafe Int64 ToInt64(UInt64 v)
		{
			Int64 res = *(Int64*)&v;
			return res;
		}
	}
}
