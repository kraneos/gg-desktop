using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Seggu.Dtos;
using Seggu.Data;

namespace Seggu.Desktop.Forms
{
    public partial class Modelos : Form
    {
       #region Private Members
        private  IVehicleModelService vehicleModelService;
        private IVehicleTypeService vehicleTypeService;
        private IBrandService brandService;
        private IMasterDataService masterDataService;
        //private VehicleModelDto currentModel;
        #endregion

        #region Constructor
        public Modelos(IBrandService brandService, IVehicleTypeService vehicleTypeService,
            IMasterDataService masterDataService, IVehicleModelService vehicleModelService)
        {
            InitializeComponent();
            this.vehicleModelService = vehicleModelService;
            this.brandService = brandService;
            this.vehicleTypeService = vehicleTypeService;
            this.masterDataService = masterDataService;
            this.InitializeIndex();
            InitializeComboboxes();

        }
        #endregion

        #region Private Methods
        private void InitializeComboboxes()
        {
            cmbMarcas.ValueMember = "Id";
            cmbMarcas.DataSource = this.brandService.GetAll().ToList();
            cmbMarcas.DisplayMember = "Name";

            cmbTipoVehiculo.ValueMember = "Id";
            cmbTipoVehiculo.DataSource = this.vehicleTypeService.GetAll().ToList();
            cmbTipoVehiculo.DisplayMember = "Name";

            cmbOrigen.DataSource = masterDataService.GetVehicleOrigin().ToList();
        }

        private void LoadCmbBrands()
        {
            

        }

        

        private void InitializeIndex()
        {
            var table = this.GetUseDataTable();
            txtNombre.Clear();
            this.useGrid.DataSource = table;
            this.useGrid.Columns["Id"].Visible = false;
        }
        

        private DataTable GetUseDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Origen", typeof(string));
            table.Columns.Add("Marca", typeof(string));
            table.Columns.Add("Tipo de Vehiculo", typeof(string));


            var banks = SegguContainer.Instance.VehicleModels.Include("Brand").Include("VehicleType");
            
            foreach (var bank in banks)
            {
                var row = table.NewRow();
                row["Id"] = bank.Id;
                row["Nombre"] = bank.Name;
                if (bank.Origin.ToString().CompareTo("National") == 0) row["Origen"] = "Nacional";
                else if (bank.Origin.ToString().CompareTo("Imported") == 0) row["Origen"] = "Importado";
                else row["Origen"] = "Desconocido";
                row["Marca"] = bank.Brand.Name;
                row["Tipo de Vehiculo"] = bank.VehicleType.Name;
                table.Rows.Add(row);
            }

            return table;
        }
        #endregion

        #region Public Methods
        public void Index()
        {
            this.InitializeIndex();
        }
        #endregion

        private void loadCombos()
        {
            cmbMarcas.ValueMember = "Id";
            cmbMarcas.DataSource = this.brandService.GetAll().ToList();
            cmbMarcas.DisplayMember = "Name";
        }

        private VehicleModelDto GetFormData()
        {
            var use = new VehicleModelDto();
            use.Name = txtNombre.Text.Trim();
            use.Origin = cmbOrigen.SelectedItem.ToString();
            use.BrandId = (int)cmbMarcas.SelectedValue;
            use.VehicleTypeId = (int)cmbTipoVehiculo.SelectedValue;
            return use;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VehicleModelDto vehicleModelDto = GetFormData();
            if (vehicleModelDto.Name == string.Empty)
            {
                MessageBox.Show("El nombre del modelo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (vehicleModelService.ExistName(vehicleModelDto.Name))
            {
                MessageBox.Show("El nombre del Modelo ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.vehicleModelService.Save(vehicleModelDto);
            this.InitializeIndex();
            MessageBox.Show("Modelo guardado exitosamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminar selected row
            if (useGrid.DataSource != null)
            {
                try
                {
                    var Id = (int)useGrid.SelectedCells[0].Value;
                    vehicleModelService.Delete(Id);
                    this.InitializeIndex();
                    MessageBox.Show("Modelo eliminado exitosamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar el modelo. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
