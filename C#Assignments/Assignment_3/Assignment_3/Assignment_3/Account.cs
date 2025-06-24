using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
   
    class Accounts
    {
        public static int Accountno;
        public static string Customername;
        public static string Accounttype;
        public static double amount;
        public static double balance;
        public static char Transactiontype;

        public Accounts(int AccountNo, string CustomerName, string AccountType, double Amount, double Balance, char transtype)
        {
            Accountno = AccountNo;
            Customername = CustomerName;
            Accounttype = AccountType;
            amount = Amount;
            balance = Balance;
            Transactiontype = transtype;

            if (transtype == 'D')
            {
                Credit(Amount);
            }
            else if (transtype == 'W')
            {
                Debit(Amount);
            }
            else
            {
                Console.WriteLine("Invalid Type");
            }
        }
        public static void Credit(double Amount)
        {
            balance += Amount;
            Console.WriteLine("Amount Creditted to Account");
            Console.WriteLine($"Current Balance:{balance}");
            Console.WriteLine("");

        }

        public static void Debit(double Amount)
        {
            if (Amount <= balance)
            {
                balance -= Amount;
                Console.WriteLine("Amount Debitted from Account");
                Console.WriteLine($"Current Balance:{balance}");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
                Console.WriteLine("");

            }
        }

        public void ShowData()
        {
            Console.WriteLine("AccountNo: " + Accountno);
            Console.WriteLine("CustomerName: " + Customername);
            Console.WriteLine("AccountType: " + Accounttype);
            Console.WriteLine("TransactionType: " + Transactiontype);
            Console.WriteLine("TransactionAmount: " + amount);
            Console.WriteLine("Updated Balance:" + balance);
        }


        public static void Main(string[] args)
        {
  
            Console.WriteLine("Enter Account No:");
            int accno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer Name:");
            string custname = Console.ReadLine();
            Console.WriteLine("Enter Account Type:");
            string acctype = Console.ReadLine();
            Console.WriteLine("Enter Transaction Type:(Debit(D/d) or Withdrawal(W/w)");
            char TransType = Convert.ToChar(Console.ReadLine().ToUpper());
            Console.WriteLine("Enter Transaction Amount:");
           double Amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Balance:");
            double Balance = Convert.ToInt32(Console.ReadLine());
            Accounts acc = new Accounts(accno, custname, acctype,Amount,Balance,TransType);
            acc.ShowData();
            Console.Read();
        }
    }
}
