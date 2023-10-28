using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq; 
using System.Web;
using UserRecordForm.Models;

namespace UserRecordForm.DataAccess
{
    public class DataAccessLayer
    {
        
        #region MyRegion

        #endregion
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objuser"></param>
        /// <returns></returns>
        /// 
        public List<UserRecord> ViewSearchResult(string SearchText)
        {
            List<UserRecord> showAllRecords = new List<UserRecord>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UserSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchText", "%" + SearchText + "%");

                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                
                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    showAllRecords.Add(
                        new UserRecord
                        {
                            userId = Convert.ToInt32(dr["userId"]),
                            firstName = Convert.ToString(dr["firstName"]),
                            email = Convert.ToString(dr["email"]),
                            username = Convert.ToString(dr["username"]),
                            password = Convert.ToString(dr["password"]),
                            mnumber = Convert.ToString(dr["mnumber"]),
                            dob = Convert.ToDateTime(dr["dob"]),
                            lastName = Convert.ToString(dr["lastName"]),
                            address = Convert.ToString(dr["address"]),
                            dropdownCity = Convert.ToString(dr["dropdowncity"]),
                            age = Convert.ToInt32(dr["age"]),
                            ssc_obtained_mark = Convert.ToInt32(dr["ssc_obtained_mark"]),
                            ssc_total_mark = Convert.ToInt32(dr["ssc_total_mark"])

                        });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }
            return showAllRecords;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userrecord"></param>
        /// <returns></returns>
        public bool ServerValidations(UserRecord userrecord)
        {


            return true;
        }
        /*public void SortView(string sortBy,string order)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("sp_sortTable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SortBy", sortBy);
                cmd.Parameters.AddWithValue("@Order", order);
            }
            *//* SqlDataAdapter sd = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();

             con.Open(); 
             sd.Fill(dt);
             con.Close();

             foreach (DataRow dr in dt.Rows)
             {
                 showAllRecords.Add(
                     new UserRecord
                     {
                         userId = Convert.ToInt32(dr["userId"]),
                         firstName = Convert.ToString(dr["firstName"]),
                         email = Convert.ToString(dr["email"]),
                         username = Convert.ToString(dr["username"]),
                         password = Convert.ToString(dr["password"]),
                         mnumber = Convert.ToString(dr["mnumber"]),
                         dob = Convert.ToDateTime(dr["dob"]),
                         lastName = Convert.ToString(dr["lastName"]),
                         address = Convert.ToString(dr["address"]),
                         dropdownCity = Convert.ToString(dr["dropdowncity"]),
                         age = Convert.ToInt32(dr["age"]),
                         ssc_obtained_mark = Convert.ToInt32(dr["ssc_obtained_mark"]),
                         ssc_total_mark = Convert.ToInt32(dr["ssc_total_mark"])

                     });
             }

         }*//*
            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }
            
        }*/

        public List<UserRecord> paginationView(int itemsPerPage,int skipCount)

            {
            List<UserRecord> showAllRecords = new List<UserRecord>();

            

            string query = $"SELECT *  FROM UserRec1 ORDER BY userId OFFSET {skipCount} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";
            SqlCommand command = new SqlCommand(query, con);
/*            SqlDataReader reader = command.ExecuteReader()*/;
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);    

            foreach (DataRow dr in dt.Rows)
            {
                showAllRecords.Add(
                    new UserRecord
                    {
                        userId = Convert.ToInt32(dr["userId"]),
                        firstName = Convert.ToString(dr["firstName"]),
                        email = Convert.ToString(dr["email"]),
                        username = Convert.ToString(dr["username"]),
                        password = Convert.ToString(dr["password"]),
                        mnumber = Convert.ToString(dr["mnumber"]),
                        dob = Convert.ToDateTime(dr["dob"]),
                        lastName = Convert.ToString(dr["lastName"]),
                        address = Convert.ToString(dr["address"]),
                        dropdownCity = Convert.ToString(dr["dropdowncity"]),
                        age = Convert.ToInt32(dr["age"]),
                        ssc_obtained_mark = Convert.ToInt32(dr["ssc_obtained_mark"]),
                        ssc_total_mark = Convert.ToInt32(dr["ssc_total_mark"])

                    });
            }

            return showAllRecords;

        }

