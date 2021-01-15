namespace BD_FARMACIA
{
    partial class Factura
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.FACDATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PROYECTO_FARMACIADataSet2 = new BD_FARMACIA.PROYECTO_FARMACIADataSet2();
            this.IMPFACBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PROYECTO_FARMACIADataSet3 = new BD_FARMACIA.PROYECTO_FARMACIADataSet3();
            this.TOTALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PROYECTO_FARMACIADataSet4 = new BD_FARMACIA.PROYECTO_FARMACIADataSet4();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.FACDATTableAdapter = new BD_FARMACIA.PROYECTO_FARMACIADataSet2TableAdapters.FACDATTableAdapter();
            this.IMPFACTableAdapter = new BD_FARMACIA.PROYECTO_FARMACIADataSet3TableAdapters.IMPFACTableAdapter();
            this.TOTALTableAdapter = new BD_FARMACIA.PROYECTO_FARMACIADataSet4TableAdapters.TOTALTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.FACDATBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMPFACBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOTALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // FACDATBindingSource
            // 
            this.FACDATBindingSource.DataMember = "FACDAT";
            this.FACDATBindingSource.DataSource = this.PROYECTO_FARMACIADataSet2;
            // 
            // PROYECTO_FARMACIADataSet2
            // 
            this.PROYECTO_FARMACIADataSet2.DataSetName = "PROYECTO_FARMACIADataSet2";
            this.PROYECTO_FARMACIADataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // IMPFACBindingSource
            // 
            this.IMPFACBindingSource.DataMember = "IMPFAC";
            this.IMPFACBindingSource.DataSource = this.PROYECTO_FARMACIADataSet3;
            // 
            // PROYECTO_FARMACIADataSet3
            // 
            this.PROYECTO_FARMACIADataSet3.DataSetName = "PROYECTO_FARMACIADataSet3";
            this.PROYECTO_FARMACIADataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TOTALBindingSource
            // 
            this.TOTALBindingSource.DataMember = "TOTAL";
            this.TOTALBindingSource.DataSource = this.PROYECTO_FARMACIADataSet4;
            // 
            // PROYECTO_FARMACIADataSet4
            // 
            this.PROYECTO_FARMACIADataSet4.DataSetName = "PROYECTO_FARMACIADataSet4";
            this.PROYECTO_FARMACIADataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightCyan;
            this.textBox1.Location = new System.Drawing.Point(328, 49);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 28);
            this.textBox1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.FACDATBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.IMPFACBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.TOTALBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BD_FARMACIA.factura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(81, 100);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(683, 358);
            this.reportViewer1.TabIndex = 1;
            // 
            // FACDATTableAdapter
            // 
            this.FACDATTableAdapter.ClearBeforeFill = true;
            // 
            // IMPFACTableAdapter
            // 
            this.IMPFACTableAdapter.ClearBeforeFill = true;
            // 
            // TOTALTableAdapter
            // 
            this.TOTALTableAdapter.ClearBeforeFill = true;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(832, 517);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Factura";
            this.Text = "FACTURA";
            this.Load += new System.EventHandler(this.Factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FACDATBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMPFACBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOTALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PROYECTO_FARMACIADataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource FACDATBindingSource;
        private PROYECTO_FARMACIADataSet2 PROYECTO_FARMACIADataSet2;
        private System.Windows.Forms.BindingSource IMPFACBindingSource;
        private PROYECTO_FARMACIADataSet3 PROYECTO_FARMACIADataSet3;
        private System.Windows.Forms.BindingSource TOTALBindingSource;
        private PROYECTO_FARMACIADataSet4 PROYECTO_FARMACIADataSet4;
        private PROYECTO_FARMACIADataSet2TableAdapters.FACDATTableAdapter FACDATTableAdapter;
        private PROYECTO_FARMACIADataSet3TableAdapters.IMPFACTableAdapter IMPFACTableAdapter;
        private PROYECTO_FARMACIADataSet4TableAdapters.TOTALTableAdapter TOTALTableAdapter;
    }
}