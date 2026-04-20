using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsEventLogger
    {
        public static void LogExceptions(Exception ex, EventLogEntryType eventLogEntryType)
        {
            string sourceName = "ExamSystem";

            try
            {
                if (!EventLog.Exists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                string Message = $"Message Error: {ex.Message}\n" +
                             $"Inner Exception: {ex.InnerException}\n" +
                             $"Stack Trace: {ex.StackTrace}\n" +
                             $"Source: {ex.Source}\n";

                EventLog.WriteEntry(sourceName, Message, eventLogEntryType);
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry(sourceName, "En Error in LogExceptions Method in clsEventLogger class" + exc.Message, eventLogEntryType);
            }
        }





        //static public void LogError(Exception ex, string SourceName = "AppDVLD")
        //{
        //    // Create the event source if it does not exist
        //    if (!EventLog.SourceExists(SourceName))
        //    {
        //        EventLog.CreateEventSource(SourceName, "Application");
        //    }

        //    // Here we save details Exception.
        //    string Message = $"Message Error: {ex.Message}\n" +
        //                     $"Inner Exception: {ex.InnerException}\n" +
        //                     $"Stack Trace: {ex.StackTrace}\n" +
        //                     $"Source: {ex.Source}\n";

        //    // Log an information event
        //    EventLog.WriteEntry(SourceName, Message, EventLogEntryType.Error);
        //}

        static public void LogInformation(string Message, EventLogEntryType eventLogEntryType)
        {
            string sourceName = "ExamSystem";
            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            // Log an information event
            EventLog.WriteEntry(sourceName, Message, eventLogEntryType);
        }


    }
}
