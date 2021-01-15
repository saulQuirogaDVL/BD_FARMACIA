using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BD_FARMACIA
{
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            this.TOTALTableAdapter.Fill(this.PROYECTO_FARMACIADataSet4.TOTAL,textBox1.Text);
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("nit", this.textBox1.Text);
            this.FACDATTableAdapter.Fill(this.PROYECTO_FARMACIADataSet2.FACDAT,textBox1.Text);
            parameters[0] = new ReportParameter("nit", this.textBox1.Text);
            this.IMPFACTableAdapter.Fill(this.PROYECTO_FARMACIADataSet3.IMPFAC,textBox1.Text);
            parameters[0] = new ReportParameter("nit", this.textBox1.Text);
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
