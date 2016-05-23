namespace Seggu.Desktop.Forms
{
    partial class Layout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Layout));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCobranzas = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNotifications = new System.Windows.Forms.Button();
            this.btnPolizas = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnNuevoEndoso = new System.Windows.Forms.Button();
            this.grdPolicies = new System.Windows.Forms.DataGridView();
            this.grdEndorses = new System.Windows.Forms.DataGridView();
            this.LblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.tabCtrlPolicies = new System.Windows.Forms.TabControl();
            this.tabValids = new System.Windows.Forms.TabPage();
            this.grdValids = new System.Windows.Forms.DataGridView();
            this.tabExpired = new System.Windows.Forms.TabPage();
            this.grdExpired = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainMenuBar = new System.Windows.Forms.MenuStrip();
            this.entidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aseguradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compañíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carroceríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobranzasARealizarEntreFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobranzasVencidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polizasVigentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pólizasARenovarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_archivo_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.byKr4neosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPolicies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEndorses)).BeginInit();
            this.tabCtrlPolicies.SuspendLayout();
            this.tabValids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdValids)).BeginInit();
            this.tabExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mainMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCobranzas
            // 
            this.btnCobranzas.AutoSize = true;
            this.btnCobranzas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCobranzas.BackColor = System.Drawing.SystemColors.Control;
            this.btnCobranzas.Enabled = false;
            this.btnCobranzas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCobranzas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCobranzas.Location = new System.Drawing.Point(405, 23);
            this.btnCobranzas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCobranzas.Name = "btnCobranzas";
            this.btnCobranzas.Size = new System.Drawing.Size(87, 28);
            this.btnCobranzas.TabIndex = 42;
            this.btnCobranzas.Text = "Cobranzas";
            this.btnCobranzas.UseVisualStyleBackColor = false;
            this.btnCobranzas.Click += new System.EventHandler(this.btnCobranzas_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSize = true;
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.BackColor = System.Drawing.Color.Olive;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.Location = new System.Drawing.Point(192, 22);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(66, 31);
            this.btnLimpiar.TabIndex = 43;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Location = new System.Drawing.Point(3, 25);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(178, 25);
            this.txtBuscar.TabIndex = 36;
            this.txtBuscar.Text = "DNI, Apellido, Patente, Póliza";
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnNotifications
            // 
            this.btnNotifications.AutoSize = true;
            this.btnNotifications.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNotifications.BackColor = System.Drawing.SystemColors.Control;
            this.btnNotifications.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNotifications.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNotifications.Location = new System.Drawing.Point(512, 23);
            this.btnNotifications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNotifications.Name = "btnNotifications";
            this.btnNotifications.Size = new System.Drawing.Size(65, 28);
            this.btnNotifications.TabIndex = 45;
            this.btnNotifications.Text = "Alertas";
            this.btnNotifications.UseVisualStyleBackColor = false;
            this.btnNotifications.Click += new System.EventHandler(this.btnNotifications_Click);
            // 
            // btnPolizas
            // 
            this.btnPolizas.AutoSize = true;
            this.btnPolizas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPolizas.BackColor = System.Drawing.SystemColors.Control;
            this.btnPolizas.Enabled = false;
            this.btnPolizas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPolizas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPolizas.Location = new System.Drawing.Point(299, 23);
            this.btnPolizas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPolizas.Name = "btnPolizas";
            this.btnPolizas.Size = new System.Drawing.Size(64, 28);
            this.btnPolizas.TabIndex = 41;
            this.btnPolizas.Text = "Pólizas";
            this.btnPolizas.UseVisualStyleBackColor = false;
            this.btnPolizas.Click += new System.EventHandler(this.btnPolizas_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 53);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnNuevoEndoso);
            this.splitContainer1.Panel1.Controls.Add(this.grdPolicies);
            this.splitContainer1.Panel1.Controls.Add(this.grdEndorses);
            this.splitContainer1.Panel1.Controls.Add(this.LblApellido);
            this.splitContainer1.Panel1.Controls.Add(this.lblDNI);
            this.splitContainer1.Panel1.Controls.Add(this.LblNombre);
            this.splitContainer1.Panel1.Controls.Add(this.tabCtrlPolicies);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 675);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 37;
            // 
            // btnNevoEndoso
            // 
            this.btnNuevoEndoso.AutoSize = true;
            this.btnNuevoEndoso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuevoEndoso.BackColor = System.Drawing.SystemColors.Control;
            this.btnNuevoEndoso.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNuevoEndoso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNuevoEndoso.Location = new System.Drawing.Point(7, 436);
            this.btnNuevoEndoso.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.btnNuevoEndoso.Name = "btnNevoEndoso";
            this.btnNuevoEndoso.Size = new System.Drawing.Size(112, 28);
            this.btnNuevoEndoso.TabIndex = 41;
            this.btnNuevoEndoso.Text = "Nuevo Endoso";
            this.btnNuevoEndoso.UseVisualStyleBackColor = false;
            this.btnNuevoEndoso.Click += new System.EventHandler(this.btnNuevoEndoso_Click);
            // 
            // grdPolicies
            // 
            this.grdPolicies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPolicies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPolicies.Location = new System.Drawing.Point(9, 163);
            this.grdPolicies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdPolicies.MultiSelect = false;
            this.grdPolicies.Name = "grdPolicies";
            this.grdPolicies.ReadOnly = true;
            this.grdPolicies.RowHeadersVisible = false;
            this.grdPolicies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPolicies.Size = new System.Drawing.Size(238, 259);
            this.grdPolicies.TabIndex = 39;
            this.grdPolicies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPolicies_CellClick);
            // 
            // grdEndorses
            // 
            this.grdEndorses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdEndorses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEndorses.Location = new System.Drawing.Point(7, 464);
            this.grdEndorses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdEndorses.MultiSelect = false;
            this.grdEndorses.Name = "grdEndorses";
            this.grdEndorses.ReadOnly = true;
            this.grdEndorses.RowHeadersVisible = false;
            this.grdEndorses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdEndorses.Size = new System.Drawing.Size(248, 164);
            this.grdEndorses.TabIndex = 37;
            this.grdEndorses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEndorses_CellContentClick);
            // 
            // LblApellido
            // 
            this.LblApellido.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LblApellido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblApellido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblApellido.Location = new System.Drawing.Point(5, 50);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.Padding = new System.Windows.Forms.Padding(0, 0, 117, 0);
            this.LblApellido.Size = new System.Drawing.Size(250, 37);
            this.LblApellido.TabIndex = 33;
            this.LblApellido.Text = "Apellido";
            this.LblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDNI
            // 
            this.lblDNI.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDNI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblDNI.Location = new System.Drawing.Point(5, 92);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Padding = new System.Windows.Forms.Padding(0, 0, 117, 0);
            this.lblDNI.Size = new System.Drawing.Size(250, 37);
            this.lblDNI.TabIndex = 2;
            this.lblDNI.Text = "DNI";
            this.lblDNI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblNombre
            // 
            this.LblNombre.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.LblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblNombre.Location = new System.Drawing.Point(5, 6);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Padding = new System.Windows.Forms.Padding(0, 0, 117, 0);
            this.LblNombre.Size = new System.Drawing.Size(250, 37);
            this.LblNombre.TabIndex = 0;
            this.LblNombre.Text = "Nombre";
            this.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblNombre.TextChanged += new System.EventHandler(this.LblNombre_TextChanged);
            this.LblNombre.Click += new System.EventHandler(this.LblNombre_Click);
            this.LblNombre.MouseLeave += new System.EventHandler(this.LblNombre_MouseLeave);
            this.LblNombre.MouseHover += new System.EventHandler(this.LblNombre_MouseHover);
            // 
            // tabCtrlPolicies
            // 
            this.tabCtrlPolicies.Controls.Add(this.tabValids);
            this.tabCtrlPolicies.Controls.Add(this.tabExpired);
            this.tabCtrlPolicies.Location = new System.Drawing.Point(3, 137);
            this.tabCtrlPolicies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCtrlPolicies.Name = "tabCtrlPolicies";
            this.tabCtrlPolicies.SelectedIndex = 0;
            this.tabCtrlPolicies.Size = new System.Drawing.Size(255, 297);
            this.tabCtrlPolicies.TabIndex = 36;
            this.tabCtrlPolicies.SelectedIndexChanged += new System.EventHandler(this.tabCtrlPolicies_SelectedIndexChanged);
            // 
            // tabValids
            // 
            this.tabValids.Controls.Add(this.grdValids);
            this.tabValids.Location = new System.Drawing.Point(4, 26);
            this.tabValids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabValids.Name = "tabValids";
            this.tabValids.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabValids.Size = new System.Drawing.Size(247, 267);
            this.tabValids.TabIndex = 0;
            this.tabValids.Text = "Vigentes";
            this.tabValids.UseVisualStyleBackColor = true;
            // 
            // grdValids
            // 
            this.grdValids.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdValids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdValids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdValids.Location = new System.Drawing.Point(3, 2);
            this.grdValids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdValids.MultiSelect = false;
            this.grdValids.Name = "grdValids";
            this.grdValids.ReadOnly = true;
            this.grdValids.RowHeadersVisible = false;
            this.grdValids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdValids.Size = new System.Drawing.Size(241, 263);
            this.grdValids.TabIndex = 0;
            this.grdValids.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdValids_CellClick);
            // 
            // tabExpired
            // 
            this.tabExpired.Controls.Add(this.grdExpired);
            this.tabExpired.Location = new System.Drawing.Point(4, 22);
            this.tabExpired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabExpired.Name = "tabExpired";
            this.tabExpired.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabExpired.Size = new System.Drawing.Size(247, 271);
            this.tabExpired.TabIndex = 1;
            this.tabExpired.Text = "Vencidas/anuladas";
            this.tabExpired.UseVisualStyleBackColor = true;
            // 
            // grdExpired
            // 
            this.grdExpired.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExpired.Location = new System.Drawing.Point(3, 2);
            this.grdExpired.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdExpired.MultiSelect = false;
            this.grdExpired.Name = "grdExpired";
            this.grdExpired.ReadOnly = true;
            this.grdExpired.RowHeadersVisible = false;
            this.grdExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdExpired.Size = new System.Drawing.Size(241, 267);
            this.grdExpired.TabIndex = 1;
            this.grdExpired.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdExpired_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Seggu.Desktop.Properties.Resources.SeGGu_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(426, 261);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entidadesToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.utilidadesToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.archivoToolStripMenuItem});
            this.mainMenuBar.Location = new System.Drawing.Point(0, 0);
            this.mainMenuBar.Name = "mainMenuBar";
            this.mainMenuBar.Size = new System.Drawing.Size(1268, 24);
            this.mainMenuBar.TabIndex = 46;
            this.mainMenuBar.Text = "menuStrip1";
            // 
            // entidadesToolStripMenuItem
            // 
            this.entidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aseguradosToolStripMenuItem,
            this.compañíasToolStripMenuItem,
            this.productoresToolStripMenuItem,
            this.modelosToolStripMenuItem,
            this.usosToolStripMenuItem,
            this.carroceríasToolStripMenuItem,
            this.tiposDeVehiculosToolStripMenuItem,
            this.bancosToolStripMenuItem});
            this.entidadesToolStripMenuItem.Name = "entidadesToolStripMenuItem";
            this.entidadesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.entidadesToolStripMenuItem.Text = "Entidades";
            // 
            // aseguradosToolStripMenuItem
            // 
            this.aseguradosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosToolStripMenuItem,
            this.nuevoToolStripMenuItem});
            this.aseguradosToolStripMenuItem.Name = "aseguradosToolStripMenuItem";
            this.aseguradosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aseguradosToolStripMenuItem.Text = "Asegurados";
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.todosToolStripMenuItem.Text = "Todos";
            this.todosToolStripMenuItem.Click += new System.EventHandler(this.todosToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // compañíasToolStripMenuItem
            // 
            this.compañíasToolStripMenuItem.Name = "compañíasToolStripMenuItem";
            this.compañíasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.compañíasToolStripMenuItem.Text = "Compañías";
            this.compañíasToolStripMenuItem.Click += new System.EventHandler(this.compañíasToolStripMenuItem_Click);
            // 
            // productoresToolStripMenuItem
            // 
            this.productoresToolStripMenuItem.Name = "productoresToolStripMenuItem";
            this.productoresToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.productoresToolStripMenuItem.Text = "Productores";
            this.productoresToolStripMenuItem.Click += new System.EventHandler(this.productoresToolStripMenuItem_Click);
            // 
            // modelosToolStripMenuItem
            // 
            this.modelosToolStripMenuItem.Name = "modelosToolStripMenuItem";
            this.modelosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.modelosToolStripMenuItem.Text = "Marcas y Modelos";
            this.modelosToolStripMenuItem.Click += new System.EventHandler(this.modelosToolStripMenuItem_Click);
            // 
            // usosToolStripMenuItem
            // 
            this.usosToolStripMenuItem.Name = "usosToolStripMenuItem";
            this.usosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.usosToolStripMenuItem.Text = "Usos";
            this.usosToolStripMenuItem.Click += new System.EventHandler(this.usosToolStripMenuItem_Click);
            // 
            // carroceríasToolStripMenuItem
            // 
            this.carroceríasToolStripMenuItem.Name = "carroceríasToolStripMenuItem";
            this.carroceríasToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.carroceríasToolStripMenuItem.Text = "Carrocerías";
            this.carroceríasToolStripMenuItem.Click += new System.EventHandler(this.carroceríasToolStripMenuItem_Click);
            // 
            // tiposDeVehiculosToolStripMenuItem
            // 
            this.tiposDeVehiculosToolStripMenuItem.Name = "tiposDeVehiculosToolStripMenuItem";
            this.tiposDeVehiculosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.tiposDeVehiculosToolStripMenuItem.Text = "Tipos de Vehiculos";
            this.tiposDeVehiculosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeVehiculosToolStripMenuItem_Click);
            // 
            // bancosToolStripMenuItem
            // 
            this.bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            this.bancosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.bancosToolStripMenuItem.Text = "Bancos";
            this.bancosToolStripMenuItem.Click += new System.EventHandler(this.BanksToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cobranzasARealizarEntreFechasToolStripMenuItem,
            this.cobranzasVencidasToolStripMenuItem,
            this.polizasVigentesToolStripMenuItem,
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem,
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem,
            this.pólizasARenovarToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // cobranzasARealizarEntreFechasToolStripMenuItem
            // 
            this.cobranzasARealizarEntreFechasToolStripMenuItem.Name = "cobranzasARealizarEntreFechasToolStripMenuItem";
            this.cobranzasARealizarEntreFechasToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.cobranzasARealizarEntreFechasToolStripMenuItem.Text = "Cobranzas  Realizadas entre fechas";
            this.cobranzasARealizarEntreFechasToolStripMenuItem.Click += new System.EventHandler(this.cobranzasARealizarEntreFechasToolStripMenuItem_Click);
            // 
            // cobranzasVencidasToolStripMenuItem
            // 
            this.cobranzasVencidasToolStripMenuItem.Name = "cobranzasVencidasToolStripMenuItem";
            this.cobranzasVencidasToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.cobranzasVencidasToolStripMenuItem.Text = "Cobranzas Vencidas";
            this.cobranzasVencidasToolStripMenuItem.Visible = false;
            this.cobranzasVencidasToolStripMenuItem.Click += new System.EventHandler(this.cobranzasVencidasToolStripMenuItem_Click);
            // 
            // polizasVigentesToolStripMenuItem
            // 
            this.polizasVigentesToolStripMenuItem.Name = "polizasVigentesToolStripMenuItem";
            this.polizasVigentesToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.polizasVigentesToolStripMenuItem.Text = "Pólizas Vigentes";
            this.polizasVigentesToolStripMenuItem.Click += new System.EventHandler(this.pólizasVigentesToolStripMenuItem_Click);
            // 
            // pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem
            // 
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem.Name = "pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem";
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem.Text = "Pólizas  entre fechas, por inicio de vigencia";
            this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem.Click += new System.EventHandler(this.pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem_Click_1);
            // 
            // pólizasSinCobranzasNiLiquidacionesToolStripMenuItem
            // 
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem.Name = "pólizasSinCobranzasNiLiquidacionesToolStripMenuItem";
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem.Text = "Pólizas sin Cobranzas ni Liquidaciones";
            this.pólizasSinCobranzasNiLiquidacionesToolStripMenuItem.Visible = false;
            // 
            // pólizasARenovarToolStripMenuItem
            // 
            this.pólizasARenovarToolStripMenuItem.Name = "pólizasARenovarToolStripMenuItem";
            this.pólizasARenovarToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.pólizasARenovarToolStripMenuItem.Text = "Pólizas a Renovar";
            this.pólizasARenovarToolStripMenuItem.Visible = false;
            // 
            // utilidadesToolStripMenuItem
            // 
            this.utilidadesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liquidacionesToolStripMenuItem,
            this.controlDeCajaToolStripMenuItem,
            this.agendaToolStripMenuItem});
            this.utilidadesToolStripMenuItem.Name = "utilidadesToolStripMenuItem";
            this.utilidadesToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.utilidadesToolStripMenuItem.Text = "Utilidades";
            // 
            // liquidacionesToolStripMenuItem
            // 
            this.liquidacionesToolStripMenuItem.Name = "liquidacionesToolStripMenuItem";
            this.liquidacionesToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.liquidacionesToolStripMenuItem.Text = "Liquidaciones";
            this.liquidacionesToolStripMenuItem.Click += new System.EventHandler(this.liquidacionesToolStripMenuItem_Click);
            // 
            // controlDeCajaToolStripMenuItem
            // 
            this.controlDeCajaToolStripMenuItem.Name = "controlDeCajaToolStripMenuItem";
            this.controlDeCajaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.controlDeCajaToolStripMenuItem.Text = "Control de caja";
            this.controlDeCajaToolStripMenuItem.Click += new System.EventHandler(this.controlDeCajaToolStripMenuItem_Click);
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.agendaToolStripMenuItem.Text = "Agenda";
            this.agendaToolStripMenuItem.Click += new System.EventHandler(this.agendaToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rORToolStripMenuItem,
            this.rCRToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // rORToolStripMenuItem
            // 
            this.rORToolStripMenuItem.Name = "rORToolStripMenuItem";
            this.rORToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.rORToolStripMenuItem.Text = "ROS";
            this.rORToolStripMenuItem.Click += new System.EventHandler(this.rORToolStripMenuItem_Click);
            // 
            // rCRToolStripMenuItem
            // 
            this.rCRToolStripMenuItem.Name = "rCRToolStripMenuItem";
            this.rCRToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.rCRToolStripMenuItem.Text = "RCR";
            this.rCRToolStripMenuItem.Click += new System.EventHandler(this.rCRToolStripMenuItem_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_archivo_salir,
            this.byKr4neosToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.archivoToolStripMenuItem.Text = "Acerca de...";
            // 
            // menu_archivo_salir
            // 
            this.menu_archivo_salir.Name = "menu_archivo_salir";
            this.menu_archivo_salir.Size = new System.Drawing.Size(132, 22);
            this.menu_archivo_salir.Text = "Salir";
            this.menu_archivo_salir.Click += new System.EventHandler(this.menu_archivo_salir_Click);
            // 
            // byKr4neosToolStripMenuItem
            // 
            this.byKr4neosToolStripMenuItem.Name = "byKr4neosToolStripMenuItem";
            this.byKr4neosToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.byKr4neosToolStripMenuItem.Text = "by Kr4neos";
            this.byKr4neosToolStripMenuItem.Click += new System.EventHandler(this.byKr4neosToolStripMenuItem_Click);
            // 
            // Layout
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1268, 729);
            this.Controls.Add(this.mainMenuBar);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCobranzas);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnNotifications);
            this.Controls.Add(this.btnPolizas);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeGGu Principal";
            this.Load += new System.EventHandler(this.Layout_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPolicies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEndorses)).EndInit();
            this.tabCtrlPolicies.ResumeLayout(false);
            this.tabValids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdValids)).EndInit();
            this.tabExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExpired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mainMenuBar.ResumeLayout(false);
            this.mainMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCobranzas;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnPolizas;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdEndorses;
        private System.Windows.Forms.TabControl tabCtrlPolicies;
        private System.Windows.Forms.TabPage tabValids;
        private System.Windows.Forms.DataGridView grdValids;
        private System.Windows.Forms.TabPage tabExpired;
        private System.Windows.Forms.DataGridView grdExpired;
        public System.Windows.Forms.Label LblApellido;
        public System.Windows.Forms.Label lblDNI;
        public System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.MenuStrip mainMenuBar;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_archivo_salir;
        private System.Windows.Forms.ToolStripMenuItem entidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aseguradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compañíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobranzasARealizarEntreFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobranzasVencidasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polizasVigentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pólizasYSolicitudesEntreFechasPorInicioDeVigenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pólizasSinCobranzasNiLiquidacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pólizasARenovarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilidadesToolStripMenuItem;
        private System.Windows.Forms.DataGridView grdPolicies;
        private System.Windows.Forms.Button btnNuevoEndoso;
        private System.Windows.Forms.ToolStripMenuItem liquidacionesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rCRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carroceríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeVehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byKr4neosToolStripMenuItem;
    }
}