using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Data;
using Seggu.Services.Interfaces;

namespace Seggu.Desktop.Forms
{
    public partial class FormCobranzasVencidas : Form
    {
        private ICashAccountService cashAccountService;
        public FormCobranzasVencidas(ICashAccountService cashAccountService)
        {
            InitializeComponent();
            this.cashAccountService = cashAccountService;
            /*var time = DateTime.Now;
            var TABLE =  cobranzaVencida(time);
            this.dataGridView1.DataSource = TABLE;*/
        }

        private void FormCobranzasVencidas_Load(object sender, EventArgs e)
        {
            
        }
        private DataTable CobranzaVencida(DateTime time)
        {
            var table = new DataTable();
            var records = this.cashAccountService.GetOverdue(time).ToArray();
            //var records = SegguContainer.Instance.CashAccounts
            //    .Include("Fee")
            //    .Include("Fee.Policy")
            //    .Include("Fee.Policy.Risk")
            //    .Include("Fee.Policy.Risk.Company")
            //    .Where(ca =>  ca.Date < time && ca.FeeId == null)
            //    .ToArray();
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
                row["FechaRegistro"] = record.RecordDate;
                if (record.ReceiptNumber != null)
                {
                    row["Concepto"] = record.ReceiptNumber;
                }
                if (record.PolicyNumber != null)
                {
                    row["Poliza"] = record.PolicyNumber;
                }
                row["CiaID"] = record.CompanyName;
                row["Importe"] = record.Amount;
                row["ImporteTipo"] = 1;
                row["NroRegistroAnulaModifica"] = 1;
                table.Rows.Add(row);
            }



            return table;
        }
        
    }
}
