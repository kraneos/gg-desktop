using iTextSharp.text.pdf;
using Seggu.Data;
using Seggu.Desktop.Forms;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{
    public partial class EndososUserControl : UserControl
    {
        private IEndorseService endorseService;
        private IPolicyService policyService;
        private IClientService clientService;
        private ICompanyService companyService;
        private IRiskService riskService;
        private IProducerService producerService;
        private IMasterDataService masterDataService;
        private IFeeService feeService;
        private IPrintService printService;

        private VehiculePolicyUserControl vehicle_uc = null;
        private VidaPolicyUserControl vida_uc = null;
        private IntegralPolicyUserControl integral_uc = null;


        public EndososUserControl(IEndorseService endorseService, IPolicyService polServ, IClientService cliServ
            , ICompanyService compServ, IRiskService riskServ, IMasterDataService masterDataServ
            , IProducerService prodServ, IFeeService feeService, IPrintService printService)
        {
            InitializeComponent();
            this.endorseService = endorseService;
            this.policyService = polServ;
            this.clientService = cliServ;
            this.companyService = compServ;
            this.riskService = riskServ;
            this.masterDataService = masterDataServ;
            this.producerService = prodServ;
            this.feeService = feeService;
            this.printService = printService;
            InitializeDetailComboBoxes();
        }
        private void InitializeDetailComboBoxes()
        {
            cmbTipoEndosos.DataSource = masterDataService.GetEndorseTypes().ToList();

            cmbCompania.ValueMember = "Id";
            cmbCompania.DisplayMember = "Name";
            cmbCompania.DataSource = companyService.GetAll().ToList();

            cmbProductor.ValueMember = "Id";
            cmbProductor.DisplayMember = "Name";
            cmbProductor.DataSource = producerService.GetProducers().ToList();

            cmbCobrador.ValueMember = "Id";
            cmbCobrador.DisplayMember = "Name";
            cmbCobrador.DataSource = producerService.GetCollectors().ToList();
        }
        public Layout MainForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

        public void NewEndorse()
        {
            cmbCompania.SelectedValue = MainForm.currentPolicy.CompanyId;

            cmbRiesgo.ValueMember = "Id";
            cmbRiesgo.DisplayMember = "Name";
            //cmbProductor.DataSource = this.producerService.GetByCompanyIdCombobox(MainForm.currentPolicy.CompanyId).ToList();
            cmbRiesgo.DataSource = this.riskService.GetByCompanyCombobox(MainForm.currentPolicy.CompanyId).ToList();
            if (MainForm.currentEndorse == null)
                ConvertPolicyToEndorse();
            else
                ConvertCurrentEndorseToNewEndorse();

            populateTextBoxesAndCombos(MainForm.currentEndorse);
            cmbPlanes.Enabled = true;
        }
        private void ConvertPolicyToEndorse()
        {
            var ce = new EndorseFullDto();
            var cp = MainForm.currentPolicy;
            ce.Asegurado = cp.Asegurado;
            ce.ClientId = cp.ClientId;
            ce.CompanyId = cp.CompanyId;
            ce.Notes = cp.Notes;
            ce.PolicyId = cp.Id;
            ce.PolicyNumber = cp.Número;
            ce.Premium = cp.Premium;
            ce.Prima = cp.Prima;
            ce.PaymentBonus = cp.PaymentBonus;
            ce.ProducerId = cp.ProducerId;
            ce.RiskId = cp.RiskId;

            ce.AnnulationDate = DateTime.Today.ToShortDateString();
            ce.EmissionDate = DateTime.Today.ToShortDateString();
            ce.EndDate = cp.Vence;
            ce.ReceptionDate = DateTime.Today.ToShortDateString();
            ce.RequestDate = DateTime.Today.ToShortDateString();
            ce.StartDate = DateTime.Today.ToShortDateString();

            ce.Surcharge = cp.Surcharge;
            ce.TipoRiesgo = cp.TipoRiesgo;
            ce.Value = cp.Value;
            if (cp.Vehicles != null)
            {
                ce.Vehicles = cp.Vehicles;
                foreach (var vehicle in ce.Vehicles) { }
                //vehicle.Id = null;
            }
            else if (cp.Employees != null)
            {
                ce.Employees = cp.Employees;
                foreach (var employee in ce.Employees) { }
                //employee.Id = null;
            }
            else if (cp.Integrals != null)
            {
                ce.Integrals = cp.Integrals;
            }
            MainForm.currentEndorse = ce;
        }
        private void ConvertCurrentEndorseToNewEndorse()
        {
            var newEndorse = new EndorseFullDto();
            var ce = MainForm.currentEndorse;
            newEndorse.Asegurado = ce.Asegurado;
            newEndorse.ClientId = ce.ClientId;
            newEndorse.CompanyId = ce.CompanyId;
            newEndorse.Notes = ce.Notes;
            newEndorse.PolicyId = ce.Id;
            newEndorse.PolicyNumber = ce.Número;
            newEndorse.Premium = ce.Premium;
            newEndorse.Prima = ce.Prima;
            newEndorse.PaymentBonus = ce.PaymentBonus;
            newEndorse.ProducerId = ce.ProducerId;
            newEndorse.RiskId = ce.RiskId;

            newEndorse.AnnulationDate = ce.AnnulationDate;
            newEndorse.EmissionDate = ce.EmissionDate;
            newEndorse.EndDate = ce.EndDate;
            newEndorse.ReceptionDate = ce.ReceptionDate;
            newEndorse.RequestDate = DateTime.Today.ToShortDateString();
            newEndorse.StartDate = DateTime.Today.ToShortDateString();

            newEndorse.Surcharge = ce.Surcharge;
            newEndorse.TipoRiesgo = ce.TipoRiesgo;
            newEndorse.Value = ce.Value;
            if (ce.Vehicles != null)
            {
                var newVehicles = new List<VehicleDto>();
                foreach (var vehicle in ce.Vehicles)
                {
                    //vehicle.Id = null;// no lo hace
                    var newVehicle = vehicle;
                    //newVehicle.Id = string.Empty;
                    newVehicles.Add(newVehicle);
                }
                newEndorse.Vehicles = newVehicles;
            }
            else if (ce.Employees != null)
            {
                var newEmployees = new List<EmployeeDto>();
                foreach (var employee in ce.Employees)
                {
                    //vehicle.Id = null;// no lo hace
                    var newEmployee = employee;
                    //newEmployee.Id = string.Empty;
                    newEmployees.Add(newEmployee);
                }
                newEndorse.Employees = newEmployees;
                //newEndorse.Employees = ce.Employees;
                //foreach (var employee in newEndorse.Employees)
                //    employee.Id = null;
            }
            MainForm.currentEndorse = newEndorse;
        }

        private void populateTextBoxesAndCombos(EndorseFullDto endorse)
        {
            cmbProductor.SelectedValue = endorse.ProducerId;
            cmbRiesgo.SelectedValue = endorse.RiskId == default(int) ? cmbRiesgo.SelectedValue : endorse.RiskId;
            cmbCompania.SelectedValue = endorse.CompanyId == default(int) ? cmbCompania.SelectedValue : endorse.CompanyId;

            cmbTipoEndosos.SelectedItem = endorse.EndorseType;
            txtNroEndoso.Text = endorse.Número;
            txtMotivo.Text = endorse.Motivo;

            txtAsegurado.Text = endorse.Asegurado;
            txtNroPoliza.Text = endorse.PolicyNumber;
            txtPrima.Text = endorse.Prima.ToString();
            txtRecargoPropio.Text = endorse.Surcharge.ToString();
            txtSumaAsegurado.Text = endorse.Value.ToString();
            txtPremioIva.Text = endorse.Premium.ToString();
            txtBonificacionPago.Text = endorse.PaymentBonus.ToString();
            txtNotas.Text = endorse.Notes;

            dtpSolicitud.Value = DateTime.Parse(endorse.RequestDate);
            dtpRecibido.Value = DateTime.Parse(endorse.ReceptionDate);
            dtpRecibido.Checked = false;
            dtpInicio.Value = DateTime.Parse(endorse.StartDate);
            dtpFin.Value = DateTime.Parse(endorse.EndDate);
            dtpEmision.Value = DateTime.Parse(endorse.EmissionDate);
            dtpEmision.Checked = false;
        }

        public void PopulateDetails()
        {
            cmbRiesgo.ValueMember = "Id";
            cmbRiesgo.DisplayMember = "Name";
            cmbRiesgo.DataSource = this.riskService.GetByCompanyCombobox(MainForm.currentPolicy.CompanyId).ToList();

            populateTextBoxesAndCombos(MainForm.currentEndorse);
            LoadFeeGrid();
        }
        private void LoadFeeGrid()
        {
            grdFees.Columns.Clear();
            grdFees.DataSource = feeService.GetByEndorseId(MainForm.currentEndorse.Id).ToList();
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
        private void FormatFeeGrid()
        {
            grdFees.Columns["Id"].Visible = false;
            grdFees.Columns["FeeSelectionId"].Visible = false;
            grdFees.Columns["PolicyId"].Visible = false;
            grdFees.Columns["Annulated"].Visible = false;
            grdFees.Columns["CompanyId"].Visible = false;
            grdFees.Columns["Cliente"].Visible = false;
            grdFees.Columns["EndorseId"].Visible = false;
            grdFees.Columns["Nro_Endoso"].Visible = false;
            grdFees.Columns["Pago_Cía"].DefaultCellStyle.Format = "c2";
            grdFees.Columns["Saldo"].DefaultCellStyle.Format = "c2";
            grdFees.Columns["Valor"].DefaultCellStyle.Format = "c2";
        }
        private void CalculateFeeTotals()
        {
            decimal totcobrar = 0;
            decimal totpagar = 0;
            foreach (DataGridViewRow row in grdFees.Rows)
            {
                totcobrar += decimal.Parse(row.Cells["Pago_Cía"].Value.ToString());
                totpagar += decimal.Parse(row.Cells["Saldo"].Value.ToString());
            }
            txtTotalCobrar.Text = totcobrar.ToString();
            txtTotalPagar.Text = totpagar.ToString();
        }

        private void cmbRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRiesgo.SelectedIndex == -1) return;
            FillInsuredObjectUserControl();
        }
        private void FillInsuredObjectUserControl()
        {
            integral_uc = null;
            vehicle_uc = null;
            vida_uc = null;

            var risk = (RiskItemDto)cmbRiesgo.SelectedItem;
            var riesgo = risk.RiskType;
            if (riesgo == RiskType.Automotores)
            {
                vehicle_uc = (VehiculePolicyUserControl)DependencyResolver.Instance.Resolve(typeof(VehiculePolicyUserControl));
                SetCoberturasTab(vehicle_uc);
                vehicle_uc.InitializeComboboxes((int)cmbRiesgo.SelectedValue);
                if (MainForm.currentEndorse != null)
                    vehicle_uc.PopulateEndorseVehicle();
            }
            else if (riesgo == RiskType.Vida_colectivo_Otros || riesgo == RiskType.Vida_individual || riesgo == RiskType.Otros)
            {
                vida_uc = (VidaPolicyUserControl)DependencyResolver.Instance.Resolve(typeof(VidaPolicyUserControl));
                SetCoberturasTab(vida_uc);
                if (MainForm.currentEndorse != null)
                {
                    vida_uc.InitializeIndex((int)this.cmbRiesgo.SelectedValue);
                    //vida_uc.
                }

            }
            else
            {
                integral_uc = (IntegralPolicyUserControl)DependencyResolver.Instance.Resolve(typeof(IntegralPolicyUserControl));
                SetCoberturasTab(integral_uc);
                integral_uc.InitializeComboboxes((int)cmbRiesgo.SelectedValue);
                if (MainForm.currentEndorse != null)
                    integral_uc.PopulateEndorseIntegral();
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
            cmbRiesgo.ValueMember = "Id";
            cmbRiesgo.DisplayMember = "Name";
            cmbRiesgo.DataSource = this.riskService.GetByCompanyCombobox(CompanyId).ToList(); // selectedCompany.Risks;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    var endorse = GetFormInfo();
                    endorse.Fees = (List<FeeDto>)this.grdFees.DataSource;

                    if (vida_uc != null)
                        endorse.Employees = vida_uc.GetEmployees();
                    else if (vehicle_uc != null && vehicle_uc.ValidateControls())
                        endorse.Vehicles = vehicle_uc.vehicleList;
                    else if (integral_uc != null)
                        endorse.Integrals = integral_uc.GetIntegral();

                    endorseService.Save(endorse);

                    MessageBox.Show("El endoso se ha guardado con exito.");
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
                        ex.InnerException.Message + "\nStackTrace: " + ex.InnerException.StackTrace), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Datos obligatorios sin completar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (TabPage tabPage in this.tctrlEndososDatos.TabPages)
            {
                foreach (Control c in tabPage.Controls)
                {
                    if (c is TextBox)
                    {
                        if (c == txtAsegurado || c == txtPremioIva || c == txtMotivo)
                            if (c.Text == string.Empty)
                            {
                                errorProvider1.SetError(c, "Campo vacio");
                                ok = false;
                            }
                    }
                    else if (c is ComboBox)
                    {
                        if (c == cmbTipoEndosos || c == cmbCompania ||
                            c == cmbRiesgo || c == cmbProductor || c == cmbCobrador)
                            if ((c as ComboBox).SelectedIndex == -1)
                            {
                                errorProvider1.SetError(c, "Debe seleccionar un elemento");
                                ok = false;
                            }
                    }
                }
            }
            return ok;
        }
        private EndorseFullDto GetFormInfo()
        {
            EndorseFullDto endorse = new EndorseFullDto();
            endorse.Id = MainForm.currentEndorse.Id;
            endorse.AnnulationDate = null;
            endorse.Asegurado = txtAsegurado.Text;

            endorse.Motivo = txtMotivo.Text;
            endorse.CompanyId = (int)cmbCompania.SelectedValue;
            endorse.ClientId = MainForm.currentEndorse.ClientId;

            endorse.EmissionDate = dtpEmision.Value.ToShortDateString();
            endorse.EndDate = dtpFin.Value.ToShortDateString();
            endorse.EndorseType = cmbTipoEndosos.SelectedValue.ToString();

            endorse.IsAnnulled = false;
            endorse.IsRemoved = false;

            endorse.Notes = txtNotas.Text;
            endorse.Número = txtNroEndoso.Text;

            endorse.PolicyId = MainForm.currentPolicy.Id;
            endorse.PolicyNumber = txtNroPoliza.Text;
            endorse.Prima = txtPrima.Text == "" ? 0 : decimal.Parse(txtPrima.Text);
            endorse.Premium = txtPremioIva.Text == "" ? 0 : decimal.Parse(txtPremioIva.Text);
            endorse.PaymentBonus = txtBonificacionPago.Text == "" ? 0 : decimal.Parse(txtBonificacionPago.Text);
            endorse.ProducerId = (int)cmbProductor.SelectedValue;

            endorse.RequestDate = dtpSolicitud.Value.ToShortDateString();
            endorse.ReceptionDate = dtpRecibido.Value.ToShortDateString();
            endorse.RiskId = (int)cmbRiesgo.SelectedValue;

            endorse.StartDate = dtpInicio.Value.ToShortDateString();
            endorse.Surcharge = txtRecargoPropio.Text == "" ? 0 : decimal.Parse(txtRecargoPropio.Text);
            //endorse.TipoRiesgo = ((RiskItemDto)cmbRiesgo.SelectedItem).RiskType;

            endorse.Value = txtSumaAsegurado.Text == "" ? 0 : decimal.Parse(txtSumaAsegurado.Text);

            return endorse;
        }

        private void txtPremioIva_TextChanged(object sender, EventArgs e)
        {
            if (txtPremioIva.Text == "-" || txtPremioIva.Text == "") return;
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
            decimal bonificacionPagar = txtBonificacionPago.Text == string.Empty ? 0 : decimal.Parse(txtBonificacionPago.Text);
            decimal premioConIva = txtPremioIva.Text == string.Empty ? 0 : decimal.Parse(txtPremioIva.Text);
            decimal netoCobrar = premioConIva - bonificacionPagar + recargoPropio;
            txtNetoCobrar.Text = netoCobrar.ToString();
        }

        private void cmbPlanes_SelectionChangeCommitted(object sender, EventArgs e)
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
            //decimal resto = netoCobrar % cuotas;
            //netoCobrar -= resto;
            for (int i = 0; i < cuotas; i++)
                importesCobrar[i] = netoCobrar / cuotas;
            //importesCobrar[cuotas - 1] += resto;

            ////////////dividir el importe total en cuotas////////////////////////
            decimal netoPagar = decimal.Parse(txtNetoPagar.Text);
            importesPagar = new decimal[cuotas];
            //decimal resto2 = netoPagar % cuotas;
            //netoPagar -= resto2;
            for (int i = 0; i < cuotas; i++)
                importesPagar[i] = netoPagar / cuotas;
            //importesPagar[cuotas - 1] += resto2;
        }
        private List<FeeDto> CreateFeeObjectsList(int cuotas, decimal[] importesCobrar, decimal[] importesPagar)
        {
            List<FeeDto> fees = new List<FeeDto>();
            for (int f = 0; f < cuotas; f++)
            {
                FeeDto fee = new FeeDto();
                fee.Cuota = (f + 1).ToString();
                fee.Venc_Cuota = dtpInicio.Value.AddMonths(f);
                fee.Valor = importesCobrar[f];
                fee.Annulated = false;
                fee.Estado = "Debe";
                fee.Pago_Cía = importesPagar[f];
                fee.Saldo = fee.Valor;
                fee.PolicyId = MainForm.currentPolicy.Id;
                fees.Add(fee);
            }
            return fees;
        }

        private void txtPremioIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
        private void txtSumaAsegurado_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros((TextBox)sender, e);
        }
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printService.EndorsePDF(MainForm.currentEndorse, MainForm.currentClient, MainForm.currentPolicy);
        }
    }
}