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
    public partial class CoberturasOnly : Form
    {
        private ICompanyService companyService;
        private IRiskService riskService;
        private ICoverageService coverageService;
        private IMasterDataService masterDataService;
        private CompanyDto currentCompany;
        private RiskCompanyDto currentRisk;
        private CoverageDto currentCoverage;
        private int lastCompanyIndex;
        private bool isNew;
        private List<RiskCompanyDto> riesgos;


        public CoberturasOnly(ICompanyService companyService, ICoverageService coverageService,
            IRiskService riskService, IMasterDataService masterDataService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.riskService = riskService;
            this.coverageService = coverageService;
            this.masterDataService = masterDataService;
            this.InitializeIndex();
            this.isNew = false;

        }

        private void InitializeRisks()
        {
            lsbRiesgos.DataSource = null;
            currentRisk = null;

        }

        private void InitializeCoberturas()
        {
            lsbCoberturas.DataSource = null;
            currentCoverage = null;
            txtCoberturas.Text = string.Empty;
            lsbCoberturas.ClearSelected();
        }

        private void InitializeIndex()
        {

            lastCompanyIndex = grdCompañias.CurrentCell == null ? 0 : grdCompañias.CurrentCell.RowIndex;
            grdCompañias.DataSource = companyService.GetAll().ToList();
            FormatCompanyGrid();
            PopulateComboboxes();
            grdCompañias.CurrentCell = grdCompañias.Rows[lastCompanyIndex].Cells["Name"];
            InitializeCoberturas();
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
            InitializeCoberturas();
            InitializeRisks();
            currentCompany = (CompanyDto)grdCompañias.CurrentRow.DataBoundItem;
            riesgos = riskService.GetByCompany(currentCompany.Id).ToList();
            if (riesgos != null)
                FillLsbRiesgos();

            ShowEdition();
        }

        private void ShowEdition()
        {
            LblNombre.Show();
            txtCoberturas.Show();
            btnAgregarCobertura.Show();
            btnQuitarCobertura.Show();
            btnEditar.Show();
        }

        private void HideEdition()
        {
            LblNombre.Hide();
            txtCoberturas.Hide();
            btnAgregarCobertura.Hide();
            btnQuitarCobertura.Hide();
            btnEditar.Hide();
        }
        private void FillLsbRiesgos()
        {
            if (currentCompany == null) return;
            if (currentCompany.Id == null) return;
            if (currentCompany.Id == default(int)) return;
            lsbRiesgos.ValueMember = "Id";
            lsbRiesgos.DisplayMember = "Name";
            lsbRiesgos.DataSource = riesgos.Where(r => r.RiskType == cmbTipoRiesgos.SelectedValue.ToString()).ToList();
        }


        private void cmbTipoRiesgos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitializeCoberturas();
            InitializeRisks();
            HideEdition();
            FillLsbRiesgos();
        }

        private void lsbRiesgos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbRiesgos.DataSource == null)
            {
                CancelarAccion();
                HideEdition();
                return;
            }

            CancelarAccion();
            InitializeCoberturas();
            currentRisk = (RiskCompanyDto)lsbRiesgos.Items[lsbRiesgos.SelectedIndex];
            currentRisk.CompanyId = currentCompany.Id;
            FillLsbCoberturas(true);
            ShowEdition();

        }

        private void CancelarAccion()
        {
            isNew = false;
            btnCancelar.Hide();
            btnGuardar.Hide();
            btnEditar.Show();
            btnAgregarCobertura.Show();
            btnQuitarCobertura.Show();
            txtCoberturas.ReadOnly = true;
            txtCoberturas.Clear();

        }

        private void FillLsbCoberturas(bool fromRisk)
        {
            lsbCoberturas.ValueMember = "Id";
            lsbCoberturas.DisplayMember = "Description";
            if (fromRisk)
                lsbCoberturas.DataSource = coverageService
                    .GetAllByRiskId((int)lsbRiesgos.SelectedValue).ToList();
            else
                lsbCoberturas.ClearSelected();
        }


        private void btnAgregarCobertura_Click(object sender, EventArgs e)
        {
            btnAgregarCobertura.Hide();
            btnEditar.Hide();
            btnQuitarCobertura.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtCoberturas.ReadOnly = false;
            txtCoberturas.Clear();
            isNew = true;
        }
        private void btnQuitarCobertura_Click(object sender, EventArgs e)
        {


            var coverages = lsbCoberturas.SelectedItems;
            if (lsbCoberturas.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("No prodrá eliminar la cobertura si esta se encuentra asociada pólizas, ¿Desea continuar?", "Borrar Cobertura", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var coberturaId = lsbCoberturas.SelectedValue.ToString();
                    if (coberturaId == null)
                    {
                        MessageBox.Show("Primero debe seleccionar una cobertura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        coverageService.DeleteMany(coverages.Cast<CoverageDto>());
                        MessageBox.Show("Cobertura eliminada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar eliminar, cobertura asociada a pólizas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        InitializeCoberturas();
                        currentCoverage = null;
                        CancelarAccion();
                        FillLsbCoberturas(true);
                    }
                }

            }
            else
            {
                MessageBox.Show("Primero debe seleccionar una cobertura para eliminarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Primero debe seleccionar la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentRisk == null)
            {
                MessageBox.Show("Primero debe seleccionar un riesgo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCoberturas.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una nueva Cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isNew)
            {
                if (coverageService.ExistName(txtCoberturas.Text))
                {
                    MessageBox.Show("Ya existe una cobertura con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {

                    var coverage = new CoverageDto();
                    int index;
                    coverage.Description = txtCoberturas.Text;
                    coverage.Name = txtCoberturas.Text;
                    coverage.RiskId = (int)lsbRiesgos.SelectedValue;
                    index = lsbCoberturas.SelectedIndex;
                    coverageService.Save(coverage);
                    MessageBox.Show("Cobertura guardada exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error al guardar la nueva Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    InitializeCoberturas();
                    currentCoverage = null;
                    CancelarAccion();
                    FillLsbCoberturas(true);

                }
            }
            else //IsNew Else
            {
                if (currentCoverage == null)
                {
                    MessageBox.Show("Primero debe seleccionar una cobertura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (coverageService.ExistNameId(txtCoberturas.Text, currentCoverage.Id, currentRisk.Id))
                {
                    MessageBox.Show("Ya existe una cobertura con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    currentCoverage.Name = txtCoberturas.Text;
                    currentCoverage.Description = txtCoberturas.Text;

                    if (currentRisk.Id != null && currentRisk.CompanyId != null)
                    {
                        coverageService.Update(currentCoverage);
                        MessageBox.Show("Cambios guardados exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al guardar los cambios del Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    InitializeCoberturas();
                    currentCoverage = null;
                    CancelarAccion();
                    FillLsbCoberturas(true);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentCoverage = null;
            lsbCoberturas.ClearSelected();
            CancelarAccion();
        }

        private void lsbCoberturas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbCoberturas.DataSource == null) return;
            if (lsbCoberturas.SelectedIndex < 0) return;
            CancelarAccion();
            currentCoverage = (CoverageDto)lsbCoberturas.Items[lsbCoberturas.SelectedIndex];
            currentCoverage.RiskId = currentRisk.Id;
            txtCoberturas.Text = currentCoverage.Name;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentCoverage == null)
            {
                MessageBox.Show("Primero debe seleccionar una cobertura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnAgregarCobertura.Hide();
            btnEditar.Hide();
            btnQuitarCobertura.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtCoberturas.ReadOnly = false;
            isNew = false;
        }

        private void txtCoberturas_KeyPress(object sender, KeyPressEventArgs e)
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
