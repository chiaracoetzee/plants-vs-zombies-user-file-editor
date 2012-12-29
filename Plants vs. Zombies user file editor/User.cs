using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Plants_vs.Zombies_user_file_editor
{
    class IncompatibleVersionException : Exception
    {
    }

    class User
    {
        public string Name;
        public string UserFilePath;
        public Level Level = new Level();
        private int moneyOver10;
        public int[] SurvivalModeFlags = new int[10];
        private uint[] unknown1 = new uint[2];
        public int StreakLengthEndlessSurvival;
        private uint[] unknown2 = new uint[2];
        public BoolPreserveNonzero[] HasMinigameTrophy = new BoolPreserveNonzero[20];
        private uint[] unknown3 = new uint[14];
        public int NumTimesAdventureModeCompleted;
        public int TreeOfWisdomHeight;
        public BoolPreserveNonzero[] HasVaseBreakerTrophy = new BoolPreserveNonzero[9];
        public int StreakLengthVaseBreakerEndless;
        public BoolPreserveNonzero[] HasIZombieTrophy = new BoolPreserveNonzero[9];
        public int StreakLengthIZombieEndless;
        private uint[] unknown4 = new uint[30];
        public BoolPreserveNonzero[] HasShopPlant = new BoolPreserveNonzero[9];
        private uint unknown5;
        public DateTime[] MarigoldLastPurchased = new DateTime[3];
        public BoolPreserveNonzero HasGoldenWateringCan;
        public int? FertilizerAmount;
        public int? BugSprayAmount;
        public BoolPreserveNonzero HasPhonograph;
        public BoolPreserveNonzero HasGardeningGlove;
        public BoolPreserveNonzero HasMushroomGarden;
        public BoolPreserveNonzero HasWheelbarrow;
        public DateTime StinkyLastAwokenTime;
        public int NumberSlots;
        public BoolPreserveNonzero HasPoolCleaners;
        public BoolPreserveNonzero HasRoofCleaners;
        public uint RakeUses;
        public BoolPreserveNonzero HasAquariumGarden;
        public int? ChocolateAmount;
        public BoolPreserveNonzero TreeOfWisdomAvailable;
        public int? TreeFoodAmount;
        public BoolPreserveNonzero HasWallNutFirstAid;
        private uint[] unknown6 = new uint[54];
        private uint unknown7;
        public DateTime StinkyLastChocolateTime;
        public int StinkyXPosition;
        public int StinkyYPosition;
        public BoolPreserveNonzero MiniGamesUnlocked;
        public BoolPreserveNonzero PuzzleModeUnlocked;
        public BoolPreserveNonzero AnimateUnlockMiniGame;
        public BoolPreserveNonzero AnimateUnlockVasebreaker;
        public BoolPreserveNonzero AnimateUnlockIZombie;
        public BoolPreserveNonzero AnimateUnlockSurvival;
        private uint unknown8;
        public BoolPreserveNonzero ShowAdventureCompleteDialog;
        public BoolPreserveNonzero HasTaco;
        private uint[] unknown9 = new uint[3];
        public ZenGardenPlant[] ZenGardenPlants;
        public BoolPreserveNonzero[] HasAchievement = new BoolPreserveNonzero[20];
        public BoolPreserveNonzero AcceptedZombatarLicenseAgreement;
        public Zombatar[] Zombatars;
        private uint[] unknown10 = new uint[5];
        private BoolPreserveNonzero HaveCreatedZombatar;
        private byte[] trailingData;

        public int Money
        {
            get
            {
                return moneyOver10 * 10;
            }
            set
            {
                if ((value % 10) != 0)
                {
                    throw new ArgumentException("Money must be divisible by 10");
                }
                moneyOver10 = value / 10;
            }
        }

        public User(string name, string filePath)
        {
            this.Name = name;
            this.UserFilePath = filePath;
        }

        public void Load(bool forceReadIncompatibleVersion)
        {
            using (var reader = new BinaryReader(new FileStream(UserFilePath, FileMode.Open, FileAccess.Read)))
            {
                var version = reader.ReadUInt32();
                if (version != 0x0C && !forceReadIncompatibleVersion)
                {
                    throw new IncompatibleVersionException();
                }
                Level.Read(reader);
                moneyOver10 = reader.ReadInt32();
                NumTimesAdventureModeCompleted = reader.ReadInt32();

                IOUtils.ReadInt32Array(reader, SurvivalModeFlags);
                IOUtils.ReadUInt32Array(reader, unknown1);
                StreakLengthEndlessSurvival = reader.ReadInt32();

                IOUtils.ReadUInt32Array(reader, unknown2);

                IOUtils.ReadBoolPreserveNonzeroArray(reader, HasMinigameTrophy, 4);
                IOUtils.ReadUInt32Array(reader, unknown3);
                TreeOfWisdomHeight = reader.ReadInt32();
                IOUtils.ReadBoolPreserveNonzeroArray(reader, HasVaseBreakerTrophy, 4);
                StreakLengthVaseBreakerEndless = reader.ReadInt32();
                IOUtils.ReadBoolPreserveNonzeroArray(reader, HasIZombieTrophy, 4);
                StreakLengthIZombieEndless = reader.ReadInt32();

                IOUtils.ReadUInt32Array(reader, unknown4);

                IOUtils.ReadBoolPreserveNonzeroArray(reader, HasShopPlant, 4);
                unknown5 = reader.ReadUInt32();
                for (int i=0; i < MarigoldLastPurchased.Length; i++)
                {
                    MarigoldLastPurchased[i] = IOUtils.ReadDaysSince2000(reader);
                }
                HasGoldenWateringCan = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                FertilizerAmount = IOUtils.ReadInt32Offset(reader, 1000);
                BugSprayAmount = IOUtils.ReadInt32Offset(reader, 1000);
                HasPhonograph = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                HasGardeningGlove = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                HasMushroomGarden = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                HasWheelbarrow = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                StinkyLastAwokenTime = IOUtils.ReadUnixTimestamp(reader);
                NumberSlots = reader.ReadInt32() + 6;
                HasPoolCleaners = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                HasRoofCleaners = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                RakeUses = reader.ReadUInt32();
                HasAquariumGarden = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                ChocolateAmount = IOUtils.ReadInt32Offset(reader, 1000);
                TreeOfWisdomAvailable = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                TreeFoodAmount = IOUtils.ReadInt32Offset(reader, 1000);
                HasWallNutFirstAid = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                IOUtils.ReadUInt32Array(reader, unknown6);
                unknown7 = reader.ReadUInt32();
                StinkyLastChocolateTime = IOUtils.ReadUnixTimestamp(reader);
                StinkyXPosition = reader.ReadInt32();
                StinkyYPosition = reader.ReadInt32();
                MiniGamesUnlocked = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                PuzzleModeUnlocked = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                AnimateUnlockMiniGame = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                AnimateUnlockVasebreaker = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                AnimateUnlockIZombie = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                AnimateUnlockSurvival = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                unknown8 = reader.ReadUInt32();
                ShowAdventureCompleteDialog = IOUtils.ReadBoolPreserveNonzero(reader, 4);
                HasTaco = IOUtils.ReadBoolPreserveNonzero(reader, 4);

                IOUtils.ReadUInt32Array(reader, unknown9);

                var numZenGardenPlants = reader.ReadUInt32();
                ZenGardenPlants = new ZenGardenPlant[numZenGardenPlants];
                for (int i = 0; i < ZenGardenPlants.Length; i++)
                {
                    ZenGardenPlants[i] = new ZenGardenPlant();
                    ZenGardenPlants[i].Load(reader);
                }

                IOUtils.ReadBoolPreserveNonzeroArray(reader, HasAchievement, 2);
                
                AcceptedZombatarLicenseAgreement = IOUtils.ReadBoolPreserveNonzero(reader, 1);
                var numZombatars = reader.ReadUInt32();
                Zombatars = new Zombatar[numZombatars];
                for (int i = 0; i < Zombatars.Length; i++)
                {
                    Zombatars[i] = new Zombatar();
                    Zombatars[i].Load(reader);
                }

                IOUtils.ReadUInt32Array(reader, unknown10);

                HaveCreatedZombatar = IOUtils.ReadBoolPreserveNonzero(reader, 1);

                // Read all trailing data into a buffer - if we're dealing with an incompatible version this might let us succeed
                // Warning: this might allocate a lot of memory if the file is huge for some reason 
                trailingData = reader.ReadBytes((int)new FileInfo(UserFilePath).Length);
            }
        }

        public void Save()
        {
            using (var writer = new BinaryWriter(new FileStream(UserFilePath, FileMode.Create, FileAccess.Write)))
            {
                writer.Write(0x0C); // Version
                Level.Write(writer);
                writer.Write(moneyOver10);
                writer.Write(NumTimesAdventureModeCompleted);
                IOUtils.WriteInt32Array(writer, SurvivalModeFlags);
                IOUtils.WriteUInt32Array(writer, unknown1);
                writer.Write(StreakLengthEndlessSurvival);
                IOUtils.WriteUInt32Array(writer, unknown2);
                IOUtils.WriteBoolPreserveNonzeroArray(writer, HasMinigameTrophy, 4);
                IOUtils.WriteUInt32Array(writer, unknown3);

                writer.Write(TreeOfWisdomHeight);
                IOUtils.WriteBoolPreserveNonzeroArray(writer, HasVaseBreakerTrophy, 4);
                writer.Write(StreakLengthVaseBreakerEndless);
                IOUtils.WriteBoolPreserveNonzeroArray(writer, HasIZombieTrophy, 4);
                writer.Write(StreakLengthIZombieEndless);

                IOUtils.WriteUInt32Array(writer, unknown4);

                IOUtils.WriteBoolPreserveNonzeroArray(writer, HasShopPlant, 4);
                writer.Write(unknown5);
                for (int i = 0; i < MarigoldLastPurchased.Length; i++)
                {
                    IOUtils.WriteDaysSince2000(writer, MarigoldLastPurchased[i]);
                }
                IOUtils.WriteBoolPreserveNonzero(writer, HasGoldenWateringCan, 4);
                IOUtils.WriteInt32Offset(writer, FertilizerAmount, 1000);
                IOUtils.WriteInt32Offset(writer, BugSprayAmount, 1000);
                IOUtils.WriteBoolPreserveNonzero(writer, HasPhonograph, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, HasGardeningGlove, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, HasMushroomGarden, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, HasWheelbarrow, 4);
                IOUtils.WriteUnixTimestamp(writer, StinkyLastAwokenTime);
                writer.Write(NumberSlots - 6);
                IOUtils.WriteBoolPreserveNonzero(writer, HasPoolCleaners, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, HasRoofCleaners, 4);
                writer.Write(RakeUses);
                IOUtils.WriteBoolPreserveNonzero(writer, HasAquariumGarden, 4);
                IOUtils.WriteInt32Offset(writer, ChocolateAmount, 1000);
                IOUtils.WriteBoolPreserveNonzero(writer, TreeOfWisdomAvailable, 4);
                IOUtils.WriteInt32Offset(writer, TreeFoodAmount, 1000);
                IOUtils.WriteBoolPreserveNonzero(writer, HasWallNutFirstAid, 4);
                IOUtils.WriteUInt32Array(writer, unknown6);
                writer.Write(unknown7);
                IOUtils.WriteUnixTimestamp(writer, StinkyLastChocolateTime);
                writer.Write(StinkyXPosition);
                writer.Write(StinkyYPosition);
                IOUtils.WriteBoolPreserveNonzero(writer, MiniGamesUnlocked, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, PuzzleModeUnlocked, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, AnimateUnlockMiniGame, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, AnimateUnlockVasebreaker, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, AnimateUnlockIZombie, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, AnimateUnlockSurvival, 4);
                writer.Write(unknown8);
                IOUtils.WriteBoolPreserveNonzero(writer, ShowAdventureCompleteDialog, 4);
                IOUtils.WriteBoolPreserveNonzero(writer, HasTaco, 4);

                IOUtils.WriteUInt32Array(writer, unknown9);

                writer.Write(ZenGardenPlants.Length);
                for (int i = 0; i < ZenGardenPlants.Length; i++)
                {
                    ZenGardenPlants[i].Save(writer);
                }

                IOUtils.WriteBoolPreserveNonzeroArray(writer, HasAchievement, 2);

                IOUtils.WriteBoolPreserveNonzero(writer, AcceptedZombatarLicenseAgreement, 1);
                writer.Write(Zombatars.Length);
                for (int i = 0; i < Zombatars.Length; i++)
                {
                    Zombatars[i].Save(writer);
                }

                IOUtils.WriteUInt32Array(writer, unknown10);

                IOUtils.WriteBoolPreserveNonzero(writer, HaveCreatedZombatar, 1);

                writer.Write(trailingData);
            }
        }
    }
}
