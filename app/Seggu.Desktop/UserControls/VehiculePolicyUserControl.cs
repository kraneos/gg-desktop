using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using Seggu.Helpers;

namespace Seggu.Desktop.UserControls
{
    public partial class VehiculePolicyUserControl : UserControl
    {
        private IVehicleService vehicleService;
        private ICoverageService coverageService;
        private IBrandService brandService;
        private IBodyworkService bodyworkService;
        private IVehicleModelService vehicleModelService;
        private IUseService useService;
        private IVehicleTypeService vehicleTypeService;
        private IMasterDataService masterDataService;
        private IAccessoryTypeService accessoryTypeService;
        private IAccessoryService accessoryService;
        private VehicleModelDto currentModel;
        private VehicleDto currentVehicle;
        public List<VehicleDto> vehicleList = new List<VehicleDto>();
        private bool changesDetected = false;
        private BindingSource accessoriesBindingSource = new BindingSource();

        public VehiculePolicyUserControl(IVehicleService vehicleService, ICoverageService coverageService
            , IBrandService brandService, IBodyworkService bodyworkService, IVehicleModelService vehicleModelService
            , IUseService useService, IVehicleTypeService vehicleTypeService, IMasterDataService masterDataService
            , IAccessoryTypeService accessoryTypeService, IAccessoryService accessoryService)
        {
            InitializeComponent();
            this.vehicleService = vehicleService;
            this.coverageService = coverageService;
            this.brandService = brandService;
            this.bodyworkService = bodyworkService;
            this.vehicleModelService = vehicleModelService;
            this.useService = useService;
            this.vehicleTypeService = vehicleTypeService;
            this.masterDataService = masterDataService;
            this.accessoryTypeService = accessoryTypeService;
            this.accessoryService = accessoryService;
        }

        public Layout LayoutForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

        DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
        public void InitializeComboboxes(int riskId)
        {
            cmbCoberturas.ValueMember = "Id";
            cmbCoberturas.DisplayMember = "Name";
            //cmbCoberturas.DataSource = this.coveragesPackService.GetAllByRiskIdCombobox(riskId).ToList();// selectedCompany.Risks
            //.Single(r => r.Id == riskId)
            //.CoveragesPacks
            //.OrderBy(cp => cp.Name)
            //.ToList();
            cmbCoberturas.DataSource = coverageService.GetAllByRiskId(riskId).ToList();

            cmbMarcas.ValueMember = "Id";
            cmbMarcas.DisplayMember = "Name";
            cmbMarcas.DataSource = brandService.GetAll().ToList();
            FillModelsByBrandId();

            cmbTipoVehiculo.ValueMember = "Id";
            cmbTipoVehiculo.DisplayMember = "Name";
            cmbTipoVehiculo.DataSource = vehicleTypeService.GetAll().ToList();

            cmbOrigen.DataSource = masterDataService.GetVehicleOrigin().ToList();
            //comboBoxColumn = (DataGridViewComboBoxColumn)grdAccessories.Columns[0];
            comboBoxColumn.DataSource = accessoryTypeService.GetAll().ToList();
            comboBoxColumn.ValueMember = "Id";
            comboBoxColumn.DisplayMember = "Name";
            //grdAccessories.Columns.Add(comboBoxColumn);
        }
        private void FillModelsByBrandId()
        {
            cmbModelos.ValueMember = "Id";
            cmbModelos.DisplayMember = "Name";
            cmbModelos.DataSource = vehicleModelService.GetByBrand((int)cmbMarcas.SelectedValue).ToList();
        }

        public void PopulateEndorseVehicle()
        {
            if (LayoutForm.currentEndorse.Vehicles == null || LayoutForm.currentEndorse.Vehicles.Count() == 0) return;
            vehicleList = LayoutForm.currentEndorse.Vehicles
                .Where(v => v.IsRemoved == false).ToList();
            grdVehicles.DataSource = vehicleList;
            FormatVehclesGrid();
            grdVehicles.CurrentCell = grdVehicles.Rows[0].Cells["Plate"];
            currentVehicle = (VehicleDto)grdVehicles.CurrentRow.DataBoundItem;
            PopulateVehicleFields();
        }
        public void PopulatePolicyVehicle()
        {
            if (LayoutForm.currentPolicy.Vehicles == null) return;
            vehicleList = LayoutForm.currentPolicy.Vehicles
                .Where(v => v.IsRemoved == false && v.EndorseId == null).ToList();
            grdVehicles.DataSource = vehicleList;
            FormatVehclesGrid();
            grdVehicles.CurrentCell = grdVehicles.Rows[0].Cells["Plate"];
            currentVehicle = (VehicleDto)grdVehicles.CurrentRow.DataBoundItem;
            PopulateVehicleFields();
        }
        private void FormatVehclesGrid()
        {
            foreach (DataGridViewColumn c in grdVehicles.Columns)
                c.Visible = false;
            grdVehicles.Columns["Plate"].Visible = true;
        }

