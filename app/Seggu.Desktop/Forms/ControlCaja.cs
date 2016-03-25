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
            InitializeComboboxes();
            InitializeIndex();
        }
        private void InitializeComboboxes()
        {
            cmbActivos.DataSource = assetService.GetAll().ToList();
            cmbActivos.ValueMember = "Id";
            cmbActivos.DisplayMember = "Name";

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
            table.Columns.Add("Activo");
            table.Columns.Add("Cuenta");
            table.Columns.Add("Fecha", typeof(DateTime));
            table.Columns.Add("Descripción");
            table.Columns.Add("Valor", typeof(int));
            table.Columns.Add("Balance", typeof(float));

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
            grdControlCaja.Columns["Id"].Visible = false;
            grdControlCaja.Columns["Balance"].DefaultCellStyle.Format = "#.##";

            //txtDescripcion.DataBindings.Add("text", index, "Descripción");
            //txtValor.DataBindings.Add("text", index, "Valor");
            //cmbActivos.DataBindings.Add("text", index, "Activo");
            grdControlCaja.Select();
            CleanTxts();
        }
        private void CleanTxts()
        {
            txtValor.Text = "Valor";
            txtDescripcion.Text = "Descripción";
            txtDescripcion.Enabled = true;
            errorProvider1.Clear();
            cmbCuentasContables.Text = "Cuentas Contables";
            cmbCuentasContables.Enabled = true;
            cmbCobrador.Enabled = true;
            //cmbCobrador.SelectedIndex = cmbCobrador.FindString("OF");
            cmbActivos.Text = "Activos";
            cmbAccion.Text = "Acción";
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtActivos.Visible)
            {
                txtCuentas.Visible = false;
                txtActivos.Visible = false;
                btnActivos.Visible = false;
                btnCuentas.Visible = false;
                cmbActivos.Visible = true;
                cmbCuentasContables.Visible = true;
                btnGuardar.Visible = true;
                dtpFechaTransaccion.Visible = true;
                cmbCobrador.Visible = true;
                txtDescripcion.Visible = true;
                cmbAccion.Visible = true;
                txtValor.Visible = true;
            }
            else
            {
                btnCuentas.Visible = true;
                txtCuentas.Visible = true;
                txtActivos.Visible = true;
                btnActivos.Visible = true;
                cmbActivos.Visible = false;
                cmbCuentasContables.Visible = false;
                btnGuardar.Visible = false;
                dtpFechaTransaccion.Visible = false;
                cmbCobrador.Visible = false;
                txtDescripcion.Visible = false;
                cmbAccion.Visible = false;
                txtValor.Visible = false;
            }
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
                    cmbActivos.DataSource = null;
                    txtValor.Text = "Valor";
                    txtActivos.Text = "Nuevo Activo";
                    btnEditar.PerformClick();
                    InitializeComboboxes();
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
                cmbCuentasContables.DataSource = null;
                txtCuentas.Text = "Nueva Cuenta Contable";
                btnEditar.PerformClick();
                btnEditar.PerformClick();
                InitializeComboboxes();
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string accion = cmbAccion.Text;
            string num = txtValor.Text;
            int valor;
            bool isNume = int.TryParse(num, out valor);
            if (isNume)
            {
                if (cmbActivos.Text.Trim() != "Activos" && cmbActivos.Text.Trim() != ""
                    && cmbCuentasContables.Text.Trim() != "Cuentas Contables" && cmbCuentasContables.Text.Trim() != ""
                    && txtDescripcion.Text.Trim() != "Descripción" && txtDescripcion.Text.Trim() != ""
                    && cmbAccion.Text.Trim() != "Acción" && cmbAccion.Text.Trim() != ""
                    && txtValor.Text.Trim() != "Valor" && txtValor.Text.Trim() != "")
                {
                    SaveTransaction(accion, valor);
                    InitializeIndex();
                }
                else
                    errorProvider1.SetError(txtValor, "Verifique que todos los campos tengan el dato correcto");
            }
            else
                errorProvider1.SetError(txtValor, "ingrese un número solamente");
        }
        private void SaveTransaction(string accion, int valor)
        {
            AssetDto selectedAsset = (AssetDto)cmbActivos.SelectedItem;
            decimal AssetTotal = selectedAsset.Amount;

            CashAccountDto obj = new CashAccountDto();
            obj.Amount = valor;
            obj.AssetId = (int)cmbActivos.SelectedValue;
            obj.Date = dtpFechaTransaccion.Value;
            obj.LedgerAccountId = (int)cmbCuentasContables.SelectedValue;
            obj.Description = txtDescripcion.Text.Trim();
            obj.ProducerId = (int)cmbCobrador.SelectedValue;
            // ver que accion y determinar si suma resta o ajusta
            switch (accion)
            {
                case "Pago": selectedAsset.Amount = AssetTotal - valor;
                    break;
                case "Depósito": selectedAsset.Amount = AssetTotal + valor;
                    break;
                case "Ajuste": selectedAsset.Amount = valor;
                    break;
                case "Transferencia": CreateSecondCashaccountForTransfer(valor, selectedAsset, obj);
                    break;
            }
            assetService.Update(selectedAsset);
            obj.Balance = selectedAsset.Amount;
            this.cashAccountService.Save(obj);
        }
        private void CreateSecondCashaccountForTransfer(int valor, AssetDto selectedAsset, CashAccountDto obj)
        {
            CashAccountDto cashAcc1 = new CashAccountDto();
            cashAcc1.Amount = valor;
            cashAcc1.AssetId = firstSelectedAsset.Id;
            cashAcc1.Date = obj.Date;
            cashAcc1.LedgerAccountId = obj.LedgerAccountId;
            cashAcc1.Description = firstSelectedAsset.Name + "/" + selectedAsset.Name;
            cashAcc1.ProducerId = obj.ProducerId;
            obj.Description = cashAcc1.Description;

            selectedAsset.Amount += valor;
            firstSelectedAsset.Amount -= valor;
            assetService.Update(firstSelectedAsset);

            cashAcc1.Balance = firstSelectedAsset.Amount;
            cashAccountService.Save(cashAcc1);
        }


        private void cmbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccion.Text == "Ajuste")
            {
                txtDescripcion.Text = "Ajuste";
                txtDescripcion.Enabled = false;
                cmbCuentasContables.SelectedIndex = cmbCuentasContables.FindString("Ajuste");
                cmbCuentasContables.Enabled = false;
            }
            else if (cmbAccion.Text == "Transferencia")
            {
                firstSelectedAsset = (AssetDto)cmbActivos.SelectedItem;
                txtDescripcion.Text = "Transferencia";
                txtDescripcion.Enabled = false;
                dtpFechaTransaccion.Enabled = false;
                cmbCobrador.Enabled = false;
                cmbCuentasContables.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void cmbActivos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
        }

    }
}
