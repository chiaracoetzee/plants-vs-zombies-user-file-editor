using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Plants_vs.Zombies_user_file_editor
{
    public partial class FormSelectUser : Form
    {
        public FormSelectUser(ICollection<string> list)
        {
            InitializeComponent();
            string[] array = new string[list.Count];
            list.CopyTo(array, 0);
            listBoxUsers.DataSource = array;
        }

        public string SelectedUser
        {
            get
            {
                return (string)listBoxUsers.SelectedItem;
            }
        }
    }
}
