using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{
    public partial class LiquidacionesUserControl : UserControl
    {
        private ICompanyService companyService;
        private ILiquidationService liquidationService;
        private IFeeSelectionService feeSelectionService;
        private IFeeService feeService;
        private IPrintService printService;
        private LiquidationDto currentLiquidation;
        private FeeSelectionDto selectedFeeSelection;
        private CompanyDto currentCompany;
        private List<FeeDto> payedFeeList = new List<FeeDto>();
        private List<FeeDto> candidateFeeList = new List<FeeDto>();
        private bool isNewFeeSelection = false;

        public LiquidacionesUserControl(ILiquidationService liquidationService, ICompanyService companySevice
            , IFeeSelectionService feeSelectionService, IFeeService feeService, IPrintService printService)
        {
            InitializeComponent();
            this.companyService = companySevice;
            this.liquidationService = liquidationService;
            this.feeSelectionService = feeSelectionService;
            this.feeService = feeService;
            this.printService = printService;
            InitializeComboboxes();
            DisableFeeTabControls();
            InitializeIndex();
        }
        private void InitializeComboboxes()
        {
            cmbCompañia.ValueMember = "Id";
            cmbCompañia.DisplayMember = "Name";
            cmbCompañia.DataSource = companyService.GetAll().OrderBy(x => x.Name).ToList();
        }
        private void InitializeIndex()
        {
            grdLiquidaciones.DataSource = liquidationService.GetAll().ToList();
            grdLiquidaciones.Columns["Notas"].Visible = false;
            grdLiquidaciones.Columns["Id"].Visible = false;
            grdLiquidaciones.Columns["CompanyId"].Visible = false;
            tbcLiquidationIndex.SelectedIndex = 0;
            grdLiquidaciones.Select();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            CleanDataSourceGrid();
            NavigateToCuotas();
            DisableFeeTabControls();
            cmbCompañia.Enabled = true;
            cmbCompañia.Text = "Elegir compañía";
            splitContainer1.Panel1Collapsed = false;
            CreateNewCurrentLiquidationObject();
        }
        private void CleanDataSourceGrid()
        {
            grdLiquidaciones.DataSource = null;
            grdFeeSelections.DataSource = null;
            grdSelectedFees.DataSource = null;
            grdCandidateFees.DataSource = null;
        }
        private void NavigateToCuotas()
        {
            tbcLiquidationIndex.SelectedIndex = 1;
        }
        private void DisableFeeTabControls()
        {
            cmbCompañia.Enabled = false;
            dtpConvenio.Enabled = false;
            dtpInicio.Enabled = false;
            dtpFin.Enabled = false;
            txtSelectionName.Enabled = false;
            label6.Enabled = false;
            btnGuardarSeleccion.Enabled = false;
            btnEdit.Visible = false;
            txtNotes.Enabled = false;
        }
        private void CreateNewCurrentLiquidationObject()
        {
            currentLiquidation = new LiquidationDto();
            //currentLiquidation.Id = Guid.NewGuid().ToString();//necesito el Id sin tener que traer el obj guardado con su nuevo Id
            currentLiquidation.Fecha = DateTime.Now.ToShortDateString();
            currentLiquidation.Total = 0;
            currentLiquidation.Registered = false;
        }


        private void cmbCompañia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetConvenioAndDateRange();
            EnableFeeTabControls();
            dtpFin_CloseUp(sender, e);
        }
        private void EnableFeeTabControls()
        {
            dtpConvenio.Enabled = true;
            dtpInicio.Enabled = true;
            dtpFin.Enabled = true;
            label6.Enabled = true;
            txtSelectionName.Enabled = true;
            btnGuardarSeleccion.Enabled = true;
            txtNotes.Enabled = true;
        }
        private void SetConvenioAndDateRange()
        {
            DateTime fechaInicio, fechaFin, fechaConvenio;
            currentLiquidation.CompanyId = (int)cmbCompañia.SelectedValue;
            currentCompany = companyService.GetById(currentLiquidation.CompanyId);
            int today = DateTime.Today.Day;
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            int dia1 = string.IsNullOrEmpty(currentCompany.LiqDay1) ? 1 : int.Parse(currentCompany.LiqDay1);
            int dia2 = string.IsNullOrEmpty(currentCompany.LiqDay2) ? 15 : int.Parse(currentCompany.LiqDay2);
            int convenio1 = string.IsNullOrEmpty(currentCompany.Convenio1) ? 25 : int.Parse(currentCompany.Convenio1);
            int convenio2 = string.IsNullOrEmpty(currentCompany.Convenio2) ? 10 : int.Parse(currentCompany.Convenio2);
            if (today <= convenio1 && today >= convenio2)
            {
                fechaConvenio = new DateTime(year, month, convenio1);
                fechaInicio = new DateTime(year, month, dia1);
                fechaFin = new DateTime(year, month, dia2);
            }
            else if (today > convenio1)
            {
                fechaConvenio = new DateTime(year, month, convenio2);
                fechaInicio = new DateTime(year, month, dia2 + 1);
                fechaFin = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
            else
            {
                fechaConvenio = new DateTime(year, month, convenio2);
                fechaInicio = new DateTime(year, fechaConvenio.AddMonths(-1).Month, dia2 + 1);
                int lastDayOfMonth = DateTime.DaysInMonth(year, fechaConvenio.AddMonths(-1).Month);
                fechaFin = new DateTime(year, fechaConvenio.AddMonths(-1).Month, lastDayOfMonth);
            }

            dtpConvenio.Value = fechaConvenio;
            dtpInicio.Value = fechaInicio;
            dtpFin.Value = fechaFin;
        }
        private void dtpFin_CloseUp(object sender, EventArgs e)
        {
            FillGrids();
        }
        private void FillGrids()
        {
            var companyId = (int)cmbCompañia.SelectedValue;
            var dateFrom = dtpInicio.Value;
            var dateTo = dtpFin.Value;

            candidateFeeList = feeService.GetCandidatesByCompany(companyId, dateFrom, dateTo).ToList();
            candidateFeeList.RemoveAll(x => x.Estado == "Pagado");
            grdCandidateFees.DataSource = candidateFeeList;
            FormatCandidateFeesGrid();

            payedFeeList = feeService.GetPayedByCompany(companyId, dateFrom, dateTo).ToList();
            grdSelectedFees.DataSource = payedFeeList;
            FormatSelectedFeesGrid();

            lblLiquidacion.Text = grdCandidateFees.RowCount.ToString();
        }
        private void FormatCandidateFeesGrid()
        {
            grdCandidateFees.Columns["Id"].Visible = false;
            grdCandidateFees.Columns["PolicyId"].Visible = false;
            grdCandidateFees.Columns["FeeSelectionId"].Visible = false;
            grdCandidateFees.Columns["CompanyId"].Visible = false;
            grdCandidateFees.Columns["Annulated"].Visible = false;
            grdCandidateFees.Columns["EndorseId"].Visible = false;
        }
        private void FormatSelectedFeesGrid()
        {
            grdSelectedFees.Columns["Id"].Visible = false;
            grdSelectedFees.Columns["CompanyId"].Visible = false;
            grdSelectedFees.Columns["PolicyId"].Visible = false;
            grdSelectedFees.Columns["FeeSelectionId"].Visible = false;
            grdSelectedFees.Columns["Annulated"].Visible = false;
            grdSelectedFees.Columns["EndorseId"].Visible = false;
        }


        private void grdCandidateFees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MoveSelectedFeeRows();
        }
        private void MoveSelectedFeeRows()
        {
            payedFeeList.Insert(0, (FeeDto)grdCandidateFees.CurrentRow.DataBoundItem);
            grdSelectedFees.DataSource = null;
            grdSelectedFees.DataSource = payedFeeList.OrderBy(x => x.Cliente).ToList();
            FormatSelectedFeesGrid();

            candidateFeeList.Remove((FeeDto)grdCandidateFees.CurrentRow.DataBoundItem);
            grdCandidateFees.DataSource = null;
            grdCandidateFees.DataSource = candidateFeeList;
            FormatCandidateFeesGrid();
        }


        private void btnGuardarSeleccion_Click(object sender, EventArgs e)
        {
            liquidationService.Save(currentLiquidation);

            var FeeSelection = currentLiquidation.Total == 0 || isNewFeeSelection ?
                CreateNewFeeSelection()
                :
                UpdateFeeSelection(selectedFeeSelection);
            UpdateFees(FeeSelection.Id);

            InitializeIndex();
            UpdateLiquidationTotal();
            DisableFeeTabControls();
        }
        private void UpdateLiquidationTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in grdFeeSelections.Rows)
            {
                total += (decimal)row.Cells["Total"].Value;
            }
            currentLiquidation.Total = total;
            liquidationService.Save(currentLiquidation);
        }
        private FeeSelectionDto CreateNewFeeSelection()
        {
            FeeSelectionDto newFeeSelection = new FeeSelectionDto();
            newFeeSelection.Name = string.IsNullOrEmpty(txtSelectionName.Text) ? DateTime.Now.ToString() : txtSelectionName.Text;
            newFeeSelection.LiquidationId = currentLiquidation.Id;
            foreach (DataGridViewRow row in grdSelectedFees.Rows)
                newFeeSelection.Total += (decimal)row.Cells["Pago_Cía"].Value;
            newFeeSelection.Id = feeSelectionService.Save(newFeeSelection);
            return newFeeSelection;
        }
        private FeeSelectionDto UpdateFeeSelection(FeeSelectionDto _selectedFeeSelection)
        {
            _selectedFeeSelection.Total = 0;
            _selectedFeeSelection.Notes = txtNotes.Text;
            _selectedFeeSelection.Name = txtSelectionName.Text;
            foreach (DataGridViewRow row in grdSelectedFees.Rows)
                _selectedFeeSelection.Total += (decimal)row.Cells["Pago_Cía"].Value;
            feeSelectionService.Save(_selectedFeeSelection);
            return _selectedFeeSelection;
        }
        private void UpdateFees(int FeeSelectionId)
        {
            List<FeeDto> fees = new List<FeeDto>();
            foreach (DataGridViewRow row in grdSelectedFees.Rows)
            {
                grdSelectedFees.CurrentCell = grdSelectedFees[2, row.Index];
                var fee = (FeeDto)grdSelectedFees.CurrentRow.DataBoundItem;
                fee.FeeSelectionId = FeeSelectionId;
                fee.Estado = fee.Saldo > 0 ? "Debe y Preliq" : "Preliquidado";
                fees.Add(fee);
            }
            feeService.UpdateMany(fees);
        }



        private void grdFeeSelections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            GetFeesByFeeSelectionIdAndFillCuotasTab();
        }
        private void GetFeesByFeeSelectionIdAndFillCuotasTab()
        {
            payedFeeList = this.feeService.GetByFeeSelectionId(selectedFeeSelection.Id).ToList();
            grdSelectedFees.DataSource = payedFeeList;
            PopulateFeeTab();
        }
        private void PopulateFeeTab()
        {
            DisableFeeTabControls();
            btnEdit.Visible = true;
            FormatSelectedFeesGrid();
            cmbCompañia.SelectedValue = currentCompany.Id;
            txtSelectionName.Text = selectedFeeSelection.Name;
            NavigateToCuotas();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableFeeTabControls();
            btnEdit.Enabled = false;

            DateTime dateFrom, dateTo, fechaConvenio;
            splitContainer1.Panel1Collapsed = false;
            SetCurrentLiquidationDates(out dateFrom, out dateTo, out fechaConvenio);
            //AddCheckBox();
            GetCurrentLiquidationCandidates(dateFrom, dateTo);
            SetDateTimePickers(dateFrom, dateTo, fechaConvenio);
        }
        private void SetCurrentLiquidationDates(out DateTime dateFrom, out DateTime dateTo, out DateTime fechaConvenio)
        {
            fechaConvenio = DateTime.Parse(currentLiquidation.Fecha);
            int year = fechaConvenio.Year;
            int month = fechaConvenio.Month;

            if (fechaConvenio.Day < 16)
            {
                if (month == 1)
                    year = fechaConvenio.AddYears(-1).Year;
                month = fechaConvenio.AddMonths(-1).Month;
                int lastDayOfMonth = DateTime.DaysInMonth(year, month);

                dateFrom = new DateTime(year, month, 16);
                dateTo = new DateTime(year, month, lastDayOfMonth);
            }
            else
            {
                dateFrom = new DateTime(year, month, 1);
                dateTo = new DateTime(year, month, 15);
            }
        }
        private void AddCheckBox()
        {
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            grdCandidateFees.Columns.Add(CheckboxColumn);
        }
        private void GetCurrentLiquidationCandidates(DateTime dateFrom, DateTime dateTo)
        {
            candidateFeeList = feeService.GetCandidatesByCompany(currentLiquidation.CompanyId, dateFrom, dateTo).ToList();
            grdCandidateFees.DataSource = candidateFeeList;
            FormatCandidateFeesGrid();
        }
        private void SetDateTimePickers(DateTime dateFrom, DateTime dateTo, DateTime fechaConvenio)
        {
            dtpConvenio.Value = fechaConvenio;
            dtpInicio.Value = dateFrom;
            dtpFin.Value = dateTo;
        }


        private void grdLiquidaciones_SelectionChanged(object sender, EventArgs e)
        {
            //if (!grdLiquidaciones.Focused) return;
            currentLiquidation = (LiquidationDto)grdLiquidaciones.CurrentRow.DataBoundItem;
            currentCompany = companyService.GetById(currentLiquidation.CompanyId);
            txtLiqNotes.DataBindings.Clear();
            txtLiqNotes.DataBindings.Add("Text", currentLiquidation, "Notas");

            grdFeeSelections.DataSource = feeSelectionService.GetByLiquidation(currentLiquidation.Id).ToList();
            grdFeeSelections.Columns["Id"].Visible = false;
            grdFeeSelections.Columns["LiquidationId"].Visible = false;

            selectedFeeSelection = grdFeeSelections.RowCount == 0 ? null : (FeeSelectionDto)grdFeeSelections.CurrentRow.DataBoundItem;
        }
        private void grdFeeSelections_SelectionChanged(object sender, EventArgs e)
        {
            selectedFeeSelection = (FeeSelectionDto)grdFeeSelections.CurrentRow.DataBoundItem;
        }
        private void txtSelectionName_Click(object sender, EventArgs e)
        {
            var escribaUnNombre = ": Escriba un nombre";
            txtSelectionName.Text = DateTime.Now.ToString() + escribaUnNombre;
            
            txtSelectionName.SelectionStart = txtSelectionName.Text.IndexOf(escribaUnNombre);
            txtSelectionName.SelectionLength = escribaUnNombre.Length;
            btnGuardarSeleccion.Enabled = true;
        }
        private void txtSelectionName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardarSeleccion_Click(sender, e);
                e.Handled = true;
            }
        }


        private void btnAgregarFeeSelection_Click(object sender, EventArgs e)
        {
            if (currentLiquidation.Registered) return;
            isNewFeeSelection = true;
            grdSelectedFees.DataSource = null;
            NavigateToCuotas();
            cmbCompañia.Enabled = true;
            cmbCompañia.SelectedValue = currentCompany.Id;
            btnEdit_Click(sender, e);
        }
        private void btnDeleteFeeSelection_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Eliminando esta Preliquidación, cambia el estado de las cuotas" +
                "¿Desea eliminar?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                DeleteFeeSelectionUpdatingFeeStates(selectedFeeSelection);
            InitializeIndex();
            UpdateLiquidationTotal();
        }
        private void btnDeleteLiquidation_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Al quitar una LIQUIDACIÓN se eliminan todas sus selecciones. " +
                "Se modificará el estado de las cuotas seleccionadas. ¿Desea esto?", "Borrar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var feeSelections = feeSelectionService.GetByLiquidation(currentLiquidation.Id).ToList();
                foreach (var feeSelection in feeSelections)
                {
                    DeleteFeeSelectionUpdatingFeeStates(feeSelection);
                }
                liquidationService.Delete(currentLiquidation);
            }

        }
        private void DeleteFeeSelectionUpdatingFeeStates(FeeSelectionDto feeSelection)
        {
            var fees = feeService.GetByFeeSelectionId(feeSelection.Id).ToList();
            foreach (var item in fees)
            {
                switch (item.Estado)
                {
                    case "Liquidado":
                        item.Estado = "Pagado"; break;
                    case "Preliquidado":
                        item.Estado = "Pagado"; break;
                    case "Debe y Preliq":
                        item.Estado = "Moroso"; break;
                    default: break;
                }
            }
            feeService.UpdateMany(fees);
            feeSelectionService.Delete(feeSelection);
        }
        private void btnSaveLiquidation_Click(object sender, EventArgs e)
        {
            liquidationService.Save(currentLiquidation);
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var feeSelections = feeSelectionService.GetByLiquidation(currentLiquidation.Id).ToList();
            foreach (var feeSelection in feeSelections)
            {
                var fees = feeService.GetByFeeSelectionId(feeSelection.Id).ToList();
                foreach (var fee in fees)
                {
                    fee.FeeSelectionId = feeSelection.Id;
                    fee.Estado = "Liquidado";
                    fee.Fecha_Liquidación = DateTime.Today.ToString();
                }
                feeService.UpdateMany(fees);
            }
            currentLiquidation.Registered = true;
            currentLiquidation.Recepción = DateTime.Today.ToString();
            liquidationService.Save(currentLiquidation);
            InitializeIndex();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<FeeDto> fees = (List<FeeDto>)grdSelectedFees.DataSource;
            printService.CreateFeesPdf(fees);
        }

        private void TogglePanel1()
        {
            Thread backgroundThread = new Thread(
                    new ThreadStart(() =>
                    {
                        if (splitContainer1.InvokeRequired)
                            splitContainer1.Invoke(new MethodInvoker(delegate
                            {
                                splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
                            }));
                    }
                    ));
            backgroundThread.Start();
        }
    }
}
