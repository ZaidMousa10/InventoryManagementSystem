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

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully.");
        }
        public void ViewProducts()
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
        public bool EditProduct(string name)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                Console.WriteLine($"Editing product: {product}");

                Console.Write("Enter new name (leave blank to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                    product.Name = newName;

                Console.Write("Enter new price (leave blank to keep current): ");
                string priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, out decimal newPrice))
                    product.Price = newPrice;

                Console.Write("Enter new quantity (leave blank to keep current): ");
                string qtyInput = Console.ReadLine();
                if (int.TryParse(qtyInput, out int newQty))
                    product.Quantity = newQty;

                Console.WriteLine("Product edited successfully.");
                return true;
            }

            Console.WriteLine("Product not found.");
            return false;
        }
        public bool DeleteProduct(string name)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully.");
                return true;
            }
            Console.WriteLine("Product not found.");
            return false;
        }

    }
}
