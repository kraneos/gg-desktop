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

namespace Seggu.Desktop.Forms
{
    public partial class Usos : Form
    {

        #region Private Members
        private  IUseService useService;
        //private UseDto currentUse;
        #endregion

        #region Constructor
        public Usos(IUseService useService)
        {
            InitializeComponent();
            this.useService = useService;
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
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            var banks = this.useService.GetAll();

            foreach (var bank in banks)
            {
                var row = table.NewRow();
                row["Id"] = bank.Id;
                row["Nombre"] = bank.Name;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminar selected row
            if (useGrid.DataSource != null)
            {
                try
                {
                    string Id = useGrid.SelectedCells[0].Value.ToString();
                    useService.Delete(Id);
                    this.InitializeIndex();
                    MessageBox.Show("Uso eliminado exitosamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar el uso. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UseDto use;
            use = this.GetFormData();
            if (use.Name == string.Empty)
            {
                MessageBox.Show("El nombre del uso no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (useService.ExistName(use.Name))
            {
                MessageBox.Show("El nombre del uso ingresado ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.useService.Save(use);
            this.InitializeIndex();
            MessageBox.Show("Uso guardado exitosamente.");
        }

        private UseDto GetFormData()
        {
            var use = new UseDto();
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

        private void AsignarTipoVehiculo_Click(object sender, EventArgs e)
        {
            Forms.TipoVehiculoUso form = (TipoVehiculoUso)Seggu.Infrastructure.DependencyContainer
                .Instance.Resolve(typeof(TipoVehiculoUso));
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
