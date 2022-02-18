
using System;
using System.Collections.Generic;
using System.Text;
using FPS.BL;
using FPS.Exceptions;
using FPS.DAL;
using FPS.Entity;
namespace FPS.UI
{

    public class CustomerUI
    {
        Customer custObj = null;
        CustomerBL custBL = null;

        public CustomerUI()
        {
            custBL = new CustomerBL();
        }

        public static void CustomerMenu()
        {
            Console.WriteLine("\t\t Customer Menu");
            Console.WriteLine("=========================================");
            Console.WriteLine("----Menu Items----");
            Console.WriteLine("1.\t Add Customer Details.");
            Console.WriteLine("2.\t Modify Customer Details.");
            Console.WriteLine("3.\t Delete Customer Detials.");
        }

        public void CustomerMain()
        {
            int choice = 1;
            do
            {
                CustomerMenu();
                Console.WriteLine("Enter Your Choice from above Menu:");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            bool flag = AddCustomer();
                            if (flag)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\t\tRecord Added...\n");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }

                    
                    default:
                        Console.WriteLine("Please enter your choice in 1-5");
                        break;
                }

            } while (choice != -1);
        }

        public bool AddCustomer()
        {
            custObj = new Customer();
            Console.WriteLine("Please Enter Customer ID :");
            custObj.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter Customer Name:");
            custObj.CustomerName = Console.ReadLine();

            Console.WriteLine("Please Enter Customer PhoneNO :");
            custObj.CustomerPhNo = Convert.ToSingle(Console.ReadLine());

            return custBL.AddCustomer(custObj);


        }

        public bool UpdateCustomer(Customer custObj)
        {
            return true;
        }

        public bool DropCustomer(int custID)
        {
            return true;
        }

    }
}