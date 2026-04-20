using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam_System_App
{
    public partial class frmTakeExam : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        private int _ExamID;
       // private clsQuestions _Questions;
        //private clsExam _Exam;

        private clsResults _result;

        private int _currentQuestionIndex = 0;

        private string _ChosenOptionToCheck = "";

        private Dictionary<int, string> _studentAnswer = new Dictionary<int, string>();
        // Key: QuestionId (int)
        // Value: Chosen Option (string, e.g., "A", "B", "C", "D", or "" if unanswered)

        public frmTakeExam(int examID)
        {
            InitializeComponent();
            _ExamID = examID;

            _result = clsResults.FindByStudentIDAndExamID( clsGlobal.CurrentUser.UserID, _ExamID);
            if (_result != null)
            {
                Mode = enMode.Update;
                this.Text = "Review/Update Exam:";
               
                LoadPreviousAnswersIntoDictionary();
            }
            else
            {
                Mode = enMode.AddNew;
                this.Text = "Take New Exam: ";

                btnSubmit.Enabled = false;
            }

            
        }

        

        //convert studentAnswer from datatable to list
        public List<clsStudentAnswers> GetAllStudentAnswerByStudentAndExam()
        {
            List<clsStudentAnswers> studentAnswerList = new List<clsStudentAnswers>();

            DataTable dtstudentAnswer = clsStudentAnswers.GetAllStudentAnswerByStudentIdAndExamId(clsGlobal.CurrentUser.UserID, _ExamID);

            foreach (DataRow row in dtstudentAnswer.Rows)
            {
                clsStudentAnswers studentAnswer = new clsStudentAnswers();

                studentAnswer.AnswerID = Convert.ToInt32(row["AnswerID"]);
                studentAnswer.StudentID = Convert.ToInt32(row["StudentId"]);
                studentAnswer.ExamID = Convert.ToInt32(row["ExamId"]);
                studentAnswer.QuestionID = Convert.ToInt32(row["QuestionId"]);
                //question.ExamIDInfo.Title = row["Title"].ToString();
                studentAnswer.ChosenOption = row["ChosenOption"].ToString();
                studentAnswer.AnswerTime = Convert.ToDateTime(row["AnswerTime"]);


                studentAnswerList.Add(studentAnswer);
            }
            return studentAnswerList;
        }

        //put the questionID and ChosenOption of Student that answer in dictionary _studentAnswer
        private void LoadPreviousAnswersIntoDictionary()
        {
            _studentAnswer.Clear();
            List<clsStudentAnswers> studentAnswerList = GetAllStudentAnswerByStudentAndExam();
             
            foreach(var studentAnswer in studentAnswerList)
            {
                _studentAnswer[studentAnswer.QuestionID] = studentAnswer.ChosenOption ?? "";

               // _ChosenOptionToCheck = studentAnswer.ChosenOption;
                
            }

            
        }


        public List<clsQuestions> GetAllQuestions()
        {
            List<clsQuestions> questionList = new List<clsQuestions>();

            DataTable dtQuestion = clsQuestions.GetAllQuestionsByExamID(_ExamID);

            foreach (DataRow row in dtQuestion.Rows)
            {
                clsQuestions question = new clsQuestions();

                question.QuestionID = Convert.ToInt32(row["QuestionID"]);
                //question.ExamIDInfo.Title = row["Title"].ToString();
                question.QuestionText = row["QuestionText"].ToString();
                question.OptionA = row["OptionA"].ToString();
                question.OptionB = row["OptionB"].ToString();
                question.OptionC = row["OptionC"].ToString();
                question.OptionD = row["OptionD"].ToString();
                question.CorrectOption = row["CorrectOption"].ToString();
                
                questionList.Add(question);
            }
            return questionList;
        }



        private void frmTakeExam_Load(object sender, EventArgs e)
        {
            //_Questions = clsQuestions.FindByExamID(_ExamID);
            try
            {
                List<clsQuestions> questionList = GetAllQuestions();

                foreach (var item in questionList)
                {
                    ctrlTakeExam takeExam = new ctrlTakeExam();

                    if(Mode == enMode.Update && _studentAnswer.TryGetValue(item.QuestionID, out _ChosenOptionToCheck) )//_studentAnswer[item.QuestionID] == item.CorrectOption
                    {//_isUpdateMode && _userAnswers.TryGetValue(currentQuestion.QuestionId, out previousChosenOption)
                        if(_studentAnswer[item.QuestionID] == item.CorrectOption)
                        {
                            //_ChosenOptionToCheck = _studentAnswer[item.QuestionID];
                            takeExam.SetSelectedOption(_ChosenOptionToCheck);
                            takeExam.ControlEnable = false;
                            //btnSubmit.Enabled = true;
                        }
                    }
                    else
                    {
                        takeExam.SetSelectedOption("U");
                        //btnSubmit.Enabled = true;
                    }
                    // --- SUBSCRIBE TO THE NEW EVENT FOR EACH QUESTION CONTROL for radioButton ckecked ---
                    takeExam.AnswerSelectionChanged += QuestionControl_AnswerSelectionChanged;

                    flPanel.Controls.Add(takeExam);
                    takeExam.LoadQuestions(item.QuestionID, _currentQuestionIndex++);

                    btnShowResult.Visible = false;
                   

                }
            }
            catch (Exception ex)
            {
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                MessageBox.Show($"Error loading exams: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- New Event Handler for AnswerSelectionChanged ---
        private void QuestionControl_AnswerSelectionChanged(object sender, EventArgs e)
        {
            ctrlTakeExam changedControl = sender as ctrlTakeExam;
            if (changedControl != null)
            {
                // Update the _userAnswers dictionary with the latest selection from this specific control
                _studentAnswer[changedControl.QuestionID] = changedControl.SelectedOption; // Assuming SelectedOption returns a char or first char of string
            }

            // Re-evaluate the submit button state
            UpdateSubmitButtonState();
        }

        private void UpdateSubmitButtonState()
        {
            // If it's a new attempt, enable the button only if at least one question has been answered.
            bool anyQuestionAnswered = false;
            List<clsQuestions> questionList = GetAllQuestions();
            foreach (var question in questionList)
            {
                // Check if the question is in _userAnswers AND its value is not "U"
                if (_studentAnswer.ContainsKey(question.QuestionID) && _studentAnswer[question.QuestionID] != "U")
                {
                    anyQuestionAnswered = true;
                    break;
                }
            }
            btnSubmit.Enabled = anyQuestionAnswered;
        }


        //
        private void _HandleCollectStudentAnswers()
        {
            //collect student answers into _userAnswers dictionary
            
            foreach (Control control in flPanel.Controls)
            {
                if (control is ctrlTakeExam takeExam)
                {
                    int questionID = takeExam.QuestionID;
                    string chosenOption = takeExam.SelectedOption;

                    if (_studentAnswer.ContainsKey(questionID))
                    {
                        _studentAnswer[questionID] = chosenOption;
                    }
                    else
                    {
                        _studentAnswer.Add(questionID, chosenOption);
                    }
                }
            }

        }


        clsStudentAnswers StudentAnswer;
        List<clsStudentAnswers> existingAnswersList;
        private void _HandleSaveStudentAnswer()
        {
            List<clsQuestions> questionList = GetAllQuestions();

            existingAnswersList = GetAllStudentAnswerByStudentAndExam();
            Dictionary<int, clsStudentAnswers> existingAnswersMap = existingAnswersList.ToDictionary(sa => sa.QuestionID);

            //Save Student Answer
            foreach (clsQuestions question in questionList)
            {
                string chosenOption = "";
                //if (_studentAnswer.ContainsKey(question.QuestionID))
                //{
                //    chosenOption = _studentAnswer[question.QuestionID];
                //}

                if (_studentAnswer.TryGetValue(question.QuestionID, out chosenOption))
                {
                    chosenOption = _studentAnswer.ContainsKey(question.QuestionID) ? _studentAnswer[question.QuestionID] : "U";
                }



                

                if (existingAnswersMap.TryGetValue(question.QuestionID, out clsStudentAnswers existingAnswer))
                {
                    // --- Scenario: Answer already exists in the database for this question ---

                    // Check if the newly submitted answer is different from the saved one
                    // OR if the saved answer was incorrect and the new one might be correct
                    if (existingAnswer.ChosenOption != chosenOption)
                    {
                        // The answer has changed OR its correctness status has changed.
                        // UPDATE the existing record.
                        //UpdateStudentAnswer(existingAnswer.AnswerId, newChosenOption, newIsCorrect);
                        Mode = enMode.Update;
                        StudentAnswer.ChosenOption = chosenOption;
                        StudentAnswer.AnswerTime = DateTime.Now;

                        if (StudentAnswer.Save())
                        {
                            MessageBox.Show("your Anser Saved Successfully of Exam : " + clsExam.Fine(_ExamID).Title, "Save Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information); //clsExam.Fine(_ExamID).Title
                        }
                        else
                        {
                            MessageBox.Show("Error Failed to save Question Record ", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // --- Scenario: No existing answer for this question in the database ---
                    // This is a new answer for this attempt/question. CREATE a new record.
                    //CreateStudentAnswer(_currentAttemptId, question.QuestionId, newChosenOption, newIsCorrect);
                    Mode = enMode.AddNew;

                    StudentAnswer = new clsStudentAnswers();
                    StudentAnswer.StudentID = clsGlobal.CurrentUser.UserID;
                    StudentAnswer.ExamID = _ExamID;
                    StudentAnswer.QuestionID = question.QuestionID;
                    StudentAnswer.ChosenOption = chosenOption;
                    StudentAnswer.AnswerTime = DateTime.Now;

                    if (StudentAnswer.Save())
                    {
                        MessageBox.Show("your Anser Saved Successfully of Exam : " + clsExam.Fine(_ExamID).Title, "Save Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information); //clsExam.Fine(_ExamID).Title
                    }
                    else
                    {
                        MessageBox.Show("Error Failed to save Question Record ", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }




                //clsStudentAnswers StudentAnswer = new clsStudentAnswers();
                //StudentAnswer.StudentID = clsGlobal.CurrentUser.UserID;
                //StudentAnswer.ExamID = _ExamID;
                //StudentAnswer.QuestionID = question.QuestionID;
                //StudentAnswer.ChosenOption = chosenOption;
                //StudentAnswer.AnswerTime = DateTime.Now;

                //if (StudentAnswer.Save())
                //{
                //    MessageBox.Show("your Anser Saved Successfully of Exam : " + clsExam.Fine(_ExamID).Title, "Save Successfully",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information); //clsExam.Fine(_ExamID).Title
                //}
                //else
                //{
                //    MessageBox.Show("Error Failed to save Question Record ", "Not Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }

        }

        private void LogStudentAnswersToHistory(string actionType, int currentScore, int? resultId)
        {
            int counter = 0;
            List<clsQuestions> questionList = GetAllQuestions();
            foreach (clsQuestions question in questionList)
            {
                //string chosenOption = _studentAnswer.ContainsKey(question.QuestionID) ? _studentAnswer[question.QuestionID] : string.Empty;

                string chosenOption = "";
                if(_studentAnswer.TryGetValue(question.QuestionID, out chosenOption))
                {
                    chosenOption = _studentAnswer.ContainsKey(question.QuestionID) ? _studentAnswer[question.QuestionID] : "U";
                }

                bool isCorrect = (chosenOption == question.CorrectOption); // Assuming Question.CorrectOption is available

                clsStudentAnswerHistory historyEntry = new clsStudentAnswerHistory();
                //{
                //    StudentID = _currentStudentId,
                //    ExamID = _currentExam.ExamId,
                //    QuestionID = question.QuestionId,
                //    ChosenOption = chosenOption,
                //    IsCorrect = isCorrect,
                //    ActionType = actionType,
                //    Timestamp = DateTime.Now,
                //    ResultID = resultId
                //};
                historyEntry.StudentID = clsGlobal.CurrentUser.UserID;
                historyEntry.ExamID = _ExamID;
                historyEntry.QuestionID = question.QuestionID;
                historyEntry.ChosenOption = chosenOption;
                historyEntry.IsCorrect = isCorrect;
                historyEntry.ActionType = actionType;
                historyEntry.Timestamp = DateTime.Now;
                historyEntry.ResultID = _result.ResultID;

                bool savedHistory = historyEntry.Save();
                if(savedHistory)
                {
                    counter++;
                   
                }
                else
                {
                    MessageBox.Show("Error Failed to save History ", "Not Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Student Anser History Saved to : " +counter +" records" ,  "Save Successfully",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            //you need to store their selected answer for each question.
            //How to store it: A common way is to use a Dictionary<int, string> where the int is the QuestionId and the string is
            //the selected option (e.g., "A", "B", "C", "D").
            //When to collect:
            //Recommended: Every time the user selects an option(e.g., RadioButton_CheckedChanged event within your QuestionUserControl
            //or on the TakeExamForm itself). This ensures answers are captured as they're made.

            //You'll need to define how your QuestionUserControl exposes the selected answer (e.g., a public string SelectedAnswer { get; }).

            /*
                - Loop through your collected _userAnswers 'dictionary' again.
                - For each QuestionId and SelectedOption in the dictionary, create a UserAnswer object.
                - Set IsCorrect property of UserAnswer by comparing SelectedOption to the Question.CorrectOption.
                - Call a method in your UserAnswerManager (e.g., SaveUserAnswer(UserAnswer answer)) to insert these into the UserAnswers table.

             */
            /*
             first check if this examID and StudentID exist in result then its Update mode 
             else if null not exist this result for this exam and student mean its AddNew mode 
             */

            // there is an constrain on StudentAnswer must not save recorde with same studentID and ExamID and QuestionID 
            //so must delete or update the old one 
            //and make sure to save a history or changegs on taking exam

            //now we do the approach of retake exam that delete the preveous StudentAnswer and before delete save it to StudentAnswerHistory
            //we must check if StudentAnswerHistory is add mutiple record of same student and exam and question 
            //and check if he already answer the correct option must the control be Enable 
            //then we must do the fill data or view mode when he answer the correct answer just show the question with answer , not able to edit




            int score = 0;
            
            _studentAnswer.Clear();

            _HandleCollectStudentAnswers();
            //_HandleCalculateScore(score);

            //calculate the score by comparing student answer with correct answer
            List<clsQuestions> questionList = GetAllQuestions();

            foreach (clsQuestions question in questionList)
            {
                if (_studentAnswer.ContainsKey(question.QuestionID))
                {
                    string chosenOption = _studentAnswer[question.QuestionID];

                    // Only compare if an option was actually chosen (not empty) AND it's correct
                    if (!string.IsNullOrEmpty(chosenOption) && chosenOption == question.CorrectOption) //)
                    {
                        score++;
                    }
                }
            }



            if (Mode == enMode.AddNew)
            {
                // Save score and result of student
                _result = new clsResults();
                _result.StudentID = clsGlobal.CurrentUser.UserID;
                _result.ExamID = _ExamID;
                _result.Score = score;
                _result.SubmissionDate = DateTime.Now;

                if (_result.Save())
                {
                    MessageBox.Show("Your score is : " + score + " of " + clsQuestions.GetQuestionCountByExamId(_ExamID), "Save Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Failed to save Result ", "Not Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LogStudentAnswersToHistory("Initial Submit", score, _result.ResultID);

                _HandleSaveStudentAnswer();
            }
            else if (Mode == enMode.Update)
            {
                _result.Score = score;
                _result.SubmissionDate = DateTime.Now;

                if (_result.Save())
                {
                    MessageBox.Show("Your score is : " + score + " of " + clsQuestions.GetQuestionCountByExamId(_ExamID), "Save Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Failed to save Result ", "Not Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LogStudentAnswersToHistory("Update Submit", score, _result.ResultID);

                //clsStudentAnswers.DeleteStudentAnswerByStudentIDAndExamID(clsGlobal.CurrentUser.UserID, _ExamID);

                _HandleSaveStudentAnswer();
            }

            btnSubmit.Enabled = false;

            btnShowResult.Visible = true;
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            //frmStudentMain frm = new frmStudentMain();
            //frm._OpenChildForm(new frmShowResult(_result));

            frmShowResult frm2 = new frmShowResult(_result);
            frm2.ShowDialog();
        }




        //List<clsStudentAnswers> existingDbAnswers;
        //Dictionary<int, clsStudentAnswers> existingAnswersMap = existingDbAnswers.ToDictionary(sa => sa.QuestionId);


        //private void num()
        //{
        //    existingDbAnswers = GetAllStudentAnswerByStudentAndExam();

        //    if (existingAnswersMap.TryGetValue(question.QuestionId, out clsStudentAnswers existingAnswer))
        //    {
        //        // --- Scenario: Answer already exists in the database for this question ---

        //        // Check if the newly submitted answer is different from the saved one
        //        // OR if the saved answer was incorrect and the new one might be correct
        //        if (existingAnswer.ChosenOption != newChosenOption || existingAnswer.IsCorrect != newIsCorrect)
        //        {
        //            // The answer has changed OR its correctness status has changed.
        //            // UPDATE the existing record.
        //            UpdateStudentAnswer(existingAnswer.AnswerId, newChosenOption, newIsCorrect);
        //        }
        //    }
        //    else
        //    {
        //        // --- Scenario: No existing answer for this question in the database ---
        //        // This is a new answer for this attempt/question. CREATE a new record.
        //        CreateStudentAnswer(_currentAttemptId, question.QuestionId, newChosenOption, newIsCorrect);
        //    }


        //    //    ///                        ///////////////////////////////////////////////////////

           


        //}


    }
}
