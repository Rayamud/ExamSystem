using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace Exam_System_App
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\ExamSystem";

            string valueNameUser = "UserName_ExamSystem";
            string valueDataUserName = Username;

            string valueNamePassword = "Password_ExamSystem";
            string valueDataPassword = Password;
            try
            {
                Registry.SetValue(keyPath, valueNameUser, valueDataUserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, valueNamePassword, valueDataPassword, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                clsEventLogger.LogExceptions(ex , EventLogEntryType.Error);
                return false;
            }
            
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\ExamSystem";

            string valueNameUser = "UserName_ExamSystem";

            string valueNamePassword = "Password_ExamSystem";
            try
            {
                 Username = Registry.GetValue(keyPath, valueNameUser, null) as string;
                 Password = Registry.GetValue(keyPath, valueNamePassword, null) as string;

                if (Username != null && Password != null) return true;
                else return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                clsEventLogger.LogExceptions(ex, EventLogEntryType.Error);
                return false;
            }

        }

        public static bool DeleteUserNameAndPasswordValueSaved()
        {
            // Specify the registry key path and value name
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\ExamSystem";

            string valueNameUser = "UserName_ExamSystem";

            string valueNamePassword = "Password_ExamSystem";
            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(valueNameUser);
                            key.DeleteValue(valueNamePassword);

                            
                            //Console.WriteLine($"Successfully deleted value '{valueNamePassword}' from registry key '{keyPath}'");
                            MessageBox.Show($"Successfully deleted value '{valueNameUser}' from registry key '{keyPath}'", "saved"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            //Console.WriteLine($"Registry key '{keyPath}' not found");
                            MessageBox.Show($"Registry key '{keyPath}' not found", "Not found"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
                MessageBox.Show("UnauthorizedAccessException: Run the program with administrative privileges.", "UnauthorizedAccessException"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"An error occurred: {ex.Message}");
                MessageBox.Show($"An error occurred: {ex.Message}", "Exception"
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }
        



        private static bool _RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        private static bool _GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

    }
}
