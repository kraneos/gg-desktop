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

        #region Security
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
            this.btnCobranzas.Visible = false;
        }
        #endregion

        private void LaunchSplash()
        {
            var splashForm = (Splash)DependencyResolver.Instance.Resolve(typeof(Splash));
            splashForm.ShowDialog();
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
            //if (!ValidateRegistry())
            //{
            //    MessageBox.Show("El periodo de pruebas ha finalizado. La aplicacion se cerrara.");
            //    this.Close();
            //}
            //var loginForm = (Login)DependencyResolver.Instance.Resolve(typeof(Login));
            //if (loginForm.ShowDialog() == DialogResult.OK)
            //{
            //SetButtonsPrincipal();
            //txtBuscar.Focus();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LblApellido.Text = "Apellido";
            LblNombre.Text = "Nombre";
            lblDNI.Text = "DNI";
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel1Collapsed = false;
            grdEndorses.DataSource = null;
            SetButtonsPrincipal();
            currentClient = null;
            currentEndorse = null;
            currentPolicy = null;
            txtBuscar.Text = "DNI, Apellido, Patente, Póliza";
            this.txtBuscar.Focus();
        }

        public void SetButtonsPrincipal()
        {
            btnCobranzas.Enabled = false;
            btnPolizas.Enabled = false;
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Regular);
            btnPolizas.Text = "Pólizas";
            CleanLeftPanel();
        }

        public void CleanLeftPanel()
        {
            grdEndorses.Visible = false;
            grdPolicies.Visible = false;
            tabCtrlPolicies.Visible = false;
            btnEndosos.Visible = false;
        }

        private void SetPanelControl(UserControl uc)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(uc);
        }

        private void CollapsePanel1()
        {
            if (!splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = true;
        }

        private void SetButtonsLiquidations()
        {
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

        #region Search
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
            clientUC.FindClientByDNI(str);
        }
        private void SearchByLastName(string str)
        {
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            //SetButtonsClients();
            clientUC.FindClientByName(str);
        }
        private void SearchByPolicyNumber(string str)
        {
            grdPolicies.DataSource = policyService.GetByPolicyNumber(str.Substring(2)).ToList();

            FormatPoliciesGrid();
            SetButtonsPolicies();
            SetButtonsPoliciesSearch();
        }
        private void SearchByVehiclePlate(string str)
        {
            grdPolicies.DataSource = policyService.GetByPlate(str).ToList();

            FormatPoliciesGrid();
            SetButtonsPolicies();
            SetButtonsPoliciesSearch();
        }
        #endregion

        #region Clientes
        public void LoadClientSideBar(ClientIndexDto cli)
        {
            currentClient = cli;
            LblNombre.Text = cli.Nombre;
            LblApellido.Text = cli.Apellido;
            lblDNI.Text = cli.Dni;
        }
        private void LblNombre_TextChanged(object sender, EventArgs e)
        {
            SetButtonsClients();
        }
        private void LblNombre_Click(object sender, EventArgs e)
        {
            if (LblNombre.Text == "Nombre") return;
            SetPanelControl(clientUC);
            clientUC.FindClientByName(LblApellido.Text + " " + LblNombre.Text);
            SetButtonsClients();
        }
        public void SetButtonsClients()
        {
            //SetButtonsPrincipal();
            //btnLiquidaciones.Font = new Font(btnLiquidaciones.Font, FontStyle.Regular);

            btnPolizas.Enabled = true;
            btnPolizas.Text = "Pólizas";
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Regular);
        }
        private void LblNombre_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void LblNombre_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Polizas
        public void MostrarCantPolizas(int cant)
        {
            if (cant > 0)
                btnPolizas.Text = "Pólizas (" + cant + ")";
            else
                btnPolizas.Text = "Pólizas";
        }
        private void btnPolizas_Click(object sender, EventArgs e)
        {
            if (currentClient != null)
            {
                LoadPoliciesGrids();
                SetButtonsPolicies();
            }
            else
            {
                MessageBox.Show("debe cargar un asegurado primero");
                this.btnLimpiar_Click(sender, e);
            }
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
            grdValids.Columns["Name"].Visible = true;
            grdValids.Columns["Name"].HeaderText = "Nro Poliza";
            grdValids.Columns["EndDate"].Visible = true;
            grdValids.Columns["EndDate"].HeaderText = "Vence";
            grdValids.ClearSelection();
        }
        private void FormatExpiredGrid()
        {
            foreach (DataGridViewColumn c in grdExpired.Columns)
                c.Visible = false;
            grdExpired.Columns["Name"].Visible = true;
            grdExpired.Columns["Name"].HeaderText = "Nro Poliza";
            grdExpired.Columns["EndDate"].Visible = true;
            grdExpired.Columns["EndDate"].HeaderText = "Vence";
            grdExpired.ClearSelection();
        }
        private void FormatPoliciesGrid()
        {
            foreach (DataGridViewColumn c in grdPolicies.Columns)
                c.Visible = false;
            grdPolicies.Columns["Name"].Visible = true;
            grdPolicies.Columns["Name"].HeaderText = "Nro Poliza";
            grdPolicies.Columns["EndDate"].Visible = true;
            grdPolicies.Columns["EndDate"].HeaderText = "Vence";
            grdPolicies.ClearSelection();
        }
        private void grdValids_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ShowDetails((DataGridView)sender);

            btnEndosos.Enabled = true;
            btnCobranzas.Enabled = true;
        }
        private void grdExpired_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails((DataGridView)sender);
        }
        private void grdPolicies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails((DataGridView)sender);

            btnEndosos.Enabled = true;
            btnCobranzas.Enabled = true;

            currentClient = clientService.GetShortDtoById(currentPolicy.ClientId);
            LoadClientSideBar(currentClient);
            SetPanelControl(policyUc);
        }

        private void ShowDetails(DataGridView grid)
        {
            currentEndorse = null;
            var currentItemPolicy = (PolicyGridItemDto)grid.CurrentRow.DataBoundItem;
            this.currentPolicy = this.policyService.GetById(currentItemPolicy.Id);
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            SetPanelControl(policyUc);
            policyUc.btnRenovar.Enabled = true;
            policyUc.PopulateDetails();
            if (currentPolicy.Endorses.Count() > 0)
                LoadEndorseGrid();
        }
        private void SetButtonsPolicies()
        {
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Bold);
            btnCobranzas.Enabled = false;
            tabCtrlPolicies.Visible = true;
            grdPolicies.Visible = false;
            //if (SegguExecutionContext.Instance.CurrentUser.Role == Role.Cajero)
            //{
            btnEndosos.Visible = true;
            btnEndosos.Enabled = false;
            //}
            grdEndorses.Visible = false;
        }
        private void SetButtonsPoliciesSearch()
        {
            grdPolicies.Visible = true;
            tabCtrlPolicies.Visible = false;
        }
        private void tabCtrlPolicies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCtrlPolicies.SelectedIndex == 0)
            {
                grdEndorses.Visible = false;
                btnCobranzas.Enabled = true;
            }
            else
            {
                btnEndosos.Enabled = false;
                btnCobranzas.Enabled = false;
            }
        }
        #endregion

        #region Endosos
        private void btnEndosos_Click(object sender, EventArgs e)
        {
            var uc = (EndososUserControl)DependencyResolver.Instance.Resolve(typeof(EndososUserControl));
            SetPanelControl(uc);
            uc.NewEndorse();
            SetButtonsEndorses();
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
        private void SetButtonsEndorses()
        {

        }
        #endregion

        #region Menus

        private void menu_archivo_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.InitializeIndex();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.NewClient();
            //SetButtonsClients();
        }

        private void compañíasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Compañías compañias = (Compañías)DependencyResolver
                 .Instance.Resolve(typeof(Compañías));
            compañias.Show();
        }

        private void productoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Productores productores = (Productores)DependencyResolver.Instance.Resolve(typeof(Productores));
            productores.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ModelosVehiculos modelos = (ModelosVehiculos)DependencyResolver.Instance.Resolve(typeof(ModelosVehiculos));
            modelos.Show();
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

        private void tiposDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.TiposVehiculos vehiclestypes = (TiposVehiculos)DependencyResolver
                .Instance.Resolve(typeof(TiposVehiculos));
            vehiclestypes.Show();
        }

        private void BanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Bancos bancos = ((Bancos)DependencyResolver.Instance.Resolve(typeof(Bancos)));
            bancos.Show();
        }


        private void cobranzasARealizarEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DependencyResolver.Instance.ResolveGeneric<CobranzasRealizadas>().Show();
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

        private void pólizasVigentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(sender, e);
            clientUC = (AseguradosUserControl)DependencyResolver.Instance.Resolve(typeof(AseguradosUserControl));
            SetPanelControl(clientUC);
            clientUC.ListClientsWithValidsPolicies();
            //SetButtonsPrincipal();
            //SetButtonsClients();
        }

        private void pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DependencyResolver.Instance.ResolveGeneric<PolizasPorFecha>().Show();
        }


        private void liquidacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uc = (LiquidacionesUserControl)DependencyResolver.Instance.Resolve(typeof(LiquidacionesUserControl));
            CollapsePanel1();
            SetPanelControl(uc);
            SetButtonsLiquidations();
        }

        private void controlDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ControlCaja controlCaja = (ControlCaja)DependencyResolver.Instance.Resolve(typeof(ControlCaja));
            controlCaja.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Agenda agenda = (Agenda)DependencyResolver.Instance.Resolve(typeof(Agenda));
            agenda.Show();
        }


        private void byKr4neosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://seggu.com.ar");
        }

        #endregion

        #region Ines
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

        private void paquetesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Forms.PackagesOnly paquetes = (PackagesOnly)DependencyResolver
                .Instance.Resolve(typeof(PackagesOnly));
            paquetes.Show();
        }
        #endregion
    }
}
