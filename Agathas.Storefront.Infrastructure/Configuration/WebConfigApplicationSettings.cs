﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Agathas.Storefront.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }

        public string NumberOfResultsPerpage
        {
            get { return ConfigurationManager.AppSettings["NumberOfResultsPerpage"]; }
        }
    }
}
