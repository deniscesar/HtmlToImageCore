using System;
using System.IO;
using HtmlToImageCore;
namespace AppConsole
{
    class Program
    {  
        static void Main(string[] args)
        {
            Console.WriteLine("Starting convert HTML to image");

            var converter = new HtmlToImageConverter(new ImageTools());

            // Convert from string HTML code
            var html = "<div><strong>Hello World Denis!</strong></div>";
            var result = converter.ConvertHtmlString(html, "bmp", null, null);
            
            using (FileStream stream = new FileStream(DateTime.UtcNow.Ticks.ToString() + ".bmp", FileMode.Create))
            {
                stream.Write(result, 0, result.Length);
            }

            // Convert from url page
            result = converter.ConvertHtmlUrl("http://google.com", "bmp", null, null);
            
            using (FileStream stream = new FileStream(DateTime.UtcNow.Ticks.ToString() + ".bmp", FileMode.Create))
            {
                stream.Write(result, 0, result.Length);
            }

            Console.WriteLine("End convert HTML to image");
        }
    }
}
