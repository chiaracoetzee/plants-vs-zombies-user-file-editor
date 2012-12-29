using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Plants_vs.Zombies_user_file_editor
{
    static class IOUtils
    {
        static public DateTime ReadDaysSince2000(BinaryReader reader)
        {
            return new DateTime(2000, 1, 1).AddDays(reader.ReadInt32());
        }

        static public void WriteDaysSince2000(BinaryWriter writer, DateTime date)
        {
            writer.Write((int)date.Subtract(new DateTime(2000, 1, 1)).TotalDays);
        }

        static public int? ReadInt32Offset(BinaryReader reader, int offset)
        {
            int value = reader.ReadInt32();
            return value == 0 ? null : (int?)(value - offset);
        }

        static public void WriteInt32Offset(BinaryWriter writer, int? value, int offset)
        {
            writer.Write(value == null ? 0 : (int)value + offset);
        }

        static public void ReadInt32Array(BinaryReader reader, Int32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadInt32();
            }
        }

        static public void WriteInt32Array(BinaryWriter writer, Int32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }

        static public void ReadBoolPreserveNonzeroArray(BinaryReader reader, BoolPreserveNonzero[] array, int length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ReadBoolPreserveNonzero(reader, length);
            }
        }

        static public BoolPreserveNonzero ReadBoolPreserveNonzero(BinaryReader reader, int length)
        {
            if (length == 4)
            {
                return new BoolPreserveNonzero(reader.ReadInt32());
            }
            else if (length == 2)
            {
                return new BoolPreserveNonzero(reader.ReadInt16());
            }
            else if (length == 1)
            {
                return new BoolPreserveNonzero(reader.ReadByte());
            }
            else
            {
                throw new ArgumentException("Length must be 1, 2, or 4 bytes but was " + length);
            }
        }

        static public void WriteBoolPreserveNonzeroArray(BinaryWriter writer, BoolPreserveNonzero[] array, int length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                WriteBoolPreserveNonzero(writer, array[i], length);
            }
        }

        static public void WriteBoolPreserveNonzero(BinaryWriter writer, BoolPreserveNonzero value, int length)
        {
            if (length == 4)
            {
                writer.Write(value.IntValue);
            }
            else if (length == 2)
            {
                writer.Write((short)value.IntValue);
            }
            else if (length == 1)
            {
                writer.Write((byte)value.IntValue);
            }
            else
            {
                throw new ArgumentException("Length must be 1, 2, or 4 bytes but was " + length);
            }
        }

        static public DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        static public DateTime ReadUnixTimestamp(BinaryReader reader)
        {
            int timestamp = reader.ReadInt32();
            if (timestamp == 0)
            {
                return DateTime.MinValue;
            }
            else
            {
                return epoch.AddSeconds(timestamp).ToLocalTime();
            }
        }

        static public void WriteUnixTimestamp(BinaryWriter writer, DateTime value)
        {
            if (value == DateTime.MinValue)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write((int)value.ToUniversalTime().Subtract(epoch).TotalSeconds);
            }
        }

        static public void ReadUInt32Array(BinaryReader reader, UInt32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = reader.ReadUInt32();
            }
        }

        static public void WriteUInt32Array(BinaryWriter writer, UInt32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
        }
    }
}
