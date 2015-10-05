using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO.Ports;
using MBA2.Model;
using System.Linq;

namespace MBA2.ViewModel
{
	public class ApplicationVM : INotifyPropertyChanged
	{
		//private ObservableCollection<ComPortConfiguration> _configurations;

		private string _statusText;


		public ApplicationVM()
		{
			Configurations = new ObservableCollection<ComPortConfiguration>();
			SystemPortsCollection = new ObservableCollection<SystemPort>(ExcistingSerialPort.GetPortNames());
			ParitiesCollection = new ObservableCollection<Parity>((IEnumerable<Parity>)Enum.GetValues(typeof(Parity)));
			DataBitsCollection = new ObservableCollection<int>() { 7, 8 };
			BaudRatesCollection = new ObservableCollection<int>() { 9600, 19200, 38400 };

			// do not show StopBits.None since this can't be executed and causes an exception
			StopBitsCollection = new ObservableCollection<StopBits>(
				//(IEnumerable<StopBits>)Enum.GetValues(typeof(StopBits))
				from sb in (IEnumerable<StopBits>)Enum.GetValues(typeof(StopBits)) where sb != StopBits.None select sb
				);
			TimeoutsCollection = new ObservableCollection<int>() { 100, 500, 1000, 2000, 5000 };
		}

		public ObservableCollection<SystemPort> SystemPortsCollection { get; set; }
		public ObservableCollection<Parity> ParitiesCollection { get; set; }
		public ObservableCollection<StopBits> StopBitsCollection { get; set; }
		public ObservableCollection<int> DataBitsCollection { get; set; }
		public ObservableCollection<int> BaudRatesCollection { get; set; }
		public ObservableCollection<int> TimeoutsCollection { get; set; }

		public ObservableCollection<ComPortConfiguration> Configurations { get; set; }
		//{
		//	//get { return _configurations; }
		//	//set
		//	//{
		//	//	_configurations = value;
		//	//	OnPropertyChanged("Configurations");
		//	//}
		//	get;
		//	set;
		//}

		public string StatusText
		{
			get { return _statusText; }
			set
			{
				_statusText = value;
				OnPropertyChanged("StatusText");
			}
		}

		public ComPortConfiguration NewPortConfiguration()
		{
			ComPortConfiguration cp = new ComPortConfiguration();
			Configurations.Add(cp);
			return cp;
		}

		public ComPortConfiguration ClonePortConfiguration(ComPortConfiguration cp)
		{
			if (cp != null)
			{
				ComPortConfiguration newcp = (ComPortConfiguration)cp.Clone();
				Configurations.Add(newcp);
				return newcp;
			}
			return null;
		}

		public void RemovePortConfiguration(ComPortConfiguration item)
		{
			if (Configurations.Contains(item))
			{
				Configurations.Remove(item);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}


	}


}
