
/*
 Class: Form1.cs
 Author: Mitwa Patel, Student ID: 000905034
 Date: September 13, 2023
 Purpose: This class represents the main form of a calculator that calculates the 
 total cost of a hairdressing salon (Perfect Cut Hair Salon)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2B
{
    public partial class Form1 : Form
    {
        private double baseRateJane = 30.0;
        private double baseRatePat = 45.0;
        private double baseRateRon = 40.0;
        private double baseRateSue = 50.0;
        private double baseRateLaura = 55.0;

        private double rateCut = 30.0;
        private double rateColour = 40.0;
        private double rateHighlights = 50.0;
        private double rateExtensions = 200.0;

        /// <summary>
        /// constructor for Form1 class that creates new instance of this class
        /// </summary>
        public Form1()
        { InitializeComponent(); }

        /// <summary>
        /// this method handles the total price selected by the user upon clicking the calculate button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            totalPricetextBox.Text = string.Empty;

            if (radioButtonJane.Checked ||  radioButtonPat.Checked || radioButtonRon.Checked || radioButtonSue.Checked || radioButtonLaura.Checked)
            {
                double hairDresserRate = 0; //inititate with 0 to avoid null exeception
                if (radioButtonJane.Checked) { hairDresserRate = baseRateJane; }
                else if (radioButtonPat.Checked) { hairDresserRate = baseRatePat; }
                else if (radioButtonRon.Checked) { hairDresserRate = baseRateRon; }
                else if (radioButtonSue.Checked) { hairDresserRate = baseRateSue; }
                else if (radioButtonLaura.Checked) { hairDresserRate = baseRateLaura; }  

                double totalPrice = hairDresserRate;
                if (checkBoxCut.Checked) { totalPrice += rateCut; }
                if (checkBoxColour.Checked) { totalPrice += rateColour;}
                if (checkBoxHighlights.Checked) { totalPrice += rateHighlights; }
                if (checkBoxExtensions.Checked) { totalPrice += rateExtensions; }

                double discountRate = 0; //inititate with 0 to avoid null exeception
                if (radioButtonChild.Checked) { discountRate = 0.10; }
                else if (radioButtonStudent.Checked) { discountRate = 0.05; }
                else if (radioButtonSenior.Checked) { discountRate = 0.15; }

                int numClientsVisits = 0; //inititate with 0 to avoid null exeception
                try
                {
                    numClientsVisits = int.Parse(textBoxClientsVisits.Text);
 
                    if (numClientsVisits >= 4 && numClientsVisits <= 8) { discountRate += 0.05; }
                    if (numClientsVisits >= 9 && numClientsVisits <= 13) { discountRate += 0.1; }
                    if (numClientsVisits >= 14) { totalPrice *= 0.85; }
                    totalPrice = totalPrice - (totalPrice * discountRate);
                }
                catch (FormatException) { MessageBox.Show("Error"); }

                totalPricetextBox.Text = totalPrice.ToString("0.00");
            }
            else { MessageBox.Show("Error"); }

            buttonCalculate.Focus();
        }

        /// <summary>
        /// this method handles the clear button and resets the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            radioButtonJane.Checked = true;
            checkBoxCut.Checked = false;
            checkBoxHighlights.Checked = false;
            checkBoxExtensions.Checked = false;
            checkBoxColour.Checked = false;
            radioButtonAdult.Checked = true;
            textBoxClientsVisits.Clear();
            textBoxClientsVisits.Text = string.Empty;
            totalPricetextBox.Text = string.Empty;     
        }
        
        /// <summary>
        /// this method handles the exit button by closing the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        { Close(); }
    }
}
