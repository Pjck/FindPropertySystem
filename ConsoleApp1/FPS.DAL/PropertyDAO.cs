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
    public class PropertyDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public PropertyDAO()
        {
            con = new SqlConnection();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString;
            con.ConnectionString = "server=.;Integrated Security=true;Database=PropertySystemDB";
        }
        
       
        public bool AddProperty(Property propObj)
        {
            
            bool flag = false;
            try
            {   
                if (propObj != null)
                {
                    con.Open();
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@propID", propObj.PropertyID);
                    param[1] = new SqlParameter("@name", propObj.PropertyName);
                    param[2] = new SqlParameter("@location", propObj.PropertyLocation);
                    param[3] = new SqlParameter("@price", propObj.Price);
                    param[4] = new SqlParameter("@descrip", propObj.Description);
                    param[5] = new SqlParameter("@catName", propObj.CategoryName);

                    cmd = new SqlCommand();
                    //use stored procedure
                    cmd.CommandText = "Insert Into Property(PropID,Name,PropertyLocation,Price,Description,CategoryName)values(@propID,@name,@location,@price,@descrip,@catName)";
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

       
        //public List<Property> SearchPropertyByName(string propName)
        //{
        //    throw new NotImplementedException();
        //}

        public bool UpdateProperty(int propID,Property propObj)
        {
            bool flag = true;
            int result = 0;
            
            try
            {
                if (propObj != null)
                {

                    con.Open();

                    //Init Parameters

                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@propID", propObj.PropertyID);
                    param[1] = new SqlParameter("@name", propObj.PropertyName);
                    param[2] = new SqlParameter("@location", propObj.PropertyLocation);
                    param[3] = new SqlParameter("@price", propObj.Price);
                    param[4] = new SqlParameter("@descrip", propObj.Description);
                    param[5] = new SqlParameter("@catName", propObj.CategoryName);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Insert Into Property(PropID,Name,PropertyLocation,Price,Description,CategoryName)values(@propID,@name,@location,@price,@descrip,@catName)";
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
                    throw new CustomException("Property is not Updated...");
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

        public bool DeleteProperty(int propID)
        {
            bool flag = true;
            int result = 0;
            try
            {
                if (propID > 0)
                {

                    con.Open();

                    //Init Parameters
                    SqlParameter p1 = new SqlParameter("@propID", propID);

                    cmd = new SqlCommand();
                    cmd.CommandText = "Delete from Property where PropID=@propID";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.Add(p1);

                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        flag = true;
                    }
                    Console.WriteLine("Property Deleted Successfully\n");
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
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return flag;
        }
       
        public Property SearchPropertyByID(int propID)
        {
            Property tempProp = null;
            try
            {
                SqlParameter p1 = new SqlParameter("@propID", propID);

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Property where PropID=@propId";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;

                cmd.Parameters.Add(p1);

                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow drow = dt.Rows[0];//Fetch Row from Data Table
                                              
                    tempProp = new Property();
                    tempProp.PropertyID = Int32.Parse(drow[0].ToString());
                    tempProp.PropertyName = drow[1].ToString();
                    tempProp.PropertyLocation = drow[2].ToString();
                    tempProp.Price = Convert.ToSingle(drow[3].ToString());
                    tempProp.Description = drow[4].ToString();
                    tempProp.CategoryName =drow[5].ToString();

                };
            }
            catch (CustomException e)
            {
                throw e;
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

            return tempProp;



        }

        public List<Property> SearchPropertyByName(string propName)
        {
            List<Property> mypropList = null;
            Property tempProp = null;
            try
            {

                con.Open();

                //Init Parameters
                SqlParameter p1 = new SqlParameter("@propName", propName);

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from  Property where Name=@propName";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    mypropList = new List<Property>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Property Object
                        tempProp = new Property();
                        tempProp.PropertyID = Int32.Parse(drow[0].ToString());
                        tempProp.PropertyName = drow[1].ToString();
                        tempProp.PropertyLocation = drow[2].ToString();
                        tempProp.Price = Convert.ToSingle(drow[3].ToString());
                        tempProp.Description = drow[4].ToString();
                        tempProp.CategoryName = drow[5].ToString();

                        //Add TempProo in to List
                        mypropList.Add(tempProp);
                    }
                }
                else
                {
                    throw new CustomException($"No Property Found  ");
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
            return mypropList;

        }

        public List<Property> SearchPropertyByLocation(string propLocation)
        {
            List<Property> mypropList = null;
            Property tempProp = null;
            try
            {

                con.Open();

                //Init Parameters
                SqlParameter p1 = new SqlParameter("@location", propLocation);

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from  Property where PropertyLocation=@location";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    mypropList = new List<Property>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Property Object
                        tempProp = new Property();
                        tempProp.PropertyID = Int32.Parse(drow[0].ToString());
                        tempProp.PropertyName = drow[1].ToString();
                        tempProp.PropertyLocation = drow[2].ToString();
                        tempProp.Price = Convert.ToSingle(drow[3].ToString());
                        tempProp.Description = drow[4].ToString();
                        tempProp.CategoryName = drow[5].ToString();

                        //Add TempProo in to List
                        mypropList.Add(tempProp);
                    }
                }
                else
                {
                    throw new CustomException($"No Property Found  ");
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
            return mypropList;

        }

        public List<Property> SearchPropertyByPrice(int price)
        {
            List<Property> mypropList = null;
            Property tempProp = null;
            try
            {

                con.Open();

                //Init Parameters
                SqlParameter p1 = new SqlParameter("@price", price);

                cmd = new SqlCommand();
                cmd.CommandText = "Select * from  Property where Price=@price";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add(p1);
                sdr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                if (sdr.HasRows)
                {
                    dt.Load(sdr);
                }

                if (dt.Rows.Count > 0)
                {
                    mypropList = new List<Property>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Product Object
                        tempProp = new Property();
                        tempProp.PropertyID = Int32.Parse(drow[0].ToString());
                        tempProp.PropertyName = drow[1].ToString();
                        tempProp.PropertyLocation = drow[2].ToString();
                        tempProp.Price = Convert.ToSingle(drow[3].ToString());
                        tempProp.Description = drow[4].ToString();
                        tempProp.CategoryName = drow[5].ToString();

                        //Add TempProduct in to List
                        mypropList.Add(tempProp);
                    }
                }
                else
                {
                    throw new CustomException($"No Property Found  ");
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
            return mypropList;

        }

        public List<Property> ShowAllProperty()
        {
            List<Property> mypropList = null;
            Property tempProp = null;
            try
            {

                con.Open();

                //Init Parameters


                cmd = new SqlCommand();
                cmd.CommandText = "Select * from  Property";
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
                    mypropList = new List<Property>();
                    foreach (DataRow drow in dt.Rows)
                    {

                        //Assign Row Data to Product Object
                        tempProp = new Property();
                        tempProp.PropertyID = Int32.Parse(drow[0].ToString());
                        tempProp.PropertyName = drow[1].ToString();
                        tempProp.PropertyLocation = drow[2].ToString();
                        tempProp.Price = Convert.ToSingle(drow[3].ToString());
                        tempProp.Description = drow[4].ToString();
                        tempProp.CategoryName = drow[5].ToString();

                        //Add TempProduct in to List
                        mypropList.Add(tempProp);
                    }
                }
                else
                {
                    throw new CustomException($"No Property Found  ");
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
            return mypropList;

        }


    }
}
