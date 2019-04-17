using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IICodingExercise
{
    class Program
    {
        static List<Account> BankAccounts = new List<Account>();
        static string BankName = "United Trust Bank";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to {0}, The program is now running, please press any key to exit!", BankName);
            TestData();
            Console.WriteLine("Program is finished running, press any key to exit");
            Console.ReadKey();
        }

        public static void TestData()
        {
            Account Austin = new Account("Austin Rukes", InvType.Checking, 1500.00);
            BankAccounts.Add(Austin);
            Account Dameon = new Account("Dameon", InvType.IndividualInvestment, 2000.00);
            BankAccounts.Add(Dameon);

            //tests empty values for owners
            Account EmptyOwnerTest = new Account("", InvType.IndividualInvestment, 1500.00);
            BankAccounts.Add(EmptyOwnerTest);

            //tests condition of withdrawing more than 1000 from individual investment accounts
            Dameon.Withraw(1001.00);

            //tests overdraft blocking capabilities
            Austin.Withraw(1600.00);

            //tests transfer functionality
            Dameon.Transfer(Austin, 1000);
        }
    }
}
