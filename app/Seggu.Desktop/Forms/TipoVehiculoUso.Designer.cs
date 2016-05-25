namespace Seggu.Desktop.Forms
{
    partial class TipoVehiculoUso
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
            this.label2 = new System.Windows.Forms.Label();
            this.useGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.vehicleTypeGrid = new System.Windows.Forms.DataGridView();
            this.vehicleTypeUseGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.useGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTypeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTypeUseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 30);
            this.label2.TabIndex = 82;
            this.label2.Text = "USOS:";
            // 
            // useGrid
            // 
            this.useGrid.AllowUserToOrderColumns = true;
            this.useGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.useGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.useGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.useGrid.Location = new System.Drawing.Point(14, 47);
            this.useGrid.Name = "useGrid";
            this.useGrid.ReadOnly = true;
            this.useGrid.RowHeadersVisible = false;
            this.useGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.useGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.useGrid.Size = new System.Drawing.Size(283, 517);
            this.useGrid.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 30);
            this.label1.TabIndex = 89;
            this.label1.Text = "TIPOS DE VEHICULOS:";
            // 
            // vehicleTypeGrid
            // 
            this.vehicleTypeGrid.AllowUserToOrderColumns = true;
            this.vehicleTypeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vehicleTypeGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.vehicleTypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleTypeGrid.Location = new System.Drawing.Point(304, 47);
            this.vehicleTypeGrid.Name = "vehicleTypeGrid";
            this.vehicleTypeGrid.ReadOnly = true;
            this.vehicleTypeGrid.RowHeadersVisible = false;
            this.vehicleTypeGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.vehicleTypeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehicleTypeGrid.Size = new System.Drawing.Size(325, 517);
            this.vehicleTypeGrid.TabIndex = 88;
            // 
            // vehicleTypeUseGrid
            // 
            this.vehicleTypeUseGrid.AllowUserToOrderColumns = true;
            this.vehicleTypeUseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vehicleTypeUseGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.vehicleTypeUseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehicleTypeUseGrid.Location = new System.Drawing.Point(637, 47);
            this.vehicleTypeUseGrid.Name = "vehicleTypeUseGrid";
            this.vehicleTypeUseGrid.ReadOnly = true;
            this.vehicleTypeUseGrid.RowHeadersVisible = false;
            this.vehicleTypeUseGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.vehicleTypeUseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehicleTypeUseGrid.Size = new System.Drawing.Size(330, 517);
            this.vehicleTypeUseGrid.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(631, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 30);
            this.label3.TabIndex = 91;
            this.label3.Text = "RELACIONES:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.Location = new System.Drawing.Point(714, 570);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 31);
            this.btnEliminar.TabIndex = 93;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSize = true;
            this.btnAgregar.Location = new System.Drawing.Point(254, 571);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 31);
            this.btnAgregar.TabIndex = 92;
            this.btnAgregar.Text = "Asignar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // TipoVehiculoUso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 615);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.vehicleTypeUseGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vehicleTypeGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.useGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TipoVehiculoUso";
            this.Text = "TipoVehiculoUso";
            ((System.ComponentModel.ISupportInitialize)(this.useGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTypeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleTypeUseGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView useGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView vehicleTypeGrid;
        private System.Windows.Forms.DataGridView vehicleTypeUseGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
    }
}