using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormEvents
{
    public partial class bankAccntWindow : Form
    {
        public bankAccntWindow()
        {
            InitializeComponent();
        }
   // Make the accounts.
        private void Form1_Load(object sender, EventArgs e)
        {
            OverDraftAccount TheAccount = new OverDraftAccount();
            TheAccount.savingsAccount = new BankAccount();
            TheAccount.Balance = 50m;
            TheAccount.savingsAccount.Balance = 50m;
            DisplayBalances();

            // Subscribe to the accounts' Overdrawn events.
            TheAccount.Overdrawn += new OverdrawnEventArgs(TheAccount.Balance,Decimal.Parse(overDraftAmountValue.Text));
            TheAccount.savingsAccount.Overdrawn += new OverdrawnEventArgs(TheAccount.savingsAccount.Balance,Decimal.Parse(savAmountValue.Text));;
        }

        // The event handler with event args.
        private void ______________________(object sender, OverdrawnEventArgs args)
        {
            // Get the overdraft account.
            OverDraftAccount account = sender as OverDraftAccount;
            string message =
                "The account is overdrawn." + Environment.NewLine +
                "Current Balance: " + account.Balance.ToString("C") + Environment.NewLine +
                "Savings Balance: " + account.savingsAccount.Balance.ToString("C") + Environment.NewLine +
                "Debit Amount: " + args.Amount.ToString("C");
            MessageBox.Show(message);
        }

        // The event handler with event args.
        private void SavingsOverdrawnHandler(object sender, OverdrawnEventArgs args)
        {
            string message =
                "The savings account is overdrawn." + Environment.NewLine +
                "Current Balance: " + args.CurrentBalance.ToString("C") + Environment.NewLine +
                "Debit Amount: " + args.Amount.ToString("C");
            MessageBox.Show(message);
        }

        // Add money to the account.
        private void overdraftCreditButton_Click(object sender, EventArgs e)
        {
            TheAccount.__________________(decimal.Parse(overdraftAmountTextBox.Text, NumberStyles.Currency));

            // Display the account balance.
            DisplayBalances();
        }

        // Remove money from the account.
        private void overdraftDebitButton_Click(object sender, EventArgs e)
        {
            TheAccount._________________(decimal.Parse(overdraftAmountTextBox.Text, NumberStyles.Currency));

            // Display the account balance.
            DisplayBalances();
        }

        // Add money to the savings account.
        private void savingsCreditButton_Click(object sender, EventArgs e)
        {
            TheAccount.____________________.__________(
                decimal.Parse(savingsAmountTextBox.Text,
                NumberStyles.Currency));

            // Display the account balance.
            DisplayBalances();
        }

        // Remove money from the savings account.
        private void savingsDebitButton_Click(object sender, EventArgs e)
        {
            TheAccount.___________________.____________(decimal.Parse(
                savingsAmountTextBox.Text,
                NumberStyles.Currency));

            // Display the account balance.
            DisplayBalances();
        }

        // Display the account balances.
        private void DisplayBalances()
        {
            ______________________________.Text = ____________________t.Balance.ToString("C");
            savingsBalanceTextBox.Text = TheAccount._________________.Balance.ToString("C");
        }
    }