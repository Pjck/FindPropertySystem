//using System;
//using System.Data.SqlClient;
//using FPS.Entity;
//using System.Collections.Generic;
//namespace FPS.DAL
//{
//    public class LoginDAO
//    {

//        public List<Login> LoginDetails()
//        {

//            string connectionString = "server = propertymanagementsystem.database.windows.net; initial catalog =cg48dEMS; user id = emsadmin; password = QWE!@#123 ";
//            SqlConnection Connection = new SqlConnection(connectionString);
//            string queryString = "SELECT * from dbo.Users";
//            SqlCommand command = new SqlCommand(queryString, Connection);
//            Connection.Open();
//            SqlDataReader reader = command.ExecuteReader();
//            List<Login> userList = new List<Login>();
//            while (reader.Read())
//            {
//                userList.Add(new Login()
//                {
//                    UName = (string)reader[1],
//                    PassWord = (string)reader[2],
//                    UType = (string)reader[3]
//                });
//            }
//            return userList;
//        }


//    }
//}