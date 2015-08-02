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
    public partial class Marcas : Form
    {
        #region Private Members
        private  IBrandService brandService;
        #endregion

        #region Constructor
        public Marcas(IBrandService brandService)
        {
            InitializeComponent();
            this.brandService = brandService;
            this.InitializeIndex();
        }
        #endregion

        #region Private Methods
        private void InitializeIndex()
        {
            var table = this.GetUseDataTable();
            txtNombre.Clear();
            this.brandGrid.DataSource = table;
            this.brandGrid.Columns["Id"].Visible = false;
        }

        private DataTable GetUseDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));

            var banks = this.brandService.GetAll();

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BrandDto use;
            use = this.GetFormData();
            if (use.Name == string.Empty)
            {
                MessageBox.Show("El nombre de la marca no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (brandService.ExistName(use.Name))
            {
                MessageBox.Show("El nombre de la marca ingresada ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.brandService.Save(use);
            this.InitializeIndex();
            MessageBox.Show("Marca guardada exitosamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //eliminar selected row
            if (brandGrid.DataSource != null)
            {
                try
                {
                    string Id = brandGrid.SelectedCells[0].Value.ToString();
                    if (brandService.HasRelatedRecords(Id))
                    {
                        MessageBox.Show("La marca ya esta asociada a uno o mas modelos de vehiculos. Debe eliminarlos antes realizar esta accion.");
                    }
                    else
                    {
                        brandService.Delete(Id);
                        this.InitializeIndex();
                        MessageBox.Show("Marca eliminada exitosamente.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar la marca. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private BrandDto GetFormData()
        {
            var brand = new BrandDto();
            brand.Name = txtNombre.Text.Trim();
            return brand;
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
    }
}
