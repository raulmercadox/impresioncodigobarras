using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpresionCodigoBarras
{
    public partial class Imprimir : Form
    {
        DatosReporte ds;
        public Imprimir(DatosReporte ds)
        {
            this.ds = ds;
            InitializeComponent();
        }

        private void Imprimir_Load(object sender, EventArgs e)
        {
            var reporte = new Reporte();
            reporte.SetDataSource(this.ds);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.Show();
        }
    }
}
