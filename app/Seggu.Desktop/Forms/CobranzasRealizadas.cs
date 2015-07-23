using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Data;

namespace Seggu.Desktop.Forms
{
    public partial class CobranzasRealizadas : Form
    {
        public CobranzasRealizadas()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DTPCobranzas.Value > dateTimePicker1.Value) { MessageBox.Show("Ingrese una fecha valida"); }
                else
                {
                    var from = DTPCobranzas.Value;
                    var to = dateTimePicker1.Value;
                    var table = getCobranzas(from, to);
                    this.dataGridView1.DataSource = table;
                    this.dataGridView1.Columns["CiaID"].Visible = false;
                    this.dataGridView1.Columns["ImporteTipo"].Visible = false;
                    this.dataGridView1.Columns["NroRegistroAnulaModifica"].Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al generar el reporte. Intente de nuevo.");
            }
        }
        private DataTable getCobranzas(DateTime from, DateTime to)
        {
            var table = new DataTable();
            var records = SegguContainer.Instance.CashAccounts
                .Include("Fee").Include("Fee.Policy")
                .Include("Fee.Policy.Risk")
                .Include("Fee.Policy.Risk.Company")
                .Where(ca => ca.Date > from && ca.Date < to && ca.FeeId != null)
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
                row["FechaRegistro"] = record.Date.ToString("yyyy-MM-dd");
                if (record.ReceiptNumber != null)
                {
                    row["Concepto"] = record.ReceiptNumber;
                }
                if (record.Fee != null)
                {
                    if (record.Fee.Policy != null)
                    {
                        row["Poliza"] = record.Fee.Policy.Number;                        
                    }
                }
                row["CiaID"] = record.Fee.Policy.Risk.Company.Name;
                row["Importe"] = record.Amount;
                row["ImporteTipo"] = 1;
                row["NroRegistroAnulaModifica"] = 1;
                table.Rows.Add(row);
            }



            return table;
        }

        private void DTPCobranzas_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
