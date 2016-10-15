using Seggu.Desktop.Forms;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.UserControls
{
    public partial class IntegralPolicyUserControl : UserControl
    {
        private ICoverageService coverageService;
        private ICoveragesPackService coveragesPackService;
        private IProvinceService provinceService;
        private IDistrictService districtService;
        private ILocalityService localityService;

        private IEnumerable<ProvinceDto> provinces;
        private IEnumerable<DistrictDto> districts;
        private IEnumerable<LocalityDto> localities;

        private IEnumerable<DistrictDto> filteredDistricts;
        private IEnumerable<LocalityDto> filteredLocalities;

        private List<IntegralDto> integralList = new List<IntegralDto>();
        private IntegralDto currentIntegral = new IntegralDto();
        private List<CoverageDto> coverages = new List<CoverageDto>();

        public string province;
        public string district;

        public Layout MainForm
        {
            get
            {
                return (Layout)this.FindForm();
            }
        }

        public IntegralPolicyUserControl(ICoveragesPackService coveragesPackService, ICoverageService coverageService, IProvinceService provinceService, IDistrictService districtService,
            ILocalityService localityService)
        {
            InitializeComponent();
            this.coverageService = coverageService;
            this.coveragesPackService = coveragesPackService;
            this.provinceService = provinceService;
            this.districtService = districtService;
            this.localityService = localityService;

            provinces = provinceService.GetAll().ToList();
            districts = districtService.GetAll().ToList();
            localities = localityService.GetAll().ToList();
        }

        public void InitializeComboboxes(int riskId)
        {
            FillCmbCubre(riskId);
            FillCmbCoverages(riskId);

            cmbProvince.ValueMember = "Id";
            cmbProvince.DisplayMember = "Name";
            cmbProvince.DataSource = provinces;

            cmbDistrict.DataSource = districts;
            cmbDistrict.ValueMember = "id";
            cmbDistrict.DisplayMember = "Name";
            cmbDistrict.SelectedIndex = -1;

            cmbLocality.DataSource = localities;
            cmbLocality.ValueMember = "Id";
            cmbLocality.DisplayMember = "Name";
            cmbLocality.SelectedIndex = -1;
        }
        private void FillCmbCubre(int riskId)
        {
            cmbCubre.DataSource = coveragesPackService.GetAllByRiskId(riskId).ToList();
            cmbCubre.DisplayMember = "Name";
            cmbCubre.ValueMember = "Id";
        }
        private void FillCmbCoverages(int riskId)
        {
            cmbCoverages.DataSource = coverageService.GetAllByRiskId(riskId).ToList();
            cmbCoverages.DisplayMember = "Name";
            cmbCoverages.ValueMember = "Id";
        }

        public void PopulateEndorseIntegral()
        {
            if (MainForm.currentEndorse.Integrals == null) return;

            integralList = MainForm.currentEndorse.Integrals.ToList();
            currentIntegral = integralList.FirstOrDefault();
            PopulateAddress(currentIntegral.Address);
            coverages = currentIntegral.Coverages.ToList();
            ReLoadGrdCoverages();
        }
        public void PopulatePolicyIntegral()
        {
            if ( MainForm.currentPolicy.Integrals == null ) return;

            integralList = MainForm.currentPolicy.Integrals
                .Where(v => v.EndorseId==null).ToList();
            currentIntegral = integralList.FirstOrDefault();
            if (currentIntegral.Address != null)
                PopulateAddress(currentIntegral.Address);
            coverages = currentIntegral.Coverages.ToList();
            ReLoadGrdCoverages();
        }
        private void PopulateAddress(AddressDto address)
        {
            txtHomeAppart.Text = address.Appartment;
            txtHomeFloor.Text = address.Floor;
            txtHomeNumber.Text = address.Number;
            txtHomePostal.Text = address.PostalCode;
            txtHomeStreet.Text = address.Street;
            cmbProvince.SelectedValue = address.ProvinceId;
            province = cmbProvince.Text;
            cmbDistrict.SelectedValue = address.DistrictId;
            district = cmbDistrict.Text;
            cmbLocality.SelectedValue = address.LocalityId;
        }

        private void cmbCubre_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbCubre.SelectedIndex != -1)
            {
                var response = MessageBox.Show(
                    "Desea reemplazar las coberturas existentes con las que pertenecen al paquete seleccionado?",
                    "Coberturas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.None
                );
                if (response == DialogResult.Yes)
                {
                    var coveragesPack = (CoveragesPackDto)cmbCubre.SelectedItem;
                    coverages = coveragesPack.Coverages.ToList();
                    grdCoverages.DataSource = coverages;
                    FormatCoveragesGrid();
                }
            }
        }

        private void FormatCoveragesGrid()
        {
            grdCoverages.ClearSelection();
            foreach (DataGridViewColumn c in grdCoverages.Columns)
                c.Visible = false;
            grdCoverages.Columns["Description"].Visible = true;
        }

        public List<IntegralDto> GetIntegral()
        {
            AddressDto address = new AddressDto();
            address.Appartment = this.txtHomeAppart.Text;
            address.Floor = txtHomeFloor.Text;
            address.Id = currentIntegral.Address == null ? default(int) : currentIntegral.Address.Id;
            address.LocalityId = (int)this.cmbLocality.SelectedValue;
            address.Number = txtHomeNumber.Text;
            address.PostalCode = this.txtHomePostal.Text;
            address.Street = this.txtHomeStreet.Text;

            IntegralDto integral = new IntegralDto();
            integral.Address = address;
            integral.Coverages = coverages;
            integral.district = cmbDistrict.Text;
            integral.EndorseId = MainForm.currentEndorse == null ? null : (int?)MainForm.currentEndorse.Id;
            integral.Id = currentIntegral == null ? default(int) : currentIntegral.Id;
            integral.locality = cmbLocality.Text;
            integral.PolicyId = MainForm.currentPolicy.Id;
            integral.province = cmbProvince.Text;
            currentIntegral = integral;

            integralList.Clear();
            integralList.Add(currentIntegral);
            return integralList;
        }

        private void cmbProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbLocality.DataSource = null;

            filteredDistricts = districtService.GetFilteredByProvince((int)cmbProvince.SelectedValue).ToList();
            cmbDistrict.ValueMember = "Id";
            cmbDistrict.DisplayMember = "Name";
            cmbDistrict.DataSource = filteredDistricts;

            province = cmbProvince.Text;//for printing
        }
        private void cmbDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filteredLocalities = localityService.GetByDistrictId((int)cmbDistrict.SelectedValue).ToList();
            cmbLocality.DisplayMember = "Name";
            cmbLocality.ValueMember = "Id";
            cmbLocality.DataSource = filteredLocalities;

            district = cmbDistrict.Text;
        }


        private void btnAddCoverage_Click(object sender, EventArgs e)
        {
            if (cmbCoverages.SelectedIndex == -1) return;
            var coverageInCombo = (CoverageDto)cmbCoverages.SelectedItem;

            var coveragesInGrid = (List<CoverageDto>)grdCoverages.DataSource;
            if (coveragesInGrid != null)
            {
                if (coveragesInGrid.Exists(x => x.Id == coverageInCombo.Id))
                    return;
            }
            coverages.Add((CoverageDto)cmbCoverages.SelectedItem);
            ReLoadGrdCoverages();
        }
        private void btnRemoveCoverage_Click(object sender, EventArgs e)
        {
            if (grdCoverages.SelectedRows.Count < 1) return;

            coverages.Remove((CoverageDto)grdCoverages.CurrentRow.DataBoundItem);
            ReLoadGrdCoverages();
        }
        private void ReLoadGrdCoverages()
        {
            grdCoverages.DataSource = null;
            grdCoverages.DataSource = coverages;
            FormatCoveragesGrid();
        }

        #region validaciones
        public bool ValidateControls()
        {
            bool ok = true;
            errorProvider1.Clear();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c == txtHomeNumber || c == txtHomeStreet || c == txtHomePostal)
                        if (c.Text == string.Empty)
                        {
                            errorProvider1.SetError(c, "Campo vacío. Este campo es obligatorio.");
                            ok = false;
                        }
                    if(c == txtHomePostal)
                    {
                        if(c.Text.Length <4)
                        {
                            errorProvider1.SetError(c, "El codigo postal no es valido.");
                            ok = false;
                        }
                    }
                }

                if (c is ComboBox)
                {
                    if (c == cmbLocality || c == cmbDistrict || c == cmbProvince)
                        if ((c as ComboBox).SelectedIndex == -1 )
                        {
                            errorProvider1.SetError(c, "Debe seleccionar un elemento");
                            ok = false;
                        }
                }

                if(c is DataGridView)
                {
                    if(c == grdCoverages && (c as DataGridView).RowCount == 0)
                    {
                        errorProvider1.SetError(c, "Debe asignar coberturas a la poliza.");
                        ok = false;
                    }
                }

            }
            return ok;
        }
        public void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;
            var decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            if (c == 46 && (sender as TextBox).Text.IndexOf(decimalSeparator) != -1)
            {
                e.Handled = true;
            }
            else if (!char.IsDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }
        }
        public void ValidarSpecial(object sender, KeyPressEventArgs e)
        {
            var c = e.KeyChar;

            if (!char.IsLetterOrDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }
        }
        private void txtHomePostal_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtHomePostal.Text))
            {
                //e.Cancel = true;
                this.errorProvider1.SetError(this.txtHomePostal, "Este campo es obligatorio.");
            }
            //var regex = @"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$";
            //var re = new Regex(regex);
            //var match = re.Match(this.txtHomePostal.Text);
            //if (!match.Success)
            //{
            //    this.errorProvider1.SetError(this.txtHomePostal, "El codigo postal no es valido.");
            //    e.Cancel = true;
            //}
            //if (this.txtHomePostal.Text.Length != 4)
            //{
            //    this.errorProvider1.SetError(this.txtHomePostal, "El codigo postal no es valido.");o
            //}
        }
        private void txtHomeStreet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtHomeStreet.Text))
            {
                //e.Cancel = true;
                this.errorProvider1.SetError(this.txtHomeStreet, "Este campo es obligatorio.");
            }
        }
        private void txtHomeNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtHomeNumber.Text))
            {
                //e.Cancel = true;
                this.errorProvider1.SetError(this.txtHomeNumber, "Este campo es obligatorio.");
            }
        }
        private void grdCoverages_Validating(object sender, CancelEventArgs e)
        {
            if (this.coverages.Count == 0)
            {
                //e.Cancel = true;
                this.errorProvider1.SetError(this.grdCoverages, "Debe asignar coberturas a la poliza.");
            }
        }
        private void cmbProvince_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbProvince.SelectedIndex < 0)
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.cmbProvince, "Este campo es obligatorio.");
            }
        }
        private void cmbDistrict_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbDistrict.SelectedIndex < 0)
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.cmbDistrict, "Este campo es obligatorio.");
            }
        }
        private void cmbLocality_Validating(object sender, CancelEventArgs e)
        {
            if (this.cmbLocality.SelectedIndex < 0)
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.cmbLocality, "Este campo es obligatorio.");
            }
        }
        #endregion
    }
}
