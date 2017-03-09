namespace Seggu.Desktop.Forms
{
    partial class GestionarCarrocerias
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
            this.UsosExistentes = new System.Windows.Forms.ListBox();
            this.UsoDeTipoVehiculo = new System.Windows.Forms.ListBox();
            this.PonerButton = new System.Windows.Forms.Button();
            this.SacarButton = new System.Windows.Forms.Button();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsosExistentes
            // 
            this.UsosExistentes.FormattingEnabled = true;
            this.UsosExistentes.Location = new System.Drawing.Point(12, 33);
            this.UsosExistentes.Name = "UsosExistentes";
            this.UsosExistentes.Size = new System.Drawing.Size(187, 290);
            this.UsosExistentes.TabIndex = 0;
            // 
            // UsoDeTipoVehiculo
            // 
            this.UsoDeTipoVehiculo.FormattingEnabled = true;
            this.UsoDeTipoVehiculo.Location = new System.Drawing.Point(281, 33);
            this.UsoDeTipoVehiculo.Name = "UsoDeTipoVehiculo";
            this.UsoDeTipoVehiculo.Size = new System.Drawing.Size(187, 290);
            this.UsoDeTipoVehiculo.TabIndex = 1;
            // 
            // PonerButton
            // 
            this.PonerButton.Location = new System.Drawing.Point(216, 97);
            this.PonerButton.Name = "PonerButton";
            this.PonerButton.Size = new System.Drawing.Size(46, 39);
            this.PonerButton.TabIndex = 2;
            this.PonerButton.Text = ">";
            this.PonerButton.UseVisualStyleBackColor = true;
            this.PonerButton.Click += new System.EventHandler(this.PonerButton_Click);
            // 
            // SacarButton
            // 
            this.SacarButton.Location = new System.Drawing.Point(217, 167);
            this.SacarButton.Name = "SacarButton";
            this.SacarButton.Size = new System.Drawing.Size(46, 39);
            this.SacarButton.TabIndex = 3;
            this.SacarButton.Text = "<";
            this.SacarButton.UseVisualStyleBackColor = true;
            this.SacarButton.Click += new System.EventHandler(this.SacarButton_Click);
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(12, 329);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(187, 31);
            this.AceptarButton.TabIndex = 4;
            this.AceptarButton.Text = "ACEPTAR";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(281, 329);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(187, 31);
            this.CancelarButton.TabIndex = 5;
            this.CancelarButton.Text = "CANCELAR";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Carrocerias Existentes";
            // 
            // UseLabel
            // 
            this.UseLabel.AutoSize = true;
            this.UseLabel.Location = new System.Drawing.Point(278, 17);
            this.UseLabel.Name = "UseLabel";
            this.UseLabel.Size = new System.Drawing.Size(78, 13);
            this.UseLabel.TabIndex = 7;
            this.UseLabel.Text = "Carrocerias de ";
            // 
            // GestionarCarrocerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 372);
            this.ControlBox = false;
            this.Controls.Add(this.UseLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.SacarButton);
            this.Controls.Add(this.PonerButton);
            this.Controls.Add(this.UsoDeTipoVehiculo);
            this.Controls.Add(this.UsosExistentes);
            this.Name = "GestionarCarrocerias";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Gestionar Carrocerias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UsosExistentes;
        private System.Windows.Forms.ListBox UsoDeTipoVehiculo;
        private System.Windows.Forms.Button PonerButton;
        private System.Windows.Forms.Button SacarButton;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UseLabel;
    }
}