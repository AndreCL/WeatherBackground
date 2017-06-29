using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

public sealed class Wallpaper
{
    Wallpaper() { }

    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public enum Style : int
    {
        Tile,
        Center,
        Stretch,
        Fit,
        Fill
    }

    /*
     TileWallpaper
        0: The wallpaper picture should not be tiled 
        1: The wallpaper picture should be tiled 

     WallpaperStyle
        0:  The image is centered if TileWallpaper=0 or tiled if TileWallpaper=1
        2:  The image is stretched to fill the screen
        6:  The image is resized to fit the screen while maintaining the aspect 
            ratio. (Windows 7 and later)
        10: The image is resized and cropped to fill the screen while maintaining 
            the aspect ratio. (Windows 7 and later)

         */

    public static int Set(Uri uri, Style style)
    {
        Stream s;

        try
        {
            s = new WebClient().OpenRead(uri.ToString());
        }
        catch (WebException) //WebException
        { 
            return -1;
        }
        catch (Exception)  //other webclient exceptions
        {
            return -2;
        }


        Image img = Image.FromStream(s);
        string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
        img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        //switch (style)
        //{
        //    case Style.Tile:
        //        key.SetValue(@"WallpaperStyle", "0");
        //        key.SetValue(@"TileWallpaper", "1");
        //        break;
        //    case Style.Center:
        //        key.SetValue(@"WallpaperStyle", "0");
        //        key.SetValue(@"TileWallpaper", "0");
        //        break;
        //    case Style.Stretch:
        //        key.SetValue(@"WallpaperStyle", "2");
        //        key.SetValue(@"TileWallpaper", "0");
        //        break;
        //    case Style.Fit: // (Windows 7 and later)
        //        key.SetValue(@"WallpaperStyle", "6");
        //        key.SetValue(@"TileWallpaper", "0");
        //        break;
        //    case Style.Fill: // (Windows 7 and later)
        //        key.SetValue(@"WallpaperStyle", "10");
        //        key.SetValue(@"TileWallpaper", "0");
        //        break;
        //}

        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            tempPath,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        return 0;
    }

    public static int Set(Image img, Style style)
    {
        string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
        img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        switch (style)
        {
            case Style.Tile:
                key.SetValue(@"WallpaperStyle", "0");
                key.SetValue(@"TileWallpaper", "1");
                break;
            case Style.Center:
                key.SetValue(@"WallpaperStyle", "0");
                key.SetValue(@"TileWallpaper", "0");
                break;
            case Style.Stretch:
                key.SetValue(@"WallpaperStyle", "2");
                key.SetValue(@"TileWallpaper", "0");
                break;
            case Style.Fit: // (Windows 7 and later)
                key.SetValue(@"WallpaperStyle", "6");
                key.SetValue(@"TileWallpaper", "0");
                break;
            case Style.Fill: // (Windows 7 and later)
                key.SetValue(@"WallpaperStyle", "10");
                key.SetValue(@"TileWallpaper", "0");
                break;
        }

        SystemParametersInfo(SPI_SETDESKWALLPAPER,
            0,
            tempPath,
            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);

        return 0;
    }
}