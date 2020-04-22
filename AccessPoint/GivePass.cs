using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessPoint
{
    static class GivePass
    {
        private static string pass;

        public static string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
    }
}
