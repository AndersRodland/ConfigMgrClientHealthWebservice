using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientHealthWebservice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            string html = @"<html>
<header>
<title>ConfigMgr Client Health</title>
</header>
<body>
<h1>ConfigMgr Client Health Webservice 2.0.1</h1>
<p>Nothing to see here</p>
</body>
</html>
";
            return html;
        }
    }
}