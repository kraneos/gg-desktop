using Seggu.Data;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Seggu.Desktop.Forms
{
    public partial class RosReportForm : Form
    {
        private IProducerService producerService;
        private ICashAccountService cashAccountService;

        public RosReportForm(IProducerService producerService, ICashAccountService cashAccountService)
        {
            InitializeComponent();
            this.producerService = producerService;
            this.cashAccountService = cashAccountService;
            this.ProductorComboBox.DataSource = this.producerService.GetProducers().ToList();
            this.ProductorComboBox.ValueMember = "Id";
            this.ProductorComboBox.DisplayMember = "Name";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (FromDateTimePicker.Value > ToDateTimePicker.Value)
                {
                    MessageBox.Show("Ingrese una fecha valida");
                }
                else
                {
                    //  var from = this.FromDateTimePicker.Value;
                    //  var to = this.ToDateTimePicker.Value;
                    //  var producer = (Producer)this.ProductorComboBox.SelectedItem;

                    var from = this.FromDateTimePicker.Value;
                    var to = this.ToDateTimePicker.Value;
                    var producer = (ProducerDto)this.ProductorComboBox.SelectedItem;


                    /* var document = new XDocument(new XDeclaration("1.0", "utf-16", "yes"));
                     var ssn = GetSsnElement(from, to, producer);
                     document.Add(ssn);

                     string tempPath = System.IO.Path.GetTempPath();
                     tempPath = System.IO.Path.Combine(tempPath, "ROS-" + DateTime.Today.ToString("yyyy-MM-dd") + ".xml");
                     document.Save(tempPath, SaveOptions.None);
                     System.Diagnostics.Process.Start(tempPath);*/
                    RosViewForm frm = new RosViewForm(
                        from,
                        to,
                        producer,
                        (ICashAccountService)DependencyResolver.Instance.Resolve(typeof(ICashAccountService)));
                    frm.Show();
                    this.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el reporte. Intente de nuevo.");
            }
        }

        private XElement GetSsnElement(DateTime from, DateTime to, Producer producer)
        {
            from = from.Date;
            to = to.Date.AddDays(1);

            var records = this.cashAccountService.GetRcrView(from, to).ToArray();
            //var records = SegguContainer.Instance.CashAccounts
            //    .Include("Fee")
            //    .Include("Fee.Policy")
            //    .Include("Fee.Policy.Risk")
            //    .Include("Fee.Policy.Risk.Company")
            //    .Where(ca => ca.Date > from && ca.Date < to && ca.FeeId != null)
                //.ToArray();

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
                var fechaRegistro = new XElement("FechaRegistro", record.RecordDate);
                var concepto = new XElement("Concepto", record.ReceiptNumber);
                var polizas = new XElement("Polizas", new XElement[]
                    {
                        new XElement("Poliza", record.PolicyNumber)
                    });
                var ciaId = new XElement("CiaID", record.CompanyName);
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

        private void RosReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
