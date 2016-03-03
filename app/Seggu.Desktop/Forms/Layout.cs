using Microsoft.Win32;
using Seggu.Data;
using Seggu.Desktop.UserControls;
using Seggu.Domain;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Infrastructure;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Layout : Form
    {
        private IPolicyService policyService;
        private IClientService clientService;
        private IFeeService feeService;
        private ICompanyService companyService;
        public EndorseFullDto currentEndorse { get; set; }
        public PolicyFullDto currentPolicy { get; set; }
        public ClientIndexDto currentClient { get; set; }
        private PolizasUserControl policyUc;
        private AseguradosUserControl clientUC;

        public Layout(ICompanyService companyService, IFeeService feeService, IBankService bankService, IPolicyService policyService, IClientService clientService)
        {
            InitializeComponent();
            this.policyService = policyService;
            this.clientService = clientService;
            this.feeService = feeService;
            this.companyService = companyService;

            try
            {
                LaunchSplash();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static bool ValidateRegistry()
        {
            var keyRoot = "HKEY_CURRENT_USER";
            var keyName = keyRoot + "\\SOFTWARE\\Seggu";

            var installationDate = (string)Registry.GetValue(keyName, "d", string.Empty);
            if (!string.IsNullOrEmpty(installationDate))
            {
                var date = DateTime.MinValue;
                if (DateTime.TryParse(installationDate, out date))
                {
                    if (DateTime.Now - date < TimeSpan.FromDays(15))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void LaunchSplash()
        {
            var splashForm = (Splash)DependencyResolver.Instance.Resolve(typeof(Splash));
            splashForm.ShowDialog();
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            //if (!ValidateRegistry())
            //{
            //    MessageBox.Show("El periodo de pruebas ha finalizado. La aplicacion se cerrara.");
            //    this.Close();
            //}
            //var loginForm = (Login)DependencyResolver.Instance.Resolve(typeof(Login));
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
            SetButtonsPrincipal();
            txtBuscar.Focus();
            //    switch ((Role)SegguExecutionContext.Instance.CurrentUser.Role)
            //    {
            //        case Role.Administrador:
            //            ConfigureUserAdministratorVisibility();
            //            break;
            //        case Role.Asesor:
            //            ConfigureConsultantVisibility();
            //            break;
            //        case Role.Cajero:
            //            ConfigureCashierVisibility();
            //            break;
            //        default:
            //            MessageBox.Show("El usuario no posee un rol soportado por el sistema.");
            //            this.Close();
            //            break;
            //    }
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        private void ConfigureCashierVisibility()
        {
            //this.splitContainer1.Visible = false;
            //this.txtBuscar.Visible = false;
            //this.btnLimpiar.Visible = false;
            //this.btnPolizas.Visible = false;
            this.btnNotifications.Visible = false;
            this.archivoToolStripMenuItem.Visible = false;
            this.entidadesToolStripMenuItem.Visible = false;
            this.utilidadesToolStripMenuItem.Visible = false;
            this.reportesToolStripMenuItem.Visible = false;
            this.polizasVigentesToolStripMenuItem.Visible = false;
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem.Visible = false;
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem.Visible = false;
            this.pólizasARenovarToolStripMenuItem.Visible = false;
        }

        private void ConfigureConsultantVisibility()
        {
            //throw new NotImplementedException();
            this.btnCobranzas.Visible = false;
        }

        public void SetButtonsPrincipal()
        {
            btnCobranzas.Enabled = false;
            //btnLiquidaciones.Font = new Font(btnLiquidaciones.Font, FontStyle.Regular);
            btnPolizas.Enabled = false;
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Regular);
            btnPolizas.Text = "Pólizas";
            btnSiniestros.Visible = false;
            grdPolicies.Visible = false;
            tabCtrlPolicies.Visible = false;
            btnEndosos.Visible = false;
            grdEndorses.Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string str = txtBuscar.Text.Trim();
            if (str == "DNI, Apellido, Patente, Póliza") return;
            double num;
            bool isNume = double.TryParse(str, out num);
            //por DNI
            if (str.Length > 3 && isNume)
                SearchByClientDNI(str);
            //por Nro Poliza
            else if (str.Length > 1 && str.Substring(0, 2) == "p-")
                SearchByPolicyNumber(str);
            //por Patente
            else if ((str.Length > 3 && str.Length < 8) && (str[3] == '-') && (str.Substring(0, 3).AreAllLetters() || str.Substring(0, 3).AreAllNumbers()))
                SearchByVehiclePlate(str);
            //por apellido
            else if (str.Length > 3)
                SearchByLastName(str);
            //nada
            else if (str.Length > 4)
                MessageBox.Show("No existen registros");
        }
        private void SearchByClientDNI(string str)
        {
            splitContainer1.Panel2.Controls.Clear();
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            SetButtonsClients();
            clientUC.FindClientByDNI(str);
        }
        private void SearchByPolicyNumber(string str)
        {
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            grdPolicies.DataSource = policyService.GetByPolicyNumber(str.Substring(2)).ToList();
            FormatPoliciesGrid();

            SetPanelControl(policyUc);
            SetButtonsClients();
            SetButtonsPolicies();
            SetButtonsPoliciesPlateSearch();
        }
        private void SearchByVehiclePlate(string str)
        {
            grdPolicies.Visible = true;
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            grdPolicies.DataSource = policyService.GetByPlate(str).ToList();

            FormatPoliciesGrid();
            SetButtonsClients();
            SetButtonsPolicies();
            SetButtonsPoliciesPlateSearch();
            SetPanelControl(policyUc);
        }
        private void SearchByLastName(string str)
        {
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            SetButtonsClients();
            clientUC.FindClientByName(str);
        }
        private void FormatPoliciesGrid()
        {
            foreach (DataGridViewColumn c in grdPolicies.Columns)
                c.Visible = false;
            grdPolicies.Columns["Número"].Visible = true;
            grdPolicies.Columns["Vence"].Visible = true;
        }
        private void SetButtonsPolicies()
        {
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Bold);
            btnCobranzas.Enabled = false;
            tabCtrlPolicies.Visible = true;
            grdPolicies.Visible = false;
            //if (SegguExecutionContext.Instance.CurrentUser.Role == Role.Cajero)
            //{
            btnSiniestros.Visible = true;
            btnSiniestros.Enabled = false;
            btnEndosos.Visible = true;
            btnEndosos.Enabled = false;
            //}
            grdEndorses.Visible = false;
        }
        private void SetButtonsPoliciesPlateSearch()
        {
            grdPolicies.Visible = true;

            tabCtrlPolicies.Visible = false;
        }
        public void SetButtonsClients()
        {
            //SetButtonsPrincipal();
            //btnLiquidaciones.Font = new Font(btnLiquidaciones.Font, FontStyle.Regular);

            btnPolizas.Enabled = true;
            btnPolizas.Text = "Pólizas";
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Regular);
        }

        private void btnPolizas_Click(object sender, EventArgs e)
        {
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            SetPanelControl(policyUc);
            //ClearPanelControl();
            if (currentClient != null)
                LoadPoliciesGrids();
            else
            {
                MessageBox.Show("debe cargar un asegurado primero");
                this.btnLimpiar_Click(sender, e);
            }
            SetButtonsPolicies();
        }
        private void SetPanelControl(UserControl uc)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(uc);
        }
        private void ClearPanelControl()
        {
            this.splitContainer1.Panel2.Controls.Clear();
            //this.splitContainer1.Panel2.Controls.Add(uc);
        }
        private void LoadPoliciesGrids()
        {
            grdValids.DataSource = policyService.GetValidsByClient(currentClient.Id).ToList();
            FormatValidGrid();

            grdExpired.DataSource = policyService.GetNotValidsByClient(currentClient.Id).ToList();
            FormatExpiredGrid();
        }
        private void FormatValidGrid()
        {
            foreach (DataGridViewColumn c in grdValids.Columns)
                c.Visible = false;
            grdValids.Columns["Número"].Visible = true;
            grdValids.Columns["Vence"].Visible = true;
            grdValids.ClearSelection();
        }
        private void FormatExpiredGrid()
        {
            foreach (DataGridViewColumn c in grdExpired.Columns)
                c.Visible = false;
            grdExpired.Columns["Número"].Visible = true;
            grdExpired.Columns["Vence"].Visible = true;
            grdExpired.ClearSelection();
        }

        private void grdPolicies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentPolicy = (PolicyFullDto)grdPolicies.CurrentRow.DataBoundItem;
            currentClient = clientService.GetShortDtoById(currentPolicy.ClientId);
            currentEndorse = null;
            LoadClientSideBar(currentClient);
            //            policyUc = (PolizasUserControl)DependencyContainer.Instance.Resolve(typeof(PolizasUserControl));
            policyUc.btnRenovar.Enabled = true;
            policyUc.PopulateDetails();
            if (currentPolicy.Endorses.Count() > 0)
                LoadEndorseGrid();
            btnEndosos.Enabled = true;
            btnSiniestros.Enabled = true;
            btnSiniestros.Text = "Siniestros (" + currentPolicy.Casualties.Count + ")";
            btnCobranzas.Enabled = true;
            SetPanelControl(policyUc);
        }
        public void LoadClientSideBar(ClientIndexDto cli)
        {
            currentClient = cli;
            LblNombre.Text = cli.Nombre;
            LblApellido.Text = cli.Apellido;
            lblDNI.Text = cli.Dni;
        }

        private void grdExpired_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentPolicy = (PolicyFullDto)grdExpired.CurrentRow.DataBoundItem;
            currentEndorse = null;
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            //SetPanelControl(policyUc);

            SetPanelControl(policyUc);
            policyUc.btnRenovar.Enabled = true;
            policyUc.PopulateDetails();
            if (currentPolicy.Endorses.Count() > 0)
                LoadEndorseGrid();
            btnSiniestros.Text = "Siniestros (" + currentPolicy.Casualties.Count + ")";
        }
        private void LoadEndorseGrid()
        {
            grdEndorses.DataSource = currentPolicy.Endorses.ToList();
            FormatEndorseGrid();
            grdEndorses.Visible = true;
            grdEndorses.ClearSelection();
        }
        private void FormatEndorseGrid()
        {
            foreach (DataGridViewColumn c in grdEndorses.Columns)
                c.Visible = false;
            grdEndorses.Columns["Motivo"].Visible = true;
        }

        public void MostrarCantPolizas(int cant)
        {
            if (cant > 0)
                btnPolizas.Text = "Pólizas (" + cant + ")";
            else
                btnPolizas.Text = "Pólizas";
        }
        public void CleanLeftPanel()
        {
            grdEndorses.Visible = false;
            tabCtrlPolicies.Visible = false;
            btnSiniestros.Visible = false;
            btnEndosos.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LblApellido.Text = "Apellido";
            LblNombre.Text = "Nombre";
            lblDNI.Text = "DNI";
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel1Collapsed = false;
            grdEndorses.DataSource = null;
            SetButtonsPrincipal();
            currentPolicy = null;
            txtBuscar.Text = "DNI, Apellido, Patente, Póliza";
            this.txtBuscar.Focus();
        }

        private void btnSiniestros_Click(object sender, EventArgs e)
        {
            var uc = (SiniestrosUserControl)DependencyResolver.Instance.Resolve(typeof(SiniestrosUserControl)
                , new Dictionary<string, object>() { { "policyId", this.currentPolicy.Id } });
            SetPanelControl(uc);
            SetButtonsCasualtys();
        }
        private void SetButtonsCasualtys()
        {
        }

        //private void btnLiquidaciones_Click(object sender, EventArgs e)
        //{
        //    var uc = (LiquidacionesUserControl)DependencyContainer
        //        .Instance.Resolve(typeof(LiquidacionesUserControl));
        //    CollapsePanel1();
        //    SetPanelControl(uc);
        //    SetButtonsLiquidations();
        //}
        private void liquidacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uc = (LiquidacionesUserControl)DependencyResolver.Instance.Resolve(typeof(LiquidacionesUserControl));
            CollapsePanel1();
            SetPanelControl(uc);
            SetButtonsLiquidations();
        }
        private void CollapsePanel1()
        {
            if (!splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = true;
        }
        private void SetButtonsLiquidations()
        {
            //btnLiquidaciones.Font = new Font(btnLiquidaciones.Font, FontStyle.Bold);

            btnPolizas.Enabled = false;
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Regular);

            btnCobranzas.Enabled = false;
        }

        private void btnCobranzas_Click(object sender, EventArgs e)
        {
            if (currentPolicy != null && currentClient != null && currentPolicy.ClientId != currentClient.Id)
                MessageBox.Show("No se ha seleccionado ninguna poliza", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Forms.Cobranza Cobranzas = (Cobranza)DependencyResolver
                    .Instance.Resolve(typeof(Cobranza)
                    , new Dictionary<string, object>() { { "policyId", this.currentPolicy.Id } });
                Cobranzas.Show();
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            var uc = (CuotasVencidasUserControl)DependencyResolver.Instance.Resolve(typeof(CuotasVencidasUserControl));
            SetPanelControl(uc);
        }

        #region menuStrip
        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Agenda agenda = (Agenda)DependencyResolver.Instance.Resolve(typeof(Agenda));
            agenda.Show();
        }

        private void BanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Bancos bancos = ((Bancos)DependencyResolver.Instance.Resolve(typeof(Bancos)));
            bancos.Show();
        }

        private void compañíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Compañías compañias = (Compañías)DependencyResolver
                 .Instance.Resolve(typeof(Compañías));
            compañias.Show();
        }

        private void controlDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ControlCaja controlCaja = (ControlCaja)DependencyResolver.Instance.Resolve(typeof(ControlCaja));
            controlCaja.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ModelosVehiculos modelos = (ModelosVehiculos)DependencyResolver.Instance.Resolve(typeof(ModelosVehiculos));
            modelos.Show();
        }

        private void productoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Productores productores = (Productores)DependencyResolver.Instance.Resolve(typeof(Productores));
            productores.Show();
        }

        private void pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    this.NavigateTo(Modules.Polizas, 0, "ver todas");
        }

        private void menu_archivo_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.InitializeIndex();
            SetButtonsPrincipal();
            SetButtonsClients();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.NewClient();
            SetButtonsClients();
        }
        #endregion

        private void grdEndorses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentEndorse = (EndorseFullDto)grdEndorses.CurrentRow.DataBoundItem;
            var uc = (EndososUserControl)DependencyResolver.Instance.Resolve(typeof(EndososUserControl));
            SetPanelControl(uc);
            uc.PopulateDetails();
            grdValids.ClearSelection();
            grdExpired.ClearSelection();
            grdPolicies.ClearSelection();
        }

        private void LblNombre_Click(object sender, EventArgs e)
        {
            if (LblNombre.Text == "Nombre") return;
            SetPanelControl(clientUC);
            clientUC.FindClientByName(LblApellido.Text + " " + LblNombre.Text);
            SetButtonsClients();
        }


        private void btnEndosos_Click(object sender, EventArgs e)
        {
            var uc = (EndososUserControl)DependencyResolver.Instance.Resolve(typeof(EndososUserControl));
            //, new Dictionary<string, object>() { { "policyId", this.currentPolicy.Id } });
            SetPanelControl(uc);
            uc.NewEndorse();
            SetButtonsEndorses();
        }
        private void SetButtonsEndorses()
        {

        }

        private void tabCtrlPolicies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCtrlPolicies.SelectedIndex == 0)
            {
                //btnEndosos.Enabled = true;
                grdEndorses.Visible = false;
                btnSiniestros.Enabled = true;
                btnCobranzas.Enabled = true;
            }
            else
            {
                btnEndosos.Enabled = false;
                btnSiniestros.Enabled = false;
                btnCobranzas.Enabled = false;
            }
        }

        private void pólizasVigentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.ListClientsWithValidsPolicies();
            SetButtonsPrincipal();
            SetButtonsClients();
        }

        private void byKr4neosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://seggu.com.ar");
        }

        private void rORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyResolver.Instance.ResolveGeneric<RcrReportForm>().Show();

        }

        private void rCRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new RosReportForm(DependencyResolver.Instance.ResolveGeneric<IProducerService>(), DependencyResolver.Instance.ResolveGeneric<ICashAccountService>()).Show();
        }

        private void riesgosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.RisksOnly risksOnly = (RisksOnly)DependencyResolver
                .Instance.Resolve(typeof(RisksOnly));
            risksOnly.Show();
        }

        private void coberturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.CoberturasOnly coberturasOnly = (CoberturasOnly)DependencyResolver
               .Instance.Resolve(typeof(CoberturasOnly));
            coberturasOnly.Show();
        }

        private void usosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Usos usos = (Usos)DependencyResolver
                .Instance.Resolve(typeof(Usos));
            usos.Show();
        }

        private void carroceríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Carrocerias carrocerias = (Carrocerias)DependencyResolver
                .Instance.Resolve(typeof(Carrocerias));
            carrocerias.Show();
        }

        private void coberturasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Forms.CoberturasOnly coberturas = (CoberturasOnly)DependencyResolver
                .Instance.Resolve(typeof(CoberturasOnly));
            coberturas.Show();
        }

        private void tiposDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.TiposVehiculos vehiclestypes = (TiposVehiculos)DependencyResolver
                .Instance.Resolve(typeof(TiposVehiculos));
            vehiclestypes.Show();
        }

        private void paquetesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Forms.PackagesOnly paquetes = (PackagesOnly)DependencyResolver
                .Instance.Resolve(typeof(PackagesOnly));
            paquetes.Show();
        }

        private void cobranzasARealizarEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyResolver.Instance.ResolveGeneric<CobranzasRealizadas>().Show();
        }

        private void pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DependencyResolver.Instance.ResolveGeneric<PolizasPorFecha>().Show();
        }

        private void cobranzasVencidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clientUC = (CuotasVencidasUserControl)DependencyContainer.Instance.Resolve(typeof(AseguradosUserControl));
            /*SetPanelControl(clientUC);
            clientUC.ListClientsWithValidsPolicies();
            SetButtonsPrincipal();
            SetButtonsClients();
            new FormCobranzasVencidas().Show();*/
        }

        private void lblPolizas_Click(object sender, EventArgs e)
        {

        }

        private void grdValids_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentPolicy = (PolicyFullDto)grdValids.CurrentRow.DataBoundItem;
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            SetPanelControl(policyUc);
            currentEndorse = null;
            //SetPanelControl(policyUc);
            policyUc.btnRenovar.Enabled = true;
            policyUc.PopulateDetails();
            if (currentPolicy.Endorses.Count() > 0)
                LoadEndorseGrid();
            btnEndosos.Enabled = true;
            btnSiniestros.Text = "Siniestros (" + currentPolicy.Casualties.Count + ")";
            btnSiniestros.Enabled = true;
            btnCobranzas.Enabled = true;
        }

    }
}