        public int totalReocordCount()
        {
            int totalRecords;

            string countQuery = "SELECT COUNT(*) FROM UserRec1";
            SqlCommand countCommand = new SqlCommand(countQuery, con);
            totalRecords = (int)countCommand.ExecuteScalar();

            return totalRecords;

        }
        public string InsertData(UserRecord objuser)
        {
            string result = "";



            try
            {

                SqlCommand cmd = new SqlCommand("sp_InsertUserData1", con);
                Console.WriteLine("Inside Insert data");
                cmd.CommandType = CommandType.StoredProcedure;
                /*cmd.Parameters.AddWithValue("@userId", objuser.userId);
*/                cmd.Parameters.AddWithValue("@email", objuser.email);
                cmd.Parameters.AddWithValue("@username", objuser.username);
                cmd.Parameters.AddWithValue("@password", objuser.password);
                cmd.Parameters.AddWithValue("@mnumber", objuser.mnumber);
                cmd.Parameters.AddWithValue("@firstName", objuser.firstName);
                cmd.Parameters.AddWithValue("@lastName", objuser.lastName);
                cmd.Parameters.AddWithValue("@address", objuser.address);
                cmd.Parameters.AddWithValue("@dropdownCity", objuser.dropdownCity);
                cmd.Parameters.AddWithValue("@dob", objuser.dob);
                cmd.Parameters.AddWithValue("@age", objuser.age);
                cmd.Parameters.AddWithValue("@ssc_total_mark", objuser.ssc_total_mark);
                cmd.Parameters.AddWithValue("@ssc_obtained_mark", objuser.ssc_obtained_mark);
                cmd.Parameters.AddWithValue("@percentage_ssc", objuser.percentage_ssc);

                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
          
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return result;

            }
            /*finally
            {
                con.Close();
            }*/
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objuser"></param>
        /// <returns></returns>


        /*
*/
    
        public bool UpdateDetails(UserRecord objuser)   
        {
            
            using (SqlCommand cmd = new SqlCommand("sp_UpdateUserDetails", con)
)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", objuser.userId);
                cmd.Parameters.AddWithValue("@email", objuser.email);
                cmd.Parameters.AddWithValue("@mnumber", objuser.mnumber);
                cmd.Parameters.AddWithValue("@firstName", objuser.firstName);

                cmd.Parameters.AddWithValue("@lastName", objuser.lastName);
                cmd.Parameters.AddWithValue("@address", objuser.address);
                cmd.Parameters.AddWithValue("@dropdownCity", objuser.dropdownCity);

                cmd.Parameters.AddWithValue("@ssc_total_mark", objuser.ssc_total_mark);
                cmd.Parameters.AddWithValue("@ssc_obtained_mark", objuser.ssc_obtained_mark);

                cmd.Parameters.AddWithValue("@percentage_ssc", objuser.percentage_ssc);

                /*cmd.Parameters.AddWithValue("@dob", objuser.dob);
                cmd.Parameters.AddWithValue("@age", objuser.age);
                cmd.Parameters.AddWithValue("@username", objuser.username);
                cmd.Parameters.AddWithValue("@password", objuser.password);*/

                con.Open();
                int i = cmd.ExecuteNonQuery();
             

                if (i >= 1)
                    return true;
                else
                    return false;
            }
        }
        public List<UserRecord> ViewAllUser()
        {
          

            List<UserRecord>   showAllRecords = new List<UserRecord> ();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ViewAllRecords", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach(DataRow dr in dt.Rows)
                {
                    showAllRecords.Add(
                        new UserRecord
                        {
                            userId = Convert.ToInt32(dr["userId"]),
                            firstName = Convert.ToString(dr["firstName"]),
                            email = Convert.ToString(dr["email"]),
                            username = Convert.ToString(dr["username"]),
                            password = Convert.ToString(dr["password"]),
                            mnumber = Convert.ToString(dr["mnumber"]),
                            dob = Convert.ToDateTime(dr["dob"]),
                            lastName = Convert.ToString(dr["lastName"]),
                            address = Convert.ToString(dr["address"]),
                            dropdownCity = Convert.ToString(dr["dropdowncity"]),
                            age = Convert.ToInt32(dr["age"]),
                            ssc_obtained_mark = Convert.ToInt32(dr["ssc_obtained_mark"]),
                            ssc_total_mark = Convert.ToInt32(dr["ssc_total_mark"])

                        });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("exception : " + e.Message);
            }
            return showAllRecords;
        }

        public bool DeleteUser(int userId)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("sp_deleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("userId", userId);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0) 
                { return true; }
                else
                {
                    return false;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }
            finally{
                con.Close();
            }
        }
    }
}

        