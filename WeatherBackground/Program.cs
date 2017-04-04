using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBackground
{
    class Program
    {
        static int Main(string[] args)
        {
            int result = Wallpaper.Set(new Uri("http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by=2500&mode=long"), Wallpaper.Style.Centered);

            return result;
        }
    }
}
