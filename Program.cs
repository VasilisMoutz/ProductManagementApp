using System.IO;
using Microsoft.Win32.SafeHandles;
namespace ProductManagementApp
{
    internal class Program
    {
        static void Main()
        {
            ProductsList<string> productsList = new();

            try
            {
                //Create Instance of StreamReader to read a file
                using (StreamReader reader = new("products.txt"))
                {
                    //Read entire content of the file
                    string allProducts = reader.ReadToEnd();

                    //Create an array containing each product
                    string[] products = allProducts.Split(' ');

                    //Insert all products to ProductList
                    foreach(var product in products)
                    {
                        productsList.Insert(product);
                    }

                }
            }
            catch (FileNotFoundException e1)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e1.Message);
            }
            catch (IOException e2)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e2.Message);
            }

            
            System.Console.WriteLine("Sorted By Value..");
            productsList.SortByValueAsc();
            productsList.Traverse();

            System.Console.WriteLine("\nSorted By Volume..");
            productsList.SortByFrequenctDesc();
            productsList.Traverse();
        }
    }
}