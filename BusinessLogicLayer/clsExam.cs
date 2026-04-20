using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsExam
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ExamID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsExam()
        {
            this.ExamID = -1;
            this.Title = "";
            this.Description = "";
            this.CreatedDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsExam(int examID, string title, string description, DateTime createdDate)
        {
            this.ExamID = examID;
            this.Title = title;
            this.Description = description;
            this.CreatedDate = createdDate;

            Mode = enMode.Update;
        }

        public static clsExam Fine (int examID)
        {
            string title = "", Description = "";
            DateTime createdDate = DateTime.Now;

            bool isFound = ExamsDataAccess.GetExamByID(examID, ref title, ref Description, ref createdDate);

            if (isFound)
            {
                return new clsExam(examID, title, Description, createdDate);
            }
            else
                return null;
        }

        private bool _AddNew()
        {
            this.ExamID = ExamsDataAccess.AddNewExam(this.Title, this.Description, this.CreatedDate);   
            return (this.ExamID != -1);
        }

        private bool _Update()
        {
            return ExamsDataAccess.UpdateExam(this.ExamID, this.Title, this.Description, this.CreatedDate); 
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool Delete(int examID)
        {
            return ExamsDataAccess.DeleteExam(examID);
        }


        public static DataTable GetAllExams()
        {
            return ExamsDataAccess.GetAllExams();
        }

    }
}
