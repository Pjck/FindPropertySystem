
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
        Customer custObj1 = null;
        CustomerBL custBL = null;
        Property propObj = null;
        PropertyBL propBL = null;
        public CustomerUI()
        {
            custBL = new CustomerBL();
            propBL = new PropertyBL();
        }

        public void customermenu()
        {


        y:
            Console.WriteLine("1.\tAdd customer deatails");
            Console.WriteLine("1.\tupdate customer deatails");
            Console.WriteLine("1.\tdelete customer deatails");
            Console.WriteLine("1.Search property by Propertyid");
            Console.WriteLine("2.Search property by PropertyNmae");
            Console.WriteLine("3.Search property by Location");
            Console.WriteLine("4.Search property by Price");
            Console.WriteLine("5.Show All Proprties");
            int choice_3 = int.Parse(Console.ReadLine());
            switch (choice_3)
            {

                case 1:
                    custObj = new Customer();
                    Console.WriteLine("Please Enter customer ID :");
                    custObj.CustomerID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter owner Name:");
                    custObj.CustomerName = Console.ReadLine();

                    Console.WriteLine("Please Enter customer PhoneNO :");
                    custObj.CustomerPhNo = long.Parse(Console.ReadLine());


                    bool flag1 = custBL.AddCustomer(custObj);

                    if (flag1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\towner details Added...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;

                case 2:
                    custObj1 = new Customer();
                    Console.WriteLine("Please Enter customer ID :");
                    custObj1.CustomerID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter owner Name:");
                    custObj1.CustomerName = Console.ReadLine();

                    Console.WriteLine("Please Enter customer PhoneNO :");
                    custObj1.CustomerPhNo = long.Parse(Console.ReadLine());


                    bool flag2 = custBL.AddCustomer(custObj1);

                    if (flag2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\towner details Added...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;

                case 3:
                    Console.WriteLine("Enter the ID ");
                    int deleteid = int.Parse(Console.ReadLine());
                    bool flag3 = custBL.DropCustomer(deleteid);
                    if (flag3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord deleted...\n");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    break;


                case 4:
                    Console.WriteLine("Enter the property ID");
                    int search_id = int.Parse(Console.ReadLine());
                    Property product = propBL.SearchPropertyByID(search_id);
                    Console.WriteLine(product);
                    break;
                case 5:
                    Console.WriteLine("Enter the property name");
                    string search_name = Console.ReadLine();
                    List<Property> propList = propBL.SearchPropertyByName(search_name);
                    foreach (var item in propList)
                    {
                        Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter the property location");
                    string search_location = Console.ReadLine();
                    List<Property> proplist = propBL.SearchPropertyByLocation(search_location);
                    foreach (var item in proplist)
                    {
                        Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter the property Price");
                    int search_price = int.Parse(Console.ReadLine());
                    List<Property> proprice = propBL.SearchPropertyByPrice(search_price);
                    foreach (var item in proprice)
                    {
                        Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);
                    }
                    break;
                case8:

                    List<Property> Allprop = propBL.ShowAllProperty();
                    foreach (var item in Allprop)
                    {
                        Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choice....Please enter correct choice");
                    goto y;

            }

        }
    }
}