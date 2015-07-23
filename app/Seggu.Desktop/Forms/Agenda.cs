using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Agenda : Form
    {
        private IContactService contactService;
        private ICompanyService companyService;
        public Agenda(IContactService contactService, ICompanyService companyService)
        {
            InitializeComponent();
            this.contactService = contactService;
            this.companyService = companyService;
            this.InitializeIndex();
        }

        private void InitializeIndex()
        {
            PopulateCmbEmpresa();
            var table = this.GetContactDataTable();
            if (table.Rows.Count != 0)
            {
                grdContactos.DataSource = table;
                FormatGridContactos();
                AddDataBindings(table);
                SetUIOnlyReadPolicy();
                grdContactos.Enabled = true;
                grdContactos.Select();
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnNuevo.Enabled = false;
                EnableInputControls();
            }
        }
            private void PopulateCmbEmpresa()
            {
                cmbEmpresa.Visible = false;
                cmbEmpresa.DataSource = companyService.GetAll().ToList();
                cmbEmpresa.ValueMember = "Id";
                cmbEmpresa.DisplayMember = "name";
            }
            private DataTable GetContactDataTable()
            {
                var table = new DataTable();
                table.Columns.Add("Id", typeof(string));
                table.Columns.Add("Nombre", typeof(string));
                table.Columns.Add("Apellido", typeof(string));
                table.Columns.Add("Empresa", typeof(string));
                table.Columns.Add("Telefono", typeof(string));
                table.Columns.Add("Mail", typeof(string));
                table.Columns.Add("CompanyId", typeof(string));
                table.Columns.Add("Notas", typeof(string));

                var contacts = this.contactService.GetAll();

                foreach (var contact in contacts)
                {
                    var row = table.NewRow();
                    row["Id"] = contact.Id;
                    row["Nombre"] = contact.FirstName;
                    row["Apellido"] = contact.LastName;
                    row["Empresa"] = contact.Bussiness;
                    row["Telefono"] = contact.Phone;
                    row["Mail"] = contact.Mail;
                    row["CompanyId"] = contact.CompanyId;
                    row["Notas"] = contact.Notes;

                    table.Rows.Add(row);
                }
                return table;
            }
            private void FormatGridContactos()
            {
                this.grdContactos.Columns["Id"].Visible = false;
                this.grdContactos.Columns["Empresa"].Visible = false;
                this.grdContactos.Columns["Telefono"].Visible = false;
                this.grdContactos.Columns["Mail"].Visible = false;
                this.grdContactos.Columns["Notas"].Visible = false;
                this.grdContactos.Columns["CompanyId"].Visible = false;
            }
            private void AddDataBindings(DataTable table)
            {
                ClearDataBidings();

                txtNombre.DataBindings.Add("text", table, "Nombre");
                txtApellido.DataBindings.Add("text", table, "Apellido");
                txtEmpresa.DataBindings.Add("text", table, "Empresa");
                txtTelefono.DataBindings.Add("text", table, "Telefono");
                txtMail.DataBindings.Add("text", table, "Mail");
                txtNotas.DataBindings.Add("text", table, "Notas");
                lblCurrentId.DataBindings.Add("text", table, "Id");
            }
                private void ClearDataBidings()
                {
                    txtNombre.DataBindings.Clear();
                    txtApellido.DataBindings.Clear();
                    txtEmpresa.DataBindings.Clear();
                    txtTelefono.DataBindings.Clear();
                    txtMail.DataBindings.Clear();
                    txtNotas.DataBindings.Clear();
                    lblCurrentId.DataBindings.Clear();
                }
            private void SetUIOnlyReadPolicy()
            {
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtEmpresa.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtMail.ReadOnly = true;
                txtNotas.ReadOnly = true;

                this.chkCompany.Visible = false;
                this.chkCompany.Checked = false;

                this.btnGuardar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnNuevo.Visible = false;
            }
            private void EnableInputControls()
            {
                foreach (Control c in Controls)
                {
                    if (!c.Visible)
                        c.Visible = true;
                    if (c is TextBox)
                        ((TextBox)c).ReadOnly = false;
                }
                lblCurrentId.Visible = false;
                cmbEmpresa.Visible = false;
            }


        private void Guardar(object sender, EventArgs e)
        {
            var isNew = string.IsNullOrEmpty(lblCurrentId.Text);
            var contact = this.GetContactFormInfo();

            if (isNew)
                this.contactService.Create(contact);
            else 
                this.contactService.Update(contact);
            this.InitializeIndex();
        }
            private ContactFullDto GetContactFormInfo()
            {
                var contact = new ContactFullDto();
                contact.Id = this.lblCurrentId.Text;
                contact.FirstName = this.txtNombre.Text;
                contact.LastName = this.txtApellido.Text;
                contact.Mail = this.txtMail.Text;
                contact.Name = this.txtNombre.Text;
                contact.Notes = this.txtNotas.Text;
                contact.Phone = this.txtTelefono.Text;
                if (this.chkCompany.Checked)
                {
                    var company = (CompanyDto)this.cmbEmpresa.SelectedItem;
                    contact.CompanyId = company.Id;
                    contact.Bussiness = company.Name; 
                }
                else
                {
                    contact.CompanyId = null;
                    contact.Bussiness = txtEmpresa.Text;
                }
                return contact;
            }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Id = grdContactos.SelectedCells[0].Value.ToString();
            contactService.Delete(Id);
            InitializeIndex();
        }

        private void chkCompany_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompany.Checked)
                cmbEmpresa.Visible = true;
            else
                cmbEmpresa.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (!chkCompany.Visible)
            {
                EnableInputControls();
                DataGridViewRow row = grdContactos.SelectedRows[0];
                String CompanyId = row.Cells["CompanyId"].Value.ToString();
                grdContactos.Enabled = false;
                if (CompanyId != "")
                {
                    cmbEmpresa.Visible = true;
                    chkCompany.Checked = true;
                    cmbEmpresa.SelectedValue = CompanyId;
                }            
            }
            else
                InitializeIndex();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            grdContactos.Enabled = false;
            grdContactos.ClearSelection();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = false;
                    ((TextBox)c).Clear();
                }
            }
            lblCurrentId.Text = "";
            cmbEmpresa.Visible = false;
            chkCompany.Checked = false;
        }
    }
}
