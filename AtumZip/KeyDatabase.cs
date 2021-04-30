using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace AtumZip
{
    public class Key
    {
        public Key()
        {
 
        }

        public Key(string FileName, string XorKey)
        {
            this.FileName = FileName;
            this.XorKey = XorKey;
        }

        public string FileName;
        public string XorKey;
    }

    class KeyDatabase
    {
        static List<Key> m_Keys = new List<Key>();

        public static bool SearchKey(string FileName, out string key)
        {
            key = String.Empty;
            Key k = m_Keys.FindLast(_key => _key.FileName.ToLower() == FileName.ToLower());;
            if (k != null)
            {
                key = k.XorKey;
                return true;
            }
            return false;
        }

        public static void Load()
        {
            if (!File.Exists(Strings.XorKeyFile))
            {
                m_Keys = new List<Key>();
                Save();
                return;
            }

            try
            {
                using (FileStream fs = new FileStream(Strings.XorKeyFile, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Key>));
                    m_Keys = ser.Deserialize(fs) as List<Key>;
                }
            }
            catch
            {
                m_Keys = new List<Key>();
                Save();
            }
        }

        public static void Save()
        {
            // Do not create a .xml file when list is empty
            if (m_Keys.Count == 0)
                return;

            if (!File.Exists(Strings.XorKeyFile))
                File.Create(Strings.XorKeyFile).Close();

            using (FileStream fs = new FileStream(Strings.XorKeyFile, FileMode.Truncate))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<Key>));
                ser.Serialize(fs, m_Keys);
            }
        }

        public static List<Key> Get()
        {
            return m_Keys;
        }

        public static void Clear()
        {
            m_Keys.Clear();
        }
    }
}
