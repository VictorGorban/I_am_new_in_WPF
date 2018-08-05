using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Handy_Extensions;
using WindowsInput;

namespace I_am_new_in_WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{

		public MainWindow()
		{
			DataContext = new MainViewModel();
			InitializeComponent();
			
		}

		private void NumberButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			var button = sender.Cast<Button>();
			var text = button.Content as string;
			var key = text[0];

			ExpressionBlock.InsertIntoCaretPosition(text, button.Foreground.ToString());
			ExpressionBlock.Focus();
		}

		private void BraceButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (true) // no complicated handlers. It just add the brace to expression.
			{
				var button = sender.Cast<Button>();
				var text = button.Content as string;

				ExpressionBlock.InsertIntoCaretPosition(text, button.Foreground.ToString());
			}
		}

		private void OperationButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (true) // handler: if last symvol in the expr is an op, then replace it, else just add to the expression.
			{
				var button = sender.Cast<Button>();
				var text = button.Content as string;

				ExpressionBlock.InsertIntoCaretPosition(text, button.Foreground.ToString());
			}
		}

		private void ClearButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			ExpressionBlock.Clear();
		}

		private void BackspaceButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			ExpressionBlock.PerformBackspace();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			DataContext.Cast<MainViewModel>().MaxSpeed = "НЕТ";
		}
	}
}