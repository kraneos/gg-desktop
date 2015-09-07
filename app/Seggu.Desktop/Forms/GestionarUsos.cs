using Seggu.Data;
using Seggu.Dtos;
using Seggu.Services.Interfaces;
//using Seggu.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.UseLabel.Text += vehicleType.Name;
            //this.UsoDeTipoVehiculo.DataSource = vehicleType.Uses.ToList();
            var vehicleTypeUses = this.useService.GetByVehicleType(vehicleType.Id).ToList();
            this.UsoDeTipoVehiculo.DataSource = vehicleTypeUses;
            this.UsoDeTipoVehiculo.DisplayMember = "Name";
            var uses = this.useService.GetAll();
            var allUses = uses;
            this.UsosExistentes.DataSource = allUses.Except(vehicleTypeUses).ToList();
            this.UsosExistentes.DisplayMember = "Name";
        }

        private void PonerButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (UseDto)this.UsosExistentes.SelectedItem;
            var existing = (List<UseDto>)this.UsoDeTipoVehiculo.DataSource;
            existing.Add(selectedItem);
            var all = (List<UseDto>)this.UsosExistentes.DataSource;
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
