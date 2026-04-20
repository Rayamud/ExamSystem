using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public short Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        public short Role { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.UserName = "";
            this.Password = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            this.Role = 0;

            Mode = enMode.AddNew;
        }

        private clsUser( int userID, string firstName, string lastName, string userName, string password, DateTime dateOfBirth,
                      short gender, string email, string address, string imagePath , short role)
        {
            this.UserID = userID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.UserName = userName;
            this.Password = password;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.Email = email;
            this.Address = address;
            this.ImagePath = imagePath;
            this.Role = role;

            Mode = enMode.Update;
        }


        public static clsUser Find (int userID)
        {
            string FirstName = "",  LastName = "";
            string UserName = "", Password = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Email = "", Address = "", ImagePath = "";
            short Role = 0;

            bool isFound = UserDataAccess.GetUserByUserID(userID,ref FirstName,ref LastName, ref UserName,ref Password, ref DateOfBirth, ref Gender,
                ref Email, ref Address, ref ImagePath, ref Role);

            if (isFound)
            {
                return new clsUser(userID, FirstName, LastName, UserName, Password, DateOfBirth, Gender,
                 Email, Address, ImagePath, Role);
            }
            else
                return null;
        }

        public static clsUser Find(string userName)
        {
            int userID = -1;
            string FirstName = "", LastName = "";
            string Password = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Email = "", Address = "", ImagePath = "";
            short Role = 0;

            bool isFound = UserDataAccess.GetUserByUserName(userName,ref userID, ref FirstName, ref LastName, ref Password, ref DateOfBirth, ref Gender,
                ref Email, ref Address, ref ImagePath, ref Role);

            if (isFound)
            {
                return new clsUser(userID, FirstName, LastName, userName, Password, DateOfBirth, Gender,
                 Email, Address, ImagePath, Role);
            }
            else
                return null;
        }

        public static clsUser Find(string userName, string password)
        {
            int userID = -1;
            string FirstName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = 0;
            string Email = "", Address = "", ImagePath = "";
            short Role = 0;

            bool isFound = UserDataAccess.GetUserByUserNameAndPassword(userName,password, ref userID, ref FirstName, ref LastName, ref DateOfBirth, ref Gender,
                ref Email, ref Address, ref ImagePath, ref Role);

            if (isFound)
            {
                return new clsUser(userID, FirstName, LastName, userName, password, DateOfBirth, Gender,
                 Email, Address, ImagePath, Role);
            }
            else
                return null;
        }

        private bool _AddNew()
        {
            string HashPass = clsSecurtyHash.ComputeHash(this.Password);

            this.UserID = UserDataAccess.AddNewUser(this.FirstName, this.LastName, this.UserName, HashPass, this.DateOfBirth, this.Gender
                , this.Email, this.Address, this.ImagePath, this.Role);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            string HashPass = clsSecurtyHash.ComputeHash(this.Password);

            return UserDataAccess.UpdateUser(this.UserID,this.FirstName, this.LastName, this.UserName, HashPass, this.DateOfBirth, this.Gender
                , this.Email, this.Address, this.ImagePath, this.Role);

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
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();
            }

            return false;
        }

        public static DataTable GetAllUsers()
        {
            return UserDataAccess.GetAllUsers();
        }

        public static bool DeletePerson(int ID)
        {
            return UserDataAccess.DeleteUser(ID);
        }

        public static bool isUserExist(int ID)
        {
            return UserDataAccess.IsUserExist(ID);
        }
        public static bool isUserExist(string userName)
        {
            return UserDataAccess.CheckUserExistsByUserName(userName);
        }
    }
}
