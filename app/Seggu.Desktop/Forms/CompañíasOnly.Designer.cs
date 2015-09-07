namespace Seggu.Desktop.Forms
{
    partial class CompañíasOnly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompañíasOnly));
            this.grdCompañias = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grdProductores = new System.Windows.Forms.DataGridView();
            this.btnAgregarProd = new System.Windows.Forms.Button();
            this.cmbProductores = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.grpbContactos = new System.Windows.Forms.GroupBox();
            this.grdContactos = new System.Windows.Forms.DataGridView();
            this.txtNotas = new System.Windows.Forms.TextBox();
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
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductores)).BeginInit();
            this.grpLiquida.SuspendLayout();
            this.grpbDatos.SuspendLayout();
            this.grpbContactos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdContactos)).BeginInit();
            this.grpbOperatoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCompañias
            // 
            this.grdCompañias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCompañias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompañias.ColumnHeadersVisible = false;
            this.grdCompañias.Location = new System.Drawing.Point(12, 111);
            this.grdCompañias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCompañias.MultiSelect = false;
            this.grdCompañias.Name = "grdCompañias";
            this.grdCompañias.ReadOnly = true;
            this.grdCompañias.RowHeadersVisible = false;
            this.grdCompañias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdCompañias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompañias.Size = new System.Drawing.Size(160, 539);
            this.grdCompañias.TabIndex = 16;
            this.grdCompañias.TabStop = false;
            this.grdCompañias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompañias_CellContentClick);
            this.grdCompañias.SelectionChanged += new System.EventHandler(this.grdCompañias_SelectionChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Location = new System.Drawing.Point(249, 13);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(66, 27);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grdProductores
            // 
            this.grdProductores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductores.Location = new System.Drawing.Point(9, 172);
            this.grdProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdProductores.MultiSelect = false;
            this.grdProductores.Name = "grdProductores";
            this.grdProductores.ReadOnly = true;
            this.grdProductores.RowHeadersVisible = false;
            this.grdProductores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProductores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductores.Size = new System.Drawing.Size(547, 204);
            this.grdProductores.TabIndex = 7;
            // 
            // btnAgregarProd
            // 
            this.btnAgregarProd.Location = new System.Drawing.Point(299, 115);
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
            this.cmbProductores.Enabled = false;
            this.cmbProductores.FormattingEnabled = true;
            this.cmbProductores.Location = new System.Drawing.Point(104, 97);
            this.cmbProductores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProductores.Name = "cmbProductores";
            this.cmbProductores.Size = new System.Drawing.Size(169, 25);
            this.cmbProductores.TabIndex = 5;
            this.cmbProductores.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Productores";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 30);
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
            this.grpLiquida.Location = new System.Drawing.Point(13, 26);
            this.grpLiquida.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Name = "grpLiquida";
            this.grpLiquida.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpLiquida.Size = new System.Drawing.Size(544, 60);
            this.grpLiquida.TabIndex = 8;
            this.grpLiquida.TabStop = false;
            this.grpLiquida.Text = "Liquida";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(411, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 17);
            this.label12.TabIndex = 7;
            this.label12.Text = "y";
            // 
            // txtConvenio2
            // 
            this.txtConvenio2.Location = new System.Drawing.Point(456, 24);
            this.txtConvenio2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio2.Name = "txtConvenio2";
            this.txtConvenio2.ReadOnly = true;
            this.txtConvenio2.Size = new System.Drawing.Size(31, 25);
            this.txtConvenio2.TabIndex = 6;
            this.txtConvenio2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenio2_KeyPress);
            // 
            // txtConvenio1
            // 
            this.txtConvenio1.Location = new System.Drawing.Point(348, 24);
            this.txtConvenio1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConvenio1.Name = "txtConvenio1";
            this.txtConvenio1.ReadOnly = true;
            this.txtConvenio1.Size = new System.Drawing.Size(31, 25);
            this.txtConvenio1.TabIndex = 4;
            this.txtConvenio1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenio1_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 27);
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
            this.txtLiq1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiq1_KeyPress);
            // 
            // txtLiq2
            // 
            this.txtLiq2.Location = new System.Drawing.Point(172, 24);
            this.txtLiq2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLiq2.Name = "txtLiq2";
            this.txtLiq2.ReadOnly = true;
            this.txtLiq2.Size = new System.Drawing.Size(31, 25);
            this.txtLiq2.TabIndex = 1;
            this.txtLiq2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLiq2_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Día 2";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(71, 140);
            this.txtCUIT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCUIT.MaxLength = 11;
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.ReadOnly = true;
            this.txtCUIT.Size = new System.Drawing.Size(193, 25);
            this.txtCUIT.TabIndex = 8;
            this.txtCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIT_KeyPress);
            // 
            // grpbDatos
            // 
            this.grpbDatos.Controls.Add(this.grpbContactos);
            this.grpbDatos.Controls.Add(this.txtNotas);
            this.grpbDatos.Controls.Add(this.txtCUIT);
            this.grpbDatos.Controls.Add(this.txtTelefono);
            this.grpbDatos.Controls.Add(this.txtMail);
            this.grpbDatos.Controls.Add(this.txtNombre);
            this.grpbDatos.Controls.Add(this.label5);
            this.grpbDatos.Controls.Add(this.label1);
            this.grpbDatos.Controls.Add(this.label3);
            this.grpbDatos.Controls.Add(this.label4);
            this.grpbDatos.Controls.Add(this.label2);
            this.grpbDatos.Location = new System.Drawing.Point(180, 73);
            this.grpbDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Name = "grpbDatos";
            this.grpbDatos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbDatos.Size = new System.Drawing.Size(566, 176);
            this.grpbDatos.TabIndex = 11;
            this.grpbDatos.TabStop = false;
            this.grpbDatos.Text = "Datos";
            // 
            // grpbContactos
            // 
            this.grpbContactos.Controls.Add(this.grdContactos);
            this.grpbContactos.Location = new System.Drawing.Point(6, 174);
            this.grpbContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Name = "grpbContactos";
            this.grpbContactos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbContactos.Size = new System.Drawing.Size(542, 143);
            this.grpbContactos.TabIndex = 10;
            this.grpbContactos.TabStop = false;
            this.grpbContactos.Text = "Contactos";
            this.grpbContactos.Visible = false;
            // 
            // grdContactos
            // 
            this.grdContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdContactos.Location = new System.Drawing.Point(7, 25);
            this.grdContactos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdContactos.MultiSelect = false;
            this.grdContactos.Name = "grdContactos";
            this.grdContactos.RowHeadersVisible = false;
            this.grdContactos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.grdContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdContactos.Size = new System.Drawing.Size(528, 110);
            this.grdContactos.TabIndex = 0;
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(355, 38);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ReadOnly = true;
            this.txtNotas.Size = new System.Drawing.Size(193, 128);
            this.txtNotas.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(71, 107);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(193, 25);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(71, 72);
            this.txtMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(193, 25);
            this.txtMail.TabIndex = 6;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(71, 38);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(193, 25);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Notas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "CUIT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teléfono";
            // 
            // btnNuevoProductor
            // 
            this.btnNuevoProductor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuevoProductor.Location = new System.Drawing.Point(474, 115);
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
            this.grpbOperatoria.Controls.Add(this.grpLiquida);
            this.grpbOperatoria.Controls.Add(this.grdProductores);
            this.grpbOperatoria.Controls.Add(this.btnAgregarProd);
            this.grpbOperatoria.Controls.Add(this.cmbProductores);
            this.grpbOperatoria.Controls.Add(this.label8);
            this.grpbOperatoria.Location = new System.Drawing.Point(180, 272);
            this.grpbOperatoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Name = "grpbOperatoria";
            this.grpbOperatoria.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpbOperatoria.Size = new System.Drawing.Size(566, 389);
            this.grpbOperatoria.TabIndex = 12;
            this.grpbOperatoria.TabStop = false;
            this.grpbOperatoria.Text = "Operatoria";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(19, 133);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(51, 17);
            this.lblCodigo.TabIndex = 22;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(104, 130);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(169, 25);
            this.txtCode.TabIndex = 21;
            this.txtCode.Visible = false;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // btnQuitarProductor
            // 
            this.btnQuitarProductor.Location = new System.Drawing.Point(387, 115);
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
            this.btnAgregarCompañia.Location = new System.Drawing.Point(12, 73);
            this.btnAgregarCompañia.Name = "btnAgregarCompañia";
            this.btnAgregarCompañia.Size = new System.Drawing.Size(73, 27);
            this.btnAgregarCompañia.TabIndex = 19;
            this.btnAgregarCompañia.Text = "Nueva";
            this.btnAgregarCompañia.UseVisualStyleBackColor = true;
            this.btnAgregarCompañia.Click += new System.EventHandler(this.btnAgregarCompañia_Click);
            // 
            // btnQuitarCompañia
            // 
            this.btnQuitarCompañia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitarCompañia.Location = new System.Drawing.Point(99, 73);
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
            this.lblNuevaCompañia.Location = new System.Drawing.Point(408, 12);
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
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancelar.Location = new System.Drawing.Point(321, 12);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 27);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CompañíasOnly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(758, 681);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNuevaCompañia);
            this.Controls.Add(this.btnQuitarCompañia);
            this.Controls.Add(this.btnAgregarCompañia);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.grdCompañias);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.grpbDatos);
            this.Controls.Add(this.grpbOperatoria);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CompañíasOnly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compañías";
            ((System.ComponentModel.ISupportInitialize)(this.grdCompañias)).EndInit();
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

        private System.Windows.Forms.DataGridView grdCompañias;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView grdProductores;
        private System.Windows.Forms.Button btnAgregarProd;
        private System.Windows.Forms.ComboBox cmbProductores;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Button btnAgregarCompañia;
        private System.Windows.Forms.Button btnQuitarProductor;
        private System.Windows.Forms.Button btnQuitarCompañia;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblNuevaCompañia;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtConvenio1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConvenio2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnCancelar;
    }
}