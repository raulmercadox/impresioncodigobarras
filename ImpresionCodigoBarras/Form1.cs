using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZXing;
using ZXing.Common;

namespace ImpresionCodigoBarras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var desde = int.Parse(txtDesde.Text);
            var hasta = int.Parse(txtHasta.Text);
            var ds = new DatosReporte();
            var tabla = ds.Datos;
            for (var i = desde; i <= hasta; i++)
            {
                var fila = tabla.NewDatosRow();
                /*var barcode = new Barcode();
                var barra = barcode.Encode(TYPE.CODE11, txtSerie.Text + "-" + i.ToString().PadLeft(6, '0'),
                    Color.Black, Color.White, 300, 300);
                var ic = new ImageConverter();
                fila.Imagen = (byte[])ic.ConvertTo(barra, typeof(byte[]));*/

                var writer = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new EncodingOptions { Height = 200, Width = 200 }
                };
                var qr = writer.Write(txtSerie.Text + "-" + i.ToString().PadLeft(6, '0'));
                var ic = new ImageConverter();
                fila.Imagen = (byte[])ic.ConvertTo(qr, typeof(byte[]));

                tabla.AddDatosRow(fila);
            }            
            var frm = new Imprimir(ds);
            frm.ShowDialog();
        }
    }
}
