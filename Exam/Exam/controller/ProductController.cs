using System;
using System.Collections.Generic;
using Exam.entity;

namespace Exam.controller
{
    public class ProductController
    {
        List<Product> listProducts = new List<Product>();
        
        public void Add()
        {
            Console.WriteLine("Add product records:");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Please enter product details:");
            Console.WriteLine("Product Id: ");
            var id = Console.ReadLine();
            Console.WriteLine("Product Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Product Price: ");
            decimal price = Decimal.Parse(Console.ReadLine());
            var product = new Product(id, name, price);
            listProducts.Add(product);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public void Display()
        {
            Console.WriteLine("{0,15}|{1,15}|{2,15}", "Product ID", "Product Name", "Product Price");
            foreach (var product in listProducts)
            {
                Console.WriteLine("{0,15}|{1,15}|{2,15}", product.Id, product.Name, "$" + product.Price);
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public void Delete()
        {
            Console.WriteLine("Product ID you want to delete:");
            var id = Console.ReadLine();
            for (int i = 0; i < listProducts.Count; i++)
            {
                Product product = listProducts[i];
                if (product.Id == id){
                    listProducts.Remove(product);
                    Console.WriteLine("The product has been deleted.");
                }
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}