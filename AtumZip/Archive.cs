namespace Ace_Globals
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Archive
    {
        private static byte[] DUMMY = new byte[4];
        private List<ArchiveEntry> entries;
        private static byte[] HEADER = new byte[] { 0xe8, 3, 0, 0, 0xe8, 3, 0, 0 };
        private string path;
        private BinaryReader reader;
        private BinaryWriter writer;

        public Archive(string path, bool isPacked, EncryptionType encryptionType)
        {
            int length;
            if (isPacked)
            {
                this.path = path;
                this.reader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
                if (this.isValidArchive(this.reader))
                {
                    Stream baseStream = this.reader.BaseStream;
                    baseStream.Position += 4L;
                    length = Convert.ToInt32(this.reader.ReadUInt32());
                    this.reader.ReadUInt32();
                    this.entries = new List<ArchiveEntry>(length);
                    for (int i = 0; i < length; i++)
                    {
                        this.entries.Add(new ArchiveEntry(this.path, this.reader, true, encryptionType));
                    }
                }
                this.reader.Close();
            }
            else
            {
                this.path = path;
                if (String.IsNullOrWhiteSpace(this.path))
                {
                    this.entries = new List<ArchiveEntry>();
                }
                else
                {
                    length = Directory.GetFiles(path).Length;
                    this.entries = new List<ArchiveEntry>(length);
                    foreach (string str in Directory.GetFiles(path))
                    {
                        this.reader = new BinaryReader(File.Open(str, FileMode.Open, FileAccess.Read, FileShare.Read));
                        this.entries.Add(new ArchiveEntry(str, this.reader, false, encryptionType));
                        this.reader.Close();
                    }
                }
            }
        }

        public bool add(ArchiveEntry ae)
        {
            int index = this.entries.IndexOf(ae);
            if (index != -1)
            {
                this.entries[index] = ae;
                return false;
            }
            else
            {
                this.entries.Add(ae);
                this.entries.Sort();
                return true;
            }
        }

        public bool remove(ArchiveEntry ae)
        {
            if (this.entries.Contains(ae))
            {
                this.entries.Remove(ae);
                this.entries.Sort();
                return true;
            }
            return false;
        }

        public bool remove(string Name)
        {
            ArchiveEntry ent = getByName(Name);
            if (ent != null)
            {
                this.entries.Remove(ent);
                this.entries.Sort();
                return true;
            }

            return false;
        }

        public ArchiveEntry getByName(string Name)
        {
            foreach (ArchiveEntry ent in this.entries)
                if (String.Equals(ent.getName(), Name))
                    return ent;

            return null;
        }

        private bool arraysEqual(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
            {
                return false;
            }
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void extractTo(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (this.entries == null)
                return;

            foreach (ArchiveEntry entry in this.entries)
            {
                entry.extractTo(path);
            }
        }

        public int getCountEntries()
        {
            return this.entries.Count;
        }

        public List<ArchiveEntry> getEntries()
        {
            return this.entries;
        }

        public byte[] getModel()
        {
            foreach (ArchiveEntry entry in this.entries)
            {
                if (entry.getFileType() == "model")
                {
                    return entry.getData();
                }
            }
            return null;
        }

        public string getName()
        {
            return Path.GetFileName(this.path);
        }

        public string getPath()
        {
            return this.path;
        }

        public int getSizeData()
        {
            int num = 0;
            foreach (ArchiveEntry entry in this.entries)
            {
                num += entry.getSizeData();
            }
            return num;
        }

        public bool isValidArchive(BinaryReader reader)
        {
            byte[] buffer = new byte[8];
            reader.BaseStream.Read(buffer, 0, 8);
            return this.arraysEqual(HEADER, buffer);
        }

        public void write(string path)
        {
            this.writer = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read));
            this.writer.BaseStream.Write(HEADER, 0, 8);
            this.writer.BaseStream.Write(BitConverter.GetBytes(this.getSizeData()), 0, 4);
            byte[] bytes = BitConverter.GetBytes(this.getCountEntries());
            this.writer.BaseStream.Write(bytes, 0, 4);
            this.writer.BaseStream.Write(DUMMY, 0, 4);
            foreach (ArchiveEntry entry in this.entries)
            {
                entry.pack(this.writer);
            }
            this.writer.Close();
        }
    }
}

