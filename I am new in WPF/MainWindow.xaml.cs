using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using Handy_Extensions;

namespace I_am_new_in_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        string operation = ""; // Знак операции
        string leftop = "";    // Левый операнд
        string rightop = "";   // Правый операнд
        
        public MainWindow()
        {
            InitializeComponent();
            foreach (var c in LayoutRoot.Children)
            {
                if (c is Button b)
                    b.Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs unused)
        {
            // Get Button text
            var s = sender.Cast<Button>().Content as string;
            if (s is ".")
            {
                return;
            }

            // Add it to text field
            if (EditBlock.Text is "0")
            {
                EditBlock.Text = s;
            }
            else
            {
                EditBlock.Text += s;
            }
            
            // try to parse text as number

            if (int.TryParse(s, out var num) is true)
            {
                if (operation is "")
                {
                    // Add to the left operand
                    leftop += s;
                    return;
                }
                // else add to the right operand
                rightop += s;
            }
            else // if input is not a number
            {
                if (s is "=")
                {
                    double result = CalculateResult();
                    leftop = result.ToString(CultureInfo.CurrentCulture);
                    rightop = "";
                    operation = "";
                    EditBlock.Text = leftop;
                }

                else
                {

                    operation = s;
                    switch (s) 
                    {
                        case "CLEAR":
                            leftop = rightop = operation = EditBlock.Text = "";
                            break;
                        case "BkSp":
                            operation = "";
                            if (EditBlock.Text is "")
                                return;
                                
                            EditBlock.Text = EditBlock.Text.Substring(0, EditBlock.Text.Length - 1);
                    
                            if (rightop != "")
                            {
                                rightop = rightop.Substring(0, rightop.Length - 1);
                                return;
                            }

                            if (operation != "")
                            {
                                operation = "";
                                return;
                            }

                            if (leftop != "")
                            {
                                leftop = leftop.Substring(0, leftop.Length - 1);
                            }

                            break;
                    }
                }

                
            }

        }

        private double CalculateResult()
        {
            var op = operation;
            double result = 0;
            var left = leftop is "" ? 0 :double.Parse(leftop);
            var right = rightop is "" ? 0 : double.Parse(rightop);
            switch (op)
            {
                case "+": result = left + right;
                    break;
                case "-": result = left - right;
                    break;
                case "*": result = left * right;
                    break;
                case "/": result = left / right;
                    break;
                
            }
            

            return result;
        }
    }
}