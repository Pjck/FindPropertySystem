using FPS.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using FPS.BL;
using FPS.Exceptions;

namespace FPS.UI
{
   
    class PropertyUI
    {
        Property propObj = null;
        PropertyBL propBL = null;

        public PropertyUI()
        {
            propBL = new PropertyBL();
        }

        public static void PropertyMenu()
        {
            Console.WriteLine("\t\t Property Menu");
            Console.WriteLine("=========================================");
            Console.WriteLine("----Menu Items----");
            Console.WriteLine("1.\t Add Property Details.");
            Console.WriteLine("2.\t Modify Property Details.");
            Console.WriteLine("3.\t Delete Property Detials.");
            Console.WriteLine("4.\t Show Property Detials By ID.");
            Console.WriteLine("5.\t Show Property Detials By Name.");
            Console.WriteLine("6.\t Show Property Detials By Price.");
            Console.WriteLine("7.\t Show All Property Details.");
        }

        public void PropertyMain()
        {
            int choice = 1;
            do
            {
                PropertyMenu();
                Console.WriteLine("Enter Your Choice from above Menu:");
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            bool flag = AddProperty();
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
                    case 4:
                        {
                            try
                            {

                                Console.Write("Please Enter Property ID :");
                                int propID = Convert.ToInt32(Console.ReadLine());
                                Property pObj = propBL.SearchPropertyByID(propID);
                                if (pObj != null)
                                {
                                    Console.WriteLine("\t\tProperty Details");
                                    Console.WriteLine("=================================");
                                    Console.WriteLine($"Property ID :{pObj.PropertyID}");
                                    Console.WriteLine("---------------------------------");
                                    Console.WriteLine($"Property Name :{pObj.PropertyName}");
                                    Console.WriteLine($"Description  :{pObj.Description}");
                                    Console.WriteLine($"Price :{pObj.Price}");
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
                        }
                    case 5:
                        {
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
                        }
                    default:
                        Console.WriteLine("Please enter your choice in 1-5");
                        break;
                }

            } while (choice != -1);
        }

        public bool AddProperty()
        {
            propObj = new Property();
            Console.WriteLine("Please Enter Property ID :");
            propObj.PropertyID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please Enter Property Name:");
            propObj.PropertyName = Console.ReadLine();

            Console.WriteLine("Please Enter Property Price :");
            propObj.Price = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Please Enter Property Description :");
            propObj.Description = Console.ReadLine();

            Console.WriteLine("Please Enter Property CategoryName :");
            propObj.CategoryName = Console.ReadLine();

            return propBL.AddProperty(propObj);


        }

        public bool UpdateProperty(Property propObj)
        {
            return true;
        }

        public bool DropProperty(int propID)
        {
            return true;
        }

        public void SearchPropertyByID(int propID)
        {
            // return new Property();
        }

        public void SearchPropertyByName(string propName)
        {
            // return new List<Property>();
        }

        public void SearchPropertyByPrice(int price)
        {

        }

        public void ShowAllProperty()
        {
            List<Property> propList = propBL.ShowAllProperty();
            foreach (var item in propList)
            {
                Console.WriteLine("{0,4} |{1,-10} |{2,4} |{3,-20} |{4,3}", item.PropertyID, item.PropertyName, item.Price, item.Description, item.CategoryName);
            }
        }

    }
}
