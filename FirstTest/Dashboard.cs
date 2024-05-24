using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTest
{
    public partial class Dashboard : Form
    {
        List<PersonModel> people = new List<PersonModel>();
        public Dashboard()
        {
            InitializeComponent();

            RebindDropdown();
        }

        private void RebindDropdown()
        {
            people = DataAccess.GetAllPeople();
            usersDropdown.DataSource = null;
            usersDropdown.DataSource = people;
            usersDropdown.DisplayMember = "FullName";
        }

        private void AddPersonButton_Click(object sender, EventArgs e)
        {
            DataAccess.AddNewPerson(new PersonModel { FirstName = firstNameText.Text, LastName = lastNameText.Text });

            firstNameText.Text = "";
            lastNameText.Text = "";

            RebindDropdown();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            resultsText.Text = Calculator.Add((double)firstNumberValue.Value, (double)secondNumberValue.Value).ToString();
            firstNumberValue.Value = 0;
            secondNumberValue.Value = 0;
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            resultsText.Text = Calculator.Subtract((double)firstNumberValue.Value, (double)secondNumberValue.Value).ToString();
            firstNumberValue.Value = 0;
            secondNumberValue.Value = 0;
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            resultsText.Text = Calculator.Multiply((double)firstNumberValue.Value, (double)secondNumberValue.Value).ToString();
            firstNumberValue.Value = 0;
            secondNumberValue.Value = 0;
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            resultsText.Text = Calculator.Divide((double)firstNumberValue.Value, (double)secondNumberValue.Value).ToString();
            firstNumberValue.Value = 0;
            secondNumberValue.Value = 0;
        }
    }
}
