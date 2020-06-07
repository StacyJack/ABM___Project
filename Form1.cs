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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            
        }

        private void buttonFactory_Click(object sender, EventArgs e)
        {
            Form factory = new FactoryForm();
            factory.Show();
        }

        private void buttonStore1_Click(object sender, EventArgs e)
        {
            Form store1 = new Store1Form();
            store1.Show();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            Form orders = new OrdersForm();
            orders.Show();

        }

        private void buttonBaguette_Products_Click(object sender, EventArgs e)
        {
            Form baguette_Products = new Baguette_ProductsForm();
            baguette_Products.Show();
        }

        private void buttonDrivers_Click(object sender, EventArgs e)
        {
            Form drivers = new DriversForm();
            drivers.Show();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            Form customers = new CustomersForm();
            customers.Show();
        }

        private void buttonDelivery_Click(object sender, EventArgs e)
        {
            Form delivery = new DeliveryForm();
            delivery.Show();
        }
    }
}
