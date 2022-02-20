//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FPS.Entity;
//using FPS.BL;
//namespace FPS.UI
//{
//    class OwnerUI
//    {
//        Property propObj = null;
//        Property propObj2 = null;
//        PropertyBL propBL = null;
//        Owner own = null;
//        Owner own1 = null;
//        OwnerBL ownBL = null;
//        public OwnerUI()
//        {
//            PropertyBL propBL = new PropertyBL();
//            OwnerBL ownBL = new OwnerBL();
//        }
//        public void OwnerMenu()
//        {

//        x:
//            Console.WriteLine("1.\tAdd Owner deatails");
//            Console.WriteLine("2.\tUpdate Owner deatails");
//            Console.WriteLine("3.\tDelete Owner deatails");
//            Console.WriteLine("4.\tAdd Property");
//            Console.WriteLine("4.\tUpdate Property");
//            Console.WriteLine("5.\tDelete Property");
//            int choice_1 = int.Parse(Console.ReadLine());
//            switch (choice_1)
//            {

//                case 1:
//                    Owner own = new Owner();
//                    Console.WriteLine("Please Enter Owner ID :");
//                    own.OwnerID = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine("Please Enter Owner Name:");
//                    own.OwnerName = Console.ReadLine();

//                    Console.WriteLine("Please Enter Owner PhoneNO :");
//                    own.OwnerPhNo = long.Parse(Console.ReadLine());


//                    bool flag1 = ownBL.AddOwner(own);

//                    if (flag1)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\towner details Added...\n");
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    break;
//                case 2:

//                    Console.WriteLine("Enter the Owner ID");
//                    own1 = new Owner();
//                    Console.WriteLine("Please Enter owner ID :");
//                    own1.OwnerID = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine("Please Enter owner Name:");
//                    own1.OwnerName = Console.ReadLine();

//                    Console.WriteLine("Please Enter owner PhoneNO :");
//                    own1.OwnerPhNo = long.Parse(Console.ReadLine());
//                    long update_id = long.Parse(Console.ReadLine());
//                    //bool flag2 = ownBL.UpdateOwner(update_id, own1);
//                    //if (flag2)
//                    //{
//                    //    Console.ForegroundColor = ConsoleColor.Green;
//                    //    Console.WriteLine("\t\tOwner detais  updated...\n");
//                    //    Console.ForegroundColor = ConsoleColor.White;
//                    //}
//                    break;

//                case 3:
//                    Console.WriteLine("Enter the ID ");
//                    int delete_id = int.Parse(Console.ReadLine());
//                    bool flag3 = ownBL.DropOwner(delete_id);
//                    if (flag3)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\tRecord deleted...\n");
//                        Console.ForegroundColor = ConsoleColor.White;

//                    }
//                    break;

//                case 4:


//                    bool flag4 = ownBL.AddOwner(own1);

//                    if (flag4)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\tRecord Added...\n");
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    break;


//                case 5:
//                    propObj = new Property();
//                    Console.WriteLine("Please Enter Property ID :");
//                    propObj.PropertyID = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine("Please Enter Property Name:");
//                    propObj.PropertyName = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property Price :");
//                    propObj.Price = Convert.ToSingle(Console.ReadLine());

//                    Console.WriteLine("Please Enter Property Location:");
//                    propObj.PropertyLocation = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property Description :");
//                    propObj.Description = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property CategoryName :");
//                    propObj.CategoryName = Console.ReadLine();

//                    bool flag5 = propBL.AddProperty(propObj);

//                    if (flag5)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\tRecord Added...\n");
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    break;

//                case 6:
//                    propObj2 = new Property();
//                    Console.WriteLine("Please Enter Property ID :");
//                    propObj2.PropertyID = Convert.ToInt32(Console.ReadLine());

//                    Console.WriteLine("Please Enter Property Name:");
//                    propObj2.PropertyName = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property Price :");
//                    propObj2.Price = Convert.ToSingle(Console.ReadLine());

//                    Console.WriteLine("Please Enter Property Location:");
//                    propObj2.PropertyLocation = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property Description :");
//                    propObj2.Description = Console.ReadLine();

//                    Console.WriteLine("Please Enter Property CategoryName :");
//                    propObj2.CategoryName = Console.ReadLine();

