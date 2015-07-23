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
    public partial class FormCobranzasVencidas : Form
    {
        public FormCobranzasVencidas()
        {
            InitializeComponent();
            /*var time = DateTime.Now;
            var TABLE =  cobranzaVencida(time);
            this.dataGridView1.DataSource = TABLE;*/
        }

        private void FormCobranzasVencidas_Load(object sender, EventArgs e)
        {
            
        }
        private DataTable cobranzaVencida(DateTime time)
        {
            var table = new DataTable();
            var records = SegguContainer.Instance.CashAccounts
                .Include("Fee").Include("Fee.Policy")
                .Include("Fee.Policy.Risk")
                .Include("Fee.Policy.Risk.Company")
                .Where(ca =>  ca.Date < time && ca.FeeId == null)
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
                if (record.Fee.Policy.Number != null)
                {
                    row["Poliza"] = record.Fee.Policy.Number;
                }
                row["CiaID"] = record.Fee.Policy.Risk.Company.Name;
                row["Importe"] = record.Amount;
                row["ImporteTipo"] = 1;
                row["NroRegistroAnulaModifica"] = 1;
                table.Rows.Add(row);
            }



            return table;
        }
        
    }
}
