namespace Seggu.Desktop.UserControls
{
    partial class LiquidacionesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.grdLiquidaciones = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnGuardarSeleccion = new System.Windows.Forms.Button();
            this.tbcLiquidationIndex = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDeleteFeeSelection = new System.Windows.Forms.Button();
            this.btnAgregarFeeSelection = new System.Windows.Forms.Button();
            this.btnSaveLiquidation = new System.Windows.Forms.Button();
            this.btnDeleteLiquidation = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grdFeeSelections = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLiqNotes = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblLiquidacion = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdCandidateFees = new System.Windows.Forms.DataGridView();
            this.grdSelectedFees = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpConvenio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSelectionName = new System.Windows.Forms.TextBox();
            this.lblCurrentSelelction = new System.Windows.Forms.Label();
            this.cmbCompañia = new System.Windows.Forms.ComboBox();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidaciones)).BeginInit();
            this.tbcLiquidationIndex.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeSelections)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCandidateFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Liquidaciones";
            // 
            // grdLiquidaciones
            // 
            this.grdLiquidaciones.AllowUserToAddRows = false;
            this.grdLiquidaciones.AllowUserToDeleteRows = false;
            this.grdLiquidaciones.AllowUserToOrderColumns = true;
            this.grdLiquidaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLiquidaciones.Location = new System.Drawing.Point(15, 15);
            this.grdLiquidaciones.Margin = new System.Windows.Forms.Padding(15);
            this.grdLiquidaciones.MultiSelect = false;
            this.grdLiquidaciones.Name = "grdLiquidaciones";
            this.grdLiquidaciones.RowHeadersVisible = false;
            this.grdLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLiquidaciones.Size = new System.Drawing.Size(639, 543);
            this.grdLiquidaciones.TabIndex = 6;
            this.grdLiquidaciones.SelectionChanged += new System.EventHandler(this.grdLiquidaciones_SelectionChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnImprimir.Location = new System.Drawing.Point(1107, 542);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(15);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(67, 27);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGuardarSeleccion
            // 
            this.btnGuardarSeleccion.AutoSize = true;
            this.btnGuardarSeleccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardarSeleccion.Enabled = false;
            this.btnGuardarSeleccion.Location = new System.Drawing.Point(903, 542);
            this.btnGuardarSeleccion.Name = "btnGuardarSeleccion";
            this.btnGuardarSeleccion.Size = new System.Drawing.Size(124, 27);
            this.btnGuardarSeleccion.TabIndex = 9;
            this.btnGuardarSeleccion.Text = "Guardar Selección";
            this.toolTip1.SetToolTip(this.btnGuardarSeleccion, "Crea una selección preLiquidación");
            this.btnGuardarSeleccion.UseVisualStyleBackColor = true;
            this.btnGuardarSeleccion.Click += new System.EventHandler(this.btnGuardarSeleccion_Click);
            // 
            // tbcLiquidationIndex
            // 
            this.tbcLiquidationIndex.Controls.Add(this.tabPage1);
            this.tbcLiquidationIndex.Controls.Add(this.tabPage2);
            this.tbcLiquidationIndex.Location = new System.Drawing.Point(8, 31);
            this.tbcLiquidationIndex.Margin = new System.Windows.Forms.Padding(14);
            this.tbcLiquidationIndex.Name = "tbcLiquidationIndex";
            this.tbcLiquidationIndex.SelectedIndex = 0;
            this.tbcLiquidationIndex.Size = new System.Drawing.Size(1196, 606);
            this.tbcLiquidationIndex.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.btnDeleteFeeSelection);
            this.tabPage1.Controls.Add(this.btnAgregarFeeSelection);
            this.tabPage1.Controls.Add(this.btnSaveLiquidation);
            this.tabPage1.Controls.Add(this.btnDeleteLiquidation);
            this.tabPage1.Controls.Add(this.btnRegistrar);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.grdFeeSelections);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtLiqNotes);
            this.tabPage1.Controls.Add(this.grdLiquidaciones);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1188, 576);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Liquidaciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = true;
            this.btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNew.Location = new System.Drawing.Point(672, 384);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 27);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "Nueva";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDeleteFeeSelection
            // 
            this.btnDeleteFeeSelection.AutoSize = true;
            this.btnDeleteFeeSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteFeeSelection.Location = new System.Drawing.Point(923, 10);
            this.btnDeleteFeeSelection.Name = "btnDeleteFeeSelection";
            this.btnDeleteFeeSelection.Size = new System.Drawing.Size(23, 27);
            this.btnDeleteFeeSelection.TabIndex = 27;
            this.btnDeleteFeeSelection.Text = "-";
            this.btnDeleteFeeSelection.UseVisualStyleBackColor = true;
            this.btnDeleteFeeSelection.Click += new System.EventHandler(this.btnDeleteFeeSelection_Click);
            // 
            // btnAgregarFeeSelection
            // 
            this.btnAgregarFeeSelection.AutoSize = true;
            this.btnAgregarFeeSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarFeeSelection.Location = new System.Drawing.Point(890, 10);
            this.btnAgregarFeeSelection.Name = "btnAgregarFeeSelection";
            this.btnAgregarFeeSelection.Size = new System.Drawing.Size(27, 27);
            this.btnAgregarFeeSelection.TabIndex = 26;
            this.btnAgregarFeeSelection.Text = "+";
            this.btnAgregarFeeSelection.UseVisualStyleBackColor = true;
            this.btnAgregarFeeSelection.Click += new System.EventHandler(this.btnAgregarFeeSelection_Click);
            // 
            // btnSaveLiquidation
            // 
            this.btnSaveLiquidation.AutoSize = true;
            this.btnSaveLiquidation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveLiquidation.Location = new System.Drawing.Point(871, 384);
            this.btnSaveLiquidation.Name = "btnSaveLiquidation";
            this.btnSaveLiquidation.Size = new System.Drawing.Size(59, 27);
            this.btnSaveLiquidation.TabIndex = 25;
            this.btnSaveLiquidation.Text = "Grabar";
            this.btnSaveLiquidation.UseVisualStyleBackColor = true;
            this.btnSaveLiquidation.Click += new System.EventHandler(this.btnSaveLiquidation_Click);
            // 
            // btnDeleteLiquidation
            // 
            this.btnDeleteLiquidation.AutoSize = true;
            this.btnDeleteLiquidation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeleteLiquidation.Location = new System.Drawing.Point(810, 384);
            this.btnDeleteLiquidation.Name = "btnDeleteLiquidation";
            this.btnDeleteLiquidation.Size = new System.Drawing.Size(55, 27);
            this.btnDeleteLiquidation.TabIndex = 24;
            this.btnDeleteLiquidation.Text = "Borrar";
            this.btnDeleteLiquidation.UseVisualStyleBackColor = true;
            this.btnDeleteLiquidation.Click += new System.EventHandler(this.btnDeleteLiquidation_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AutoSize = true;
            this.btnRegistrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRegistrar.Location = new System.Drawing.Point(733, 384);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(71, 27);
            this.btnRegistrar.TabIndex = 17;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(672, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Grupos de cuotas seleccionadas";
            // 
            // grdFeeSelections
            // 
            this.grdFeeSelections.AllowUserToAddRows = false;
            this.grdFeeSelections.AllowUserToDeleteRows = false;
            this.grdFeeSelections.AllowUserToOrderColumns = true;
            this.grdFeeSelections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdFeeSelections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFeeSelections.Location = new System.Drawing.Point(675, 47);
            this.grdFeeSelections.Margin = new System.Windows.Forms.Padding(15);
            this.grdFeeSelections.MultiSelect = false;
            this.grdFeeSelections.Name = "grdFeeSelections";
            this.grdFeeSelections.ReadOnly = true;
            this.grdFeeSelections.RowHeadersVisible = false;
            this.grdFeeSelections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFeeSelections.Size = new System.Drawing.Size(505, 262);
            this.grdFeeSelections.TabIndex = 22;
            this.grdFeeSelections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFeeSelections_CellDoubleClick);
            this.grdFeeSelections.SelectionChanged += new System.EventHandler(this.grdFeeSelections_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(676, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Notas de la Liquidación";
            // 
            // txtLiqNotes
            // 
            this.txtLiqNotes.Location = new System.Drawing.Point(672, 443);
            this.txtLiqNotes.Multiline = true;
            this.txtLiqNotes.Name = "txtLiqNotes";
            this.txtLiqNotes.Size = new System.Drawing.Size(502, 115);
            this.txtLiqNotes.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtNotes);
            this.tabPage2.Controls.Add(this.btnEdit);
            this.tabPage2.Controls.Add(this.lblLiquidacion);
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.dtpConvenio);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnImprimir);
            this.tabPage2.Controls.Add(this.txtSelectionName);
            this.tabPage2.Controls.Add(this.lblCurrentSelelction);
            this.tabPage2.Controls.Add(this.cmbCompañia);
            this.tabPage2.Controls.Add(this.dtpInicio);
            this.tabPage2.Controls.Add(this.dtpFin);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnGuardarSeleccion);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1188, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cuotas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(516, 542);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(356, 25);
            this.txtNotes.TabIndex = 20;
            this.txtNotes.Text = "Notas";
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Location = new System.Drawing.Point(160, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 27);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblLiquidacion
            // 
            this.lblLiquidacion.AutoSize = true;
            this.lblLiquidacion.Location = new System.Drawing.Point(123, 10);
            this.lblLiquidacion.Name = "lblLiquidacion";
            this.lblLiquidacion.Size = new System.Drawing.Size(16, 17);
            this.lblLiquidacion.TabIndex = 16;
            this.lblLiquidacion.Text = "#";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(9, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdCandidateFees);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdSelectedFees);
            this.splitContainer1.Size = new System.Drawing.Size(1173, 496);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 19;
            // 
            // grdCandidateFees
            // 
            this.grdCandidateFees.AllowUserToAddRows = false;
            this.grdCandidateFees.AllowUserToDeleteRows = false;
            this.grdCandidateFees.AllowUserToOrderColumns = true;
            this.grdCandidateFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCandidateFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCandidateFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCandidateFees.Location = new System.Drawing.Point(0, 0);
            this.grdCandidateFees.Margin = new System.Windows.Forms.Padding(15);
            this.grdCandidateFees.Name = "grdCandidateFees";
            this.grdCandidateFees.RowHeadersVisible = false;
            this.grdCandidateFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdCandidateFees.Size = new System.Drawing.Size(1173, 248);
            this.grdCandidateFees.TabIndex = 0;
            this.grdCandidateFees.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCandidateFees_CellContentDoubleClick);
            // 
            // grdSelectedFees
            // 
            this.grdSelectedFees.AllowUserToAddRows = false;
            this.grdSelectedFees.AllowUserToDeleteRows = false;
            this.grdSelectedFees.AllowUserToOrderColumns = true;
            this.grdSelectedFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSelectedFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSelectedFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSelectedFees.Location = new System.Drawing.Point(0, 0);
            this.grdSelectedFees.Margin = new System.Windows.Forms.Padding(15);
            this.grdSelectedFees.Name = "grdSelectedFees";
            this.grdSelectedFees.ReadOnly = true;
            this.grdSelectedFees.RowHeadersVisible = false;
            this.grdSelectedFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSelectedFees.Size = new System.Drawing.Size(1173, 244);
            this.grdSelectedFees.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Convenio:";
            // 
            // dtpConvenio
            // 
            this.dtpConvenio.Location = new System.Drawing.Point(527, 6);
            this.dtpConvenio.Name = "dtpConvenio";
            this.dtpConvenio.Size = new System.Drawing.Size(238, 25);
            this.dtpConvenio.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 547);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nueva Selección";
            // 
            // txtSelectionName
            // 
            this.txtSelectionName.Location = new System.Drawing.Point(122, 542);
            this.txtSelectionName.Name = "txtSelectionName";
            this.txtSelectionName.Size = new System.Drawing.Size(356, 25);
            this.txtSelectionName.TabIndex = 14;
            this.txtSelectionName.Click += new System.EventHandler(this.txtSelectionName_Click);
            this.txtSelectionName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSelectionName_KeyUp);
            // 
            // lblCurrentSelelction
            // 
            this.lblCurrentSelelction.AutoSize = true;
            this.lblCurrentSelelction.Location = new System.Drawing.Point(6, 10);
            this.lblCurrentSelelction.Name = "lblCurrentSelelction";
            this.lblCurrentSelelction.Size = new System.Drawing.Size(120, 17);
            this.lblCurrentSelelction.TabIndex = 12;
            this.lblCurrentSelelction.Text = "Cuotas Candidatas:";
            // 
            // cmbCompañia
            // 
            this.cmbCompañia.FormattingEnabled = true;
            this.cmbCompañia.Location = new System.Drawing.Point(225, 6);
            this.cmbCompañia.Name = "cmbCompañia";
            this.cmbCompañia.Size = new System.Drawing.Size(187, 25);
            this.cmbCompañia.TabIndex = 7;
            this.cmbCompañia.Text = "Compañía";
            this.cmbCompañia.SelectionChangeCommitted += new System.EventHandler(this.cmbCompañia_SelectionChangeCommitted);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(860, 6);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(103, 25);
            this.dtpInicio.TabIndex = 6;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Location = new System.Drawing.Point(1054, 6);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(110, 25);
            this.dtpFin.TabIndex = 8;
            this.dtpFin.CloseUp += new System.EventHandler(this.dtpFin_CloseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(810, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1008, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LiquidacionesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tbcLiquidationIndex);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1230, 640);
            this.Name = "LiquidacionesUserControl";
            this.Size = new System.Drawing.Size(1218, 640);
            ((System.ComponentModel.ISupportInitialize)(this.grdLiquidaciones)).EndInit();
            this.tbcLiquidationIndex.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFeeSelections)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCandidateFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSelectedFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdLiquidaciones;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnGuardarSeleccion;
        private System.Windows.Forms.TabControl tbcLiquidationIndex;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLiqNotes;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView grdSelectedFees;
        private System.Windows.Forms.TextBox txtSelectionName;
        private System.Windows.Forms.DataGridView grdFeeSelections;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLiquidacion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnSaveLiquidation;
        private System.Windows.Forms.Button btnDeleteLiquidation;
        private System.Windows.Forms.Button btnAgregarFeeSelection;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grdCandidateFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpConvenio;
        private System.Windows.Forms.Label lblCurrentSelelction;
        private System.Windows.Forms.ComboBox cmbCompañia;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnDeleteFeeSelection;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