//                    Console.WriteLine("enter the propery id");
//                    int update_id1 = int.Parse(Console.ReadLine());
//                    bool flag6 = propBL.UpdateProperty(update_id1, propObj2);
//                    if (flag6)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\tRecord updated...\n");
//                        Console.ForegroundColor = ConsoleColor.White;
//                    }
//                    break;
//                case 7:
//                    Console.WriteLine();
//                    int delete_id1 = int.Parse(Console.ReadLine());
//                    bool flag7 = propBL.DeleteProperty(delete_id1);
//                    if (flag7)
//                    {
//                        Console.ForegroundColor = ConsoleColor.Green;
//                        Console.WriteLine("\t\tRecord deleted...\n");
//                        Console.ForegroundColor = ConsoleColor.White;

//                    }
//                    break;




//                default:
//                    Console.WriteLine("Invalid Choice....Please enter correct choice");
//                    goto x;
//            }


//        }
//    }
//}







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPS.Entity;
using FPS.BL;
namespace FPS.UI
{
    class OwnerUI
    {
        Property propObj = new Property();
        PropertyBL propBL = new PropertyBL();
        Owner own = null;
        Owner own1 = null;
        OwnerBL ownBL = null;
        public OwnerUI()
        {
            propBL = new PropertyBL();
            ownBL = new OwnerBL();
        }
        public void OwnerMenu()
        {

        x:
            Console.WriteLine("=========================================");
            Console.WriteLine("1.\tAdd Owner deatails");
            Console.WriteLine("2.\tUpdate Owner deatails");
            Console.WriteLine("3.\tDelete Owner deatails");
            Console.WriteLine("4.\tAdd Property");
            Console.WriteLine("5.\tUpdate Property");
            Console.WriteLine("6.\tDelete Property");

            int choice_1 = int.Parse(Console.ReadLine());
            switch (choice_1)
            {

                case 1:

                    bool flag = AddOwner();
                    if (flag)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord Added...\n");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    break;

                case 2:

                    Console.WriteLine("Enter the Owner ID");
                    own1 = new Owner();
                    Console.WriteLine("Please Enter owner ID :");
                    own1.OwnerID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter owner Name:");
                    own1.OwnerName = Console.ReadLine();

                    Console.WriteLine("Please Enter owner PhoneNO :");
                    own1.OwnerPhNo = long.Parse(Console.ReadLine());
                    long update_id = long.Parse(Console.ReadLine());
                    //bool flag2 = ownBL.UpdateOwner(update_id, own1);
                    //if (flag2)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Green;
                    //    Console.WriteLine("\t\tOwner detais  updated...\n");
                    //    Console.ForegroundColor = ConsoleColor.White;
                    //}
                    break;

                case 3:
                    Console.WriteLine("Enter the ID ");
                    int delete_id = int.Parse(Console.ReadLine());
                    bool flag3 = ownBL.DropOwner(delete_id);
                    if (flag3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord deleted...\n");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    break;

                case 4:

                    propObj = new Property();
                    Console.WriteLine("Please Enter Property ID :");
                    propObj.PropertyID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please Enter Property Name:");
                    propObj.PropertyName = Console.ReadLine();

                    Console.WriteLine("Please Enter Property Price :");
                    propObj.Price = Convert.ToSingle(Console.ReadLine());

                    Console.WriteLine("Please Enter Property Location:");
                    propObj.PropertyLocation = Console.ReadLine();

                    Console.WriteLine("Please Enter Property Description :");
                    propObj.Description = Console.ReadLine();

                    Console.WriteLine("Please Enter Property CategoryName :");
                    propObj.CategoryName = Console.ReadLine();

                    bool flag5 = propBL.AddProperty(propObj);

                    if (flag5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord Added...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;

                case 5:
                    Console.WriteLine("Enter Property ID ");
                    int update_id1 = int.Parse(Console.ReadLine());
                    bool flag6 = propBL.UpdateProperty(update_id1, propObj);
                    if (flag6)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord updated...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    break;

                case 6:
                    Console.WriteLine("Enter Property ID");
                    int delete_id1 = int.Parse(Console.ReadLine());
                    bool flag7 = propBL.DeleteProperty(delete_id1);
                    if (flag7)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tRecord deleted...\n");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choice....Please enter correct choice");
                    goto x;
            }
        }
            public bool AddOwner()
            {
                Owner ownerObj = new Owner();
                Console.WriteLine("Please Enter Owner ID :");
                 ownerObj.OwnerID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter Owner Name:");
                ownerObj.OwnerName = Console.ReadLine();

                Console.WriteLine("Please Enter Owner PhoneNo :");
                 ownerObj.OwnerPhNo = Convert.ToInt32(Console.ReadLine());

                return ownBL.AddOwner(ownerObj);


            }
        

    }
}

