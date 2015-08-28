using iTextSharp.text;
using iTextSharp.text.pdf;
using Seggu.Data;
using Seggu.Desktop.Forms;
using Seggu.Desktop.Helpers;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{

    public partial class PolizasUserControl : UserControl
    {

        private IPolicyService policyService;
        private IClientService clientService;
        private ICompanyService companyService;
        private IRiskService riskService;
        private IProducerService producerService;
        private IMasterDataService masterDataService;
        private IFeeService feeService;
        private IPrintService printService;
        private IAttachedFileService attachedFileService;
        private CompanyFullDto selectedCompany;
        private ClientIndexDto currentClient;
        private VehiculePolicyUserControl vehicle_uc = null;
        private VidaPolicyUserControl vida_uc = null;
        private IntegralPolicyUserControl integral_uc = null;

        public PolizasUserControl(IPolicyService polServ, IClientService cliServ, ICompanyService compServ,
            IRiskService riskServ, IMasterDataService masterDataServ, IProducerService prodServ,
            IFeeService feeService, IPrintService printService, IAttachedFileService attachedFileService)
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
            chkOtherClient.Visible = false;
            InitializeDetailComboBoxes();
            if (SegguExecutionContext.Instance.CurrentUser.Role == Role.Cajero)
            {
                this.btnNuevaPoliza.Visible = false;
                this.btnRenovar.Visible = false;
                this.btnGrabar.Visible = false;
                this.btnPrint.Visible = false;
            }
        }
        private void InitializeDetailComboBoxes()
        {
            cmbPeriodo.DataSource = masterDataService.GetPeriods().ToList();

            cmbCompania.ValueMember = "Id";
            cmbCompania.DisplayMember = "Name";
            cmbCompania.DataSource = companyService.GetAll().ToList();

            cmbProductor.ValueMember = "Id";
            cmbProductor.DisplayMember = "Name";

            cmbRiesgo.ValueMember = "Id";
            cmbRiesgo.DisplayMember = "Name";

            cmbCobrador.ValueMember = "Id";
            cmbCobrador.DisplayMember = "Name";
            cmbCobrador.DataSource = producerService.GetCollectors().ToList();
        }
        private Layout LayoutForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

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
            grdFees.Rows.Clear();
            cmbPlanes.Enabled = true;
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
            selectedCompany = companyService.GetFullById(LayoutForm.currentPolicy.CompanyId);
            //cp.Id = null;
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
            calcularNetoCobrar();
        }


        public void PopulateDetails()
        {
            currentClient = LayoutForm.currentClient;

            NavigateToDetalle();
            selectedCompany = companyService.GetFullById(LayoutForm.currentPolicy.CompanyId);
            cmbProductor.DataSource = selectedCompany.Producers;
            cmbRiesgo.DataSource = selectedCompany.Risks;
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
            txtBonificacionPropia.DataBindings.Add("Text", policy, "Bonus");
            txtNroPolAnt.DataBindings.Add("Text", policy, "PreviousNumber");
            txtNroPoliza.DataBindings.Add("Text", policy, "Número");
            txtPrima.DataBindings.Add("Text", policy, "Prima");
            txtRecargoPropio.DataBindings.Add("Text", policy, "Surcharge");
            txtSumaAsegurado.DataBindings.Add("Text", policy, "Value");
            txtPremioIva.DataBindings.Add("Text", policy, "Premium");
            txtNotas.DataBindings.Add("Text", policy, "Notes");

            dtpInicio.DataBindings.Add("Value", policy, "StartDate");
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


        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            dtpSolicitud.Value = dtpInicio.Value;
            if (cmbPeriodo.SelectedIndex != -1)
                CalcularFinPoliza();
        }
        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedIndex == -1) return;
            CalcularFinPoliza();
        }
        private void cmbPeriodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcularFinPoliza();
        }
        private void CalcularFinPoliza()
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


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    var policy = GetFormInfo();
                    policy.Fees = (List<FeeDto>)this.grdFees.DataSource;

                    if (vida_uc != null)
                        policy.Employees = vida_uc.GetEmployees();
                    else if (vehicle_uc != null && vehicle_uc.ValidateControls())
                        policy.Vehicles = vehicle_uc.vehicleList;
                    else if (integral_uc != null && integral_uc.ValidateControls())
                        policy.Integrals = integral_uc.GetIntegral();
                    else
                        return;
                    policyService.SavePolicy(policy);

                    MessageBox.Show("Guardó OK!");
                    //limpiar layout
                    var mainForm = (Layout)this.FindForm();
                    mainForm.CleanLeftPanel();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo tecnico.\n" +
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
            bool ok = true;
            errorProvider1.Clear();
            foreach (TabPage tabPage in this.tctrlPolizasDatos.TabPages)
            {
                foreach (Control c in tabPage.Controls)
                {
                    if (c is TextBox)
                        if (c == txtAsegurado || c == txtPremioIva || c == txtSumaAsegurado)
                            if (c.Text == string.Empty || c.Text == "0")
                            {
                                errorProvider1.SetError(c, "Campo vacio");
                                ok = false;
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
            return ok;
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

            return policy;
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

            var risk = (RiskCompanyDto)cmbRiesgo.SelectedItem;

            var riesgo = RiskTypeDtoMapper.ToEnum(risk.RiskType);
            if (riesgo == RiskType.Automotores)
            {
                vehicle_uc = (VehiculePolicyUserControl)DependencyContainer.Instance.Resolve(typeof(VehiculePolicyUserControl));
                SetCoberturasTab(vehicle_uc);
                vehicle_uc.InitializeComboboxes(selectedCompany, (int)cmbRiesgo.SelectedValue);
                if (LayoutForm.currentPolicy != null)
                    vehicle_uc.PopulatePolicyVehicle();
            }
            else if (riesgo == RiskType.Vida_colectivo_Otros || riesgo == RiskType.Vida_individual || riesgo == RiskType.Otros)
            {
                vida_uc = (VidaPolicyUserControl)DependencyContainer.Instance.Resolve(typeof(VidaPolicyUserControl));
                SetCoberturasTab(vida_uc);
                if (LayoutForm.currentPolicy != null)
                    vida_uc.InitializeIndex((int)this.cmbRiesgo.SelectedValue);
            }
            else
            {
                integral_uc = (IntegralPolicyUserControl)DependencyContainer.Instance.Resolve(typeof(IntegralPolicyUserControl));
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

        private void cmbCompania_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var CompanyId = (int)cmbCompania.SelectedValue;
            selectedCompany = companyService.GetFullById(CompanyId);
            cmbRiesgo.DataSource = selectedCompany.Risks;
            cmbProductor.DataSource = selectedCompany.Producers;
            cmbCobrador.SelectedIndex = 0;
        }


        #region Sumas y Planes de pago

        private void cmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPlanes.SelectedIndex != -1 && txtNetoCobrar.Text != string.Empty && txtNetoCobrar.Text != "0")
                generarPlanDeCobro();
        }
        private void generarPlanDeCobro()
        {
            int cuotas;
            decimal[] importesCobrar;
            decimal[] importesPagar;
            DivideValueInFees(out cuotas, out importesCobrar, out importesPagar);
            grdFees.DataSource = CreateFeeObjectsList(cuotas, importesCobrar, importesPagar);
            FormatFeeGrid();
            CalculateFeeTotals();
        }
        private void DivideValueInFees(out int cuotas, out decimal[] importesCobrar, out decimal[] importesPagar)
        {
            ////////////dividir el importe total en cuotas////////////////////////
            cuotas = cmbPlanes.SelectedIndex + 1;
            decimal netoCobrar = decimal.Parse(txtNetoCobrar.Text);
            importesCobrar = new decimal[cuotas];
            decimal resto = netoCobrar % cuotas;
            netoCobrar -= resto;
            for (int i = 0; i < cuotas; i++)
                importesCobrar[i] = netoCobrar / cuotas;
            importesCobrar[cuotas - 1] += resto;

            ////////////dividir el importe total en cuotas////////////////////////
            decimal netoPagar = decimal.Parse(txtNetoPagar.Text);
            importesPagar = new decimal[cuotas];
            decimal resto2 = netoPagar % cuotas;
            netoPagar -= resto2;
            for (int i = 0; i < cuotas; i++)
                importesPagar[i] = netoPagar / cuotas;
            importesPagar[cuotas - 1] += resto2;
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
                fee.Venc_Cuota = payDate.AddMonths(f).ToShortDateString();
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
        }
        private void CalculateFeeTotals()
        {
            decimal totcobrar = 0;
            decimal totpagar = 0;
            foreach (DataGridViewRow row in grdFees.Rows)
            {
                totcobrar += decimal.Parse(row.Cells["Saldo"].Value.ToString());
                totpagar += decimal.Parse(row.Cells["Pago_Cía"].Value.ToString());
            }
            txtTotalCobrar.Text = totcobrar.ToString();
            txtTotalPagar.Text = totpagar.ToString();
        }


        private void txtPremioIva_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPremioIva.Text)) return;
            calcularNetoCobrar();
            calcularNetoPagar();
            txtIva.Text = (double.Parse(txtPremioIva.Text) * (0.21)).ToString();
            txtPrima.Text = (double.Parse(txtPremioIva.Text) * (0.79)).ToString();
        }
        private void calcularNetoPagar()
        {
            decimal premioConIva = txtPremioIva.Text == string.Empty ? 0 : decimal.Parse(txtPremioIva.Text);
            decimal bonificacionPagaCia = txtBonificacionPago.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPago.Text);
            decimal netoPagar = premioConIva - bonificacionPagaCia;
            txtNetoPagar.Text = netoPagar.ToString();
        }
        private void txtBonificacionPropia_TextChanged(object sender, EventArgs e)
        {
            calcularNetoCobrar();
        }
        private void txtBonificacionPago_TextChanged(object sender, EventArgs e)
        {
            calcularNetoCobrar();
        }
        private void txtRecargoPropio_TextChanged(object sender, EventArgs e)
        {
            calcularNetoCobrar();
        }
        private void calcularNetoCobrar()
        {
            decimal recargoPropio = txtRecargoPropio.Text == string.Empty ? 0 : decimal.Parse(txtRecargoPropio.Text);
            decimal bonificacionPropia = txtBonificacionPropia.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPropia.Text);
            decimal bonificacionPagar = txtBonificacionPago.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPago.Text);
            decimal premioConIva = txtPremioIva.Text == string.Empty ? 0 : decimal.Parse(txtPremioIva.Text);
            decimal netoCobrar = premioConIva - bonificacionPagar - bonificacionPropia + recargoPropio;
            txtNetoCobrar.Text = netoCobrar.ToString();
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

        #endregion


        #region Validaciones

        private void txtAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTextoYPuntuacion(e);
        }
        public void ValidarTextoYPuntuacion(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true)
            {
            }
            //Codigo Ascii para el punto
            else if (e.KeyChar == 46)
            {
            }
            //codigo Ascii para la coma
            else if (e.KeyChar == 44)
            {
            }
            //codigo Ascii para el guion 
            else if (e.KeyChar == 45)
            {
            }
            //Codigo Ascii para el Backspace
            else if (e.KeyChar == '\b')
            {
            }
            //Codigo Ascii para el Space
            else if (e.KeyChar == 32)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        public void ValidarNumeroYPunto(TextBox sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 46 && (sender.Text ?? string.Empty).IndexOf('.') == -1)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSumaAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeroYPunto((TextBox)sender, e);
        }
        private void txtPremioIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeroYPunto((TextBox)sender, e);
        }
        private void txtBonificacionPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeroYPunto((TextBox)sender, e);
        }
        private void txtBonificacionPropia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeroYPunto((TextBox)sender, e);
        }
        private void txtRecargoPropio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeroYPunto((TextBox)sender, e);
        }
        public void ValidarNumeroYPuntuacion(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true)
            {
            }
            //Codigo Ascii para el punto
            else if (e.KeyChar == 46)
            {
            }
            //Codigo Ascii para el porcentaje
            else if (e.KeyChar == 37)
            {
            }
            //codigo Ascii para la coma
            else if (e.KeyChar == 44)
            {
            }
            //codigo Ascii para el guion 
            else if (e.KeyChar == 45)
            {
            }
            //Codigo Ascii para el Backspace
            else if (e.KeyChar == '\b')
            {
            }
            //Codigo Ascii para el Space
            else if (e.KeyChar == 32)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        public void ValidarNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true)
            {
            }
            //codigo Ascii para el guion 
            else if (e.KeyChar == 45)
            {
            }
            //Codigo Ascii para el Backspace
            else if (e.KeyChar == '\b')
            {
            }
            //Codigo Ascii para el Space
            else if (e.KeyChar == 32)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        private void cmbClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtAsegurado.Text = cmbClient.SelectedText;
            LayoutForm.currentPolicy.ClientId = (int)cmbClient.SelectedValue;
        }

        private void txtPaymentDay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int input = 0;
            bool isNum = Int32.TryParse(txtPaymentDay.Text, out input);

            if (!isNum || input < 1 || input > 30)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPaymentDay.Select(0, txtPaymentDay.Text.Length);

            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printService.PolicyPDF(LayoutForm.currentClient, LayoutForm.currentPolicy, vehicle_uc.GetSelectedPlate());
        }

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

        private void txtPaymentDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(e);
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
    }
}
