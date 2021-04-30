using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace AtumZip
{
    public static class Extensions
    {
        //public static Key Find(this List<Key> self, string Name)
        //{
        //    foreach (Key k in self)
        //    {
        //        if (k.FileName.ToLower() == Name.ToLower())
        //            return k;
        //    }

        //    return null;
        //}

        public static bool Exists(this List<Key> self, string Name)
        {
            return self.Exists(Key => Key.FileName.ToLower() == Name.ToLower());
        }

        public static string GetSizeFormat(long size)
        {
            if(size < 1000)
                return String.Format("{0} B", size);
            else if ((size /= 1024) < 1000)
                return String.Format("{0} KB", size);
            else if ((size /= 1024) < 1000)
                return String.Format("{0} MB", size);
            else if ((size /= 1024) < 1000)
                return String.Format("{0} GB", size);
            else
                return String.Format("{0} TB", size);
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
