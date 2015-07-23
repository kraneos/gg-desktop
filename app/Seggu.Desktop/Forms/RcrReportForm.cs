using Seggu.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Seggu.Desktop.Forms
{
    public partial class RcrReportForm : Form
    {
        public RcrReportForm()
        {
            InitializeComponent();

            this.ProductorComboBox.DataSource = SegguContainer.Instance.Producers.ToList();
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
                    var from = this.FromDateTimePicker.Value;
                    var to = this.ToDateTimePicker.Value;
                    var producer = (Producer)this.ProductorComboBox.SelectedItem;
                    /*
                    var document = new XDocument(new XDeclaration("1.0", "utf-16", "yes"));
                    var ssn = GetSsnElement(from, to, producer);
                    document.Add(ssn);

                    string tempPath = System.IO.Path.GetTempPath();
                    tempPath = System.IO.Path.Combine(tempPath, "RCR-" + DateTime.Today.ToString("yyyy-MM-dd") + ".xml");
                    document.Save(tempPath, SaveOptions.None);
                    System.Diagnostics.Process.Start(tempPath);*/
                    RcrViewForm frm = new RcrViewForm(from, to, producer);
                    frm.Show();
                    this.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el reporte. Intente de nuevo.");
            }
        }

        private static XElement GetSsnElement(DateTime from, DateTime to, Producer producer)
        {
            from = from.Date;
            to = to.Date.AddDays(1);

            var records = SegguContainer.Instance.Policies
                .Include("Client")
                .Include("Risk")
                .Include("Risk.Company")
                .Include("Client.Addresses")
                .Include("Client.Addresses.Locality")
                .Include("Client.Addresses.Locality.District")
                .Include("Client.Addresses.Locality.District.Province")
                .Where(ca => ca.EmissionDate > from && ca.EmissionDate < to && ca.EmissionDate != null)
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
                var nroOrden = new XElement("NroOrden", i + 1);
                var fechaRegistro = new XElement("FechaRegistro", record.EmissionDate.Value.ToString("yyyy-MM-dd"));
                var asegurado = new XElement("Asegurados", new XElement[]
                    {
                        new XElement("Asegurado", 
                            new XAttribute[]
                            {
                                new XAttribute("TipoAsegurado", 1),
                                new XAttribute("TipoDoc", 1),
                                new XAttribute("NroDoc", record.Client.Document),
                                new XAttribute("Nombre", record.Client.FirstName + " " + record.Client.LastName)
                            })
                    });
                var address = record.Client.Addresses.FirstOrDefault();
                XElement cpaProponente = new XElement("CPAProponente", string.Empty);
                XElement obsProponente = new XElement("ObsProponente", string.Empty);
                XElement codigosPostales = new XElement("CodigosPostales", new XElement("CPA", string.Empty));
                if (address != null)
                {
                    cpaProponente = new XElement("CPAProponente", address.PostalCode);
                    obsProponente = new XElement("ObsProponente", address.Street + " " + address.Number + ", " + address.Locality.Name + ", " + address.Locality.District.Name + ", " + address.Locality.District.Province.Name);
                    codigosPostales = new XElement("CodigosPostales", new XElement("CPA", address.PostalCode));
                }
                var cpaCantidad = new XElement("CPACantidad", 1);
                var ciaId = new XElement("CiaID", string.Empty);
                var bienAsegurado = new XElement("BienAsegurado", record.Risk.RiskType == RiskType.Automotores ? "Automovil" : (record.Risk.RiskType == RiskType.Combinados_Integrales ? "Integral De Comercio" : "Seguro de Vida"));
                var ramo = new XElement("Ramo", 34);
                var sumaAsegurada = new XElement("SumaAsegurada", record.Value);
                var sumaAseguradaTipo = new XElement("SumaAseguradaTipo", 1);
                var cobertura = new XElement("Cobertura", new XAttribute("FechaDesde", record.StartDate.ToString("yyyy-MM-dd")), new XAttribute("FechaHasta", record.EndDate.ToString("yyyy-MM-dd")));
                var observacion = new XElement("Observacion", new XAttribute("Tipo", 2), new XAttribute("Poliza", record.Number), new XAttribute("NroOrdenAnulaModifica", string.Empty));
                var flota = new XElement("Flota", 0);
                var operacionOrigen = new XElement("OperacionOrigen", 1);

                var elements = new XElement[]
                {
                    nroOrden,
                    fechaRegistro,
                    asegurado,
                    cpaProponente,
                    obsProponente,
                    cpaCantidad,
                    codigosPostales,
                    ciaId,
                    bienAsegurado,
                    ramo,
                    sumaAsegurada,
                    sumaAseguradaTipo,
                    cobertura,
                    observacion,
                    flota,
                    operacionOrigen
                };

                var registro = new XElement("Registro", elements);

                registros.Add(registro);
            }

            var detalle = new XElement("Detalle", registros);

            ssn.Add(detalle);

            return ssn;
        }

        
    }
}
