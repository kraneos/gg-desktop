using Seggu.Services.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;
using Seggu.Dtos;
using Seggu.Infrastructure;

namespace Seggu.Desktop.Forms
{
    public partial class TiposVehiculos : Form
    {
        #region Private Members
        private IVehicleTypeService vehicleTypeService;
        #endregion

        #region Constructor
        public TiposVehiculos(IVehicleTypeService vehicleTypeService)
        {
            InitializeComponent();
            this.vehicleTypeService = vehicleTypeService;
            this.InitializeIndex();
        }
        #endregion

        #region Private Methods
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
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nombre", typeof(string));

            var vehicleTypes = this.vehicleTypeService.GetAll();

            foreach (var vehicleType in vehicleTypes)
            {
                var row = table.NewRow();
                row["Id"] = vehicleType.Id;
                row["Nombre"] = vehicleType.Name;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VehicleTypeDto vehicleType;
            vehicleType = this.GetFormData();
            if (vehicleType.Name == string.Empty)
            {
                MessageBox.Show("El nombre del tipo de vehiculo no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (vehicleTypeService.ExistName(vehicleType.Name))
            {
                MessageBox.Show("El nombre del tipo de vehiculo ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.vehicleTypeService.Save(vehicleType);
            this.InitializeIndex();
            MessageBox.Show("Tipo de Vehiculo guardado exitosamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminar selected row
            if (useGrid.DataSource != null)
            {
                try
                {
                    var Id = (int)useGrid.SelectedCells[0].Value;
                    vehicleTypeService.Delete(Id);
                    this.InitializeIndex();
                    MessageBox.Show("Tipo de Vehiculo eliminado exitosamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar el Tipo de Vehiculo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private VehicleTypeDto GetFormData()
        {
            var use = new VehicleTypeDto();
            use.Name = txtNombre.Text.Trim();
            return use;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Seggu.Helpers.StringExtensions.isTextLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AdministrarUsos(object sender, EventArgs e)
        {
            //eliminar selected row
            if (useGrid.DataSource != null)
            {
                try
                {
                    var Id = (int)useGrid.SelectedCells[0].Value;
                    var idGuid = Id;
                    var vehicleType = this.vehicleTypeService.Get(idGuid);
                    var usosForm = DependencyResolver.Instance.ResolveGeneric<GestionarUsos>();
                    usosForm.Initialize(vehicleType);
                    usosForm.ShowDialog();
                    this.InitializeIndex();
                }
                catch (Exception)
                {
                }

            }
        }

        private void AdministrarCarrocerias(object sender, EventArgs e)
        {
            //eliminar selected row
            if (useGrid.DataSource != null)
            {
                try
                {
                    var Id = (int)useGrid.SelectedCells[0].Value;
                    var idGuid = Id;
                    var vehicleType = this.vehicleTypeService.Get(idGuid);
                    //var vehicleType = SegguContainer.Instance.VehicleTypes.First(x => x.Id == idGuid);
                    var usosForm = DependencyResolver.Instance.ResolveGeneric<GestionarCarrocerias>();
                    usosForm.Initialize(vehicleType);
                    usosForm.ShowDialog();
                    this.InitializeIndex();
                }
                catch (Exception)
                {
                }

            }
        }
    }
}
