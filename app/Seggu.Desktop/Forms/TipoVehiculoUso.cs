using Seggu.Services.Interfaces;
using System.Data;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class TipoVehiculoUso : Form
    {
         #region Private Members
        private  IVehicleTypeService vehicleTypeService;
        private IUseService useService;
        #endregion

        #region Constructor
        public TipoVehiculoUso(IVehicleTypeService vehicleTypeService, IUseService useService)
        {
            InitializeComponent();
            this.vehicleTypeService = vehicleTypeService;
            this.useService = useService;
            this.InitializeIndex();
        }
        #endregion

        #region Private Methods
        private void InitializeIndex()
        {
            var table = this.GetUseDataTableUse();
            this.useGrid.DataSource = table;
            this.useGrid.Columns["Id"].Visible = false;

            var table2 = this.GetUseDataTableVehicleType();
            this.vehicleTypeGrid.DataSource = table2;
            this.vehicleTypeGrid.Columns["Id"].Visible = false;
        }

        private DataTable GetUseDataTableUse()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            var uses = this.useService.GetAll();

            foreach (var use in uses)
            {
                var row = table.NewRow();
                row["Id"] = use.Id;
                row["Nombre"] = use.Name;
                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable GetUseDataTableVehicleType()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
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
    }
}
