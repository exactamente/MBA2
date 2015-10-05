using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace MBA2.Model
{
	class Log
	{
		enum MsgClass { PortState, IOMessage, ApplicationEvent };

		private class Message
		{
			private MsgClass msgClass; 
			private DateTime dateTime;
			
			public string MsgClass
			{
				get
				{
					return msgClass.ToString();
				}
			}

			public string Date
			{
				get	{ return dateTime.Date.ToString(); }
			}

			public string Time
			{
				get { return dateTime.TimeOfDay.ToString(); }
			}

			
		}




		private static XmlDocument appLog = new XmlDocument();
		static void notMain(string[] args)
		{
			if (File.Exists("AppLog.xml"))
				appLog.Load("AppLog.xml");
			else
			{
				var root = appLog.CreateElement("root");
				appLog.AppendChild(root);
			}
		}

		static void LogMe(DateTime datetime, string hostname, string state)
		{
			var el = (XmlElement)appLog.DocumentElement.AppendChild(appLog.CreateElement("event"));
			el.SetAttribute("date", datetime.Date.ToString());
			el.SetAttribute("time", datetime.Hour.ToString() + ":" + datetime.Minute.ToString() + ":" + datetime.Second.ToString() + "." + datetime.Millisecond.ToString());
			el.AppendChild(appLog.CreateElement("State")).InnerText = state;
			appLog.Save("AppLog.xml");
		}
	}
}
