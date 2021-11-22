
namespace Vista
{
    partial class FrmMapa
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
            this.btnDesplegar = new System.Windows.Forms.Button();
            this.rdbPuestoAvanz = new System.Windows.Forms.RadioButton();
            this.rdbAldea = new System.Windows.Forms.RadioButton();
            this.rdbCampBand = new System.Windows.Forms.RadioButton();
            this.rdbGranja = new System.Windows.Forms.RadioButton();
            this.rdbLaboratorio = new System.Windows.Forms.RadioButton();
            this.rdbEstacionTren = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnDesplegar
            // 
            this.btnDesplegar.Location = new System.Drawing.Point(456, 519);
            this.btnDesplegar.Name = "btnDesplegar";
            this.btnDesplegar.Size = new System.Drawing.Size(123, 47);
            this.btnDesplegar.TabIndex = 0;
            this.btnDesplegar.Text = "Desplegar";
            this.btnDesplegar.UseVisualStyleBackColor = true;
            this.btnDesplegar.Click += new System.EventHandler(this.btnDesplegar_Click);
            // 
            // rdbPuestoAvanz
            // 
            this.rdbPuestoAvanz.AutoSize = true;
            this.rdbPuestoAvanz.Location = new System.Drawing.Point(190, 533);
            this.rdbPuestoAvanz.Name = "rdbPuestoAvanz";
            this.rdbPuestoAvanz.Size = new System.Drawing.Size(129, 19);
            this.rdbPuestoAvanz.TabIndex = 1;
            this.rdbPuestoAvanz.TabStop = true;
            this.rdbPuestoAvanz.Text = "Puesto de avanzada";
            this.rdbPuestoAvanz.UseVisualStyleBackColor = true;
            // 
            // rdbAldea
            // 
            this.rdbAldea.AutoSize = true;
            this.rdbAldea.Location = new System.Drawing.Point(84, 320);
            this.rdbAldea.Name = "rdbAldea";
            this.rdbAldea.Size = new System.Drawing.Size(55, 19);
            this.rdbAldea.TabIndex = 2;
            this.rdbAldea.TabStop = true;
            this.rdbAldea.Text = "Aldea";
            this.rdbAldea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdbAldea.UseVisualStyleBackColor = true;
            // 
            // rdbCampBand
            // 
            this.rdbCampBand.AutoSize = true;
            this.rdbCampBand.Location = new System.Drawing.Point(306, 36);
            this.rdbCampBand.Name = "rdbCampBand";
            this.rdbCampBand.Size = new System.Drawing.Size(145, 19);
            this.rdbCampBand.TabIndex = 3;
            this.rdbCampBand.TabStop = true;
            this.rdbCampBand.Tag = "";
            this.rdbCampBand.Text = "Campamento Bandido";
            this.rdbCampBand.UseVisualStyleBackColor = true;
            // 
            // rdbGranja
            // 
            this.rdbGranja.AutoSize = true;
            this.rdbGranja.Location = new System.Drawing.Point(163, 186);
            this.rdbGranja.Name = "rdbGranja";
            this.rdbGranja.Size = new System.Drawing.Size(59, 19);
            this.rdbGranja.TabIndex = 4;
            this.rdbGranja.TabStop = true;
            this.rdbGranja.Tag = "";
            this.rdbGranja.Text = "Granja";
            this.rdbGranja.UseVisualStyleBackColor = true;
            // 
            // rdbLaboratorio
            // 
            this.rdbLaboratorio.AutoSize = true;
            this.rdbLaboratorio.Location = new System.Drawing.Point(385, 268);
            this.rdbLaboratorio.Name = "rdbLaboratorio";
            this.rdbLaboratorio.Size = new System.Drawing.Size(153, 19);
            this.rdbLaboratorio.TabIndex = 5;
            this.rdbLaboratorio.TabStop = true;
            this.rdbLaboratorio.Tag = "";
            this.rdbLaboratorio.Text = "Laboratorio Subterráneo";
            this.rdbLaboratorio.UseVisualStyleBackColor = true;
            // 
            // rdbEstacionTren
            // 
            this.rdbEstacionTren.AutoSize = true;
            this.rdbEstacionTren.Location = new System.Drawing.Point(318, 158);
            this.rdbEstacionTren.Name = "rdbEstacionTren";
            this.rdbEstacionTren.Size = new System.Drawing.Size(109, 19);
            this.rdbEstacionTren.TabIndex = 6;
            this.rdbEstacionTren.TabStop = true;
            this.rdbEstacionTren.Tag = "";
            this.rdbEstacionTren.Text = "Estación de tren";
            this.rdbEstacionTren.UseVisualStyleBackColor = true;
            // 
            // FrmMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.mapa;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(591, 578);
            this.ControlBox = false;
            this.Controls.Add(this.rdbEstacionTren);
            this.Controls.Add(this.rdbLaboratorio);
            this.Controls.Add(this.rdbGranja);
            this.Controls.Add(this.rdbCampBand);
            this.Controls.Add(this.rdbAldea);
            this.Controls.Add(this.rdbPuestoAvanz);
            this.Controls.Add(this.btnDesplegar);
            this.MaximizeBox = false;
            this.Name = "FrmMapa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione ubicación de despliegue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDesplegar;
        private System.Windows.Forms.RadioButton rdbPuestoAvanz;
        private System.Windows.Forms.RadioButton rdbAldea;
        private System.Windows.Forms.RadioButton rdbCampBand;
        private System.Windows.Forms.RadioButton rdbGranja;
        private System.Windows.Forms.RadioButton rdbLaboratorio;
        private System.Windows.Forms.RadioButton rdbEstacionTren;
    }
}