using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    public class SettingDataAccess
    {
        //public static string ConnectionString = "Server=(local);Database=ExamSystemDB; User id=sa;password=sa123456;";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"]?.ConnectionString;

    }
}

