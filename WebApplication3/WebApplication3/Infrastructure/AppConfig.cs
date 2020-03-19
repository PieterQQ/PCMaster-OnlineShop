using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpodIglyMVC.Infrastructure
{
    public class AppConfig
    {
        private static string _photosFolderRelative = ConfigurationManager.AppSettings["Convert"];
        public static string PhotosFolderRelative
        {
            get
            {
                return "Photos";
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
