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

namespace DashBoardUI
{
    public partial class DashBoard : Form
    {
        BindingList<string> errors = new BindingList<string>();
        public DashBoard()
        {
            InitializeComponent();
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


            // Insert into database

            MessageBox.Show("Operation Complete");
        }

       
    }
}
