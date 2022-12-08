﻿using System;
using System.Runtime.InteropServices;

namespace MWebBrowser.Code.Configure
{
    public static class KnownFolder
    {
        public static readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");
    }

    public static class KnownFolderHelper
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags, IntPtr hToken, out string pszPath);

        public static string GetDownload()
        {
            SHGetKnownFolderPath(KnownFolder.Downloads, 0, IntPtr.Zero, out var downloads);
            return downloads;
        }
    }
}
