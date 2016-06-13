using Seggu.Dtos;
using Seggu.Services;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Seggu.Desktop.Forms
{
    public partial class ControlCaja : Form
    {
        private IAssetService assetService;
        private ILedgerAccountService ledgerAccountService;
        private ICashAccountService cashAccountService;
        private IProducerService producerService;
        private AssetDto firstSelectedAsset;
        private AssetDto selectedAsset;
        public ControlCaja(IAssetService assetService
            , ILedgerAccountService ledgerAccountService
            , ICashAccountService cashAccountService
            , IProducerService producerService)
        {
            InitializeComponent();
            this.assetService = assetService;
            this.ledgerAccountService = ledgerAccountService;
            this.cashAccountService = cashAccountService;
            this.producerService = producerService;
        }

        private void ControlCaja_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeComboboxes();
            InitializeIndex();
            InitializeTextCtrls();
        }

        private void InitializeComboboxes()
        {
            cmbActivos.DataSource = assetService.GetAll().ToList();
            cmbActivos.ValueMember = "Id";
            cmbActivos.DisplayMember = "Name";
            cmbActivos.SelectedIndex = -1;

            cmbCuentasContables.DataSource = ledgerAccountService.GetAll().ToList();
            cmbCuentasContables.ValueMember = "Id";
            cmbCuentasContables.DisplayMember = "Name";

            cmbCobrador.DataSource = producerService.GetCollectors().ToList();
            cmbCobrador.ValueMember = "Id";
            cmbCobrador.DisplayMember = "Name";
            cmbCobrador.SelectedIndex = 0;
        }
        private void InitializeIndex()
        {
            var table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Fecha", typeof(DateTime));
            table.Columns.Add("Activo");
            table.Columns.Add("Balance", typeof(decimal));
            table.Columns.Add("Cuenta");
            table.Columns.Add("Descripción");
            table.Columns.Add("Valor", typeof(decimal));

            var index = cashAccountService.GetAll();

            foreach (var x in index)
            {
                var row = table.NewRow();
                row["Id"] = x.Id;
                row["Activo"] = x.AssetName;
                row["Cuenta"] = x.LedgerAccountName;
                row["Fecha"] = x.Date;
                row["Descripción"] = x.Description;
                row["Valor"] = x.Amount;
                row["Balance"] = x.Balance;
                table.Rows.Add(row);
            }
            grdControlCaja.DataSource = table;
            FormatGrid();

            //txtDescripcion.DataBindings.Add("text", index, "Descripción");
            //txtValor.DataBindings.Add("text", index, "Valor");
            //cmbActivos.DataBindings.Add("text", index, "Activo");
            grdControlCaja.Select();
        }
        private void FormatGrid()
        {
            grdControlCaja.Columns["Fecha"].Width = 55;
            grdControlCaja.Columns["Activo"].Width = 80;
            grdControlCaja.Columns["Balance"].Width = 40;
            grdControlCaja.Columns["Cuenta"].Width = 45;
            grdControlCaja.Columns["Descripción"].Width = 100;
            grdControlCaja.Columns["Valor"].Width = 75;
            grdControlCaja.Columns["Id"].Visible = false;
            grdControlCaja.Columns["Valor"].DefaultCellStyle.Format = "c2";
            grdControlCaja.Columns["Balance"].DefaultCellStyle.Format = "c2";
        }
        private void InitializeTextCtrls()
        {
            grbTransfer.Visible = false;
            txtValor.Text = "Valor";
            txtDescripcion.Text = "Descripción";
            txtDescripcion.Enabled = true;
            errorProvider1.Clear();
            cmbCuentasContables.Text = "Cuentas Contables";
            cmbCuentasContables.Enabled = true;
            cmbCobrador.Enabled = true;
            cmbActivos.Text = "Activos";
            cmbAccion.Text = "Acción";
            lblBalance.Text = "";
            lblDestinyBalance.Text = "";
            lblOriginBalance.Text = "";
            //cmbDestinyAsset.SelectedIndex = 0;
            //cmbOriginAsset.SelectedIndex = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtActivos.Visible)
            {
                ToggleEditModeOff();
            }
            else
            {
                ToggleEditModeOn();
            }
        }
        private void ToggleEditModeOff()
        {
            //ShowAssetBalance();
            txtCuentas.Visible = false;
            txtActivos.Visible = false;
            btnActivos.Visible = false;
            btnCuentas.Visible = false;
            label2.Visible = true;
            cmbActivos.Visible = true;
            cmbCuentasContables.Visible = true;
            btnGuardar.Visible = true;
            dtpFechaTransaccion.Visible = true;
            cmbCobrador.Visible = true;
            txtDescripcion.Visible = true;
            cmbAccion.Visible = true;
            txtValor.Visible = true;
        }
        private void ToggleEditModeOn()
        {
            grbTransfer.Visible = false;
            lblBalance.Text = "";
            btnCuentas.Visible = true;
            txtCuentas.Visible = true;
            txtActivos.Visible = true;
            btnActivos.Visible = true;
            label2.Visible = false;
            cmbActivos.Visible = false;
            cmbCuentasContables.Visible = false;
            btnGuardar.Visible = false;
            dtpFechaTransaccion.Visible = false;
            cmbCobrador.Visible = false;
            txtDescripcion.Visible = false;
            cmbAccion.Visible = false;
            txtValor.Visible = false;
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            txtDescripcion.SelectionStart = 0;
            txtDescripcion.SelectionLength = txtDescripcion.Text.Length;
        }
        private void txtActivos_Click(object sender, EventArgs e)
        {
            txtActivos.SelectionStart = 0;
            txtActivos.SelectionLength = txtActivos.Text.Length;
            txtValor.Visible = true;
            txtValor.Text = "Valor inicial del activo";
            txtCuentas.Visible = false;
            btnCuentas.Visible = false;
        }
        private void txtCuentas_Click(object sender, EventArgs e)
        {
            txtCuentas.SelectionStart = 0;
            txtCuentas.SelectionLength = txtCuentas.Text.Length;
            txtActivos.Visible = false;
            btnActivos.Visible = false;
            txtValor.Visible = false;
        }
        private void txtValor_Click(object sender, EventArgs e)
        {
            txtValor.SelectionStart = 0;
            txtValor.SelectionLength = txtValor.Text.Length;
        }
        private void txtTransferValue_Click(object sender, EventArgs e)
        {
            txtTransferValue.SelectionStart = 0;
            txtTransferValue.SelectionLength = txtTransferValue.Text.Length;
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            string str = txtValor.Text;
            int num;
            bool isNume = int.TryParse(str, out num);

            if (txtActivos.Text != "Nuevo Activo")
            {
                if (isNume)
                {
                    AssetDto obj = new AssetDto();
                    obj.Name = txtActivos.Text.Trim();
                    obj.Amount = num;
                    assetService.Create(obj);
                    txtValor.Text = "Valor";
                    txtActivos.Text = "Nuevo Activo";
                    cmbActivos.DataSource = null;
                    InitializeComboboxes();
                    btnEditar.PerformClick();
                    errorProvider1.Clear();
                }
                else
                    errorProvider1.SetError(txtValor, "ingrese un número solamente");
            }
        }
        private void btnCuentas_Click(object sender, EventArgs e)
        {
            if (txtCuentas.Text != "Nueva Cuenta Contable")
            {
                // insertar en Legderaccount
                LedgerAccountDto obj = new LedgerAccountDto();
                obj.Name = txtCuentas.Text.Trim();
                ledgerAccountService.Create(obj);
                txtCuentas.Text = "Nueva Cuenta Contable";
                cmbCuentasContables.DataSource = null;
                InitializeComboboxes();
                btnEditar.PerformClick();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string accion = cmbAccion.Text;
            string num = txtValor.Text;
            decimal valor;
            bool isNume = decimal.TryParse(num, out valor);
            if (isNume)
            {
                if (cmbActivos.Text.Trim() != "Activos" && cmbActivos.Text.Trim() != ""
                    && cmbCuentasContables.Text.Trim() != "Cuentas Contables" && cmbCuentasContables.Text.Trim() != ""
                    && txtDescripcion.Text.Trim() != "Descripción" && txtDescripcion.Text.Trim() != ""
                    && cmbAccion.Text.Trim() != "Acción" && cmbAccion.Text.Trim() != ""
                    && txtValor.Text.Trim() != "Valor" && txtValor.Text.Trim() != "")
                {
                    SaveTransaction(accion, valor);
                    Initialize();
                    
                }
                else
                    errorProvider1.SetError(txtValor, "Verifique que todos los campos tengan el dato correcto");
            }
            else
                errorProvider1.SetError(txtValor, "ingrese un número solamente");
        }
        private void SaveTransaction(string accion, decimal valor)
        {
            decimal AssetTotal = selectedAsset.Amount;

            CashAccountDto cashAccount = new CashAccountDto();
            cashAccount.Amount = valor;
            cashAccount.AssetId = selectedAsset.Id;
            cashAccount.Date = dtpFechaTransaccion.Value;
            cashAccount.LedgerAccountId = (int)cmbCuentasContables.SelectedValue;
            cashAccount.Description = txtDescripcion.Text.Trim();
            cashAccount.ProducerId = (int)cmbCobrador.SelectedValue;
            // ver que accion y determinar si suma resta o ajusta
            switch (accion)
            {
                case "Pago": selectedAsset.Amount = AssetTotal - valor;
                    break;
                case "Depósito": selectedAsset.Amount = AssetTotal + valor;
                    break;
                case "Ajuste": selectedAsset.Amount = valor;
                    break;
                case "Transferencia": CreateSecondCashaccountForTransfer(valor, selectedAsset, cashAccount);
                    break;
            }
            assetService.Update(selectedAsset);
            cashAccount.Balance = selectedAsset.Amount;
            this.cashAccountService.Save(cashAccount);
        }
        private void CreateSecondCashaccountForTransfer(decimal valor, AssetDto selectedAsset, CashAccountDto cashAccount1)
        {
            CashAccountDto cashAccount2 = new CashAccountDto();
            cashAccount2.Amount = valor;
            cashAccount2.AssetId = firstSelectedAsset.Id;
            cashAccount2.Date = cashAccount1.Date;
            cashAccount2.LedgerAccountId = cashAccount1.LedgerAccountId;
            cashAccount2.Description = firstSelectedAsset.Name + "/" + selectedAsset.Name;
            cashAccount2.ProducerId = cashAccount1.ProducerId;
            cashAccount1.Description = cashAccount2.Description;

            selectedAsset.Amount += valor;
            firstSelectedAsset.Amount -= valor;
            assetService.Update(firstSelectedAsset);

            cashAccount2.Balance = firstSelectedAsset.Amount;
            cashAccountService.Save(cashAccount2);
        }

        private void cmbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            switch (cmbAccion.Text)
            {
                case "Pago":
                    InitializeTextCtrls();
                    break;
                case "Depósito":
                    InitializeTextCtrls();
                    break;
                case "Ajuste":
                    SetAdjustCtrls();
                    break;
                case "Transferencia":
                    SetTransferCtrls();
                    break;
            }
        }
        private void SetAdjustCtrls()
        {
            grbTransfer.Visible = false;
            txtDescripcion.Text = "Ajuste";
            txtDescripcion.Enabled = false;
            cmbCuentasContables.SelectedIndex = cmbCuentasContables.FindString("Ajuste");
            cmbCuentasContables.Text = "Ajuste";
            cmbCuentasContables.Enabled = false;
        }
        private void SetTransferCtrls()
        {
            grbTransfer.Visible =  true;

            cmbOriginAsset.DataSource = assetService.GetAll().ToList();
            cmbOriginAsset.ValueMember = "Id";
            cmbOriginAsset.DisplayMember = "Name";

            cmbDestinyAsset.DataSource = assetService.GetAll().ToList();
            cmbDestinyAsset.ValueMember = "Id";
            cmbDestinyAsset.DisplayMember = "Name";

            txtDescripcion.Text = "Transferencia";
            dtpFechaTransaccion.Enabled = false;
            cmbCuentasContables.SelectedIndex = cmbCuentasContables.FindString("Transferencia");
        }

        private void cmbActivos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedAsset = (AssetDto)cmbActivos.SelectedItem;
            lblBalance.Text = selectedAsset.Amount.ToString();

        }
        private void cmbDestinyAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAsset = (AssetDto)cmbDestinyAsset.SelectedItem;
            lblDestinyBalance.Text = selectedAsset.Amount.ToString();
        }
        private void cmbOriginAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            firstSelectedAsset = (AssetDto)cmbOriginAsset.SelectedItem;
            lblOriginBalance.Text = firstSelectedAsset.Amount.ToString();
        }

        private void btnSaveTransfer_Click(object sender, EventArgs e)
        {
            string num = txtTransferValue.Text;
            decimal valor;
            bool isNume = decimal.TryParse(num, out valor);
            if (isNume)
            {
                SaveTransaction("Transferencia", valor);
                Initialize();
            }
        }

        //bool IsValid()
        //{
        //    foreach (Control c in errorProvider1.ContainerControl.Controls)
        //        if (errorProvider1.GetError(c) != "")
        //            return false;
        //    return true;
        //}
    }
}
