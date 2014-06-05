using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveAStickWP8
{
    public static class Parameters
    {
        public static String API_URL = "http://api.giveastick.com";
        public static String API_GETSTICKLIST_RESOURCE = "/sticks/{nickname}/{grouptag}";
        public static String API_POSTSTICK_RESOURCE = "/sticks/{grouptag}";
    }
}
