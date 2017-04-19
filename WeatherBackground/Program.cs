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

            int result = -3;

            if (ConfigurationManager.AppSettings["CountryCode"] == "DK")
            {
                result = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long"),Wallpaper.Style.Centered);
            }
            else
            {
                result = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/world_image?city={ZipCode}&mode=dag1_2"), Wallpaper.Style.Centered);
            }

            return result;
        }
    }
}
