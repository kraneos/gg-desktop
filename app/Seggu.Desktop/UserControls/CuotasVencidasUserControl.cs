using Seggu.Data;
using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{
    public partial class CuotasVencidasUserControl : UserControl
    {
        public CuotasVencidasUserControl()
        {
            InitializeComponent();
        }

        private Layout LayoutForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

        private void AseguradosUserControl_Load(object sender, EventArgs e)
        {
            InitializeIndex();
        }

        public void InitializeIndex()
        {
            var policyFees = SegguContainer.Instance.Fees
                .Where(x => x.ExpirationDate == DateTime.Today && x.PolicyId != null)
                .Select(x => new 
                { 
                    FeeNumber = x.Number, 
                    FeeValue = x.Value, 
                    PolicyNumber = x.Policy.Number, 
                    ClientName = x.Policy.Client.FirstName + " " + x.Policy.Client.LastName
                }).ToList();

            var endorseFees = SegguContainer.Instance.Fees
                .Where(x => x.ExpirationDate == DateTime.Today && x.PolicyId == null)
                .Select(x => new
                {
                    FeeNumber = x.Number,
                    FeeValue = x.Value,
                    PolicyNumber = x.Endorse.Policy.Number,
                    ClientName = x.Policy.Client.FirstName + " " + x.Policy.Client.LastName
                }).ToList();

            clientGrid.DataSource = policyFees.Concat(endorseFees).ToList();

            clientGrid.Columns["PolicyNumber"].HeaderText = "Nro Poliza";
            clientGrid.Columns["PolicyNumber"].DisplayIndex = 0;
            clientGrid.Columns["ClientName"].HeaderText = "Cliente";
            clientGrid.Columns["ClientName"].DisplayIndex = 1;
            clientGrid.Columns["FeeNumber"].HeaderText = "Nro Cuota";
            clientGrid.Columns["FeeNumber"].DisplayIndex = 2;
            clientGrid.Columns["FeeValue"].HeaderText = "Valor Cuota";
            clientGrid.Columns["FeeValue"].DisplayIndex = 3;

            clientGrid.Select();
        }

    }
}
