using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Interfaces
{
    public static class WebAPI
    {
        private const string api = "api/";

        public const string Version = "v1";

        public const string Employees = api + Version + "/employees";
 
        public static class Identity
        {
            public const string User = api + Version + "/users";
            public const string Role = api + Version + "/roles";
        }
    }
}
