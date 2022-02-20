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
            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1.\tOWNER");
            Console.WriteLine("2.\tCUSTOMER");
            int choice_1 = int.Parse(Console.ReadLine());

            switch (choice_1)
            {
                case 1:
                    owner.OwnerMenu();
                    break;
                case 2:
                    cust.CustomerMain();
                    break;
            }
        }
    }
}
