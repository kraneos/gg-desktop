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
    public partial class Compañías : Form
    {
        private ICompanyService companyService;
        private IProducerService producerService;
        private IRiskService riskService;
        private ICoverageService coverageService;
        private IMasterDataService masterDataService;
        private CompanyFullDto selectedFullCompany;
        private CompanyDto currentCompany;
        private bool isNew;

        public Compañías(ICompanyService companyService, ICoverageService coverageService,IProducerService producerService,
            IRiskService riskService, IMasterDataService masterDataService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.producerService = producerService;
            this.riskService = riskService;
            this.coverageService = coverageService;
            this.masterDataService = masterDataService;
            this.InitializeIndex();
            this.isNew = false;
        }

        private void InitializeIndex()
        {
            lsbRiesgos.DataSource = null;
            lsbCoberturas.DataSource = null;
            grdProductores.DataSource = null;

            PopulateComboboxes();
        }
        private void PopulateComboboxes()
        {     
            cmbProductores.ValueMember = "Id";
            cmbProductores.DisplayMember = "Name";
            cmbProductores.DataSource = producerService.GetProducers().ToList();

            cmbTipoRiesgos.ValueMember = "Id";
            cmbTipoRiesgos.DisplayMember = "Name";
            cmbTipoRiesgos.DataSource = masterDataService.GetRiskTypes().ToList();
            
            if (isNew) 
                return;

            cmbCompañias.ValueMember = "Id";
            cmbCompañias.DisplayMember = "Name";
            cmbCompañias.DataSource = companyService.GetAll().ToList();
            cmbCompañias.SelectedIndex = -1;
        }
        private void cmbCompañias_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCompany = (CompanyDto)cmbCompañias.SelectedItem;
            PopulateForm();
        }

        private void PopulateForm()
        {
            lsbCoberturas.DataSource = null;

            currentCompany = (CompanyDto)cmbCompañias.SelectedItem;
            selectedFullCompany = companyService.GetFullById(currentCompany.Id);//acá cuelga bocha la primer vez
            BindCompaniesTextBoxes(currentCompany);

            if (selectedFullCompany.Contacts != null)
                FillGrdContactos();
            if (selectedFullCompany.Producers != null)
                FillGrdProductores();
            if (selectedFullCompany.Risks != null)
                FillLsbRiesgos();
        }
        private void BindCompaniesTextBoxesFull(CompanyFullDto company)
        {
            ClearBindings();

            chkActive.DataBindings.Add("checked", company, "Active");
            txtNombre.DataBindings.Add("text", company, "Name");
            txtLiq1.DataBindings.Add("text", company, "LiqDay1");
            txtLiq2.DataBindings.Add("text", company, "LiqDay2");
            txtConvenio1.DataBindings.Add("text", company, "Convenio1");
            txtConvenio2.DataBindings.Add("text", company, "Convenio2");
            txtMail.DataBindings.Add("text", company, "Mail");
            txtNotas.DataBindings.Add("text", company, "Notes");
            txtTelefono.DataBindings.Add("text", company, "Phone");
            txtCUIT.DataBindings.Add("text", company, "CUIT");
        }
        private void BindCompaniesTextBoxes(CompanyDto company)
        {
            ClearBindings();

            chkActive.DataBindings.Add("checked", company, "Active");
            txtNombre.DataBindings.Add("text", company, "Name");
            txtLiq1.DataBindings.Add("text", company, "LiqDay1");
            txtLiq2.DataBindings.Add("text", company, "LiqDay2");
            txtConvenio1.DataBindings.Add("text", company, "Convenio1");
            txtConvenio2.DataBindings.Add("text", company, "Convenio2");
            txtMail.DataBindings.Add("text", company, "Mail");
            txtNotas.DataBindings.Add("text", company, "Notes");
            txtTelefono.DataBindings.Add("text", company, "Phone");
            txtCUIT.DataBindings.Add("text", company, "CUIT");
        }
        private void ClearBindings()
        {
            chkActive.DataBindings.Clear();
            txtNombre.DataBindings.Clear();
            txtLiq1.DataBindings.Clear();
            txtLiq2.DataBindings.Clear();
            txtConvenio1.DataBindings.Clear();
            txtConvenio2.DataBindings.Clear();
            txtMail.DataBindings.Clear();
            txtNotas.DataBindings.Clear();
            txtTelefono.DataBindings.Clear();
            txtCUIT.DataBindings.Clear();
        }
        private void FillGrdContactos()
        {
            this.grdContactos.DataSource = selectedFullCompany.Contacts;
            this.grdContactos.Columns["Id"].Visible = false;
            this.grdContactos.Columns["CompanyId"].Visible = false;
            this.grdContactos.Columns["Bussiness"].Visible = false;
        }
        private void FillGrdProductores()
        {
            this.grdProductores.DataSource = selectedFullCompany.Producers;
            this.grdProductores.Columns["Id"].Visible = false;
            this.grdProductores.Columns["Code"].HeaderText = "Código";
            this.grdProductores.Columns["RegistrationNumber"].HeaderText = "Matrícula";
            this.grdProductores.Columns["commission"].HeaderText = "Comisión";
            this.grdProductores.Columns["Name"].HeaderText = "Nombre";

        }
        private void FillLsbRiesgos()
        {
            if (selectedFullCompany == null) return;
            lsbRiesgos.ValueMember = "Id";
            lsbRiesgos.DisplayMember = "Name";
            var riskType = (string)cmbTipoRiesgos.SelectedValue;
            var risks = selectedFullCompany.Risks
                .Where(r => r.RiskType == riskType);
            lsbRiesgos.DataSource = risks.ToList();
        }

        private void cmbTipoRiesgos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lsbCoberturas.DataSource = null;
            FillLsbRiesgos();
        }

        private void lsbRiesgos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lsbRiesgos.DataSource == null) return;
            FillLsbCoberturas();
        }

        private void FillLsbCoberturas()
        {
            lsbCoberturas.ValueMember = "Id";
            lsbCoberturas.DisplayMember = "Description";
            lsbCoberturas.DataSource = coverageService.GetAllByRiskId((int)lsbRiesgos.SelectedValue).ToList();//aca la cuelga el wacho
            lsbCoberturas.ClearSelected();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblNuevaCompañia.Visible = false;
            btnAgregarCompañia.UseVisualStyleBackColor = true;

            if (ValidateControls())
            {
                CompanyDto company;
                if (isNew)
                {
                    company = this.GetFormData();
                    if (!companyService.ExistName(company.Name))
                    {
                        this.companyService.Create(company);
                        isNew = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya existe una compañía con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    //company = (CompanyDto)cmbCompañias.SelectedItem;
                    company = currentCompany;
                    this.companyService.Update(company);
                }
                btnEditar_Click(sender, e);
                InitializeIndex();
            }
        }
        private bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (Control control in grpbDatos.Controls)
            {
                if (control == txtNombre || control == txtTelefono || control == txtMail)
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
        private CompanyDto GetFormData()
        {
            var company = new CompanyDto();
            company.Active = true;
            company.CUIT = txtCUIT.Text;
            company.LiqDay1 = txtLiq1.Text;
            company.LiqDay2 = txtLiq2.Text;
            company.Convenio1 = txtConvenio1.Text;
            company.Convenio2 = txtConvenio2.Text;
            company.Mail = txtMail.Text;
            company.Name = txtNombre.Text;
            company.Notes = txtNotas.Text;
            company.Phone = txtTelefono.Text;
            return company;
        }

        #region Edit
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!btnGuardar.Visible)
            {
                grbRiesgos.Width += 371;
                grbRiesgos.Height += 58;

                LoadAllCoverages();

                btnEditar.Text = "Cancelar";
                chkActive.Visible = true;
                btnGuardar.Visible = true;
                btnNuevoProductor.Visible = true;
                btnQuitarCobertura.Visible = true;
                btnQuitarRiesgo.Visible = true;
                btnQuitarCompañia.Visible = true;
                btnQuitarProductor.Visible = true;
                btnAgregarCompañia.Visible = true;
                btnAgregarCobertura.Visible = true;
                btnAgregarProd.Visible = true;
                btnAgregarRiesgos.Visible = true;
                cmbProductores.Visible = true;
                txtCode.Visible = true;
                lblCodigo.Visible = true;
                txtRiesgo.Visible = true;
                txtCoberturas.Visible = true;
                txtNombre.ReadOnly = false;
                txtTelefono.ReadOnly = false;
                txtCUIT.ReadOnly = false;
                txtLiq1.ReadOnly = false;
                txtLiq2.ReadOnly = false;
                txtConvenio1.ReadOnly = false;
                txtConvenio2.ReadOnly = false;
                txtMail.ReadOnly = false;
                txtNombre.ReadOnly = false;
                txtNotas.ReadOnly = false;
                txtTelefono.ReadOnly = false;
            }
            else
            {
                grbRiesgos.Width -= 371;
                grbRiesgos.Height -= 58;

                btnEditar.Text = "Editar";
                chkActive.Visible = false;
                btnGuardar.Visible = false;
                btnNuevoProductor.Visible = false;
                btnQuitarCobertura.Visible = false;
                btnQuitarRiesgo.Visible = false;
                btnQuitarCompañia.Visible = false;
                btnQuitarProductor.Visible = false;
                btnAgregarCompañia.Visible = false;
                btnAgregarCobertura.Visible = false;
                btnAgregarProd.Visible = false;
                btnAgregarRiesgos.Visible = false;
                cmbProductores.Visible = false;
                txtCode.Visible = false;
                lblCodigo.Visible = false;
                txtRiesgo.Visible = false;
                txtCoberturas.Visible = false;
                txtNombre.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtCUIT.ReadOnly = true;
                txtLiq1.ReadOnly = true;
                txtLiq2.ReadOnly = true;
                txtConvenio1.ReadOnly = true;
                txtConvenio2.ReadOnly = true;
                txtMail.ReadOnly = true;
                txtNombre.ReadOnly = true;
                txtNotas.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                if (isNew)
                {
                    isNew = false;
                    InitializeIndex();
                }
            }
        }

        private void LoadAllCoverages()
        {
            lstCoveragesMaster.ValueMember = "Id";
            lstCoveragesMaster.DisplayMember = "Name";
            lstCoveragesMaster.DataSource = coverageService.GetAll().ToList();
        }

        private void btnAgregarCompañia_Click(object sender, EventArgs e)
        {
            isNew = true;
            btnAgregarCompañia.BackColor = SystemColors.Highlight;

            //limpiar todos los controles
            ClearBindings();
            currentCompany = null;
            cmbCompañias.DataSource = null;
            grdContactos.DataSource = null;

            txtNombre.Clear();
            txtTelefono.Clear();
            txtCUIT.Clear();
            txtLiq1.Clear();
            txtLiq2.Clear();
            txtConvenio1.Clear();
            txtConvenio2.Clear();
            txtMail.Clear();
            txtNombre.Clear();
            txtNotas.Clear();
            txtTelefono.Clear();

            InitializeIndex();
        }
        private void btnQuitarCompañia_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
            "Si existen pólizas creadas para esta compañía, la misma no podrá eliminarse. ¿Desea continuar?", "Borrar Compañía", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var obj = cmbCompañias.SelectedItem;
                    var company = (CompanyDto)obj;
                    companyService.DeleteCompany(company);
                    InitializeIndex();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar la Compañía, existen pólizas asociadas.", "Error al Eliminar Compañía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Primero debe crear o seleccionar la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCode.Text != "")
            {
                var prodCode = new ProducerCodeDto();
                prodCode.ProducerId = (int)cmbProductores.SelectedValue;
                prodCode.CompanyId = selectedFullCompany.Id;
                prodCode.Code = txtCode.Text;
                companyService.AddProducer(prodCode);
                grdProductores.DataSource = producerService.GetByCompanyId(selectedFullCompany.Id);
                selectedFullCompany = companyService.GetFullById(currentCompany.Id);
                InitializeProducers();
                if (selectedFullCompany.Producers != null)
                    FillGrdProductores();
            }
            else
                errorProvider1.SetError(txtCode, "Campo vacío");
        }
        private void btnQuitarProductor_Click(object sender, EventArgs e)
        {
            if (grdProductores.DataSource == null)
            {
                MessageBox.Show("Primero debe cargar al menos un productor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var producerId = (int)grdProductores.Rows[grdProductores.SelectedRows[0].Index].Cells["Id"].Value;
            var companyId = selectedFullCompany.Id;
            companyService.DeleteProducerCode(companyId, producerId);
            selectedFullCompany = companyService.GetFullById(currentCompany.Id);
            InitializeProducers();
            if (selectedFullCompany.Producers != null)
                FillGrdProductores();
        }
        private void InitializeProducers()
        {
            grdProductores.DataSource = null;
            txtCode.Text = string.Empty;
        }

        private void btnAgregarRiesgos_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Primero debe crear o seleccionar la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtRiesgo.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un nuevo Riesgo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var risk = new RiskCompanyDto();
                risk.CompanyId = currentCompany.Id;
                risk.Name = txtRiesgo.Text;
                risk.RiskType = cmbTipoRiesgos.SelectedItem.ToString();
                riskService.Create(risk);
                selectedFullCompany = companyService.GetFullById(currentCompany.Id);
                InitializeRisks();
                if (selectedFullCompany.Risks != null)
                    FillLsbRiesgos();
            }
        }
        private void btnQuitarRiesgo_Click(object sender, EventArgs e)
        {
            if (lsbRiesgos.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Al quitar un RIESGO se eliminan todas sus COBERTURAS y PAQUETES. " +
                "Esta acción no será posible si existe alguna póliza con esa cobertura ¿Desea continuar?", "Borrar Riesgo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var riskId = (int)lsbRiesgos.SelectedValue;
                        riskService.Delete(riskId);
                        selectedFullCompany = companyService.GetFullById(currentCompany.Id);
                        InitializeRisks();
                        if (selectedFullCompany.Risks != null)
                            FillLsbRiesgos();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar eliminar el Riesgo, existen coberturas o paquetes asociados.", "Error al Eliminar Riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void InitializeRisks()
        {
            lsbRiesgos.DataSource = null;
            txtRiesgo.Text = string.Empty;
        }

        private void btnAgregarCobertura_Click(object sender, EventArgs e)
        {
            if (currentCompany == null)
            {
                MessageBox.Show("Primero debe crear o seleccionar la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtCoberturas.Text == string.Empty)
            {
                if (lstCoveragesMaster.SelectedItem == null)
                    MessageBox.Show("Ingrese una nueva Cobertura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //toma la cobertura de la lista y debería agregarle el riskId que está seleccionado

                    //asi no va porque risk queda como icollection y no i
                    //var coverage = (CoverageDto)lstCoveragesMaster.SelectedItem;
                    //var risks = coverage.Risks.ToList();
                    //risks.Add((RiskCompanyDto)lsbRiesgos.SelectedItem);

                    //coverageService.Save(coverage);

                    //o tomar el riesgo y agregarle la cobertura seleccionada
                    var risk = (RiskCompanyDto)lsbRiesgos.SelectedItem;
                    List<CoverageDto>coverages = (List<CoverageDto>)lsbCoberturas.DataSource;
                    coverages.Add((CoverageDto)lstCoveragesMaster.SelectedItem);
                    lsbCoberturas.DataSource = coverages; 
                    risk.Coverages = (List<CoverageDto>)lsbCoberturas.DataSource;
                    riskService.Update(risk);
                }
            }
            else
            {
                if (!coverageService.ExistName(txtCoberturas.Text))
                {
                    var coverage = new CoverageDto();
                    coverage.Description = txtCoberturas.Text;
                    //coverage.Name
                    //coverage.Risks
                    coverageService.Save(coverage);

                    // también agregar al riesgo seleccionado

                    riskService.Update((RiskCompanyDto)lsbRiesgos.SelectedItem);

                    selectedFullCompany = companyService.GetFullById(currentCompany.Id);
                    CleanCoveragesCtrls();
                    FillLsbCoberturas();
                }
                else
                {
                    MessageBox.Show("Ya existe una cobertura con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }             
            }
        }
        private void btnQuitarCobertura_Click(object sender, EventArgs e)
        {
            var coverages = lsbCoberturas.SelectedItems;
            if (lsbCoberturas.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea borrar la Cobertura? Tenga en cuenta que será removida de aquellos Paquetes de Coberturas que contengan esta cobertura. Si la cobertura se encuentra en alguna Póliza, no podrá ser eliminada.", "Borrar Cobertura", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        coverageService.DeleteMany(coverages.Cast<CoverageDto>());
                        selectedFullCompany = companyService.GetFullById(currentCompany.Id);
                        CleanCoveragesCtrls();
                        FillLsbCoberturas();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al intentar eliminarla Cobertura, existen pólizas asociadas.", "Error al Eliminar Cobertura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void CleanCoveragesCtrls()
        {
            lsbCoberturas.DataSource = null;
            txtCoberturas.Text = string.Empty;
        }
        private void btnNuevoProductor_Click(object sender, EventArgs e)
        {
            Forms.Productores form = (Productores)DependencyResolver.Instance.Resolve(typeof(Productores));
            form.Show();
        }
        #endregion
    }
}
