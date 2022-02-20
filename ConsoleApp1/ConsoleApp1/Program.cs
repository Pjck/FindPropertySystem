using System;
using System.Data.SqlClient;

namespace FPS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerUI cust = new CustomerUI();
            OwnerUI owner = new OwnerUI();
            Console.WriteLine("Enter 1 for Owner Login and 2 for Customer Login");
            Console.WriteLine("=========================================");
            Console.WriteLine("1.OWNER");
            Console.WriteLine("2.CUSTOMER");
            Console.WriteLine("------------------------------------------");
            int choice_1 = int.Parse(Console.ReadLine());

            switch (choice_1)
            {
                case 1:
                    owner.OwnerMenu();
                    break;
                case 2:
                    cust.CustomerMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input......Please enter correct Choice");
                    break;

            }

            //PropertyUI propObj = new PropertyUI();
            //propObj.PropertyMain();
        }
    }
}
