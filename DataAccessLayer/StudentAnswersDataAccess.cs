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
    public class StudentAnswersDataAccess
    {
        public static bool GetStudentAnswerById(int AnswerID, ref int StudentID, ref int ExamID, ref int QuestionID, ref string ChosenOption
            , ref DateTime AnswerTime)
        {
            bool isFound = false;

            try
            {
                using(SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_GetStudentAnswersById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AnswerId", AnswerID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if(reader.Read())
                        {
                            isFound = true;
                            StudentID = (int)reader["StudentId"];
                            ExamID = (int)reader["ExamId"];
                            QuestionID = (int)reader["QuestionId"];
                            ChosenOption = (string)reader["ChosenOption"];

                            AnswerTime = (DateTime)reader["AnswerTime"];
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

        
        public static int AddNewStudentAnswer(int StudentID, int ExamID, int QuestionID, string ChosenOption, DateTime AnswerTime)
        {
            int AnswerID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_InsertStudentAnswers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);
                        command.Parameters.AddWithValue("@ChosenOption", ChosenOption);
                        command.Parameters.AddWithValue("@AnswerTime", AnswerTime);

                        SqlParameter outputIdParam = new SqlParameter("@NewAnswerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);
                        connection.Open();

                        command.ExecuteNonQuery();

                        AnswerID = (int)command.Parameters["@NewAnswerID"].Value;

                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return AnswerID;
        }

        public static bool UpdateStudentAnswer(int AnswerID,int StudentID, int ExamID, int QuestionID, string ChosenOption, DateTime AnswerTime)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_UpdateStudentAnswers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AnswerID", AnswerID);
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);
                        command.Parameters.AddWithValue("@ChosenOption", ChosenOption);
                        command.Parameters.AddWithValue("@AnswerTime", AnswerTime);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return (RowsAffected > 0);
        }

        public static bool DeleteStudentAnswer(int AnswerID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_DeleteStudentAnswers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AnswerID", AnswerID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return (RowsAffected > 0);
        }

        public static bool DeleteStudentAnswerByStudentIDAndExamID(int StudentID, int ExamID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_DeleteStudentAnswersByStudentIDAndExamID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllStudentAnswers()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_GetAllStudentAnswers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader reader = command.ExecuteReader();
                        if(reader.HasRows)
                        {
                            dt.Load(reader);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return dt;
        }

        public static DataTable GetAllStudentAnswerByStudentIdAndExamId(int StudentID, int ExamID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswers_GetStudentAnswersByStudentIDAndExamID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);

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
            }



            return dt;
        }
    }
}
