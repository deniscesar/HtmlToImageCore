using System;
using System.Runtime.InteropServices;
using HtmlToImageCore.Interfaces;

namespace HtmlToImageCore
{
    public class ImageTools : ITools
    {
        public bool IsLoaded { get; private set; }

        public ImageTools(){
            IsLoaded = false;
        }

        public void Load()
        {
            if(IsLoaded){
                return;
            }

            if (WkHtmlToXBindings.wkhtmltoimage_init(0) == 1)
            {
                IsLoaded = true;
            }
        }

        public IntPtr CreateGlobalSettings()
        {
            return WkHtmlToXBindings.wkhtmltoimage_create_global_settings();
        }

        public int SetGlobalSetting(IntPtr settings, string name, string value)
        {
            return WkHtmlToXBindings.wkhtmltoimage_set_global_setting(settings, name, value);
        }

        public IntPtr CreateConverter(IntPtr globalSettings, byte[] data)
        {
            return WkHtmlToXBindings.wkhtmltoimage_create_converter(globalSettings, data);
        }

        public bool Convert(IntPtr converter)
        {
            return WkHtmlToXBindings.wkhtmltoimage_convert(converter);
        }

        public byte[] GetConversionResult(IntPtr converter)
        {
            IntPtr resultPointer;

            int length = WkHtmlToXBindings.wkhtmltoimage_get_output(converter, out resultPointer);
            var result = new byte[length];
            Marshal.Copy(resultPointer, result, 0, length);

            return result;
        }

        public void DestroyConverter(IntPtr converter)
        {
            WkHtmlToXBindings.wkhtmltoimage_destroy_converter(converter);
        }

        public void Deinit()
        {
            WkHtmlToXBindings.wkhtmltoimage_create_global_settings();
        }

        public void Dispose()
        {
            this.Deinit();
        }

    }
}