using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using Seggu.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Seggu.Data;

namespace Seggu.Desktop.UserControls
{
    public partial class AseguradosUserControl : UserControl
    {
        private IClientService clientService;
        private IProducerService producerService;
        private IDistrictService districtService;
        private ILocalityService localityService;
        private IProvinceService provinceService;
        private IMasterDataService masterdataService;
        private ClientIndexDto currentIndexClient;
        private ClientFullDto currentClient;
        private int? currentHomeAddressId;
        private int? currentCollectionAddressId;
        private IEnumerable<ProvinceDto> provinces;
        private IEnumerable<DistrictDto> districts;
        private IEnumerable<LocalityDto> localities;

        private IEnumerable<DistrictDto> filteredDistricts;
        private IEnumerable<LocalityDto> filteredLocalities;
        private IEnumerable<DistrictDto> filteredCollectorDistricts;
        private IEnumerable<LocalityDto> filteredCollectorLocalities;

        public AseguradosUserControl(IClientService clientService, IProducerService producerService,
            IDistrictService districtService, ILocalityService localityService, IProvinceService provinceService,
            IMasterDataService masterdataService)
        {
            InitializeComponent();

            this.clientService = clientService;
            this.producerService = producerService;
            this.districtService = districtService;
            this.localityService = localityService;
            this.provinceService = provinceService;
            this.masterdataService = masterdataService;

            provinces = provinceService.GetAll().ToList();
            districts = districtService.GetAll().ToList();
            localities = localityService.GetAll().ToList();
        }

        private Layout LayoutForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

        private void AseguradosUserControl_Load(object sender, EventArgs e)
        {
            InitializeComboboxes();
        }
        private void InitializeComboboxes()
        {
            cmbProvince.ValueMember = "Id";
            cmbProvince.DisplayMember = "Name";
            cmbProvince.DataSource = provinces.ToList();

            cmbProvinceCollector.ValueMember = "Id";
            cmbProvinceCollector.DisplayMember = "Name";
            cmbProvinceCollector.DataSource = provinces.ToList();

            cmbEstado.DataSource = masterdataService.GetMaritalStatuses().ToList();
            cmbIva.DataSource = masterdataService.GetIvas().ToList();
            cmbSexo.DataSource = masterdataService.GetSexs().ToList();
            cmbTipoDoc.DataSource = masterdataService.GetIdTypes().ToList();

            SetComboboxes();
        }
        private void SetComboboxes()
        {
            cmbTipoDoc.SelectedItem = "DNI";
            cmbIva.SelectedItem = "CONSUMIDOR FINAL";
            cmbEstado.SelectedItem = "SOLTERO";
            cmbSexo.SelectedItem = "MASCULINO";
        }

        public void NewClient()
        {
            tctrlAseguradosControl.SelectedIndex = 1;
        }

        public void InitializeIndex()
        {
            clientGrid.DataSource = clientService.GetAll().ToList();
            clientGrid.Columns["Id"].Visible = false;
            clientGrid.Select();
        }

        public void ListClientsWithValidsPolicies()
        {
            clientGrid.DataSource = clientService.GetValids().ToList();
            clientGrid.Columns["Id"].Visible = false;
        }

        private void cmbProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbLocality.DataSource = null;
            cmbLocalityCollector.DataSource = null;

            filteredDistricts = districtService.GetFilteredByProvince((int)cmbProvince.SelectedValue).ToList();
            cmbDistrict.ValueMember = "Id";
            cmbDistrict.DisplayMember = "Name";
            cmbDistrict.DataSource = filteredDistricts;
            //cmblocalities_index changed ya carga las filteredLocalities
            cmbProvinceCollector.SelectedValue = cmbProvince.SelectedValue;

