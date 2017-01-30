// Programmer:  Yogesh Patel
// Student #:   200334362
// Course:      COMP1004
// Date:        Jan 29, 2017
// Title:       Sharp Mail Order - SALES BONUS
// Description: A program to calculate what amount of bonus employee will earn  
//              based on sales in store and amount of hours worked during bonus period                


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP1004_Assignment1
{
    public partial class MailOrder : Form
    {
        public static PrintAction PrintAction { get; private set; }

        public MailOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event for check valid range for entered hours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoursWorkedTextBox_TextChanged(object sender, EventArgs e)
        {
            bool valid = true;

         
            try
            {
                //convert value to number
                float EnteredHours = Convert.ToSingle(HoursWorkedTextBox.Text);

                // If condition check entered umber is valid or not
                if (EnteredHours > 160 || EnteredHours < 0)
                {
                    valid = false;
                }
            }

            catch
            {
                valid = false;
            }

            if (valid)
            {
                // Input is valid so allow calculate button to be used
                CalculateButton.Enabled = true;
                HoursWorkedLabel.Text = "Hours Worked";
            }

            else
            {
                // Invalid input so disable calculate button and display error message
                CalculateButton.Enabled = false;
                HoursWorkedLabel.Text = "Hours must be in range from 0 to 160";
            }


        }

        //Handler for shows in currency format
        private void TotalSalesTextBox_TextChanged(object sender, EventArgs e)
        {
            //Formate currecncy
            TotalSalesTextBox.Text = TotalSalesTextBox.Text;
            //After format, move cursor to end of content
            TotalSalesTextBox.Select(TotalSalesTextBox.Text.Length, 0);

        }


        /// <summary>
        /// Handler for EnglishButton Checked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnglishRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // when english button check set all labels and button to English
            if (EnglishRadioButton.Checked)
            {
                EmployeeNameLabel.Text = "Employee's Name";
                EmployeeIDLabel.Text = "Employee ID:";
                HoursWorkedLabel.Text = "Hours Worked:";
                TotalSalesLabel.Text = "Total Sales:";
                SalesBonusLabel.Text = "Sales Bonus:";
                LanguageGroupBox.Text = "Language";
                CalculateButton.Text = "Calculate";
                PrintButton.Text = "Print";
                NextButton.Text = "Next";
            }

            else
            {
                // If French button is checked
                EmployeeNameLabel.Text = "Nom de l'employé";
                EmployeeIDLabel.Text = "ID de l'employé:";
                HoursWorkedLabel.Text = "Heures travaillées:";
                TotalSalesLabel.Text = "Ventes totales:";
                SalesBonusLabel.Text = "Bonus des ventes:";
                LanguageGroupBox.Text = "Langue";
                CalculateButton.Text = "Calculer";
                PrintButton.Text = "Imprimer";
                NextButton.Text = "Suivant";
            }

        }

        /// <summary>
        /// Event for clicked CalculateButton control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // Get the hours and sales figures for the calculation
            float TotalSalesValue = Convert.ToSingle(TotalSalesTextBox.Text);
            float TotalHours = Convert.ToSingle(HoursWorkedTextBox.Text);

            // Perform the calculation
            float Percentage = TotalHours / 160;
            double TotalBonusAmount = 0.02 * TotalSalesValue;
            double ActualBonus = Percentage * TotalBonusAmount;

            // Format the result and insert into SalesBonusTextBox
            SalesBonusTextBox.Text = Convert.ToString(ActualBonus);
        }

        /// <summary>
        /// Handler for the click event on the NextButton control 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            // Clear all text boxes except SalesTextBox and move focus back to start of form
            EmployeeNameTextBox.Text = "";
            EmployeeIDTextBox.Text = "";
            HoursWorkedTextBox.Text = "";
            TotalSalesTextBox.Text = "";
            SalesBonusTextBox.Text = "";
            EmployeeNameTextBox.Focus();
        }

        /// <summary>
        /// Handler for the click enevt on PrintButton control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Print form to a Print Preview window
           
        }

       
    }
}
