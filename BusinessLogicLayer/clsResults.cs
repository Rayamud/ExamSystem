using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsResults
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ResultID {  get; set; }
        public int StudentID { get; set; }
        public clsUser StudentInfo;
        public int ExamID { get; set; }
        public clsExam ExamInfo;
        public int Score { get; set; }
        public DateTime SubmissionDate { get; set; }

        public clsResults()
        {
            this.ResultID = -1;
            this.StudentID = -1;
            this.ExamID = -1;
            this.Score = 0;
            this.SubmissionDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsResults(int resultID, int studentID, int examID, int score, DateTime submissionDate)
        {
            this.ResultID = resultID;
            this.StudentID = studentID;
            this.StudentInfo = clsUser.Find(studentID);
            this.ExamID = examID;
            this.ExamInfo = clsExam.Fine(examID);
            this.Score = score;
            this.SubmissionDate = submissionDate;

            Mode = enMode.Update;
        }

        public static clsResults Find (int ResultID)
        {
            int StudentId = -1, ExamId = -1;
            int Score = 0;
            DateTime SubmissionDate = DateTime.Now;

            bool isFound = ResultsDataAccess.GetResultsById(ResultID, ref StudentId, ref ExamId, ref Score, ref SubmissionDate);

            if (isFound)
            {
                return new clsResults(ResultID, StudentId, ExamId, Score, SubmissionDate);
            }
            else
                return null;
        }

        public static clsResults FindByStudentIDAndExamID(int StudentId, int ExamId)
        {
            int ResultID = -1; 
            int Score = 0;
            DateTime SubmissionDate = DateTime.Now;

            bool isFound = ResultsDataAccess.GetResultsByStudentIdAndExamId(StudentId, ExamId, ref ResultID,  ref Score, ref SubmissionDate);

            if (isFound)
            {
                return new clsResults(ResultID, StudentId, ExamId, Score, SubmissionDate);
            }
            else
                return null;
        }

        private bool _AddNewResult ()
        {
            this.ResultID = ResultsDataAccess.AddNewResults(this.StudentID,this.ExamID, this.Score, this.SubmissionDate);

            return (this.ResultID != -1);
        }

        private bool _UpdateResult()
        {
            return ResultsDataAccess.UpdateResults(this.ResultID, this.StudentID, this.ExamID, this.Score, this.SubmissionDate);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewResult())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateResult();
            }
            return false;
        }

        public static bool DeleteResult(int ResultID)
        {
            return ResultsDataAccess.DeleteResults(ResultID);
        }

        public static DataTable GetAllResults()
        {
            return ResultsDataAccess.GetAllResults();
        }
    }
}
