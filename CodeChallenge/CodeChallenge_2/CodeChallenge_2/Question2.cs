using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_2
{
    /*    2. Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, 
     *    sort them based on the price, and display the sorted Products
    */
    class Products
    {
        public int Productid { get; set; }
        public string ProductName{get;set;}
        public double Price { get; set; }
        public Products(int productid,string productname,double price)
        {
            Productid = productid;
            ProductName = productname;
            Price = price;
        }
    }
    class Question2
    {
        static void Main()
        {
            List<Products> products = new List<Products>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter Products Details");
                Console.WriteLine("");
                Console.WriteLine("Enter Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                products.Add(new Products(id, name, price));
            }

            var sortedProducts = products.OrderBy(product => product.Price);
            sortedProducts.ToList();

            Console.WriteLine("\nSorted Products by Price:");
            foreach (var product in sortedProducts)
            {
                Console.WriteLine("The products are:");
                Console.WriteLine($"ProductID: {product.Productid}, ProductName: {product.ProductName}, " +
                    $"ProductPrice: {product.Price}");
            }
            Console.ReadLine();
        }
    }
}
