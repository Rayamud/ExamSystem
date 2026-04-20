using System;

public class Class1
{
	public Class1()
	{

         public static void LogExceptions(string logMessage, EventLogEntryType eventLogEntryType)
         {
                string sourceName = "ExamSystem";

                try
                {
                    if (!EventLog.Exists(sourceName))
                    {
                        EventLog.CreateEventSource(sourceName, "Application");
                    }

                    EventLog.WriteEntry(sourceName, logMessage, eventLogEntryType);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(sourceName, "En Error in LogExceptions Method in clsEventLogger class" + ex.Message, eventLogEntryType);
                }
         }
    }
}
