using iTextSharp.text;
using iTextSharp.text.pdf;
using Seggu.Data;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Cobranza : Form
    {
        private IFeeService feeService;
        private IProducerService producerService;
        private ILedgerAccountService ledgerAccountService;
        private IAssetService assetService;
        private ICashAccountService cashAccountService;
        private ICollectionService collectionService;
        private IVehicleService vehicleService;
        private IPrintService printService;
        private IPolicyService policyService;
        private FeeDto currentFee;
        private int policyId;
        private int ledgerAccountId;
        private decimal cobro;

        public Cobranza(IFeeService feeService, IProducerService producerService
            , ILedgerAccountService ledgerAccountService, IAssetService assetService
            , ICashAccountService cashAccountService, IPrintService printService
            , ICollectionService collectionService, IVehicleService vehicleService
            , IPolicyService policyService, int policyId)
        {
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
            InitializeComponent();
        }

        private void Cobranza_Load(object sender, EventArgs e)
        {
            ledgerAccountId = ledgerAccountService.GetCobranzaId();
            InitializeComboboxes();
            InitializeGrdCuotas();
        }
            private void InitializeComboboxes()
            {
                cmbActivos.ValueMember = "Id";
                cmbActivos.DisplayMember = "Name";
                cmbActivos.DataSource = assetService.GetAll().ToList();

                cmbCobrador.ValueMember = "Id";
                cmbCobrador.DisplayMember = "Name";
                cmbCobrador.DataSource = producerService.GetCollectors().ToList();
                //cmbCobrador.SelectedIndex = 1;
            }
            public void InitializeGrdCuotas()
            {
                grdCuotas.DataSource = feeService.GetByPolicyId(policyId).ToList();
                    //.Where(x => x.Estado !="Pagado")
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
                }


        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImporte.Text))
            {
                MessageBox.Show("Debe seleccionar una cuota.");
                return;
            }
            decimal value = decimal.Parse(txtImporte.Text);

            if (string.IsNullOrEmpty(this.txtNumeroRecibo.Text))
            {
                MessageBox.Show("Debe completar el campo Numero de Recibo.");
                return;
            }
            if (ReceiptExists())
            {
                MessageBox.Show("El numero de Recibo ya existe.");
                return;
            }

            if (grdCuotas.SelectedRows.Count > 1)
                foreach (DataGridViewRow row in grdCuotas.SelectedRows)
                {
                    currentFee = (FeeDto)row.DataBoundItem;
                    cobro = currentFee.Saldo;
                    CollectFee();
                    value -= cobro;
                }
            else
            {
                currentFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
                cobro = value;
                bool existsPrevRow = grdCuotas.CurrentRow.Index > 0;
                if (existsPrevRow)
                {
                    var previousFee = (FeeDto)grdCuotas.Rows[grdCuotas.CurrentRow.Index - 1].DataBoundItem;
                    if (previousFee.Estado != "Moroso" && previousFee.Estado != "Debe" && 
                        previousFee.Estado != "Observado" && currentFee.Estado != "Pagado")
                        CollectFee();
                    else
                        MessageBox.Show("Verifique su acción, la cuota anterior no se pagó");
                }
                else
                    CollectFee();
            }
            ClearForm();
        }

        private bool ReceiptExists()
        {
            var receipt = this.txtNumeroRecibo.Text;
            return this.cashAccountService.ReceiptExists(receipt);//SegguContainer.Instance.CashAccounts.Any(x => x.ReceiptNumber == receipt);
        }
            private void CollectFee()
            {
                if (cobro != 0 && currentFee.Saldo != 0)
                {
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
                        //if (existsNextRow && currentFee.Saldo != 0)
                        //    SumDiferenceToNextFee();
                        //printService.PrintReceipt(ConvertCurrentFeeToFeeChargeDto(currentFee, value));
                    }
                }
                else
                    MessageBox.Show("Verifique su acción, el importe no puede ser 0,"+
                        " o la cuota ya está pagada, o la cuota anterior no se pagó");
            }
                private void UpdateFeeAndSaveCollection()
                {
                    PrepareFeeToUpdate();
                    feeService.Update(currentFee);
                    SaveFeeInCashAccount(currentFee);            
                }
                    private void PrepareFeeToUpdate()
                    {
                        if (cobro >= currentFee.Saldo)
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

                        selectedAsset.Amount = AssetTotal + cobro;
                        assetService.Update(selectedAsset);

                        obj.Balance = selectedAsset.Amount;
                        obj.FeeId = fee.Id;
                        this.cashAccountService.Save(obj);
                    }
                private void SumDiferenceToNextFee()
                {
                    short feeNumber = short.Parse(currentFee.Cuota);                
                    grdCuotas.CurrentCell = grdCuotas[7, feeNumber];
                    var nextFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
                    nextFee.Valor += currentFee.Saldo;
                    nextFee.Saldo = nextFee.Valor;
                    feeService.Update(nextFee);
                }
                private FeeChargeDto ConvertCurrentFeeToFeeChargeDto(FeeDto currentFee, decimal value)
                {
                    currentFee = (FeeDto)grdCuotas.CurrentRow.DataBoundItem;
                    var vehicle = vehicleService.GetByPolicyId(currentFee.PolicyId);
                    var policy = policyService.GetById(currentFee.PolicyId);
                    var dto = new FeeChargeDto()
                    {
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
            private void ClearForm()
                    {
                        txtImporte.Clear();
                        txtNumeroRecibo.Clear();
                        grdCuotas.Refresh();
                    }


        private void btnPDF_Click(object sender, EventArgs e)
        {
            decimal value = decimal.Parse(txtImporte.Text);
            printService.PrintReceipt(ConvertCurrentFeeToFeeChargeDto(currentFee, value));
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(e);
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

        private void grdCuotas_SelectionChanged(object sender, EventArgs e)
        {
            decimal value = 0;
            foreach (DataGridViewRow row in grdCuotas.SelectedRows)
            {
                var fee = (FeeDto)row.DataBoundItem;
                value += fee.Saldo;
            }
            txtImporte.Text = value.ToString();

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
        }

    }
}
