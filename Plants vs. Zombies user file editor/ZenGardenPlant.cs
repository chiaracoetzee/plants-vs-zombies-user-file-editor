using System;
using System.IO;

namespace Plants_vs.Zombies_user_file_editor
{
    enum ZenGardenPlantNeeds
    {
        Nothing = 0,
        BugSpray = 3,
        Phonograph = 4
    }

    class ZenGardenPlant
    {
        static public string[] PlantTypeNames =
        {
            "Peashooter",
            "Sunflower",
            "Cherry Bomb",
            "Wall-nut",
            "Potato Mine",
            "Snow Pea",
            "Chomper",
            "Repeater",
            "Puff-shroom",
            "Sun-shroom",
            "Fume-shroom",
            "Grave Buster",
            "Hypno-shroom",
            "Scaredy-shroom",
            "Ice-shroom",
            "Doom-shroom",
            "Lily pad",
            "Squash",
            "Threepeater",
            "Tangle Kelp",
            "Jalapeno",
            "Spikeweed",
            "Torchwood",
            "Tall-nut",
            "Sea-shroom",
            "Plantern",
            "Cactus",
            "Blover",
            "Split Pea",
            "Starfruit",
            "Pumpkin",
            "Magnet-shroom",
            "Cabbage-pult",
            "Flower Pot",
            "Kernel-pult",
            "Coffee Bean",
            "Garlic",
            "Umbrella Leaf",
            "Marigold",
            "Melon-pult",
            "Gatling Pea",
            "Twin Sunflower",
            "Gloom-shroom",
            "Cattail",
            "Winter Melon",
            "Gold Magnet",
            "Spikerock",
            "Cob Cannon",
            "The Imitater",
            "Explode-o-nut",
            "Giant Wall-nut",
            "Sprout",
            "Repeater"
        };

        public const int Marigold = 38;

        static public string[] GardenNames =
        {
            "Zen Garden",
            "Mushroom Garden",
            "Wheelbarrow",
            "Aquarium"
        };

        static public string[] ColorNames =
        {
            "",
            "All white",
            "White",
            "Magenta",
            "Orange",
            "Pink",
            "Cyan",
            "Red",
            "Blue",
            "Purple",
            "Light purple",
            "Yellow",
            "Light green"
        };

        public int PlantType;
        public int GardenLocation;
        public int Column;
        public int Row;
        private uint[] unknown1 = new uint[2];
        public DateTime LastWateringTime;
        private uint unknown2;
        public int Color;
        public int NumTimesFertilized;
        public int NumTimesWatered;
        private uint unknown3;
        public ZenGardenPlantNeeds NeedsPhonographOrBugSpray;
        public uint unknown4;
        public DateTime LastPhonographOrBugSprayTime;
        public uint unknown5;
        public DateTime LastFertilizerTime;
        public uint[] unknown6 = new uint[5];

        public ZenGardenPlant()
        {
            PlantType = Marigold;
            Color = 2;
            GardenLocation = 0;
            Row = 0;
            Column = 0;
            unknown1[0] = 1;
            unknown3 = 5;
            LastWateringTime = DateTime.MinValue;
            LastPhonographOrBugSprayTime = DateTime.MinValue;
            LastFertilizerTime = DateTime.MinValue;
        }

        public ZenGardenPlant(ZenGardenPlant plant)
        {
            PlantType = plant.PlantType;
            GardenLocation = plant.GardenLocation;
            Column = plant.Column;
            Row = plant.Row;
            Array.Copy(plant.unknown1, unknown1, 2);
            LastWateringTime = plant.LastWateringTime;
            unknown2 = plant.unknown2;
            Color = plant.Color;
            NumTimesFertilized = plant.NumTimesFertilized;
            NumTimesWatered = plant.NumTimesWatered;
            unknown3 = plant.unknown3;
            NeedsPhonographOrBugSpray = plant.NeedsPhonographOrBugSpray;
            unknown4 = plant.unknown4;
            LastPhonographOrBugSprayTime = plant.LastPhonographOrBugSprayTime;
            unknown5 = plant.unknown5;
            LastFertilizerTime = plant.LastFertilizerTime;
            Array.Copy(plant.unknown6, unknown6, 5);
        }

        public void Load(BinaryReader reader)
        {
            PlantType = reader.ReadInt32();
            GardenLocation = reader.ReadInt32();
            Column = reader.ReadInt32();
            Row = reader.ReadInt32();
            IOUtils.ReadUInt32Array(reader, unknown1);
            LastWateringTime = IOUtils.ReadUnixTimestamp(reader);
            unknown2 = reader.ReadUInt32();
            Color = reader.ReadInt32();
            NumTimesFertilized = reader.ReadInt32();
            NumTimesWatered = reader.ReadInt32();
            unknown3 = reader.ReadUInt32();
            NeedsPhonographOrBugSpray = (ZenGardenPlantNeeds)reader.ReadInt32();
            unknown4 = reader.ReadUInt32();
            LastPhonographOrBugSprayTime = IOUtils.ReadUnixTimestamp(reader);
            unknown5 = reader.ReadUInt32();
            LastFertilizerTime = IOUtils.ReadUnixTimestamp(reader);
            IOUtils.ReadUInt32Array(reader, unknown6);
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(PlantType);
            writer.Write(GardenLocation);
            writer.Write(Column);
            writer.Write(Row);
            IOUtils.WriteUInt32Array(writer, unknown1);
            IOUtils.WriteUnixTimestamp(writer, LastWateringTime);
            writer.Write(unknown2);
            writer.Write(Color);
            writer.Write(NumTimesFertilized);
            writer.Write(NumTimesWatered);
            writer.Write(unknown3);
            writer.Write((int)NeedsPhonographOrBugSpray);
            writer.Write(unknown4);
            IOUtils.WriteUnixTimestamp(writer, LastPhonographOrBugSprayTime);
            writer.Write(unknown5);
            IOUtils.WriteUnixTimestamp(writer, LastFertilizerTime);
            IOUtils.WriteUInt32Array(writer, unknown6);
        }

        public override string ToString()
        {
            string result = "";
            if (PlantType == Marigold)
            {
                result += ColorNames[Color] + " ";
            }
            result += PlantTypeNames[PlantType] + " at " + GardenNames[GardenLocation] + ", ";
            if (GardenLocation == 0)
            {
                result += "(" + (Row + 1) + "," + (Column + 1) + ")";
            }
            else
            {
                result += (Column + 1);
            }
            return result;
        }
    }
}
