using Microsoft.Win32;
using Seggu.Desktop.UserControls;
using Seggu.Dtos;
using Seggu.Helpers;
using Seggu.Infrastructure;
using Seggu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Seggu.Desktop.Forms
{
    public partial class Layout : Form
    {
        private IPolicyService _policyService;
        private IClientService _clientService;
        private IFeeService _feeService;
        private ICompanyService _companyService;
        private ILoginService _loginService;
        public EndorseFullDto currentEndorse { get; set; }
        public PolicyFullDto currentPolicy { get; set; }
        public ClientIndexDto currentClient { get; set; }
        private PolizasUserControl policyUc;
        private AseguradosUserControl clientUC;

        public Layout(ICompanyService companyService, IFeeService feeService, IBankService bankService, IPolicyService policyService, IClientService clientService, ILoginService loginService)
        {
            InitializeComponent();
            _policyService = policyService;
            _clientService = clientService;
            _feeService = feeService;
            _companyService = companyService;
            _loginService = loginService;
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            var loginForm = DependencyResolver.Instance.Resolve<LoginForm>();
            var result = loginForm.ShowDialog();
            if (result != DialogResult.OK)
            {
                this.Close();
            }

            _feeService.UpdateFeeStates();
            btnLimpiar_Click(sender, e);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            InitiateContextServices();

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

        public void InitiateContextServices()
        {
            _policyService = DependencyResolver.Instance.Resolve<IPolicyService>();
            _clientService = DependencyResolver.Instance.Resolve<IClientService>();
            _feeService = DependencyResolver.Instance.Resolve<IFeeService>();
            _companyService = DependencyResolver.Instance.Resolve<ICompanyService>();
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
            InitiateContextServices();
            grdEndorses.Visible = false;
            grdPolicies.Visible = false;
            tabCtrlPolicies.Visible = false;
            btnNuevoEndoso.Visible = false;
        }

        private void CollapsePanel1()
        {
            if (!splitContainer1.Panel1Collapsed)
                splitContainer1.Panel1Collapsed = true;
        }

        private void SetPanelControl(UserControl uc)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(uc);
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
                Cobranza Cobranzas = (Cobranza)DependencyResolver
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
            else if (str.Length > 1 && str.Substring(0, 1) == "#")
                SearchByPolicyNumber(str.Substring(1));

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
            grdPolicies.DataSource = _policyService.GetByPolicyNumber(str).ToList();

            FormatPoliciesGrid();
            SetPoliciesSearchResultCtrls();
        }
        private void SearchByVehiclePlate(string str)
        {
            grdPolicies.DataSource = _policyService.GetByPlate(str).ToList();

            FormatPoliciesGrid();
            SetPoliciesSearchResultCtrls();
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
            SetButtonsPrincipal();
            btnPolizas.Enabled = true;
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
                if (currentClient.PolicyCount == 0)//para crear nueva pol
                {
                    policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
                    SetPanelControl(policyUc);
                }
                else
                {
                    LoadPoliciesGrids();
                    tabCtrlPolicies_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                MessageBox.Show("debe cargar un asegurado primero");
                this.btnLimpiar_Click(sender, e);
            }
        }
        private void LoadPoliciesGrids()
        {
            grdExpired.DataSource = _policyService.GetNotValidsByClient(currentClient.Id).ToList();
            FormatExpiredGrid();

            grdValids.DataSource = _policyService.GetValidsByClient(currentClient.Id).ToList();
            FormatValidGrid();

            this.splitContainer1.Panel2.Controls.Clear();

            tabCtrlPolicies.Visible = true;
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Bold);
            btnCobranzas.Enabled = true;

            grdPolicies.Visible = false;
            grdEndorses.Visible = false;
            btnNuevoEndoso.Visible = false;

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

        private void grdValids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails((DataGridView)sender);
        }
        private void grdExpired_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails((DataGridView)sender);
        }
        private void grdPolicies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails((DataGridView)sender);
            SetPoliciesSearchResultCtrls();
            currentClient = _clientService.GetShortDtoById(currentPolicy.ClientId);
            LoadClientSideBar(currentClient);
        }

        private void ShowDetails(DataGridView grid)
        {
            currentEndorse = null;
            var currentItemPolicy = (PolicyGridItemDto)grid.CurrentRow.DataBoundItem;
            this.currentPolicy = this._policyService.GetById(currentItemPolicy.Id);
            policyUc = (PolizasUserControl)DependencyResolver.Instance.Resolve(typeof(PolizasUserControl));
            SetPanelControl(policyUc);
            policyUc.btnRenovar.Enabled = true;
            policyUc.PopulateDetails();

            SetPoliciesVisualContext();
        }
        private void SetPoliciesVisualContext()
        {
            tabCtrlPolicies.Visible = true;
            btnNuevoEndoso.Visible = true;
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Bold);

            if (currentPolicy.IsAnnulled || currentPolicy.IsRemoved || currentPolicy.Vence.ToDateTime() < DateTime.Today)
            {
                btnNuevoEndoso.Visible = false;
                btnCobranzas.Enabled = false;
            }

            if (currentPolicy.Endorses.Any())
                LoadEndorseGrid();
            else
                grdEndorses.Visible = false;

        }
        private void SetPoliciesSearchResultCtrls()
        {
            btnPolizas.Font = new Font(btnPolizas.Font, FontStyle.Bold);

            grdPolicies.Visible = true;
            tabCtrlPolicies.Visible = false;
        }
        private void tabCtrlPolicies_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            grdEndorses.Visible = false;//

            if (tabCtrlPolicies.SelectedIndex == 0)//pestaña de pol vigentes
            {
                if (grdValids.RowCount == 1)
                {
                    grdValids.CurrentCell = grdValids.Rows[0].Cells[0];
                    ShowDetails(grdValids);
                    grdValids.CurrentCell = grdValids.Rows[0].Cells[0];
                }
                else
                    grdValids.ClearSelection();
                      
            }
            else//pestaña de pol vencidas
            {
                if (grdExpired.RowCount == 1)
                {
                    grdExpired.CurrentCell = grdExpired.Rows[0].Cells[0];
                    ShowDetails(grdExpired);
                    grdExpired.CurrentCell = grdExpired.Rows[0].Cells[0];
                }
                else
                    grdExpired.ClearSelection();

                grdEndorses.Visible = false;
                btnNuevoEndoso.Visible = false;
                btnCobranzas.Enabled = false;
            }
        }
        #endregion

        #region Endosos
        private void btnNuevoEndoso_Click(object sender, EventArgs e)
        {
            var uc = (EndososUserControl)DependencyResolver.Instance.Resolve(typeof(EndososUserControl));
            SetPanelControl(uc);
            uc.NewEndorse();
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
        }
        #endregion

        #region Menus

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
            Compañías compañias = (Compañías)DependencyResolver
                 .Instance.Resolve(typeof(Compañías));
            compañias.Show();
        }

        private void productoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productores productores = (Productores)DependencyResolver.Instance.Resolve(typeof(Productores));
            productores.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelosVehiculos modelos = (ModelosVehiculos)DependencyResolver.Instance.Resolve(typeof(ModelosVehiculos));
            modelos.Show();
        }

        private void usosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usos usos = (Usos)DependencyResolver
                .Instance.Resolve(typeof(Usos));
            usos.Show();
        }

        private void carroceríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Carrocerias carrocerias = (Carrocerias)DependencyResolver
                .Instance.Resolve(typeof(Carrocerias));
            carrocerias.Show();
        }

        private void tiposDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TiposVehiculos vehiclestypes = (TiposVehiculos)DependencyResolver
                .Instance.Resolve(typeof(TiposVehiculos));
            vehiclestypes.Show();
        }

        private void BanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bancos bancos = ((Bancos)DependencyResolver.Instance.Resolve(typeof(Bancos)));
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
            ControlCaja controlCaja = (ControlCaja)DependencyResolver.Instance.Resolve(typeof(ControlCaja));
            controlCaja.Show();
        }

        private void agendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agenda agenda = (Agenda)DependencyResolver.Instance.Resolve(typeof(Agenda));
            agenda.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿está seguro de salir?", "Logout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _loginService.Logout();
                this.Close();
            }
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
        #endregion
    }
}
