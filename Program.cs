using InventoryManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Inventory Management System");

            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter product name: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Product name cannot be empty. Please try again.");
                        continue;
                    }

                    Console.Write("Enter product price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    if (price < 0)
                    {
                        Console.WriteLine("Price cannot be negative. Please try again.");
                        continue;
                    }
                    Console.Write("Enter product quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    if (qty < 0)
                    {
                        Console.WriteLine("Quantity cannot be negative. Please try again.");
                        continue;
                    }

                    inventory.addProduct(new Product(name, price, qty));
                    break;

                case "2":
                    Console.WriteLine("Displaying all products...");
                    inventory.viewProducts();
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}