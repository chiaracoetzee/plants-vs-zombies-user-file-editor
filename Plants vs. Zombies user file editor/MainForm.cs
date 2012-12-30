using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plants_vs.Zombies_user_file_editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        User user;

        const string IncompatibleVersionCaption = "Incompatible version";
        const string IncompatibleVersionMessage = "This application was designed for use with another version of Plants vs. Zombies. The application will back up your user data file, but may cause corruption. If you continue, results may be unpredictable. Continue?";
        const string GameIsRunningCaption = "Game currently running";
        const string GameIsRunningMessage = "Plants vs. Zombies is currently running. You must either change to a different user or quit the game before saving. Continue saving?";
        const string UnsavedChangesCaption = "Unsaved changes";
        const string UnsavedChangesMessage = "You have made changes but not saved them to the user file. Are you sure you want to quit without saving?";

        bool acceptedIncompatibleVersion = false;

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeControlArrays();

            SelectUser();

            comboBoxPlantType.Items.AddRange(ZenGardenPlant.PlantTypeNames);
            foreach (string s in ZenGardenPlant.ColorNames)
            {
                if (s != "") comboBoxColor.Items.Add(s);
            }
            foreach (string s in ZenGardenPlant.GardenNames)
            {
                if (s != "") comboBoxGarden.Items.Add(s);
            }
        }

        CheckBox[] miniGameTrophyCheckbox = new CheckBox[20];
        CheckBox[] vaseBreakerTrophyCheckbox = new CheckBox[9];
        CheckBox[] iZombieTrophyCheckbox = new CheckBox[9];
        NumericUpDown[] survivalNumericUpDown = new NumericUpDown[10];
        DateTimePicker[] marigoldDateTimePicker = new DateTimePicker[3];
        CheckBox[] marigoldNeverPurchasedCheckBox = new CheckBox[3];
        CheckBox[] shopPlantCheckBox = new CheckBox[9];
        CheckBox[] achievementCheckBox = new CheckBox[20];

        private void InitializeControlArrays()
        {
            miniGameTrophyCheckbox[0] = checkBoxMinigame0;
            miniGameTrophyCheckbox[1] = checkBoxMinigame1;
            miniGameTrophyCheckbox[2] = checkBoxMinigame2;
            miniGameTrophyCheckbox[3] = checkBoxMinigame3;
            miniGameTrophyCheckbox[4] = checkBoxMinigame4;
            miniGameTrophyCheckbox[5] = checkBoxMinigame5;
            miniGameTrophyCheckbox[6] = checkBoxMinigame6;
            miniGameTrophyCheckbox[7] = checkBoxMinigame7;
            miniGameTrophyCheckbox[8] = checkBoxMinigame8;
            miniGameTrophyCheckbox[9] = checkBoxMinigame9;
            miniGameTrophyCheckbox[10] = checkBoxMinigame10;
            miniGameTrophyCheckbox[11] = checkBoxMinigame11;
            miniGameTrophyCheckbox[12] = checkBoxMinigame12;
            miniGameTrophyCheckbox[13] = checkBoxMinigame13;
            miniGameTrophyCheckbox[14] = checkBoxMinigame14;
            miniGameTrophyCheckbox[15] = checkBoxMinigame15;
            miniGameTrophyCheckbox[16] = checkBoxMinigame16;
            miniGameTrophyCheckbox[17] = checkBoxMinigame17;
            miniGameTrophyCheckbox[18] = checkBoxMinigame18;
            miniGameTrophyCheckbox[19] = checkBoxMinigame19;

            vaseBreakerTrophyCheckbox[0] = checkBoxVaseBreaker0;
            vaseBreakerTrophyCheckbox[1] = checkBoxVaseBreaker1;
            vaseBreakerTrophyCheckbox[2] = checkBoxVaseBreaker2;
            vaseBreakerTrophyCheckbox[3] = checkBoxVaseBreaker3;
            vaseBreakerTrophyCheckbox[4] = checkBoxVaseBreaker4;
            vaseBreakerTrophyCheckbox[5] = checkBoxVaseBreaker5;
            vaseBreakerTrophyCheckbox[6] = checkBoxVaseBreaker6;
            vaseBreakerTrophyCheckbox[7] = checkBoxVaseBreaker7;
            vaseBreakerTrophyCheckbox[8] = checkBoxVaseBreaker8;

            iZombieTrophyCheckbox[0] = checkBoxIZombie0;
            iZombieTrophyCheckbox[1] = checkBoxIZombie1;
            iZombieTrophyCheckbox[2] = checkBoxIZombie2;
            iZombieTrophyCheckbox[3] = checkBoxIZombie3;
            iZombieTrophyCheckbox[4] = checkBoxIZombie4;
            iZombieTrophyCheckbox[5] = checkBoxIZombie5;
            iZombieTrophyCheckbox[6] = checkBoxIZombie6;
            iZombieTrophyCheckbox[7] = checkBoxIZombie7;
            iZombieTrophyCheckbox[8] = checkBoxIZombie8;

            survivalNumericUpDown[0] = numericUpDownSurvival0;
            survivalNumericUpDown[1] = numericUpDownSurvival1;
            survivalNumericUpDown[2] = numericUpDownSurvival2;
            survivalNumericUpDown[3] = numericUpDownSurvival3;
            survivalNumericUpDown[4] = numericUpDownSurvival4;
            survivalNumericUpDown[5] = numericUpDownSurvival5;
            survivalNumericUpDown[6] = numericUpDownSurvival6;
            survivalNumericUpDown[7] = numericUpDownSurvival7;
            survivalNumericUpDown[8] = numericUpDownSurvival8;
            survivalNumericUpDown[9] = numericUpDownSurvival9;

            marigoldDateTimePicker[0] = dateTimePickerMarigold1;
            marigoldDateTimePicker[1] = dateTimePickerMarigold2;
            marigoldDateTimePicker[2] = dateTimePickerMarigold3;

            marigoldNeverPurchasedCheckBox[0] = checkBoxMarigold1Never;
            marigoldNeverPurchasedCheckBox[1] = checkBoxMarigold2Never;
            marigoldNeverPurchasedCheckBox[2] = checkBoxMarigold3Never;

            shopPlantCheckBox[0] = checkBoxShopPlant0;
            shopPlantCheckBox[1] = checkBoxShopPlant1;
            shopPlantCheckBox[2] = checkBoxShopPlant2;
            shopPlantCheckBox[3] = checkBoxShopPlant3;
            shopPlantCheckBox[4] = checkBoxShopPlant4;
            shopPlantCheckBox[5] = checkBoxShopPlant5;
            shopPlantCheckBox[6] = checkBoxShopPlant6;
            shopPlantCheckBox[7] = checkBoxShopPlant7;
            shopPlantCheckBox[8] = checkBoxShopPlant8;

            achievementCheckBox[0] = checkBoxAchievement0;
            achievementCheckBox[1] = checkBoxAchievement1;
            achievementCheckBox[2] = checkBoxAchievement2;
            achievementCheckBox[3] = checkBoxAchievement3;
            achievementCheckBox[4] = checkBoxAchievement4;
            achievementCheckBox[5] = checkBoxAchievement5;
            achievementCheckBox[6] = checkBoxAchievement6;
            achievementCheckBox[7] = checkBoxAchievement7;
            achievementCheckBox[8] = checkBoxAchievement8;
            achievementCheckBox[9] = checkBoxAchievement9;
            achievementCheckBox[10] = checkBoxAchievement10;
            achievementCheckBox[11] = checkBoxAchievement11;
            achievementCheckBox[12] = checkBoxAchievement12;
            achievementCheckBox[13] = checkBoxAchievement13;
            achievementCheckBox[14] = checkBoxAchievement14;
            achievementCheckBox[15] = checkBoxAchievement15;
            achievementCheckBox[16] = checkBoxAchievement16;
            achievementCheckBox[17] = checkBoxAchievement17;
            achievementCheckBox[18] = checkBoxAchievement18;
            achievementCheckBox[19] = checkBoxAchievement19;
        }

        private void SelectUser()
        {
            var formSelectUser = new FormSelectUser();
            if (formSelectUser.ShowDialog(this) != DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                var userName = formSelectUser.SelectedUser;
                var userFilePath = formSelectUser.UserFilePath;
                user = ReadUserFile(userName, userFilePath);
                if (user == null)
                {
                    return;
                }
                PopulateControls();
            }
        }

        private User ReadUserFile(string userName, string path)
        {
            var user = new User(userName, path);
            try
            {
                try
                {
                    user.Load(/*forceReadIncompatibleVersion*/false);
                }
                catch (IncompatibleVersionException)
                {
                    IncompatibleVersion();
                    user.Load(/*forceReadIncompatibleVersion*/true);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(this, "User file \"" + path + "\" is missing in user data location. Exiting application.", "User file not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Unable to load user file: " + e.Message + " Exiting application.", "Unable to load user file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return user;
        }

        private void PopulateControls()
        {
            // General tab
            textBoxPlayerName.Text = user.Name;
            numericUpDownNumTimesCompletedAdventureMode.Value = user.NumTimesAdventureModeCompleted;
            comboBoxAdventureModeLevel.SelectedIndex = user.Level.Index;
            UpdateComboBoxAdventureModeLevelItems();
            numericUpDownMoney.Value = user.Money;

            for (int i = 0; i < miniGameTrophyCheckbox.Length; i++)
            {
                miniGameTrophyCheckbox[i].Checked = user.HasMinigameTrophy[i].Value;
            }
            for (int i = 0; i < vaseBreakerTrophyCheckbox.Length; i++)
            {
                vaseBreakerTrophyCheckbox[i].Checked = user.HasVaseBreakerTrophy[i].Value;
            }
            numericUpDownVaseBreakerEndless.Value = user.StreakLengthVaseBreakerEndless;
            for (int i = 0; i < iZombieTrophyCheckbox.Length; i++)
            {
                iZombieTrophyCheckbox[i].Checked = user.HasIZombieTrophy[i].Value;
            }
            numericUpDownIZombieEndless.Value = user.StreakLengthIZombieEndless;
            for (int i = 0; i < survivalNumericUpDown.Length; i++)
            {
                survivalNumericUpDown[i].Value = user.SurvivalModeFlags[i];
            }
            numericUpDownSurvivalEndless.Value = user.StreakLengthEndlessSurvival;

            checkBoxTreeOfWisdomAvailable.Checked = user.TreeOfWisdomAvailable.Value;
            numericUpDownTreeOfWisdomHeight.Value = user.TreeOfWisdomHeight;
            checkBoxPurchasedFood.Checked = user.TreeFoodAmount != null;
            if (user.TreeFoodAmount != null)
            {
                numericUpDownTreeFood.Value = (int)user.TreeFoodAmount;
            }

            for (int i = 0; i < marigoldDateTimePicker.Length; i++)
            {
                marigoldNeverPurchasedCheckBox[i].Checked = user.MarigoldLastPurchased[i] == DateTime.MinValue;
                if (user.MarigoldLastPurchased[i] != DateTime.MinValue)
                {
                    marigoldDateTimePicker[i].Value = user.MarigoldLastPurchased[i];
                }
            }

            numericUpDownNumSlots.Value = user.NumberSlots;
            checkBoxPoolCleaners.Checked = user.HasPoolCleaners.Value;
            numericUpDownRake.Value = user.RakeUses;
            checkBoxRoofCleaners.Checked = user.HasRoofCleaners.Value;
            for (int i = 0; i < shopPlantCheckBox.Length; i++)
            {
                shopPlantCheckBox[i].Checked = user.HasShopPlant[i].Value;
            }
            checkBoxWallNutFirstAid.Checked = user.HasWallNutFirstAid.Value;

            checkBoxMiniGamesUnlocked.Checked = user.MiniGamesUnlocked.Value;
            checkBoxPuzzleModeUnlocked.Checked = user.PuzzleModeUnlocked.Value;
            checkBoxHasTaco.Checked = user.HasTaco.Value;

            // Achievements tab
            for (int i = 0; i < achievementCheckBox.Length; i++)
            {
                achievementCheckBox[i].Checked = user.HasAchievement[i].Value;
            }

            // Zen Garden tab
            checkBoxGoldenWateringCan.Checked = user.HasGoldenWateringCan.Value;
            checkBoxPhonograph.Checked = user.HasPhonograph.Value;
            checkBoxGardeningGlove.Checked = user.HasGardeningGlove.Value;
            checkBoxMushroomGarden.Checked = user.HasMushroomGarden.Value;
            checkBoxAquariumGarden.Checked = user.HasAquariumGarden.Value;
            checkBoxWheelbarrow.Checked = user.HasWheelbarrow.Value;

            checkBoxFertilizerNeverPurchased.Checked = user.FertilizerAmount == null;
            if (user.FertilizerAmount != null)
            {
                numericUpDownFertilizer.Value = (int)user.FertilizerAmount;
            }
            checkBoxBugSprayNeverPurchased.Checked = user.BugSprayAmount == null;
            if (user.BugSprayAmount != null)
            {
                numericUpDownBugSpray.Value = (int)user.BugSprayAmount;
            }

            checkBoxStinkyPurchased.Checked = user.StinkyLastAwokenTime != DateTime.MinValue;
            if (user.StinkyLastAwokenTime != DateTime.MinValue)
            {
                numericUpDownLastAwoken.Value = (decimal)DateTime.Now.Subtract(user.StinkyLastAwokenTime).TotalMinutes;
            }

            checkBoxNeverChocolate.Checked = user.StinkyLastChocolateTime == DateTime.MinValue;
            if (user.StinkyLastChocolateTime != DateTime.MinValue)
            {
                numericUpDownLastChocolate.Value = (decimal)DateTime.Now.Subtract(user.StinkyLastChocolateTime).TotalMinutes;
            }

            numericUpDownStinkyX.Value = user.StinkyXPosition;
            numericUpDownStinkyY.Value = user.StinkyYPosition;

            PopulatePlantList();

            MarkChanged(false);
        }

        private void PopulatePlantList()
        {
            var selectedIndicesList = new List<int>();
            foreach (int index in listBoxPlants.SelectedIndices)
            {
                selectedIndicesList.Add(index);
            }
            listBoxPlants.Items.Clear();
            foreach (var plant in user.ZenGardenPlants)
            {
                listBoxPlants.Items.Add(plant);
            }
            listBoxPlants.SelectedIndices.Clear();
            foreach (int index in selectedIndicesList)
            {
                if (index < listBoxPlants.Items.Count)
                {
                    listBoxPlants.SelectedIndices.Add(index);
                }
                else
                {
                    listBoxPlants.SelectedIndices.Add(index - 1);
                }
            }
        }

        private void Save()
        {
            string backupFileName;
            // Create backup files
            for (int i=1; ; i++)
            {
                backupFileName = user.UserFilePath + ".bak." + i;
                if (File.Exists(backupFileName)) continue;
                break;
            }
            try
            {
                File.Copy(user.UserFilePath, backupFileName);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Unable to create backup \"" + backupFileName + "\" of user file: " + e.Message + " Save aborted.", "Can't create backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // General tab
            user.NumTimesAdventureModeCompleted = (int)numericUpDownNumTimesCompletedAdventureMode.Value;
            user.Level.Index = comboBoxAdventureModeLevel.SelectedIndex;
            user.Money = (int)numericUpDownMoney.Value;
            for (int i = 0; i < miniGameTrophyCheckbox.Length; i++)
            {
                user.HasMinigameTrophy[i].Value = miniGameTrophyCheckbox[i].Checked;
            }
            for (int i = 0; i < vaseBreakerTrophyCheckbox.Length; i++)
            {
                user.HasVaseBreakerTrophy[i].Value = vaseBreakerTrophyCheckbox[i].Checked;
            }
            user.StreakLengthVaseBreakerEndless = (int)numericUpDownVaseBreakerEndless.Value;
            for (int i = 0; i < iZombieTrophyCheckbox.Length; i++)
            {
                user.HasIZombieTrophy[i].Value = iZombieTrophyCheckbox[i].Checked;
            }
            user.StreakLengthIZombieEndless = (int)numericUpDownIZombieEndless.Value;
            for (int i = 0; i < survivalNumericUpDown.Length; i++)
            {
                user.SurvivalModeFlags[i] = (int)survivalNumericUpDown[i].Value;
            }
            user.StreakLengthEndlessSurvival = (int)numericUpDownSurvivalEndless.Value;

            user.NumberSlots = (int)numericUpDownNumSlots.Value;
            user.HasPoolCleaners.Value = checkBoxPoolCleaners.Checked;
            user.RakeUses = (uint)numericUpDownRake.Value;
            user.HasRoofCleaners.Value = checkBoxRoofCleaners.Checked;
            for (int i = 0; i < shopPlantCheckBox.Length; i++)
            {
                user.HasShopPlant[i].Value = shopPlantCheckBox[i].Checked;
            }
            user.HasWallNutFirstAid.Value = checkBoxWallNutFirstAid.Checked;

            user.MiniGamesUnlocked.Value = checkBoxMiniGamesUnlocked.Checked;
            user.PuzzleModeUnlocked.Value = checkBoxPuzzleModeUnlocked.Checked;
            user.HasTaco.Value = checkBoxHasTaco.Checked;

            // Achievements tab
            for (int i = 0; i < achievementCheckBox.Length; i++)
            {
                user.HasAchievement[i].Value = achievementCheckBox[i].Checked;
            }

            // Zen Garden tab
            user.TreeOfWisdomAvailable.Value = checkBoxTreeOfWisdomAvailable.Checked;
            user.TreeOfWisdomHeight = (int)numericUpDownTreeOfWisdomHeight.Value;
            if (checkBoxPurchasedFood.Checked)
            {
                user.TreeFoodAmount = (int)numericUpDownTreeFood.Value;
            }
            else
            {
                user.TreeFoodAmount = null;
            }

            for (int i = 0; i < marigoldDateTimePicker.Length; i++)
            {
                if (marigoldNeverPurchasedCheckBox[i].Checked)
                {
                    user.MarigoldLastPurchased[i] = DateTime.MinValue;
                }
                else
                {
                    user.MarigoldLastPurchased[i] = marigoldDateTimePicker[i].Value;
                }
            }

            user.HasGoldenWateringCan.Value = checkBoxGoldenWateringCan.Checked;
            user.HasPhonograph.Value = checkBoxPhonograph.Checked;
            user.HasGardeningGlove.Value = checkBoxGardeningGlove.Checked;
            user.HasMushroomGarden.Value = checkBoxMushroomGarden.Checked;
            user.HasAquariumGarden.Value = checkBoxAquariumGarden.Checked;
            user.HasWheelbarrow.Value = checkBoxWheelbarrow.Checked;

            if (checkBoxFertilizerNeverPurchased.Checked)
            {
                user.FertilizerAmount = null;
            }
            else
            {
                user.FertilizerAmount = (int)numericUpDownFertilizer.Value;
            }
            if (checkBoxBugSprayNeverPurchased.Checked)
            {
                user.BugSprayAmount = null;
            }
            else
            {
                user.BugSprayAmount = (int)numericUpDownBugSpray.Value;
            }

            if (!checkBoxStinkyPurchased.Checked)
            {
                user.StinkyLastAwokenTime = DateTime.MinValue;
            }
            else
            {
                user.StinkyLastAwokenTime = DateTime.Now.Subtract(TimeSpan.FromMinutes((double)numericUpDownLastAwoken.Value));
            }

            if (checkBoxNeverChocolate.Checked)
            {
                user.StinkyLastChocolateTime = DateTime.MinValue;
            }
            else
            {
                user.StinkyLastChocolateTime = DateTime.Now.Subtract(TimeSpan.FromMinutes((double)numericUpDownLastChocolate.Value));
            }

            user.StinkyXPosition = (int)numericUpDownStinkyX.Value;
            user.StinkyYPosition = (int)numericUpDownStinkyY.Value;

            try
            {
                user.Save();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Unable to save to user file: " + e.Message, "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateComboBoxAdventureModeLevelItems()
        {
            int saveIndex = comboBoxAdventureModeLevel.SelectedIndex;
            comboBoxAdventureModeLevel.Items.Clear();
            if (numericUpDownNumTimesCompletedAdventureMode.Value == 0)
            {
                comboBoxAdventureModeLevel.Items.AddRange(Level.NamesWithUnlocks);
            }
            else
            {
                comboBoxAdventureModeLevel.Items.AddRange(Level.Names);
            }
            comboBoxAdventureModeLevel.SelectedIndex = saveIndex;
        }

        public void IncompatibleVersion()
        {
            if (!acceptedIncompatibleVersion)
            {
                if (MessageBox.Show(this, IncompatibleVersionMessage, IncompatibleVersionCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    Application.Exit();
                }
                acceptedIncompatibleVersion = true;
            }
        }

        bool changed = false;

        private void numericUpDownNumTimesCompletedAdventureMode_ValueChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
            UpdateComboBoxAdventureModeLevelItems();
            switch ((int)numericUpDownNumTimesCompletedAdventureMode.Value)
            {
                case 0:
                    labelCompletedAdventureModeEffects.Text = "Level determines plants/items and whether Almanac, Garden, Shop unlocked";
                    break;
                case 1:
                    labelCompletedAdventureModeEffects.Text = "Silver Sunflower trophy, all modes unlocked, all items in shop";
                    break;
                default:
                    labelCompletedAdventureModeEffects.Text = "Yeti Zombie in Almanac";
                    break;
            }
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            user = ReadUserFile(user.Name, user.UserFilePath);
            PopulateControls();
            MarkChanged(false);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == "PlantsVsZombies")
                {
                    if (MessageBox.Show(this, GameIsRunningMessage, GameIsRunningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        return;
                    }
                    break;
                }
            }
            Save();
            MarkChanged(false);
        }

        private void MarkChanged(bool value)
        {
            changed = value;
            buttonSave.Enabled = changed;

            if ((int)numericUpDownMoney.Value % 10 != 0)
            {
                numericUpDownMoney.Value = (int)numericUpDownMoney.Value / 10 * 10;
            }

            numericUpDownTreeFood.ReadOnly = !checkBoxPurchasedFood.Checked;
            dateTimePickerMarigold1.Enabled = !checkBoxMarigold1Never.Checked;
            dateTimePickerMarigold2.Enabled = !checkBoxMarigold2Never.Checked;
            dateTimePickerMarigold3.Enabled = !checkBoxMarigold3Never.Checked;

            numericUpDownFertilizer.Enabled = !checkBoxFertilizerNeverPurchased.Checked;
            numericUpDownBugSpray.Enabled = !checkBoxBugSprayNeverPurchased.Checked;
            numericUpDownLastAwoken.Enabled = checkBoxStinkyPurchased.Checked;
            numericUpDownLastChocolate.Enabled = !checkBoxNeverChocolate.Checked;

            UpdatePlantDetails();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                if (MessageBox.Show(this, UnsavedChangesMessage, UnsavedChangesCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void somethingChanged(object sender, EventArgs e)
        {
            MarkChanged(true);
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            var list = new List<ZenGardenPlant>(user.ZenGardenPlants);
            list.Add(new ZenGardenPlant());
            user.ZenGardenPlants = list.ToArray();
            MarkChanged(true);
            PopulatePlantList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var list = new List<ZenGardenPlant>(user.ZenGardenPlants);
            var indices = new List<int>();

            // Remove in reverse sorted order to avoid indexes changing
            foreach (int index in listBoxPlants.SelectedIndices)
            {
                indices.Add(index);
            }
            indices.Sort();
            indices.Reverse();
            foreach (int index in indices)
            {
                list.RemoveAt(index);
            }
            user.ZenGardenPlants = list.ToArray();
            MarkChanged(true);
            PopulatePlantList();
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            var list = new List<ZenGardenPlant>(user.ZenGardenPlants);
            var indices = new List<int>();
            foreach (int index in listBoxPlants.SelectedIndices)
            {
                ZenGardenPlant plant = new ZenGardenPlant(list[index]);
                list.Add(plant);
            }
            user.ZenGardenPlants = list.ToArray();
            MarkChanged(true);
            PopulatePlantList();
        }

        private void buttonLoadPlant_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                using (var reader = new BinaryReader(new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read)))
                {
                    var version = reader.ReadUInt32();
                    if (version != 0x0C)
                    {
                        IncompatibleVersion();
                    }
                    ZenGardenPlant plant = new ZenGardenPlant();
                    plant.Load(reader);

                    var list = new List<ZenGardenPlant>(user.ZenGardenPlants);
                    list.Add(plant);
                    user.ZenGardenPlants = list.ToArray();
                    MarkChanged(true);
                    PopulatePlantList();
                }
            }           
        }

        private void buttonSavePlant_Click(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 0)
            {
                MessageBox.Show(this, "Before using Save, select a plant to save to a file.", "No plant selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listBoxPlants.SelectedIndices.Count > 1)
            {
                MessageBox.Show(this, "Only one plant can be saved to a file.", "Multiple plants selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                using (var writer = new BinaryWriter(new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write)))
                {
                    // Write version in case we need to support other versions in the future
                    writer.Write(0x0C);
                    user.ZenGardenPlants[listBoxPlants.SelectedIndex].Save(writer);
                    MessageBox.Show(this, "Plant saved to file \"" + dialog.FileName + "\".", "Plant saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void listBoxPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlantDetails();
        }

        private void UpdatePlantDetails()
        {
            comboBoxPlantType.Enabled = comboBoxColor.Enabled = comboBoxGarden.Enabled = comboBoxHappiness.Enabled =
                numericUpDownRow.Enabled = numericUpDownColumn.Enabled =
                numericUpDownWateredTimes.Enabled = numericUpDownFertilizedTimes.Enabled =
                dateTimePickerLastWatered.Enabled = dateTimePickerLastFertilized.Enabled = dateTimePickerLastHappiness.Enabled =
                checkBoxNeverWatered.Enabled = checkBoxNeverFertilized.Enabled = checkBoxNeverHappiness.Enabled = 
                (listBoxPlants.SelectedIndices.Count == 1);
            if (listBoxPlants.SelectedIndices.Count == 1 && listBoxPlants.SelectedIndex < user.ZenGardenPlants.Length)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                comboBoxPlantType.SelectedIndex = plant.PlantType;
                if (plant.PlantType == ZenGardenPlant.Marigold)
                {
                    comboBoxColor.Enabled = true;
                    comboBoxColor.SelectedIndex = plant.Color - 1;
                }
                else
                {
                    comboBoxColor.Enabled = false;
                    comboBoxColor.SelectedIndex = -1;
                }
                comboBoxGarden.SelectedIndex = plant.GardenLocation;
                if (plant.GardenLocation != 0)
                {
                    numericUpDownRow.Enabled = false;
                }
                else
                {
                    numericUpDownRow.Enabled = true;
                    numericUpDownRow.Value = plant.Row + 1;
                }
                numericUpDownColumn.Value = plant.Column + 1;

                numericUpDownWateredTimes.Value = plant.NumTimesWatered;
                if (plant.LastWateringTime == DateTime.MinValue)
                {
                    checkBoxNeverWatered.Checked = true;
                    dateTimePickerLastWatered.Enabled = false;
                }
                else
                {
                    dateTimePickerLastWatered.Enabled = true;
                    dateTimePickerLastWatered.Value = plant.LastWateringTime;
                }
                numericUpDownFertilizedTimes.Value = plant.NumTimesFertilized;
                if (plant.LastFertilizerTime == DateTime.MinValue)
                {
                    checkBoxNeverFertilized.Checked = true;
                    dateTimePickerLastFertilized.Enabled = false;
                }
                else
                {
                    dateTimePickerLastFertilized.Enabled = true;
                    dateTimePickerLastFertilized.Value = plant.LastFertilizerTime;
                }
                switch (plant.NeedsPhonographOrBugSpray)
                {
                    case ZenGardenPlantNeeds.Nothing: comboBoxHappiness.SelectedIndex = 0; break;
                    case ZenGardenPlantNeeds.BugSpray: comboBoxHappiness.SelectedIndex = 1; break;
                    case ZenGardenPlantNeeds.Phonograph: comboBoxHappiness.SelectedIndex = 2; break;
                }
                if (plant.LastPhonographOrBugSprayTime == DateTime.MinValue)
                {
                    checkBoxNeverHappiness.Checked = true;
                    dateTimePickerLastHappiness.Enabled = false;
                }
                else
                {
                    checkBoxNeverHappiness.Checked = false;
                    dateTimePickerLastHappiness.Enabled = true;
                    dateTimePickerLastHappiness.Value = plant.LastPhonographOrBugSprayTime;
                }
            }
        }

        private void comboBoxPlantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.PlantType = comboBoxPlantType.SelectedIndex;
                MarkChanged(true);
                PopulatePlantList();
            }
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                if (plant.PlantType == ZenGardenPlant.Marigold)
                {
                    plant.Color = comboBoxColor.SelectedIndex + 1;
                }
                MarkChanged(true);
                PopulatePlantList();
            }
        }

        private void comboBoxGarden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.GardenLocation = comboBoxGarden.SelectedIndex;
                if (plant.GardenLocation != 0)
                {
                    plant.Row = 0;
                }
                MarkChanged(true);
                UpdatePlantDetails();
                PopulatePlantList();
            }
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.Row = (int)numericUpDownRow.Value - 1;
                MarkChanged(true);
                PopulatePlantList();
            }
        }

        private void numericUpDownColumn_ValueChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.Column = (int)numericUpDownColumn.Value - 1;
                MarkChanged(true);
                PopulatePlantList();
            }
        }

        private void checkBoxNeverWatered_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWatered();
        }

        private void dateTimePickerLastWatered_ValueChanged(object sender, EventArgs e)
        {
            UpdateWatered();
        }

        private void UpdateWatered()
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.LastWateringTime = checkBoxNeverWatered.Checked ? DateTime.MinValue : dateTimePickerLastWatered.Value;
                MarkChanged(true);
                UpdatePlantDetails();
            }
        }

        private void checkBoxNeverFertilized_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFertilized();
        }

        private void dateTimePickerLastFertilized_ValueChanged(object sender, EventArgs e)
        {
            UpdateFertilized();
        }

        private void UpdateFertilized()
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.LastFertilizerTime = checkBoxNeverFertilized.Checked ? DateTime.MinValue : dateTimePickerLastFertilized.Value;
                MarkChanged(true);
                UpdatePlantDetails();
            }
        }

        private void numericUpDownFertilizedTimes_ValueChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.NumTimesFertilized = (int)numericUpDownFertilizedTimes.Value;
                MarkChanged(true);
            }
        }

        private void numericUpDownWateredTimes_ValueChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.NumTimesWatered = (int)numericUpDownWateredTimes.Value;
                MarkChanged(true);
            }
        }

        private void comboBoxHappiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                switch (comboBoxHappiness.SelectedIndex)
                {
                    case 0: plant.NeedsPhonographOrBugSpray = ZenGardenPlantNeeds.Nothing; break;
                    case 1: plant.NeedsPhonographOrBugSpray = ZenGardenPlantNeeds.BugSpray; break;
                    case 2: plant.NeedsPhonographOrBugSpray = ZenGardenPlantNeeds.Phonograph; break;
                }
                MarkChanged(true);
            }
        }

        private void dateTimePickerLastHappiness_ValueChanged(object sender, EventArgs e)
        {
            UpdateHappiness();
        }

        private void checkBoxNeverHappiness_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHappiness();
        }

        private void UpdateHappiness()
        {
            if (listBoxPlants.SelectedIndices.Count == 1)
            {
                ZenGardenPlant plant = user.ZenGardenPlants[listBoxPlants.SelectedIndex];
                plant.LastPhonographOrBugSprayTime = checkBoxNeverHappiness.Checked ? DateTime.MinValue : dateTimePickerLastHappiness.Value;
                MarkChanged(true);
                UpdatePlantDetails();
            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog(this);
        }
    }
}
