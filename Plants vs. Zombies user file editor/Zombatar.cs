using System;
using System.IO;

namespace Plants_vs.Zombies_user_file_editor
{
    class Zombatar
    {
        private uint unknown;
        public int SkinColor;
        public int ClothesType;
        public int ClothesColor;
        public int TidbitsType;
        public int TidbitsColor;
        public int AccessoriesType;
        public int AccessoriesColor;
        public int FacialHairType;
        public int FacialHairColor;
        public int HairType;
        public int HairColor;
        public int EyewearType;
        public int EyewearColor;
        public int HatType;
        public int HatColor;
        public int BackdropType;
        public int BackdropColor;

        public void Load(BinaryReader reader)
        {
            unknown = reader.ReadUInt32();
            SkinColor = reader.ReadInt32();
            ClothesType = reader.ReadInt32();
            ClothesColor = reader.ReadInt32();
            TidbitsType = reader.ReadInt32();
            TidbitsColor = reader.ReadInt32();
            AccessoriesType = reader.ReadInt32();
            AccessoriesColor = reader.ReadInt32();
            FacialHairType = reader.ReadInt32();
            FacialHairColor = reader.ReadInt32();
            HairType = reader.ReadInt32();
            HairColor = reader.ReadInt32();
            EyewearType = reader.ReadInt32();
            EyewearColor = reader.ReadInt32();
            HatType = reader.ReadInt32();
            HatColor = reader.ReadInt32();
            BackdropType = reader.ReadInt32();
            BackdropColor = reader.ReadInt32();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(unknown);
            writer.Write(SkinColor);
            writer.Write(ClothesType);
            writer.Write(ClothesColor);
            writer.Write(TidbitsType);
            writer.Write(TidbitsColor);
            writer.Write(AccessoriesType);
            writer.Write(AccessoriesColor);
            writer.Write(FacialHairType);
            writer.Write(FacialHairColor);
            writer.Write(HairType);
            writer.Write(HairColor);
            writer.Write(EyewearType);
            writer.Write(EyewearColor);
            writer.Write(HatType);
            writer.Write(HatColor);
            writer.Write(BackdropType);
            writer.Write(BackdropColor);
        }
    }
}
