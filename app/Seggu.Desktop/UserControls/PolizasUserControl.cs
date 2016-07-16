using Seggu.Desktop.Forms;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{

    public partial class PolizasUserControl : UserControl
    {
        private readonly IPolicyService policyService;
        private readonly IClientService clientService;
        private readonly ICompanyService companyService;
        private readonly IRiskService riskService;
        private readonly IProducerService producerService;
        private readonly IMasterDataService masterDataService;
        private readonly IFeeService feeService;
        private readonly IPrintService printService;
        private IAttachedFileService attachedFileService;
        private ClientIndexDto currentClient;
        private VehiculePolicyUserControl vehicle_uc = null;
        private VidaPolicyUserControl vida_uc = null;
        private IntegralPolicyUserControl integral_uc = null;

        #region Siniestros Vars
        private ICasualtyService casualtyService;
        private ICasualtyTypeService casualtyTypeService;

        private CasualtyDto currentCasualty;
        private List<CasualtyDto> casualties;

        #endregion

        public PolizasUserControl(IPolicyService polServ, IClientService cliServ, ICompanyService compServ,
            IRiskService riskServ, IMasterDataService masterDataServ, IProducerService prodServ,
            IFeeService feeService, IPrintService printService, IAttachedFileService attachedFileService,
            ICasualtyTypeService casualtyTypeService, ICasualtyService casualtyService)
        {
            InitializeComponent();
            this.policyService = polServ;
            this.clientService = cliServ;
            this.companyService = compServ;
            this.riskService = riskServ;
            this.masterDataService = masterDataServ;
            this.producerService = prodServ;
            this.feeService = feeService;
            this.printService = printService;
            this.attachedFileService = attachedFileService;

            this.casualtyService = casualtyService;
            this.casualtyTypeService = casualtyTypeService;

            chkOtherClient.Visible = false;
            InitializeDetailComboBoxes();
        }

        private void InitializeDetailComboBoxes()
        {
            cmbPeriodo.DataSource = masterDataService.GetPeriods().ToList();

            cmbCompania.ValueMember = "Id";
            cmbCompania.DisplayMember = "Name";
            cmbCompania.DataSource = companyService.GetAllCombobox().ToList();

            cmbProductor.ValueMember = "Id";
            cmbProductor.DisplayMember = "Name";

            cmbRiesgo.ValueMember = "Id";
            cmbRiesgo.DisplayMember = "Name";

            cmbCobrador.ValueMember = "Id";
            cmbCobrador.DisplayMember = "Name";
            cmbCobrador.DataSource = producerService.GetCollectors().ToList();

            cmbCompania.SelectedIndex = cmbCompania.Items.Count > 0 ? 0 : -1;

            if (cmbRiesgo.Items.Count > 0)
            {
                cmbRiesgo.SelectedIndex = 0;
            }
        }
        private Layout LayoutForm => (Layout)this.FindForm();

        private void btnNuevaPoliza_Click(object sender, EventArgs e)
        {
            this.NewPolicy();
        }
        private void NewPolicy()
        {
            currentClient = LayoutForm.currentClient;
            EmptyControlsDetalleTab();
            PanelCoverage.Controls.Clear();
            txtAsegurado.Text = currentClient.Nombre + " " + currentClient.Apellido;
            NavigateToDetalle();
            ClearDataBindings();
            LayoutForm.currentPolicy = new PolicyFullDto();
            cmbCompania_SelectionChangeCommitted(null, null);
            cmbRiesgo_SelectionChangeCommitted(null, null);
            grdFees.Rows.Clear();
            cmbPlanes.Enabled = true;
            EnablePage(tabPageSiniestros, false);
            //tctrlPolizasDatos.TabPages[3].Visible = false;
            //tabPageSiniestros.Visible = false;

            //foreach (Control c in tctrlPolizasDatos.TabPages[2].Controls)//tab siniestros
            //{
            //    c.Visible = false;
            //}
        }

        private readonly List<TabPage> hiddenPages = new List<TabPage>();

        private void EnablePage(TabPage page, bool enable)
        {
            if (enable)
            {
                tctrlPolizasDatos.TabPages.Add(page);
                hiddenPages.Remove(page);
            }
            else
            {
                tctrlPolizasDatos.TabPages.Remove(page);
                hiddenPages.Add(page);
            }
        }

        protected void Dispose()
        {
            foreach (var page in hiddenPages) page.Dispose();
        }

        private void EmptyControlsDetalleTab()
        {
            lblAnulada.Visible = false;
            foreach (TabPage tabPage in this.tctrlPolizasDatos.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TextBox)
                        control.Text = string.Empty;
                    //else if (control is ComboBox)
                    //(control as ComboBox).SelectedIndex = -1;
                    else if (control is DataGridView)
                    {
                        (control as DataGridView).DataSource = null;
                        (control as DataGridView).Rows.Clear();
                    }
                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else if (control is DateTimePicker)
                    {
                        (control as DateTimePicker).Value = DateTime.Today;
                        (control as DateTimePicker).Checked = false;
                    }
                    else if (control is GroupBox)
                    {
                        foreach (Control groupBoxControl in control.Controls)
                        {
                            if (groupBoxControl is TextBox)
                                groupBoxControl.Text = string.Empty;
                            else if (groupBoxControl is ComboBox)
                                (groupBoxControl as ComboBox).SelectedIndex = -1;
                            else if (groupBoxControl is CheckBox)
                                (groupBoxControl as CheckBox).Checked = false;
                            else if (groupBoxControl is DateTimePicker)
                            {
                                (groupBoxControl as DateTimePicker).Value = DateTime.Today;
                                (groupBoxControl as DateTimePicker).Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            this.RenovatePolicy();
        }
        public void RenovatePolicy()
        {
            var cp = LayoutForm.currentPolicy;
            if (!string.IsNullOrWhiteSpace(cp.Número))
            {
                //selectedCompany = companyService.GetFullById(LayoutForm.currentPolicy.CompanyId);
                cp.Id = default(int);
                cp.PreviousNumber = cp.Número;
                cp.Número = "";
                cp.StartDate = DateTime.Today.ToShortDateString();
                cp.Vence = DateTime.Today.ToShortDateString();
                cp.Period = PeriodDtoMapper.ToString(Period.Anual);
                if (cp.Vehicles != null)
                {
                    var vehicles = cp.Vehicles.ToList();
                    foreach (var vehicle in vehicles)
                    {
                        //vehicle.Id = null;
                        //vehicle.PolicyId = null;
                    }
                    cp.Vehicles = vehicles;
                }
                else if (cp.Employees != null)
                {
                    var employees = cp.Employees.ToList();
                    foreach (var employee in employees)
                    {
                        //employee.Id = null;
                        //employee.PolicyId = null;
                    }
                    cp.Employees = employees;
                }
                else if (cp.Integrals != null)
                {
                    var integrals = cp.Integrals.ToList();
                    foreach (var integral in integrals)
                    {
                        //integral.Id = null;
                        //integral.PolicyId = null;
                    }
                    cp.Integrals = integrals;
                }
                cp.IsRenovated = true;
                cp.IsRemoved = false;
                cp.IsAnnulled = false;
                cp.Notes = "";
                //cp.Premium = 0;
                cp.RequestDate = DateTime.Today.ToShortDateString();
                dtpRecibido.Checked = false;
                dtpEmision.Checked = false;
                chkOtherClient.Visible = true;
                PopulateDetails();
                CalculateNetoCobrar();
                //tctrlPolizasDatos.TabPages[3].Visible = false;
                //tabPageSiniestros.Visible = false;
                //foreach (Control c in tctrlPolizasDatos.TabPages[2].Controls)
                //{
                //    c.Visible = false;
                //}
            }
            else
            {
                MessageBox.Show("La póliza debe tener un número asignado para ser renovada.");
            }
        }

        public void PopulateDetails()
        {
            currentClient = LayoutForm.currentClient;

            NavigateToDetalle();
            cmbProductor.DataSource = this.producerService.GetByCompanyIdCombobox(LayoutForm.currentPolicy.CompanyId).ToList();// selectedCompany.Producers;
            cmbRiesgo.DataSource = this.riskService.GetByCompanyCombobox(LayoutForm.currentPolicy.CompanyId).ToList();// selectedCompany.Risks;
            BindTextBoxesAndCombos(LayoutForm.currentPolicy);
            LoadFeeGrid();
            //LoadAttachedFilesGrid();
        }
        private void NavigateToDetalle()
        {
            this.tctrlPolizasDatos.SelectedIndex = 0;
            this.tctrlPolizasDatos.Enabled = true;
            this.btnGrabar.Enabled = true;
        }
        private void BindTextBoxesAndCombos(PolicyFullDto policy)
        {
            ClearDataBindings();
            //txtBonificacionPago;
            lblAnulada.DataBindings.Add("Visible", policy, "IsAnnulled");
            cmbCompania.DataBindings.Add("SelectedValue", policy, "CompanyId");
            cmbProductor.DataBindings.Add("SelectedValue", policy, "ProducerId");
            cmbRiesgo.DataBindings.Add("SelectedValue", policy, "RiskId");
            cmbCobrador.DataBindings.Add("SelectedValue", policy, "CollectorId");

            txtAsegurado.DataBindings.Add("Text", policy, "Asegurado");
            //txtBonificacionPropia.DataBindings.Add("Text", policy, "Bonus");
            txtBonificacionPropia.Text = policy.Bonus.ToString();
            txtNroPolAnt.DataBindings.Add("Text", policy, "PreviousNumber");
            txtNroPoliza.DataBindings.Add("Text", policy, "Número");
            txtPrima.DataBindings.Add("Text", policy, "Prima");
            //txtRecargoPropio.DataBindings.Add("Text", policy, "Surcharge");
            txtRecargoPropio.Text = policy.Surcharge.ToString();
            txtBonificacionPago.Text = policy.PaymentBonus.ToString();
            //txtPaymentDay.DataBindings.Add("Text", policy, "PaymentDay");
            txtPaymentDay.Text = policy.PaymentDay.ToString();
            txtSumaAsegurado.DataBindings.Add("Text", policy, "Value");
            txtPremioIva.DataBindings.Add("Text", policy, "Premium");
            txtNotas.DataBindings.Add("Text", policy, "Notes");

            dtpInicio.DataBindings.Add("Value", policy, "StartDate");
            //   txtNetoCobrar.Text = policy.NetCharge.ToString();
            dtpFin.Value = DateTime.Parse(policy.Vence);
            cmbPeriodo.SelectedItem = LayoutForm.currentPolicy.Period;

            dtpSolicitud.Value = DateTime.Parse(policy.RequestDate);
            dtpRecibido.Value = DateTime.Parse(policy.ReceptionDate);
            if (policy.ReceptionDate == "01/01/1753")
                dtpRecibido.Checked = false;
            dtpEmision.Value = DateTime.Parse(policy.EmissionDate);
            if (policy.EmissionDate == "01/01/1753")
                dtpEmision.Checked = false;
        }
        private void ClearDataBindings()
        {
            lblAnulada.DataBindings.Clear();
            cmbProductor.DataBindings.Clear();
            cmbRiesgo.DataBindings.Clear();
            cmbCompania.DataBindings.Clear();
            cmbCobrador.DataBindings.Clear();

            txtAsegurado.DataBindings.Clear();
            txtBonificacionPropia.DataBindings.Clear();
            txtNroPolAnt.DataBindings.Clear();
            txtNroPoliza.DataBindings.Clear();
            txtPrima.DataBindings.Clear();
            txtRecargoPropio.DataBindings.Clear();
            txtSumaAsegurado.DataBindings.Clear();
            txtPremioIva.DataBindings.Clear();
            txtNotas.DataBindings.Clear();

            dtpSolicitud.DataBindings.Clear();
            dtpInicio.DataBindings.Clear();
        }
        private void LoadFeeGrid()
        {
            grdFees.Columns.Clear();
            var fees = LayoutForm.currentPolicy.Id == default(int) ?
                null : feeService.GetByPolicyId(LayoutForm.currentPolicy.Id).ToList();
            grdFees.DataSource = fees;
            cmbPlanes.SelectedIndex = grdFees.RowCount > 12 ? -1 : grdFees.RowCount - 1;
            if (grdFees.RowCount != 0)
            {
                cmbPlanes.Enabled = false;
                FormatFeeGrid();
                CalculateFeeTotals();
            }
            else
                cmbPlanes.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var pol = LayoutForm.currentPolicy;

            var risk = (RiskItemDto)cmbRiesgo.SelectedItem;
            var riesgo = risk.RiskType;

            switch (riesgo)
            {
                case RiskType.Automotores:
                    if (pol.Vehicles.Count() > 1)
                    {
                        //print flota
                    }
                    else
                        printService.PolicyVehiclePDF(pol, vehicle_uc.GetSelectedPlate());
                    break;

                case RiskType.Vida_colectivo_Otros:
                    printService.PolicyLifePDF(pol);
                    break;

                case RiskType.Vida_individual:
                    printService.PolicyLifePDF(pol);
                    break;

                case RiskType.Combinados_Integrales:
                    printService.PolicyIntegralPDF(pol);
                    break;
            }
        }
        #region Datos grales Tab

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpSolicitud.Value = dtpInicio.Value;
            if (cmbPeriodo.SelectedIndex != -1)
                CalculatePolicyEnd();
        }
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex == -1) return;
            CalculatePolicyEnd();
        }
        private void cmbPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalculatePolicyEnd();
        }
        private void CalculatePolicyEnd()
        {
            switch (cmbPeriodo.SelectedIndex)
            {
                case 0:
                    dtpFin.Value = dtpInicio.Value.AddMonths(1);
                    break;
                case 1:
                    dtpFin.Value = dtpInicio.Value.AddMonths(2);
                    break;
                case 2:
                    dtpFin.Value = dtpInicio.Value.AddMonths(3);
                    break;
                case 3:
                    dtpFin.Value = dtpInicio.Value.AddMonths(4);
                    break;
                case 4:
                    dtpFin.Value = dtpInicio.Value.AddMonths(6);
                    break;
                case 5:
                    dtpFin.Value = dtpInicio.Value.AddMonths(12);
                    break;
            }
        }

        private void cmbCompania_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbCompania.SelectedValue != null)
            {
                var companyId = (int)cmbCompania.SelectedValue;
                //selectedCompany = companyService.GetFullById(CompanyId);
                cmbRiesgo.DataSource = this.riskService.GetByCompanyCombobox(companyId).ToList();// selectedCompany.Risks;
                cmbProductor.DataSource = this.producerService.GetByCompanyIdCombobox(companyId).ToList();// selectedCompany.Producers;
                cmbCobrador.SelectedIndex = 0;
            }
        }

        private void cmbRiesgo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillInsuredObjectUserControl();
        }
        private void cmbRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LayoutForm.currentPolicy != null)
            {
                if (LayoutForm.currentPolicy.RiskId != (int)cmbRiesgo.SelectedValue) return;
                FillInsuredObjectUserControl();
            }
        }
        private void FillInsuredObjectUserControl()
        {
            integral_uc = null;
            vehicle_uc = null;
            vida_uc = null;

            var risk = (RiskItemDto)cmbRiesgo.SelectedItem;
            var riskType = risk.RiskType;
            if (riskType == RiskType.Automotores)
            {
                vehicle_uc = (VehiculePolicyUserControl)DependencyResolver.Instance.Resolve(typeof(VehiculePolicyUserControl));
                SetCoberturasTab(vehicle_uc);
                vehicle_uc.InitializeComboboxes((int)cmbRiesgo.SelectedValue);
                if (LayoutForm.currentPolicy != null)
                    vehicle_uc.PopulatePolicyVehicle();
            }
            else if (riskType == RiskType.Vida_colectivo_Otros || riskType == RiskType.Vida_individual || riskType == RiskType.Otros)
            {
                vida_uc = (VidaPolicyUserControl)DependencyResolver.Instance.Resolve(typeof(VidaPolicyUserControl));
                SetCoberturasTab(vida_uc);
                if (LayoutForm.currentPolicy != null)
                    vida_uc.InitializeIndex((int)this.cmbRiesgo.SelectedValue);
            }
            else
            {
                integral_uc = (IntegralPolicyUserControl)DependencyResolver.Instance.Resolve(typeof(IntegralPolicyUserControl));
                SetCoberturasTab(integral_uc);
                integral_uc.InitializeComboboxes((int)this.cmbRiesgo.SelectedValue);
                if (LayoutForm.currentPolicy != null)
                    integral_uc.PopulatePolicyIntegral();
            }
        }
        private void SetCoberturasTab(UserControl uc)
        {
            PanelCoverage.Controls.Clear();
            PanelCoverage.Controls.Add(uc);
        }

        private void cmbClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtAsegurado.Text = cmbClient.SelectedText;
            LayoutForm.currentPolicy.ClientId = (int)cmbClient.SelectedValue;
        }
        private void chkOtherClient_CheckedChanged(object sender, EventArgs e)
        {
            cmbClient.ValueMember = "Id";
            cmbClient.DisplayMember = "FullName";
            cmbClient.DataSource = clientService.GetAll().ToList();
            if (chkOtherClient.Checked)
                cmbClient.Visible = true;
            else
                cmbClient.Visible = false;

        }
        #endregion

        #region Sumas y Planes de pago Tab

        private void cmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanes.SelectedIndex != -1 && txtNetoCobrar.Text != string.Empty && txtNetoCobrar.Text != "0")
            {
                GenerarPlanDeCobro();
            }
        }
        private void GenerarPlanDeCobro()
        {
            int cuotas;
            decimal[] importesCobrar;
            decimal[] importesPagar;
            var neto = 0M;

            if (decimal.TryParse(this.txtNetoCobrar.Text, out neto))
            {
                if (neto > 0)
                {
                    DivideValueInFees(out cuotas, out importesCobrar, out importesPagar);
                    this.grdFees.DataSource = CreateFeeObjectsList(cuotas, importesCobrar, importesPagar);
                    FormatFeeGrid();
                    CalculateFeeTotals();
                }
                else
                {
                    MessageBox.Show("El valor neto a cobrar debe ser mayor a 0.");
                }
            }
        }
        private void DivideValueInFees(out int cuotas, out decimal[] importesCobrar, out decimal[] importesPagar)
        {
            ////////////dividir el importe total en cuotas////////////////////////
            cuotas = cmbPlanes.SelectedIndex + 1;
            decimal netoCobrar = decimal.Parse(txtNetoCobrar.Text);
            importesCobrar = new decimal[cuotas];
            //decimal resto = netoCobrar % cuotas;
            //netoCobrar -= resto;
            for (int i = 0; i < cuotas; i++)
            {
                importesCobrar[i] = Math.Round(netoCobrar / (decimal)cuotas, 2);
            }

            if (importesCobrar.Sum() != netoCobrar)
            {
                var resto = netoCobrar - importesCobrar.Sum();
                importesCobrar[importesCobrar.Length - 1] += resto;
            }
            //importesCobrar[cuotas - 1] += resto;

            ////////////dividir el importe total en cuotas////////////////////////
            decimal netoPagar = decimal.Parse(txtNetoPagar.Text);
            importesPagar = new decimal[cuotas];
            //decimal resto2 = netoPagar % cuotas;
            //netoPagar -= resto2;
            for (int i = 0; i < cuotas; i++)
            {
                importesPagar[i] = Math.Round(netoPagar / (decimal)cuotas, 2);
            }

            if (importesPagar.Sum() != netoPagar)
            {
                var resto = netoPagar - importesPagar.Sum();
                importesPagar[importesPagar.Length - 1] += resto;
            }
            //importesPagar[cuotas - 1] += resto2;
        }
        private List<FeeDto> CreateFeeObjectsList(int cuotas, decimal[] importesCobrar, decimal[] importesPagar)
        {
            int payDay = string.IsNullOrEmpty(txtPaymentDay.Text) ? DateTime.Now.Day : int.Parse(txtPaymentDay.Text);
            DateTime payDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, payDay);
            List<FeeDto> fees = new List<FeeDto>();
            for (int f = 0; f < cuotas; f++)
            {
                FeeDto fee = new FeeDto();
                fee.Cuota = (f + 1).ToString();
                fee.Venc_Cuota = payDate.AddMonths(f);
                fee.Valor = importesCobrar[f];
                fee.Annulated = false;
                fee.Estado = "Debe";
                fee.Pago_Cía = importesPagar[f];
                fee.Saldo = fee.Valor;
                fees.Add(fee);
            }
            return fees;
        }
        private void FormatFeeGrid()
        {
            grdFees.Columns["Id"].Visible = false;
            grdFees.Columns["FeeSelectionId"].Visible = false;
            grdFees.Columns["PolicyId"].Visible = false;
            grdFees.Columns["Annulated"].Visible = false;
            grdFees.Columns["CompanyId"].Visible = false;
            grdFees.Columns["Cliente"].Visible = false;
            grdFees.Columns["EndorseId"].Visible = false;
            grdFees.Columns["Nro_Póliza"].Visible = false;
            grdFees.Columns["Valor"].DefaultCellStyle.Format = "0.00";
            grdFees.Columns["Saldo"].DefaultCellStyle.Format = "0.00";
            grdFees.Columns["Pago_Cía"].DefaultCellStyle.Format = "0.00";
            grdFees.Columns["Venc_Cuota"].HeaderText = "Vencimiento";
            grdFees.Columns["Venc_Cuota"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void CalculateFeeTotals()
        {
            decimal totcobrar = 0M;
            decimal totpagar = 0M;
            var totsaldo = 0M;
            foreach (DataGridViewRow row in grdFees.Rows)
            {
                totcobrar += decimal.Parse(row.Cells["Saldo"].Value.ToString());
                totpagar += decimal.Parse(row.Cells["Pago_Cía"].Value.ToString());
                totsaldo += decimal.Parse(row.Cells["Saldo"].Value.ToString());
            }
            txtTotalCobrar.Text = totcobrar.ToString("F");
            txtTotalPagar.Text = totpagar.ToString("F");
            txtTotalSaldo.Text = totsaldo.ToString("F");
        }


        private void txtPremioIva_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPremioIva.Text)) return;
            CalculateNetoCobrar();
            CalcularNetoPagar();
            txtIva.Text = (double.Parse(txtPremioIva.Text) * (0.21)).ToString();
            txtPrima.Text = (double.Parse(txtPremioIva.Text) * (0.79)).ToString();
        }
        private void CalcularNetoPagar()
        {
            var d = 0M;
            if (
                decimal.TryParse(txtPremioIva.Text, out d) &&
                decimal.TryParse(txtBonificacionPago.Text, out d))
            {
                decimal premioConIva = txtPremioIva.Text == string.Empty ? 0 : decimal.Parse(txtPremioIva.Text);
                decimal bonificacionPagaCia = txtBonificacionPago.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPago.Text);
                decimal netoPagar = premioConIva - bonificacionPagaCia;
                txtNetoPagar.Text = netoPagar.ToString();
            }
        }
        private void txtBonificacionPropia_TextChanged(object sender, EventArgs e)
        {
            CalculateNetoCobrar();
        }
        private void txtBonificacionPago_TextChanged(object sender, EventArgs e)
        {
            CalculateNetoCobrar();
            CalcularNetoPagar();

        }
        private void txtRecargoPropio_TextChanged(object sender, EventArgs e)
        {
            CalculateNetoCobrar();
        }
        private void CalculateNetoCobrar()
        {
            var d = 0M;
            if (
                decimal.TryParse(txtRecargoPropio.Text, out d) &&
                decimal.TryParse(txtBonificacionPropia.Text, out d) &&
                decimal.TryParse(txtBonificacionPago.Text, out d) &&
                decimal.TryParse(txtPremioIva.Text, out d))
            {
                decimal recargoPropio = txtRecargoPropio.Text == string.Empty ? 0 : decimal.Parse(txtRecargoPropio.Text);
                decimal bonificacionPropia = txtBonificacionPropia.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPropia.Text);
                decimal bonificacionPagar = txtBonificacionPago.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPago.Text);
                decimal premioConIva = txtPremioIva.Text == string.Empty ? 0 : decimal.Parse(txtPremioIva.Text);
                decimal netoCobrar = premioConIva - bonificacionPagar - bonificacionPropia + recargoPropio;
                txtNetoCobrar.Text = netoCobrar.ToString();
            }
        }


        private void rdbIguales_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbIguales.Checked == true)
            {
                lblPlanAsegurado.Visible = false;
                lblPlanCia.Visible = false;
                cmbPlanAsegurado.Visible = false;
                cmbPlanCia.Visible = false;
                cmbPlanes.Visible = true;
            }
        }

        private void rdbDistintos_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDistintos.Checked == true)
            {
                lblPlanAsegurado.Visible = true;
                lblPlanCia.Visible = true;
                cmbPlanAsegurado.Visible = true;
                cmbPlanCia.Visible = true;
                cmbPlanes.Visible = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidateControls() && this.ValidateChildren())
            {
                try
                {
                    var policy = GetFormInfo();
                    policy.Fees = (List<FeeDto>)this.grdFees.DataSource;

                    if (vida_uc != null)
                        policy.Employees = vida_uc.GetEmployees();
                    else if (vehicle_uc != null && vehicle_uc.ValidateControls() && vehicle_uc.ValidateFlota())
                        policy.Vehicles = vehicle_uc.vehicleList;
                    else if (integral_uc != null && integral_uc.ValidateControls())
                        policy.Integrals = integral_uc.GetIntegral();
                    else
                        return;
                    policyService.SavePolicy(policy);

                    MessageBox.Show("La poliza se ha guardado con exito.");
                    //limpiar layout
                    var mainForm = (Layout)this.FindForm();
                    mainForm.CleanLeftPanel();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        @"Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo tecnico.
" +
                        ex.Message + "\n" + ex.StackTrace + (ex.InnerException == null ? string.Empty : "\nInner Exception: " +
                        ex.InnerException.Message + "\nStackTrace: " +
                        ex.InnerException.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Datos obligatorios sin completar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidateControls()
        {
            var ok = true;
            errorProvider1.Clear();
            foreach (TabPage tabPage in this.tctrlPolizasDatos.TabPages)
            {
                foreach (Control c in tabPage.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c == txtAsegurado || c == txtPremioIva || c == txtSumaAsegurado || c == txtRecargoPropio || c == txtBonificacionPropia || c == txtBonificacionPago)
                        {
                            if (c.Text == string.Empty)
                            {
                                errorProvider1.SetError(c, "Campo vacio");
                                ok = false;
                            }
                            else if (c == txtPremioIva || c == txtSumaAsegurado)
                            {
                                var x = 0M;

                                if (decimal.TryParse(c.Text, out x))
                                {
                                    if (x <= 0)
                                    {
                                        errorProvider1.SetError(c, "El valor debe ser mayor a 0.");
                                        ok = false;
                                    }
                                }
                            }
                        }

                        /*if (c == txtPaymentDay)
                        {
                            if (c.Text == string.Empty)
                            {
                                errorProvider1.SetError(c, "Campo vacio");
                                ok = false;
                            }
                            else
                            {
                                int input = 0;
                                bool isNum = Int32.TryParse(c.Text, out input);

                                if (!isNum || input < 1 || input > 28)
                                {
                                    // Cancel the event and select the text to be corrected by the user.
                                    //e.Cancel = true;
                                    //txtPaymentDay.Select(0, txtPaymentDay.Text.Length);
                                    errorProvider1.SetError(c, "El dia de debe ser mayor a 0 y menor o igual a 28");
                                    ok = false;
                                }
                            }

                        }*/
                    }
                    if (c is ComboBox)
                        if (c == cmbCompania || c == cmbRiesgo || c == cmbPeriodo || c == cmbProductor || c == cmbCobrador)
                            if ((c as ComboBox).SelectedIndex == -1)
                            {
                                errorProvider1.SetError(c, "Debe seleccionar un elemento");
                                ok = false;
                            }
                }
            }
            return ok && this.ValidateChildren();
        }
        private PolicyFullDto GetFormInfo()
        {
            PolicyFullDto policy = new PolicyFullDto();
            policy.Id = LayoutForm.currentPolicy == null ? default(int) : LayoutForm.currentPolicy.Id;
            policy.AnnulationDate = null;
            policy.Bonus = txtBonificacionPropia.Text == "" ? 0 : decimal.Parse(txtBonificacionPropia.Text);
            policy.ClientId = chkOtherClient.Checked ? ((ClientIndexDto)this.cmbClient.SelectedItem).Id : LayoutForm.currentClient.Id;
            policy.CollectorId = (int)cmbCobrador.SelectedValue;
            policy.EmissionDate = dtpEmision.Checked ? dtpEmision.Value.ToShortDateString() : null;
            policy.Vence = dtpFin.Value.ToShortDateString();
            policy.IsAnnulled = LayoutForm.currentPolicy.IsAnnulled;
            policy.IsRemoved = LayoutForm.currentPolicy.IsRemoved;
            policy.IsRenovated = LayoutForm.currentPolicy.IsRenovated;
            policy.Notes = txtNotas.Text;
            policy.Número = txtNroPoliza.Text;
            policy.Period = (string)cmbPeriodo.SelectedValue;
            policy.Premium = txtPremioIva.Text == "" ? 0 : decimal.Parse(txtPremioIva.Text);
            policy.PreviousNumber = txtNroPolAnt.Text;
            policy.Prima = txtPrima.Text == "" ? 0 : decimal.Parse(txtPrima.Text);
            policy.ProducerId = (int)cmbProductor.SelectedValue;
            policy.ReceptionDate = dtpRecibido.Checked ? dtpRecibido.Value.ToShortDateString() : null;
            policy.RequestDate = dtpSolicitud.Value.ToShortDateString();
            policy.RiskId = (int)cmbRiesgo.SelectedValue;

            policy.StartDate = dtpInicio.Value.ToShortDateString();
            policy.Surcharge = txtRecargoPropio.Text == "" ? 0 : decimal.Parse(txtRecargoPropio.Text);
            policy.Value = txtSumaAsegurado.Text == "" ? 0 : decimal.Parse(txtSumaAsegurado.Text);
            policy.PaymentDay = int.Parse(txtPaymentDay.Text);
            policy.PaymentBonus = txtBonificacionPago.Text == string.Empty ? null : (decimal?)decimal.Parse(txtBonificacionPago.Text);
            policy.NetCharge = txtNetoCobrar.Text == string.Empty ? null : (decimal?)decimal.Parse(txtNetoCobrar.Text);
            return policy;
        }
        #endregion

        #region Siniestros Tab

        private void tctrlPolizasDatos_Selected(object sender, TabControlEventArgs e)
        {
            if (tctrlPolizasDatos.SelectedTab.Text == "Siniestros")
                LoadSiniestrosTab();
        }

        private void LoadSiniestrosTab()
        {
            if (LayoutForm.currentPolicy.Casualties == null) return;
            //casualties = casualtyService.GetByPolicyId(LayoutForm.currentPolicy.Id).OrderByDescending(x => x.Number).ToList();
            casualties = LayoutForm.currentPolicy.Casualties;
            InitializeSiniestrosComboboxes();

            if (casualties.Count == 0)
                NewCasualty();
            else
                btnNuevoSiniestro.Enabled = true;
        }
        private void InitializeSiniestrosComboboxes()
        {
            cmbType.ValueMember = "Id";
            cmbType.DisplayMember = "Name";
            cmbType.DataSource = casualtyTypeService.GetAll().ToList();

            cmbNumber.DataSource = null;
            cmbNumber.ValueMember = "Id";
            cmbNumber.DisplayMember = "Number";
            cmbNumber.DataSource = casualties;
            cmbNumber.SelectedIndex = cmbNumber.Items.Count - 1;
        }

        private void cmbNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNumber.SelectedItem == null) return;
            currentCasualty = (CasualtyDto)cmbNumber.SelectedItem;
            ClearSiniestrosDataBindings();
            BindControls();
        }
        private void ClearSiniestrosDataBindings()
        {
            txtDescripcionSiniestro.DataBindings.Clear();
            txtIndemnizacionDef.DataBindings.Clear();
            txtIndemnizacionEst.DataBindings.Clear();
            chkbNuestroCargo.DataBindings.Clear();
            cmbType.DataBindings.Clear();
            dtpDenunciaPolicial.DataBindings.Clear();
            dtpOcurrio.DataBindings.Clear();
            dtpRecibido.DataBindings.Clear();
        }
        private void BindControls()
        {
            txtDescripcionSiniestro.DataBindings.Add("Text", currentCasualty, "Notes");
            txtIndemnizacionDef.DataBindings.Add("Text", currentCasualty, "DefinedCompensation");
            txtIndemnizacionEst.DataBindings.Add("Text", currentCasualty, "EstimatedCompensation");
            #region Faltan esos campos en la BD
            //txtAbogados.DataBindings.Add();
            //txtActa.DataBindings.Add();
            //txtComisaria.DataBindings.Add();
            //txtConductor.DataBindings.Add();
            //txtDanios.DataBindings.Add();
            //txtDatos.DataBindings.Add();
            //txtDomicilio.DataBindings.Add("Text", currentCasualty, "bla");
            //txtJuzgado.DataBindings.Add();
            //txtPatente.DataBindings.Add();
            //txtPoliza.DataBindings.Add();
            //txtProximaGestion.DataBindings.Add();
            //txtRegistro.DataBindings.Add();
            //txtSecretaria.DataBindings.Add();
            //txtTelefono.DataBindings.Add();
            //txtTitular.DataBindings.Add();
            //txtVehiculo.DataBindings.Add();

            //cmbCompania.DataBindings.Add("SelectedValue", currentCasualty, "")
            //dtpDenunciaCia.DataBindings.Add("Value", currentCasualty, "")
            //dtpDesestimamiento.DataBindings.Add("Value", currentCasualty, "");
            //dtpFechaPagoDef.DataBindings.Add();
            //dtpFechaPagoEst.DataBindings.Add("Value", currentCasualty, ")
            //dtpInicioDemanda.DataBindings.Add();
            //dtpInspeccion.DataBindings.Add();
            //dtpProximaGestion.DataBindings.Add();
            //dtpRechazoCia.DataBindings.Add();
            #endregion
            chkbNuestroCargo.DataBindings.Add("Checked", currentCasualty, "OurCharge");
            cmbType.DataBindings.Add("SelectedValue", currentCasualty, "CasualtyTypeId");
            dtpDenunciaPolicial.DataBindings.Add("Value", currentCasualty, "PoliceReportDate");
            dtpOcurrio.DataBindings.Add("Value", currentCasualty, "OccurredDate");
            dtpRecibido.DataBindings.Add("Value", currentCasualty, "ReceiveDate");
        }

        private void btnGrabarSiniestro_Click(object sender, EventArgs e)
        {
            if (ValidateSiniestrosControls())
            {
                try
                {
                    CasualtyDto casualty = GetSiniestroInfo();
                    //var injuries = (List<FeeDto>)this.grdInjuries.DataSource;
                    //CasualtyDto submitCasualtyFormDto = this.ConvertToSubmitForm(casualty, injuries);
                    casualtyService.Save(casualty);
                    MessageBox.Show("Guardó OK, refresque los datos con doble click en la póliza deseada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo tecnico.\n" +
                        ex.Message +
                        "\n" +
                        ex.StackTrace +
                        (ex.InnerException == null ? string.Empty : "\nInner Exception: " +
                        ex.InnerException.Message +
                        "\nStackTrace: " +
                        ex.InnerException.StackTrace),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Datos obligatorios sin completar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private CasualtyDto GetSiniestroInfo()
        {
            currentCasualty.CasualtyTypeId = (int)cmbType.SelectedValue;
            currentCasualty.DefinedCompensation = decimal.Parse(txtIndemnizacionDef.Text);
            currentCasualty.EstimatedCompensation = decimal.Parse(txtIndemnizacionEst.Text);
            currentCasualty.Notes = txtDescripcionSiniestro.Text;
            //currentCasualty.Number = ;
            currentCasualty.OccurredDate = dtpOcurrio.Value.ToShortDateString();
            currentCasualty.OurCharge = chkbNuestroCargo.Checked;
            currentCasualty.PoliceReportDate = dtpDenunciaPolicial.Value.ToShortDateString();
            currentCasualty.PolicyId = LayoutForm.currentPolicy.Id;
            currentCasualty.ReceiveDate = dtpRecibido.Value.ToShortDateString();
            return currentCasualty;
        }
        private bool ValidateSiniestrosControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (TabPage tabPage in this.tctrlSiniestrosDatos.TabPages)
            {
                foreach (Control c in tabPage.Controls)
                {
                    if (c == txtDescripcionSiniestro)
                    {
                        if (c.Text == string.Empty)
                        {
                            errorProvider1.SetError(c, "Campo vacío");
                            ok = false;
                        }
                    }

                    else if (c is ComboBox)
                    {
                        if (c == cmbType)
                        {
                            if ((c as ComboBox).SelectedIndex == -1)
                            {
                                errorProvider1.SetError(c, "Debe seleccionar un elemento");
                                ok = false;
                            }
                        }
                    }
                    else if (c is GroupBox)
                    {
                        foreach (Control groupBoxControl in c.Controls)
                        {
                            if (groupBoxControl is TextBox)
                            {
                                if (groupBoxControl == txtIndemnizacionEst || groupBoxControl == txtIndemnizacionDef)
                                {
                                    if (groupBoxControl.Text == string.Empty)
                                    {
                                        errorProvider1.SetError(groupBoxControl, "Campo vacío");
                                        ok = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ok;
        }

        private void btnNuevoSiniestro_Click(object sender, EventArgs e)
        {
            NewCasualty();
        }
        private void NewCasualty()
        {
            EmptyControlsSiniestrosTab();

            cmbNumber.Visible = false;

            ClearSiniestrosDataBindings();
            int casualtiesCount = cmbNumber.Items.Count;
            lblNumber.Text = (casualtiesCount + 1).ToString();

            currentCasualty = new CasualtyDto();
            currentCasualty.Number = (casualtiesCount + 1).ToString();
            currentCasualty.OccurredDate = DateTime.Today.ToShortDateString();
            currentCasualty.PoliceReportDate = DateTime.Today.ToShortDateString();
            currentCasualty.ReceiveDate = DateTime.Today.ToShortDateString();

            btnNuevoSiniestro.Enabled = false;
        }
        private void EmptyControlsSiniestrosTab()
        {
            foreach (TabPage tabPage in tctrlSiniestrosDatos.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TextBox)
                        control.Text = string.Empty;
                    //else if (control is ComboBox)
                    //(control as ComboBox).SelectedIndex = -1;

                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else if (control is DateTimePicker)
                    {
                        (control as DateTimePicker).Value = DateTime.Today;
                        (control as DateTimePicker).Checked = false;
                    }
                    else if (control is GroupBox)
                    {
                        foreach (Control groupBoxControl in control.Controls)
                        {
                            if (groupBoxControl is TextBox)
                                groupBoxControl.Text = string.Empty;
                            else if (groupBoxControl is ComboBox)
                                (groupBoxControl as ComboBox).SelectedIndex = -1;
                            else if (groupBoxControl is CheckBox)
                                (groupBoxControl as CheckBox).Checked = false;
                            else if (groupBoxControl is DateTimePicker)
                            {
                                (groupBoxControl as DateTimePicker).Value = DateTime.Today;
                                (groupBoxControl as DateTimePicker).Checked = false;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Files Tab
        //private void LoadAttachedFilesGrid()
        //{
        //    grdFiles.Columns.Clear();
        //    var files = string.IsNullOrEmpty(LayoutForm.currentPolicy.Id) ?
        //        null : attachedFileService.GetByPolicyId(LayoutForm.currentPolicy.Id).ToList();
        //    grdFiles.DataSource = files;
        //    if(grdFiles.RowCount !=0)
        //        FormatFilesGrid();
        //}
        //    private void FormatFilesGrid()
        //    {
        //        grdFiles.Columns["CasualtyId"].Visible = false;
        //        grdFiles.Columns["Id"].Visible = false;
        //        grdFiles.Columns["CashAccountId"].Visible = false;
        //        grdFiles.Columns["EndorseId"].Visible = false;
        //        grdFiles.Columns["PolicyId"].Visible = false;
        //        grdFiles.Columns["FilePath"].HeaderText = "Ruta del Archivo";

        //    }
        private void tabPageFiles_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void grdFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    // Code to read the contents of the text file
                    if (File.Exists(fileLoc))
                    {
                        using (TextReader tr = new StreamReader(fileLoc))
                        {
                            MessageBox.Show(tr.ReadToEnd());
                        }
                    }

                }
            }
        }
        //private void grdFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string path = grdFiles.SelectedCells[0].Value.ToString();
        //    System.Diagnostics.Process.Start(path);

        //}

        //private void btnLoadFilePath_Click(object sender, EventArgs e)
        //{
        //    string policyId = LayoutForm.currentPolicy.Id;
        //    DialogResult result = openFileDialog1.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        string filePath = openFileDialog1.FileName;
        //        try
        //        {
        //            var attachedFile = new AttachedFileDto();
        //            attachedFile.PolicyId = LayoutForm.currentPolicy.Id;
        //            attachedFile.FilePath = filePath;

        //            var files = string.IsNullOrEmpty(LayoutForm.currentPolicy.Id) ?
        //                null : attachedFileService.GetByPolicyId(policyId).ToList();
        //            files.Add(attachedFile);
        //            attachedFileService.Save(files);
        //            files = attachedFileService.GetByPolicyId(policyId).ToList();
        //            grdFiles.DataSource = files;
        //            FormatFilesGrid();

        //        }
        //        catch (IOException)
        //        {
        //        }
        //}
        //}
        #endregion

        #region Validaciones
        public void ValidarNumeros(TextBox sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (c == 46 && sender.Text.IndexOf(decimalSeparator) != -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }
        }

        private void txtAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtSumaAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtPremioIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtBonificacionPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtBonificacionPropia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtRecargoPropio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtPaymentDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int input = 0;
            bool isNum = Int32.TryParse(txtPaymentDay.Text, out input);

            if (!isNum || input < 1 || input > 28)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPaymentDay.Select(0, txtPaymentDay.Text.Length);
                errorProvider1.SetError(this.txtPaymentDay, "El dia de debe ser mayor a 0 y menor o igual a 28");
            }
        }
        private void txtPaymentDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtNetoCobrar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var netoCobrar = 0M;

            if (decimal.TryParse(this.txtNetoCobrar.Text, out netoCobrar))
            {
                if (netoCobrar <= 0)
                {
                    errorProvider1.SetError(this.txtNetoCobrar, "El valor neto a cobrar debe ser mayor a 0.");
                    //e.Cancel = true;
                }
            }
            else
            {
                errorProvider1.SetError(this.txtNetoCobrar, "El valor neto a cobrar debe ser un numero valido.");
                //e.Cancel = true;
            }
        }
        private void txtPaymentDay_Validated(object sender, EventArgs e)
        {
            var val = 0;
            if (int.TryParse(txtPaymentDay.Text, out val))
            {
                if (val > 0 && val < 29)
                {
                    var fees = (List<FeeDto>)this.grdFees.DataSource;
                    if (fees != null)
                    {
                        foreach (var fee in fees)
                        {
                            if (fee.Estado == "Debe")
                            {
                                fee.Venc_Cuota = new DateTime(fee.Venc_Cuota.Year, fee.Venc_Cuota.Month, val);
                            }
                        }
                        this.grdFees.DataSource = fees;
                        this.grdFees.Invalidate();
                    }
                }
            }
        }

        #endregion

        private void AgregarFoto(object sender, EventArgs e)
        {
            this.folderBrowserFotos.Reset();
            //var openFileDialog = new OpenFileDialog { CheckFileExists = true };
            //if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            //foreach (var fileName in openFileDialog.FileNames)
            //{
            //    listViewFotos.Items.Add(fileName);
            //}
            var fdlg = new OpenFileDialog
            {
                Multiselect = true,
                Title = @"Select a file to add... ",
                InitialDirectory = "C:\\",
                Filter = @"All files|*.*",
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() != DialogResult.OK) return;

            foreach (var files in fdlg.FileNames)
            {
                try
                {
                    this.imageList1.Images.Add(Image.FromFile(files));
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            this.listViewFotos.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(32, 32);
            this.listViewFotos.LargeImageList = this.imageList1;
            //or
            //this.listView1.View = View.SmallIcon;
            //this.listView1.SmallImageList = this.imageList1;
            for (var j = 0; j < this.imageList1.Images.Count; j++)
            {
                var item = new ListViewItem { ImageIndex = j };
                this.listViewFotos.Items.Add(item);
            }
        }

        private void EliminarFoto(object sender, EventArgs e)
        {
            if (listViewFotos.FocusedItem == null) return;
            var focusedItem = listViewFotos.FocusedItem;
            imageList1.Images.RemoveAt(focusedItem.ImageIndex);
            listViewFotos.Items.Remove(listViewFotos.FocusedItem);
        }
    }
}
