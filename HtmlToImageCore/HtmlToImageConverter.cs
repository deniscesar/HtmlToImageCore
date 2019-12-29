using System;
using System.IO;
using System.Net;
using HtmlToImageCore.Interfaces;

namespace HtmlToImageCore
{
    public class HtmlToImageConverter : IConverter
    {
        public readonly ITools _tools;

        public HtmlToImageConverter(ITools tools)
        {
            _tools = tools;
        }

        public byte[] ConvertHtmlString(string html, string fmt, int? quality, int? screenWidth)
        {
            byte[] result = new byte[0];
            _tools.Load();

            byte[] page = CreatePage(html);

            IntPtr settingsGlobal = _tools.CreateGlobalSettings();
            _tools.SetGlobalSetting(settingsGlobal, "fmt", fmt);
            if(quality != null)
                _tools.SetGlobalSetting(settingsGlobal, "quality", quality.ToString());
            if(screenWidth != null)
                _tools.SetGlobalSetting(settingsGlobal, "screenWidth", screenWidth.ToString());

            IntPtr converter = _tools.CreateConverter(settingsGlobal, page);
            
            if(_tools.Convert(converter))
            {
                result = _tools.GetConversionResult(converter);
            }

            _tools.DestroyConverter(converter);
            return result;
        }

        public byte[] ConvertHtmlUrl(string url, string fmt, int? quality, int? screenWidth)
        {
            byte[] result = new byte[0];
            _tools.Load();

            IntPtr settingsGlobal = _tools.CreateGlobalSettings();
            _tools.SetGlobalSetting(settingsGlobal, "in", url);
            _tools.SetGlobalSetting(settingsGlobal, "fmt", fmt);
            if(quality != null)
                _tools.SetGlobalSetting(settingsGlobal, "quality", quality.ToString());
            if(screenWidth != null)
                _tools.SetGlobalSetting(settingsGlobal, "screenWidth", screenWidth.ToString());

            IntPtr converter = _tools.CreateConverter(settingsGlobal, null);
            
            if(_tools.Convert(converter))
            {
                result = _tools.GetConversionResult(converter);
            }

            _tools.DestroyConverter(converter);
            return result;
        }

        private byte[] CreatePage(string html)
        {
            var filename = $"{Guid.NewGuid()}.html";
            File.WriteAllText(filename, html);
            byte[] bytes = File.ReadAllBytes(filename);
            File.Delete(filename);
            
            return bytes;
        }

    }
}
