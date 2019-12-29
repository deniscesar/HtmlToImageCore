using System;

namespace HtmlToImageCore.Interfaces
{
    public interface ITools : IDisposable
    {
        void Load();
        bool IsLoaded { get; }
        IntPtr CreateGlobalSettings();
        int SetGlobalSetting(IntPtr settings, string name, string value);
        IntPtr CreateConverter(IntPtr globalSettings, byte[] data);
        bool Convert(IntPtr converter);
        byte[] GetConversionResult(IntPtr converter);
        void DestroyConverter(IntPtr converter);
        void Deinit();

    }
}