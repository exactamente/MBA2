using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MBA2.Model;

namespace MBA2.Model
{
	public class SystemPort : IEquatable<SystemPort>, INotifyPropertyChanged//, IComparer<SysPort>, IComparable<SysPort>
	{
		private string _name;
		private bool _isEnabled;

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


		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				_isEnabled = value;
				OnPropertyChanged("IsEnabled");
			}
		}
		public bool IsSelected { get; set; }

		public SystemPort()
		{
			Name = "";
			IsEnabled = false;
			IsSelected = false;
		}

		public SystemPort(string name)
		{
			Name = name;
			IsEnabled = true;
		}

		public SystemPort(int i)
		{
			Name = "COM" + i;
			IsEnabled = false;
		}

		public override string ToString()
		{
			return Name;
		}

		public bool Equals(SystemPort sp)
		{
			//SysPort sp = obj as SysPort;
			return (sp.Name == this.Name);
		}


		//public int Compare(SysPort x, SysPort y)
		//{
		//	string xN = x.Name;
		//	string yN = y.Name;
		//	int i = int.Parse(xN.Substring(4)); // Parse the numeric value which starts at 5th character
		//	int j = int.Parse(yN.Substring(4));

		//	return i.CompareTo(j);
		//}

		//public int CompareTo(SysPort sp)
		//{
		//	int result;
		//	AlphanumComparator cmp = new AlphanumComparator();
		//	result = cmp.Compare(this, sp);
		//	return result;
		//}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}

		}
	}
}
