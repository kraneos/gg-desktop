using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Seggu.Desktop.Forms
{
    public partial class RisksOnly : Form
    {
        private ICompanyService companyService;
        private IRiskService riskService;
        private IMasterDataService masterDataService;
        private CompanyDto currentCompany;
        private RiskCompanyDto currentRisk;
        private int lastCompanyIndex;
        private bool isNew;
        private List<RiskCompanyDto> riesgos;


        public RisksOnly(ICompanyService companyService, IRiskService riskService, IMasterDataService masterDataService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.riskService = riskService;
            this.masterDataService = masterDataService;
            this.InitializeIndex();
            this.isNew = false;

        }

        private void InitializeRisks()
        {
            lsbRiesgos.DataSource = null;
            txtRiesgo.Text = string.Empty;
            currentRisk = null;
        }


        private void InitializeIndex()
        {
            lastCompanyIndex = grdCompañias.CurrentCell == null ? 0 : grdCompañias.CurrentCell.RowIndex;
            grdCompañias.DataSource = companyService.GetAll().ToList();
            FormatCompanyGrid();
            PopulateComboboxes();
            grdCompañias.CurrentCell = grdCompañias.Rows[lastCompanyIndex].Cells["Name"];
            InitializeRisks();
        }
        private void FormatCompanyGrid()
        {
            foreach (DataGridViewColumn c in grdCompañias.Columns)
                c.Visible = false;
            grdCompañias.Columns["Name"].Visible = true;
            grdCompañias.Columns["Name"].HeaderText = "Nombre";
        }
        private void PopulateComboboxes()
        {
            cmbTipoRiesgos.ValueMember = "Id";
            cmbTipoRiesgos.DisplayMember = "Name";
            cmbTipoRiesgos.DataSource = masterDataService.GetRiskTypes().ToList();
        }

        private void grdCompañias_SelectionChanged(object sender, EventArgs e)
        {
            PopulateForm();
        }
        private void grdCompañias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateForm();
        }

        private void PopulateForm()
        {

            if (!grdCompañias.Focused)
            {
                grdCompañias.ClearSelection();
                grdCompañias.Rows[0].Selected = false;
                HideEdition();
                return;
            }

            isNew = false;
            InitializeRisks();
            currentCompany = (CompanyDto)grdCompañias.CurrentRow.DataBoundItem;
            riesgos = riskService.GetByCompany(currentCompany.Id).ToList();

            if (riesgos != null)
                FillLsbRiesgos();

            ShowEdition();
        }


        private void ShowEdition()
        {
            lblRiesgos.Show();
            txtRiesgo.Show();
            btnAgregarRiesgos.Show();
            btnQuitarRiesgo.Show();
            btnEditar.Show();
        }

        private void HideEdition()
        {
            lblRiesgos.Hide();
            txtRiesgo.Hide();
            btnAgregarRiesgos.Hide();
            btnQuitarRiesgo.Hide();
            btnEditar.Hide();
        }
        private void FillLsbRiesgos()
        {
            if (currentCompany == null) return;
            if (currentCompany.Id == default(int)) return;

            lsbRiesgos.ValueMember = "Id";
            lsbRiesgos.DisplayMember = "Name";
            lsbRiesgos.DataSource = riesgos.Where(r => r.RiskType == cmbTipoRiesgos.SelectedValue.ToString()).ToList();
        }

        private bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (Control control in this.Controls)
            {
                if (control == txtRiesgo)
                {
                    if (control.Text == string.Empty)
                    {
                        errorProvider1.SetError(control, "Campo vacío");
                        ok = false;
                    }
                }
            }
            return ok;
        }


        private void cmbTipoRiesgos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillLsbRiesgos();
        }

        private void lsbRiesgos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbRiesgos.DataSource == null) return;
            CancelarAccion();
            currentRisk = (RiskCompanyDto)lsbRiesgos.Items[lsbRiesgos.SelectedIndex];
            currentRisk.CompanyId = currentCompany.Id;
            txtRiesgo.Text = currentRisk.Name;
        }



        private void btnAgregarRiesgos_Click(object sender, EventArgs e)
        {
            btnAgregarRiesgos.Hide();
            btnEditar.Hide();
            btnQuitarRiesgo.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtRiesgo.ReadOnly = false;
            txtRiesgo.Clear();
            isNew = true;

        }

        private void CancelarAccion()
        {
            isNew = false;
            btnCancelar.Hide();
            btnGuardar.Hide();
            btnEditar.Show();
            btnAgregarRiesgos.Show();
            btnQuitarRiesgo.Show();
            txtRiesgo.ReadOnly = true;
            txtRiesgo.Clear();

        }

        private void btnQuitarRiesgo_Click(object sender, EventArgs e)
        {
            if (lsbRiesgos.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("No prodrá eliminar el riesgo si este tiene coberturas asociadas, ¿Desea continuar?", "Borrar Riesgo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var riskId = (int)lsbRiesgos.SelectedValue;
                    if (riskId == default(int))
                    {
                        MessageBox.Show("Primero debe seleccionar un riesgo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (riskService.HasCoverages(riskId))
                    {
                        MessageBox.Show("Error al intentar eliminar el Riesgo, existen coberturas asociadas.", "Error al Eliminar Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (riskService.HasPackages(riskId))
                    {
                        MessageBox.Show("Error al intentar eliminar el Riesgo, existen paquetes asociados.", "Error al Eliminar Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {

                        riskService.Delete(riskId);
                        MessageBox.Show("Riesgo eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error al Eliminar Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        InitializeRisks();
                        riesgos = riskService.GetByCompany(currentCompany.Id).ToList();
                        lsbRiesgos.ClearSelected();
                        currentRisk = null;
                        CancelarAccion();
                        if (riesgos != null)
                            FillLsbRiesgos();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentRisk = null;
            CancelarAccion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Primero debe seleccionar la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRiesgo.Text))
            {
                MessageBox.Show("Ingrese un nuevo Riesgo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (isNew)
            {

                if (!riskService.ExistName(txtRiesgo.Text))
                {

                    try
                    {
                        var risk = new RiskCompanyDto();
                        risk.CompanyId = currentCompany.Id;
                        risk.Name = txtRiesgo.Text;
                        risk.RiskType = cmbTipoRiesgos.SelectedItem.ToString();
                        riskService.Create(risk);
                        MessageBox.Show("Riesgo guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error al guardar el nuevo Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        InitializeRisks();
                        currentRisk = null;
                        riesgos = riskService.GetByCompany(currentCompany.Id).ToList();
                        CancelarAccion();
                        if (riesgos != null)
                            FillLsbRiesgos();
                    }


                }
                else
                {
                    MessageBox.Show("Ya existe un riesgo con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            else
            {
                if (currentRisk == null)
                {
                    MessageBox.Show("Primero debe seleccionar un riesgo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!riskService.ExistNameId(txtRiesgo.Text, currentRisk.Id))
                {
                    currentRisk.Name = txtRiesgo.Text;
                    if (currentRisk.Id != default(int) && currentRisk.CompanyId != default(int))
                    {
                        try
                        {
                            riskService.Update(currentRisk);
                            MessageBox.Show("Cambios guardados exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Error al guardar los cambios del Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            InitializeRisks();
                            currentRisk = null;
                            riesgos = riskService.GetByCompany(currentCompany.Id).ToList();
                            CancelarAccion();
                            if (riesgos != null)
                                FillLsbRiesgos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un riesgo con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentRisk == null)
            {
                MessageBox.Show("Primero debe seleccionar un riesgo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnAgregarRiesgos.Hide();
            btnEditar.Hide();
            btnQuitarRiesgo.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtRiesgo.ReadOnly = false;
            isNew = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtRiesgo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsLetterOrDigit(e.KeyChar))
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
