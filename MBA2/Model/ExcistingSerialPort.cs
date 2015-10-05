using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using MBA2.Model;

namespace MBA2.Model
{
	class ExcistingSerialPort
	{
		//private List<SystemPort> _winSerialPorts = new List<SystemPort>();

		//public WinSerialPorts()
		//{
		//	for (int i = 1; i < 256; i++)
		//	{
		//		SystemPort sp = new SystemPort();
		//		sp.Name = "COM" + i;
		//		_winSerialPorts.Add(sp);
		//	}

		//	foreach (string s in SerialPort.GetPortNames())
		//	{
		//		SystemPort sp = new SystemPort(s);
		//		if (true == _winSerialPorts.Contains(sp))
		//		{
		//			_winSerialPorts[_winSerialPorts.IndexOf(sp)].IsEnabled = true;
		//		}
		//	}
		//}

		public static List<SystemPort> GetPortNames()
		{
			List<SystemPort> _winSerialPorts = new List<SystemPort>();
			for (int i = 1; i < 256; i++)
			{
				SystemPort sp = new SystemPort();
				sp.Name = "COM" + i;
				_winSerialPorts.Add(sp);
			}

			foreach (string s in SerialPort.GetPortNames())
			{
				SystemPort sp = new SystemPort(s);
				if (true == _winSerialPorts.Contains(sp))
				{
					_winSerialPorts[_winSerialPorts.IndexOf(sp)].IsEnabled = true;
				}
			}
			return _winSerialPorts;
		}
	}
}
