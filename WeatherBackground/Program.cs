using System;
using System.Configuration;

namespace WeatherBackground
{
    class Program
    {
        static int Main(string[] args)
        {
            //possible for auto zip?
            //string name = RegionInfo.CurrentRegion.DisplayName;
            
            int ZipCode = Int32.Parse(ConfigurationManager.AppSettings["ZipCode"]);

            int result  = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long"), Wallpaper.Style.Centered);

            return result;
        }
    }
}
