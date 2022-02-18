//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FSP.UI
//{
//    class LoginUI
//    {
//    }
//}


//namespace ConsoleApp8
//{
//    class Program
//    {
//        public static string UserId { get; private set; }

//        static void Main(string[] args)
//        {
//            Console.WriteLine("Choose Any One Option");
//            Console.WriteLine("1:Customer\n2:Admin");
//            switch (Convert.ToInt32(Console.ReadLine()))
//            {
//                case 1:
//                    Customer cust;
//                    Console.WriteLine("Choose One\n1:Username\n2:Password\n3:newuser Registration");
//                    cust = new Customer();
//                    switch (Convert.ToInt32(Console.ReadLine()))
//                    {
//                        case 1:
//                            cust.Username();
//                            break;
//                        case 2:
//                            cust.Password();
//                            break;
//                        case 3:
//                            break;

//                    }
//                    break;
//                case 2:
//                start: Console.Write("User Name: ");
//                    string uName = Console.ReadLine();
//                    Console.Write("Password: ");
//                    string pass = Console.ReadLine();
//                    Console.Write("new user Registration");
//                    string New = Console.ReadLine();
//                    Main admin = new Admin();
//                    Console.WriteLine("Checking Credentials...");
//                    int n = admin.CheckCredentials(uName, pass);
//                    if (n == 0)
//                    {
//                        Console.WriteLine("Either username or password is incorrect.");
//                        goto start;
//                    }
//                    else
//                    {
//                        int choice;
//                        do
//                        {
//                            choice = Convert.ToInt32(Console.ReadLine());
//                            switch (choice)
//                            {
//                                case 1:

//                                    Console.Write("UserId: ");
//                                    UserId = Console.ReadLine();
//                                    Console.Write("Password: ");
//                                    string Password = Console.ReadLine();

//                                    {
//                                        Console.WriteLine("Username Added");
//                                    }
//                                    break;
//                            }
//                        } while (choice != 0);
//                    }

//                    break;
//            }
//        }

//        private static object Registrarion()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}