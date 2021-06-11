using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using LoL1Shot.Infrastructure;

namespace LoL1Shot.Infrastructure
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ImageMiddleware
    {
        private readonly RequestDelegate next;

        public ImageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        private Image DodajZnakWodny(Image zdjecie)
        {
            Image znak = Image.FromFile(".wwwroot/images/jap.png");

            MemoryStream stream = new MemoryStream();

            Brush WatermarkBrush = new TextureBrush(znak);

            Graphics ImageGraphics = Graphics.FromImage(zdjecie);

            ImageGraphics.FillRectangle(WatermarkBrush, new Rectangle(new Point(50, 50), zdjecie.Size));

            ImageGraphics.Dispose();

            zdjecie.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return zdjecie;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string url = httpContext.Request.Path;

            if (url.ToLower().Contains("Error.jpg"))
            {
                Image zdjecie;

                try
                {
                    zdjecie = Image.FromFile(url);
                    zdjecie = DodajZnakWodny(zdjecie);
                }
                catch (FileNotFoundException)
                {
                    zdjecie = Image.FromFile("./wwwroot/images/jap.png");
                }

                MemoryStream stream = new MemoryStream();

                zdjecie.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                httpContext.Response.ContentType = "image/png";

                return httpContext.Response.Body.WriteAsync(stream.ToArray(), 0, (int)stream.Length);
            }

            return next(httpContext);
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ImageMiddlewareExtensions
    {
        public static IApplicationBuilder UseImageMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageMiddleware>();
        }
    }

}