using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABM___Project
{
    public partial class DriversForm : Form
    {
        public DriversForm()
        {
            InitializeComponent();
            ShowDrivers();
        }
        void ShowDrivers()
        {
            listView1.Items.Clear();
            foreach (Drivers factory in Program.wftDb.Drivers)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Driver.ToString(),
                    factory.Surname,
                    factory.Name,
                    factory.Patronymic
                });
                item.Tag = factory;
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Drivers factory = listView1.SelectedItems[0].Tag as Drivers;
                textBoxSurname.Text = factory.Surname;
                textBoxName.Text = factory.Name;
                textBoxPatronymic.Text = factory.Patronymic;
            }
            else
            {
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Drivers factorySet = new Drivers();
            factorySet.Surname = textBoxSurname.Text;
            factorySet.Name = textBoxName.Text;
            factorySet.Patronymic = textBoxPatronymic.Text;
            Program.wftDb.Drivers.Add(factorySet);
            Program.wftDb.SaveChanges();
            ShowDrivers();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Drivers factory = listView1.SelectedItems[0].Tag as Drivers;
                factory.Surname = textBoxSurname.Text;
                factory.Name = textBoxName.Text;
                factory.Patronymic = textBoxPatronymic.Text;
                Program.wftDb.SaveChanges();
                ShowDrivers();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    Drivers factory = listView1.SelectedItems[0].Tag as Drivers;
                    Program.wftDb.Drivers.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowDrivers();
                }
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
