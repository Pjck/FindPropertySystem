
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

        public void CustomerMenu()
        {


        y:
            Console.WriteLine("=========================================");
            Console.WriteLine("1.\tAdd Customer deatails");
            Console.WriteLine("2.\tupdate Customer deatails");
            Console.WriteLine("3.\tdelete Customer deatails");
            Console.WriteLine("4.\tSearch Property by Propertyid");
            Console.WriteLine("5.\tSearch Property by PropertyNmae");
            Console.WriteLine("6.\tSearch Property by Location");
            Console.WriteLine("7.\tSearch Property by Price");
            Console.WriteLine("8.\tShow All Proprties");
            int choice_3 = int.Parse(Console.ReadLine());
            switch (choice_3)
            {

                case 1:
                    custObj = new Customer();
                    Console.WriteLine("Please Enter Customer ID :");
                    custObj.CustomerID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter Customer Name:");
                    custObj.CustomerName = Console.ReadLine();

                    Console.WriteLine("Please Enter Customer PhoneNO :");
                    custObj.CustomerPhNo = long.Parse(Console.ReadLine());


                    bool flag1 = custBL.AddCustomer(custObj);

                    if (flag1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tCustomer details Added...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;

                case 2:
                    custObj1 = new Customer();
                    Console.WriteLine("Please Enter Customer ID :");
                    custObj1.CustomerID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter Customer Name:");
                    custObj1.CustomerName = Console.ReadLine();

                    Console.WriteLine("Please Enter Customer PhoneNO :");
                    custObj1.CustomerPhNo = long.Parse(Console.ReadLine());


                    bool flag2 = custBL.AddCustomer(custObj1);

                    if (flag2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tCustomer details Added...\n");
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
                    
                    try{
                        Console.WriteLine("Enter Property ID");
                        int search_id = int.Parse(Console.ReadLine());
                        Property pObj = propBL.SearchPropertyByID(search_id);
                        Console.WriteLine(pObj);
                        if (pObj != null)
                        {
                            Console.WriteLine("\t\tProperty Details");
                            Console.WriteLine("=================================");
                            Console.WriteLine($"Property ID :{pObj.PropertyID}");
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine($"Property Name :{pObj.PropertyName}");
                            Console.WriteLine($"Description  :{pObj.Description}");
                            Console.WriteLine($"Price :{pObj.Price}");
                            Console.WriteLine($"Location:{ pObj.PropertyLocation}");
                            Console.WriteLine($"Category Name :{pObj.CategoryName}");
                            Console.WriteLine("-----------------------------------");
                        }
                    }

                            catch (CustomException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    
                         break;

                case 5:
                    Console.WriteLine("Enter Property name");
                    string search_name = Console.ReadLine();
                    List<Property> propList = propBL.SearchPropertyByName(search_name);
                    foreach (var pObj in propList)
                    {
                        //  Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);

                        Console.WriteLine("\t\t Property Details");
                        Console.WriteLine("=================================");
                        Console.WriteLine($"Property ID :{pObj.PropertyID}");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Property Name :{pObj.PropertyName}");
                        Console.WriteLine($"Description  :{pObj.Description}");
                        Console.WriteLine($"Price :{pObj.Price}");
                        Console.WriteLine($"Location:{ pObj.PropertyLocation}");
                        Console.WriteLine($"Category Name :{pObj.CategoryName}");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter the property location");
                    string search_location = Console.ReadLine();
                    List<Property> proplist = propBL.SearchPropertyByLocation(search_location);
                    foreach (var pObj in proplist)
                    {
                        //  Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);

                        Console.WriteLine("\t\t Property Details");
                        Console.WriteLine("=================================");
                        Console.WriteLine($"Property ID :{pObj.PropertyID}");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Property Name :{pObj.PropertyName}");
                        Console.WriteLine($"Description  :{pObj.Description}");
                        Console.WriteLine($"Price :{pObj.Price}");
                        Console.WriteLine($"Location:{ pObj.PropertyLocation}");
                        Console.WriteLine($"Category Name :{pObj.CategoryName}");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter the property Price");
                    int search_price = int.Parse(Console.ReadLine());
                    List<Property> proprice = propBL.SearchPropertyByPrice(search_price);
                    foreach (var pObj in proprice)
                    {
                        //Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3} |{5,-10} |{6,10}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName, item.PropertyLocation);

                        Console.WriteLine("\t\t Property Details");
                        Console.WriteLine("=================================");
                        Console.WriteLine($"Property ID :{pObj.PropertyID}");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Property Name :{pObj.PropertyName}");
                        Console.WriteLine($"Description  :{pObj.Description}");
                        Console.WriteLine($"Price :{pObj.Price}");
                        Console.WriteLine($"Location:{ pObj.PropertyLocation}");
                        Console.WriteLine($"Category Name :{pObj.CategoryName}");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                    }
                    break;
                case 8:
                    try
                    {


                        List<Property> tempList = propBL.ShowAllProperty();
                        if (tempList != null)
                        {
                            foreach (var pObj in tempList)
                            {

                                Console.WriteLine("\t\t Property Details");
                                Console.WriteLine("=================================");
                                Console.WriteLine($"Property ID :{pObj.PropertyID}");
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine($"Property Name :{pObj.PropertyName}");
                                Console.WriteLine($"Description  :{pObj.Description}");
                                Console.WriteLine($"Price :{pObj.Price}");
                                Console.WriteLine($"Location:{ pObj.PropertyLocation}");
                                Console.WriteLine($"Category Name :{pObj.CategoryName}");
                                Console.WriteLine("-----------------------------------");
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (CustomException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choice....Please enter correct choice");
                    goto y;

            }

        }
    }
}