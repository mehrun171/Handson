using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    /*Indexers:
 
3. Create a class called Books with BookName and AuthorName as members.Instantiate the class through 
    constructor and also write a method Display() to display the details.

Create an Indexer of Books Object to store 5 books in a class called BookShelf.
    Using the indexer method assign values to the books and display the same.
   */
    class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookname, string authorname)
        {
            BookName = bookname;
            AuthorName = authorname;
        }
        public void Display()
        {
            Console.WriteLine("The details are:");
            Console.WriteLine($"BookName = {BookName}");
            Console.WriteLine($"AuthorName = {AuthorName}");
        }
    }
    class BookShelf
    {
        public Books[] books = new Books[5];
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                {
                    return books[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
            set
            {
                if (index >= 0 && index < books.Length)
                {
                    books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }
    }
    class Question3
    {

        public static void Main()
        {
            try
            {

                BookShelf bookshelf = new BookShelf();
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Enter Book {0} Details: ", i + 1);
                    Console.Write("Enter Book Name: ");
                    string BookName = Console.ReadLine();
                    Console.Write("Enter Author Name: ");
                    string AuthorName = Console.ReadLine();
                    bookshelf[i] = new Books(BookName, AuthorName);
                }
                for (int i = 0; i < 5; i++)
                {
                    bookshelf[i].Display();
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("Exception Occurred:" + e.Message);
            }
            Console.ReadLine();
        }
    }
}
