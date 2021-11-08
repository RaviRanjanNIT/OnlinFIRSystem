using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OnlinFIRSystem
{
    public class AppConnection
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

    }
}