            filteredCollectorDistricts = districtService.GetFilteredByProvince((int)cmbProvinceCollector.SelectedValue).ToList();
            cmbDistrictCollector.ValueMember = "Id";
            cmbDistrictCollector.DisplayMember = "Name";
            cmbDistrictCollector.DataSource = filteredCollectorDistricts;
        }
        private void cmbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filteredLocalities = localityService.GetByDistrictId((int)cmbDistrict.SelectedValue).ToList();
            cmbLocality.DisplayMember = "Name";
            cmbLocality.ValueMember = "Id";
            cmbLocality.DataSource = filteredLocalities;

            cmbDistrictCollector_SelectionChangeCommitted(sender, e);
        }
        private void cmbProvinceCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbLocalityCollector.DataSource = null;
            filteredCollectorDistricts = districtService.GetFilteredByProvince((int)cmbProvinceCollector.SelectedValue).ToList();
            cmbDistrictCollector.ValueMember = "Id";
            cmbDistrictCollector.DisplayMember = "Name";
            cmbDistrictCollector.DataSource = filteredCollectorDistricts;
        }
        private void cmbDistrictCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!cmbDistrictCollector.Focused)
                cmbDistrictCollector.SelectedValue = cmbDistrict.SelectedValue;
            filteredCollectorLocalities = localityService.GetByDistrictId((int)cmbDistrictCollector.SelectedValue).ToList();
            cmbLocalityCollector.ValueMember = "Id";
            cmbLocalityCollector.DisplayMember = "Name";
            cmbLocalityCollector.DataSource = filteredCollectorLocalities;
        }
        private void cmbLocality_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbLocalityCollector.SelectedValue = cmbLocality.SelectedValue;
        }


        public void FindClientByDNI(string txtBuscar)
        {
            clientGrid.DataSource = clientService.GetByDNI(txtBuscar).ToList();
            FormatFullClientGrid();
        }


        private void SaveClient(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                var client = GetFormInformation();
                clientService.Save(client);
                MessageBox.Show("El asegurado se guardo con exito.");
                tctrlAseguradosControl.SelectedIndex = 0;
                FindClientByName(client.Apellido);

                //DialogResult dialogResult = MessageBox.Show("El cliente se guardó con éxito," +
                //    " ¿desea crear una NUEVA póliza para " + client.Apellido + "?",
                //    "Nueva Póliza", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{
                //    this.Dispose();

                //if new client, go to new pOlicy (usar messagebox que pregunte si quiere crear una nueva pol)
                //}
            }
        }
        private bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Campo vacio");
                ok = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Campo vacio");
                ok = false;
            }
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                errorProvider1.SetError(txtDNI, "Campo vacio");
                ok = false;
            }
            else if (currentClient == null)
            {
                var dni = this.txtDNI.Text;
                var exists = SegguContainer.Instance.Clients.Any(x => x.Document == dni);
                if (exists)
                {
                    errorProvider1.SetError(this.txtDNI, "Ya existe un asegurado con el mismo documento");
                    ok = false;
                }
            }
            if (string.IsNullOrEmpty(txtHomeStreet.Text))
            {
                errorProvider1.SetError(txtHomeStreet, "Campo vacio");
                ok = false;
            }
            if (string.IsNullOrEmpty(txtHomePostal.Text))
            {
                errorProvider1.SetError(txtHomePostal, "Campo vacio");
                ok = false;
            }
            if (string.IsNullOrEmpty(txtHomePhone.Text))
            {
                errorProvider1.SetError(txtHomePhone, "Campo vacio");
                ok = false;
            }
            else if (!txtHomePhone.Text.IsAllNumbers())
            {
                errorProvider1.SetError(txtHomePhone, "El campo solo puede contener numeros");
                ok = false;
            }
            if (!string.IsNullOrEmpty(txtCollectionPhone.Text) && !txtCollectionPhone.Text.IsAllNumbers())
            {
                errorProvider1.SetError(txtCollectionPhone, "El campo solo puede contener numeros");
                ok = false;
            }
            if (cmbDistrict.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbDistrict, "Debe seleccionar un valor. Si no ve opciones, intente seleccionar la provincia");
                ok = false;
            }
            if (cmbLocality.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbLocality, "Debe seleccionar un valor. Si no ve opciones, intente seleccionar la provincia");
                ok = false;
            }
            if (cmbProvince.SelectedIndex < 1)
            {
                errorProvider1.SetError(cmbProvince, "Debe seleccionar un valor");
                ok = false;
            }
            if (cmbDistrictCollector.SelectedIndex == -1 && !string.IsNullOrEmpty(txtCollectionStreet.Text))
            {
                errorProvider1.SetError(cmbDistrictCollector, "Debe seleccionar un valor. Si no ve opciones, intente seleccionar la provincia");
                ok = false;
            }
            if (cmbLocalityCollector.SelectedIndex == -1 && !string.IsNullOrEmpty(txtCollectionStreet.Text))
            {
                errorProvider1.SetError(cmbLocalityCollector, "Debe seleccionar un valor. Si no ve opciones, intente seleccionar la provincia");
                ok = false;
            }
            if (cmbProvinceCollector.SelectedIndex < 1 && !string.IsNullOrEmpty(txtCollectionStreet.Text))
            {
                errorProvider1.SetError(cmbProvinceCollector, "Debe seleccionar un valor.");
                ok = false;
            }
            return ok;
        }
        private ClientFullDto GetFormInformation()
        {
            var client = new ClientFullDto();
            client.Id = currentClient == null ? default(int) : currentClient.Id;
            client.Nombre = txtFirstName.Text;
            client.Apellido = txtApellido.Text;
            client.Tel_Móvil = txtCel.Text;
            client.DocumentTypes = (string)cmbTipoDoc.SelectedValue;
            client.DNI = txtDNI.Text;
            client.BirthDate = dtpBirthDate.Value.ToShortDateString();
            client.Cuit = txtCuit.Text;
            client.IngresosBrutos = txtIB.Text;
            client.CollectionTimeRange = txtCollectionRange.Text;
            client.BankingCode = txtCBU.Text;
            client.Notes = txtNotas.Text;
            client.IsSmoker = ckbFumador.Checked;
            client.Sex = (string)cmbSexo.SelectedValue;
            client.HomeStreet = txtHomeStreet.Text;
            client.HomeNumber = txtHomeNumber.Value.ToString();
            client.HomeFloor = txtHomeFloor.Text;
            client.HomeAppartment = txtHomeAppart.Text;
            client.HomePostalCode = txtHomePostal.Text;
            client.HomeLocalityId = (int)cmbLocality.SelectedValue;
            client.HomeDistrictId = (int)cmbDistrict.SelectedValue;
            client.HomeProvinceId = (int)cmbProvince.SelectedValue;
            client.HomePhone = txtHomePhone.Text;
            client.MaritalStatus = (string)cmbEstado.SelectedValue;
            client.Iva = (string)cmbIva.SelectedValue;
            client.Mail = txtMail.Text;
            client.CollectionAppartment = txtCollectionAppartment.Text;
            client.CollectionFloor = txtCollectionFloor.Text;
            client.CollectionLocalityId = (int)cmbLocalityCollector.SelectedValue;
            client.CollectionDistrictId = (int)cmbDistrictCollector.SelectedValue;
            client.CollectionProvinceId = (int)cmbProvinceCollector.SelectedValue;
            client.CollectionNumber = txtCollectionNumber.Text;
            client.CollectionPhone = txtCollectionPhone.Text;
            client.CollectionPostalCode = txtCollectionPostalCode.Text;
            client.CollectionStreet = txtCollectionStreet.Text;
            client.HomeAddressId = currentHomeAddressId ?? default(int);
            client.CollectionAddressId = currentCollectionAddressId ?? default(int);
            client.Occupation = txtOccupation.Text;
            return client;
        }


        public void FindClientByName(string txtBuscar)
        {
            try
            {
                clientGrid.Focus();
                clientGrid.DataSource = clientService.GetByName(txtBuscar).ToList();
                FormatFullClientGrid();
                clientGrid.Select();
            }
            catch (Exception ex)
            { throw ex; }
        }
        private void FormatFullClientGrid()
        {
            foreach (DataGridViewColumn c in clientGrid.Columns)
                c.Visible = false;
            clientGrid.Columns["Nombre"].Visible = true;
            clientGrid.Columns["Apellido"].Visible = true;
            clientGrid.Columns["Tel_Móvil"].Visible = true;
        }


        private void clientGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (!clientGrid.Focused) return;//para evitar error null reference
            if (clientGrid.CurrentRow.DataBoundItem.GetType().Name == "ClientFullDto")
            {
                currentClient = (ClientFullDto)clientGrid.CurrentRow.DataBoundItem;
                //LayoutForm.MostrarCantPolizas(currentClient.PolicyCount);
            }
            SendClientToSideBar();
            if (clientGrid.RowCount > 0) clientGrid.Select();// para navegar con teclas flecha            
        }
        private void GoToDetails_DoubleCLick(object sender, DataGridViewCellEventArgs e)
        {
            if (clientGrid.CurrentRow.DataBoundItem.GetType().Name == "ClientFullDto")
                currentClient = (ClientFullDto)clientGrid.CurrentRow.DataBoundItem;
            else
            {
                var clientId = ((ClientIndexDto)clientGrid.CurrentRow.DataBoundItem).Id;
                currentClient = clientService.GetById(clientId);
            }
            SendClientToSideBar();
            PopulateClientInformation();
            tctrlAseguradosControl.SelectedIndex = 1;
        }
        private void SendClientToSideBar()
        {
            var clientId = (int)clientGrid.CurrentRow.Cells["Id"].Value;
            currentIndexClient = clientService.GetShortDtoById(clientId);
            LayoutForm.LoadClientSideBar(currentIndexClient);
        }

        private void PopulateClientInformation()
        {
            txtFirstName.Text = currentClient.Nombre;
            txtApellido.Text = currentClient.Apellido;
            txtCel.Text = (currentClient.Tel_Móvil ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtDNI.Text = (currentClient.DNI ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtCuit.Text = (currentClient.Cuit ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtIB.Text = currentClient.IngresosBrutos;
            txtCollectionRange.Text = currentClient.CollectionTimeRange;
            txtCBU.Text = (currentClient.BankingCode ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtNotas.Text = currentClient.Notes;
            txtHomeStreet.Text = currentClient.HomeStreet;
            txtHomeNumber.Value = Convert.ToDecimal(currentClient.HomeNumber);
            txtHomeFloor.Text = currentClient.HomeFloor;
            txtHomeAppart.Text = currentClient.HomeAppartment;
            txtHomePostal.Text = currentClient.HomePostalCode;
            txtHomePhone.Text = (currentClient.HomePhone ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtMail.Text = currentClient.Mail;
            txtCollectionAppartment.Text = currentClient.CollectionAppartment;
            txtCollectionFloor.Text = currentClient.CollectionFloor;
            txtCollectionNumber.Text = currentClient.CollectionNumber;
            txtCollectionPhone.Text = (currentClient.CollectionPhone ?? string.Empty).RemoveAll(" ", ".", "-", "/");
            txtCollectionPostalCode.Text = currentClient.CollectionPostalCode;
            txtCollectionStreet.Text = currentClient.CollectionStreet;
            txtOccupation.Text = currentClient.Occupation;
            cmbSexo.SelectedItem = currentClient.Sex;
            cmbTipoDoc.SelectedItem = currentClient.DocumentTypes;
            cmbEstado.SelectedItem = currentClient.MaritalStatus;
            cmbIva.SelectedItem = currentClient.Iva;

            cmbProvinceCollector.DataSource = provinces;
            cmbDistrictCollector.DataSource = districts;
            cmbLocalityCollector.DataSource = localities;
            cmbProvince.DataSource = provinces;
            cmbDistrict.DataSource = districtService.GetAll().ToList();
            cmbLocality.DataSource = localityService.GetAll().ToList();

            cmbProvince.SelectedValue = currentClient.HomeProvinceId == null ? cmbProvince.SelectedValue : currentClient.HomeProvinceId;
            cmbDistrict.SelectedValue = currentClient.HomeDistrictId == null ? cmbDistrict.SelectedValue : currentClient.HomeDistrictId;
            cmbLocality.SelectedValue = currentClient.HomeLocalityId == null ? cmbLocality.SelectedValue : currentClient.HomeLocalityId;
            cmbProvinceCollector.SelectedValue = currentClient.CollectionProvinceId == null ? cmbProvinceCollector.SelectedValue : currentClient.CollectionProvinceId;
            cmbDistrictCollector.SelectedValue = currentClient.CollectionDistrictId == null ? cmbDistrictCollector.SelectedValue : currentClient.CollectionDistrictId;
            cmbLocalityCollector.SelectedValue = currentClient.CollectionLocalityId == null ? cmbLocalityCollector.SelectedValue : currentClient.CollectionLocalityId;

            ckbFumador.Checked = currentClient.IsSmoker;
            dtpBirthDate.Text = currentClient.BirthDate;
            // = currentClient.CreditCards;
            currentHomeAddressId = currentClient.HomeAddressId;
            currentCollectionAddressId = currentClient.CollectionAddressId;
        }

        private void EmptyControlsDetalleTab()
        {
            foreach (TabPage tabPage in tctrlAseguradosControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TextBox)
                        control.Text = string.Empty;
                    else if (control is ComboBox)
                        (control as ComboBox).SelectedIndex = -1;
                    else if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else if (control is DateTimePicker)
                        (control as DateTimePicker).Value = DateTime.Today;
                    else if (control is GroupBox)
                    {
                        foreach (Control groupBoxControl in control.Controls)
                        {
                            if (groupBoxControl is TextBox)
                                groupBoxControl.Text = string.Empty;
                            else if (groupBoxControl is ComboBox)
                                (groupBoxControl as ComboBox).SelectedIndex = -1;
                            else if (groupBoxControl is CheckBox)
                                (groupBoxControl as CheckBox).Checked = false;
                            else if (groupBoxControl is DateTimePicker)
                                (groupBoxControl as DateTimePicker).Value = DateTime.Today;
                        }
                    }
                }
            }
        }

        private void txtHomeStreet_TextChanged(object sender, EventArgs e)
        {
            txtCollectionStreet.Text = txtHomeStreet.Text;
        }

        private void txtHomeNumber_TextChanged(object sender, EventArgs e)
        {
            txtCollectionNumber.Value = txtHomeNumber.Value;
        }

        private void clientGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clientGrid.CurrentRow.DataBoundItem.GetType().Name == "ClientFullDto")
            {
                currentClient = (ClientFullDto)clientGrid.CurrentRow.DataBoundItem;
                //LayoutForm.MostrarCantPolizas(currentClient.PolicyCount);
            }
            SendClientToSideBar();

        }

        private void clientGrid_MouseLeave(object sender, EventArgs e)
        {
            //por alguna razón la grilla permanece en foco y en el selectionchanged hace lo que no debe
            // así otro control toma el focus y la cliengrid lo pierde
            ActiveControl = label1;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (StringExtensions.isTextNumber(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void txtCBU_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (StringExtensions.isTextNumber(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtIB_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (StringExtensions.isTextNumber(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (StringExtensions.isTextNumber(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void tctrlAseguradosControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tctrlAseguradosControl.SelectedIndex == 1 && this.clientGrid.Rows.Count > 0)
            {
                this.tctrlAseguradosControl.SelectedIndex = 0;
            }
        }



        //private void PopulateTarjetaCreditoDatos(ClientInformationDto aseg)
        //{
        //    IList<tarj_cre> tarjCre = tarjetaCreditoRepository.SelectWhere(x => x.cod_aseg == aseg.codigo).ToList();
        //}
    }
}
