using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Calculator : Form
    {
        private string currentCalculation = "";
        public Calculator()
        {
            InitializeComponent();
        }
        private void btnClick(object sender, EventArgs e)
        {
            // This adds the number or operator to the string calculation
            currentCalculation += (sender as Button).Text;

            // Display the current calculation back to the user
            textBoxOut.Text = currentCalculation;
        }
        private void btnEqualsClick(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("X", "*").ToString().Replace("&divide;", "/");

            try
            {
                textBoxOut.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = textBoxOut.Text;
            }
            catch (Exception ex)
            {
                textBoxOut.Text = "0";
                currentCalculation = "";
            }
        }
        private void btnClearClick(object sender, EventArgs e)
        {
            // Reset the calculation and empty the textbox
            textBoxOut.Text = "0";
            currentCalculation = "";
        }
    }

}
