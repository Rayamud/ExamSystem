using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ResultsDataAccess
    {
        public static bool GetResultsById(int ResultID, ref int StudentID, ref int ExamID, ref int Score, ref DateTime SubmissionDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spResults_GetResultsById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ResultID", ResultID);


                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            StudentID = (int)reader["StudentId"];
                            ExamID = (int)reader["ExamId"];
                            Score = (int)reader["Score"];
                            SubmissionDate = (DateTime)reader["SubmissionTime"];

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


        public static bool GetResultsByStudentIdAndExamId(int StudentID, int ExamID, ref int ResultID, ref int Score, ref DateTime SubmissionDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spResults_GetResultsByStudentIDAndExamID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            ResultID = (int)reader["ResultID"];
                            Score = (int)reader["Score"];
                            SubmissionDate = (DateTime)reader["SubmissionTime"];

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

        public static int AddNewResults(int StudentID, int ExamID, int Score, DateTime SubmissionDate)
        {
            int ResultID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spResults_InsertResults", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@Score", Score);
                        command.Parameters.AddWithValue("@SubmissionTime", SubmissionDate);


                        SqlParameter outputIdParam = new SqlParameter("@NewResultID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();

                        command.ExecuteNonQuery();

                        ResultID = (int)command.Parameters["@NewResultID"].Value;

                        connection.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return ResultID;
        }

        public static bool UpdateResults(int ResultID, int StudentID, int ExamID, int Score, DateTime SubmissionDate)
        {
            int RowsAffected = 0;
            try
            {

                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("spResults_UpdateResults", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ResultId", ResultID); 
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@Score", Score);
                        command.Parameters.AddWithValue("@SubmissionTime", SubmissionDate);


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

        public static bool DeleteResults(int ResultID)
        {
            int RowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spResults_DeleteResults", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ResultID", ResultID);

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

        public static DataTable GetAllResults()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spResults_GetAllResults", connection))
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
