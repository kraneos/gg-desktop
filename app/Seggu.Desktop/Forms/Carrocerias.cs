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
    public partial class Carrocerias : Form
    {
        #region Private Members
        private  IBodyworkService bodyworkService;
        #endregion

        #region Constructor
        public Carrocerias(IBodyworkService bodyworkService)
        {
            InitializeComponent();
            this.bodyworkService = bodyworkService;
            this.InitializeIndex();
        }
        #endregion

        #region Private Methods
        private void InitializeIndex()
        {
            var table = this.GetUseDataTable();
            txtNombre.Clear();
            this.bodyWorkGrid.DataSource = table;
            this.bodyWorkGrid.Columns["Id"].Visible = false;
        }

        private DataTable GetUseDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            var banks = this.bodyworkService.GetAll();

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
            if (bodyWorkGrid.DataSource != null)
            {
                try
                {
                    string Id = bodyWorkGrid.SelectedCells[0].Value.ToString();
                    bodyworkService.Delete(Id);
                    this.InitializeIndex();
                    MessageBox.Show("Carroceria eliminada exitosamente.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar la carrocería. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BodyworkDto bodywork;
            bodywork = this.GetFormData();
            if (bodywork.Name == string.Empty)
            {
                MessageBox.Show("El nombre de la carroceria no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bodyworkService.ExistName(bodywork.Name))
            {
                MessageBox.Show("El nombre de la carroceria ingresada ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.bodyworkService.Save(bodywork);
            this.InitializeIndex();
            MessageBox.Show("Carroceria guardada exitosamente.");
        }

        private BodyworkDto GetFormData()
        {
            var body = new BodyworkDto();
            body.Name = txtNombre.Text.Trim();
            return body;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Seggu.Helpers.StringExtensions.isTextLetter(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
