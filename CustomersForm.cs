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
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
            ShowCustomers();


        }
        void ShowCustomers()
        {
            listViewCustomers.Items.Clear();
            foreach (Customers factory in Program.wftDb.Customers)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    factory.Id_Customer.ToString(), factory.Surname, factory.Name,factory.Patronymic,factory.Store_Address
                });
                item.Tag = factory;
                listViewCustomers.Items.Add(item);
            }
            listViewCustomers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void listViewCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count == 1)
            {
                Customers factory = listViewCustomers.SelectedItems[0].Tag as Customers;
                textBoxSurname.Text = factory.Surname;
                textBoxName.Text = factory.Name;
                textBoxPatronymic.Text = factory.Patronymic;
                textBoxAddress.Text = factory.Store_Address;
            }
            else
            {
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
                textBoxAddress.Text = "";
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Customers factorySet = new Customers();
            factorySet.Surname = textBoxSurname.Text;
            factorySet.Name = textBoxName.Text;
            factorySet.Patronymic = textBoxPatronymic.Text;
            factorySet.Store_Address = textBoxAddress.Text;
            Program.wftDb.Customers.Add(factorySet);
            Program.wftDb.SaveChanges();
            ShowCustomers();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewCustomers.SelectedItems.Count == 1)
            {
                Customers factory = listViewCustomers.SelectedItems[0].Tag as Customers;
                factory.Surname = textBoxSurname.Text;
                factory.Name = textBoxName.Text;
                factory.Patronymic = textBoxPatronymic.Text;
                factory.Store_Address = textBoxAddress.Text;
                Program.wftDb.SaveChanges();
                ShowCustomers();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewCustomers.SelectedItems.Count == 1)
                {
                    Customers factory = listViewCustomers.SelectedItems[0].Tag as Customers;
                    Program.wftDb.Customers.Remove(factory);
                    Program.wftDb.SaveChanges();
                    ShowCustomers();
                }
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
                textBoxAddress.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить, эта запись используется!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
