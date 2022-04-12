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

namespace wpf_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Calculate cal = new Calculate();

        private double _product;

        public double product
        {
            get { return _product; }
            set { _product = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            buttonsbox.IsEnabled = false;
            displayTextbox.IsEnabled = false;
        }


        public void moneyinput(object sender, EventArgs e)
        {

            try
            {

                if (
                     mi1 != null &&
                     mi2 != null &&
                     mi3 != null &&
                     mi4 != null &&
                     mi5 != null &&
                     mi6 != null &&
                     mi7 != null &&
                     mi8 != null &&
                     mi9 != null &&
                     mi10 != null &&
                     tbresult != null &&
                     tbresultklant != null &&
                     tbresultproduct != null
                     )
                {
                    double klantbedrag = 0.00;
                    double totaalbedrag = 0.00;

                    klantbedrag += int.Parse(mi1.Text) * 0.05;
                    klantbedrag += int.Parse(mi2.Text) * 0.10;
                    klantbedrag += int.Parse(mi3.Text) * 0.50;
                    klantbedrag += int.Parse(mi4.Text) * 1.00;
                    klantbedrag += int.Parse(mi5.Text) * 2.00;
                    klantbedrag += int.Parse(mi6.Text) * 5.00;
                    klantbedrag += int.Parse(mi7.Text) * 10.00;
                    klantbedrag += int.Parse(mi8.Text) * 50.00;
                    klantbedrag += int.Parse(mi9.Text) * 100.00;
                    klantbedrag += int.Parse(mi10.Text) * 200.00;

                    totaalbedrag += int.Parse(tbresultklant.Text) - int.Parse(tbresultproduct.Text);


                    tbresult.Text = klantbedrag.ToString();
                    tbresultklant.Text = klantbedrag.ToString();
                }

            }

            catch
            {

            }



        }

        private void combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex != 0)
            {
                ComboBox2.SelectedIndex = 0;
                ComboBox3.SelectedIndex = 0;

                switch (ComboBox1.SelectedIndex)
                {
                    case 0:
                        product = 20.00;
                        break;
                    case 1:
                        product = 35.00;
                        break;
                    case 2:
                        product = 30.00;
                        break;
                    case 3:
                        product = 30.00;
                        break;
                    case 4:
                        product = 15.00;
                        break;
                    case 5:
                        product = 45.00;
                        break;
                    case 6:
                        product = 12.50;
                        break;
                    case 7:
                        product = 15.00;
                        break;
                    case 8:
                        product = 15.00;
                        break;
                    case 9:
                        product = 12.50;
                        break;
                    case 10:
                        product = 10.00;
                        break;
                    case 11:
                        product = 15.00;
                        break;

                }
            }
        }

        private void combobox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox2.SelectedIndex != 0)
            {
                ComboBox1.SelectedIndex = 0;
                ComboBox3.SelectedIndex = 0;

                switch (ComboBox2.SelectedIndex)
                {
                    case 0:
                        product = 5.00;
                        break;
                    case 1:
                        product = 10.00;
                        break;
                    case 2:
                        product = 5.00;
                        break;
                    case 3:
                        product = 2.50;
                        break;
                }
            }
        }

        private void combobox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox3.SelectedIndex != 0)
            {
                ComboBox1.SelectedIndex = 0;
                ComboBox2.SelectedIndex = 0;

                switch (ComboBox3.SelectedIndex)
                {
                    case 0:
                        product = 15.00;
                        break;
                    case 1:
                        product = 10.00;
                        break;
                    case 2:
                        product = 12.50;
                        break;
                    case 3:
                        product = 20.00;
                        break;
                }
            }
        }

        private void dageninput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void progressbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void NumOpButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            displayTextbox.Text += button.Content.ToString();
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculate();
            }
            catch (Exception)
            {
                displayTextbox.Text = "Error! Try again.";
            }
        }

        private void FuncButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == onButton)
            {
                displayTextbox.Text = "";
                buttonsbox.IsEnabled = true;
                displayTextbox.IsEnabled = true;
            }
            else if (sender == offButton)
            {
                displayTextbox.Text = "Off";
                buttonsbox.IsEnabled = false;
                displayTextbox.IsEnabled = false;
            }
            else if (sender == clearButton)
            {
                displayTextbox.Text = "";
            }
        }

        private void Calculate()
        {
            int opPos = 0;
            double value1 = 0;
            double value2 = 0;
            double result = 0;
            string op = "";

            if (displayTextbox.Text.Contains("*"))
            {
                opPos = displayTextbox.Text.IndexOf("*");
            }
            else if (displayTextbox.Text.Contains("/"))
            {
                opPos = displayTextbox.Text.IndexOf("/");
            }
            else if (displayTextbox.Text.Contains("+"))
            {
                opPos = displayTextbox.Text.IndexOf("+");
            }
            else if (displayTextbox.Text.Contains("-"))
            {
                opPos = displayTextbox.Text.IndexOf("-");
            }

            value1 = Double.Parse(displayTextbox.Text.Substring(0, opPos));
            op = displayTextbox.Text.Substring(opPos, 1);
            value2 = Double.Parse(displayTextbox.Text.Substring(opPos + 1, displayTextbox.Text.Length - opPos - 1));

            if (op == "*")
            {
                result = cal.multiply(value1, value2);
                displayTextbox.Text += "= " + result.ToString();
            }
            else if (op == "/")
            {
                if (value2 == 0)
                {
                    displayTextbox.Text = "Cannot divide by zero!";
                }
                else
                {
                    result = cal.divide(value1, value2);
                    displayTextbox.Text += "= " + result.ToString();
                }
            }
            else if (op == "+")
            {
                result = cal.add(value1, value2);
                displayTextbox.Text += "= " + result.ToString();
            }
            else if (op == "-")
            {
                result = cal.subtract(value1, value2);
                displayTextbox.Text += "= " + result.ToString();
            }
        }
    }
}
