using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

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

            Image backImg = Image.FromFile("C:\\Users\\andre.lundin\\Desktop\\background weather\\background.jpg"); //full path otherwise not work with job scheduler
            Image mrkImg = null; //= Image.FromFile("watermark.png");
            Graphics g = Graphics.FromImage(backImg);

            try
            {
                if (ConfigurationManager.AppSettings["CountryCode"] == "DK")
                {
                    //result = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long"),Wallpaper.Style.Centered);
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long");

                    if (stream != null)
                    {
                        mrkImg = Image.FromStream(stream);
                        stream.Flush();
                        stream.Close();
                    }
                    client.Dispose();
                }
                else
                {
                    //result = Wallpaper.Set(new Uri($"http://servlet.dmi.dk/byvejr/servlet/world_image?city={ZipCode}&mode=dag1_2"),Wallpaper.Style.Centered);
                    WebClient client = new WebClient();
                    Stream stream = client.OpenRead($"http://servlet.dmi.dk/byvejr/servlet/world_image?city={ZipCode}&mode=dag1_2");

                    if (stream != null)
                    {
                        mrkImg = Image.FromStream(stream);
                        stream.Flush();
                        stream.Close();
                    }
                    client.Dispose();
                }
                g.DrawImage(mrkImg, backImg.Width / 2, backImg.Height  / 2);
                Wallpaper.Set(backImg, Wallpaper.Style.Stretch);
                //backImg.Save("C:\\Users\\andre.lundin\\Desktop\\result.jpg");
            }
            catch (Exception e)
            {
                Wallpaper.Set(backImg, Wallpaper.Style.Stretch);
                Console.WriteLine(e.Message);
            }
           

            return result;
        }
    }
}
