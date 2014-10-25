using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace WebMVCDemo.Web
{
    /// <summary>
    /// Summary description for ImageResolver
    /// </summary>
    public class ImageResolver : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string imageName = context.Request.QueryString["imagename"];
            string size = context.Request.QueryString["size"];

            int W = 75;
            int H = 75;

            Image _img = null;

            using (Image img = Image.FromFile(ConfigurationManager.AppSettings["PhotoGalleryPath"] + imageName))
            {
                if (size == "l")
                {
                    W = img.Width / 2;
                    H = img.Height / 2;
                }

                _img = new Bitmap(W, H);

                using (Graphics g = Graphics.FromImage(_img))
                {
                    g.DrawImage(img, 0, 0, W, H);
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                    g.Dispose();
                }
                img.Dispose();
            }

            using (MemoryStream str = new MemoryStream())
            {
                _img = _img.GetThumbnailImage(W, H, null, IntPtr.Zero);
                _img.Save(str, System.Drawing.Imaging.ImageFormat.Png);
                _img.Dispose();
                str.WriteTo(context.Response.OutputStream);
                str.Dispose();
                str.Close();
            }

            context.Response.ContentType = ".png";
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}