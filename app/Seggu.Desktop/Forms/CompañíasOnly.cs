using Seggu.Dtos;
using Seggu.Infrastructure;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using Seggu.Data;
using Seggu.Services.DtoMappers;
using System.Text.RegularExpressions;

namespace Seggu.Desktop.Forms
{
    public partial class CompañíasOnly : Form
    {
        private ICompanyService companyService;
        private IProducerService producerService;
        private IMasterDataService masterDataService;
        private CompanyFullDto selectedFullCompany;
        private CompanyDto currentCompany;
        private int lastCompanyIndex;
        private bool isNew;

        public CompañíasOnly(ICompanyService companyService, IProducerService producerService, IMasterDataService masterDataService)
        {
            InitializeComponent();
            this.companyService = companyService;
            this.producerService = producerService;
            this.masterDataService = masterDataService;
            this.InitializeIndex();
            this.isNew = false;

        }

        private void InitializeProducers()
        {
            grdProductores.DataSource = null;
            txtCode.Text = string.Empty;
        }

        private void InitializeIndex()
        {
            lastCompanyIndex = grdCompañias.CurrentCell == null ? 0 : grdCompañias.CurrentCell.RowIndex;
            grdProductores.DataSource = null;
            grdCompañias.DataSource = companyService.GetAll().ToList();
            FormatCompanyGrid();
            PopulateComboboxes();
            if (grdCompañias.Rows.Count > 0)
            {
                grdCompañias.CurrentCell = grdCompañias.Rows[lastCompanyIndex].Cells["Name"];
                btnEditar.Visible = true;
            }
            else
            {
                btnEditar.Visible = false;
            }
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
            cmbProductores.ValueMember = "Id";
            cmbProductores.DisplayMember = "Name";
            cmbProductores.DataSource = producerService.GetProducers().ToList();
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
                return;
            }

            isNew = false;
            currentCompany = (CompanyDto)grdCompañias.CurrentRow.DataBoundItem;
            BindCompaniesTextBoxes(currentCompany);
            SelectCompany();

            if (selectedFullCompany.Producers != null)
                FillGrdProductores();
        }

        private void SelectCompany()
        {
            var id = currentCompany.Id;
            var obj = this.companyService.GetFullById(id);// SegguContainer.Instance.Companies.Single(x => x.Id == id);
            selectedFullCompany = obj;// CompanyDtoMapper.GetCompanyOnly(obj);
        }

        private void BindCompaniesTextBoxes(CompanyDto company)
        {
            //txtNombre.DataBindings.Clear();
            //txtLiq1.DataBindings.Clear();
            //txtLiq2.DataBindings.Clear();
            //txtConvenio1.DataBindings.Clear();
            //txtConvenio2.DataBindings.Clear();
            //txtMail.DataBindings.Clear();
            //txtNotas.DataBindings.Clear();
            //txtTelefono.DataBindings.Clear();
            //txtCUIT.DataBindings.Clear();

            txtNombre.Text = company.Name;
            txtLiq1.Text = company.LiqDay1;
            txtLiq2.Text = company.LiqDay2;
            txtConvenio1.Text = company.Convenio1;
            txtConvenio2.Text = company.Convenio2;
            txtMail.Text = company.Mail;
            txtNotas.Text = company.Notes;
            txtTelefono.Text = company.Phone;
            txtCUIT.Text = company.CUIT;

            //txtNombre.DataBindings.Add("text", company, "Name");
            //txtLiq1.DataBindings.Add("text", company, "LiqDay1");
            //txtLiq2.DataBindings.Add("text", company, "LiqDay2");
            //txtConvenio1.DataBindings.Add("text", company, "Convenio1");
            //txtConvenio2.DataBindings.Add("text", company, "Convenio2");
            //txtMail.DataBindings.Add("text", company, "Mail");
            //txtNotas.DataBindings.Add("text", company, "Notes");
            //txtTelefono.DataBindings.Add("text", company, "Phone");
            //txtCUIT.DataBindings.Add("text", company, "CUIT");
        }

