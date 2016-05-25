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
            this.label8 = new System.Windows.Forms.Label();
            this.lstCoveragesMaster = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnQuitarCobertura = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRiesgo = new System.Windows.Forms.TextBox();
            this.btnQuitarRiesgo = new System.Windows.Forms.Button();
            this.cmbTipoRiesgos = new System.Windows.Forms.ComboBox();
            this.txtCoberturas = new System.Windows.Forms.TextBox();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cmbCompañias = new System.Windows.Forms.ComboBox();
            this.grbRiesgos.SuspendLayout();
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
            this.btnGuardar.Location = new System.Drawing.Point(275, 12);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(59, 25);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregarCobertura
            // 
            this.btnAgregarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCobertura.Location = new System.Drawing.Point(918, 255);
            this.btnAgregarCobertura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarCobertura.Name = "btnAgregarCobertura";
            this.btnAgregarCobertura.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarCobertura.TabIndex = 3;
            this.btnAgregarCobertura.Text = "+";
            this.btnAgregarCobertura.UseVisualStyleBackColor = true;
            this.btnAgregarCobertura.Visible = false;
            this.btnAgregarCobertura.Click += new System.EventHandler(this.btnAgregarCobertura_Click);
            // 
            // btnAgregarRiesgos
            // 
            this.btnAgregarRiesgos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarRiesgos.Location = new System.Drawing.Point(178, 255);
            this.btnAgregarRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarRiesgos.Name = "btnAgregarRiesgos";
            this.btnAgregarRiesgos.Size = new System.Drawing.Size(25, 25);
            this.btnAgregarRiesgos.TabIndex = 2;
            this.btnAgregarRiesgos.Text = "+";
            this.btnAgregarRiesgos.UseVisualStyleBackColor = true;
            this.btnAgregarRiesgos.Visible = false;
            this.btnAgregarRiesgos.Click += new System.EventHandler(this.btnAgregarRiesgos_Click);
            // 
            // lsbCoberturas
            // 
            this.lsbCoberturas.FormattingEnabled = true;
            this.lsbCoberturas.HorizontalScrollbar = true;
            this.lsbCoberturas.ItemHeight = 15;
            this.lsbCoberturas.Location = new System.Drawing.Point(242, 69);
            this.lsbCoberturas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbCoberturas.Name = "lsbCoberturas";
            this.lsbCoberturas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbCoberturas.Size = new System.Drawing.Size(371, 154);
            this.lsbCoberturas.TabIndex = 1;
            // 
            // lsbRiesgos
            // 
            this.lsbRiesgos.FormattingEnabled = true;
            this.lsbRiesgos.ItemHeight = 15;
            this.lsbRiesgos.Location = new System.Drawing.Point(6, 69);
            this.lsbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbRiesgos.Name = "lsbRiesgos";
            this.lsbRiesgos.Size = new System.Drawing.Size(229, 154);
            this.lsbRiesgos.TabIndex = 0;
            this.lsbRiesgos.SelectedValueChanged += new System.EventHandler(this.lsbRiesgos_SelectedValueChanged);
            // 
            // grbRiesgos
            // 
            this.grbRiesgos.Controls.Add(this.label8);
            this.grbRiesgos.Controls.Add(this.lstCoveragesMaster);
            this.grbRiesgos.Controls.Add(this.label10);
            this.grbRiesgos.Controls.Add(this.label14);
            this.grbRiesgos.Controls.Add(this.btnAgregarCobertura);
            this.grbRiesgos.Controls.Add(this.btnQuitarCobertura);
            this.grbRiesgos.Controls.Add(this.label13);
            this.grbRiesgos.Controls.Add(this.txtRiesgo);
            this.grbRiesgos.Controls.Add(this.btnAgregarRiesgos);
            this.grbRiesgos.Controls.Add(this.btnQuitarRiesgo);
            this.grbRiesgos.Controls.Add(this.cmbTipoRiesgos);
            this.grbRiesgos.Controls.Add(this.lsbCoberturas);
            this.grbRiesgos.Controls.Add(this.lsbRiesgos);
            this.grbRiesgos.Controls.Add(this.txtCoberturas);
            this.grbRiesgos.Location = new System.Drawing.Point(3, 346);
            this.grbRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Name = "grbRiesgos";
            this.grbRiesgos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbRiesgos.Size = new System.Drawing.Size(617, 226);
            this.grbRiesgos.TabIndex = 13;
            this.grbRiesgos.TabStop = false;
            this.grbRiesgos.Text = "Riesgos y Coberturas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(616, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Todas las Coberturas";
            // 
            // lstCoveragesMaster
            // 
            this.lstCoveragesMaster.FormattingEnabled = true;
            this.lstCoveragesMaster.HorizontalScrollbar = true;
            this.lstCoveragesMaster.ItemHeight = 15;
            this.lstCoveragesMaster.Location = new System.Drawing.Point(619, 69);
            this.lstCoveragesMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstCoveragesMaster.Name = "lstCoveragesMaster";
            this.lstCoveragesMaster.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCoveragesMaster.Size = new System.Drawing.Size(363, 154);
            this.lstCoveragesMaster.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Tipo de Riesgos";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(248, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 15);
            this.label14.TabIndex = 26;
            this.label14.Text = "Coberturas";
            // 
            // btnQuitarCobertura
            // 
            this.btnQuitarCobertura.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCobertura.Location = new System.Drawing.Point(951, 255);
            this.btnQuitarCobertura.Name = "btnQuitarCobertura";
            this.btnQuitarCobertura.Size = new System.Drawing.Size(25, 25);
            this.btnQuitarCobertura.TabIndex = 19;
            this.btnQuitarCobertura.Text = "-";
            this.btnQuitarCobertura.UseVisualStyleBackColor = true;
            this.btnQuitarCobertura.Visible = false;
            this.btnQuitarCobertura.Click += new System.EventHandler(this.btnQuitarCobertura_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Riesgos";
            // 
            // txtRiesgo
            // 
            this.txtRiesgo.Location = new System.Drawing.Point(6, 230);
            this.txtRiesgo.Name = "txtRiesgo";
            this.txtRiesgo.Size = new System.Drawing.Size(229, 23);
            this.txtRiesgo.TabIndex = 23;
            this.txtRiesgo.Visible = false;
            // 
            // btnQuitarRiesgo
            // 
            this.btnQuitarRiesgo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarRiesgo.Location = new System.Drawing.Point(208, 255);
            this.btnQuitarRiesgo.Name = "btnQuitarRiesgo";
            this.btnQuitarRiesgo.Size = new System.Drawing.Size(25, 25);
            this.btnQuitarRiesgo.TabIndex = 18;
            this.btnQuitarRiesgo.Text = "-";
            this.btnQuitarRiesgo.UseVisualStyleBackColor = true;
            this.btnQuitarRiesgo.Visible = false;
            this.btnQuitarRiesgo.Click += new System.EventHandler(this.btnQuitarRiesgo_Click);
            // 
            // cmbTipoRiesgos
            // 
            this.cmbTipoRiesgos.FormattingEnabled = true;
            this.cmbTipoRiesgos.Location = new System.Drawing.Point(105, 20);
            this.cmbTipoRiesgos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRiesgos.Name = "cmbTipoRiesgos";
            this.cmbTipoRiesgos.Size = new System.Drawing.Size(226, 23);
            this.cmbTipoRiesgos.TabIndex = 24;
            this.cmbTipoRiesgos.SelectionChangeCommitted += new System.EventHandler(this.cmbTipoRiesgos_SelectionChangeCommitted);
            // 
            // txtCoberturas
            // 
            this.txtCoberturas.Location = new System.Drawing.Point(619, 230);
            this.txtCoberturas.Name = "txtCoberturas";
            this.txtCoberturas.Size = new System.Drawing.Size(363, 23);
            this.txtCoberturas.TabIndex = 25;
            this.txtCoberturas.Visible = false;
            // 
            // grdProductores
            // 
            this.grdProductores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductores.Location = new System.Drawing.Point(6, 51);
            this.grdProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProductores.MultiSelect = false;
            this.grdProductores.Name = "grdProductores";
            this.grdProductores.ReadOnly = true;
            this.grdProductores.RowHeadersVisible = false;
            this.grdProductores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProductores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductores.Size = new System.Drawing.Size(471, 109);
            this.grdProductores.TabIndex = 7;
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Location = new System.Drawing.Point(295, 23);
            this.btnAgregarProd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarProd.Name = "btnAgregarProd";
            this.btnAgregarProd.Size = new System.Drawing.Size(28, 24);
            this.btnAgregarProd.TabIndex = 6;
            this.btnAgregarProd.Text = "+";
            this.btnAgregarProd.UseVisualStyleBackColor = true;
            this.btnAgregarProd.Visible = false;
            this.btnAgregarProd.Click += new System.EventHandler(this.btnAgregarProd_Click);
            // 
            // cmbProductores
            // 
            this.cmbProductores.FormattingEnabled = true;
            this.cmbProductores.Location = new System.Drawing.Point(6, 24);
            this.cmbProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProductores.Name = "cmbProductores";
            this.cmbProductores.Size = new System.Drawing.Size(169, 23);
            this.cmbProductores.TabIndex = 5;
            this.cmbProductores.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 9);
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
            this.grpLiquida.Location = new System.Drawing.Point(505, 24);
            this.grpLiquida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Name = "grpLiquida";
            this.grpLiquida.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Size = new System.Drawing.Size(362, 49);
            this.grpLiquida.TabIndex = 8;
            this.grpLiquida.TabStop = false;
            this.grpLiquida.Text = "Liquida";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 15);
            this.label12.TabIndex = 7;
            this.label12.Text = "y";
            // 
            // txtConvenio2
            // 
            this.txtConvenio2.Location = new System.Drawing.Point(312, 21);
            this.txtConvenio2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio2.Name = "txtConvenio2";
            this.txtConvenio2.ReadOnly = true;
            this.txtConvenio2.Size = new System.Drawing.Size(31, 23);
            this.txtConvenio2.TabIndex = 6;
            // 
            // txtConvenio1
            // 
            this.txtConvenio1.Location = new System.Drawing.Point(231, 21);
            this.txtConvenio1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio1.Name = "txtConvenio1";
            this.txtConvenio1.ReadOnly = true;
            this.txtConvenio1.Size = new System.Drawing.Size(31, 23);
            this.txtConvenio1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(193, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Paga";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Día 1";
            // 
            // txtLiq1
            // 
            this.txtLiq1.Location = new System.Drawing.Point(47, 21);
            this.txtLiq1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLiq1.Name = "txtLiq1";
            this.txtLiq1.ReadOnly = true;
            this.txtLiq1.Size = new System.Drawing.Size(31, 23);
            this.txtLiq1.TabIndex = 0;
            // 
            // txtLiq2
            // 
            this.txtLiq2.Location = new System.Drawing.Point(128, 21);
            this.txtLiq2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLiq2.Name = "txtLiq2";
            this.txtLiq2.ReadOnly = true;
            this.txtLiq2.Size = new System.Drawing.Size(31, 23);
            this.txtLiq2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Día 2";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(300, 50);
            this.txtCUIT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.ReadOnly = true;
            this.txtCUIT.Size = new System.Drawing.Size(193, 23);
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
            this.grpbDatos.Controls.Add(this.grpbOperatoria);
            this.grpbDatos.Controls.Add(this.label4);
            this.grpbDatos.Controls.Add(this.label2);
            this.grpbDatos.Location = new System.Drawing.Point(3, 75);
            this.grpbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Name = "grpbDatos";
            this.grpbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Size = new System.Drawing.Size(988, 263);
            this.grpbDatos.TabIndex = 11;
            this.grpbDatos.TabStop = false;
            this.grpbDatos.Text = "Datos";
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(71, 77);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ReadOnly = true;
            this.txtNotas.Size = new System.Drawing.Size(422, 56);
            this.txtNotas.TabIndex = 9;
            // 
            // grpbContactos
            // 
            this.grpbContactos.Controls.Add(this.grdContactos);
            this.grpbContactos.Location = new System.Drawing.Point(6, 141);
            this.grpbContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Name = "grpbContactos";
            this.grpbContactos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Size = new System.Drawing.Size(487, 115);
            this.grpbContactos.TabIndex = 10;
            this.grpbContactos.TabStop = false;
            this.grpbContactos.Text = "Contactos";
            // 
            // grdContactos
            // 
            this.grdContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContactos.Location = new System.Drawing.Point(6, 23);
            this.grdContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdContactos.MultiSelect = false;
            this.grdContactos.Name = "grdContactos";
            this.grdContactos.RowHeadersVisible = false;
            this.grdContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContactos.Size = new System.Drawing.Size(468, 85);
            this.grdContactos.TabIndex = 0;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(71, 48);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(174, 23);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(301, 24);
            this.txtMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(193, 23);
            this.txtMail.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(71, 23);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(174, 23);
            this.txtNombre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Notas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono";
            // 
            // btnNuevoProductor
            // 
            this.btnNuevoProductor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuevoProductor.Location = new System.Drawing.Point(410, 22);
            this.btnNuevoProductor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNuevoProductor.Name = "btnNuevoProductor";
            this.btnNuevoProductor.Size = new System.Drawing.Size(67, 24);
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
            this.grpbOperatoria.Location = new System.Drawing.Point(499, 91);
            this.grpbOperatoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Name = "grpbOperatoria";
            this.grpbOperatoria.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Size = new System.Drawing.Size(483, 164);
            this.grpbOperatoria.TabIndex = 12;
            this.grpbOperatoria.TabStop = false;
            this.grpbOperatoria.Text = "Productores";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(211, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(46, 15);
            this.lblCodigo.TabIndex = 22;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(181, 24);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 23);
            this.txtCode.TabIndex = 21;
            this.txtCode.Text = "Código";
            this.txtCode.Visible = false;
            // 
            // btnQuitarProductor
            // 
            this.btnQuitarProductor.Location = new System.Drawing.Point(329, 23);
            this.btnQuitarProductor.Name = "btnQuitarProductor";
            this.btnQuitarProductor.Size = new System.Drawing.Size(28, 24);
            this.btnQuitarProductor.TabIndex = 20;
            this.btnQuitarProductor.Text = "-";
            this.btnQuitarProductor.UseVisualStyleBackColor = true;
            this.btnQuitarProductor.Visible = false;
            this.btnQuitarProductor.Click += new System.EventHandler(this.btnQuitarProductor_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.Location = new System.Drawing.Point(191, 11);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(47, 25);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregarCompañia
            // 
            this.btnAgregarCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCompañia.Location = new System.Drawing.Point(228, 44);
            this.btnAgregarCompañia.Name = "btnAgregarCompañia";
            this.btnAgregarCompañia.Size = new System.Drawing.Size(73, 24);
            this.btnAgregarCompañia.TabIndex = 19;
            this.btnAgregarCompañia.Text = "Nueva";
            this.btnAgregarCompañia.UseVisualStyleBackColor = true;
            this.btnAgregarCompañia.Visible = false;
            this.btnAgregarCompañia.Click += new System.EventHandler(this.btnAgregarCompañia_Click);
            // 
            // btnQuitarCompañia
            // 
            this.btnQuitarCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCompañia.Location = new System.Drawing.Point(307, 44);
            this.btnQuitarCompañia.Name = "btnQuitarCompañia";
            this.btnQuitarCompañia.Size = new System.Drawing.Size(73, 24);
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
            this.lblNuevaCompañia.Location = new System.Drawing.Point(353, 12);
            this.lblNuevaCompañia.Name = "lblNuevaCompañia";
            this.lblNuevaCompañia.Size = new System.Drawing.Size(164, 25);
            this.lblNuevaCompañia.TabIndex = 11;
            this.lblNuevaCompañia.Text = "Nueva Compañía";
            this.lblNuevaCompañia.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(524, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(90, 26);
            this.progressBar1.TabIndex = 25;
            this.progressBar1.Visible = false;
            // 
            // cmbCompañias
            // 
            this.cmbCompañias.FormattingEnabled = true;
            this.cmbCompañias.Location = new System.Drawing.Point(3, 44);
            this.cmbCompañias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCompañias.Name = "cmbCompañias";
            this.cmbCompañias.Size = new System.Drawing.Size(219, 23);
            this.cmbCompañias.TabIndex = 26;
            this.cmbCompañias.SelectionChangeCommitted += new System.EventHandler(this.cmbCompañias_SelectionChangeCommitted);
            // 
            // Compañías
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(994, 586);
            this.Controls.Add(this.cmbCompañias);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblNuevaCompañia);
            this.Controls.Add(this.btnQuitarCompañia);
            this.Controls.Add(this.btnAgregarCompañia);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grbRiesgos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grpbDatos);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Compañías";
            this.Text = "Compañías";
            this.grbRiesgos.ResumeLayout(false);
            this.grbRiesgos.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox cmbCompañias;
        private System.Windows.Forms.ListBox lstCoveragesMaster;
        private System.Windows.Forms.Label label8;
    }
}