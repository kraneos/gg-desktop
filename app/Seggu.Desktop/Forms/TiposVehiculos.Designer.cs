namespace Seggu.Desktop.Forms
{
    partial class TiposVehiculos
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.useGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AdministrarUsosButton = new System.Windows.Forms.Button();
            this.AdministrarCarroceriasButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.useGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.Location = new System.Drawing.Point(358, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 27);
            this.btnEliminar.TabIndex = 89;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.Location = new System.Drawing.Point(673, 79);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 27);
            this.btnAgregar.TabIndex = 88;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 30);
            this.label2.TabIndex = 87;
            this.label2.Text = "TIPOS DE VEHICULOS:";
            // 
            // useGrid
            // 
            this.useGrid.AllowUserToOrderColumns = true;
            this.useGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.useGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.useGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.useGrid.Location = new System.Drawing.Point(12, 43);
            this.useGrid.Name = "useGrid";
            this.useGrid.ReadOnly = true;
            this.useGrid.RowHeadersVisible = false;
            this.useGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.useGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.useGrid.Size = new System.Drawing.Size(421, 449);
            this.useGrid.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Nombre";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Red;
            this.label46.Location = new System.Drawing.Point(522, 51);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(15, 20);
            this.label46.TabIndex = 85;
            this.label46.Text = "*";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(543, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(205, 20);
            this.txtNombre.TabIndex = 83;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(673, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 90;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdministrarUsosButton
            // 
            this.AdministrarUsosButton.Location = new System.Drawing.Point(442, 141);
            this.AdministrarUsosButton.Name = "AdministrarUsosButton";
            this.AdministrarUsosButton.Size = new System.Drawing.Size(139, 43);
            this.AdministrarUsosButton.TabIndex = 91;
            this.AdministrarUsosButton.Text = "Administrar Usos";
            this.AdministrarUsosButton.UseVisualStyleBackColor = true;
            this.AdministrarUsosButton.Click += new System.EventHandler(this.AdministrarUsos);
            // 
            // AdministrarCarroceriasButton
            // 
            this.AdministrarCarroceriasButton.Location = new System.Drawing.Point(610, 141);
            this.AdministrarCarroceriasButton.Name = "AdministrarCarroceriasButton";
            this.AdministrarCarroceriasButton.Size = new System.Drawing.Size(138, 43);
            this.AdministrarCarroceriasButton.TabIndex = 92;
            this.AdministrarCarroceriasButton.Text = "Administrar Carrocerias";
            this.AdministrarCarroceriasButton.UseVisualStyleBackColor = true;
            this.AdministrarCarroceriasButton.Click += new System.EventHandler(this.AdministrarCarrocerias);
            // 
            // TiposVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 504);
            this.Controls.Add(this.AdministrarCarroceriasButton);
            this.Controls.Add(this.AdministrarUsosButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.useGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.txtNombre);
            this.Name = "TiposVehiculos";
            this.Text = "Tipos de Vehiculos";
            ((System.ComponentModel.ISupportInitialize)(this.useGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView useGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AdministrarUsosButton;
        private System.Windows.Forms.Button AdministrarCarroceriasButton;
    }
}