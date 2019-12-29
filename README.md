# HtmlToImageCore

[![Build Status](https://travis-ci.org/deniscesar/HtmlToImageCore.svg?branch=master)](https://travis-ci.com/deniscesar/HtmlToImageCore.svg?branch=master) [![NuGet](https://img.shields.io/nuget/v/HtmlToImageCore.svg)](https://www.nuget.org/packages/CoreHtmlToImage/)

## Install
Nuget package available https://www.nuget.org/packages/HtmlToImageCore
```
dotnet add package HtmlToImageCore --version 0.0.1
```
## Dependency
This package uses as dependency the native library [libwkhtmltox](https://github.com/deniscesar/HtmlToImageCore/tree/master/libwkhtmltox-v0.12.4).
Copy native library to root folder of your project. From there .NET Core loads native library when native method is called with P/Invoke. You can find latest version of native library here. Select appropriate library for your OS and platform (64 or 32 bit).

#### Convert HTML string to image bytes
```
var html = "<div><strong>Hello World!</strong></div>";
converter.ConvertHtmlString(html, "bmp", null, null);
```
            
#### Convert URL to image bytes
```
converter.ConvertHtmlUrl("http://google.com", "bmp", null, null);
```

### Optional parameters
- quality - output image quality from 1 to 100.
- screenWidth - the with of the screen used to render is pixels, e.g "800".
