using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Google.Apis.Drive.v3;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CreadorQR
{
    public partial class Form1 : Form
    {

        JObject STOCK_DATABASE, PRODUCT_DATABASE;
        
        iTextSharp.text.Document doc = new iTextSharp.text.Document();        
        private double qrX, qrY; // coordenadas del qr en el pdf 
        public int itemsInPdf = 48;

        private int idx_local = 0;
        List<idProduct> GLOBAL_IDENTITIES = new List<idProduct>();
        
        // Lista de categorias de productos del local
        List<string> TIPOS_DE_PRODUCTOS = new List<string> { "botineros", "cocina", "comoda", "escritorios", "mesa de luz", "mesa ratona",
                                                             "mesas", "multiespacios", "organizadores", "placares", "rack panel tv",
                                                             "sillas" };

        public Form1()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "myAuthSecret :)",
            BasePath = "myBasePath"
        };

        IFirebaseClient client;

        QRCode generarQr (string text) {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear QR y cargar al stock
            if (cb_producto.SelectedIndex != -1 && cb_prod.SelectedIndex != -1)
            {
                int espacio_necesario = 1;

                string cantidad = tb_cantidad.Text;
                try {
                    if (int.Parse(cantidad) > 1) { espacio_necesario = int.Parse(cantidad); }
                }
                catch
                { }

                if (itemsInPdf - listBox1.Items.Count >= espacio_necesario)
                {
                    for (int n = 0; n < espacio_necesario; n++) {

                        string date_code = DateTime.Now.ToString();
                        string CODE = date_code + idx_local.ToString();

                        // Guardar qr en .png temporal
                        QRCode qrCode = generarQr(CODE);
                        pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(6);
                        qrCode.GetGraphic(pdfSize()).Save("qr_file.png");

                        // Agregar qr al pdf
                        iTextSharp.text.Image qrImg = iTextSharp.text.Image.GetInstance("qr_file.png");
                        qrImg.ScaleAbsoluteWidth(100); qrImg.ScaleAbsoluteHeight(100);
                        qrImg.SetAbsolutePosition((int)qrX, (int)qrY);
                        doc.Add(qrImg);

                        if (qrX < 500) { qrX += pdfSize() * 20; }
                        else { qrX = 0; qrY -= pdfSize() * 20; }

                        listBox1.Items.Add(cb_prod.SelectedItem.ToString() + " " + idx_local.ToString());

                        nprod.Text = "Te quedan " + (itemsInPdf - listBox1.Items.Count).ToString() + " productos por agregar";

                        idx_local++;
                        GLOBAL_IDENTITIES.Add(new idProduct()
                        {
                            arrive = CODE,
                            color = tb_color.Text.ToUpper(),
                            detail = tbox_detalle.Text,
                            type = cb_producto.SelectedItem.ToString(),
                            product = cb_prod.SelectedItem.ToString(),
                        });

                        panel1.Visible = false;

                        tb_color.Text = "";
                        tbox_detalle.Text = "";
                        cb_prod.Text = "";
                        tb_cantidad.Text = "";

                        idx_local++;
                    }

                    if (espacio_necesario == 1)
                        MessageBox.Show("Se ha agregado el producto ", "Cargar al stock");
                    else
                        MessageBox.Show("Se han agregado "+espacio_necesario.ToString()+" productos. ", "Cargar al stock");

                }
                else { MessageBox.Show("Tienes la lista llena!", "Cargar al stock");  }
            }
            else { MessageBox.Show ("No has elegido ningun producto!", "Cargar al stock"); }

        }

        private int pdfSize() { return (int)(itemsInPdf * 0.10417); }


        async void liveCall() {
            while (true)
            {
                FirebaseResponse res = await client.GetAsync(@"stock");
                STOCK_DATABASE = JsonConvert.DeserializeObject<JObject>(res.Body.ToString());
                FirebaseResponse _res = await client.GetAsync(@"datos-productos");
                PRODUCT_DATABASE = JsonConvert.DeserializeObject<JObject>(_res.Body.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QRCode qrCode = generarQr("enunlugardelamanchad");
            pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(6);
            try { client = new FirebaseClient(ifc); }
            catch { MessageBox.Show("Problemas de conexion a internet!", "Error"); }
            
            try
            {
                PdfWriter.GetInstance(doc, new FileStream("temp_print.pdf", FileMode.Create));
                doc.Open();
            }
            catch { }
           
            qrX = 0; qrY = pdfSize() * 140;
            panel1.Visible = true;
            trackBar1.Value = 48;
            
            cb_tipo.DataSource = null;
            cb_tipo.DataSource = TIPOS_DE_PRODUCTOS;
            cb_producto.DataSource = TIPOS_DE_PRODUCTOS;

            tb_nuevoprod.Text = "";
            tb_nuevocod.Text = "";
            tb_nuevasmedidas.Text = "";
            tb_nuevaempresa.Text = "";
            tb_precio.Text = "";

            liveCall();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            itemsInPdf = trackBar1.Value;
            nprod.Text = "Te quedan " + (itemsInPdf - listBox1.Items.Count).ToString() + " productos por agregar";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // vaciar
            listBox1.Items.Clear();
            try { restartDocument(); }
            catch { }
            nprod.Text = "Te quedan " + (itemsInPdf - listBox1.Items.Count).ToString() + " productos por agregar";
            panel1.Visible = true;

            Directory.Delete(Application.StartupPath + @"\qr_imagenes", true);
        
        }

        private void restartDocument()
        {
            doc.Close();
            qrX = 0; qrY = pdfSize() * 140;
            doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("temp_print.pdf", FileMode.Create));
            doc.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datosProductos data = new datosProductos() { 
                nombre = tb_nuevoprod.Text.ToUpper(),
                empresa = tb_nuevaempresa.Text.ToUpper(),
                medidas = tb_nuevasmedidas.Text.ToUpper(),   
                precio = tb_precio.Text.ToUpper(),
                id = tb_nuevocod.Text.ToUpper(),
                tipo = cb_tipo.Text,
            };

            if (data.nombre != "" && data.empresa != "" & data.id != "" && data.precio != "")
            {
                if (PRODUCT_DATABASE is null || PRODUCT_DATABASE[data.tipo] is null) {
                    var setter = client.Set("datos-productos/" + data.tipo + "/" + data.id, data);
                    MessageBox.Show("Producto agregado!", "Nuevos Productos");
                    Form1_Load(sender, e);
                }
                else
                {
                    if (!DatabaseManager.ObjectContainsKey((JObject)PRODUCT_DATABASE[data.tipo], data.id))
                    {
                        var setter = client.Set("datos-productos/" + data.tipo + "/" + data.id, data);
                        MessageBox.Show("Producto agregado!", "Nuevos Productos");
                        Form1_Load(sender, e);
                    }
                    else { MessageBox.Show("El codigo ya existe en la base de datos", "Error"); }
                }

            }
            else { MessageBox.Show("Te falta completar datos", "Error"); }
        }

        private void cb_producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llenar productos cb
            cb_prod.Items.Clear();

            string tipo = cb_producto.SelectedItem.ToString();

            if (PRODUCT_DATABASE != null && PRODUCT_DATABASE[tipo] != null)
            {
                foreach (var item in PRODUCT_DATABASE[tipo])
                {
                    cb_prod.Items.Add(item.Path.Replace(tipo, "").Replace("['", "").Replace("']", "").Replace(".", ""));
                }
            }

        }

        private void verStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // abrir form de stock
            VerStock nForm = new VerStock();
            nForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GLOBAL_IDENTITIES.Count > 0)
            {
                // imprimir
                try
                {
                    // abrir impresion de pdf
                    doc.Close();
                    Process.Start(Path.Combine(Application.StartupPath, "temp_print.pdf"));
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\qr_imagenes");
                }
                catch { }

                if (!Directory.Exists(Application.StartupPath + @"\qr_imagenes"))
                {
                    Directory.CreateDirectory("qr_imagenes");
                }
                else {
                    Directory.Delete(Application.StartupPath + @"\qr_imagenes", true);
                    Directory.CreateDirectory("qr_imagenes");
                }

                foreach (idProduct ipu in GLOBAL_IDENTITIES)
                {
                    string CODE = ipu.arrive;
                    QRCode qrCode = generarQr(CODE);
                    pictureBoxQRCode.BackgroundImage = qrCode.GetGraphic(6);
                    qrCode.GetGraphic(pdfSize()).Save("qr_file.png");
                    string nCode = CODE.Replace('/', '-').Replace(' ', '_').Replace(':', 'f').Replace('-', '_');
                    string PATH = Application.StartupPath + @"\qr_imagenes\" + ipu.product + " [" +nCode + "].png";
                    qrCode.GetGraphic(pdfSize()).Save(PATH);
                }

                DialogResult dialogResult = MessageBox.Show("Se agregaron los datos al stock id. \nYa imprimiste?", "Seguridad", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // actualizar temp-database.json 
                    foreach (idProduct ipu in GLOBAL_IDENTITIES)
                    {
                        var setter = client.Set("stock/" + ipu.arrive.Replace('/', '-'), ipu);
                    }
                    restartDocument();
                    listBox1.Items.Clear();
                    idx_local = 0;
                    GLOBAL_IDENTITIES.Clear();
                    nprod.Text = "Te quedan " + (itemsInPdf - listBox1.Items.Count).ToString() + " productos por agregar";
                    doc.Open();
                }

            }
        }
    }
}
