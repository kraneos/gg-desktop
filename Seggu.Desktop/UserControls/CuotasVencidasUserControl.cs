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
        private IFeeService feeService;
        public CuotasVencidasUserControl(IFeeService feeService)
        {
            InitializeComponent();
            this.feeService = feeService;
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
            var policyFees = this.feeService.GetOverduePoliciesToday();

            var endorseFees = this.feeService.GetOverdueEndorsesToday();

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
