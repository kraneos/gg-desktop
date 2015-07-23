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

namespace Seggu.Desktop.Forms
{
    public partial class RcrViewForm : Form
    {
        public RcrViewForm(DateTime a,DateTime b,Producer pro)
        {
            InitializeComponent();
           var table = GetRcrView(a,b,pro);
           this.DTGRcr.DataSource = table;
           producer = pro;
           from = a;
           to = b;
            //rc.
            //DTGRcr.DataSource = ;
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void DTGRcr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
        private void RcrViewForm_Load(object sender, EventArgs e)
        {

        }
        private DataTable GetRcrView(DateTime a, DateTime b, Producer pro)
        {
            var table = new DataTable();
            var records = SegguContainer.Instance.Policies
                .Include("Client")
                .Include("Risk")
                .Include("Risk.Company")
                .Include("Client.Addresses")
                .Include("Client.Addresses.Locality")
                .Include("Client.Addresses.Locality.District")
                .Include("Client.Addresses.Locality.District.Province")
                .Where(ca => ca.EmissionDate > a && ca.EmissionDate < b && ca.EmissionDate != null)
                .ToArray();

            table.Columns.Add("NroOrden", typeof(string));
            table.Columns.Add("FechaRegistro", typeof(string));
            table.Columns.Add("Asegurado", typeof(string));
            table.Columns.Add("Dni", typeof(string));
            table.Columns.Add("Tipo Documento", typeof(string));
            table.Columns.Add("Tipo Asegurado", typeof(string));
            table.Columns.Add("Codigo Postal", typeof(string));
            table.Columns.Add("Domicilio", typeof(string));
            table.Columns.Add("Cpa Cantidad", typeof(string));
            //table.Columns.Add("Codigo Postal", typeof(string));
            table.Columns.Add("Bien Asegurado", typeof(string));
            //table.Columns.Add("Codigo Postal", typeof(string));
            //table.Columns.Add("Bien Asegurado", typeof(string));
            table.Columns.Add("Ramo", typeof(string));
            table.Columns.Add("Suma Asegurada", typeof(string));
            table.Columns.Add("tipo suma asegurada", typeof(string));
            table.Columns.Add("Fecha hasta", typeof(string));
            table.Columns.Add("Fecha desde", typeof(string));
            table.Columns.Add("Poliza", typeof(string));
            table.Columns.Add("Tipo Poliza", typeof(string));
            table.Columns.Add("Flota", typeof(string));
            table.Columns.Add("Origen operacion", typeof(string));

            for (var i = 0; i < records.Length; i++)
            {
                var record = records[i];
                var row = table.NewRow();
                var address = record.Client.Addresses.FirstOrDefault();
                row["NroOrden"] = i + 1;
                row["FechaRegistro"] = record.EmissionDate.Value.ToString("yyyy-MM-dd");
                row["Asegurado"] = record.Client.FirstName + " " + record.Client.LastName;
                row["Dni"] = record.Client.Document;
                row["Tipo Documento"] = 1;
                row["Tipo Asegurado"] = 1;
                if (address != null)
                {
                    row["Codigo Postal"] = address.PostalCode;
                    row["Domicilio"] = address.Street + " " + address.Number + ", " + address.Locality.Name + ", " + address.Locality.District.Name + ", " + address.Locality.District.Province.Name;
                    row["Cpa Cantidad"] = 1;
                }
               // row["Codigo Postal"] = address.PostalCode;
                row["Bien Asegurado"] = record.Risk.RiskType == RiskType.Automotores ? "Automovil" : (record.Risk.RiskType == RiskType.Combinados_Integrales ? "Integral De Comercio" : "Seguro de Vida");
                row["Ramo"] = 34;
                row["Suma Asegurada"] = record.Value;
                row["tipo suma asegurada"] = 1;
                row["Fecha hasta"] = record.EndDate.ToString("yyyy-MM-dd");
                row["Fecha desde"] = record.StartDate.ToString("yyyy-MM-dd");
                row["Poliza"] = record.Number;
                row["Tipo Poliza"] = 2;
                row["Flota"] = 0;
                row["Origen operacion"] = 1;
                table.Rows.Add(row);
                //table.Columns.Add("Nombre", typeof(string));
            }
            return table;

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
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
        public DateTime from { get; set; }

        public DateTime to { get; set; }

        public Producer producer { get; set; }
    }
}
