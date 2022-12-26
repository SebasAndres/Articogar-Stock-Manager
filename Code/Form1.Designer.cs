namespace CreadorQR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cargarAlStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_prod = new System.Windows.Forms.ComboBox();
            this.tb_color = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbox_detalle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_producto = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_precio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_nuevaempresa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_nuevocod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_nuevoprod = new System.Windows.Forms.TextBox();
            this.tb_nuevasmedidas = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.nprod = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_cantidad = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.Tomato;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarAlStockToolStripMenuItem,
            this.verStockToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1052, 30);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // cargarAlStockToolStripMenuItem
            // 
            this.cargarAlStockToolStripMenuItem.Name = "cargarAlStockToolStripMenuItem";
            this.cargarAlStockToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.cargarAlStockToolStripMenuItem.Text = "Cargar al stock";
            // 
            // verStockToolStripMenuItem
            // 
            this.verStockToolStripMenuItem.Name = "verStockToolStripMenuItem";
            this.verStockToolStripMenuItem.Size = new System.Drawing.Size(82, 26);
            this.verStockToolStripMenuItem.Text = "Ver stock";
            this.verStockToolStripMenuItem.Click += new System.EventHandler(this.verStockToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_cantidad);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cb_prod);
            this.groupBox1.Controls.Add(this.tb_color);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.pictureBoxQRCode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbox_detalle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_producto);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 610);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de stock";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "Producto: ";
            // 
            // cb_prod
            // 
            this.cb_prod.FormattingEnabled = true;
            this.cb_prod.Location = new System.Drawing.Point(162, 96);
            this.cb_prod.Name = "cb_prod";
            this.cb_prod.Size = new System.Drawing.Size(270, 24);
            this.cb_prod.TabIndex = 24;
            // 
            // tb_color
            // 
            this.tb_color.Location = new System.Drawing.Point(162, 229);
            this.tb_color.Name = "tb_color";
            this.tb_color.Size = new System.Drawing.Size(270, 22);
            this.tb_color.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Color:";
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(107, 272);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(277, 254);
            this.pictureBoxQRCode.TabIndex = 8;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(302, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 53);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbox_detalle
            // 
            this.tbox_detalle.Location = new System.Drawing.Point(162, 187);
            this.tbox_detalle.Name = "tbox_detalle";
            this.tbox_detalle.Size = new System.Drawing.Size(270, 22);
            this.tbox_detalle.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Detalle: ";
            // 
            // dtpicker
            // 
            this.dtpicker.Location = new System.Drawing.Point(162, 139);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(270, 22);
            this.dtpicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de llegada: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de producto: ";
            // 
            // cb_producto
            // 
            this.cb_producto.FormattingEnabled = true;
            this.cb_producto.Location = new System.Drawing.Point(162, 53);
            this.cb_producto.Name = "cb_producto";
            this.cb_producto.Size = new System.Drawing.Size(270, 24);
            this.cb_producto.TabIndex = 0;
            this.cb_producto.SelectedIndexChanged += new System.EventHandler(this.cb_producto_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_tipo);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tb_precio);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tb_nuevaempresa);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_nuevocod);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_nuevoprod);
            this.groupBox2.Controls.Add(this.tb_nuevasmedidas);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(529, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 340);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar nuevo";
            // 
            // cb_tipo
            // 
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Location = new System.Drawing.Point(183, 31);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(269, 24);
            this.cb_tipo.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo: ";
            // 
            // tb_precio
            // 
            this.tb_precio.Location = new System.Drawing.Point(182, 232);
            this.tb_precio.Name = "tb_precio";
            this.tb_precio.Size = new System.Drawing.Size(270, 22);
            this.tb_precio.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Precio: ";
            // 
            // tb_nuevaempresa
            // 
            this.tb_nuevaempresa.Location = new System.Drawing.Point(183, 188);
            this.tb_nuevaempresa.Name = "tb_nuevaempresa";
            this.tb_nuevaempresa.Size = new System.Drawing.Size(270, 22);
            this.tb_nuevaempresa.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Empresa: ";
            // 
            // tb_nuevocod
            // 
            this.tb_nuevocod.Location = new System.Drawing.Point(183, 108);
            this.tb_nuevocod.Name = "tb_nuevocod";
            this.tb_nuevocod.Size = new System.Drawing.Size(270, 22);
            this.tb_nuevocod.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Codigo: ";
            // 
            // tb_nuevoprod
            // 
            this.tb_nuevoprod.Location = new System.Drawing.Point(183, 71);
            this.tb_nuevoprod.Name = "tb_nuevoprod";
            this.tb_nuevoprod.Size = new System.Drawing.Size(270, 22);
            this.tb_nuevoprod.TabIndex = 16;
            // 
            // tb_nuevasmedidas
            // 
            this.tb_nuevasmedidas.Location = new System.Drawing.Point(182, 147);
            this.tb_nuevasmedidas.Name = "tb_nuevasmedidas";
            this.tb_nuevasmedidas.Size = new System.Drawing.Size(270, 22);
            this.tb_nuevasmedidas.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(276, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 53);
            this.button2.TabIndex = 21;
            this.button2.Text = "Cargar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Medidas: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nuevo producto: ";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(942, 538);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 53);
            this.button3.TabIndex = 20;
            this.button3.Text = "Imprimir";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(529, 397);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(511, 100);
            this.listBox1.TabIndex = 21;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Brown;
            this.trackBar1.Location = new System.Drawing.Point(6, 23);
            this.trackBar1.Maximum = 48;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(203, 56);
            this.trackBar1.TabIndex = 22;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "QR por hoja";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // nprod
            // 
            this.nprod.AutoSize = true;
            this.nprod.Location = new System.Drawing.Point(792, 509);
            this.nprod.Name = "nprod";
            this.nprod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nprod.Size = new System.Drawing.Size(235, 16);
            this.nprod.TabIndex = 23;
            this.nprod.Text = "Te quedan 48 productos para agregar";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.Location = new System.Drawing.Point(850, 545);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 24;
            this.button4.Text = "vaciar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Location = new System.Drawing.Point(550, 509);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 82);
            this.panel1.TabIndex = 25;
            // 
            // tb_cantidad
            // 
            this.tb_cantidad.Location = new System.Drawing.Point(391, 14);
            this.tb_cantidad.Name = "tb_cantidad";
            this.tb_cantidad.Size = new System.Drawing.Size(114, 22);
            this.tb_cantidad.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(323, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Cantidad";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 663);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nprod);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Articogar Stock";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cargarAlStockToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_producto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbox_detalle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.PictureBox pictureBoxQRCode;
        private System.Windows.Forms.ToolStripMenuItem verStockToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_nuevaempresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_nuevocod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_nuevoprod;
        private System.Windows.Forms.TextBox tb_nuevasmedidas;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label nprod;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_precio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_prod;
        private System.Windows.Forms.TextBox tb_cantidad;
        private System.Windows.Forms.Label label13;
    }
}

