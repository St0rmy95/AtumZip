namespace Ace_Globals
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using Ace_Globals.Extensions;

    public enum EncryptionType
    {
        None,
        CR
    }

    public class ArchiveEntry : IComparable<ArchiveEntry>, IEquatable<ArchiveEntry>
    {
        private static byte[] DUMMY = new byte[4];
        private string extension;
        private string fileType;
        private int id;
        private bool insideArchive;
        private string name;
        private string path;
        private long position;
        private int sizeData;
        private byte[] data;
        EncryptionType encryptionType = EncryptionType.None;

        public ArchiveEntry(string path, BinaryReader reader, bool insideArchive, EncryptionType encryptionType)
        {
            this.insideArchive = insideArchive;
            this.path = path;
            this.encryptionType = encryptionType;
            if (insideArchive)
            {
                this.position = reader.BaseStream.Position;
                try
                {
                    this.id = (Int32) reader.ReadUInt32();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + "\n" + reader.ReadUInt32().ToString());
                }
                this.sizeData = Convert.ToInt32(reader.ReadUInt32());
                reader.ReadUInt32();
                this.name = this.readName(reader);
                Stream baseStream = reader.BaseStream;
                baseStream.Position += this.sizeData;
            }
            else
            {
                string[] strArray = Path.GetFileName(path).Split(new char[] { '.' });
                int length = strArray[0].LastIndexOf('-');
                if (length == -1)
                {
                    this.id = 0;
                    this.name = strArray[0];
                }
                else
                {
                    if (!Int32.TryParse(strArray[0].Substring(length + 1, (strArray[0].Length - length) - 1), out this.id))
                        this.id = 0;
                    this.name = strArray[0].Substring(0, length);
                }
                FileInfo info = new FileInfo(path);
                this.sizeData = (int) info.Length;
            }
            this.extension = this.readExtension();
            this.fileType = this.setFileType();
            this.data = getData();  
        }

        public int CompareTo(ArchiveEntry other)
        {
            return this.name.CompareTo(other.getName());
        }

        public bool Equals(ArchiveEntry other)
        {
            return (this.name == other.getName());
        }

        public void extractTo(string path, bool useFileName = false)
         {
            BinaryWriter writer = new BinaryWriter(
                File.Open((useFileName) ? path : Path.Combine(path, string.Concat(new object[] { this.name, this.extension }))
                , FileMode.Create
                , FileAccess.Write
                , FileShare.Read)
                );
            byte[] buffer = this.getData();
            writer.Write(buffer, 0, buffer.Length);
            writer.Close();
        }

        void cr_xor(byte[] data)
        {
            byte[] key = { 0x87, 0xad, 0x32, 0x47 };

            for (int i = 0; i < data.Length; i++)
                data[i] ^= key[i % key.Length];
        }

        public byte[] getData()
        {
            if (data != null)
                return data;
            else
            {
                byte[] buffer = new byte[this.sizeData];
                FileStream stream = File.OpenRead(this.path);
                if (!this.insideArchive)
                {
                    try
                    {
                        stream.Read(buffer, 0, this.sizeData);
                        stream.Close();
                        return buffer;
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
                try
                {
                    stream.Position = this.position + 0x18L;
                    stream.Read(buffer, 0, this.sizeData);
                    stream.Close();
                }
                finally
                {
                    stream.Close();
                }

                switch(encryptionType)
                {
                    case EncryptionType.CR:
                        cr_xor(buffer);
                        break;
                    case EncryptionType.None:
                    default:
                        break;
                }

                return buffer;
            }
        }

        public string getExtension()
        {
            return this.extension;
        }

        public string getFileType()
        {
            return this.fileType;
        }

        public int getId()
        {
            return this.id;
        }

        public string getName()
        {
            return this.name;
        }

        public string getNameExtension()
        {
            return (this.name + this.extension);
        }

        public int getSizeData()
        {
            return this.sizeData;
        }

        public void pack(BinaryWriter writer)
        {
            writer.BaseStream.Write(BitConverter.GetBytes(this.id), 0, 4);
            writer.BaseStream.Write(BitConverter.GetBytes(this.sizeData), 0, 4);
            writer.BaseStream.Write(DUMMY, 0, 4);
            var bytes = Encoding.ASCII.GetBytes(this.name.ToNativeString(12));
            writer.BaseStream.Write(bytes, 0, bytes.Length);

            byte[] buffer = this.getData();

            switch (encryptionType)
            {
                case EncryptionType.CR:
                    cr_xor(buffer);
                    break;
                case EncryptionType.None:
                default:
                    break;
            }

            writer.Write(buffer, 0, buffer.Length);
        }


        public string readExtension()
        {
            if (!insideArchive && Path.GetExtension(path) == ".obi")
                return ".obi";

            if (!insideArchive && Path.GetExtension(path) == ".eff")
                return ".eff";

            return FileType.GetExtensionByHeader(this.getData(), Path.GetFileNameWithoutExtension(path));
        }

        private string readName(BinaryReader reader)
        {
            char[] chArray = new char[12];
            ushort index = 0;
            while ((reader.PeekChar() != 0) & (index < 12))
            {
                chArray[index] = reader.ReadChar();
                index = (ushort) (index + 1);
            }
            reader.ReadBytes(12 - index);
            return new string(chArray).Replace("\0", string.Empty);
        }

        public void replaceWith(ArchiveEntry that)
        {
            this.insideArchive = that.insideArchive;
            this.extension = that.extension;
            this.fileType = this.getFileType();
            this.path = that.path;
            this.sizeData = that.sizeData;
        }

        private string setFileType()
        {
            return FileType.GetDescription(this.getExtension());
        }
    }
}

