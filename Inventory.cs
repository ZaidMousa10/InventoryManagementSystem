using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    internal class Inventory
    {
        private List<Product> products = new List<Product>();

        public void addProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully.");
        }
        public void viewProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            Console.WriteLine("Current products in inventory:");
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
