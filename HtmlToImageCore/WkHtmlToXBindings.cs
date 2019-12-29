using System;
using System.Runtime.InteropServices;

namespace HtmlToImageCore
{
    public unsafe static class WkHtmlToXBindings
    {
        const string DLLNAME = "libwkhtmltox";
        const CharSet CHARSET = CharSet.Unicode;

        #region HTML to Image bindings

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern int wkhtmltoimage_init(int useGraphics);

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern IntPtr wkhtmltoimage_create_global_settings();

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern int wkhtmltoimage_set_global_setting(IntPtr settings,
            [MarshalAs((short)48)]
            String name,
            [MarshalAs((short)48)]
            String value);
        
        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern IntPtr wkhtmltoimage_create_converter(IntPtr globalSettings, byte[] data);

        [DllImport(DLLNAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool wkhtmltoimage_convert(IntPtr converter);

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern int wkhtmltoimage_get_output(IntPtr converter, out IntPtr data);

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern int wkhtmltoimage_deinit();

        [DllImport(DLLNAME, CharSet = CHARSET)]
        public static extern void wkhtmltoimage_destroy_converter(IntPtr converter);

        #endregion
    }
}