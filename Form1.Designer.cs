namespace ABM___Project
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFactory = new System.Windows.Forms.Button();
            this.buttonStore1 = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonBaguette_Products = new System.Windows.Forms.Button();
            this.buttonDelivery = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonDrivers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFactory
            // 
            this.buttonFactory.Location = new System.Drawing.Point(201, 176);
            this.buttonFactory.Name = "buttonFactory";
            this.buttonFactory.Size = new System.Drawing.Size(135, 31);
            this.buttonFactory.TabIndex = 0;
            this.buttonFactory.Text = "Фабрики";
            this.buttonFactory.UseVisualStyleBackColor = true;
            this.buttonFactory.Click += new System.EventHandler(this.buttonFactory_Click);
            // 
            // buttonStore1
            // 
            this.buttonStore1.Location = new System.Drawing.Point(201, 213);
            this.buttonStore1.Name = "buttonStore1";
            this.buttonStore1.Size = new System.Drawing.Size(135, 31);
            this.buttonStore1.TabIndex = 1;
            this.buttonStore1.Text = "Магазины";
            this.buttonStore1.UseVisualStyleBackColor = true;
            this.buttonStore1.Click += new System.EventHandler(this.buttonStore1_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(201, 250);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(135, 31);
            this.buttonOrders.TabIndex = 2;
            this.buttonOrders.Text = "Заказы";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonBaguette_Products
            // 
            this.buttonBaguette_Products.Location = new System.Drawing.Point(201, 287);
            this.buttonBaguette_Products.Name = "buttonBaguette_Products";
            this.buttonBaguette_Products.Size = new System.Drawing.Size(135, 31);
            this.buttonBaguette_Products.TabIndex = 3;
            this.buttonBaguette_Products.Text = "Багетные изделия";
            this.buttonBaguette_Products.UseVisualStyleBackColor = true;
            this.buttonBaguette_Products.Click += new System.EventHandler(this.buttonBaguette_Products_Click);
            // 
            // buttonDelivery
            // 
            this.buttonDelivery.Location = new System.Drawing.Point(201, 324);
            this.buttonDelivery.Name = "buttonDelivery";
            this.buttonDelivery.Size = new System.Drawing.Size(135, 31);
            this.buttonDelivery.TabIndex = 4;
            this.buttonDelivery.Text = "Доставка";
            this.buttonDelivery.UseVisualStyleBackColor = true;
            this.buttonDelivery.Click += new System.EventHandler(this.buttonDelivery_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Location = new System.Drawing.Point(201, 361);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(135, 31);
            this.buttonCustomers.TabIndex = 5;
            this.buttonCustomers.Text = "Заказчики";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonDrivers
            // 
            this.buttonDrivers.Location = new System.Drawing.Point(201, 398);
            this.buttonDrivers.Name = "buttonDrivers";
            this.buttonDrivers.Size = new System.Drawing.Size(135, 31);
            this.buttonDrivers.TabIndex = 6;
            this.buttonDrivers.Text = "Водители";
            this.buttonDrivers.UseVisualStyleBackColor = true;
            this.buttonDrivers.Click += new System.EventHandler(this.buttonDrivers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ABM___Project.Properties.Resources.Vramky_Logo_200;
            this.pictureBox1.Location = new System.Drawing.Point(131, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 513);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonDrivers);
            this.Controls.Add(this.buttonCustomers);
            this.Controls.Add(this.buttonDelivery);
            this.Controls.Add(this.buttonBaguette_Products);
            this.Controls.Add(this.buttonOrders);
            this.Controls.Add(this.buttonStore1);
            this.Controls.Add(this.buttonFactory);
            this.Name = "Menu";
            this.Text = "Меню";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFactory;
        private System.Windows.Forms.Button buttonStore1;
        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonBaguette_Products;
        private System.Windows.Forms.Button buttonDelivery;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonDrivers;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

