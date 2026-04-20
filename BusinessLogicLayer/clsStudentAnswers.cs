using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsStudentAnswers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int AnswerID { get; set; }
        public int StudentID { get; set; }
        public clsUser StudentIDInfo;
        public int ExamID { get; set; }
        public clsExam ExamIDInfo;
        public int QuestionID { get; set; }
        public clsQuestions QuestionIDInfo;

        public string ChosenOption { get; set; }
        public DateTime AnswerTime { get; set; }

        public clsStudentAnswers()
        {
            this.AnswerID = -1;
            this.StudentID = -1;
            this.ExamID = -1;
            this.QuestionID = -1;
            this.ChosenOption = "";
            this.AnswerTime = DateTime.Now;

            Mode = enMode.AddNew;
        }

        public clsStudentAnswers(int answerID, int studentID, int examID, int questionID, string chosenOption,
            DateTime answerTime)
        {
            this.AnswerID = answerID;
            this.StudentID = studentID;
            this.StudentIDInfo = clsUser.Find(studentID);
            this.ExamID = examID;
            this.ExamIDInfo = clsExam.Fine(examID);
            this.QuestionID = questionID;
            this.QuestionIDInfo = clsQuestions.Find(questionID);
            this.ChosenOption = chosenOption;
            this.AnswerTime = answerTime;

            Mode = enMode.Update;
        }

        public static clsStudentAnswers Find(int AnswerId)
        {
            int studentID = -1, examID = -1, questionID = -1;
            string chosenOption = "";
            DateTime answerTime = DateTime.Now;

            bool isFound = StudentAnswersDataAccess.GetStudentAnswerById(AnswerId, ref studentID, ref examID, ref  questionID, 
                ref chosenOption,ref answerTime);

            if (isFound)
            {
                return new clsStudentAnswers(AnswerId, studentID, examID, questionID, chosenOption, answerTime);
            }
            else
                return null;
        }

        private bool _AddNewStudentAnswer()
        {
            this.AnswerID = StudentAnswersDataAccess.AddNewStudentAnswer(this.StudentID, this.ExamID, this.QuestionID, this.ChosenOption
                , this.AnswerTime);

            return (this.AnswerID != -1);
        }

        private bool _UpdateStudentAnswer()
        {
            return StudentAnswersDataAccess.UpdateStudentAnswer(this.AnswerID, this.StudentID,this.ExamID, this.QuestionID, this.ChosenOption
                ,this.AnswerTime);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudentAnswer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateStudentAnswer();
            } 
            return false;
        }

        public static bool DeleteStudentAnswer(int answerID)
        {
            return StudentAnswersDataAccess.DeleteStudentAnswer(answerID);
        }

        public static bool DeleteStudentAnswerByStudentIDAndExamID(int studentID, int examID)
        {
            return StudentAnswersDataAccess.DeleteStudentAnswerByStudentIDAndExamID(studentID, examID);
        }

        public static DataTable GetAllStudentAnswers()
        {
            return StudentAnswersDataAccess.GetAllStudentAnswers();
        }

        public static DataTable GetAllStudentAnswerByStudentIdAndExamId(int studentID, int examID)
        {
            return StudentAnswersDataAccess.GetAllStudentAnswerByStudentIdAndExamId(studentID, examID);
        }
    }
}
