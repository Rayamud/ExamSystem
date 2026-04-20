using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ExamsDataAccess
    {
        public static bool GetExamByID(int ExamID, ref string Title, ref string Description , ref DateTime CreatedDate)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spExam_GetExamById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ExamID", ExamID);


                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            Title = (string)reader["Title"];
                            
                            CreatedDate = (DateTime)reader["CreatedDate"];

                            if (reader["Description"] != DBNull.Value)
                                Description = (string)reader["Description"];
                            else
                                Description = "";

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

        public static int AddNewExam(string Title, string Description, DateTime CreatedDate)
        {
            int ExamID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spExam_InsertExam", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Title", Title);
                        
                        command.Parameters.AddWithValue("@CreatedDate", CreatedDate);



                        if (Description != "" && Description != null)
                            command.Parameters.AddWithValue("@Description", Description);
                        else
                            command.Parameters.AddWithValue("@Description", System.DBNull.Value);


                        SqlParameter outputIdParam = new SqlParameter("@NewExamID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        ExamID = (int)command.Parameters["@NewExamID"].Value;

                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return ExamID;
        }

        public static bool UpdateExam (int ExamID, string Title, string Description, DateTime CreatedDate)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spExam_UpdateExam", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ExamID", ExamID);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                        if (Description != "" && Description != null)
                            command.Parameters.AddWithValue("@Description", Description);
                        else
                            command.Parameters.AddWithValue("@Description", System.DBNull.Value);


                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();

                        //connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }

        public static bool DeleteExam(int ExamID)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spExam_DeleteExam", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ExamID", ExamID);

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

        public static DataTable GetAllExams()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spExam_GetAllExams", connection))
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
    }
}
