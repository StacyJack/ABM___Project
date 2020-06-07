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
    public partial class Store1Form : Form
    {
        public Store1Form()
        {
            InitializeComponent();
            ShowFactory();
            ShowStore();
        }
        void ShowFactory()
        {
            comboBoxFactory.Items.Clear();
            foreach (Factory factory in Program.wftDb.Factory)
            {
                string[] item = { factory.Id_Factory.ToString() + ".", factory.City };
                comboBoxFactory.Items.Add(string.Join("", item));
            }
        }
        void ShowStore()
        {
            listViewStore1.Items.Clear();
            foreach (Store1 factory in Program.wftDb.Store1)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Factory.Id_Factory.ToString()+ " "+ factory.Factory.City,
                    factory.Id_Store.ToString(),
                    factory.Address
                });
                item.Tag = factory;
                listViewStore1.Items.Add(item);
            }
            listViewStore1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Store1 storeSet = new Store1();
            storeSet.Id_Factory = Convert.ToInt32(comboBoxFactory.SelectedItem.ToString().Split('.')[0]);
            storeSet.Address = textBoxAddress.Text;
            Program.wftDb.Store1.Add(storeSet);
            Program.wftDb.SaveChanges();
            ShowStore();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewStore1.SelectedItems.Count == 1)
            {
                Store1 factory = listViewStore1.SelectedItems[0].Tag as Store1;
                factory.Id_Factory = Convert.ToInt32(comboBoxFactory.SelectedItem.ToString().Split('.')[0]);
                factory.Address = textBoxAddress.Text;
                Program.wftDb.SaveChanges();
                ShowFactory();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewStore1.SelectedItems.Count == 1)
                {
                    Store1 factory = listViewStore1.SelectedItems[0].Tag as Store1;
                    Program.wftDb.Store1.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowFactory();
                }
                comboBoxFactory.Text = "";
                textBoxAddress.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listViewStore1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listViewStore1.SelectedItems.Count == 1))
            {
                Store1 realEstate = listViewStore1.SelectedItems[0].Tag as Store1;
                comboBoxFactory.SelectedIndex = comboBoxFactory.FindString(realEstate.Id_Factory.ToString());
                
                textBoxAddress.Text = realEstate.Address.ToString();


            }
            else
            {
                comboBoxFactory.SelectedItem = null;

                textBoxAddress.Text = "";


            }
        }
    }
}
