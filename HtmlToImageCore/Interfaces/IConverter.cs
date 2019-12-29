using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlToImageCore.Interfaces
{
    public interface IConverter
    {

        /// <summary>
        ///  Convert string HTML to bytes
        /// </summary>
        /// <param name="html">String HTML code</param>
        /// <param name="fmt">Format image jpg, png, bmp or svg</param>
        /// <param name="quality">The compression factor to use when outputting a JPEG image. E.g. "94".</param>
        /// <param name="screenWidth">The with of the screen used to render is pixels, e.g "800".</param>
        /// <returns>Returns converted document in bytes</returns>
        byte[] ConvertHtmlString(string html, string fmt, int? quality, int? screenWidth);

        /// <summary>
        ///  Convert string HTML to bytes
        /// </summary>
        /// <param name="html">String HTML code</param>
        /// <param name="fmt">Format image jpg, png, bmp or svg</param>
        /// <param name="quality">The compression factor to use when outputting a JPEG image. E.g. "94".</param>
        /// <param name="screenWidth">The with of the screen used to render is pixels, e.g "800".</param>
        /// <returns>Returns converted document in bytes</returns>
        byte[] ConvertHtmlUrl(string url, string fmt, int? quality, int? screenWidth);

    }
}