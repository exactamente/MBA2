using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA2.Model
{
	public enum valueType { BOOL, INT8, UINT8, INT16, UINT16, INT32, UINT32, FLOAT32, FLOAT64, BINARY, HEX };
	public enum function { Coil = 0x01, DiscreteInput = 0x02, Holding = 0x03, Input = 0x04 };
	public enum quality { Unknown, Bad, Good };


	class Value
	{
		public valueType type { get; set; }
		public string value { get; set; }

		public Value()
		{
			type = valueType.UINT16;
			value = "0";
		}

		public void Set(byte[] value)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in value) sb.Append(b);
			this.value = sb.ToString();
		}

		// TODO: переделать по-умному эту ерунду, отдельной либой на будущее
		public void Set(string value)
		{
			//this.value = String.Format("{0:X}", value);
			string tmp = string.Empty;
			switch (type)
			{
				case valueType.BOOL:
					tmp = value;
					break;
				case valueType.BINARY:
					tmp = String.Format("{0:X2}", Convert.ToUInt64(value, 2));
					break;
				case valueType.INT8:
					tmp = sbyte.Parse(value).ToString("X1");
					break;
				case valueType.UINT8:
					tmp = byte.Parse(value).ToString("X1");
					break;
				case valueType.INT16:
					tmp = Int16.Parse(value).ToString("X2");
					break;
				case valueType.UINT16:
					tmp = UInt16.Parse(value).ToString("X2");
					break;
				case valueType.INT32:
					tmp = Int32.Parse(value).ToString("X4");
					break;
				case valueType.UINT32:
					tmp = UInt32.Parse(value).ToString("X4");
					break;
				case valueType.FLOAT32:
					float flt = float.Parse(value);
					byte[] byteArray = BitConverter.GetBytes(flt);
					StringBuilder sb = new StringBuilder();
					for (int i = byteArray.Length; i > 0; i--)
						sb.Append(byteArray[i - 1].ToString("X4"));
					tmp = sb.ToString();
					break;
				case valueType.FLOAT64:
					double dbl = double.Parse(value);
					byte[] byteArray2 = BitConverter.GetBytes(dbl);
					StringBuilder sb2 = new StringBuilder();
					for (int i = byteArray2.Length; i > 0; i--)
						sb2.Append(byteArray2[i - 1].ToString("X4"));
					tmp = sb2.ToString();
					break;
				case valueType.HEX:
					tmp = value;
					break;
			}
			this.value = tmp;


		}

		// TODO: и эту
		public override string ToString()
		{
			string tmp = string.Empty;

			switch (type)
			{
				case valueType.BOOL:
					tmp = value;
					break;
				case valueType.BINARY:
					tmp = Convert.ToString(Convert.ToInt64(value, 16), 2);
					break;
				case valueType.INT8:
					tmp = sbyte.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.UINT8:
					tmp = byte.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.INT16:
					tmp = Int16.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.UINT16:
					tmp = UInt16.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.INT32:
					tmp = Int32.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.UINT32:
					tmp = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber).ToString();
					break;
				case valueType.FLOAT32:
					byte[] byteArray = BitConverter.GetBytes(Int32.Parse(value, System.Globalization.NumberStyles.HexNumber));
					tmp = BitConverter.ToSingle(byteArray, 0).ToString();
					break;
				case valueType.FLOAT64:
					byte[] byteArray2 = BitConverter.GetBytes(Int64.Parse(value, System.Globalization.NumberStyles.HexNumber));
					tmp = BitConverter.ToDouble(byteArray2, 0).ToString();
					break;
				case valueType.HEX:
					tmp = value;
					break;
			}
			return tmp;
		}
	}
}
