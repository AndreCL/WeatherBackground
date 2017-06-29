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

            Image backImg = Image.FromFile("background.jpg");
            Image mrkImg = null; //= Image.FromFile("watermark.png");
            Graphics g = Graphics.FromImage(backImg);

            try
            {
                if (ConfigurationManager.AppSettings["CountryCode"] == "DK")
                {
                    //result = Wallpaper.Set(
                    //    new Uri($"http://servlet.dmi.dk/byvejr/servlet/byvejr_dag1?by={ZipCode}&mode=long"),
                    //    Wallpaper.Style.Centered);
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
                    //result = Wallpaper.Set(
                    //    new Uri($"http://servlet.dmi.dk/byvejr/servlet/world_image?city={ZipCode}&mode=dag1_2"),
                    //    Wallpaper.Style.Centered);
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
                g.DrawImage(mrkImg, backImg.Width-(mrkImg.Width/2) / 2, backImg.Height- (mrkImg.Height / 2) / 2);
                Wallpaper.Set(backImg, Wallpaper.Style.Centered);
                //backImg.Save("result.jpg");
            }
            catch (Exception e)
            {
                Wallpaper.Set(backImg, Wallpaper.Style.Centered);
            }
           

            return result;
        }

        public static Bitmap SaveImage(string imageUrl)
        {

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();

            return bitmap;
        }
    }
}
