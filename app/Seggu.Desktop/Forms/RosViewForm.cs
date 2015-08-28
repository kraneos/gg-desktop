using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Data;
using System.Xml;
using System.Xml.Linq;
using Seggu.Domain;

namespace Seggu.Desktop.Forms
{
    public partial class RosViewForm : Form
    {
        public RosViewForm(DateTime a,DateTime b, Producer pro)
        {
            InitializeComponent();
            var table = getRcrView2(a, b, pro);
            this.DtgRos.DataSource = table;
            
            
            
            from=a;
            to=b;
            producer =pro;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //var from = RcrReportForm.FromDateTimePicker.Value;
                //var to = this.ToDateTimePicker.Value;
                //var producer = (Producer)this.ProductorComboBox.SelectedItem;
                var document = new XDocument(new XDeclaration("1.0", "utf-16", "yes"));
                var ssn = GetSsnElement(from, to, producer);
                document.Add(ssn);



                string tempPath = System.IO.Path.GetTempPath();
                tempPath = System.IO.Path.Combine(tempPath, "RCR-" + DateTime.Today.ToString("yyyy-MM-dd") + ".xml");
                document.Save(tempPath, SaveOptions.None);
                System.Diagnostics.Process.Start(tempPath);
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el XML. Intente de nuevo.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RosViewForm_Load(object sender, EventArgs e)
        {

        }
        private static XElement GetSsnElement(DateTime from, DateTime to, Producer producer)
        {
            from = from.Date;
            to = to.Date.AddDays(1);

            var records = SegguContainer.Instance.CashAccounts.Include("Fee").Include("Fee.Policy").Include("Fee.Policy.Risk").Include("Fee.Policy.Risk.Company")
                .Where(ca => ca.Date > from && ca.Date < to && ca.FeeId != null)
                .ToArray();

            var ssn = new XElement("SSN");
            var cabecera = new XElement("Cabecera");
            cabecera.Add(new XElement("Version", 1));
            var productorAttrs = new XAttribute[]
            {
                new XAttribute("TipoPersona", "2"), 
                new XAttribute("Matricula", producer.RegistrationNumber),
                new XAttribute("CUIT", producer.RegistrationNumber),
            };
            var productor = new XElement("Productor", productorAttrs);

            cabecera.Add(productor);
            cabecera.Add(new XElement("CantidadRegistros", records.Count()));
            ssn.Add(cabecera);

            var registros = new List<XElement>();

            for (var i = 0; i < records.Length; i++)
            {
                var record = records[i];
                var tipoRegistro = new XElement("TipoRegistro", 1);
                var fechaRegistro = new XElement("FechaRegistro", record.Date.ToString("yyyy-MM-dd"));
                var concepto = new XElement("Concepto", record.ReceiptNumber);
                var polizas = new XElement("Polizas", new XElement[]
                    {
                        new XElement("Poliza", record.Fee.Policy.Number)
                    });
                var ciaId = new XElement("CiaID", record.Fee.Policy.Risk.Company.Name);
                var importe = new XElement("Importe", record.Amount);
                var importeTipo = new XElement("ImporteTipo", 1);
                var nroRegistroAnulaModifica = new XElement("NroRegistroAnulaModifica", null);

                var elements = new XElement[]
                {
                    tipoRegistro,
                    fechaRegistro,
                    concepto,
                    polizas,
                    ciaId,
                    importe,
                    importeTipo,
                    nroRegistroAnulaModifica
                };
                var registro = new XElement("Registro", elements);

                registros.Add(registro);
            }

            var detalle = new XElement("Detalle", registros);

            ssn.Add(detalle);

            return ssn;
        }
        private DataTable getRcrView2(DateTime a,DateTime b, Producer pro)
        {
            var table = new DataTable();
            var records = SegguContainer.Instance.CashAccounts
                .Include("Fee").Include("Fee.Policy")
                .Include("Fee.Policy.Risk")
                .Include("Fee.Policy.Risk.Company")
                .Where(ca => ca.Date > a && ca.Date < b && ca.FeeId != null)
                .ToArray();
            table.Columns.Add("TipoRegistro", typeof(string));
            table.Columns.Add("FechaRegistro", typeof(string));
            table.Columns.Add("Concepto", typeof(string));
            table.Columns.Add("Poliza", typeof(string));
            table.Columns.Add("CiaID", typeof(string));
            table.Columns.Add("Importe", typeof(string));
            table.Columns.Add("ImporteTipo", typeof(string));
            table.Columns.Add("NroRegistroAnulaModifica", typeof(string));

            for (var i = 0; i < records.Length; i++)
            {
                var record = records[i];
                var row = table.NewRow();
                row["TipoRegistro"] = 1;
                row["FechaRegistro"] =  record.Date.ToString("yyyy-MM-dd");
                if (record.ReceiptNumber !=null)
                {
                row["Concepto"] = record.ReceiptNumber;
                }
                row["Poliza"] = record.Fee.Policy.Number;
                row["CiaID"] = record.Fee.Policy.Risk.Company.Name;
                row["Importe"] = record.Amount;
                row["ImporteTipo"] = 1;
                row["NroRegistroAnulaModifica"] = 1;
                table.Rows.Add(row);
            }



            return table;
        }

        public DateTime from { get; set; }

        public DateTime to { get; set; }

        public Producer producer { get; set; }
    }
}
