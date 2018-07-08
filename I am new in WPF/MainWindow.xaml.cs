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
            InitializeComponent();
        }

        private void NumberButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var button = sender.Cast<Button>();
            var text = button.Content as string;
            var key = text[0];
            ExpressionBlock.Focus();
            var focused = ExpressionBlock.IsFocused;
            
            //target.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromDependencyObject(this),0, (Key)key));
            var inputSimulator = new InputSimulator();
            
            
            inputSimulator.Mouse.MoveMouseBy(0,-60);
            inputSimulator.Mouse.LeftButtonClick();
            inputSimulator.Keyboard.KeyDown((WindowsInput.Native.VirtualKeyCode)key);

            focused = ExpressionBlock.IsFocused;
            /*ExpressionBlock.InsertIntoCaretPosition(text, button.Foreground.ToString());
            ExpressionBlock.Focus();*/
        }

        private void BraceButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void ClearButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ExpressionBlock.Clear();
        }

        private void BackspaceButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ExpressionBlock.PerformBackspace();
        }


    }
}