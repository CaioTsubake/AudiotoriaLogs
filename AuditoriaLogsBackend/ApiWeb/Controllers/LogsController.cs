﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWeb.Controllers
{
    public class LogsController : ApiController
    {
        public string GetHeartbeat() 
        {
            return "Ok";
        }
    }
}
