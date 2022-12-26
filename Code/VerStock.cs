using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreadorQR
{
    public partial class VerStock : Form
    {

        DatabaseManager BDD = new DatabaseManager();
        JObject STOCK_DATABASE, PRODUCT_DATABASE;

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "Some Auth Secret Key",
            BasePath = "https://articogar-database-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;


        List<string> TIPOS_DE_PRODUCTOS = new List<string> { "botineros", "cocina", "comoda", "escritorios", "mesa de luz", "mesa ratona",
                                                             "mesas", "multiespacios", "organizadores", "placares", "rack panel tv",
                                                             "sillas" };

        public VerStock()
        {
            InitializeComponent();
        }

        async void liveCall()
        {
            while (true)
            {
                FirebaseResponse res = await client.GetAsync(@"stock");
                STOCK_DATABASE = JsonConvert.DeserializeObject<JObject>(res.Body.ToString());
                FirebaseResponse _res = await client.GetAsync(@"datos-productos");
                PRODUCT_DATABASE = JsonConvert.DeserializeObject<JObject>(_res.Body.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_nuevocod_TextChanged(object sender, EventArgs e)
        {

        }

        private void VerStock_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("there was a problem in your internet");
            }

            cb_categorias.DataSource = TIPOS_DE_PRODUCTOS;

            liveCall();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // mostrar datos del producto elegido en el cuadrado de abajo
            if (listBox1.SelectedIndex != -1)
            {
                var categoria = cb_categorias.SelectedItem.ToString();
                string prodCode = listBox1.SelectedItem.ToString().Replace(categoria+'.', "");
                
                var product = PRODUCT_DATABASE[categoria][prodCode];

                lbl_codigo.Text = "Codigo: " + prodCode;
                tb_empresa.Text = product["empresa"].ToString();
                tb_precio.Text = product["precio"].ToString();
                tb_nombre.Text = product["nombre"].ToString();
                tb_medidas.Text = product["medidas"].ToString();


                // llenar listbox2 con los ipus que tengan como tipo de producto a prodCode

                listBox2.Items.Clear();
                if (STOCK_DATABASE != null) { 
                    foreach (var item in STOCK_DATABASE)
                    {
                        if (item.Value["type"].ToString() == categoria && item.Value["product"].ToString() == prodCode) {
                            // remove [' ... ']

                            string value = "";
                            for (int q=2; q < item.Value.Path.Length-2; q++) {
                                value += item.Value.Path[q];
                            }
                            listBox2.Items.Add(value);
                        }
                    }

                    lbl_contador.Text = listBox2.Items.Count.ToString();
                }
                
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_fecha.Text = "";
            tb_color.Text = "";
            richTextBox1.Text = "";
            lbl_producto.Text = "";

            if (listBox2.SelectedIndex != -1) {
                var ipu = STOCK_DATABASE[listBox2.SelectedItem.ToString()];
                lbl_fecha.Text = "Fecha: " + ipu["arrive"].ToString();
                lbl_producto.Text = "Producto: " + ipu["product"].ToString();
                tb_color.Text = ipu["color"].ToString();
                richTextBox1.Text = ipu["detail"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cb_categorias.SelectedIndex != -1 && listBox1.SelectedIndex != -1) {

                string categoria = cb_categorias.SelectedItem.ToString();
                string codigo = listBox1.SelectedItem.ToString().Replace(categoria + '.', ""); // del producto en datos-productos

                datosProductos data = new datosProductos()
                {
                    nombre = tb_nombre.Text.ToUpper(),
                    empresa = tb_empresa.Text.ToUpper(),
                    medidas = tb_medidas.Text.ToUpper(),
                    precio = tb_precio.Text.ToUpper(),
                    id = codigo,
                    tipo = categoria,
                };

                if (data.nombre != "" && data.empresa != "" & data.id != "" && data.precio != "")
                {
                    var setter = client.Set("datos-productos/" + data.tipo + "/" + data.id, data);
                    MessageBox.Show("Se actualizaron los datos!", "Datos productos");
                    VerStock_Load(sender, e);
                }
                else { MessageBox.Show("Te falta completar datos", "Error"); }
            
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string categoria = cb_categorias.SelectedItem.ToString();
            string codigo = listBox1.SelectedItem.ToString().Replace(categoria + '.', "");

            if (!BDD.StockUsesProduct(categoria, codigo, STOCK_DATABASE)) { // no references in stockdatabase

                DialogResult dialogResult = MessageBox.Show("Tas seguro?", "Seguridad", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var setter = client.Delete("datos-productos/" + categoria + "/" + codigo);
                    MessageBox.Show("Se borro el producto!", "Datos productos");

                    listBox1.Items.Clear();

                    VerStock_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("No se borro el producto.", "Datos productos");
                }

            }
            else { MessageBox.Show("El producto esta en el stock!\nNo puede ser borrado.", "Error"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // actualizar ipu

            if (listBox2.SelectedIndex != -1) {

                string ipu = listBox2.SelectedItem.ToString();

                string categoria = cb_categorias.SelectedItem.ToString();
                string codigo_producto = listBox1.SelectedItem.ToString().Replace(categoria + '.', "");
                string fecha = STOCK_DATABASE[ipu]["arrive"].ToString() ;

                idProduct updatedIPU = new idProduct()
                {
                    arrive = fecha,
                    color = tb_color.Text.ToUpper(),
                    detail = richTextBox1.Text,
                    type = categoria,
                    product = codigo_producto,
                };

                var setter = client.Set("stock/" + ipu, updatedIPU);
                MessageBox.Show("Se actualizaron los datos!", "Datos productos");
                VerStock_Load(sender, e);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tas seguro?", "Seguridad", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string ipu = listBox2.SelectedItem.ToString();
                var setter = client.Delete("stock/" + ipu);
                MessageBox.Show("Se borro el producto vendido!", "Datos productos");

                listBox2.Items.Clear();

                VerStock_Load(sender, e);
            }
            else
            {
                MessageBox.Show("No se borro el producto.", "Datos productos");
            }

        }
        QRCode generarQr(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // generar qr
            if (listBox2.SelectedIndex != -1) {

                if (!Directory.Exists(Application.StartupPath + @"\qr_imagenes"))
                {
                    Directory.CreateDirectory("qr_imagenes");
                }
                else
                {
                    Directory.Delete(Application.StartupPath + @"\qr_imagenes", true);
                    Directory.CreateDirectory("qr_imagenes");
                }

                try
                {
                    string CODE = listBox2.SelectedItem.ToString();
                    QRCode qrCode = generarQr(CODE);
                    qrCode.GetGraphic(6).Save("qr_file.png");
                    string nCode = CODE.Replace('/', '-').Replace(' ', '_').Replace(':', 'f').Replace('-', '_');
                    string PATH = Application.StartupPath + @"\qr_imagenes\" + tb_nombre.Text + " [" + nCode + "].png";
                    qrCode.GetGraphic(6).Save(PATH);
                }
                catch {
                    MessageBox.Show("No se pudo crear el QR.\nRevisa si ya existe uno igual en el directorio.", "Error");
                }

                System.Diagnostics.Process.Start(Application.StartupPath + @"\qr_imagenes");
            }
        }

        private void cb_categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load listbox 1 (muestra todos los productos de la categoria elegida);

            listBox1.Items.Clear();

            if (PRODUCT_DATABASE != null)
            {
                var categoria = cb_categorias.SelectedItem.ToString();
                if (cb_categorias.SelectedIndex != -1 && PRODUCT_DATABASE[categoria] != null)
                {
                    foreach (var item in PRODUCT_DATABASE[categoria])
                    {
                        listBox1.Items.Add(item.Path.Replace(categoria, "").Replace("['", "").Replace("']", "").Replace(".", ""));
                    }
                }
            }

            tb_empresa.Text = "";
            tb_precio.Text = "";
            tb_nombre.Text = "";
            tb_medidas.Text = "";


            listBox2.Items.Clear();
            lbl_fecha.Text = "";
            tb_color.Text = "";
            richTextBox1.Text = "";
            lbl_producto.Text = "";

        }
    }
}
