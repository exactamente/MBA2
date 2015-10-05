using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MBA2.Model
{


	//interface IRegister
	//{

	//	Register.valueType ValueType { get; set; }

	//	Register.function CommandFunction { get; set; }

	//	object Value { get; set; }

	//	DateTime TimeStamp { get; set; }

	//	Register.quality Quality { get; set; }
	//}

	//public enum valueType { BOOL, INT8, UINT8, INT16, UINT16, INT32, UINT32, FLOAT32, FLOAT64, BINARY, HEX };
	//public enum function { Coil = 0x01, DiscreteInput = 0x02, Holding = 0x03, Input = 0x04 };
	//public enum quality { Unknown, Bad, Good };

	//public struct RegVal
	//{
	//	public valueType Type;
	//	public Int64 Value;

	//	public RegVal(valueType Type, Int64 Value)
	//	{
	//		this.Type = Type;
	//		this.Value = Value;
	//	}

	//	public static RegVal operator +(RegVal c1, RegVal c2)
	//	{
	//		return new RegVal();
	//		//return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
	//	}
	//}


	public class Register : INotifyPropertyChanged
	{
		//public enum valueType { BOOL, INT8, UINT8, INT16, UINT16, INT32, UINT32, FLOAT32, FLOAT64, BINARY, HEX };
		//public enum function { Coil = 0x01, DiscreteInput = 0x02, Holding = 0x03, Input = 0x04 };
		//public enum quality { Unknown, Bad, Good };

		string _name;
		int _address;
		valueType _valueType;
		function _commandFunction;
		string _value;
		string _pureValue;
		DateTime _timeStamp = new DateTime();
		quality _quality;
		Value _val;

		public Register()
		{
			_name = "imma regista";
			_address = 1;
			_valueType = valueType.UINT16;
			_commandFunction = function.Holding;
			_pureValue = "0";
			_value = "0";
			_timeStamp = DateTime.Now;
			_quality = quality.Unknown;
			_val = new Value();
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		public int Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
				OnPropertyChanged("Address");
			}
		}

		public function CommandFunction
		{
			get { return _commandFunction; }
			set
			{
				this._commandFunction = value;
				if (
					(_commandFunction == function.Coil || _commandFunction == function.DiscreteInput)
					&&
					(_valueType != valueType.BOOL)
					) //(value != Register.function.Coil || value != Register.function.DiscreteInpit)
				{
					this._valueType = valueType.BOOL;
					OnPropertyChanged("ValueType");
				}
				else if (
					(_commandFunction != function.Coil || _commandFunction != function.DiscreteInput)
					&&
					(_valueType == valueType.BOOL)
					)
				{
					this._valueType = valueType.UINT8;
					OnPropertyChanged("ValueType");
				}
				OnPropertyChanged("CommandFunction");
			}
		}

		public string PureValue
		{
			get { return _val.value; }
			set
			{
				_val.value = value.ToLower();
				OnPropertyChanged("PureValue");
				OnPropertyChanged("Value");
			}
		}

		public valueType ValueType
		{
			get { return _val.type; }
			set
			{
				_val.type = value;
				if (_val.type == valueType.BOOL && (_commandFunction != function.Coil || _commandFunction != function.DiscreteInput))
				{
					_commandFunction = function.Coil;
					OnPropertyChanged("CommandFunction");
				}
				else if (_val.type != valueType.BOOL && (_commandFunction == function.Coil || _commandFunction == function.DiscreteInput))
				{
					_commandFunction = function.Input;
					OnPropertyChanged("CommandFunction");
				}
				OnPropertyChanged("ValueType");
				OnPropertyChanged("Value");
			}
		}

		public string Value
		{
			get
			{
				return _val.ToString();
			}
			set
			{
				_val.Set(value);
				//Quality = quality.Good;
				TimeStamp = DateTime.Now; // FixMe: actually should be DateTime when message was read
				OnPropertyChanged("Value");
				OnPropertyChanged("PureValue");
			}
		}

		public DateTime TimeStamp
		{
			get { return _timeStamp; }
			private set
			{
				_timeStamp = value;
				OnPropertyChanged("TimeStamp");
			}
		}

		public quality Quality
		{
			get { return _quality; }
			private set
			{
				_quality = value;
				OnPropertyChanged("Quality");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}

		}
		//private string make<T>(string val)
		//{
		//	T tmp;

		//	T.TryParse(val, out tmp);
		//	return tmp.ToString();
		//}

		private sbyte makeSint(string val)
		{
			sbyte tmp;
			sbyte.TryParse(val, out tmp).ToString();
			return tmp;
		}

		private byte makeUsint(object val)
		{
			return (byte)val;
		}

		private short makeInt(object val)
		{
			return (short)val;
		}

		private ushort makeUint(object val)
		{
			return (ushort)val;
		}

		private int makeDint(object val)
		{
			return (int)val;
		}

		private uint makeUdint(object val)
		{
			return (uint)val;
		}

		private float makeFloat(object val)
		{
			return (float)val;
		}
	}
}