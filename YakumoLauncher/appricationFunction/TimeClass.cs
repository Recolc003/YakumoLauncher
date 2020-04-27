using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace YakumoLauncher.appricationFunction
{
    public static class TimeClass
    {
        public static string GetTime()
        {
            var dt = DateTime.Now;

            return string.Format("{0:00}:{1:00}:{2:00}", dt.Hour, dt.Minute, dt.Second);
        }
    }
}
