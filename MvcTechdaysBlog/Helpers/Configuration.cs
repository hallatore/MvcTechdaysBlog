using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcTechdaysBlog.Helpers
{
    public static class Configuration
    {
        private static string _adminUserName;
        public static string AdminUserName
        {
            get
            {
                _adminUserName = _adminUserName ?? ConfigurationManager.AppSettings["adminUserName"];
                return _adminUserName;
            }
        }

        private static string _adminPassword;
        public static string AdminPassword
        {
            get
            {
                _adminPassword = _adminPassword ?? ConfigurationManager.AppSettings["adminPassword"];
                return _adminPassword;
            }
        }
    }
}