        private void grdVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentVehicle = (VehicleDto)grdVehicles.CurrentRow.DataBoundItem;
            PopulateVehicleFields();
        }
        private void PopulateVehicleFields()
        {
            this.BackColor = Color.Transparent;
            btnAgregar.Text = "Guardar Cambios";

            this.txtAnio.Text = currentVehicle.Year;
            this.txtPatente.Text = currentVehicle.Plate;
            this.txtChasis.Text = currentVehicle.Chassis;
            this.txtMotor.Text = currentVehicle.Engine;
            this.cmbMarcas.SelectedValue = currentVehicle.BrandId;
            this.FillModelsByBrandId();
            this.cmbTipoVehiculo.SelectedValue = currentVehicle.VehicleTypeId;
            this.cmbOrigen.SelectedItem = currentVehicle.Origin;
            this.cmbModelos.SelectedValue = currentVehicle.ModelId;
            this.cmbBodyworks.SelectedValue = currentVehicle.BodyworkId;
            this.cmbUses.SelectedValue = currentVehicle.UseId;
            //if (currentVehicle.Coverages.Count() != 0)
            //    cmbCoberturas.SelectedValue = coveragesPackService.GetPackIdByCoverageId(currentVehicle.Coverages.FirstOrDefault().Id,
            //        currentVehicle.Coverages.FirstOrDefault().Risks);
            //if (currentVehicle.Accessories != null)
            //    FillAccessoriesGrid();
        }
        //private void FillAccessoriesGrid()
        //{
        //    var accessories = currentVehicle.Accessories;
        //    accessoriesBindingSource.DataSource = accessories; //uso BIndingSource para poder agregar un row al grid en la UI.
        //    grdAccessories.DataSource = accessoriesBindingSource;
        //    FormatAccessoriesGrid();
        //}
        //    private void FormatAccessoriesGrid()
        //{
        //    comboBoxColumn.DataPropertyName = "AccessoryTypeId";
        //    grdAccessories.Columns["AccessoryTypeId"].Visible = false;
        //    grdAccessories.Columns["Id"].Visible = false;
        //    grdAccessories.Columns["VehicleId"].Visible = false;
        //}        

