using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccessLayer
{
    public class StudentAnswerHistoryDataAccess
    {
        public static int AddNewStudentAnswerHistory(int StudentID, int ExamID, int QuestionID, string ChosenOption, bool IsCorrect 
            , string ActionType, DateTime Timestamp, int ResultID)
        {
            int HistoryID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswerHistory_InsertStudentAnswerHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);
                        command.Parameters.AddWithValue("@ChosenOption", ChosenOption);
                        command.Parameters.AddWithValue("@IsCorrect", IsCorrect);
                        command.Parameters.AddWithValue("@ActionType", ActionType);
                        command.Parameters.AddWithValue("@Timestamp", Timestamp);
                        command.Parameters.AddWithValue("@ResultId", ResultID);

                        SqlParameter outputIdParam = new SqlParameter("@NewHistoryID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);
                        connection.Open();

                        command.ExecuteNonQuery();

                        HistoryID = (int)command.Parameters["@NewHistoryID"].Value;

                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return HistoryID;
        }


        public static bool UpdateStudentAnswerHistory(int HistoryID,int StudentID, int ExamID, int QuestionID, string ChosenOption, bool IsCorrect
            , string ActionType, DateTime Timestamp, int ResultID)
        {
            int RowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(SettingDataAccess.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("spStudentAnswerHistory_UpdateStudentAnswerHistory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@HistoryID", HistoryID);
                        command.Parameters.AddWithValue("@StudentId", StudentID);
                        command.Parameters.AddWithValue("@ExamId", ExamID);
                        command.Parameters.AddWithValue("@QuestionId", QuestionID);
                        command.Parameters.AddWithValue("@ChosenOption", ChosenOption);
                        command.Parameters.AddWithValue("@IsCorrect", IsCorrect);
                        command.Parameters.AddWithValue("@ActionType", ActionType);
                        command.Parameters.AddWithValue("@Timestamp", Timestamp);
                        command.Parameters.AddWithValue("@ResultId", ResultID);

                        connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { clsEventLogger.LogExceptions(ex, EventLogEntryType.Error); }

            return (RowsAffected > 0);
        }


    }
}
