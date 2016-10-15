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
    public partial class PackagesOnly : Form
    {
        private ICompanyService companyService;
        private IRiskService riskService;
        private ICoverageService coverageService;
        private ICoveragesPackService coveragesPackService;
        private IMasterDataService masterDataService;
        private CompanyDto currentCompany;
        private RiskCompanyDto currentRisk;
        private CoverageDto currentCoverage;
        private CoveragesPackDto currentPackage;
        private int lastCompanyIndex;
        private bool isNew;
        private List<RiskCompanyDto> riesgos;



        public PackagesOnly(ICompanyService companyService, ICoverageService coverageService,
            IRiskService riskService, ICoveragesPackService coveragesPackService, IMasterDataService masterDataService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.riskService = riskService;
            this.coverageService = coverageService;
            this.coveragesPackService = coveragesPackService;
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
            txtCoveragesPack.Text = string.Empty;
            lsbCoberturas.ClearSelected();

        }

        private void InitializeCoveragePacks()
        {
            grdCoveragesPack.DataSource = null;
            txtCoveragesPack.Text = string.Empty;
            currentPackage = null;
            btnAgregar.Hide();
            btnQuitar.Hide();
        }

        private void InitializaAddedCoverages()
        {
            lsbCoberturasPaquete.DataSource = null;

        }

        private void InitializeIndex()
        {

            lastCompanyIndex = grdCompañias.CurrentCell == null ? 0 : grdCompañias.CurrentCell.RowIndex;
            grdCompañias.DataSource = companyService.GetActive().ToList();
            FormatCompanyGrid();
            PopulateComboboxes();
            grdCompañias.CurrentCell = grdCompañias.Rows[lastCompanyIndex].Cells["Name"];
            InitializeCoberturas();
            InitializeRisks();
            InitializeCoveragePacks();
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
            if (this.grdCompañias.SelectedRows.Count == 0)
            {
                HideEdition();
            }
            else
            {
                PopulateForm(); 
            }
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
            InitializeCoveragePacks();
            InitializaAddedCoverages();
            currentCompany = (CompanyDto)grdCompañias.CurrentRow.DataBoundItem;
            riesgos = riskService.GetByCompany(currentCompany.Id).ToList();
            
            if (riesgos != null)
            {
                FillLsbRiesgos();
            }

            ShowEdition();
        }

        private void ShowEdition()
        {
            LblNombre.Show();
            txtCoveragesPack.Show();
            btnAgregarPaquete.Show();
            btnQuitarPaquete.Show();
            btnEditar.Show();
        }

        private void HideEdition()
        {
            LblNombre.Hide();
            txtCoveragesPack.Hide();
            btnAgregarPaquete.Hide();
            btnQuitarPaquete.Hide();
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

        private void FillgrdCoveragesPack()
        {
            if (lsbRiesgos.SelectedValue == null) return;
            grdCoveragesPack.DataSource = coveragesPackService
                .GetAllByRiskId((int)lsbRiesgos.SelectedValue).ToList();
            FormatCoveragesPacksGrid();
            grdCoveragesPack.ClearSelection();
        }

        private void FillLsbCoberturasPaquete()
        {
            lsbCoberturasPaquete.ValueMember = "Id";
            lsbCoberturasPaquete.DisplayMember = "Description";
            lsbCoberturasPaquete.DataSource = currentPackage.Coverages.ToList();
        }

        private void FormatCoveragesPacksGrid()
        {
            foreach (DataGridViewColumn c in grdCoveragesPack.Columns)
                c.Visible = false;
            grdCoveragesPack.Columns["Name"].Visible = true;
            grdCoveragesPack.Columns["Name"].HeaderText = "Nombre";
        }

        private void cmbTipoRiesgos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitializeCoberturas();
            InitializeRisks();
            InitializeCoveragePacks();
            InitializaAddedCoverages();
            CancelarAccion();
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
            InitializeCoveragePacks();
            InitializaAddedCoverages();
            currentRisk = (RiskCompanyDto)lsbRiesgos.Items[lsbRiesgos.SelectedIndex];
            currentRisk.CompanyId = currentCompany.Id;
            FillLsbCoberturas(true);
            FillgrdCoveragesPack();
            ShowEdition();

        }

        private void CancelarAccion()
        {
            isNew = false;
            btnCancelar.Hide();
            btnGuardar.Hide();
            btnEditar.Show();
            btnAgregarPaquete.Show();
            btnQuitarPaquete.Show();
            txtCoveragesPack.ReadOnly = true;
            txtCoveragesPack.Clear();

        }

        private void btnAgregarPaquete_Click(object sender, EventArgs e)
        {
            btnAgregarPaquete.Hide();
            btnEditar.Hide();
            btnQuitarPaquete.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtCoveragesPack.ReadOnly = false;
            txtCoveragesPack.Clear();
            isNew = true;
        }

        private void btnQuitarPaquete_Click(object sender, EventArgs e)
        {
            if (grdCoveragesPack.CurrentRow == null)
            {
                MessageBox.Show("Primero debe seleccionar un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentPackage == null)
            {
                MessageBox.Show("Primero debe seleccionar un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este paquete? Se eliminara también las coberturas asociadas.", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {


                try
                {
                    currentPackage = (CoveragesPackDto)grdCoveragesPack.CurrentRow.DataBoundItem;
                    coveragesPackService.Delete(currentPackage.Id);
                    MessageBox.Show("Paquete eliminado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al intentar eliminar el Paquete, existen pólizas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    InitializeCoveragePacks();
                    InitializaAddedCoverages();
                    FillgrdCoveragesPack();
                }
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


            if (string.IsNullOrWhiteSpace(txtCoveragesPack.Text))
            {
                MessageBox.Show("Ingrese un el nombre del Paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (isNew)
            {
                if (coveragesPackService.ExistNameRisk(txtCoveragesPack.Text, currentRisk.Id))
                {
                    MessageBox.Show("Ya existe un paquete de coberturas con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var coveragesPack = new CoveragesPackDto();
                    coveragesPack.Name = txtCoveragesPack.Text;
                    coveragesPack.RiskId = currentRisk.Id;
                    coveragesPack.Coverages = new List<CoverageDto>();
                    coveragesPackService.Create(coveragesPack);
                    MessageBox.Show("Paquete guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error al guardar el nuevo Paquete", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    currentPackage = null;
                    InitializeCoveragePacks();
                    InitializaAddedCoverages();
                    CancelarAccion();
                    FillgrdCoveragesPack();
                }

            }
            else
            {
                if (currentPackage == null)
                {
                    MessageBox.Show("Primero debe seleccionar un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (coveragesPackService.ExistNameId(txtCoveragesPack.Text, currentPackage.Id, currentRisk.Id))
                {
                    MessageBox.Show("Ya existe un paquete de coberturas con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var coveragesPack = currentPackage;
                    coveragesPack.Name = txtCoveragesPack.Text;

                    coveragesPackService.Update(coveragesPack);
                    MessageBox.Show("Los cambios se han guardado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error al guardar las modificaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    currentPackage = null;
                    InitializeCoveragePacks();
                    InitializaAddedCoverages();
                    CancelarAccion();
                    FillgrdCoveragesPack();

                }

            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            currentCoverage = null;
            CancelarAccion();
        }

        private void lsbCoberturas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbCoberturas.DataSource == null) return;
            if (lsbCoberturas.SelectedIndex < 0) return;
            currentCoverage = (CoverageDto)lsbCoberturas.Items[lsbCoberturas.SelectedIndex];
            currentCoverage.RiskId = currentRisk.Id;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (currentPackage == null)
            {
                MessageBox.Show("Primero debe seleccionar un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnAgregarPaquete.Hide();
            btnEditar.Hide();
            btnQuitarPaquete.Hide();
            btnGuardar.Show();
            btnCancelar.Show();
            txtCoveragesPack.ReadOnly = false;
            isNew = false;
        }

        private void grdCoveragesPack_SelectionChanged(object sender, EventArgs e)
        {
            if (!grdCoveragesPack.Focused)
            {
                grdCoveragesPack.ClearSelection();
                grdCoveragesPack.Rows[0].Selected = false;

                return;
            }

            if (grdCoveragesPack.DataSource == null) return;
            if (grdCoveragesPack.CurrentRow == null) return;

            CancelarAccion();
            InitializaAddedCoverages();
            currentPackage = (CoveragesPackDto)grdCoveragesPack.CurrentRow.DataBoundItem;
            FillLsbCoberturasPaquete();
            btnAgregar.Show();
            btnQuitar.Show();
            txtCoveragesPack.Text = currentPackage.Name;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (grdCoveragesPack.DataSource == null)
            {
                MessageBox.Show("Por favor, seleccione un paquete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdCoveragesPack.CurrentRow == null || lsbCoberturas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el paquete y las coberturas que desea agregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int agregadas = 0;
                int total = lsbCoberturas.SelectedItems.Count;
                bool agregar = true;
                var coveragesPack = (CoveragesPackDto)grdCoveragesPack.CurrentRow.DataBoundItem;
                foreach (CoverageDto coverage in lsbCoberturas.SelectedItems)
                {
                    agregar = true;
                    foreach (CoverageDto added in coveragesPack.Coverages)
                    {
                        if (coverage.Id == added.Id)
                        {
                            agregar = false;
                        }
                    }
                    if (agregar == true)
                    {
                        coveragesPack.Coverages.Add(coverage);
                        agregadas++;
                    }

                }

                coveragesPackService.Update(coveragesPack);
                MessageBox.Show("Se agregaron " + agregadas + " coberturas de " + total + " coberturas seleccionadas.", "Cobertura/s Agregada/s", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Error al agregar la/s Cobertura/s.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                InitializaAddedCoverages();
                FillLsbCoberturasPaquete();
            }

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

            if (lsbCoberturasPaquete.DataSource == null)
            {
                MessageBox.Show("Por favor, seleccione el paquete y las coberturas que desea quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (grdCoveragesPack.CurrentRow == null || lsbCoberturasPaquete.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el paquete y las coberturas que desea quitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var coveragesPack = (CoveragesPackDto)grdCoveragesPack.CurrentRow.DataBoundItem;
                foreach (CoverageDto coverage in lsbCoberturasPaquete.SelectedItems)
                    coveragesPack.Coverages.Remove(coverage);
                coveragesPackService.Update(coveragesPack);
                MessageBox.Show("Cobertura/s removida/s del paquete.", "Cobertura Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error al remover la/s Cobertura/s.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                InitializaAddedCoverages();
                FillLsbCoberturasPaquete();
            }

        }

        private void txtCoveragesPack_KeyPress(object sender, KeyPressEventArgs e)
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
