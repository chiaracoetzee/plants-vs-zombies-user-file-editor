using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Plants_vs.Zombies_user_file_editor
{
    class Level
    {
        public static string[] Names =
        {
            "1-1", "1-2", "1-3", "1-4", "1-5", "1-6", "1-7", "1-8", "1-9", "1-10",
            "2-1", "2-2", "2-3", "2-4", "2-5", "2-6", "2-7", "2-8", "2-9", "2-10",
            "3-1", "3-2", "3-3", "3-4", "3-5", "3-6", "3-7", "3-8", "3-9", "3-10",
            "4-1", "4-2", "4-3", "4-4", "4-5", "4-6", "4-7", "4-8", "4-9", "4-10",
            "5-1", "5-2", "5-3", "5-4", "5-5", "5-6", "5-7", "5-8", "5-9", "5-10",
        };

        public static string[] NamesWithUnlocks =
        {
            "1-1 - Pea Shooter available",
            "1-2 - Sunflower available",
            "1-3 - Cherry Bomb available",
            "1-4 - Wall-nut available",
            "1-5",
            "1-6 - Potato Mine available",
            "1-7 - Snow Pea available",
            "1-8 - Chomper available",
            "1-9 - Repeater available",
            "1-10",
            "2-1 - Puff-shroom available",
            "2-2 - Sun-shroom available",
            "2-3 - Fume-shroom available",
            "2-4 - Grave Buster available",
            "2-5 - *Almanac unlocked*",
            "2-6 - Hypno-shroom available",
            "2-7 - Scaredy-shroom available",
            "2-8 - Ice-shroom available",
            "2-9 - Doom-shroom available",
            "2-10",
            "3-1 - Lily Pad available",
            "3-2 - Squash available",
            "3-3 - Threepeater available",
            "3-4 - Tangle Kelp available",
            "3-5 - *Shop unlocked*",
            "3-6 - Jalapeno available",
            "3-7 - Spikeweed available",
            "3-8 - Torchwood available",
            "3-9 - Tall-nut available",
            "3-10",
            "4-1 - Sea-shroom available",
            "4-2 - Plantern available",
            "4-3 - Cactus available",
            "4-4 - Blover available",
            "4-5 - *Gloom-shroom, Cattail available in shop*",
            "4-6 - Split Pea available",
            "4-7 - Starfruit available",
            "4-8 - Pumpkin available",
            "4-9 - Magnet-shroom available",
            "4-10",
            "5-1 - Cabbage-pult available",
            "5-2 - Flower Pot available, *more items in shop*",
            "5-3 - Kernel-pult available",
            "5-4 - Coffee Bean available",
            "5-5 - *Zen Garden unlocked*",
            "5-6 - Garlic available",
            "5-7 - Umbrella Leaf available",
            "5-8 - Marigold available",
            "5-9 - Melon-pult available",
            "5-10"
        };

        private int level;

        public Level()
        {
            level = 1;
        }
        
        public void Read(BinaryReader reader)
        {
            level = reader.ReadInt32();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(level);
        }

        public int Index
        {
            get
            {
                return level - 1;
            }
            set
            {
                level = value + 1;
            }
        }

        public override string ToString()
        {
            return ((level - 1)/10 + 1).ToString() + "-" + ((level % 10 == 0) ? 10 : level % 10).ToString();
        }
    }
}
