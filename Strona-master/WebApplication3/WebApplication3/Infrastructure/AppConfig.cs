using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Infrastructure
{
    public class AppConfig
    {
        private static string _photosFolderRelative = ConfigurationManager.AppSettings["Convert"];
        public static string PhotosFolderRelative
        {
            get
            {
                return _photosFolderRelative;
            }
        }

        private static string _podzespolIconsFolderRelative = ConfigurationManager.AppSettings["ikony"];
        public static string GenreIconsFolderRelative
        {
            get
            {
                return _podzespolIconsFolderRelative;
            }
        }

    }
}
