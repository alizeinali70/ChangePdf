
using PdfSharpCore.Fonts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class BlazorFontResolver : IFontResolver
{
    private static readonly Dictionary<string, byte[]> fontCache = new Dictionary<string, byte[]>();

    public BlazorFontResolver()
    {
        AddFont("Verdana", "ChangePdf.Client.Fonts.Verdana.ttf");
        AddFont("VerdanaBold", "ChangePdf.Client.Fonts.Verdana-Bold.ttf");
    }


    public string DefaultFontName => throw new NotImplementedException();

    public byte[] GetFont(string faceName)
    {
        if (fontCache.TryGetValue(faceName, out var fontData))
        {
            return fontData;
        }

        throw new InvalidOperationException($"The font '{faceName}' could not be found.");
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        string faceName = familyName.ToLowerInvariant();

        if (isBold)
        {
            faceName += "bold";
        }

        switch (faceName)
        {
            case "verdana":
                return new FontResolverInfo("Verdana");
            case "verdanabold":
                return new FontResolverInfo("VerdanaBold");
        }

        return null;
    }

    private void AddFont(string faceName, string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                throw new InvalidOperationException($"The font '{resourceName}' could not be found as an embedded resource.");
            }

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fontCache[faceName] = memoryStream.ToArray();
            }
        }
    }


}
