namespace Seggu.Desktop.Forms
{
    partial class Productores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productores));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.chkCobrador = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.grdProductores = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.EhProducers = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditarProductor = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProductores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EhProducers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(447, 76);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(15);
            this.txtNombre.MaxLength = 40;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(264, 25);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(447, 138);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatricula.MaxLength = 9;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.ReadOnly = true;
            this.txtMatricula.Size = new System.Drawing.Size(264, 25);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress_1);
            // 
            // chkCobrador
            // 
            this.chkCobrador.AutoSize = true;
            this.chkCobrador.Enabled = false;
            this.chkCobrador.Location = new System.Drawing.Point(450, 182);
            this.chkCobrador.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCobrador.Name = "chkCobrador";
            this.chkCobrador.Size = new System.Drawing.Size(84, 21);
            this.chkCobrador.TabIndex = 2;
            this.chkCobrador.Text = "Cobrador";
            this.chkCobrador.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.Location = new System.Drawing.Point(636, 221);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 27);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grdProductores
            // 
            this.grdProductores.AllowUserToAddRows = false;
            this.grdProductores.AllowUserToDeleteRows = false;
            this.grdProductores.AllowUserToOrderColumns = true;
            this.grdProductores.AllowUserToResizeRows = false;
            this.grdProductores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdProductores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProductores.Location = new System.Drawing.Point(17, 54);
            this.grdProductores.Margin = new System.Windows.Forms.Padding(15);
            this.grdProductores.MultiSelect = false;
            this.grdProductores.Name = "grdProductores";
            this.grdProductores.ReadOnly = true;
            this.grdProductores.RowHeadersVisible = false;
            this.grdProductores.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdProductores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProductores.Size = new System.Drawing.Size(386, 428);
            this.grdProductores.TabIndex = 8;
            this.grdProductores.SelectionChanged += new System.EventHandler(this.grdProductores_SelectionChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = true;
            this.btnEditar.Location = new System.Drawing.Point(328, 14);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 27);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 30);
            this.label1.TabIndex = 25;
            this.label1.Text = "Productores";
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitar.Location = new System.Drawing.Point(542, 221);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 27);
            this.btnQuitar.TabIndex = 4;
            this.btnQuitar.Text = "Eliminar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNuevo.Location = new System.Drawing.Point(448, 221);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 27);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // EhProducers
            // 
            this.EhProducers.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.EhProducers.ContainerControl = this;
            this.EhProducers.RightToLeft = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Matrícula";
            // 
            // btnEditarProductor
            // 
            this.btnEditarProductor.AutoSize = true;
            this.btnEditarProductor.Location = new System.Drawing.Point(636, 221);
            this.btnEditarProductor.Name = "btnEditarProductor";
            this.btnEditarProductor.Size = new System.Drawing.Size(75, 27);
            this.btnEditarProductor.TabIndex = 5;
            this.btnEditarProductor.Text = "Editar";
            this.btnEditarProductor.UseVisualStyleBackColor = true;
            this.btnEditarProductor.Click += new System.EventHandler(this.btnEditarProductor_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Location = new System.Drawing.Point(447, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.Location = new System.Drawing.Point(636, 455);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 27);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Productores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(730, 506);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditarProductor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdProductores);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkCobrador);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtNombre);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Productores";
            this.Text = "Productores";
            ((System.ComponentModel.ISupportInitialize)(this.grdProductores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EhProducers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.CheckBox chkCobrador;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView grdProductores;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ErrorProvider EhProducers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditarProductor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
    }
}