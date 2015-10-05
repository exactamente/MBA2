using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;
using MBA2.Model;

namespace MBA2.Model
{
	//[Serializable]
	public class ComPortConfiguration : INotifyPropertyChanged, ICloneable
	{
		//private IList<string> packets;
		private string _name;
		private string _readBuffer;
		private Guid _id = Guid.NewGuid();
		private List<Register> _registers = new List<Register>();
		private int _updateCycle = 3000;
		bool _isOpen = false;
		bool _isRunning = false;
		
		//[NonSerialized]
		private SerialPort _serialPort = new SerialPort();

		public ObservableCollection<Device> DeviceCollection { get; set; }


		public object Clone()
		{
			ComPortConfiguration cp = new ComPortConfiguration();// { Name = string.Format("{0} (clone)", this.Name)};
			cp.Name = this.Name + " (clone)";
			cp.PortName = this.PortName;
			cp.StopBits = this.StopBits;
			cp.DataBits = this.DataBits;
			cp.Parity = this.Parity;
			cp.BaudRate = this.BaudRate;
			cp.Timeouts = this.Timeouts;
			cp.ReadBuffer = this.ReadBuffer;
			cp.DeviceCollection = this.DeviceCollection; // clone?
			return cp;
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

		public bool IsOpen
		{
			get
			{
				return _isOpen;
			}
			set
			{
				_isOpen = value;
				OnPropertyChanged("IsOpen");
			}
		}

		public string PortName
		{
			get
			{
				return _serialPort.PortName;
			}
			set
			{
				_serialPort.PortName = value;
				OnPropertyChanged("PortName");
			}
		}

		public System.IO.Ports.StopBits StopBits
		{
			get
			{
				return _serialPort.StopBits;
			}
			set
			{
				_serialPort.StopBits = value;
				OnPropertyChanged("StopBits");
			}
		}

		public int DataBits
		{
			get
			{
				return _serialPort.DataBits;
			}
			set
			{
				_serialPort.DataBits = value;
				OnPropertyChanged("DataBits");
			}
		}

		public System.IO.Ports.Parity Parity
		{
			get
			{
				return _serialPort.Parity;
			}
			set
			{
				_serialPort.Parity = value;
				OnPropertyChanged("Parity");
			}
		}

		public int BaudRate
		{
			get
			{
				return _serialPort.BaudRate;
			}
			set
			{
				_serialPort.BaudRate = value;
				OnPropertyChanged("BaudRate");
			}
		}

		public int Timeouts
		{
			get
			{
				return _serialPort.ReadTimeout;
			}
			set
			{
				_serialPort.ReadTimeout = value;
				_serialPort.WriteTimeout = value;
				OnPropertyChanged("Timeouts");
			}
		}

		//public List<Register> Registers
		//{

		//}

		public int UpdateCycle
		{
			get
			{
				return _updateCycle;
			}
			set
			{
				_updateCycle = value;
				OnPropertyChanged("UpdateCycle");
			}
		}

		//public string 
		//{
		//	get
		//	{
		//		return _serialPort;
		//	}
		//	set
		//	{
		//		_serialPort. = value;
		//	}
		//}

		public string ReadBuffer
		{
			get
			{
				return _readBuffer;
			}
			set
			{
				_readBuffer = value;
				OnPropertyChanged("ReadBuffer");
			}
		}

		public Guid Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				OnPropertyChanged("Id");
			}
		}



		public string ReadLine()
		{
			return _serialPort.ReadLine();
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

		public void OpenPort()
		{
			try
			{
				_serialPort.Open();
			}
			finally
			{
				OnPropertyChanged("IsOpen");
				_serialPort.DataReceived += OnDataReceived;
				//this.Packets +=
			}
		}

		public void ClosePort()
		{
			try
			{
				_serialPort.Close();
			}
			finally
			{
				OnPropertyChanged("IsOpen");
			}
		}

		public void SwitchState()
		{
			if (!_serialPort.IsOpen)
			{
				this.OpenPort();
			}
			else
			{
				this.ClosePort();
			}
		}

		public void Read(function function)
		{
			// OpenPort
			_registers = new List<Register>();
		}

		public void Write(function function, List<Register> registersToWrite)
		{

		}

		void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			//ComPortConfiguration pc = sender as ComPortConfiguration;
			ReadBuffer = _serialPort.ReadLine();
		}

		public ComPortConfiguration()
		{
			this.Name = "New config";
			this.PortName = "COM1";
			//_serialPort = new SerialPort();
			this.StopBits = System.IO.Ports.StopBits.Two;
			this.DataBits = 8;
			this.Parity = System.IO.Ports.Parity.Even;
			this.BaudRate = 9600;
			this.Timeouts = 1000;
			this.Id = Guid.NewGuid();
			this.DeviceCollection = new ObservableCollection<Device>() { new Device() { Name = "Device 1" }, new Device() { Name = "Device 2" } };

			//this.Packets = new List<string>();

			try
			{
				//_serialPort.Open();
				//for (int i = 0; i < 2; i++)
				//{

				//	_serialPort.Write("tsjrsb7e5bu ryu hyr9sehby9eb5y9weby9e5b9ehyb");
				//	try
				//	{
				//		_serialPort.Read(buffer, 0, _serialPort.BytesToRead);
				//		Console.WriteLine(buffer);
				//	}
				//	catch (Exception e) { Console.WriteLine(e.Message); }

				//	Console.ReadKey();
				//}
				//_serialPort.Close();

			}
			catch (System.IO.IOException wtf) { Console.WriteLine(wtf.Message); }

			//Console.ReadKey();

		}
	}
}
