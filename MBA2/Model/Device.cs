using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MBA2.Model
{
	public class Device
	{
		public bool IsEnabled { get; set; }
		public string Name { get; set; }
		public int Overhead { get; set; }
		private int _address = 1;
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

		public ObservableCollection<Register> RegisterCollection { get; set; }

		public Device()
		{
			IsEnabled = false;
			RegisterCollection = new ObservableCollection<Register>() { new Register(), new Register(), new Register(), new Register() };
		}

		public void AddRegister()
		{
			RegisterCollection.Add(new Register());
		}

		public void RemoveRegister(Register register)
		{
			if (register != null && RegisterCollection.Contains(register))
				RegisterCollection.Remove(register);
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
	}
}
