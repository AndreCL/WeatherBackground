using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace WeatherBackground
{
    class Program
    {
        static int Main(string[] args)
        {
            //string name = RegionInfo.CurrentRegion.DisplayName;

            //Console.WriteLine(name);
            int ZipCode = Int32.Parse(ConfigurationManager.AppSettings["ZipCode"]);

            int result  = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long"), Wallpaper.Style.Centered);

            return result;
        }
    }
}
