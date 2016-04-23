namespace Seggu.Desktop.UserControls
{
    partial class PolizasUserControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tctrlPolizasDatos = new System.Windows.Forms.TabControl();
            this.tabPageDatos = new System.Windows.Forms.TabPage();
            this.chkOtherClient = new System.Windows.Forms.CheckBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.txtAsegurado = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNroPoliza = new System.Windows.Forms.TextBox();
            this.txtNroPolAnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpRecibido = new System.Windows.Forms.DateTimePicker();
            this.dtpEmision = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.dtpSolicitud = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.cmbRiesgo = new System.Windows.Forms.ComboBox();
            this.cmbCompania = new System.Windows.Forms.ComboBox();
            this.cmbProductor = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.tabPagePlanes = new System.Windows.Forms.TabPage();
            this.txtNetoPagar = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBonificacionPago = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCobrador = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtRecargoPropio = new System.Windows.Forms.TextBox();
            this.txtNetoCobrar = new System.Windows.Forms.TextBox();
            this.txtBonificacionPropia = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPremioIva = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrima = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSumaAsegurado = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCobrar = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbPlanes = new System.Windows.Forms.ComboBox();
            this.grdFees = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbDistintos = new System.Windows.Forms.RadioButton();
            this.rdbIguales = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPaymentDay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPlanAsegurado = new System.Windows.Forms.Label();
            this.lblPlanCia = new System.Windows.Forms.Label();
            this.cmbPlanAsegurado = new System.Windows.Forms.ComboBox();
            this.cmbPlanCia = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PanelCoverage = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAnulada = new System.Windows.Forms.Label();
            this.btnNuevaPoliza = new System.Windows.Forms.Button();
            this.btnRenovar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tctrlPolizasDatos.SuspendLayout();
            this.tabPageDatos.SuspendLayout();
            this.tabPagePlanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFees)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tctrlPolizasDatos
            // 
            this.tctrlPolizasDatos.Controls.Add(this.tabPageDatos);
            this.tctrlPolizasDatos.Controls.Add(this.tabPagePlanes);
            this.tctrlPolizasDatos.Enabled = false;
            this.tctrlPolizasDatos.Location = new System.Drawing.Point(5, 24);
            this.tctrlPolizasDatos.Name = "tctrlPolizasDatos";
            this.tctrlPolizasDatos.SelectedIndex = 0;
            this.tctrlPolizasDatos.Size = new System.Drawing.Size(995, 419);
            this.tctrlPolizasDatos.TabIndex = 0;
            // 
            // tabPageDatos
            // 
            this.tabPageDatos.Controls.Add(this.chkOtherClient);
            this.tabPageDatos.Controls.Add(this.cmbClient);
            this.tabPageDatos.Controls.Add(this.lblID);
            this.tabPageDatos.Controls.Add(this.label19);
            this.tabPageDatos.Controls.Add(this.txtNotas);
            this.tabPageDatos.Controls.Add(this.txtAsegurado);
            this.tabPageDatos.Controls.Add(this.label23);
            this.tabPageDatos.Controls.Add(this.txtNroPoliza);
            this.tabPageDatos.Controls.Add(this.txtNroPolAnt);
            this.tabPageDatos.Controls.Add(this.label1);
            this.tabPageDatos.Controls.Add(this.dtpRecibido);
            this.tabPageDatos.Controls.Add(this.dtpEmision);
            this.tabPageDatos.Controls.Add(this.dtpFin);
            this.tabPageDatos.Controls.Add(this.label48);
            this.tabPageDatos.Controls.Add(this.label49);
            this.tabPageDatos.Controls.Add(this.dtpSolicitud);
            this.tabPageDatos.Controls.Add(this.dtpInicio);
            this.tabPageDatos.Controls.Add(this.cmbPeriodo);
            this.tabPageDatos.Controls.Add(this.label44);
            this.tabPageDatos.Controls.Add(this.label45);
            this.tabPageDatos.Controls.Add(this.label47);
            this.tabPageDatos.Controls.Add(this.cmbRiesgo);
            this.tabPageDatos.Controls.Add(this.cmbCompania);
            this.tabPageDatos.Controls.Add(this.cmbProductor);
            this.tabPageDatos.Controls.Add(this.label43);
            this.tabPageDatos.Controls.Add(this.label52);
            this.tabPageDatos.Controls.Add(this.label55);
            this.tabPageDatos.Controls.Add(this.label57);
            this.tabPageDatos.Controls.Add(this.label60);
            this.tabPageDatos.Location = new System.Drawing.Point(4, 26);
            this.tabPageDatos.Name = "tabPageDatos";
            this.tabPageDatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatos.Size = new System.Drawing.Size(987, 389);
            this.tabPageDatos.TabIndex = 0;
            this.tabPageDatos.Text = "Datos Generales";
            this.tabPageDatos.UseVisualStyleBackColor = true;
            // 
            // chkOtherClient
            // 
            this.chkOtherClient.AutoSize = true;
            this.chkOtherClient.Location = new System.Drawing.Point(861, 19);
            this.chkOtherClient.Name = "chkOtherClient";
            this.chkOtherClient.Size = new System.Drawing.Size(97, 21);
            this.chkOtherClient.TabIndex = 104;
            this.chkOtherClient.Text = "Otro Cliente";
            this.chkOtherClient.UseVisualStyleBackColor = true;
            this.chkOtherClient.CheckedChanged += new System.EventHandler(this.chkOtherClient_CheckedChanged);
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(580, 14);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(266, 25);
            this.cmbClient.TabIndex = 103;
            this.cmbClient.Visible = false;
            this.cmbClient.SelectionChangeCommitted += new System.EventHandler(this.cmbClient_SelectionChangeCommitted);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(15, 120);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 100;
            this.lblID.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 254);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 17);
            this.label19.TabIndex = 99;
            this.label19.Text = "Notas";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(117, 252);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(5);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(758, 127);
            this.txtNotas.TabIndex = 98;
            // 
            // txtAsegurado
            // 
            this.txtAsegurado.Location = new System.Drawing.Point(580, 14);
            this.txtAsegurado.Name = "txtAsegurado";
            this.txtAsegurado.ReadOnly = true;
            this.txtAsegurado.Size = new System.Drawing.Size(266, 25);
            this.txtAsegurado.TabIndex = 96;
            this.txtAsegurado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAsegurado_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(462, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 17);
            this.label23.TabIndex = 97;
            this.label23.Text = "Asegurado";
            // 
            // txtNroPoliza
            // 
            this.txtNroPoliza.Location = new System.Drawing.Point(120, 50);
            this.txtNroPoliza.Name = "txtNroPoliza";
            this.txtNroPoliza.Size = new System.Drawing.Size(244, 25);
            this.txtNroPoliza.TabIndex = 8;
            // 
            // txtNroPolAnt
            // 
            this.txtNroPolAnt.Location = new System.Drawing.Point(580, 51);
            this.txtNroPolAnt.Name = "txtNroPolAnt";
            this.txtNroPolAnt.ReadOnly = true;
            this.txtNroPolAnt.Size = new System.Drawing.Size(266, 25);
            this.txtNroPolAnt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 80;
            this.label1.Text = "Recibida el";
            // 
            // dtpRecibido
            // 
            this.dtpRecibido.Checked = false;
            this.dtpRecibido.Location = new System.Drawing.Point(580, 216);
            this.dtpRecibido.Name = "dtpRecibido";
            this.dtpRecibido.ShowCheckBox = true;
            this.dtpRecibido.Size = new System.Drawing.Size(266, 25);
            this.dtpRecibido.TabIndex = 7;
            // 
            // dtpEmision
            // 
            this.dtpEmision.Checked = false;
            this.dtpEmision.Location = new System.Drawing.Point(580, 179);
            this.dtpEmision.Name = "dtpEmision";
            this.dtpEmision.ShowCheckBox = true;
            this.dtpEmision.Size = new System.Drawing.Size(266, 25);
            this.dtpEmision.TabIndex = 18;
            // 
            // dtpFin
            // 
            this.dtpFin.Checked = false;
            this.dtpFin.Location = new System.Drawing.Point(120, 219);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(244, 25);
            this.dtpFin.TabIndex = 6;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(462, 184);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(65, 17);
            this.label48.TabIndex = 75;
            this.label48.Text = "Emitida el";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 224);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(77, 17);
            this.label49.TabIndex = 22;
            this.label49.Text = "Fin Vigencia";
            // 
            // dtpSolicitud
            // 
            this.dtpSolicitud.Checked = false;
            this.dtpSolicitud.Location = new System.Drawing.Point(580, 142);
            this.dtpSolicitud.Name = "dtpSolicitud";
            this.dtpSolicitud.Size = new System.Drawing.Size(266, 25);
            this.dtpSolicitud.TabIndex = 17;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Checked = false;
            this.dtpInicio.Location = new System.Drawing.Point(120, 143);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(244, 25);
            this.dtpInicio.TabIndex = 4;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(120, 181);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(244, 25);
            this.cmbPeriodo.TabIndex = 5;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            this.cmbPeriodo.SelectionChangeCommitted += new System.EventHandler(this.cmbPeriodo_SelectionChangeCommitted);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(462, 146);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(93, 17);
            this.label44.TabIndex = 67;
            this.label44.Text = "Solicitud a Cía.";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 146);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(91, 17);
            this.label45.TabIndex = 20;
            this.label45.Text = "Inicio Vigencia";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 185);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(54, 17);
            this.label47.TabIndex = 21;
            this.label47.Text = "Periodo";
            // 
            // cmbRiesgo
            // 
            this.cmbRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRiesgo.FormattingEnabled = true;
            this.cmbRiesgo.Location = new System.Drawing.Point(120, 88);
            this.cmbRiesgo.Name = "cmbRiesgo";
            this.cmbRiesgo.Size = new System.Drawing.Size(244, 25);
            this.cmbRiesgo.TabIndex = 3;
            this.cmbRiesgo.SelectedIndexChanged += new System.EventHandler(this.cmbRiesgo_SelectedIndexChanged);
            this.cmbRiesgo.SelectionChangeCommitted += new System.EventHandler(this.cmbRiesgo_SelectionChangeCommitted);
            // 
            // cmbCompania
            // 
            this.cmbCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompania.FormattingEnabled = true;
            this.cmbCompania.Location = new System.Drawing.Point(120, 12);
            this.cmbCompania.Name = "cmbCompania";
            this.cmbCompania.Size = new System.Drawing.Size(244, 25);
            this.cmbCompania.TabIndex = 1;
            this.cmbCompania.SelectionChangeCommitted += new System.EventHandler(this.cmbCompania_SelectionChangeCommitted);
            // 
            // cmbProductor
            // 
            this.cmbProductor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductor.FormattingEnabled = true;
            this.cmbProductor.Location = new System.Drawing.Point(580, 88);
            this.cmbProductor.Name = "cmbProductor";
            this.cmbProductor.Size = new System.Drawing.Size(266, 25);
            this.cmbProductor.TabIndex = 14;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 51);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(62, 17);
            this.label43.TabIndex = 49;
            this.label43.Text = "Nº Póliza";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(462, 91);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(66, 17);
            this.label52.TabIndex = 45;
            this.label52.Text = "Productor";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 90);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(48, 17);
            this.label55.TabIndex = 42;
            this.label55.Text = "Riesgo";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(462, 53);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(97, 17);
            this.label57.TabIndex = 40;
            this.label57.Text = "Nº Pól Anterior";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(6, 12);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(67, 17);
            this.label60.TabIndex = 27;
            this.label60.Text = "Compañia";
            // 
            // tabPagePlanes
            // 
            this.tabPagePlanes.Controls.Add(this.txtNetoPagar);
            this.tabPagePlanes.Controls.Add(this.textBox1);
            this.tabPagePlanes.Controls.Add(this.txtBonificacionPago);
            this.tabPagePlanes.Controls.Add(this.label11);
            this.tabPagePlanes.Controls.Add(this.label15);
            this.tabPagePlanes.Controls.Add(this.btnDarDeBaja);
            this.tabPagePlanes.Controls.Add(this.label14);
            this.tabPagePlanes.Controls.Add(this.txtTotalPagar);
            this.tabPagePlanes.Controls.Add(this.btnGrabar);
            this.tabPagePlanes.Controls.Add(this.label5);
            this.tabPagePlanes.Controls.Add(this.cmbCobrador);
            this.tabPagePlanes.Controls.Add(this.label51);
            this.tabPagePlanes.Controls.Add(this.txtRecargoPropio);
            this.tabPagePlanes.Controls.Add(this.txtNetoCobrar);
            this.tabPagePlanes.Controls.Add(this.txtBonificacionPropia);
            this.tabPagePlanes.Controls.Add(this.txtIva);
            this.tabPagePlanes.Controls.Add(this.label7);
            this.tabPagePlanes.Controls.Add(this.txtPremioIva);
            this.tabPagePlanes.Controls.Add(this.label6);
            this.tabPagePlanes.Controls.Add(this.txtPrima);
            this.tabPagePlanes.Controls.Add(this.label8);
            this.tabPagePlanes.Controls.Add(this.txtSumaAsegurado);
            this.tabPagePlanes.Controls.Add(this.label13);
            this.tabPagePlanes.Controls.Add(this.label4);
            this.tabPagePlanes.Controls.Add(this.label3);
            this.tabPagePlanes.Controls.Add(this.label2);
            this.tabPagePlanes.Controls.Add(this.txtTotalCobrar);
            this.tabPagePlanes.Controls.Add(this.label20);
            this.tabPagePlanes.Controls.Add(this.cmbPlanes);
            this.tabPagePlanes.Controls.Add(this.grdFees);
            this.tabPagePlanes.Controls.Add(this.groupBox4);
            this.tabPagePlanes.Controls.Add(this.groupBox1);
            this.tabPagePlanes.Controls.Add(this.lblPlanAsegurado);
            this.tabPagePlanes.Controls.Add(this.lblPlanCia);
            this.tabPagePlanes.Controls.Add(this.cmbPlanAsegurado);
            this.tabPagePlanes.Controls.Add(this.cmbPlanCia);
            this.tabPagePlanes.Location = new System.Drawing.Point(4, 26);
            this.tabPagePlanes.Name = "tabPagePlanes";
            this.tabPagePlanes.Size = new System.Drawing.Size(987, 389);
            this.tabPagePlanes.TabIndex = 3;
            this.tabPagePlanes.Text = "Sumas y Planes de Cobranza";
            this.tabPagePlanes.UseVisualStyleBackColor = true;
            // 
            // txtNetoPagar
            // 
            this.txtNetoPagar.Enabled = false;
            this.txtNetoPagar.Location = new System.Drawing.Point(686, 110);
            this.txtNetoPagar.Name = "txtNetoPagar";
            this.txtNetoPagar.ReadOnly = true;
            this.txtNetoPagar.Size = new System.Drawing.Size(77, 25);
            this.txtNetoPagar.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(415, 355);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(54, 25);
            this.textBox1.TabIndex = 55;
            // 
            // txtBonificacionPago
            // 
            this.txtBonificacionPago.Location = new System.Drawing.Point(686, 76);
            this.txtBonificacionPago.Name = "txtBonificacionPago";
            this.txtBonificacionPago.Size = new System.Drawing.Size(77, 25);
            this.txtBonificacionPago.TabIndex = 1;
            this.txtBonificacionPago.TextChanged += new System.EventHandler(this.txtBonificacionPago_TextChanged);
            this.txtBonificacionPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonificacionPago_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(335, 358);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "Total Saldo";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(553, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Neto a Pagar";
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.Enabled = false;
            this.btnDarDeBaja.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarDeBaja.Location = new System.Drawing.Point(788, 353);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(87, 27);
            this.btnDarDeBaja.TabIndex = 102;
            this.btnDarDeBaja.Text = "Dar de Baja";
            this.btnDarDeBaja.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(553, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Bonificación P/ Pago";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Location = new System.Drawing.Point(666, 355);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.ReadOnly = true;
            this.txtTotalPagar.Size = new System.Drawing.Size(54, 25);
            this.txtTotalPagar.TabIndex = 50;
            // 
            // btnGrabar
            // 
            this.btnGrabar.AutoSize = true;
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ForeColor = System.Drawing.Color.Red;
            this.btnGrabar.Location = new System.Drawing.Point(893, 353);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 27);
            this.btnGrabar.TabIndex = 21;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(590, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 49;
            this.label5.Text = "Total a Cía";
            // 
            // cmbCobrador
            // 
            this.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCobrador.FormattingEnabled = true;
            this.cmbCobrador.Location = new System.Drawing.Point(338, 9);
            this.cmbCobrador.Name = "cmbCobrador";
            this.cmbCobrador.Size = new System.Drawing.Size(171, 25);
            this.cmbCobrador.TabIndex = 47;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(259, 12);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 17);
            this.label51.TabIndex = 48;
            this.label51.Text = "Cobrador";
            // 
            // txtRecargoPropio
            // 
            this.txtRecargoPropio.Location = new System.Drawing.Point(399, 76);
            this.txtRecargoPropio.Name = "txtRecargoPropio";
            this.txtRecargoPropio.Size = new System.Drawing.Size(110, 25);
            this.txtRecargoPropio.TabIndex = 5;
            this.txtRecargoPropio.TextChanged += new System.EventHandler(this.txtRecargoPropio_TextChanged);
            this.txtRecargoPropio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecargoPropio_KeyPress);
            // 
            // txtNetoCobrar
            // 
            this.txtNetoCobrar.Enabled = false;
            this.txtNetoCobrar.Location = new System.Drawing.Point(399, 109);
            this.txtNetoCobrar.Name = "txtNetoCobrar";
            this.txtNetoCobrar.ReadOnly = true;
            this.txtNetoCobrar.Size = new System.Drawing.Size(110, 25);
            this.txtNetoCobrar.TabIndex = 6;
            this.txtNetoCobrar.Validating += new System.ComponentModel.CancelEventHandler(this.txtNetoCobrar_Validating);
            // 
            // txtBonificacionPropia
            // 
            this.txtBonificacionPropia.Location = new System.Drawing.Point(399, 43);
            this.txtBonificacionPropia.Name = "txtBonificacionPropia";
            this.txtBonificacionPropia.Size = new System.Drawing.Size(110, 25);
            this.txtBonificacionPropia.TabIndex = 4;
            this.txtBonificacionPropia.TextChanged += new System.EventHandler(this.txtBonificacionPropia_TextChanged);
            this.txtBonificacionPropia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonificacionPropia_KeyPress);
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.Control;
            this.txtIva.Enabled = false;
            this.txtIva.Location = new System.Drawing.Point(115, 76);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(115, 25);
            this.txtIva.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Recargo propio";
            // 
            // txtPremioIva
            // 
            this.txtPremioIva.Location = new System.Drawing.Point(115, 109);
            this.txtPremioIva.Name = "txtPremioIva";
            this.txtPremioIva.Size = new System.Drawing.Size(115, 25);
            this.txtPremioIva.TabIndex = 3;
            this.txtPremioIva.TextChanged += new System.EventHandler(this.txtPremioIva_TextChanged);
            this.txtPremioIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPremioIva_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bonif. propia";
            // 
            // txtPrima
            // 
            this.txtPrima.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrima.Enabled = false;
            this.txtPrima.Location = new System.Drawing.Point(115, 43);
            this.txtPrima.Name = "txtPrima";
            this.txtPrima.Size = new System.Drawing.Size(115, 25);
            this.txtPrima.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(259, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Neto a Cobrar";
            // 
            // txtSumaAsegurado
            // 
            this.txtSumaAsegurado.Location = new System.Drawing.Point(115, 10);
            this.txtSumaAsegurado.Name = "txtSumaAsegurado";
            this.txtSumaAsegurado.Size = new System.Drawing.Size(115, 25);
            this.txtSumaAsegurado.TabIndex = 0;
            this.txtSumaAsegurado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSumaAsegurado_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "IVA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Premio con IVA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Prima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Suma asegurada";
            // 
            // txtTotalCobrar
            // 
            this.txtTotalCobrar.Enabled = false;
            this.txtTotalCobrar.Location = new System.Drawing.Point(275, 355);
            this.txtTotalCobrar.Name = "txtTotalCobrar";
            this.txtTotalCobrar.ReadOnly = true;
            this.txtTotalCobrar.Size = new System.Drawing.Size(54, 25);
            this.txtTotalCobrar.TabIndex = 11;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(177, 358);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 17);
            this.label20.TabIndex = 7;
            this.label20.Text = "Total a Cobrar";
            // 
            // cmbPlanes
            // 
            this.cmbPlanes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanes.FormattingEnabled = true;
            this.cmbPlanes.Items.AddRange(new object[] {
            "1 cuota",
            "2 cuotas",
            "3 cuotas",
            "4 cuotas",
            "5 cuotas",
            "6 cuotas",
            "7 cuotas",
            "8 cuotas",
            "9 cuotas",
            "10 cuotas",
            "11 cuotas",
            "12 cuotas"});
            this.cmbPlanes.Location = new System.Drawing.Point(798, 110);
            this.cmbPlanes.Name = "cmbPlanes";
            this.cmbPlanes.Size = new System.Drawing.Size(145, 25);
            this.cmbPlanes.TabIndex = 0;
            this.cmbPlanes.SelectedIndexChanged += new System.EventHandler(this.cmbPlanes_SelectedIndexChanged);
            // 
            // grdFees
            // 
            this.grdFees.AllowDrop = true;
            this.grdFees.AllowUserToAddRows = false;
            this.grdFees.AllowUserToDeleteRows = false;
            this.grdFees.AllowUserToOrderColumns = true;
            this.grdFees.AllowUserToResizeColumns = false;
            this.grdFees.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            this.grdFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdFees.Location = new System.Drawing.Point(6, 151);
            this.grdFees.Name = "grdFees";
            this.grdFees.RowHeadersVisible = false;
            this.grdFees.RowHeadersWidth = 13;
            this.grdFees.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdFees.Size = new System.Drawing.Size(978, 196);
            this.grdFees.TabIndex = 3;
            this.grdFees.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbDistintos);
            this.groupBox4.Controls.Add(this.rdbIguales);
            this.groupBox4.Location = new System.Drawing.Point(612, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 50);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Plan Cía / Aseg";
            this.groupBox4.Visible = false;
            // 
            // rdbDistintos
            // 
            this.rdbDistintos.AutoSize = true;
            this.rdbDistintos.Location = new System.Drawing.Point(71, 24);
            this.rdbDistintos.Name = "rdbDistintos";
            this.rdbDistintos.Size = new System.Drawing.Size(76, 21);
            this.rdbDistintos.TabIndex = 1;
            this.rdbDistintos.Text = "Distintos";
            this.rdbDistintos.UseVisualStyleBackColor = true;
            this.rdbDistintos.CheckedChanged += new System.EventHandler(this.rdbDistintos_CheckedChanged);
            // 
            // rdbIguales
            // 
            this.rdbIguales.AutoSize = true;
            this.rdbIguales.Checked = true;
            this.rdbIguales.Location = new System.Drawing.Point(6, 24);
            this.rdbIguales.Name = "rdbIguales";
            this.rdbIguales.Size = new System.Drawing.Size(67, 21);
            this.rdbIguales.TabIndex = 0;
            this.rdbIguales.TabStop = true;
            this.rdbIguales.Text = "Iguales";
            this.rdbIguales.UseVisualStyleBackColor = true;
            this.rdbIguales.CheckedChanged += new System.EventHandler(this.rdbIguales_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPaymentDay);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(810, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 56);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "cobro al cliente";
            // 
            // txtPaymentDay
            // 
            this.txtPaymentDay.Location = new System.Drawing.Point(56, 20);
            this.txtPaymentDay.MaxLength = 2;
            this.txtPaymentDay.Name = "txtPaymentDay";
            this.txtPaymentDay.Size = new System.Drawing.Size(31, 25);
            this.txtPaymentDay.TabIndex = 53;
            this.txtPaymentDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaymentDay_KeyPress);
            this.txtPaymentDay.Validating += new System.ComponentModel.CancelEventHandler(this.txtPaymentDay_Validating);
            this.txtPaymentDay.Validated += new System.EventHandler(this.txtPaymentDay_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "Día: ";
            // 
            // lblPlanAsegurado
            // 
            this.lblPlanAsegurado.AutoSize = true;
            this.lblPlanAsegurado.Location = new System.Drawing.Point(858, 3);
            this.lblPlanAsegurado.Name = "lblPlanAsegurado";
            this.lblPlanAsegurado.Size = new System.Drawing.Size(100, 17);
            this.lblPlanAsegurado.TabIndex = 15;
            this.lblPlanAsegurado.Text = "Plan Asegurado";
            this.lblPlanAsegurado.Visible = false;
            // 
            // lblPlanCia
            // 
            this.lblPlanCia.AutoSize = true;
            this.lblPlanCia.Location = new System.Drawing.Point(795, 3);
            this.lblPlanCia.Name = "lblPlanCia";
            this.lblPlanCia.Size = new System.Drawing.Size(57, 17);
            this.lblPlanCia.TabIndex = 13;
            this.lblPlanCia.Text = "Plan Cía.";
            this.lblPlanCia.Visible = false;
            // 
            // cmbPlanAsegurado
            // 
            this.cmbPlanAsegurado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanAsegurado.FormattingEnabled = true;
            this.cmbPlanAsegurado.Items.AddRange(new object[] {
            "1 cuota",
            "2 cuotas",
            "3 cuotas",
            "4 cuotas",
            "5 cuotas",
            "6 cuotas",
            "7 cuotas",
            "8 cuotas",
            "9 cuotas",
            "10 cuotas",
            "11 cuotas",
            "12 cuotas"});
            this.cmbPlanAsegurado.Location = new System.Drawing.Point(889, 26);
            this.cmbPlanAsegurado.Name = "cmbPlanAsegurado";
            this.cmbPlanAsegurado.Size = new System.Drawing.Size(54, 25);
            this.cmbPlanAsegurado.TabIndex = 16;
            this.cmbPlanAsegurado.Visible = false;
            // 
            // cmbPlanCia
            // 
            this.cmbPlanCia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanCia.FormattingEnabled = true;
            this.cmbPlanCia.Items.AddRange(new object[] {
            "1 cuota",
            "2 cuotas",
            "3 cuotas",
            "4 cuotas",
            "5 cuotas",
            "6 cuotas",
            "7 cuotas",
            "8 cuotas",
            "9 cuotas",
            "10 cuotas",
            "11 cuotas",
            "12 cuotas"});
            this.cmbPlanCia.Location = new System.Drawing.Point(798, 26);
            this.cmbPlanCia.Name = "cmbPlanCia";
            this.cmbPlanCia.Size = new System.Drawing.Size(54, 25);
            this.cmbPlanCia.TabIndex = 14;
            this.cmbPlanCia.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // PanelCoverage
            // 
            this.PanelCoverage.AutoSize = true;
            this.PanelCoverage.Location = new System.Drawing.Point(3, 446);
            this.PanelCoverage.Name = "PanelCoverage";
            this.PanelCoverage.Size = new System.Drawing.Size(250, 225);
            this.PanelCoverage.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 25);
            this.label10.TabIndex = 101;
            this.label10.Text = "Póliza";
            // 
            // lblAnulada
            // 
            this.lblAnulada.AutoSize = true;
            this.lblAnulada.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnulada.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblAnulada.Location = new System.Drawing.Point(70, 4);
            this.lblAnulada.Name = "lblAnulada";
            this.lblAnulada.Size = new System.Drawing.Size(59, 17);
            this.lblAnulada.TabIndex = 53;
            this.lblAnulada.Text = "Anulada";
            this.lblAnulada.Visible = false;
            // 
            // btnNuevaPoliza
            // 
            this.btnNuevaPoliza.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaPoliza.Location = new System.Drawing.Point(139, 0);
            this.btnNuevaPoliza.Name = "btnNuevaPoliza";
            this.btnNuevaPoliza.Size = new System.Drawing.Size(75, 24);
            this.btnNuevaPoliza.TabIndex = 104;
            this.btnNuevaPoliza.Text = "Nueva";
            this.btnNuevaPoliza.UseVisualStyleBackColor = true;
            this.btnNuevaPoliza.Click += new System.EventHandler(this.btnNuevaPoliza_Click);
            // 
            // btnRenovar
            // 
            this.btnRenovar.Enabled = false;
            this.btnRenovar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenovar.Location = new System.Drawing.Point(220, 0);
            this.btnRenovar.Name = "btnRenovar";
            this.btnRenovar.Size = new System.Drawing.Size(75, 24);
            this.btnRenovar.TabIndex = 103;
            this.btnRenovar.Text = "Renovar";
            this.btnRenovar.UseVisualStyleBackColor = true;
            this.btnRenovar.Click += new System.EventHandler(this.btnRenovar_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(301, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 24);
            this.btnPrint.TabIndex = 105;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PolizasUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNuevaPoliza);
            this.Controls.Add(this.btnRenovar);
            this.Controls.Add(this.lblAnulada);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PanelCoverage);
            this.Controls.Add(this.tctrlPolizasDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PolizasUserControl";
            this.Size = new System.Drawing.Size(1000, 675);
            this.tctrlPolizasDatos.ResumeLayout(false);
            this.tabPageDatos.ResumeLayout(false);
            this.tabPageDatos.PerformLayout();
            this.tabPagePlanes.ResumeLayout(false);
            this.tabPagePlanes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFees)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TabControl tctrlPolizasDatos;
        private System.Windows.Forms.TabPage tabPageDatos;
        private System.Windows.Forms.TextBox txtNroPoliza;
        private System.Windows.Forms.TextBox txtNroPolAnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpRecibido;
        private System.Windows.Forms.DateTimePicker dtpEmision;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.DateTimePicker dtpSolicitud;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ComboBox cmbRiesgo;
        private System.Windows.Forms.ComboBox cmbCompania;
        private System.Windows.Forms.ComboBox cmbProductor;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TabPage tabPagePlanes;
        private System.Windows.Forms.TextBox txtTotalCobrar;
        private System.Windows.Forms.ComboBox cmbPlanAsegurado;
        private System.Windows.Forms.Label lblPlanAsegurado;
        private System.Windows.Forms.ComboBox cmbPlanCia;
        private System.Windows.Forms.Label lblPlanCia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbPlanes;
        private System.Windows.Forms.DataGridView grdFees;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbDistintos;
        private System.Windows.Forms.RadioButton rdbIguales;
        private System.Windows.Forms.TextBox txtAsegurado;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.TextBox txtRecargoPropio;
        private System.Windows.Forms.TextBox txtNetoCobrar;
        private System.Windows.Forms.TextBox txtBonificacionPropia;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPremioIva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrima;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetoPagar;
        private System.Windows.Forms.TextBox txtBonificacionPago;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCobrador;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel PanelCoverage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAnulada;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Button btnNuevaPoliza;
        internal System.Windows.Forms.Button btnRenovar;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.TextBox txtPaymentDay;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkOtherClient;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtSumaAsegurado;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
