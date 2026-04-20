using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class UserDataAccess
    {
        public static bool GetUserByUserID(int userID, ref string firstName, ref string lastName, ref string userName, ref string password
                   , ref DateTime dateOfBirth , ref short gender , ref string email, ref string address, ref string imagePath,ref short role)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spUser_GetUserById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userID);


                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            firstName = (string)reader["FirstName"];
                            lastName = (string)reader["LastName"];
                            userName = (string)reader["Username"];
                            password = (string)reader["Password"];

                            if (reader["DateOfBirth"] != DBNull.Value)
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                            else
                                dateOfBirth = DateTime.Now;

                            gender = (byte)reader["Gender"];
                            email = (string)reader["Email"];

                            if (reader["address"] != DBNull.Value)
                                address = (string)reader["Address"];
                            else
                                address = "";

                            if (reader["imagePath"] != DBNull.Value)
                                imagePath = (string)reader["imagePath"];
                            else
                                imagePath = "";

                            role = (byte)reader["Role"];
                        }
                        else
                        {
                            isFound = false;
                        }
                        reader.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                isFound = false;
            }



           return isFound;
        }


        public static bool GetUserByUserName(string userName , ref int userID, ref string firstName, ref string lastName, ref string password
                   , ref DateTime dateOfBirth, ref short gender, ref string email, ref string address, ref string imagePath, ref short role)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spUser_GetUserByUsername", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", userName);


                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            firstName = (string)reader["FirstName"];
                            lastName = (string)reader["LastName"];
                            userID = (int)reader["ID"];
                            password = (string)reader["Password"];

                            if (reader["DateOfBirth"] != DBNull.Value)
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                            else
                                dateOfBirth = DateTime.Now;

                            gender = (byte)reader["Gender"];
                            email = (string)reader["Email"];

                            if (reader["address"] != DBNull.Value)
                                address = (string)reader["Address"];
                            else
                                address = "";

                            if (reader["imagePath"] != DBNull.Value)
                                imagePath = (string)reader["imagePath"];
                            else
                                imagePath = "";

                            role = (byte)reader["Role"];
                        }
                        else
                        {
                            isFound = false;
                        }
                        reader.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                isFound = false;
            }



            return isFound;
        }



        public static bool GetUserByUserNameAndPassword( string userName, string password, ref int userID ,ref string firstName,
            ref string lastName , ref DateTime dateOfBirth, ref short gender, ref string email, ref string address, ref string imagePath, ref short role)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("spUser_GetUserByUserNameAndPassword", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            userID = (int)reader["ID"];
                            firstName = (string)reader["FirstName"];
                            lastName = (string)reader["LastName"];
                            if (reader["DateOfBirth"] != DBNull.Value)
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                            else
                                dateOfBirth = DateTime.Now;

                            gender = (byte)reader["Gender"];
                            email = (string)reader["Email"];

                            if (reader["address"] != DBNull.Value)
                                address = (string)reader["Address"];
                            else
                                address = "";

                            if (reader["imagePath"] != DBNull.Value)
                                imagePath = (string)reader["imagePath"];
                            else
                                imagePath = "";

                            role = (byte)reader["Role"];
                        }
                        else
                        {
                            isFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                        isFound = false;
                        //Console.WriteLine(ex.Message); 
                    }
                }
            }


            return isFound;
        }

        public static int AddNewUser( string firstName,  string lastName,  string userName,  string password , DateTime dateOfBirth,
                                                  short gender,  string email, string address, string imagePath, short role)
        {
            int userID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    
                    using (SqlCommand command = new SqlCommand("spUser_InsertUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@username", userName);
                        command.Parameters.AddWithValue("@password", password);

                        if (dateOfBirth != null)
                            command.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                        else
                            command.Parameters.AddWithValue("@dateOfBirth", System.DBNull.Value);

                        command.Parameters.AddWithValue("@gender", gender);
                        command.Parameters.AddWithValue("@email", email);


                        if (address != "" && address != null)
                            command.Parameters.AddWithValue("@address", address);
                        else
                            command.Parameters.AddWithValue("@address", System.DBNull.Value);

                        if (imagePath != "" && imagePath != null)
                            command.Parameters.AddWithValue("@imagePath", imagePath);
                        else
                            command.Parameters.AddWithValue("@imagePath", System.DBNull.Value);


                        command.Parameters.AddWithValue("@role", role);

                        SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        userID = (int)command.Parameters["@NewUserID"].Value;

                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return userID;
        }

        public static bool UpdateUser(int userID,string firstName, string lastName, string userName, string password, DateTime dateOfBirth,
                                                  short gender, string email, string address, string imagePath, short role)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spUser_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", userID);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Username", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        if (dateOfBirth != null)
                            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        else
                            command.Parameters.AddWithValue("@DateOfBirth", System.DBNull.Value);

                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Email", email);


                        if (address != "" && address != null)
                            command.Parameters.AddWithValue("@Address", address);
                        else
                            command.Parameters.AddWithValue("@Address", System.DBNull.Value);

                        if (imagePath != "" && imagePath != null)
                            command.Parameters.AddWithValue("@ImagePath", imagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


                        command.Parameters.AddWithValue("@Role", role);


                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteUser(int userID)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spUser_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", userID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }


        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spUser_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                //Console.WriteLine(ex.Message); 
            }

            return dt;
        }

        public static bool IsUserExist(int userID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spUser_CheckUserExists", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)userID ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        command.ExecuteNonQuery();

                        isFound = (int)returnParameter.Value == 1;

                        Console.WriteLine($" Person Exist   {isFound}");

                        connection.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                isFound = false;
                //Console.WriteLine($" Person doesn't Exist   {ex.Message}");
            }
            return isFound;
        }

        public static bool CheckUserExistsByUserName(string UserName)
        {
            bool UserNameExists=false;
            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spUser_CheckUserExistsByUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", (object)UserName ?? DBNull.Value);

                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };

                        command.Parameters.Add(returnParameter);
                        command.ExecuteNonQuery();

                        UserNameExists = (int)returnParameter.Value == 1;

                        Console.WriteLine($" Person Exist   {UserNameExists}");

                        connection.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                //Console.WriteLine($" Person doesn't Exist   {ex.Message}");
            }

            return UserNameExists;
        }

    }
}
