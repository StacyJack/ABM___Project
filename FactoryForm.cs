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
    public partial class FactoryForm : Form
    {
        public FactoryForm()
        {
            InitializeComponent();
            ShowFactory();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
        }

       
        void ShowFactory()
        {
            listViewFactory.Items.Clear();
            foreach (Factory factory in Program.wftDb.Factory)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Factory.ToString(), factory.name, factory.City,
                });
                item.Tag = factory;
                listViewFactory.Items.Add(item);
            }
            listViewFactory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }



 
        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            Factory factorySet = new Factory();
            factorySet.name = textBoxname.Text;
            factorySet.City = textBoxCity.Text;
            Program.wftDb.Factory.Add(factorySet);
            Program.wftDb.SaveChanges();
            ShowFactory();
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            if (listViewFactory.SelectedItems.Count == 1)
            {
                Factory factory = listViewFactory.SelectedItems[0].Tag as Factory;
                factory.name = textBoxname.Text;
                factory.City = textBoxCity.Text;
                Program.wftDb.SaveChanges();
                ShowFactory();
            }
        }

        private void buttonDel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listViewFactory.SelectedItems.Count == 1)
                {
                    Factory factory = listViewFactory.SelectedItems[0].Tag as Factory;
                    Program.wftDb.Factory.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowFactory();
                }
                textBoxname.Text = "";
                textBoxCity.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listViewFactory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listViewFactory.SelectedItems.Count == 1)
            {
                Factory factory = listViewFactory.SelectedItems[0].Tag as Factory;
                textBoxname.Text = factory.name;
                textBoxCity.Text = factory.City;
            }
            else
            {
                textBoxname.Text = "";
                textBoxCity.Text = "";
            }
        }
    }
}

