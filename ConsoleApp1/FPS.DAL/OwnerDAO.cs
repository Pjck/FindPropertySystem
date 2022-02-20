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
    public class OwnerDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public OwnerDAO()
        {
            con = new SqlConnection();
            // con.ConnectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;
            con.ConnectionString = "server=.;Integrated Security=true;Database=PropertySystemDB";
        }

        public bool AddOwner(Owner ownObj)
        {
            bool flag = false;
            try
            {
                if (ownObj != null)
                {
                    con.Open();
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@ownID", ownObj.OwnerID);
                    param[1] = new SqlParameter("@ownName", ownObj.OwnerName);
                    param[2] = new SqlParameter("@ownPhoneNo", ownObj.OwnerPhNo);


                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert Into Owner(OwnID,OwnName,OwnerPhNo)values(@ownID,@ownName,@ownPhoneNo)";
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


        public bool UpdateOwner(int ownID, Owner ownObj)
        {
            bool flag = true;
            int result = 0;

            try
            {
                if (ownObj != null)
                {

                    con.Open();

                    //Init Parameters

                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@ownID", ownObj.OwnerID);
                    param[1] = new SqlParameter("@ownName", ownObj.OwnerName);
                    param[2] = new SqlParameter("@ownPhoneNo", ownObj.OwnerPhNo);


                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert Into Owner(OwnID,OwnName,OwnerPhNo)values(@ownID,@ownName,@ownPhoneNo)";
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
                    throw new CustomException("Owner Info not Updated...");
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

        public bool DropOwner(int ownID)
        {
            bool flag = true;
            int result = 0;
            try
            {
                if (ownID > 0)
                {

                    con.Open();

                    //Init Parameters
                    SqlParameter p1 = new SqlParameter("@ownID", ownID);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Delete from Owner where OwnID=@OwnID";
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





        public List<Owner> ShowAllOwner()
        {
            List<Owner> myownList = null;
            Owner tempOwn = null;
            try
            {

                con.Open();

                //Init Parameters


                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Owner";
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
                    myownList = new List<Owner>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Product Object
                        tempOwn = new Owner();
                        tempOwn.OwnerID = Int32.Parse(drow[0].ToString());
                        tempOwn.OwnerName = drow[1].ToString();
                        tempOwn.OwnerPhNo = long.Parse(drow[2].ToString());

                        //Add TempProduct in to List
                        myownList.Add(tempOwn);
                    }
                }
                else
                {
                    throw new CustomException($"No Owner Found  ");
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
            return myownList;

        }


    }
}