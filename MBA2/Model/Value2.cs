using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA2.Model
{

	//public enum valueType { BOOL, INT8, UINT8, INT16, UINT16, INT32, UINT32, FLOAT32, FLOAT64, BINARY, HEX };
	//public enum function { Coil = 0x01, DiscreteInput = 0x02, Holding = 0x03, Input = 0x04 };
	//public enum quality { Unknown, Bad, Good };

	class Value2
	{
		public valueType type { get; set; }
		public UInt64 value { get; set; }

		public Value2()
		{
			type = valueType.UINT16;
			value = 0;
		}





		//private unsafe 
	}
}
