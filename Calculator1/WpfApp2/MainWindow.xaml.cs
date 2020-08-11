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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bool operation_clicked = false;
        string op;
        double first_number;
        double second_number;
        bool result_click = false;

        bool checkedConv = false;
        double convLeft;
        string firstLength = "";
        string resultLength = "";
        double convAns;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (result_click)
            {
                textBlock1.Text = "";
                textBlock2.Text = "";
                result_click = false;
            }
            if (textBlock1.Text.Contains(',') && b.Content.ToString() == ",")
            {
                MessageBox.Show("You can not put , again");
            }
            else
            {
                textBlock1.Text += b.Content.ToString();
            }


        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            if (!operation_clicked)
            {
                op = b.Content.ToString();
                first_number = Convert.ToDouble(textBlock1.Text);
                textBlock2.Text += textBlock1.Text;
                textBlock2.Text += op;
                textBlock1.Text = "";
                operation_clicked = true;

            }

        }
        private void squareRoot_Click(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(textBlock1.Text);
            double res = Math.Sqrt(a);
            textBlock1.Text = res.ToString();
            result_click = true;
        }
        private void Result_click(object sender, RoutedEventArgs e)
        {
            operation_clicked = false;
            if (doubleRadio.IsChecked == true)
            {
                try
                {
                    textBlock2.Text += textBlock1.Text;
                    second_number = Convert.ToDouble(textBlock1.Text);
                    if (op == "+")
                    {
                        textBlock2.Text += "=" + (first_number + second_number);
                        textBlock1.Text = Convert.ToString(first_number + second_number);
                    }
                    else if (op == "-")
                    {
                        textBlock2.Text += "=" + (first_number - second_number);
                        textBlock1.Text = Convert.ToString(first_number - second_number);
                    }
                    else if (op == "*")
                    {
                        textBlock2.Text += "=" + (first_number * second_number);
                        textBlock1.Text = Convert.ToString(first_number * second_number);
                    }
                    else
                    {
                        textBlock2.Text += "=" + (first_number / second_number);
                        textBlock1.Text = Convert.ToString(first_number / second_number);
                    }
                    result_click = true;
                }
                catch (Exception exc)
                {
                    textBlock1.Text = "Error!";
                }
            }
            else
            {
                try
                {
                    textBlock2.Text += textBlock1.Text;
                    second_number = Convert.ToDouble(textBlock1.Text);
                    if (op == "+")
                    {
                        textBlock2.Text += "=" + Convert.ToInt32(first_number + second_number);
                        textBlock1.Text = Convert.ToString(Convert.ToInt32(first_number + second_number));
                    }
                    else if (op == "-")
                    {
                        textBlock2.Text += "=" + Convert.ToInt32(first_number - second_number);
                        textBlock1.Text = Convert.ToString(Convert.ToInt32(first_number - second_number));
                    }
                    else if (op == "*")
                    {
                        textBlock2.Text += "=" + Convert.ToInt32(first_number * second_number);
                        textBlock1.Text = Convert.ToString(Convert.ToInt32(first_number * second_number));
                    }
                    else
                    {
                        textBlock2.Text += "=" + Convert.ToInt32(first_number / second_number);
                        textBlock1.Text = Convert.ToString(Convert.ToInt32(first_number / second_number));
                    }
                    result_click = true;
                }
                catch (Exception exc)
                {
                    textBlock1.Text = "Error!";
                }
            }


        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "";
            textBlock2.Text = "";
            operation_clicked = false;

        }
        private void R_Click(object sender, RoutedEventArgs e)
        {
            int length = textBlock1.Text.Length;
            textBlock1.Text = textBlock1.Text.Remove(length - 1);
        }
        private void ConvertButt_clicked(object sender, RoutedEventArgs e)
        {
            firstLength = from.SelectedValue.ToString().Substring(38);
            resultLength = to.SelectedValue.ToString().Substring(38);
            // System.Windows.MessageBox.Show(leftLen);
            bool res = Double.TryParse(fromNum.Text, out convLeft);
            if (res)
            {
                if (firstLength == "Meters")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft * 1000;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft * 100;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft / 1000;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft / 1609.34;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft * 3.28084;
                    }

                }
                else if (firstLength == "Millimeters")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft / 10;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft / 1000;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft / 1000000;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft / 160934000000;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft / 305;
                    }

                }
                else if (firstLength == "Centimeters")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft * 10;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft / 100;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft / 100000;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft / 16093400000;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft / 30;
                    }
                }
                else if (firstLength == "Kilometers")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft * 1000000;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft * 100000;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft * 1000;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft / 1.609;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft * 3281;
                    }
                }
                else if (firstLength == "Miles")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft * 1609000;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft * 160934;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft * 1609;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft * 1.609;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft * 5280;
                    }
                }
                else if (firstLength == "Feet")
                {
                    if (resultLength == "Millimeters")
                    {
                        convAns = convLeft * 305;
                    }
                    else if (resultLength == "Centimeters")
                    {
                        convAns = convLeft * 30.5;
                    }
                    else if (resultLength == "Meters")
                    {
                        convAns = convLeft / 3.281;
                    }
                    else if (resultLength == "Kilometers")
                    {
                        convAns = convLeft / 3281;
                    }
                    else if (resultLength == "Miles")
                    {
                        convAns = convLeft / 5280;
                    }
                    else if (resultLength == "Feet")
                    {
                        convAns = convLeft;
                    }
                }
                answer.Text = convAns.ToString();
                if (checkedConv) System.Windows.MessageBox.Show(answer.Text);
            }
        }



    }
}
