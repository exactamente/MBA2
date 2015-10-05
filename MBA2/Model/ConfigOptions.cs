//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO.Ports;
//using MBA2.Model;

//namespace MBA2.Model
//{
//	public static class BaudRates
//	{
//		private static List<int> _baudRates;

//		static BaudRates()
//		{
//			_baudRates = new List<int>(2);
//			_baudRates.Add(9600);
//			_baudRates.Add(19200);
//			_baudRates.Add(38400);
//		}

//		public static IList<int> GetAll()
//		{
//			return _baudRates;
//		}
//	}

//	public static class Parities
//	{
//		private static List<Parity> _parities;

//		static Parities()
//		{
//			_parities = new List<Parity>();
//			foreach (Parity s in Enum.GetValues(typeof(Parity)))
//			{
//				_parities.Add(s);
//			}
//		}

//		public static IList<Parity> GetAll()
//		{
//			return _parities;
//		}
//	}

//	public static class DataBits
//	{

//		private static List<int> _dataBits;

//		static DataBits()
//		{
//			_dataBits = new List<int>();
//			_dataBits.Add(7);
//			_dataBits.Add(8);
//		}

//		public static IList<int> GetAll()
//		{
//			return _dataBits;
//		}
//	}

//	public static class StopBits
//	{
//		private static List<System.IO.Ports.StopBits> _stopBits;

//		static StopBits()
//		{
//			_stopBits = new List<System.IO.Ports.StopBits>();
//			foreach (System.IO.Ports.StopBits s in Enum.GetValues(typeof(System.IO.Ports.StopBits)))
//			{
//				_stopBits.Add(s);
//			}
//		}
//		public static IList<System.IO.Ports.StopBits> GetAll()
//		{
//			return _stopBits;
//		}
//	}

//	public static class Timeouts
//	{
//		private static List<int> _timeouts;

//		static Timeouts()
//		{
//			_timeouts = new List<int>();
//			_timeouts.Add(100);
//			_timeouts.Add(500);
//			_timeouts.Add(1000);
//			_timeouts.Add(2000);
//			_timeouts.Add(5000);
//		}

//		public static IList<int> GetAll()
//		{
//			return _timeouts;
//		}
//	}
//}
