using Seggu.Dtos;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class GestionarCarrocerias : Form
    {
        private VehicleTypeDto vehicleType;
        private IBodyworkService bodyworkService;

        public GestionarCarrocerias(IBodyworkService bodyworkService)
        {
            InitializeComponent();
            this.bodyworkService = bodyworkService;
        }

        public void Initialize(VehicleTypeDto vehicleType)
        {
            this.vehicleType = vehicleType;
            UseLabel.Text += vehicleType.Name;
            var vehicleTypeBodyworks = this.bodyworkService.GetByVehicleType(vehicleType.Id).ToList();
            this.UsoDeTipoVehiculo.DataSource = vehicleTypeBodyworks;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            var allUses = this.bodyworkService.GetAll().ToList();
            this.UsosExistentes.DataSource = allUses.Except(vehicleTypeBodyworks).OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void PonerButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (BodyworkDto)this.UsosExistentes.SelectedItem;
            var existing = (List<BodyworkDto>)this.UsoDeTipoVehiculo.DataSource;
            existing.Add(selectedItem);
            var all = (List<BodyworkDto>)this.UsosExistentes.DataSource;
            all.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing.OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DataSource = all.OrderBy(x => x.Name).ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void SacarButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (BodyworkDto)this.UsoDeTipoVehiculo.SelectedItem;
            var all = (List<BodyworkDto>)this.UsosExistentes.DataSource;
            all.Add(selectedItem);
            var existing = (List<BodyworkDto>)this.UsoDeTipoVehiculo.DataSource;
            existing.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing.OrderBy(x => x.Name).ToList();
            this.UsosExistentes.DataSource = all.OrderBy(x => x.Name).ToList();
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            var existing = (List<BodyworkDto>)this.UsoDeTipoVehiculo.DataSource;
            this.bodyworkService.SaveChanges(this.vehicleType, existing);
            this.Close();
        }


    }
}
