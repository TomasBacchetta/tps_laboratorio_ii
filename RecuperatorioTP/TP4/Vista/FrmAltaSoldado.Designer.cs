
namespace Vista
{
    partial class FrmAltaSoldado
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
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.txtbApellido = new System.Windows.Forms.TextBox();
            this.gpbClase = new System.Windows.Forms.GroupBox();
            this.rbReconocimiento = new System.Windows.Forms.RadioButton();
            this.rbMedico = new System.Windows.Forms.RadioButton();
            this.rbTecnico = new System.Windows.Forms.RadioButton();
            this.rbAsalto = new System.Windows.Forms.RadioButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.cmbRango = new System.Windows.Forms.ComboBox();
            this.lblRango = new System.Windows.Forms.Label();
            this.btnReclutar = new System.Windows.Forms.Button();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtbDocumento = new System.Windows.Forms.TextBox();
            this.gpbClase.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(114, 36);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(269, 23);
            this.txtbNombre.TabIndex = 0;
            this.txtbNombre.Tag = "Nombre";
            // 
            // txtbApellido
            // 
            this.txtbApellido.Location = new System.Drawing.Point(114, 81);
            this.txtbApellido.Name = "txtbApellido";
            this.txtbApellido.Size = new System.Drawing.Size(269, 23);
            this.txtbApellido.TabIndex = 1;
            this.txtbApellido.Tag = "Apellido";
            // 
            // gpbClase
            // 
            this.gpbClase.Controls.Add(this.rbReconocimiento);
            this.gpbClase.Controls.Add(this.rbMedico);
            this.gpbClase.Controls.Add(this.rbTecnico);
            this.gpbClase.Controls.Add(this.rbAsalto);
            this.gpbClase.Location = new System.Drawing.Point(74, 232);
            this.gpbClase.Name = "gpbClase";
            this.gpbClase.Size = new System.Drawing.Size(267, 107);
            this.gpbClase.TabIndex = 4;
            this.gpbClase.TabStop = false;
            this.gpbClase.Tag = "Clase";
            this.gpbClase.Text = "Clase";
            // 
            // rbReconocimiento
            // 
            this.rbReconocimiento.AutoSize = true;
            this.rbReconocimiento.Location = new System.Drawing.Point(148, 67);
            this.rbReconocimiento.Name = "rbReconocimiento";
            this.rbReconocimiento.Size = new System.Drawing.Size(112, 19);
            this.rbReconocimiento.TabIndex = 3;
            this.rbReconocimiento.TabStop = true;
            this.rbReconocimiento.Text = "Reconocimiento";
            this.rbReconocimiento.UseVisualStyleBackColor = true;
            // 
            // rbMedico
            // 
            this.rbMedico.AutoSize = true;
            this.rbMedico.Location = new System.Drawing.Point(17, 67);
            this.rbMedico.Name = "rbMedico";
            this.rbMedico.Size = new System.Drawing.Size(65, 19);
            this.rbMedico.TabIndex = 2;
            this.rbMedico.TabStop = true;
            this.rbMedico.Text = "Médico";
            this.rbMedico.UseVisualStyleBackColor = true;
            // 
            // rbTecnico
            // 
            this.rbTecnico.AutoSize = true;
            this.rbTecnico.Location = new System.Drawing.Point(148, 33);
            this.rbTecnico.Name = "rbTecnico";
            this.rbTecnico.Size = new System.Drawing.Size(65, 19);
            this.rbTecnico.TabIndex = 1;
            this.rbTecnico.TabStop = true;
            this.rbTecnico.Text = "Técnico";
            this.rbTecnico.UseVisualStyleBackColor = true;
            // 
            // rbAsalto
            // 
            this.rbAsalto.AutoSize = true;
            this.rbAsalto.Location = new System.Drawing.Point(17, 33);
            this.rbAsalto.Name = "rbAsalto";
            this.rbAsalto.Size = new System.Drawing.Size(58, 19);
            this.rbAsalto.TabIndex = 0;
            this.rbAsalto.TabStop = true;
            this.rbAsalto.Text = "Asalto";
            this.rbAsalto.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(34, 36);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(34, 81);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(34, 131);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(119, 15);
            this.lblFechaNac.TabIndex = 6;
            this.lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // cmbRango
            // 
            this.cmbRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRango.FormattingEnabled = true;
            this.cmbRango.Location = new System.Drawing.Point(191, 365);
            this.cmbRango.Name = "cmbRango";
            this.cmbRango.Size = new System.Drawing.Size(121, 23);
            this.cmbRango.TabIndex = 6;
            this.cmbRango.Tag = "Rango";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(122, 368);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(41, 15);
            this.lblRango.TabIndex = 8;
            this.lblRango.Text = "Rango";
            // 
            // btnReclutar
            // 
            this.btnReclutar.Location = new System.Drawing.Point(114, 408);
            this.btnReclutar.Name = "btnReclutar";
            this.btnReclutar.Size = new System.Drawing.Size(117, 39);
            this.btnReclutar.TabIndex = 7;
            this.btnReclutar.Text = "Reclutar";
            this.btnReclutar.UseVisualStyleBackColor = true;
            this.btnReclutar.Click += new System.EventHandler(this.btnReclutar_Click);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(34, 175);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(70, 15);
            this.lblDocumento.TabIndex = 10;
            this.lblDocumento.Text = "Documento";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(159, 128);
            this.dtpFechaNac.MaxDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(224, 23);
            this.dtpFechaNac.TabIndex = 12;
            this.dtpFechaNac.Value = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            // 
            // txtbDocumento
            // 
            this.txtbDocumento.Location = new System.Drawing.Point(143, 172);
            this.txtbDocumento.Name = "txtbDocumento";
            this.txtbDocumento.Size = new System.Drawing.Size(240, 23);
            this.txtbDocumento.TabIndex = 3;
            this.txtbDocumento.Tag = "Documento";
            // 
            // FrmAltaSoldado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 467);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.txtbDocumento);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.btnReclutar);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.cmbRango);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.gpbClase);
            this.Controls.Add(this.txtbApellido);
            this.Controls.Add(this.txtbNombre);
            this.Name = "FrmAltaSoldado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de soldado";
            this.gpbClase.ResumeLayout(false);
            this.gpbClase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.TextBox txtbApellido;
        private System.Windows.Forms.GroupBox gpbClase;
        private System.Windows.Forms.RadioButton rbReconocimiento;
        private System.Windows.Forms.RadioButton rbMedico;
        private System.Windows.Forms.RadioButton rbTecnico;
        private System.Windows.Forms.RadioButton rbAsalto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.ComboBox cmbRango;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.Button btnReclutar;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtbDocumento;
    }
}