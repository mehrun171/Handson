using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge_3
{
    /*    2. Write a class Box that has Length and breadth as its members.Write a function that adds 2 box objects
     *    and stores in the 3rd.Display the 3rd object details. Create a Test class to execute the above.
    */
    class Box
    {
        public double length { get; set; }
        public double breadth { get; set; }
        public Box(double l, double b)
        {
            length = l;
            breadth = b;
        }

        public static Box Add(Box b1, Box b2)
        {
            double templ = b1.length + b2.length;
            double tempb = b1.breadth + b2.breadth;
            return new Box(templ,tempb);
        }
        public void Display()
        {
            Console.WriteLine($"Length COmbined: {length}, Breadth Combined: {breadth}");
        }
    }
    class Test
    {
        public static void Main()
        {
            Console.WriteLine("Enter Box 1 Length");
            double l1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Box 1 Breadth");
            double b1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Box 2 Length");
            double l2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Box 2 Breadth");
            double b2 = Convert.ToDouble(Console.ReadLine());

            Box box1res = new Box(l1,b1);
            Box box2res = new Box(l2,b2);
            Box box3 = Box.Add(box1res, box2res);
            Console.WriteLine("After addition - BOX 3 =>");
            box3.Display();
            Console.ReadLine();
        }
    }

}
