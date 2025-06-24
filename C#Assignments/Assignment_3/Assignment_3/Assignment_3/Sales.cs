using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    
    class Saledetails
    {
        public static int Salesno;
        public static int Productno;
        public static double Price;
        public static DateTime Dateofsale;
        public static int Qty;
        public static double TotalAmount;

        public Saledetails(int salesno, int productno, double price, int qty, DateTime dateofsale)
        {
            Salesno = salesno;
            Productno = productno;
            Price = price;
            Qty = qty;
            Dateofsale = dateofsale;
            Sales(qty, price);
        }
        public void Sales(int qty,double price)
        {
            TotalAmount = qty * price;
        }
        public static void showData()
        {
            Console.WriteLine("**********The Sale Details are:**********");
            Console.WriteLine("Sales Number:" + Salesno);
            Console.WriteLine("Product Number:" + Productno);
            Console.WriteLine("Price:" + Price);
            Console.WriteLine("Date of Sale:" + Dateofsale);
            Console.WriteLine("Quantity:" + Qty);
            Console.WriteLine("Total Amount:" + TotalAmount);
        }

    }

    class Test3
    {
        public static void Main()
        {
            int Salesno;
            int Productno;
            double Price;
            DateTime Dateofsale;
            int Qty;

            Console.WriteLine("Enter Sales Number:");
            Salesno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Number:");
            Productno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Date of Sale:");
            Dateofsale = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Quantity:");
            Qty = Convert.ToInt32(Console.ReadLine());

            Saledetails sd = new Saledetails(Salesno, Productno, Price, Qty,Dateofsale);

            Saledetails.showData();
            Console.Read();
        }
    }
}
    
