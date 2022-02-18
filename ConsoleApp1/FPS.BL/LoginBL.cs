//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FPS.DAL;
//using FPS.BL;
//using FPS.Entity;
//using FPS.Exceptions;

//namespace FPS.BL
//{
//    public class LoginCheckBL
//    {
//        #region LoginCheckingMethod
//        //method for login check
//        public static int LoginCheck(User user)
//        {
//            int access = -1;
//            try
//            {

//                PropertyDAL loginDAL = new PropertyDAL();
//                //call login check method of DAL
//                access = loginDAL.LoginCheck(user);

//            }
//            catch (PropertyExceptions e)
//            {
//                throw new PropertyExceptions(e.Message);
//            }
//            catch (Exception e)
//            {
//                throw new Exception(e.Message);
//            }
//            return access;
//        }
//        #endregion
//    }
//}
