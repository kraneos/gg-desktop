namespace Seggu.Desktop.Forms
{
    partial class Compañías
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compañías));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregarCobertura = new System.Windows.Forms.Button();
            this.btnAgregarRiesgos = new System.Windows.Forms.Button();
            this.lsbCoberturas = new System.Windows.Forms.ListBox();
            this.lsbRiesgos = new System.Windows.Forms.ListBox();
            this.grbRiesgos = new System.Windows.Forms.GroupBox();
            this.btnDeleteFromPack = new System.Windows.Forms.Button();
            this.btnInsertInPack = new System.Windows.Forms.Button();
            this.grdCoveragesPack = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCoveragesPack = new System.Windows.Forms.TextBox();
            this.btnQuitarPaquete = new System.Windows.Forms.Button();
            this.btnAgregarPaquete = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCoberturas = new System.Windows.Forms.TextBox();
            this.txtRiesgo = new System.Windows.Forms.TextBox();
            this.btnQuitarCobertura = new System.Windows.Forms.Button();
            this.btnQuitarRiesgo = new System.Windows.Forms.Button();
            this.grdProductores = new System.Windows.Forms.DataGridView();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.cmbProductores = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpLiquida = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtConvenio2 = new System.Windows.Forms.TextBox();
            this.txtConvenio1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLiq1 = new System.Windows.Forms.TextBox();
            this.txtLiq2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.grpbDatos = new System.Windows.Forms.GroupBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.grpbContactos = new System.Windows.Forms.GroupBox();
            this.grdContactos = new System.Windows.Forms.DataGridView();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevoProductor = new System.Windows.Forms.Button();
            this.grpbOperatoria = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnQuitarProductor = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregarCompañia = new System.Windows.Forms.Button();
            this.btnQuitarCompañia = new System.Windows.Forms.Button();
            this.lblNuevaCompañia = new System.Windows.Forms.Label();
            this.cmbTipoRiesgos = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmbCompañias = new System.Windows.Forms.ComboBox();
            this.grbRiesgos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoveragesPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductores)).BeginInit();
            this.grpLiquida.SuspendLayout();
            this.grpbDatos.SuspendLayout();
            this.grpbContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactos)).BeginInit();
            this.grpbOperatoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(275, 14);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(66, 27);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarCobertura
            // 
            this.btnAgregarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCobertura.Location = new System.Drawing.Point(362, 49);
            this.btnAgregarCobertura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarCobertura.Name = "btnAgregarCobertura";
            this.btnAgregarCobertura.Size = new System.Drawing.Size(65, 27);
            this.btnAgregarCobertura.TabIndex = 3;
            this.btnAgregarCobertura.Text = "Agregar";
            this.btnAgregarCobertura.UseVisualStyleBackColor = true;
            this.btnAgregarCobertura.Visible = false;
            this.btnAgregarCobertura.Click += new System.EventHandler(this.btnAgregarCobertura_Click);
            // 
            // btnAgregarRiesgos
            // 
            this.btnAgregarRiesgos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarRiesgos.Location = new System.Drawing.Point(68, 49);
            this.btnAgregarRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarRiesgos.Name = "btnAgregarRiesgos";
            this.btnAgregarRiesgos.Size = new System.Drawing.Size(65, 27);
            this.btnAgregarRiesgos.TabIndex = 2;
            this.btnAgregarRiesgos.Text = "Agregar";
            this.btnAgregarRiesgos.UseVisualStyleBackColor = true;
            this.btnAgregarRiesgos.Visible = false;
            this.btnAgregarRiesgos.Click += new System.EventHandler(this.btnAgregarRiesgos_Click);
            // 
            // lsbCoberturas
            // 
            this.lsbCoberturas.FormattingEnabled = true;
            this.lsbCoberturas.HorizontalScrollbar = true;
            this.lsbCoberturas.ItemHeight = 17;
            this.lsbCoberturas.Location = new System.Drawing.Point(208, 78);
            this.lsbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbCoberturas.Name = "lsbCoberturas";
            this.lsbCoberturas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCoberturas.Size = new System.Drawing.Size(288, 412);
            this.lsbCoberturas.TabIndex = 1;
            // 
            // lsbRiesgos
            // 
            this.lsbRiesgos.FormattingEnabled = true;
            this.lsbRiesgos.ItemHeight = 17;
            this.lsbRiesgos.Location = new System.Drawing.Point(6, 78);
            this.lsbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRiesgos.Name = "lsbRiesgos";
            this.lsbRiesgos.Size = new System.Drawing.Size(196, 174);
            this.lsbRiesgos.TabIndex = 0;
            this.lsbRiesgos.SelectedValueChanged += new System.EventHandler(this.lsbRiesgos_SelectedValueChanged);
            // 
            // grbRiesgos
            // 
            this.grbRiesgos.Controls.Add(this.btnDeleteFromPack);
            this.grbRiesgos.Controls.Add(this.btnInsertInPack);
            this.grbRiesgos.Controls.Add(this.grdCoveragesPack);
            this.grbRiesgos.Controls.Add(this.label15);
            this.grbRiesgos.Controls.Add(this.txtCoveragesPack);
            this.grbRiesgos.Controls.Add(this.btnQuitarPaquete);
            this.grbRiesgos.Controls.Add(this.btnAgregarPaquete);
            this.grbRiesgos.Controls.Add(this.label14);
            this.grbRiesgos.Controls.Add(this.label13);
            this.grbRiesgos.Controls.Add(this.txtCoberturas);
            this.grbRiesgos.Controls.Add(this.txtRiesgo);
            this.grbRiesgos.Controls.Add(this.btnQuitarCobertura);
            this.grbRiesgos.Controls.Add(this.btnQuitarRiesgo);
            this.grbRiesgos.Controls.Add(this.lsbCoberturas);
            this.grbRiesgos.Controls.Add(this.lsbRiesgos);
            this.grbRiesgos.Controls.Add(this.btnAgregarRiesgos);
            this.grbRiesgos.Controls.Add(this.btnAgregarCobertura);
            this.grbRiesgos.Location = new System.Drawing.Point(656, 94);
            this.grbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Name = "grbRiesgos";
            this.grbRiesgos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Size = new System.Drawing.Size(514, 554);
            this.grbRiesgos.TabIndex = 13;
            this.grbRiesgos.TabStop = false;
            this.grbRiesgos.Text = "Riesgos y Coberturas";
            // 
            // btnDeleteFromPack
            // 
            this.btnDeleteFromPack.AutoSize = true;
            this.btnDeleteFromPack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteFromPack.Location = new System.Drawing.Point(369, 498);
            this.btnDeleteFromPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteFromPack.Name = "btnDeleteFromPack";
            this.btnDeleteFromPack.Size = new System.Drawing.Size(127, 27);
            this.btnDeleteFromPack.TabIndex = 33;
            this.btnDeleteFromPack.Text = "Quitar del Paquete";
            this.btnDeleteFromPack.UseVisualStyleBackColor = true;
            this.btnDeleteFromPack.Visible = false;
            this.btnDeleteFromPack.Click += new System.EventHandler(this.btnDeleteFromPack_Click);
            // 
            // btnInsertInPack
            // 
            this.btnInsertInPack.AutoSize = true;
            this.btnInsertInPack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInsertInPack.Location = new System.Drawing.Point(208, 498);
            this.btnInsertInPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInsertInPack.Name = "btnInsertInPack";
            this.btnInsertInPack.Size = new System.Drawing.Size(131, 27);
            this.btnInsertInPack.TabIndex = 32;
            this.btnInsertInPack.Text = "Agregar al Paquete";
            this.toolTip.SetToolTip(this.btnInsertInPack, "Seleccione Cobertura y luego Cubre antes de apretar");
            this.btnInsertInPack.UseVisualStyleBackColor = true;
            this.btnInsertInPack.Visible = false;
            this.btnInsertInPack.Click += new System.EventHandler(this.btnInsertInPack_Click);
            // 
            // grdCoveragesPack
            // 
            this.grdCoveragesPack.AllowUserToAddRows = false;
            this.grdCoveragesPack.AllowUserToDeleteRows = false;
            this.grdCoveragesPack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCoveragesPack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCoveragesPack.ColumnHeadersVisible = false;
            this.grdCoveragesPack.Location = new System.Drawing.Point(6, 314);
            this.grdCoveragesPack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCoveragesPack.MultiSelect = false;
            this.grdCoveragesPack.Name = "grdCoveragesPack";
            this.grdCoveragesPack.ReadOnly = true;
            this.grdCoveragesPack.RowHeadersVisible = false;
            this.grdCoveragesPack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdCoveragesPack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCoveragesPack.ShowCellToolTips = false;
            this.grdCoveragesPack.Size = new System.Drawing.Size(196, 232);
            this.grdCoveragesPack.TabIndex = 25;
            this.toolTip.SetToolTip(this.grdCoveragesPack, "Doble Click para filtrar");
            this.grdCoveragesPack.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCoveragesPack_CellDoubleClick);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 290);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 17);
            this.label15.TabIndex = 31;
            this.label15.Text = "Paquete";
            // 
            // txtCoveragesPack
            // 
            this.txtCoveragesPack.Location = new System.Drawing.Point(6, 259);
            this.txtCoveragesPack.Name = "txtCoveragesPack";
            this.txtCoveragesPack.Size = new System.Drawing.Size(196, 25);
            this.txtCoveragesPack.TabIndex = 30;
            this.txtCoveragesPack.Visible = false;
            // 
            // btnQuitarPaquete
            // 
            this.btnQuitarPaquete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarPaquete.Location = new System.Drawing.Point(137, 285);
            this.btnQuitarPaquete.Name = "btnQuitarPaquete";
            this.btnQuitarPaquete.Size = new System.Drawing.Size(65, 27);
            this.btnQuitarPaquete.TabIndex = 29;
            this.btnQuitarPaquete.Text = "Quitar";
            this.btnQuitarPaquete.UseVisualStyleBackColor = true;
            this.btnQuitarPaquete.Visible = false;
            this.btnQuitarPaquete.Click += new System.EventHandler(this.btnQuitarPaquete_Click);
            // 
            // btnAgregarPaquete
            // 
            this.btnAgregarPaquete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarPaquete.Location = new System.Drawing.Point(68, 285);
            this.btnAgregarPaquete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarPaquete.Name = "btnAgregarPaquete";
            this.btnAgregarPaquete.Size = new System.Drawing.Size(65, 27);
            this.btnAgregarPaquete.TabIndex = 28;
            this.btnAgregarPaquete.Text = "Agregar";
            this.btnAgregarPaquete.UseVisualStyleBackColor = true;
            this.btnAgregarPaquete.Visible = false;
            this.btnAgregarPaquete.Click += new System.EventHandler(this.btnAgregarPaquete_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(217, 54);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "Coberturas";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "Riesgos";
            // 
            // txtCoberturas
            // 
            this.txtCoberturas.Location = new System.Drawing.Point(208, 21);
            this.txtCoberturas.Name = "txtCoberturas";
            this.txtCoberturas.Size = new System.Drawing.Size(288, 25);
            this.txtCoberturas.TabIndex = 25;
            this.txtCoberturas.Visible = false;
            // 
            // txtRiesgo
            // 
            this.txtRiesgo.Location = new System.Drawing.Point(6, 21);
            this.txtRiesgo.Name = "txtRiesgo";
            this.txtRiesgo.Size = new System.Drawing.Size(196, 25);
            this.txtRiesgo.TabIndex = 23;
            this.txtRiesgo.Visible = false;
            // 
            // btnQuitarCobertura
            // 
            this.btnQuitarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCobertura.Location = new System.Drawing.Point(431, 49);
            this.btnQuitarCobertura.Name = "btnQuitarCobertura";
            this.btnQuitarCobertura.Size = new System.Drawing.Size(65, 27);
            this.btnQuitarCobertura.TabIndex = 19;
            this.btnQuitarCobertura.Text = "Quitar";
            this.btnQuitarCobertura.UseVisualStyleBackColor = true;
            this.btnQuitarCobertura.Visible = false;
            this.btnQuitarCobertura.Click += new System.EventHandler(this.btnQuitarCobertura_Click);
            // 
            // btnQuitarRiesgo
            // 
            this.btnQuitarRiesgo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarRiesgo.Location = new System.Drawing.Point(137, 49);
            this.btnQuitarRiesgo.Name = "btnQuitarRiesgo";
            this.btnQuitarRiesgo.Size = new System.Drawing.Size(65, 27);
            this.btnQuitarRiesgo.TabIndex = 18;
            this.btnQuitarRiesgo.Text = "Quitar";
            this.btnQuitarRiesgo.UseVisualStyleBackColor = true;
            this.btnQuitarRiesgo.Visible = false;
            this.btnQuitarRiesgo.Click += new System.EventHandler(this.btnQuitarRiesgo_Click);
            // 
            // grdProductores
            // 
            this.grdProductores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductores.Location = new System.Drawing.Point(17, 56);
            this.grdProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProductores.MultiSelect = false;
            this.grdProductores.Name = "grdProductores";
            this.grdProductores.ReadOnly = true;
            this.grdProductores.RowHeadersVisible = false;
            this.grdProductores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProductores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductores.Size = new System.Drawing.Size(572, 123);
            this.grdProductores.TabIndex = 7;
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Location = new System.Drawing.Point(371, 23);
            this.btnAgregarProd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(67, 27);
            this.btnAgregarProd.TabIndex = 6;
            this.btnAgregarProd.Text = "Agregar";
            this.btnAgregarProd.UseVisualStyleBackColor = true;
            this.btnAgregarProd.Visible = false;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // cmbProductores
            // 
            this.cmbProductores.FormattingEnabled = true;
            this.cmbProductores.Location = new System.Drawing.Point(26, 26);
            this.cmbProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProductores.Name = "cmbProductores";
            this.cmbProductores.Size = new System.Drawing.Size(169, 25);
            this.cmbProductores.TabIndex = 5;
            this.cmbProductores.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 30);
            this.label9.TabIndex = 15;
            this.label9.Text = "COMPAÑÍAS";
            // 
            // grpLiquida
            // 
            this.grpLiquida.Controls.Add(this.label12);
            this.grpLiquida.Controls.Add(this.txtConvenio2);
            this.grpLiquida.Controls.Add(this.txtConvenio1);
            this.grpLiquida.Controls.Add(this.label11);
            this.grpLiquida.Controls.Add(this.label6);
            this.grpLiquida.Controls.Add(this.txtLiq1);
            this.grpLiquida.Controls.Add(this.txtLiq2);
            this.grpLiquida.Controls.Add(this.label7);
            this.grpLiquida.Location = new System.Drawing.Point(11, 158);
            this.grpLiquida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Name = "grpLiquida";
            this.grpLiquida.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Size = new System.Drawing.Size(362, 56);
            this.grpLiquida.TabIndex = 8;
            this.grpLiquida.TabStop = false;
            this.grpLiquida.Text = "Liquida";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "y";
            // 
            // txtConvenio2
            // 
            this.txtConvenio2.Location = new System.Drawing.Point(312, 24);
            this.txtConvenio2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio2.Name = "txtConvenio2";
            this.txtConvenio2.ReadOnly = true;
            this.txtConvenio2.Size = new System.Drawing.Size(31, 25);
            this.txtConvenio2.TabIndex = 6;
            // 
            // txtConvenio1
            // 
            this.txtConvenio1.Location = new System.Drawing.Point(231, 24);
            this.txtConvenio1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio1.Name = "txtConvenio1";
            this.txtConvenio1.ReadOnly = true;
            this.txtConvenio1.Size = new System.Drawing.Size(31, 25);
            this.txtConvenio1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "Paga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Día 1";
            // 
            // txtLiq1
            // 
            this.txtLiq1.Location = new System.Drawing.Point(47, 24);
            this.txtLiq1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLiq1.Name = "txtLiq1";
            this.txtLiq1.ReadOnly = true;
            this.txtLiq1.Size = new System.Drawing.Size(31, 25);
            this.txtLiq1.TabIndex = 0;
            // 
            // txtLiq2
            // 
            this.txtLiq2.Location = new System.Drawing.Point(128, 24);
            this.txtLiq2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLiq2.Name = "txtLiq2";
            this.txtLiq2.ReadOnly = true;
            this.txtLiq2.Size = new System.Drawing.Size(31, 25);
            this.txtLiq2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Día 2";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(341, 54);
            this.txtCUIT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.ReadOnly = true;
            this.txtCUIT.Size = new System.Drawing.Size(193, 25);
            this.txtCUIT.TabIndex = 8;
            // 
            // grpbDatos
            // 
            this.grpbDatos.Controls.Add(this.txtNotas);
            this.grpbDatos.Controls.Add(this.grpbContactos);
            this.grpbDatos.Controls.Add(this.txtCUIT);
            this.grpbDatos.Controls.Add(this.txtTelefono);
            this.grpbDatos.Controls.Add(this.txtMail);
            this.grpbDatos.Controls.Add(this.txtNombre);
            this.grpbDatos.Controls.Add(this.label5);
            this.grpbDatos.Controls.Add(this.grpLiquida);
            this.grpbDatos.Controls.Add(this.label1);
            this.grpbDatos.Controls.Add(this.label3);
            this.grpbDatos.Controls.Add(this.label4);
            this.grpbDatos.Controls.Add(this.label2);
            this.grpbDatos.Location = new System.Drawing.Point(16, 94);
            this.grpbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Name = "grpbDatos";
            this.grpbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Size = new System.Drawing.Size(604, 360);
            this.grpbDatos.TabIndex = 11;
            this.grpbDatos.TabStop = false;
            this.grpbDatos.Text = "Datos";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(71, 87);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ReadOnly = true;
            this.txtNotas.Size = new System.Drawing.Size(463, 63);
            this.txtNotas.TabIndex = 9;
            // 
            // grpbContactos
            // 
            this.grpbContactos.Controls.Add(this.grdContactos);
            this.grpbContactos.Location = new System.Drawing.Point(11, 222);
            this.grpbContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Name = "grpbContactos";
            this.grpbContactos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Size = new System.Drawing.Size(566, 130);
            this.grpbContactos.TabIndex = 10;
            this.grpbContactos.TabStop = false;
            this.grpbContactos.Text = "Contactos";
            // 
            // grdContactos
            // 
            this.grdContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContactos.Location = new System.Drawing.Point(6, 26);
            this.grdContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdContactos.MultiSelect = false;
            this.grdContactos.Name = "grdContactos";
            this.grdContactos.RowHeadersVisible = false;
            this.grdContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContactos.Size = new System.Drawing.Size(554, 96);
            this.grdContactos.TabIndex = 0;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(71, 54);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(193, 25);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(342, 25);
            this.txtMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(193, 25);
            this.txtMail.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(71, 26);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(193, 25);
            this.txtNombre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Notas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono";
            // 
            // btnNuevoProductor
            // 
            this.btnNuevoProductor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuevoProductor.Location = new System.Drawing.Point(517, 23);
            this.btnNuevoProductor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNuevoProductor.Name = "btnNuevoProductor";
            this.btnNuevoProductor.Size = new System.Drawing.Size(67, 27);
            this.btnNuevoProductor.TabIndex = 9;
            this.btnNuevoProductor.Text = "Nuevo";
            this.btnNuevoProductor.UseVisualStyleBackColor = true;
            this.btnNuevoProductor.Visible = false;
            this.btnNuevoProductor.Click += new System.EventHandler(this.btnNuevoProductor_Click);
            // 
            // grpbOperatoria
            // 
            this.grpbOperatoria.Controls.Add(this.lblCodigo);
            this.grpbOperatoria.Controls.Add(this.txtCode);
            this.grpbOperatoria.Controls.Add(this.btnQuitarProductor);
            this.grpbOperatoria.Controls.Add(this.btnNuevoProductor);
            this.grpbOperatoria.Controls.Add(this.grdProductores);
            this.grpbOperatoria.Controls.Add(this.btnAgregarProd);
            this.grpbOperatoria.Controls.Add(this.cmbProductores);
            this.grpbOperatoria.Location = new System.Drawing.Point(16, 462);
            this.grpbOperatoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Name = "grpbOperatoria";
            this.grpbOperatoria.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Size = new System.Drawing.Size(604, 186);
            this.grpbOperatoria.TabIndex = 12;
            this.grpbOperatoria.TabStop = false;
            this.grpbOperatoria.Text = "Productores";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(247, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(51, 17);
            this.lblCodigo.TabIndex = 22;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(243, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 25);
            this.txtCode.TabIndex = 21;
            this.txtCode.Text = "Código";
            this.txtCode.Visible = false;
            // 
            // btnQuitarProductor
            // 
            this.btnQuitarProductor.Location = new System.Drawing.Point(444, 23);
            this.btnQuitarProductor.Name = "btnQuitarProductor";
            this.btnQuitarProductor.Size = new System.Drawing.Size(67, 27);
            this.btnQuitarProductor.TabIndex = 20;
            this.btnQuitarProductor.Text = "Quitar";
            this.btnQuitarProductor.UseVisualStyleBackColor = true;
            this.btnQuitarProductor.Visible = false;
            this.btnQuitarProductor.Click += new System.EventHandler(this.btnQuitarProductor_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(191, 13);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(52, 27);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregarCompañia
            // 
            this.btnAgregarCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCompañia.Location = new System.Drawing.Point(275, 59);
            this.btnAgregarCompañia.Name = "btnAgregarCompañia";
            this.btnAgregarCompañia.Size = new System.Drawing.Size(73, 27);
            this.btnAgregarCompañia.TabIndex = 19;
            this.btnAgregarCompañia.Text = "Nueva";
            this.btnAgregarCompañia.UseVisualStyleBackColor = true;
            this.btnAgregarCompañia.Visible = false;
            this.btnAgregarCompañia.Click += new System.EventHandler(this.btnAgregarCompañia_Click);
            // 
            // btnQuitarCompañia
            // 
            this.btnQuitarCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCompañia.Location = new System.Drawing.Point(357, 59);
            this.btnQuitarCompañia.Name = "btnQuitarCompañia";
            this.btnQuitarCompañia.Size = new System.Drawing.Size(73, 27);
            this.btnQuitarCompañia.TabIndex = 21;
            this.btnQuitarCompañia.Text = "Eliminar";
            this.btnQuitarCompañia.UseVisualStyleBackColor = true;
            this.btnQuitarCompañia.Visible = false;
            this.btnQuitarCompañia.Click += new System.EventHandler(this.btnQuitarCompañia_Click);
            // 
            // lblNuevaCompañia
            // 
            this.lblNuevaCompañia.AutoSize = true;
            this.lblNuevaCompañia.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevaCompañia.Location = new System.Drawing.Point(353, 14);
            this.lblNuevaCompañia.Name = "lblNuevaCompañia";
            this.lblNuevaCompañia.Size = new System.Drawing.Size(164, 25);
            this.lblNuevaCompañia.TabIndex = 11;
            this.lblNuevaCompañia.Text = "Nueva Compañía";
            this.lblNuevaCompañia.Visible = false;
            // 
            // cmbTipoRiesgos
            // 
            this.cmbTipoRiesgos.FormattingEnabled = true;
            this.cmbTipoRiesgos.Location = new System.Drawing.Point(784, 68);
            this.cmbTipoRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRiesgos.Name = "cmbTipoRiesgos";
            this.cmbTipoRiesgos.Size = new System.Drawing.Size(198, 25);
            this.cmbTipoRiesgos.TabIndex = 24;
            this.cmbTipoRiesgos.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRiesgos_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(665, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tipo de Riesgos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(532, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 23);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // cmbCompañias
            // 
            this.cmbCompañias.FormattingEnabled = true;
            this.cmbCompañias.Location = new System.Drawing.Point(44, 61);
            this.cmbCompañias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCompañias.Name = "cmbCompañias";
            this.cmbCompañias.Size = new System.Drawing.Size(219, 25);
            this.cmbCompañias.TabIndex = 26;
            this.cmbCompañias.SelectionChangeCommitted += new System.EventHandler(this.cmbCompañias_SelectionChangeCommitted);
            // 
            // Compañías
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1177, 658);
            this.Controls.Add(this.cmbCompañias);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmbTipoRiesgos);
            this.Controls.Add(this.lblNuevaCompañia);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnQuitarCompañia);
            this.Controls.Add(this.btnAgregarCompañia);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grbRiesgos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grpbDatos);
            this.Controls.Add(this.grpbOperatoria);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Compañías";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compañías";
            this.grbRiesgos.ResumeLayout(false);
            this.grbRiesgos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCoveragesPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductores)).EndInit();
            this.grpLiquida.ResumeLayout(false);
            this.grpLiquida.PerformLayout();
            this.grpbDatos.ResumeLayout(false);
            this.grpbDatos.PerformLayout();
            this.grpbContactos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdContactos)).EndInit();
            this.grpbOperatoria.ResumeLayout(false);
            this.grpbOperatoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregarCobertura;
        private System.Windows.Forms.Button btnAgregarRiesgos;
        private System.Windows.Forms.ListBox lsbCoberturas;
        private System.Windows.Forms.ListBox lsbRiesgos;
        private System.Windows.Forms.GroupBox grbRiesgos;
        private System.Windows.Forms.DataGridView grdProductores;
        private System.Windows.Forms.Button btnAgregarProd;
        private System.Windows.Forms.ComboBox cmbProductores;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpLiquida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLiq1;
        private System.Windows.Forms.TextBox txtLiq2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.GroupBox grpbDatos;
        private System.Windows.Forms.GroupBox grpbContactos;
        private System.Windows.Forms.DataGridView grdContactos;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNuevoProductor;
        private System.Windows.Forms.GroupBox grpbOperatoria;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnQuitarRiesgo;
        private System.Windows.Forms.Button btnAgregarCompañia;
        private System.Windows.Forms.Button btnQuitarCobertura;
        private System.Windows.Forms.Button btnQuitarProductor;
        private System.Windows.Forms.Button btnQuitarCompañia;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblNuevaCompañia;
        private System.Windows.Forms.TextBox txtRiesgo;
        private System.Windows.Forms.TextBox txtCoberturas;
        private System.Windows.Forms.ComboBox cmbTipoRiesgos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtConvenio1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConvenio2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCoveragesPack;
        private System.Windows.Forms.Button btnQuitarPaquete;
        private System.Windows.Forms.Button btnAgregarPaquete;
        private System.Windows.Forms.DataGridView grdCoveragesPack;
        private System.Windows.Forms.Button btnDeleteFromPack;
        private System.Windows.Forms.Button btnInsertInPack;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cmbCompañias;
    }
}