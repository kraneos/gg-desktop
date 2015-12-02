using Seggu.Dtos;
using Seggu.Services.Interfaces;

using Seggu.Infrastructure;

using System;
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
            currentModel = new VehicleModelDto();
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
            if (txtMarcas.Visible)
                HideEditionControls();
            else
                ShowEditionControls();
        }
        private void HideEditionControls()
        {
            btnEditar.Text = "Editar";
            txtMarcas.Visible = false;
            txtModelo.Visible = false;
            btnMarcas.Visible = false;
            btnModelo.Visible = false;
            btnBodyworks.Visible = false;
            btnUses.Visible = false;
            btnRemoveModel.Visible = false;
            btnGuardar.Visible = false;
            cmbTipoVehiculo.Enabled = false;
            cmbOrigen.Enabled = false;

            editMode = false;
        }
        private void ShowEditionControls()
        {
            foreach (Control c in Controls)
                if (!c.Visible)
                    c.Visible = true;
            btnEditar.Text = "Cancelar";
            editMode = true;
            cmbTipoVehiculo.Enabled = true;
            cmbOrigen.Enabled = true;
        }

        #region Txt Select On Click
        private void txtMarcas_Click(object sender, EventArgs e)
        {
            txtMarcas.SelectionStart = 0;
            txtMarcas.SelectionLength = txtMarcas.Text.Length;
        }
        private void txtModelo_Click(object sender, EventArgs e)
        {
            txtModelo.SelectionStart = 0;
            txtModelo.SelectionLength = txtModelo.Text.Length;
        }
        #endregion

        private void btnModelo_Click(object sender, EventArgs e)
        {
            if (lstModelos.FindString(txtModelo.Text) != -1 || txtModelo.Text == "Nuevo Modelo")
            {
                MessageBox.Show("El Modelo ya existe o no igresó texto.");
                return;
            }
            currentModel.Id = default(int);// Null, hay que instanciar un new
            try
            {
                btnGuardar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentModel == null) return;
            var model = this.GetFormInformation();
            vehicleModelService.Save(model);
            txtModelo.Text = "";
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
                txtMarcas.Text = "";
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

        private void txtCarroceria_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBodyworks_Click(object sender, EventArgs e)
        {
            Forms.Carrocerias carrocerias = (Carrocerias)DependencyResolver.Instance.Resolve(typeof(Carrocerias));
            carrocerias.Show();
        }

        private void btnUses_Click(object sender, EventArgs e)
        {
            Forms.Usos usos = (Usos)DependencyResolver.Instance.Resolve(typeof(Usos));
            usos.Show();
        }
    }
}
