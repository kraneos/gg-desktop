using Seggu.Dtos;
using Seggu.Services.Interfaces;
//using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class GestionarUsos : Form
    {
        private VehicleTypeDto vehicleType;
        private IUseService useService;
        public GestionarUsos(IUseService useService)
        {
            InitializeComponent();

            this.useService = useService;
        }

        public void Initialize(VehicleTypeDto vehicleType)
        {
            this.vehicleType = vehicleType;
            UseLabel.Text += vehicleType.Name;
            var vehicleTypeUses = useService.GetByVehicleType(vehicleType.Id).ToList();
            UsoDeTipoVehiculo.DataSource = vehicleTypeUses;
            UsoDeTipoVehiculo.DisplayMember = "Name";
            var allUses = useService.GetAll();
            UsosExistentes.DataSource = allUses.Except(vehicleTypeUses).ToList();
            UsosExistentes.DisplayMember = "Name";
        }

        private void PonerButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (UseDto)UsosExistentes.SelectedItem;
            var existing = (List<UseDto>)UsoDeTipoVehiculo.DataSource;
            existing.Add(selectedItem);
            var all = (List<UseDto>)UsosExistentes.DataSource;
            all.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing;
            this.UsosExistentes.DataSource = all;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void SacarButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (UseDto)this.UsoDeTipoVehiculo.SelectedItem;
            var all = (List<UseDto>)this.UsosExistentes.DataSource;
            all.Add(selectedItem);
            var existing = (List<UseDto>)this.UsoDeTipoVehiculo.DataSource;
            existing.Remove(selectedItem);
            this.UsoDeTipoVehiculo.DataSource = null;
            this.UsosExistentes.DataSource = null;
            this.UsoDeTipoVehiculo.DataSource = existing;
            this.UsosExistentes.DataSource = all;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            var existing = (List<UseDto>)this.UsoDeTipoVehiculo.DataSource;
            this.useService.SaveChanges(this.vehicleType, existing);
            this.Close();
        }     
    }
}
