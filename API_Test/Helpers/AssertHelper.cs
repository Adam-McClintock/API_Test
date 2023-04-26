using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Test
{
    public static class AssertHelper
    {
        public static HttpStatusCode StatusIs(int status)
        {
            return (HttpStatusCode)status;
        }
    }
}
