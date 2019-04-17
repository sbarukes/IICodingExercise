using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IICodingExercise
{
    public enum InvType
    {
        Checking,
        CorporateInvestment,
        IndividualInvestment
    }

    public class Account
    {
        private string accountOwner;

        public Account(string owner, InvType type, double balance)
        {
            this.AccountOwner = owner;
            this.BankTypeProp = type;
            this.AccountBalance = balance;
        }

        //properties
        public string AccountOwner {
            get {
                return this.accountOwner;
            }
            set
            {
                //Check for null or empty values for the owner.
                if(!String.IsNullOrWhiteSpace(value))
                {
                    this.accountOwner = value;
                }
                else
                {
                    Console.WriteLine("Must have value for Owner");
                }
            }
        }

        public InvType BankTypeProp { get; }
        public double AccountBalance { get; set; }
        
        //methods
        public void Withraw(double amount)
        {
            if(this.BankTypeProp == InvType.IndividualInvestment && this.AccountBalance >= amount && amount <= 1000)
            {
                this.AccountBalance = this.AccountBalance - amount;
            }
            else if (this.BankTypeProp == InvType.IndividualInvestment && this.AccountBalance >= amount && amount > 1000)
            {
                Console.WriteLine("Cannot withdraw more than 1000 from Individual Investment accounts.");
            }
            else if (this.BankTypeProp != InvType.IndividualInvestment && this.AccountBalance >= amount)
            {
                this.AccountBalance = this.AccountBalance - amount;
            }
            else
            {
                Console.WriteLine("Cannot Overdraft Account");
            }
        }

        public void Deposit(double amount)
        {
            this.AccountBalance = this.AccountBalance + amount;
        }

        //Transfer has same constraints as Withdraw since it is essentially withdrawing from one account and depositing into another.
        public void Transfer(Account transferToAccount, double amount)
        {
            if (this.BankTypeProp == InvType.IndividualInvestment && this.AccountBalance >= amount && amount <= 1000)
            {
                transferToAccount.AccountBalance = transferToAccount.AccountBalance + amount;
                this.AccountBalance = this.AccountBalance - amount;
            }
            else if(this.BankTypeProp == InvType.IndividualInvestment && this.AccountBalance >= amount && amount > 1000)
            {
                Console.WriteLine("Cannot transfer more than 1000 from Individual Investment accounts.");
            }
            else if (this.BankTypeProp != InvType.IndividualInvestment && this.AccountBalance >= amount)
            {
                transferToAccount.AccountBalance = transferToAccount.AccountBalance + amount;
                this.AccountBalance = this.AccountBalance - amount;
            }
            else
            {
                Console.WriteLine("Cannot Overdraft Account");
            }
        }
    }
}
