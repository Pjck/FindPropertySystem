
using FPS.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using FPS.DAL;
namespace FPS.BL

{
    public class CustomerBL
    {
        CustomerDAO custDao = null;
        public CustomerBL()
        {
            custDao = new CustomerDAO();
        }
        public bool AddCustomer(Customer custObj)
        {
            //Calling DAO class Function
            return custDao.AddCustomer(custObj);
        }

        public bool UpdateCustomer(int custId, Customer custObj)
        {
            return custDao.UpdateCustomer(custId, custObj);
        }

        public bool DropCustomer(int custID)
        {
            return custDao.DropCustomer(custID);
        }

        //public Customer SearchCustomerByID(int custID)
        //{
        //    return custDao.SearchCustomerByID(custID);
        //}


        //public List<Customer> ShowAllCustomer()
        //{
        //    return custDao.ShowAllCustomer();
        //}

    }
}