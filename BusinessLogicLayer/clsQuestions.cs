using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsQuestions
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enOptions { A = 1, B = 2 , C = 3 , D = 4 }

        public int QuestionID {  get; set; }
        public int ExamId { get; set; }
        public clsExam ExamIDInfo;
        public string Subject { get; set; }
        public string QuestionText { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectOption {  get; set; }

        //public string CorrectOptionText
        //{
        //    get
        //    {
        //        switch(CorrectOption)
        //        {
        //            case enOptions.A:
        //                return "Option A";
        //            case enOptions.B:
        //                return "Option B";
        //            case enOptions.C:
        //                return "Option C";
        //            case enOptions.D:
        //                return "Option D";
        //            default:
        //                return "UnKown";
        //        }
        //    }
        //}

        public clsQuestions()
        {
            this.QuestionID = -1;
            this.ExamId = -1;
            this.Subject = "";
            this.QuestionText = "";
            this.OptionA = "";
            this.OptionB = "";
            this.OptionC = "";
            this.OptionD = "";
            this.CorrectOption = "";

            Mode = enMode.AddNew;
        }

        public clsQuestions(int questionID, int examId ,string subject, string questionText, string optionA, string optionB, 
            string optionC, string optionD, string correctOption)
        {
            this.QuestionID = questionID;
            this.ExamId = examId;
            this.Subject = subject;
            this.ExamIDInfo = clsExam.Fine(examId);
            this.QuestionText = questionText;
            this.OptionA = optionA;
            this.OptionB = optionB;
            this.OptionC = optionC;
            this.OptionD = optionD;
            this.CorrectOption = correctOption;

            Mode = enMode.Update;
        }

        public static clsQuestions Find(int  questionID)
        {
            int examID = -1; string subject = "";
            string questionText = "", optionA = "", optionB = "", optionC = "", optionD = "";
            string correctOption = "";

            bool isFound = QuestionsDataAccess.GetQuestionByID(questionID, ref examID, ref subject,ref questionText, ref optionA, ref optionB, ref optionC
                , ref optionD, ref correctOption);

            if (isFound)
            {
                return new clsQuestions(questionID, examID, subject,questionText, optionA, optionB, optionC, optionD,correctOption);
            }
            else
                return null;
        }

        public static clsQuestions FindByExamID(int examID)
        {
            int questionID = -1; string subject = "";
            string questionText = "", optionA = "", optionB = "", optionC = "", optionD = "";
            string correctOption = "";

            bool isFound = QuestionsDataAccess.GetQuestionByExamID(examID, ref questionID,   ref subject, ref questionText, ref optionA, ref optionB, ref optionC
                , ref optionD, ref correctOption);

            if (isFound)
            {
                return new clsQuestions(questionID, examID, subject, questionText, optionA, optionB, optionC, optionD, correctOption);
            }
            else
                return null;
        }

        private bool _AddNewQuestion()
        {
            this.QuestionID = QuestionsDataAccess.AddNewQuestion(this.ExamId, this.Subject,this.QuestionText ,this.OptionA,this.OptionB, this.OptionC,
                this.OptionD, this.CorrectOption);

            return (this.QuestionID != -1);
        }

        private bool _UpdateQuestion()
        {
            return QuestionsDataAccess.UpdateQuestion(this.QuestionID, this.ExamId, this.Subject,this.QuestionText, this.OptionA, this.OptionB,
                this.OptionC, this.OptionD, this.CorrectOption);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewQuestion())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateQuestion();
            }
            return false;
        }

        public static bool DeleteQuestion(int questionID)
        {
            return QuestionsDataAccess.DeleteQuestion(questionID);
        }

        public static DataTable GetAllQuestions()
        {
            return QuestionsDataAccess.GetAllQuestions();
        }

        public static DataTable GetAllQuestionsByExamID(int examID)
        {
            return QuestionsDataAccess.GetAllQuestionsByExamID(examID);
        }

        public static int GetQuestionCountByExamId(int examId)
        {
            return QuestionsDataAccess.GetQuestionCountByExamId(examId);
        }
    }
}
