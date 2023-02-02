using DashBoardUI.Validators;
using FluentValidation.Results;
using ModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentValidation;

namespace DashBoardUI
{
    public partial class DashBoard : Form
    {
        BindingList<string> errors = new BindingList<string>();
        public DashBoard()
        {
            InitializeComponent();
            errorlistBox.DataSource = errors;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            errors.Clear();
            if(!decimal.TryParse(balancetextBox.Text, out decimal accountBalance))
            {
                errors.Add("Account Balance : Invalid Amount");
                return;
            }
            PersonModel person = new PersonModel();
            person.FirstName = fnametextBox.Text;
            person.LastName = fnametextBox.Text;
            person.AccountBalance = accountBalance;
            person.DateOfBirth = dateTimePicker1.Value;

            //Validate my data using fluentvalidation library
            // install FluentValidation Nuget package to make use of this library

            PersonValidator validator = new PersonValidator();

            ValidationResult results = validator.Validate(person);

            if(results.IsValid == false)
            {
                foreach(ValidationFailure failure in results.Errors)
                {
                    errors.Add($"{failure.ErrorMessage}");
                }
            }

            // Insert into database

            MessageBox.Show("Operation Complete");
        }

       
    }
}
