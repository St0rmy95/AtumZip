using System;
using System.Collections.Generic;
using System.Text;

class fileInfo
{
    public fileInfo(string Extension, short[] Header, string Description, ImageListIndex Icon)
    {
        this.Extension = Extension;
        this.Header = Header;
        this.Description = Description;
        this.Icon = Icon;
    }

    public string Extension;
    public short[] Header;
    public string Description;
    public ImageListIndex Icon;
}

public enum ImageListIndex
{
    Binary,
    File,
    Config,
    Image,
    Mesh,
    Video,
    Sound,
    Text
}

public static class FileType
{
    static List<fileInfo> m_Infos = new List<fileInfo>()
    {
        { new fileInfo(".tga", null, "Truevision TGA Image", ImageListIndex.Image) },
        { new fileInfo(".txt", null, "Textfile", ImageListIndex.Text) },
        { new fileInfo(".bin", null, "Binary File", ImageListIndex.Binary) },
        { new fileInfo(".png", new short[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "Portable Network Graphics File", ImageListIndex.Image) },
        { new fileInfo(".jpg", new short[] { 0xFF, 0xD8, 0xFF, 0xDB }, "JPEG Image", ImageListIndex.Image) },
        { new fileInfo(".jpg", new short[] { 0xFF, 0xD8, 0xFF, 0xE0, -1, -1, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 }, "JPEG Image", ImageListIndex.Image) },
        { new fileInfo(".jpg", new short[] { 0xFF, 0xD8, 0xFF, 0xE1, -1, -1, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00 }, "JPEG Image", ImageListIndex.Image) },
        { new fileInfo(".wav", new short[] { 0x52, 0x49, 0x46, 0x46, -1, -1, -1, -1, 0x57, 0x41, 0x56, 0x45 }, "Waveform Audio File Format", ImageListIndex.Sound) },
        { new fileInfo(".x", new short[] { 0x78, 0x6F, 0x66, 0x20 }, "DirectX Mesh File", ImageListIndex.Mesh) },
        { new fileInfo(".ico", new short[] { 0x00, 0x00, 0x01, 0x00 }, "Icon File", ImageListIndex.Image) },
        { new fileInfo(".exe", new short[] { 0x4D, 0x5A }, "DOS MZ executable", ImageListIndex.File) },
        { new fileInfo(".pdf", new short[] { 0x25, 0x50, 0x44, 0x46 }, "PDF Document", ImageListIndex.Config) },
        { new fileInfo(".wmv", new short[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C }, "WMV Video/Audio", ImageListIndex.Video) },
        { new fileInfo(".psd", new short[] { 0x8, 0x42, 0x50, 0x53 }, "Photoshop Document File", ImageListIndex.Image) },
        { new fileInfo(".avi", new short[] { 0x52, 0x49, 0x46, 0x46, -1, -1, -1, -1, 0x41, 0x56, 0x49, 0x20 }, "Audio Video Interleave File", ImageListIndex.Video) },
        { new fileInfo(".mp3", new short[] { 0xFF, 0xFB }, "MP3 Sound File", ImageListIndex.Sound) },
        { new fileInfo(".mp3", new short[] { 0x49, 0x44, 0x33 }, "MP3 Sound File", ImageListIndex.Sound) },
        { new fileInfo(".bmp", new short[] { 0x42, 0x4D }, "Bitmap Image", ImageListIndex.Image) },
        { new fileInfo(".flac", new short[] { 0x66, 0x4C, 0x61, 0x43 }, "Free Lossless Audio Codec File", ImageListIndex.Sound) },
        { new fileInfo(".doc", new short[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }, "MS Office Document", ImageListIndex.Config) },
        { new fileInfo(".webm", new short[] { 0xA, 0x45, 0xDF, 0xA3 }, "WebM Media Container", ImageListIndex.Video) },
        { new fileInfo(".eff", null, "EffectInfo entry", ImageListIndex.Binary) },
        { new fileInfo(".obi", null, "ObjectInfo entry", ImageListIndex.Binary) },
    };

    public static string GetExtensionByHeader(byte[] data, string archiveFileName)
    {
        if (archiveFileName.ToLower().Contains("effectinfo"))
            return ".eff";

        if (archiveFileName.ToLower().Contains("objectinfo"))
            return ".obi";

        // Checking the header is too insecure, better rely on the footer
        if (CheckTgaFooter(data)/* || CheckTgaHeader(data[1], data[2])*/)
            return ".tga";

        foreach (fileInfo info in m_Infos)
        {
            bool Failed = false;

            if (info.Header == null)
                continue;

            if (data.Length < info.Header.Length)
                continue;

            for (int i = 0; i < info.Header.Length; i++)
            {
                if (data[i] != (byte)info.Header[i] && info.Header[i] != -1)
                {
                    Failed = true;
                    break;
                }
            }

            if (!Failed)
                return info.Extension;
        }

        if (CheckValidChars(data))
            return ".txt";

        return ".bin";
    }

    public static string GetDescription(string Extension)
    {
        foreach (fileInfo info in m_Infos)
            if (info.Extension == Extension)
                return info.Description;

        return String.Format("{0} File", Extension);
    }

    public static ImageListIndex GetImageIndex(string Extension)
    {
        foreach (fileInfo info in m_Infos)
            if (info.Extension == Extension)
                return info.Icon;

        return ImageListIndex.File;
    }

    private static bool CheckTgaHeader(byte b2nd, byte b3rd)
    {
        if ((b2nd == 1 || b2nd == 0) && (
            b3rd == 0
            || b3rd == 1
            || b3rd == 2
            || b3rd == 3
            || b3rd == 9
            || b3rd == 10
            || b3rd == 11))
        {
            return true;
        }
        return false;
    }

    private static bool CheckTgaFooter(byte[] data)
    {
        // Our buffer must be at least 18 bytes, otherwise the following operations will fail
        if (data.Length < 18)
            return false;

        return Encoding.ASCII.GetString(data, data.Length - 18, 16) == "TRUEVISION-XFILE";
    }

    private static bool CheckValidChars(byte[] data)
    {
        List<byte> lData = new List<byte>(data);

        for (byte i = 0; i <= 8; i++)
            if (lData.Contains(i))
                return false;
        for (byte i = 14; i <= 31; i++)
            if (lData.Contains(i))
                return false;
        for (byte i = 127; i <= 160; i++)
            if (lData.Contains(i))
                return false;

        return true;
    }
}

