using CalculatLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalculator
{
    public partial class mainForm : Form
    {
        double result = 0;
        double value = 0;
        bool operatorsIsPressed = false;
        bool subOperatorsIsPressed = false;
        bool equalOperatorIsPressed = false;
        string operation;
        public mainForm()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (equalOperatorIsPressed)
            {
                result = 0;
                value = 0;
                operatorsIsPressed = false;
                equalOperatorIsPressed = false;
                subOperatorsIsPressed = false;
                inputTextBox.Clear();
            }
            if(inputTextBox.Text == "0")
            {
                inputTextBox.Clear();
            }
            if (operatorsIsPressed)
            {
                inputTextBox.Clear();
                operatorsIsPressed = false;
                subOperatorsIsPressed = true;
            }
            inputTextBox.Text = inputTextBox.Text + button.Text;
        }

        private void CEButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "0";
            resultBox.Clear();
            result = 0;
            value = 0;
            operatorsIsPressed = false;
            subOperatorsIsPressed = false;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = "0";
        }

        private void dellButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = inputTextBox.Text.Remove(inputTextBox.Text.Length - 1);
            if(inputTextBox.Text == "")
            {
                inputTextBox.Text = "0";
            }
        }

        private void reversButton_Click(object sender, EventArgs e)
        {
            if(inputTextBox.Text[0] == '-')
            {
                inputTextBox.Text = inputTextBox.Text.Remove(0, 1);
            }
            else
            {
                inputTextBox.Text = "-" + inputTextBox.Text;
            }
        }
        private void Operators_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resultBox.Text += inputTextBox.Text+" "+button.Text+" ";

            if (value == 0)
            {
                value = Convert.ToDouble(inputTextBox.Text);
            }
            if (!operatorsIsPressed && subOperatorsIsPressed)
            {
                switch (operation)
                {
                    case "+":
                        result = Calculate.Sum(value, Convert.ToDouble(inputTextBox.Text));
                        value = result;
                        break;
                    case "-":
                        result = Calculate.Substract(value, Convert.ToDouble(inputTextBox.Text));
                        value = result;
                        break;
                    case "*":
                        result = Calculate.Multiply(value, Convert.ToDouble(inputTextBox.Text));
                        value = result;
                        break;
                    case "÷":
                        result = Calculate.Divide(value, Convert.ToDouble(inputTextBox.Text));
                        value = result;
                        break;
                }
                inputTextBox.Text = result.ToString();

            }
            else
            {
                try
                {
                    resultBox.Text = resultBox.Text.Remove(resultBox.Text.Length - 6);
                    resultBox.Text += button.Text + " ";
                }
                catch
                {
                }
            }
            operation = button.Text;
            operatorsIsPressed = true;
            subOperatorsIsPressed = false;
        }

        private void equallyButton_Click(object sender, EventArgs e)
        {
            resultBox.Clear();
            switch (operation)
            {
                case "+":
                    result = Calculate.Sum(value, Convert.ToDouble(inputTextBox.Text));
                    inputTextBox.Text = result.ToString();
                    break;
                case "-":
                    result = Calculate.Substract(value, Convert.ToDouble(inputTextBox.Text));
                    inputTextBox.Text = result.ToString();
                    break;
                case "*":
                    result = Calculate.Multiply(value, Convert.ToDouble(inputTextBox.Text));
                    inputTextBox.Text = result.ToString();
                    break;
                case "÷":
                    result = Calculate.Divide(value, Convert.ToDouble(inputTextBox.Text));
                    inputTextBox.Text = result.ToString();
                    break;
            }
            resultBox.Clear();
            result = 0;
            value = 0;
            operatorsIsPressed = false;
            equalOperatorIsPressed = true;
            subOperatorsIsPressed = false;
        }
    }
}