        private void GetForUpdate()
        {
            currentCompany.CUIT = txtCUIT.Text;
            currentCompany.LiqDay1 = txtLiq1.Text;
            currentCompany.LiqDay2 = txtLiq2.Text;
            currentCompany.Convenio1 = txtConvenio1.Text;
            currentCompany.Convenio2 = txtConvenio2.Text;
            currentCompany.Mail = txtMail.Text;
            currentCompany.Name = txtNombre.Text;
            currentCompany.Notes = txtNotas.Text;
            currentCompany.Phone = txtTelefono.Text;
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

                        try
                        {
                            this.companyService.Create(company);
                            MessageBox.Show("Compañía creada exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Error al intentar crear la Compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Ya existe una compañía con ese nombre. Ingrese un nombre diferente.", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    GetForUpdate();
                    try
                    {
                        this.companyService.Update(currentCompany);
                        MessageBox.Show("Compañía se ha modificado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al intentar modificar la Compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

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
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        errorProvider1.SetError(control, "Campo vacío");
                        ok = false;
                    }
                }
                if (control == txtMail)
                {
                    if (!ComprobarFormatoEmail(txtMail.Text))
                    {
                        errorProvider1.SetError(control, "Formato de Mail inválido");
                        ok = false;
                    }
                }


            }

            foreach (Control control in grpLiquida.Controls)
            {
                if (control == txtLiq2 || control == txtLiq1 || control == txtConvenio1 || control == txtConvenio2)
                {
                    if (!string.IsNullOrWhiteSpace(control.Text))
                    {
                        int dia;
                        try
                        {
                            dia = Convert.ToInt32(control.Text);
                            if (dia > 30 || dia <= 0)
                            {
                                errorProvider1.SetError(control, "Día fuera de rango válido");
                                ok = false;
                            }
                        }
                        catch
                        {
                            errorProvider1.SetError(control, "Formato inválido");
                            ok = false;
                        }


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

        private void btnNuevoProductor_Click(object sender, EventArgs e)
        {
            Forms.Productores form = (Productores)DependencyResolver.Instance.Resolve(typeof(Productores));
            form.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!btnGuardar.Visible)
            {
                if (currentCompany == null)
                {
                    MessageBox.Show("Primero debe seleccionar una compañía.", "Seleccionar Compañía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                btnGuardar.Visible = true;
                // btnNuevoProductor.Visible = true;
                btnQuitarCompañia.Visible = true;
                btnQuitarProductor.Visible = true;
                btnAgregarProd.Visible = true;
                btnAgregarCompañia.Visible = true;
                btnNuevoProductor.Visible = true;

                btnAgregarProd.Visible = true;

                cmbProductores.Visible = true;
                cmbProductores.Enabled = true;
                label8.Visible = true;
                txtCode.Visible = true;
                txtCode.Enabled = true;
                txtCode.ReadOnly = false;
                lblCodigo.Visible = true;
                //btnRecuperar.Visible = true;

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
                btnGuardar.Visible = false;
                // btnNuevoProductor.Visible = false;
                btnQuitarCompañia.Visible = false;
                btnQuitarProductor.Visible = false;
                btnAgregarCompañia.Visible = false;
                btnAgregarProd.Visible = false;
                cmbProductores.Visible = false;
                label8.Visible = false;
                txtCode.Visible = false;
                lblCodigo.Visible = false;
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
            }
        }

        private void btnAgregarCompañia_Click(object sender, EventArgs e)
        {
            //limpiar todos los controles
            isNew = true;
            currentCompany = null;
            //btnAgregarCompañia.BackColor = SystemColors.Highlight;
            lblNuevaCompañia.Visible = true;
            //grdCompañias.DataSource = null;
            //lsbRiesgos.DataSource = riskService.GetAll().ToList();
            //lsbCoberturas.DataSource = coverageService.GetAll().ToList();
            //grdProductores.DataSource = producerService.GetProducers().ToList();
            grdContactos.DataSource = null;

            txtNombre.Clear();
            txtTelefono.Clear();
            txtCUIT.Clear();
            txtLiq1.Clear();
            txtLiq2.Clear();
            txtConvenio1.Clear();
            txtConvenio2.Clear();
            txtMail.Clear();
            txtNotas.Clear();
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtCUIT.Enabled = true;
            txtLiq1.Enabled = true;
            txtLiq2.Enabled = true;
            txtConvenio1.Enabled = true;
            txtConvenio2.Enabled = true;
            txtMail.Enabled = true;
            txtNotas.Enabled = true;
            txtNombre.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCUIT.ReadOnly = false;
            txtLiq1.ReadOnly = false;
            txtLiq2.ReadOnly = false;
            txtConvenio1.ReadOnly = false;
            txtConvenio2.ReadOnly = false;
            txtMail.ReadOnly = false;
            txtNotas.ReadOnly = false;
            this.btnGuardar.Visible = true;
            this.btnCancelar.Visible = true;
            this.cmbProductores.Visible = true;
            this.txtCode.Visible = true;
            this.btnAgregarProd.Visible = true;
            this.btnQuitarProductor.Visible = true;
            this.btnNuevoProductor.Visible = true;
            btnGuardar.Visible = true;
            // btnNuevoProductor.Visible = true;
            btnQuitarCompañia.Visible = true;
            btnQuitarProductor.Visible = true;
            btnAgregarCompañia.Visible = true;

            btnAgregarProd.Visible = true;

            cmbProductores.Visible = true;
            label8.Visible = true;
            txtCode.Visible = true;
            lblCodigo.Visible = true;
            cmbProductores.Enabled = true;
            txtCode.ReadOnly = false;
            txtCode.Enabled = true;
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
                    var obj = this.grdCompañias.CurrentRow.DataBoundItem;
                    var company = (CompanyDto)obj;
                    companyService.DeleteCompany(company);
                    InitializeIndex();
                    MessageBox.Show("Compañía eliminada Exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al intentar eliminar la Compañía, existen pólizas asociadas.", "Error al Eliminar Compañía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show(
                    //"Una excepcion ha llegado a la aplicacion. Por favor copiar el siguiente mensaje y consultar al equipo tecnico.\n" 
                    //ex.Message + "\n" + ex.StackTrace + (ex.InnerException == null ? string.Empty : "\nInner Exception: " +
                    //ex.InnerException.Message + "\nStackTrace: " +
                    //ex.InnerException.StackTrace), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtCode.Text != string.Empty)
            {

                var existe = false;
                var existeCod = false;
                var prodCode = new ProducerCodeDto();
                prodCode.ProducerId = (int)cmbProductores.SelectedValue;
                prodCode.CompanyId = selectedFullCompany.Id;
                prodCode.Code = txtCode.Text;

                foreach (ProducerCompanyDto prod in selectedFullCompany.Producers)
                {
                    if (prod.Id == prodCode.ProducerId)
                    {
                        existe = true;
                        break;
                    }
                    else if (prod.Code == prodCode.Code)
                    {
                        existeCod = true;
                    }

                }

                if (existe)
                {
                    MessageBox.Show("El productor asignado ya existe para esta compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (existeCod)
                {
                    MessageBox.Show("El código ingresado ya existe para un productor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {

                    companyService.AddProducer(prodCode);

                    MessageBox.Show("Productor agregado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SelectCompany();
                    InitializeProducers();
                    grdProductores.DataSource = producerService.GetByCompanyId(selectedFullCompany.Id);
                    if (selectedFullCompany.Producers != null)
                        FillGrdProductores();
                }
                catch (Exception ex)
                {
                    string a = ex.Message;
                    MessageBox.Show("Error al agregar el productor a la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {

                }
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

            if (grdProductores.CurrentRow == null)
            {
                MessageBox.Show("Primero debe seleccionar un productor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var producerId = (int)grdProductores.Rows[grdProductores.SelectedRows[0].Index].Cells["Id"].Value;
                var companyId = selectedFullCompany.Id;
                companyService.DeleteProducerCode(companyId, producerId);

                MessageBox.Show("Productor removido exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SelectCompany();
                InitializeProducers();
                if (selectedFullCompany.Producers != null)
                    FillGrdProductores();

            }
            catch
            {
                MessageBox.Show("Error al quitar el productor a la compañía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtLiq1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtLiq2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtConvenio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtConvenio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private static bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InitializeIndex();
        }
    }
}
