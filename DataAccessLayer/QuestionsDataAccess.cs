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
    public class QuestionsDataAccess
    {
        public static bool GetQuestionByID(int QuestionID, ref int ExamID, ref string Subject,ref string QuestionText, ref string OptionA, ref string OptionB,
            ref string OptionC, ref string OptionD, ref string CorrectOption)
        {
            bool isFound = false;
            try
            {
                using(SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("spQuestions_GetQuestionsById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;

                            ExamID = (int)reader["ExamId"];
                            Subject = (string)reader["Subject"];
                            QuestionText = (string)reader["QuestionText"];
                            OptionA = (string)reader["OptionA"];
                            OptionB = (string)reader["OptionB"];
                            OptionC = (string)reader["OptionC"];
                            OptionD = (string)reader["OptionD"];
                            CorrectOption = (string)reader["CorrectOption"];
                        }
                        else
                        {
                            isFound = false;
                        }
                        reader.Close();
                    }
                }
            }
            catch(Exception ex) 
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                isFound =false;
            }


            return isFound;
        }


        public static bool GetQuestionByExamID(int ExamID, ref int QuestionID, ref string Subject, ref string QuestionText, ref string OptionA, ref string OptionB,
           ref string OptionC, ref string OptionD, ref string CorrectOption)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_GetQuestionsByExamId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ExamId", ExamID);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            isFound = true;

                            QuestionID = (int)reader["QuestionID"];
                            Subject = (string)reader["Subject"];
                            QuestionText = (string)reader["QuestionText"];
                            OptionA = (string)reader["OptionA"];
                            OptionB = (string)reader["OptionB"];
                            OptionC = (string)reader["OptionC"];
                            OptionD = (string)reader["OptionD"];
                            CorrectOption = (string)reader["CorrectOption"];
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


        public static int AddNewQuestion(int ExamID, string Subject, string QuestionText, string OptionA, string OptionB,
                                          string OptionC, string OptionD, string CorrectOption)
        {
            int QuestionID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using(SqlCommand command = new SqlCommand("spQuestions_InsertQuestions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@Subject", Subject);
                        command.Parameters.AddWithValue("@QuestionText", QuestionText);
                        command.Parameters.AddWithValue("@OptionA", OptionA);
                        command.Parameters.AddWithValue("@OptionB", OptionB);
                        command.Parameters.AddWithValue("@OptionC", OptionC);
                        command.Parameters.AddWithValue("@OptionD", OptionD);
                        command.Parameters.AddWithValue("@CorrectOption", CorrectOption);

                        SqlParameter outputIdParam = new SqlParameter("@NewQuestionID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        
                        command.Parameters.Add(outputIdParam);
                        connection.Open();
                        command.ExecuteNonQuery();

                        QuestionID = (int)command.Parameters["@NewQuestionID"].Value;
                    }
                }
            }
            catch(Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return QuestionID;
        }

        public static bool UpdateQuestion(int QuestionID,int ExamID, string Subject, string QuestionText, string OptionA, string OptionB,
                                          string OptionC, string OptionD, string CorrectOption)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_UpdateQuestions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@QuestionId", QuestionID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@Subject", Subject);
                        command.Parameters.AddWithValue("@QuestionText", QuestionText);
                        command.Parameters.AddWithValue("@OptionA", OptionA);
                        command.Parameters.AddWithValue("@OptionB", OptionB);
                        command.Parameters.AddWithValue("@OptionC", OptionC);
                        command.Parameters.AddWithValue("@OptionD", OptionD);
                        command.Parameters.AddWithValue("@CorrectOption", CorrectOption);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }


            return (RowsAffected > 0);
        }

        public static bool DeleteQuestion(int QuestionID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_DeleteQuestions", connection))
                    {
                        command.CommandType= CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);

                        connection.Open();

                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return (RowsAffected > 0);
        }

        public static DataTable GetAllQuestions()
        {
            DataTable dt = new DataTable();

            try
            {
                using(SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_GetAllQuestions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
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
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }

            return dt;
        }

        public static DataTable GetAllQuestionsByExamID(int examID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_GetQuestionsByExamId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ExamId",examID);
                        

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


        public static int GetQuestionCountByExamId(int examId)
        {
            int questionCount = 0; // Default value

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spQuestions_GetQuestionCountByExamId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ExamId", examId);

                        connection.Open();

                        // ExecuteScalar() is perfect for retrieving a single value (like COUNT, SUM, MAX, etc.)
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            questionCount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
            }
            return questionCount;
        }

    }
}
