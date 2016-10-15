using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Data;
using Seggu.Domain;
using Seggu.Services.Interfaces;

namespace Seggu.Desktop.Forms
{
    public partial class PolizasPorFecha : Form
    {
        private IPolicyService policyService;
        public PolizasPorFecha(IPolicyService policyService)
        {
            InitializeComponent();
            this.policyService = policyService;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                { MessageBox.Show("Ingrese una fecha valida"); }
                else
                {
                    var from = dateTimePicker1.Value;
                    var to = dateTimePicker2.Value;
                    var table = PolizasPorFechas(from, to);
                    this.dataGridView1.DataSource = table;
                    this.dataGridView1.Columns["Tipo Documento"].Visible = false;
                    this.dataGridView1.Columns["Tipo Asegurado"].Visible = false;
                    this.dataGridView1.Columns["Cpa Cantidad"].Visible = false;
                    this.dataGridView1.Columns["Ramo"].Visible = false;
                    this.dataGridView1.Columns["Tipo Poliza"].Visible = false;
                    this.dataGridView1.Columns["Flota"].Visible = false;
                    this.dataGridView1.Columns["Origen operacion"].Visible = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el reporte. Intente de nuevo.");
            }
        }
        private DataTable PolizasPorFechas(DateTime from, DateTime to)
        {
            var table = new DataTable();
            var records = this.policyService.GetRosView(from, to).ToArray();

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
                row["NroOrden"] = i + 1;
                row["FechaRegistro"] = record.StartDate;
                row["Asegurado"] = record.ClientFullName;
                row["Dni"] = record.ClientDocument;
                row["Tipo Documento"] = 1;
                row["Tipo Asegurado"] = 1;
                row["Codigo Postal"] = record.ClientAddressPostalCode;
                row["Domicilio"] = record.ClientAddressLine;
                row["Cpa Cantidad"] = 1;
                // row["Codigo Postal"] = address.PostalCode;
                row["Bien Asegurado"] = record.RiskType;
                row["Ramo"] = 34;
                row["Suma Asegurada"] = record.Value;
                row["tipo suma asegurada"] = 1;
                row["Fecha hasta"] = record.EndDate;
                row["Fecha desde"] = record.StartDate;
                row["Poliza"] = record.Number;
                row["Tipo Poliza"] = 2;
                row["Flota"] = 0;
                row["Origen operacion"] = 1;
                table.Rows.Add(row);
                //table.Columns.Add("Nombre", typeof(string));
            }
            return table;

        }
    }
}
