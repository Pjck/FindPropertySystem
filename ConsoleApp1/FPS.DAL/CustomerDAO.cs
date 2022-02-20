
using FPS.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FPS.Exceptions;

namespace FPS.DAL
{
    public class CustomerDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public CustomerDAO()
        {
            con = new SqlConnection();
            // con.ConnectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;
            con.ConnectionString = "server=.;Integrated Security=true;Database=PropertySystemDB";
        }

        public bool AddCustomer(Customer custObj)
        {
            bool flag = false;
            try
            {
                if (custObj != null)
                {
                    con.Open();
                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@custID", custObj.CustomerID);
                    param[1] = new SqlParameter("@custName", custObj.CustomerName);
                    param[2] = new SqlParameter("@custPhoneNo", custObj.CustomerPhNo);


                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert Into Customer(custID,custName,custPhoneNo)values(@custID,@custName,@custPhoneNo)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    //Adding Param to Commands
                    cmd.Parameters.AddRange(param);

                    int res = cmd.ExecuteNonQuery();

                    if (res > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception e)
            {
                
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }


        public bool UpdateCustomer(int custID, Customer custObj)
        {
            bool flag = true;
            int result = 0;

            try
            {
                if (custObj != null)
                {

                    con.Open();

                    //Init Parameters

                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@custID", custObj.CustomerID);
                    param[1] = new SqlParameter("@custName", custObj.CustomerName);
                    param[2] = new SqlParameter("@custPhoneNo", custObj.CustomerPhNo);


                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert Into Customer(CustID,CustName,CustomerPhNo)values(@custID,@custName,@custPhoneNo)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddRange(param);

                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    throw new CustomException("Customer Info not Updated...");
                }
            }
            catch (CustomException se)
            {
                throw se;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }

        public bool DropCustomer(int custID)
        {
            bool flag = true;
            int result = 0;
            try
            {
                if (custID > 0)
                {

                    con.Open();

                    //Init Parameters
                    SqlParameter p1 = new SqlParameter("@custID", custID);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Delete from Customer where CustID=@custID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.Add(p1);

                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                    }

                }
                else
                {
                    flag = false;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }


            return flag;
        }





        public List<Customer> ShowAllCustomer()
        {
            List<Customer> mycustList = null;
            Customer tempCust = null;
            try
            {

                con.Open();

                //Init Parameters


                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Customer";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    mycustList = new List<Customer>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Product Object
                        tempCust = new Customer();
                        tempCust.CustomerID = Int32.Parse(drow[0].ToString());
                        tempCust.CustomerName = drow[1].ToString();
                        tempCust.CustomerPhNo = Convert.ToSingle(drow[2].ToString());

                        //Add TempProduct in to List
                        mycustList.Add(tempCust);
                    }
                }
                else
                {
                    throw new CustomException($"No Customer Found  ");
                }
            }
            catch (SqlException e)
            {
                throw new CustomException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return mycustList;

        }


    }
}