using Seggu.Data;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class ModelosVehiculos : Form
    {
        private IVehicleTypeService vehicleTypeService;
        private IBrandService brandService;
        private IMasterDataService masterDataService;
        private IVehicleModelService vehicleModelService;
        private IBodyworkService bodyworkService;
        private VehicleModelDto currentModel;
        private bool editMode = false;
        private int currentBrandIndex;
        public ModelosVehiculos(IBrandService brandService, IVehicleTypeService vehicleTypeService,
            IMasterDataService masterDataService, IVehicleModelService vehicleModelService,
            IBodyworkService bodyworkService)
        {
            InitializeComponent();
            this.brandService = brandService;
            this.vehicleTypeService = vehicleTypeService;
            this.masterDataService = masterDataService;
            this.vehicleModelService = vehicleModelService;
            this.bodyworkService = bodyworkService;
            InitializeComboboxes();
        }

        private void InitializeComboboxes()
        {
            LoadCmbBrands();
            cmbTipoVehiculo.DataSource = vehicleTypeService.GetAll().ToList();
            cmbOrigen.DataSource = masterDataService.GetVehicleOrigin().ToList();
        }

        private void cmbMarcas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (editMode) return;
            currentBrandIndex = cmbMarcas.SelectedIndex;
            FillModelsByBrandId();
        }
        private void LoadCmbBrands()
        {
            cmbMarcas.ValueMember = "Id";
            cmbMarcas.DataSource = this.brandService.GetAll().ToList();
            cmbMarcas.DisplayMember = "Name";

            if (cmbMarcas.Items.Count != 0)
                FillModelsByBrandId();
            else
            {
                lstModelos.DataSource = null;
                cmbOrigen.DataSource = null;
                cmbTipoVehiculo.DataSource = null;
            }
        }
        private void FillModelsByBrandId()
        {
            if (cmbMarcas.SelectedValue == null) return;
            lstModelos.DataSource = vehicleModelService.GetByBrand((int)cmbMarcas.SelectedValue).ToList();
            lstModelos.ClearSelected();
        }

        private void lstModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lstModelos.Focused) return;
            currentModel = (VehicleModelDto)lstModelos.SelectedItem;
            cmbOrigen.SelectedItem = currentModel.Origin;
            cmbTipoVehiculo.SelectedValue = currentModel.VehicleTypeId;
            txtModelo.Text = currentModel.Name;
            FillBodyworks();
            FillUses();
        }
        private void cmbTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editMode) return;
            if (!cmbTipoVehiculo.Focused) return;
            FillBodyworks();
            FillUses();
        }
        private void FillBodyworks()
        {
            if (currentModel != null)
                lstBodyworks.DataSource = currentModel.Bodyworks;
            else
                lstBodyworks.DataSource = null;
        }
        private void FillUses()
        {
            if (currentModel != null)
                lstUses.DataSource = currentModel.Uses;
            else
                lstBodyworks.DataSource = null;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ToggleEditionControls();
        }
        private void ToggleEditionControls()
        {
            if (!txtMarcas.Visible)
            {
                foreach (Control c in Controls)
                {
                    //if (c is TextBox)
                    //    c.Text = "Nuevo";
                    if (!c.Visible)
                        c.Visible = true;
                }
                btnEditar.Text = "Cancelar";
                editMode = true;
            }
            else
            {
                btnEditar.Text = "Editar";
                txtMarcas.Visible = false;
                txtModelo.Visible = false;
                txtTipoVehiculo.Visible = false;
                txtCarroceria.Visible = false;
                btnCarroceria.Visible = false;
                btnMarcas.Visible = false;
                btnModelo.Visible = false;
                btnRemoveModel.Visible = false;
                btnTipoVehiculo.Visible = false;
                editMode = false;
            }
        }

        #region Txt Select On Click
        private void txtMarcas_Click(object sender, EventArgs e)
        {
            txtMarcas.SelectionStart = 0;
            txtMarcas.SelectionLength = txtMarcas.Text.Length;
        }

        private void txtTipoVehiculo_Click(object sender, EventArgs e)
        {
            txtTipoVehiculo.SelectionStart = 0;
            txtTipoVehiculo.SelectionLength = txtTipoVehiculo.Text.Length;
        }

        private void txtModelo_Click(object sender, EventArgs e)
        {
            txtModelo.SelectionStart = 0;
            txtModelo.SelectionLength = txtModelo.Text.Length;
        }

        private void txtCarroceria_Click(object sender, EventArgs e)
        {
            txtCarroceria.SelectionStart = 0;
            txtCarroceria.SelectionLength = txtCarroceria.Text.Length;
        }

        #endregion

        private void btnModelo_Click(object sender, EventArgs e)
        {
            if (lstModelos.FindString(txtModelo.Text) != -1 || txtModelo.Text == "Nuevo Modelo")
            {
                MessageBox.Show("El Modelo ya existe o no igresó texto.");
                return;
            }
            currentModel.Id = default(int);
            btnGuardar_Click(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            var model = this.GetFormInformation();
            vehicleModelService.Save(model);
            ReInitiateForm();
        }
        private VehicleModelDto GetFormInformation()
        {
            var model = new VehicleModelDto();
            model.Id = currentModel.Id;
            model.BrandId = (int)cmbMarcas.SelectedValue;
            model.Origin = cmbOrigen.SelectedItem.ToString();
            model.Bodyworks = currentModel.Bodyworks;
            model.Name = txtModelo.Text;
            model.Uses = currentModel.Uses;
            model.VehicleTypeId = (int)cmbTipoVehiculo.SelectedValue;
            return model;
        }

        private void btnCarroceria_Click(object sender, EventArgs e)
        {
            var bodywork = new BodyworkDto();
            bodywork.Name = txtCarroceria.Text;
            if (lstBodyworks.FindString(bodywork.Name) != -1 || txtCarroceria.Text == "Nueva carrocería")
            {
                MessageBox.Show("La Carroceria ya existe o no ingresó texto.");
                return;
            }
            try
            {
                this.bodyworkService.Save(bodywork);
                ReInitiateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTipoVehiculo_Click(object sender, EventArgs e)
        {
            var vehicleType = new VehicleTypeDto();
            vehicleType.Name = this.txtTipoVehiculo.Text;
            if (cmbTipoVehiculo.FindString(vehicleType.Name) != -1 || txtTipoVehiculo.Text == "Nuevo tipo")
            {
                MessageBox.Show("El Tipo de Vehiculo ya existe o no ingresó texto."); 
                return;
            }
            try
            {
                this.vehicleTypeService.Save(vehicleType);
                ReInitiateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMarcas_Click(object sender, EventArgs e)
        {
            BrandDto brand = new BrandDto();
            brand.Name = this.txtMarcas.Text;
            if (cmbMarcas.FindString(brand.Name) != -1 || txtMarcas.Text == "Nueva marca")
            {
                MessageBox.Show("La Marca ya existe o no ingresó texto.");
                return;
            }
            try
            {
                this.brandService.Save(brand);
                ReInitiateForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReInitiateForm()
        {
            MessageBox.Show("La operacion ha sido exitosa.");
            LoadCmbBrands();

            cmbTipoVehiculo.ValueMember = "Id";
            cmbTipoVehiculo.DataSource = this.vehicleTypeService.GetAll().ToList();
            cmbTipoVehiculo.DisplayMember = "Name";

            cmbMarcas.Focus();
            cmbMarcas.SelectedIndex = currentBrandIndex;
            FillModelsByBrandId();
            if (editMode)
                ToggleEditionControls();

        }

        private void btnRemoveModel_Click(object sender, EventArgs e)
        {
            string message = "Si este modelo es usado por alguna póliza NO será eliminado\n ¿Continúa?";
            if (MessageBox.Show(message, "Aviso!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    vehicleModelService.Delete(currentModel);
                    ReInitiateForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void cmbMarcas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMarcas_SelectionChangeCommitted(null, null);
        }
    }
}