        private void cmbMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
            FillModelsByBrandId();
        }
        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillBodyworks();
            FillUses();
        }
        private void cmbModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentModel = (VehicleModelDto)cmbModelos.SelectedItem;
            cmbOrigen.SelectedItem = currentModel.Origin;
            cmbTipoVehiculo.SelectedValue = currentModel.VehicleTypeId;

            FillBodyworks();
            FillUses();
        }
        private void FillBodyworks()
        {
            cmbBodyworks.ValueMember = "Id";
            cmbBodyworks.DisplayMember = "Name";
            cmbBodyworks.DataSource = currentModel.Bodyworks;
        }
        private void FillUses()
        {
            cmbUses.ValueMember = "Id";
            cmbUses.DisplayMember = "Name";
            cmbUses.DataSource = currentModel.Uses;
        }

        public VehicleDto GetFormInfo()
        {
            var dto = new VehicleDto();
            dto.Id = currentVehicle == null ? default(int) : currentVehicle.Id;
            dto.BodyworkId = (int)cmbBodyworks.SelectedValue;
            dto.BrandId = (int)cmbMarcas.SelectedValue;
            dto.Chassis = txtChasis.Text;
            dto.Engine = txtMotor.Text;
            dto.ModelId = (int)cmbModelos.SelectedValue;
            dto.Origin = cmbOrigen.SelectedValue.ToString();
            dto.Plate = txtPatente.Text;
            dto.UseId = (int)cmbUses.SelectedValue;
            dto.VehicleTypeId = (int)cmbTipoVehiculo.SelectedValue;
            dto.Year = txtAnio.Text;
            dto.EndorseId = currentVehicle == null ? null : currentVehicle.EndorseId;
            dto.PolicyId = LayoutForm.currentPolicy.Id;
            //dto.Coverages = coveragesPackService.GetById((int)cmbCoberturas.SelectedValue)
            //    .FirstOrDefault().Coverages;
            if (accessoriesBindingSource.DataSource != null)
                dto.Accessories = (List<AccessoryDto>)accessoriesBindingSource.List;
            return dto;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            currentVehicle = null;
            txtAnio.Text = "";
            txtChasis.Text = "";
            //txtContrato.Text = "";
            txtMotor.Text = "";
            //txtNroRecibo.Text = "";
            txtPatente.Text = "";
            btnAgregar.Text = "Agregar";
            accessoriesBindingSource.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (!this.ValidateChildren())
            {
                return;
            }
            if (!ValidateControls()) return;
            if (!changesDetected) return;

            string neededEndorseType = Seggu.Domain.EndorseType.Alta_Objetos.ToString();
            EndososUserControl endososUC = this.Parent.Parent.GetType().Equals(typeof(EndososUserControl)) ?
                (EndososUserControl)this.Parent.Parent : null;
            if (endososUC == null)
            {
                if (btnAgregar.Text == "Agregar" && CancelAction(neededEndorseType))
                    return;
            }
            else
            {
                if (LayoutForm.currentEndorse.Id == default(int))
                    endososUC.cmbTipoEndosos.SelectedItem = neededEndorseType;
                else
                    if (btnAgregar.Text == "Agregar" && LayoutForm.currentEndorse.Número != null)
                    {
                        string message = "Está queriendo agregar un vehículo a un ENDOSO ya creado que puede estar en la COMPAÑÍA" +
                            "\n Debería crear uno NUEVO. \n ¿Continúa?";
                        if (MessageBox.Show(message, "Aviso!", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
            }
            this.BackColor = Color.Transparent;
            AddToVehicleList();
            btnAgregar.Text = "Guardar cambios";
        }
        public bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            //foreach (TabPage tabPage in this.tabControl1.TabPages)
            //{
                //foreach (Control c in tabPage.Controls)
                //{
                    //if (c is TextBox)
                    //{
                    //    if (c == txtAnio || c == txtChasis || c == txtMotor || c == txtPatente)
                    //    {
                    //        if (string.IsNullOrWhiteSpace(c.Text))
                    //        {
                    //            errorProvider1.SetError(c, "Campo vacio");
                    //            ok = false;
                    //        }
                    //        else if (c == txtPatente)
                    //        {
                    //            if (!txtPatente.Text.IsPlateNumber())
                    //            {
                    //                errorProvider1.SetError(c, "Formato de patente inválido.");
                    //                ok = false;
                    //            }
                    //        }
                    //        else if (c == txtChasis)
                    //        {
                    //            if (!txtChasis.Text.IsVIN())
                    //            {
                    //                errorProvider1.SetError(c, "Formato de chasis inválido.");
                    //                ok = false;
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (c is ComboBox)
                    //        if (c == cmbBodyworks || c == cmbCoberturas || c == cmbMarcas || c == cmbModelos
                    //            || c == cmbOrigen || c == cmbTipoVehiculo)
                    //            if ((c as ComboBox).SelectedIndex == -1)
                    //            {
                    //                errorProvider1.SetError(c, "Debe seleccionar un elemento");
                    //                ok = false;
                    //            }
                    //}
                //}
            //}
            return ok;
        }
        public void AddToVehicleList()
        {
            var vehicle = GetFormInfo();
            bool isNew = !vehicleList.Any(v => v.Plate == vehicle.Plate);
            if (isNew)
            {
                vehicleList.Insert(0, vehicle);
                grdVehicles.DataSource = null;
                grdVehicles.DataSource = vehicleList;
                FormatVehclesGrid();
            }
            else
            {
                if (vehicleList.Any())
                {
                    var item = vehicleList.First(x => x.Plate == vehicle.Plate);
                    vehicleList.Remove(item);
                    vehicleList.Add(vehicle);
                }
            }
            currentVehicle = vehicle;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (vehicleList.Count() <= 1)
            {
                MessageBox.Show("Una póliza automotor debe tener al menos un vehículo asociado.");
                return;
            }
            string neededEndorseType = Seggu.Domain.EndorseType.Baja_Objetos.ToString();
            EndososUserControl endososUC = this.Parent.Parent.GetType().Equals(typeof(EndososUserControl)) ?
                (EndososUserControl)this.Parent.Parent : null;
            if (endososUC == null)
            {
                if (CancelAction(neededEndorseType))
                    return;
            }
            else
            {
                if (LayoutForm.currentEndorse.Id == default(int))
                    endososUC.cmbTipoEndosos.SelectedItem = neededEndorseType;
            }

            RemoveFromVehicleList();
            grdVehicles.CurrentCell = grdVehicles["Plate", 0];
            currentVehicle = (VehicleDto)grdVehicles.CurrentRow.DataBoundItem;
            PopulateVehicleFields();
        }
        private bool CancelAction(string neededEndorseType)
        {
            bool cancel = false;
            string message = "Recuerde que esta acción debe ser realizada mediante tipo endoso: " + neededEndorseType + " \n ¿Continúa?";
            if (!string.IsNullOrEmpty(LayoutForm.currentPolicy.Número))
                if (MessageBox.Show(message, "Aviso!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    cancel = false;
                else
                    cancel = true;
            return cancel;
        }
        private void RemoveFromVehicleList()
        {
            vehicleList.Remove(currentVehicle);
            grdVehicles.DataSource = null;
            grdVehicles.DataSource = vehicleList;
            FormatVehclesGrid();
        }

        public string GetSelectedPlate()
        {
            return txtPatente.Text;
        }

        #region Cambió el control
        private void cmbCoberturas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void cmbModelos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void cmbBodyworks_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }

        private void cmbTipoVehiculo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void cmbUses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void cmbOrigen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void txtMotor_ModifiedChanged(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void txtChasis_ModifiedChanged(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void txtAnio_ModifiedChanged(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void txtPatente_ModifiedChanged(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void grdAccessories_CurrentCellChanged(object sender, EventArgs e)
        {
            SetChangesDetected();
        }
        private void SetChangesDetected()
        {
            //tabPage1.BackColor = Color.Coral;
            this.BackColor = Color.Coral;
            btnAgregar.Text = btnAgregar.Text == "Agregar" ? "Agregar" : "Guardar cambios";
            changesDetected = true;
        }

        #endregion

        #region validaciones
        private void txtAnio_Leave(object sender, EventArgs e)
        {
            if (txtAnio.Text.Length != 4)
                MessageBox.Show("El año debe ser de cuatro digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ((int.Parse(txtAnio.Text) < 1950) || (int.Parse(txtAnio.Text) > DateTime.Today.Year))
                MessageBox.Show("El año debe estar entre 1950 y el actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void cmbMarcas_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbMarcas.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbMarcas, "Este campo es obligatorio.");
            }
        }
        private void txtMotor_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtMotor.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txtMotor, "Este campo es obligatorio.");
            }
        }
        private void txtChasis_Validating(object sender, CancelEventArgs e)
        {
            if (!this.txtChasis.Text.IsVIN())
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txtChasis, "Este campo debe tener un formato de chasis válido.");
            }
        }
        private void txtAnio_Validating(object sender, CancelEventArgs e)
        {
            if (txtAnio.Text.Length != 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txtAnio, "El año debe ser de cuatro digitos");
            }
            else if ((int.Parse(txtAnio.Text) < 1950) || (int.Parse(txtAnio.Text) > DateTime.Today.Year))
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txtAnio, "El año debe estar entre 1950 y el actual");
            }
        }
        private void cmbModelos_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbModelos.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbModelos, "Este campo es obligatorio.");
            }
        }
        private void cmbTipoVehiculo_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbTipoVehiculo.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbTipoVehiculo, "Este campo es obligatorio.");
            }
        }
        private void cmbBodyworks_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbBodyworks.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbBodyworks, "Este campo es obligatorio.");
            }
        }
        private void cmbUses_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbUses.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbUses, "Este campo es obligatorio.");
            }
        }
        private void cmbOrigen_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbOrigen.SelectedValue == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(this.cmbOrigen, "Este campo es obligatorio.");
            }
        }
        private void txtPatente_Validating(object sender, CancelEventArgs e)
        {
            if (!this.txtPatente.Text.IsPlateNumber())
            {
                e.Cancel = true;
                errorProvider1.SetError(this.txtPatente, "Este campo debe tener un formato de patente válido.");
            }
        }
        #endregion

    }
}
