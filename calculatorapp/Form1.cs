using System;
using System.Windows.Forms;

namespace calculatorapp
{
    public partial class screen1 : Form
    {
        // Store the current result of the calculation
        Double resultValue = 0;

        // Store the current operation being performed
        String opPerformed = "";

        // Flag to check if an operation button was clicked
        bool isOpPerformed = false;

        // Store the full expression to display in the label
        String expression = "";

        public screen1()
        {
            InitializeComponent();
        }

        private void screen1_Load(object sender, EventArgs e)
        {

        }

        // Event handler for number and decimal point button clicks
        private void n_click(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0") || (isOpPerformed))
            {
                textBoxResult.Clear();
            }
            isOpPerformed = false;

            Button n = (Button)sender;

            if (!textBoxResult.Text.Contains(".") || !n.Text.Equals("."))
            {
                textBoxResult.Text = textBoxResult.Text + n.Text;
            }
        }

        // Event handler for operation button clicks
        private void op_click(object sender, EventArgs e)
        {
            Button n = (Button)sender;

            // Update expression to show in the label
            expression += textBoxResult.Text + " " + n.Text + " ";

            if (resultValue != 0)
            {
                btnequal.PerformClick();
                opPerformed = n.Text;
                resultValue = Double.Parse(textBoxResult.Text);
            }
            else
            {
                resultValue = Double.Parse(textBoxResult.Text);
            }

            opPerformed = n.Text;
            label.Text = expression;
            isOpPerformed = true;
        }

        // Event handler for the CE button click (clears the current entry)
        private void btnce_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        // Event handler for the C button click (clears all)
        private void btnc_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultValue = 0;
            expression = "";
            label.Text = "";
        }

        // Event handler for the equal button click
        private void btnequal_Click(object sender, EventArgs e)
        {
            // Append the last part of the expression to the label
            expression += textBoxResult.Text;

            switch (opPerformed)
            {
                case "+":
                    textBoxResult.Text = (resultValue + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultValue - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (resultValue * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (resultValue / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }

            // Update the result value to the current result
            resultValue = Double.Parse(textBoxResult.Text);

            // Display the complete expression and result in the label
            label.Text = expression + " = " + textBoxResult.Text;

            // Reset the expression and operation performed
            expression = "";
            opPerformed = "";
        }
    }
}
