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
    public partial class Baguette_ProductsForm : Form
    {
        public Baguette_ProductsForm()
        {
            InitializeComponent();
            ShowBaguette_Products();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Baguette_Products factorySet = new Baguette_Products();
            factorySet.Name = textBoxName.Text;
            factorySet.Profit = Convert.ToDouble(textBoxProfit.Text);
            Program.wftDb.Baguette_Products.Add(factorySet);
            Program.wftDb.SaveChanges();
            ShowBaguette_Products();
        }
        void ShowBaguette_Products()
        {
            listViewBaguette_Products.Items.Clear();
            foreach (Baguette_Products factory in Program.wftDb.Baguette_Products)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Baguette_Products.ToString(), factory.Name, factory.Profit.ToString()
                });
                item.Tag = factory;
                listViewBaguette_Products.Items.Add(item);
            }
            listViewBaguette_Products.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewBaguette_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBaguette_Products.SelectedItems.Count == 1)
            {
                Baguette_Products factory = listViewBaguette_Products.SelectedItems[0].Tag as Baguette_Products;
                textBoxName.Text = factory.Name;
                textBoxProfit.Text = Convert.ToString(factory.Profit);
            }
            else
            {
                textBoxName.Text = "";
                textBoxProfit.Text = "";
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewBaguette_Products.SelectedItems.Count == 1)
            {
                Baguette_Products factory = listViewBaguette_Products.SelectedItems[0].Tag as Baguette_Products;
                factory.Name = textBoxName.Text;
                factory.Profit = Convert.ToDouble(factory.Profit);
                Program.wftDb.SaveChanges();
                ShowBaguette_Products();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewBaguette_Products.SelectedItems.Count == 1)
                {
                    Baguette_Products factory = listViewBaguette_Products.SelectedItems[0].Tag as Baguette_Products;
                    Program.wftDb.Baguette_Products.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowBaguette_Products();
                }
                textBoxName.Text = "";
                textBoxProfit.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
