using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Plants_vs.Zombies_user_file_editor
{
    public partial class FormSelectUser : Form
    {
        string SettingsFilePath;
        const string UsersFileNotFoundCaption = "Plants vs. Zombies users file not found";
        const string UsersFileNotFoundMessage = "{0} Make sure Plants vs. Zombies is installed.";

        string pvzDataPath;
        Dictionary<string, uint> users = new Dictionary<string, uint>();
        
        public FormSelectUser()
        {
            InitializeComponent();

            SettingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Plants vs. Zombies user file editor.dat";
            pvzDataPath = "";
            try
            {
                using (var reader = new StreamReader(File.OpenRead(SettingsFilePath)))
                {
                    pvzDataPath = reader.ReadLine();
                }
            }
            catch (FileNotFoundException) { }
            if (pvzDataPath == "" || !Directory.Exists(pvzDataPath))
            {
                pvzDataPath = GetPvzDataPath();
            }

            if (pvzDataPath == null)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            users = ReadUsersFile(pvzDataPath);
            UpdateList();
        }

        private void UpdateList()
        {
            if (users == null || users.Count == 0)
            {
                if (users == null)
                {
                    MessageBox.Show(this, "No user data found in the selected location: " + lastReadUsersFileException.Message + " Please select a different location.", "User data not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, "No users found in the selected location. No users have yet been created in the game. Select a different location or exit and create a user in the game.", "No users found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                listBoxUsers.DataSource = null;
                listBoxUsers.Enabled = false;
                return;
            }

            using (var writer = new StreamWriter(File.OpenWrite(SettingsFilePath)))
            {
                writer.WriteLine(pvzDataPath);
            }

            string[] array = new string[users.Keys.Count];
            users.Keys.CopyTo(array, 0);
            listBoxUsers.DataSource = array;
            listBoxUsers.Enabled = true;

            textBoxUserDataFolder.Text = pvzDataPath;
        }

        private string GetPvzDataPath()
        {
            string result = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\PopCap Games\PlantsVsZombies\userdata";
            if (!Directory.Exists(result))
            {
                var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                result = programFiles + @"\PopCap Games\Plants vs. Zombies\userdata";
                if (!Directory.Exists(result))
                {
                    result = BrowseUserDataFolder("The userdata directory for Plants vs. Zombies could not be found. Please locate it.");
                    if (result == null)
                    {
                        Application.Exit();
                        return null;
                    }
                }
            }
            return result;
        }

        private Exception lastReadUsersFileException;

        private Dictionary<string, uint> ReadUsersFile(string pvzDataPath)
        {
            var result = new Dictionary<string, uint>();
            var usersFilePath = pvzDataPath + @"\" + "users.dat";
            try
            {
                using (var reader = new BinaryReader(new FileStream(usersFilePath, FileMode.Open, FileAccess.Read)))
                {
                    var version = reader.ReadUInt32();
                    if (version != 0x0E)
                    {
                        ((MainForm)Parent).IncompatibleVersion();
                    }
                    var numUsers = reader.ReadUInt16();
                    for (int i = 0; i < numUsers; i++)
                    {
                        var length = reader.ReadUInt16();
                        var name = Encoding.ASCII.GetString(reader.ReadBytes(length));
                        var timestamp = reader.ReadUInt32();
                        var fileNumber = reader.ReadUInt32();
                        result.Add(name, fileNumber);
                    }
                }
            }
            catch (Exception e)
            {
                lastReadUsersFileException = e;
                return null;
            }

            return result;
        }

        public string SelectedUser
        {
            get
            {
                return (string)listBoxUsers.SelectedItem;
            }
        }

        private void buttonBrowseUserDataFolder_Click(object sender, EventArgs e)
        {
            string folder = BrowseUserDataFolder("Select the location of the userdata folder for Plants vs. Zombies.");
            if (folder != null)
            {
                textBoxUserDataFolder.Text = folder;
                CheckModifiedText();
            }
        }

        private string BrowseUserDataFolder(string description)
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = pvzDataPath;
            dialog.Description = description;
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return null;
            }
            return dialog.SelectedPath;
        }

        private void textBoxUserDataFolder_Leave(object sender, EventArgs e)
        {
            CheckModifiedText();
        }

        private void CheckModifiedText()
        {
            if (pvzDataPath != textBoxUserDataFolder.Text)
            {
                pvzDataPath = textBoxUserDataFolder.Text;
                users = ReadUsersFile(pvzDataPath);
                UpdateList();
            }
        }

        public string UserFilePath
        {
            get
            {
                return pvzDataPath + @"\" + "user" + users[SelectedUser] + ".dat";
            }
        }

        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxUsers.SelectedIndices.Count == 1)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
