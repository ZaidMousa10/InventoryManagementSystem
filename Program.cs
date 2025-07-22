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
                    string name;
                    decimal price;
                    int qty;

                    // Get valid name
                    while (true)
                    {
                        Console.Write("Enter product name: ");
                        name = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Product name cannot be empty. Please try again.");
                            continue;
                        }

                        if (inventory.Products.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("Product with this name already exists. Please use a different name.");
                            continue;
                        }

                        break;
                    }

                    // Get valid price
                    while (true)
                    {
                        Console.Write("Enter product price: ");
                        string priceInput = Console.ReadLine();

                        if (!decimal.TryParse(priceInput, out price) || price < 0)
                        {
                            Console.WriteLine("Invalid price. Please enter a non-negative number.");
                            continue;
                        }

                        break;
                    }

                    // Get valid quantity
                    while (true)
                    {
                        Console.Write("Enter product quantity: ");
                        string qtyInput = Console.ReadLine();

                        // Accept only Integer numbers
                        if (!int.TryParse(qtyInput, out qty) || qty < 0)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a non-negative Integer number.");
                            continue;
                        }

                        break;
                    }

                    inventory.AddProduct(new Product(name, price, qty));
                    break;


                case "2":
                    Console.WriteLine("Displaying all products...");
                    inventory.ViewProducts();
                    break;

                case "3":
                    Console.Write("Enter name of product to edit: ");
                    string editName = Console.ReadLine();
                    inventory.EditProduct(editName);
                    break;

                case "4":
                    Console.Write("Enter name of product to Delete: ");
                    string deleteName = Console.ReadLine();
                    inventory.DeleteProduct(deleteName);
                    break;

                case "5":
                    Console.Write("Enter name of product to search: ");
                    string searchName = Console.ReadLine();
                    inventory.SearchProduct(searchName);
                    break;

                case "6":
                    Console.WriteLine("Exiting the Inventory Management System. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}