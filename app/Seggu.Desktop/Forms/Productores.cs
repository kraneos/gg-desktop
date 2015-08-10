using Seggu.Dtos;
using Seggu.Services;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Productores : Form
    {
        private IProducerService producerService;
        private ProducerDto currentProducer = new ProducerDto();
        private ProducerDto modificationProducer = new ProducerDto();
        private bool isNew;
        
        public Productores(IProducerService producerService)
        {
            this.producerService = producerService;
            InitializeComponent();
            InitializeIndex();
        }

        private void InitializeIndex()
        {
            isNew = false;
            var table = GetProducerDataTable();
            grdProductores.DataSource = table;
            //var producers = producerService.GetProducers().ToList();
            //grdProductores.DataSource = producers;
            grdProductores.Columns["Id"].Visible = false;
            grdProductores.Columns["Cobrador"].Visible = false;
            
            foreach (DataGridViewColumn column in this.grdProductores.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            grdProductores.Focus();
            //ClearAndAddDataBindings(producers);
        }
        
        private DataTable GetProducerDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nombre", typeof(string));
            table.Columns.Add("Matrícula", typeof(string));
            table.Columns.Add("Cobrador");

            var list = this.producerService.GetProducers().ToList();

            foreach (var x in list)
            {
                var row = table.NewRow();
                row["Id"] = x.Id;
                row["Nombre"] = x.Name;
                row["Matrícula"] = x.Matrícula;
                row["Cobrador"] = x.Cobrador;
                table.Rows.Add(row);
            }
            return table;
        }

        private void ClearAndAddDataBindings(List<ProducerDto> prod)
        {
            txtNombre.DataBindings.Clear();
            txtMatricula.DataBindings.Clear();
            chkCobrador.DataBindings.Clear();

            txtNombre.DataBindings.Add("text", prod, "Name");
            txtMatricula.DataBindings.Add("text", prod, "Matrícula");
            chkCobrador.DataBindings.Add("checked", prod, "Cobrador");
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.grdProductores.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace((string)this.grdProductores.SelectedCells[0].Value))
            {
                MessageBox.Show("Debe seleccionar un productor.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtMatricula.Visible)
            {
                txtMatricula.Visible = true;
                txtNombre.Visible = true;
                chkCobrador.Visible = true;
                btnGuardar.Visible = true;
                btnQuitar.Visible = true;
                btnNuevo.Visible = true;
            }
            else
            {
                txtMatricula.Visible = false;
                txtNombre.Visible = false;
                chkCobrador.Visible = false;
                btnGuardar.Visible = false;
                btnQuitar.Visible = false;
                btnNuevo.Visible = false;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            var producer = this.GetProducerFromForm();

            if (this.grdProductores.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace((string)this.grdProductores.SelectedCells[0].Value))
            {
                MessageBox.Show("Debe seleccionar un productor.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (producer.Id == null)
            {
                MessageBox.Show("Primero debe seleccionar un Productor para eliminarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (producerService.HasCompany(producer.Id))
            {
                MessageBox.Show("No es posible eliminar productores asociados a compañías.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (producerService.HasPolicies(producer.Id))
            {
                MessageBox.Show("No es posible eliminar productores asociados a polizas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (MessageBox.Show("¿Está seguro de eliminar el Productor?", "Eliminar Productor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    producerService.Delete(grdProductores.SelectedCells[0].Value.ToString());
                    InitializeIndex();
                    if (this.grdProductores.Rows.Count > 0)
                    {
                        this.grdProductores.Rows[0].Selected = true;
                    }
                }

            }

        }

        private bool ValidateControls()
        {
            bool ok = true;
            EhProducers.Clear();

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                    if (c == txtNombre || c == txtMatricula)
                        if (string.IsNullOrWhiteSpace(c.Text))
                        {
                            EhProducers.SetError(c, "Este campo es obligatorio.");
                            ok = false;
                        }
            }

            return ok;
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var producer = this.GetProducerFromForm();

            if (ValidateControls() == false)
            {
                return;
            }

            bool exist = false;

            exist = producerService.GetByRegistrationNumber(producer.Matrícula, producer.Id);

            if (exist == false)
            {
                producerService.Save(producer);
                this.InitializeIndex();
                CancelarAccion();

            }
            else
            {
                MessageBox.Show("Matrícula existente. El número de matrícula no puede repetirse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        private ProducerDto GetProducerFromForm()
        {
            if (isNew)
            {
                modificationProducer.Id = null;
                modificationProducer.Name = txtNombre.Text;
                modificationProducer.Matrícula = txtMatricula.Text;
                modificationProducer.Cobrador = chkCobrador.Checked ? true : false;
                return modificationProducer;
            }
            else
            {
                modificationProducer.Id = currentProducer.Id;
                modificationProducer.Name = txtNombre.Text;
                modificationProducer.Matrícula = txtMatricula.Text;
                modificationProducer.Cobrador = chkCobrador.Checked ? true : false;
                return modificationProducer;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            isNew = true;
            //grdProductores.ClearSelection();
            txtNombre.Clear();
            txtMatricula.Clear();
            chkCobrador.Enabled = true;
            chkCobrador.Checked = false;
            btnGuardar.Visible = true;
            txtNombre.ReadOnly = false;
            txtMatricula.ReadOnly = false;
            btnEditarProductor.Visible = false;
            btnQuitar.Visible = false;
            btnNuevo.Visible = false;
            btnCancelar.Visible = true;

        }

        private void grdProductores_SelectionChanged(object sender, EventArgs e)
        {
            //currentProducer = (ProducerDto)grdProductores.CurrentRow.DataBoundItem;
            currentProducer = GetCurrentProducer();

            txtMatricula.Text = currentProducer.Matrícula;
            txtNombre.Text = currentProducer.Name;
            if (currentProducer.Cobrador)
            {
                chkCobrador.Checked = true;
            }
            else
            {
                chkCobrador.Checked = false;
            }

            //CancelarAccion();
        }

        private ProducerDto GetCurrentProducer()
        {
            var producer = new ProducerDto();
            
            if (this.grdProductores.SelectedRows.Count > 0)
            {
                var row = this.grdProductores.SelectedRows[0];
                producer.Id = (string)row.Cells["Id"].Value;
                producer.Name = (string)row.Cells["Nombre"].Value;
                producer.Matrícula = (string)row.Cells["Matrícula"].Value;
                producer.Cobrador = Convert.ToBoolean(row.Cells["Cobrador"].Value);
            }

            return producer;
        }

        private void btnEditarProductor_Click(object sender, EventArgs e)
        {
            if (this.grdProductores.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace((string)this.grdProductores.SelectedCells[0].Value))
            {
                MessageBox.Show("Debe seleccionar un productor.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentProducer.Id == null || currentProducer.Id == String.Empty)
            {
                MessageBox.Show("Primero debe seleccionar un Productor para poder editarlo.");
            }
            else
            {
                txtMatricula.Text = currentProducer.Matrícula;
                txtNombre.Text = currentProducer.Name;
                if (currentProducer.Cobrador)
                {
                    chkCobrador.Checked = true;
                }
                else
                {
                    chkCobrador.Checked = false;
                }

                btnGuardar.Visible = true;
                btnNuevo.Visible = false;
                btnEditarProductor.Visible = false;
                btnQuitar.Visible = false;
                txtMatricula.ReadOnly = false;
                txtNombre.ReadOnly = false;
                chkCobrador.Enabled = true;
                btnCancelar.Visible = true;

            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarAccion();
            if (this.grdProductores.SelectedCells.Count > 0 && !string.IsNullOrWhiteSpace((string)this.grdProductores.SelectedCells[0].Value))
            {
                grdProductores_SelectionChanged(null, null);
            }
        }

        private void CancelarAccion()
        {
            btnGuardar.Visible = false;
            btnNuevo.Visible = true;
            btnEditarProductor.Visible = true;
            btnQuitar.Visible = true;
            txtMatricula.ReadOnly = true;
            txtNombre.ReadOnly = true;
            chkCobrador.Enabled = false;
            btnCancelar.Visible = false;
            EhProducers.Clear();
            this.txtMatricula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtMatricula_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
