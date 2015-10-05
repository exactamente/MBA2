using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace MBA2
{
	public class CustomCmd
	{
		private static RoutedUICommand add;
		private static RoutedUICommand clone;

		static CustomCmd()
		{
			// Инициализация команды
			InputGestureCollection inputs = new InputGestureCollection();
			inputs.Add(new KeyGesture(Key.N, ModifierKeys.Control, "Ctrl + Shift + N"));
			add = new RoutedUICommand("Add", "Add", typeof(CustomCmd), inputs);
		}

		public static RoutedUICommand Add
		{
			get { return add; }
		}
	}
}
