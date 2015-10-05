using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MBA2.ViewModel;
using MBA2.Model;

namespace MBA2
{
	/// <summary>
	/// Interaction logic for MainWindow2.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ApplicationVM dc;
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ApplicationVM();
			dc = (ApplicationVM)DataContext;
		}

		private void ConfigurationsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			dc.NewPortConfiguration();

		}




		private void SystemPortsList_Refresh(object sender, MouseEventArgs e)
		{

		}

		private void Button_Run_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Stop_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Button_Send_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CheckBox_Clicked(object sender, RoutedEventArgs e)
		{

		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//dc.SaveAll();
		}


		private void Button_Save_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ExecuteAbout(object sender, ExecutedRoutedEventArgs e)
		{
			//var about = new AboutWindow { Owner = this };
			var about = new Window1 { Owner = this };
			about.ShowDialog();
		}

		private void ExecuteAddPort(object sender, ExecutedRoutedEventArgs e)
		{
			ListView lv = (ListView)e.Source;
			lv.SelectedItem = dc.NewPortConfiguration();
		}

		private void ExecuteRemovePort(object sender, ExecutedRoutedEventArgs e)
		{
			ListView lv = (ListView)e.Source;
			ComPortConfiguration lvi = (ComPortConfiguration)lv.SelectedItem;
			dc.RemovePortConfiguration(lvi);
		}

		private void ExecuteClonePort(object sender, ExecutedRoutedEventArgs e)
		{
			ListView lv = (ListView)e.Source;
			ComPortConfiguration lvi = (ComPortConfiguration)lv.SelectedItem;
			lv.SelectedItem = dc.ClonePortConfiguration(lvi);
		}

		private void ExecuteRenamePort(object sender, ExecutedRoutedEventArgs e)
		{
			ListView lv = (ListView)e.Source;
			ComPortConfiguration lvi = (ComPortConfiguration)lv.SelectedItem;
			//lv.SelectedItem = dc.ClonePortConfiguration(lvi);
		}

		private void RemovePort_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			ListView lv = (ListView)this.FindName("ConfigurationsList");
			if (lv != null)
				e.CanExecute = lv.SelectedItem != null;
		}

		private void ClonePort_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			ListView lv = (ListView)this.FindName("ConfigurationsList");
			if (lv != null)
				e.CanExecute = lv.SelectedItem != null;
		}

		private void RenamePort_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			ListView lv = (ListView)this.FindName("ConfigurationsList");
			if (lv != null)
				e.CanExecute = lv.SelectedItem != null;
		}
	}
}
