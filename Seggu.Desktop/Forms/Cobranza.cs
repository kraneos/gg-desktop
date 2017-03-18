using Seggu.Dtos;
using Seggu.Domain;
using Seggu.Helpers;

using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace Seggu.Desktop.Forms
{
    public partial class Cobranza : Form
    {
        private IClientService clientService;
        private IFeeService feeService;
        private IProducerService producerService;
        private ILedgerAccountService ledgerAccountService;
        private IAssetService assetService;
        private ICashAccountService cashAccountService;
        private ICollectionService collectionService;
        private IVehicleService vehicleService;
        private IPrintService printService;
        private IPolicyService policyService;
        private IRiskService riskService;
        private FeeDto currentFee;
        private int policyId;
        private int ledgerAccountId;
        private decimal cobro;
        private IEmployeeService employeeService;

        public Cobranza(IClientService clientService, IFeeService feeService, IProducerService producerService
            , ILedgerAccountService ledgerAccountService, IAssetService assetService
            , ICashAccountService cashAccountService, IPrintService printService
            , ICollectionService collectionService, IVehicleService vehicleService
            , IPolicyService policyService, IRiskService riskService, IEmployeeService employeeService, int policyId)
        {
            this.clientService = clientService;
            this.policyId = policyId;
            this.feeService = feeService;
            this.producerService = producerService;
            this.ledgerAccountService = ledgerAccountService;
            this.assetService = assetService;
            this.cashAccountService = cashAccountService;
            this.collectionService = collectionService;
            this.vehicleService = vehicleService;
            this.policyService = policyService;
            this.printService = printService;
            this.riskService = riskService;
            this.employeeService = employeeService;
            InitializeComponent();
        }

        private void Cobranza_Load(object sender, EventArgs e)
        {
            ledgerAccountId = ledgerAccountService.GetCobranzaId();
            InitializeComboboxes();
            InitializeGrdCuotas();
            txtNumeroRecibo.Text = (cashAccountService.GetLastReceiptNumber() + 1).ToString();
        }
        private void InitializeComboboxes()
        {
            cmbActivos.ValueMember = "Id";
            cmbActivos.DisplayMember = "Name";
            cmbActivos.DataSource = assetService.GetAll().ToList();

            cmbCobrador.ValueMember = "Id";
            cmbCobrador.DisplayMember = "Name";
            cmbCobrador.DataSource = producerService.GetCollectors().ToList();
        }
        public void InitializeGrdCuotas()
        {
            grdCuotas.DataSource = feeService.GetByPolicyId(policyId).ToList();
            string policyNumber = grdCuotas.Rows[0].Cells["Nro_Póliza"].Value.ToString();
            lblPolicyNumber.Text = string.IsNullOrEmpty(policyNumber) ? "Sin Nº" : policyNumber;
            lblClient.Text = grdCuotas.Rows[0].Cells["Cliente"].Value.ToString();
            FormatGridCuotas();
            grdCuotas.Select();
        }
        private void FormatGridCuotas()
        {
            grdCuotas.Columns["Id"].Visible = false;
            grdCuotas.Columns["Cliente"].Visible = false;
            grdCuotas.Columns["Nro_Póliza"].Visible = false;
            grdCuotas.Columns["PolicyId"].Visible = false;
            grdCuotas.Columns["FeeSelectionId"].Visible = false;
            grdCuotas.Columns["CompanyId"].Visible = false;
            grdCuotas.Columns["Annulated"].Visible = false;
            grdCuotas.Columns["EndorseId"].Visible = false;
            grdCuotas.Columns["Saldo"].DefaultCellStyle.Format = "c2";
            grdCuotas.Columns["Pago_Cía"].DefaultCellStyle.Format = "c2";
            grdCuotas.Columns["Valor"].DefaultCellStyle.Format = "c2";
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                if (ValidateCurrentFeeState(currentFee))
                {
                    bool existsPrevRow = grdCuotas.CurrentRow.Index > 0;
                    if (existsPrevRow)
                    {
                        var previousFee = (FeeDto)grdCuotas.Rows[grdCuotas.CurrentRow.Index - 1].DataBoundItem;
                        if (ValidatePrevFeeState(previousFee))
                            CollectFee();
                        else
                            MessageBox.Show("Verifique el estado de la cuota anterior");
                    }
                    else
                        CollectFee();
                }
                else
                    MessageBox.Show("Verifique el estado de la cuota seleccionada");
            }
        }

        private void CollectFee()
        {
            if (currentFee.Saldo != 0)
            {
                cobro = Convert.ToDecimal(txtImporte.Text);
                bool valueIsSameAsBalance = (currentFee.Saldo == cobro);
                bool existsNextRow = (grdCuotas.CurrentRow.Index + 1) < grdCuotas.Rows.Count;
                if (!existsNextRow && !valueIsSameAsBalance)
                    MessageBox.Show("La última cuota debe pagarse el monto exacto" +
                            " que figura en el saldo!\n $ " + currentFee.Saldo);
                else
                {
                    if (currentFee.Estado == "Sin Cobertura")
                        MessageBox.Show("Recuerde enviar Mantener Cubierto a la Compañía");
                    UpdateFeeAndSaveCollection();
                }
            }
            else
                MessageBox.Show("Verifique su acción, la cuota ya está pagada");
        }
        private void UpdateFeeAndSaveCollection()
        {
            PrepareFeeToUpdate();
            feeService.Update(currentFee);
            SaveFeeInCashAccount(currentFee);
        }
        private void PrepareFeeToUpdate()
        {
            if (cobro == currentFee.Saldo)
                currentFee.Estado = "Pagado";
            else
                currentFee.Estado = "Observado";
            currentFee.Saldo -= cobro;
        }
        private void SaveFeeInCashAccount(FeeDto fee)
        {
            AssetDto selectedAsset = (AssetDto)cmbActivos.SelectedItem;
            decimal AssetTotal = selectedAsset.Amount;

            CashAccountDto obj = new CashAccountDto();
            obj.Amount = cobro;
            obj.AssetId = (int)cmbActivos.SelectedValue;
            obj.Date = DateTime.Now;
            obj.LedgerAccountId = ledgerAccountId;//"cobranza"
            obj.Description = "Cuota #" + currentFee.Cuota + ", Póliza #" +
                currentFee.Nro_Póliza;
            obj.ReceiptNumber = txtNumeroRecibo.Text;
            obj.ProducerId = (int)cmbCobrador.SelectedValue;
            obj.Balance = selectedAsset.Amount;
            obj.FeeId = fee.Id;

            selectedAsset.Amount = AssetTotal + cobro;
            try
            {
                assetService.Update(selectedAsset);
                this.cashAccountService.Save(obj);
                MessageBox.Show("La cobranza se ha guardado con éxito.");
                grdCuotas.Refresh();
                txtNumeroRecibo.Text = (cashAccountService.GetLastReceiptNumber() + 1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    @"Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo técnico." +
                    ex.Message + "\n" + ex.StackTrace + (ex.InnerException == null ? string.Empty : "\nInner Exception: " +
                    ex.InnerException.Message + "\nStackTrace: " +
                    ex.InnerException.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private FeeChargeDto ConvertCurrentFeeToFeeChargeDto(FeeDto currentFee, decimal value)
        {
            currentFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
            var vehicle = vehicleService.GetByPolicyId(currentFee.PolicyId);
            var policy = policyService.GetById(currentFee.PolicyId);
            var dto = new FeeChargeDto()
            {
                Company = policy.Compañía,
                CompanyId = currentFee.CompanyId,
                PolicyId = currentFee.PolicyId,
                NºRecibo = txtNumeroRecibo.Text,
                CollectionDate = DateTime.Today,
                PolicyExpirationDate = DateTime.Parse(policy.Vence),
                //Coverage = policy.Coverage,
                FullClientName = currentFee.Cliente,
                Items = new List<ChargeItemDto>()
                        {
                            new ChargeItemDto()
                            {
                                FeeNumber = currentFee.Cuota,
                                PolicyNumber = currentFee.Nro_Póliza,
                                Value = value
                            }
                        },
                VehicleBrand = vehicle.Brand,
                VehicleModel = vehicle.Model,
                VehiclePlate = vehicle.Plate,
                VehicleChasis = vehicle.Chassis,
                VehicleEngine = vehicle.Engine,
            };
            return dto;
        }
        private FeeLifeDto CreateLifeDto()
        {
            var client = clientService.GetShortDtoById(currentFee.ClientId);
            var policy = policyService.GetById(currentFee.PolicyId);
            var employees = employeeService.GetByPolicyId(currentFee.PolicyId);
            var producer = producerService.GetById(policy.ProducerId);

            var firstEmployee = employees.First();

            var dto = new FeeLifeDto();
            dto.BeneficiaryCUIT = firstEmployee.CUIT;
            dto.BeneficiaryKinship = string.Empty;
            dto.BeneficiaryName = firstEmployee.Nombre;
            dto.BeneficiaryLastName = firstEmployee.Apellido;
            dto.BeneficiaryDNI = firstEmployee.DNI;
            dto.BeneficiaryPercent = string.Empty;

            dto.ClientBirthDate = client.BirthDate;
            dto.ClientCUIT = client.CUIT;
            dto.ClientDNI = client.Dni;
            dto.ClientEnsuranceValue = policy.Value.ToString();
            dto.ClientLastName = client.Apellido;
            dto.ClientName = client.Nombre;

            dto.CollectType = string.Empty;
            dto.CompanyName = policy.Compañía;
            dto.EmployerCompanyName = string.Empty;
            dto.EmployerCUIT = firstEmployee.CUIT;
            dto.EmployerDNI = firstEmployee.DNI;
            dto.EmployerLastName = firstEmployee.Apellido;
            dto.EmployerName = firstEmployee.Nombre;
            string feesCount = this.feeService.GetByPolicyId(currentFee.PolicyId).Count().ToString();
            dto.FeeCount = feesCount;
            dto.FeeNumber = currentFee.Cuota;
            dto.PolicyNumber = lblPolicyNumber.Text;
            dto.Producer = cmbCobrador.Text;
            dto.ProducerCode = producer.Matrícula;
            dto.ProducerComission = string.Empty;
            dto.ReceiptNumber = txtNumeroRecibo.Text;
            dto.Value = currentFee.Valor.ToString();
            dto.ValueInWords = Convert.ToDouble(currentFee.Valor).ToSpanishTextWithDecimals();
            return dto;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                decimal value = decimal.Parse(txtImporte.Text);
                var pol = policyService.GetById(currentFee.PolicyId);
                var risk = pol.TipoRiesgo;

                switch (risk)
                {
                    case "Automotores":
                        if (pol.Vehicles.Count() > 1)
                        {
                            //print flota
                        }
                        else
                            //printService.PolicyVehiclePDF(pol, vehicle_uc.GetSelectedPlate());
                            printService.VehicleReceipt(ConvertCurrentFeeToFeeChargeDto(currentFee, value));
                        break;

                    case "Vida Colectivo y Otros":
                        printService.LifeReceiptPDF(CreateLifeDto());
                        break;
                    case "Otros":
                        printService.LifeReceiptPDF(CreateLifeDto());
                        break;

                    case "Vida Individual":
                        printService.LifeReceiptPDF(CreateLifeDto());
                        break;

                    case "Combinados Integrales":
                        printService.IntegralReceiptPDF(currentFee);//, integral_uc.province, integral_uc.district);
                        break;
                }
            }
        }

        private void grdCuotas_SelectionChanged(object sender, EventArgs e)
        {
            currentFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
            txtImporte.Text = currentFee.Saldo.ToString("N2");
        }

        #region Validaciones
        public bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c == txtImporte || c == txtNumeroRecibo)
                        if (c.Text == string.Empty)
                        {
                            errorProvider1.SetError(c, "Campo vacío. Este campo es obligatorio.");
                            ok = false;
                        }
                    if (c == txtNumeroRecibo)
                        if (ReceiptExists())
                        {
                            errorProvider1.SetError(c, "El numero de Recibo ya existe.");
                            ok = false;
                        }
                }
                if (c is ComboBox)
                    if (c == cmbCobrador || c == cmbActivos)
                        if ((c as ComboBox).SelectedIndex == -1)
                        {
                            errorProvider1.SetError(c, "Debe seleccionar un elemento");
                            ok = false;
                        }

                if (c is DataGridView)
                    if (c == grdCuotas && (c as DataGridView).RowCount == 0)
                    {
                        errorProvider1.SetError(c, "Debe seleccionar un elemento");
                        ok = false;
                    }
            }
            return ok;
        }
        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
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
        private bool ReceiptExists()
        {
            var receipt = this.txtNumeroRecibo.Text;
            return this.cashAccountService.ReceiptExists(receipt);
        }
        private bool ValidatePrevFeeState(FeeDto prevFee)
        {
            bool ok = true;
            switch (prevFee.Estado)
            {
                case "Debe":
                    ok = false;
                    break;
                case "Liquidado":
                    ok = true;
                    break;
                case "Observado":
                    ok = false;
                    break;
                case "Pagado":
                    ok = true;
                    break;
                case "Preliquidado":
                    ok = true;
                    break;
                case "Mant. Cubierto":
                    ok = false;
                    break;
                case "Moroso":
                    ok = false;
                    break;
                case "Sin Cobertura":
                    ok = false;
                    break;
                case "Debe y Preliq":
                    ok = false;
                    break;
            }
            return ok;
        }
        private bool ValidateCurrentFeeState(FeeDto currentFee)
        {
            var ok = true;
            switch (currentFee.Estado)
            {
                case "Debe":
                    ok = true;
                    break;
                case "Liquidado":
                    ok = false;
                    break;
                case "Observado":
                    ok = true;
                    break;
                case "Pagado":
                    ok = false;
                    break;
                case "Preliquidado":
                    ok = false;
                    break;
                case "Mant. Cubierto":
                    ok = true;
                    break;
                case "Moroso":
                    ok = true;
                    break;
                case "Sin Cobertura":
                    ok = true;
                    break;
                case "Debe y Preliq":
                    ok = true;
                    break;
            }
            return ok;
        }
        #endregion

        #region Métodos obsoletos para multiseleccionar cuotas
        //private decimal CollectSelectedFees(decimal value)
        //{
        //    foreach (DataGridViewRow row in grdCuotas.SelectedRows)
        //    {
        //        currentFee = (FeeDto)row.DataBoundItem;
        //        cobro = currentFee.Saldo;
        //        CollectFee();
        //        value -= cobro;
        //    }

        //    return value;
        //}
        //private decimal NewMethod(decimal value)
        //{
        //    if (grdCuotas.SelectedRows.Count > 1)
        //        value = CollectSelectedFees(value);
        //    else
        //    {
        //        currentFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
        //        cobro = value;
        //        bool existsPrevRow = grdCuotas.CurrentRow.Index > 0;
        //        if (existsPrevRow)
        //        {
        //            var previousFee = (FeeDto)grdCuotas.Rows[grdCuotas.CurrentRow.Index - 1].DataBoundItem;
        //            if (previousFee.Estado != "Moroso" && previousFee.Estado != "Debe" &&
        //                previousFee.Estado != "Observado" && currentFee.Estado != "Pagado")
        //                CollectFee();
        //            else
        //                MessageBox.Show("Verifique su acción, la cuota anterior no se pagó");
        //        }
        //        else
        //            CollectFee();
        //    }

        //    return value;
        //}
        //private void SumDiferenceToNextFee()
        //{
        //    short feeNumber = short.Parse(currentFee.Cuota);
        //    grdCuotas.CurrentCell = grdCuotas[7, feeNumber];
        //    var nextFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
        //    nextFee.Valor += currentFee.Saldo;
        //    nextFee.Saldo = nextFee.Valor;
        //    feeService.Update(nextFee);
        //}
        //private void ClearForm()
        //{
        //    txtImporte.Clear();
        //    txtNumeroRecibo.Clear();
        //    grdCuotas.Refresh();
        //}


        ////para multiseleccionar
        //decimal value = 0;
        //foreach (DataGridViewRow row in grdCuotas.SelectedRows)
        //{
        //    var fee = (FeeDto)row.DataBoundItem;
        //    value += fee.Saldo;
        //}
        //txtImporte.Text = value.ToString("N2");

        //string[] vencimiento_cuotas = new string[grdCuotas.SelectedRows.Count];
        //decimal value = 0;
        //int index = 0;
        //foreach (DataGridViewRow row in grdCuotas.SelectedRows)
        //{
        //    var obj = (FeeDto)row.DataBoundItem;
        //    value += obj.Valor;
        //    vencimiento_cuotas[index] = obj.Venc_Cuota;
        //    index++;
        //}
        ////para muliseleccionar sólo las de un mismo vencimiento
        //foreach (string v in vencimiento_cuotas)
        //    if (v != vencimiento_cuotas[0])
        //    {
        //        grdCuotas.ClearSelection();
        //        return;
        //    }
        //txtImporte.Text = value.ToString();
        #endregion
    }
}
