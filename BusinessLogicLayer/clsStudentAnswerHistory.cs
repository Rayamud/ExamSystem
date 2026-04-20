using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsStudentAnswerHistory
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int HistoryID { get; set; }
        public int StudentID { get; set; }
        public clsUser StudentInfo;

        public int ExamID { get; set; }
        public clsExam ExamInfo;

        public int QuestionID { get; set; }
        public clsQuestions QuestionInfo;

        public string ChosenOption { get; set; }
        public bool IsCorrect { get; set; }
        public string ActionType { get; set; }
        public DateTime Timestamp { get; set; }
        public int ResultID { get; set; }
        public clsResults ResultInfo;


        public clsStudentAnswerHistory()
        {
            this.HistoryID = -1;
            this.StudentID = -1;
            this.ExamID = -1;
            this.QuestionID = -1;
            this.ChosenOption = "";
            this.IsCorrect = false;
            this.ActionType = "";
            this.Timestamp = DateTime.Now;
            this.ResultID = -1;

            Mode = enMode.AddNew;   
        }

        public clsStudentAnswerHistory(int historyID, int studentID, clsUser studentInfo, int examID, clsExam examInfo, int questionID, clsQuestions questionInfo, string chosenOption, bool isCorrect, string actionType, DateTime timestamp, int resultID, clsResults resultInfo)
        {
            this.HistoryID = historyID;
            this.StudentID = studentID;
            this.StudentInfo = clsUser.Find(studentID);
            this.ExamID = examID;
            this.ExamInfo = clsExam.Fine(examID);
            this.QuestionID = questionID;
            this.QuestionInfo= clsQuestions.Find(questionID);
            this.ChosenOption = chosenOption;
            this.IsCorrect = isCorrect;
            this.ActionType = actionType;
            this.Timestamp = timestamp;
            this.ResultID = resultID;
            this.ResultInfo = clsResults.Find(resultID);

            Mode = enMode.Update;
        }


        private bool _AddNewStudentAnswerHistory()
        {
            this.HistoryID = StudentAnswerHistoryDataAccess.AddNewStudentAnswerHistory(this.StudentID,this.ExamID,this.QuestionID,
                this.ChosenOption, this.IsCorrect, this.ActionType, this.Timestamp, this.ResultID);

            return (this.HistoryID != -1);
        }

        private bool _UpdateStudentAnswerHistory()
        {
            return StudentAnswerHistoryDataAccess.UpdateStudentAnswerHistory(this.HistoryID, this.StudentID, this.ExamID, this.QuestionID,
                this.ChosenOption, this.IsCorrect, this.ActionType, this.Timestamp, this.ResultID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewStudentAnswerHistory())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateStudentAnswerHistory();
            }   
            return false;
        }
    }
}
