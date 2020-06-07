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
    public partial class DeliveryForm : Form
    {
        public DeliveryForm()
        {
            InitializeComponent();
            ShowCustomers();
            ShowOrdes();
            ShowDriver();
            ShowDelivery();

        }
        void ShowCustomers()
        {
            comboBoxCustomer.Items.Clear();
            foreach (Customers factory in Program.wftDb.Customers)
            {
                string[] item = { factory.Id_Customer.ToString() + ".", factory.Surname };
                comboBoxCustomer.Items.Add(string.Join("", item));
            }
        }
        void ShowOrdes()
        {
            comboBoxOrdes.Items.Clear();
            foreach (Orders factory in Program.wftDb.Orders)
            {
                string[] item = { factory.Id_Orders.ToString() + ".", factory.Baguette_Products.Name };
                comboBoxOrdes.Items.Add(string.Join("", item));
            }
        }
        void ShowDriver()
        {
            comboBoxDriver.Items.Clear();
            foreach (Drivers factory in Program.wftDb.Drivers)
            {
                string[] item = { factory.Id_Driver.ToString() + ".", factory.Surname };
                comboBoxDriver.Items.Add(string.Join("", item));
            }
        }
        void ShowDelivery()
        {
            listViewDelivery.Items.Clear();
            foreach (Delivery factory in Program.wftDb.Delivery)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Delivery.ToString(),
                    factory.Id_Customer.ToString()+" "+ factory.Customers.Surname+" "+factory.Customers.Name,
                    factory.Id_Ordes.ToString()+" "+factory.Orders.Quantity.ToString()+" "+factory.Orders.Id_item,
                    factory.Id_Driver.ToString()+" "+factory.Drivers.Surname+" "+factory.Drivers.Name,
                    factory.Date_of_export.ToString(),
                    factory.Delivery_date.ToString(),
                    factory.Cost.ToString()
                });
                item.Tag = factory;
                listViewDelivery.Items.Add(item);
            }
            listViewDelivery.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((listViewDelivery.SelectedItems.Count == 1))
            {
                Delivery realEstate = listViewDelivery.SelectedItems[0].Tag as Delivery;
                comboBoxCustomer.SelectedIndex = comboBoxCustomer.FindString(realEstate.Id_Customer.ToString());
                comboBoxOrdes.SelectedIndex = comboBoxOrdes.FindString(realEstate.Id_Ordes.ToString());
                comboBoxDriver.SelectedIndex = comboBoxDriver.FindString(realEstate.Id_Driver.ToString());
                textBoxDate_of_export.Text = realEstate.Date_of_export.ToString();
                textBoxDelivery_date.Text = realEstate.Delivery_date.ToString();
                textBoxCost.Text = realEstate.Cost.ToString();

            }
            else
            {
                comboBoxCustomer.SelectedItem = null;
                comboBoxOrdes.SelectedItem = null;
                comboBoxDriver.SelectedItem = null;
                textBoxDate_of_export.Text = "";
                textBoxDelivery_date.Text = "";
                textBoxCost.Text = "";

            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Delivery factorySet = new Delivery();
            factorySet.Id_Customer = Convert.ToInt32(comboBoxCustomer.SelectedItem.ToString().Split('.')[0]);
            factorySet.Id_Ordes = Convert.ToInt32(comboBoxOrdes.SelectedItem.ToString().Split('.')[0]);
            factorySet.Id_Driver = Convert.ToInt32(comboBoxDriver.SelectedItem.ToString().Split('.')[0]);
            factorySet.Date_of_export = Convert.ToDateTime(textBoxDate_of_export.Text);
            factorySet.Delivery_date = Convert.ToDateTime(textBoxDelivery_date.Text);
            factorySet.Cost = Convert.ToInt32(textBoxCost.Text);
            Program.wftDb.Delivery.Add(factorySet);
            
            Program.wftDb.SaveChanges();
            factorySet.Orders.Id_Delivery = factorySet.Id_Delivery;
            Program.wftDb.SaveChanges();
            ShowDelivery();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewDelivery.SelectedItems.Count == 1)
            {
                Delivery factory = listViewDelivery.SelectedItems[0].Tag as Delivery;
                factory.Id_Customer = Convert.ToInt32(comboBoxCustomer.SelectedItem.ToString().Split('.')[0]);
                factory.Id_Ordes = Convert.ToInt32(comboBoxOrdes.SelectedItem.ToString().Split('.')[0]);
                factory.Id_Driver = Convert.ToInt32(comboBoxDriver.SelectedItem.ToString().Split('.')[0]);
                factory.Date_of_export = Convert.ToDateTime(textBoxDate_of_export.Text);
                factory.Delivery_date = Convert.ToDateTime(textBoxDelivery_date.Text);
                factory.Cost = Convert.ToInt32(textBoxCost.Text);
                Program.wftDb.SaveChanges();
                ShowDelivery();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewDelivery.SelectedItems.Count == 1)
                {
                    Delivery factory = listViewDelivery.SelectedItems[0].Tag as Delivery;
                    Program.wftDb.Delivery.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowDelivery();
                }
                comboBoxCustomer.SelectedItem = null;
                comboBoxOrdes.SelectedItem = null;
                comboBoxDriver.SelectedItem = null;
                textBoxDate_of_export.Text = "";
                textBoxDelivery_date.Text = "";
                textBoxCost.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
