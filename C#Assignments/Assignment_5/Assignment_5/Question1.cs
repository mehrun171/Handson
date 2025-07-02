using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    /*1.
• You have a class which has methods for transaction for a banking system. (created earlier)
• Define your own methods for deposit money, withdraw money and balance in the account.
• Write your own new application Exception class called InsuffientBalanceException.
• This new Exception will be thrown in case of withdrawal of money from the account
    where customer doesn’t have sufficient balance.
• Identify and categorize all possible checked and unchecked exception.*/
    public class InsuffientBalanceException : Exception
    {
        public InsuffientBalanceException()
        {
            Console.WriteLine("NO enough balance to withdraw amount");
        }
    }
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
                try
                {
                    Debit(Amount);
                }
                catch (InsuffientBalanceException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.WriteLine("");                }
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
                throw new InsuffientBalanceException();
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
            Accounts acc = new Accounts(accno, custname, acctype, Amount, Balance, TransType);
            acc.ShowData();
            Console.Read();
        }
    }
}
