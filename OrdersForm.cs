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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            ShowDelivery();
            ShowItem();
            ShowStore();
            ShowOrders();
        }
        void ShowDelivery()
        {
            comboBoxDelivery.Items.Clear();
            foreach (Delivery factory in Program.wftDb.Delivery)
            {
                string[] item = { factory.Id_Delivery.ToString() + ".", factory.Drivers.Surname


                };
                comboBoxDelivery.Items.Add(string.Join("", item));
            }
        }
        void ShowItem()
        {
            comboBoxItem.Items.Clear();
            foreach (Baguette_Products factory in Program.wftDb.Baguette_Products)
            {
                string[] item = { factory.Id_Baguette_Products.ToString() + ".", factory.Name


                };
                comboBoxItem.Items.Add(string.Join("", item));
            }
        }
        void ShowStore()
        {
            comboBoxStore.Items.Clear();
            foreach (Store1 factory in Program.wftDb.Store1)
            {
                string[] item = { factory.Id_Store.ToString() + ".", factory.Address


                };
                comboBoxStore.Items.Add(string.Join("", item));
            }
        }
        void ShowOrders()
        {
            listViewOrders.Items.Clear();
            foreach (Orders factory in Program.wftDb.Orders)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Delivery.ToString(),factory.Id_Store.ToString(),factory.Id_item.ToString(),factory.Quantity.ToString()
                    
                });
                item.Tag = factory;
                listViewOrders.Items.Add(item);
            }
            listViewOrders.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Orders ordesSet = new Orders();
            if (comboBoxDelivery.SelectedItem != null)
            { ordesSet.Id_Delivery = Convert.ToInt32(comboBoxDelivery.SelectedItem.ToString().Split('.')[0]); }
            ordesSet.Id_item = Convert.ToInt32(comboBoxItem.SelectedItem.ToString().Split('.')[0]);
            ordesSet.Id_Store = Convert.ToInt32(comboBoxStore.SelectedItem.ToString().Split('.')[0]);
            ordesSet.Quantity = Convert.ToInt32(textBoxQuantity.Text);
            
            Program.wftDb.Orders.Add(ordesSet);
            Program.wftDb.SaveChanges();
            ShowOrders();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewOrders.SelectedItems.Count == 1)
            {
                Orders factory = listViewOrders.SelectedItems[0].Tag as Orders;
                factory.Id_Delivery = Convert.ToInt32(comboBoxDelivery.SelectedItem.ToString().Split('.')[0]);
                factory.Id_item = Convert.ToInt32(comboBoxItem.SelectedItem.ToString().Split('.')[0]);
                factory.Id_Store = Convert.ToInt32(comboBoxStore.SelectedItem.ToString().Split('.')[0]);
                factory.Quantity = Convert.ToInt32(textBoxQuantity.Text);
                Program.wftDb.SaveChanges();
                ShowOrders();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewOrders.SelectedItems.Count == 1)
                {
                    Orders factory = listViewOrders.SelectedItems[0].Tag as Orders;
                    Program.wftDb.Orders.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowOrders();
                }
                comboBoxDelivery.SelectedItem = null;
                comboBoxItem.SelectedItem = null;
                comboBoxStore.SelectedItem = null;
                textBoxQuantity.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void listViewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listViewOrders.SelectedItems.Count == 1))
            {
                Orders realEstate = listViewOrders.SelectedItems[0].Tag as Orders;
                comboBoxDelivery.SelectedIndex = comboBoxDelivery.FindString(realEstate.Id_Delivery.ToString());
                comboBoxItem.SelectedIndex = comboBoxItem.FindString(realEstate.Id_item.ToString());
                comboBoxStore.SelectedIndex = comboBoxStore.FindString(realEstate.Id_Store.ToString());
                textBoxQuantity.Text = realEstate.Quantity.ToString();


            }
            else
            {
                comboBoxDelivery.SelectedItem = null;
                comboBoxItem.SelectedItem = null;
                comboBoxStore.SelectedItem = null;
                textBoxQuantity.Text = "";


            }
        }
    }
}
