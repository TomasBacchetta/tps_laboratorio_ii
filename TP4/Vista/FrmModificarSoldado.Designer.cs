
namespace Vista
{
    partial class FrmModificarSoldado
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.gpbClase = new System.Windows.Forms.GroupBox();
            this.rbReconocimiento = new System.Windows.Forms.RadioButton();
            this.rbMedico = new System.Windows.Forms.RadioButton();
            this.rbTecnico = new System.Windows.Forms.RadioButton();
            this.rbAsalto = new System.Windows.Forms.RadioButton();
            this.cmbRango = new System.Windows.Forms.ComboBox();
            this.lblRango = new System.Windows.Forms.Label();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.txtbApellido = new System.Windows.Forms.TextBox();
            this.txtbDocumento = new System.Windows.Forms.TextBox();
            this.btnEstablecer = new System.Windows.Forms.Button();
            this.lblArma = new System.Windows.Forms.Label();
            this.lblArmaSeleccionada = new System.Windows.Forms.Label();
            this.btnCambiarArma = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.gpbClase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(67, 67);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(67, 112);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(67, 159);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(70, 15);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "Documento";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(67, 205);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(119, 15);
            this.lblFechaNac.TabIndex = 3;
            this.lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // gpbClase
            // 
            this.gpbClase.Controls.Add(this.rbReconocimiento);
            this.gpbClase.Controls.Add(this.rbMedico);
            this.gpbClase.Controls.Add(this.rbTecnico);
            this.gpbClase.Controls.Add(this.rbAsalto);
            this.gpbClase.Location = new System.Drawing.Point(67, 237);
            this.gpbClase.Name = "gpbClase";
            this.gpbClase.Size = new System.Drawing.Size(267, 107);
            this.gpbClase.TabIndex = 5;
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
            this.rbReconocimiento.Tag = "Reconocimiento";
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
            this.rbMedico.Tag = "Medico";
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
            this.rbTecnico.Tag = "Tecnico";
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
            this.rbAsalto.Tag = "Asalto";
            this.rbAsalto.Text = "Asalto";
            this.rbAsalto.UseVisualStyleBackColor = true;
            // 
            // cmbRango
            // 
            this.cmbRango.FormattingEnabled = true;
            this.cmbRango.Location = new System.Drawing.Point(186, 392);
            this.cmbRango.Name = "cmbRango";
            this.cmbRango.Size = new System.Drawing.Size(121, 23);
            this.cmbRango.TabIndex = 7;
            this.cmbRango.Tag = "Rango";
            this.cmbRango.Text = "Seleccione";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.Location = new System.Drawing.Point(134, 395);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(41, 15);
            this.lblRango.TabIndex = 8;
            this.lblRango.Text = "Rango";
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(196, 64);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(220, 23);
            this.txtbNombre.TabIndex = 9;
            // 
            // txtbApellido
            // 
            this.txtbApellido.Location = new System.Drawing.Point(196, 109);
            this.txtbApellido.Name = "txtbApellido";
            this.txtbApellido.Size = new System.Drawing.Size(220, 23);
            this.txtbApellido.TabIndex = 10;
            // 
            // txtbDocumento
            // 
            this.txtbDocumento.Location = new System.Drawing.Point(196, 156);
            this.txtbDocumento.Name = "txtbDocumento";
            this.txtbDocumento.Size = new System.Drawing.Size(220, 23);
            this.txtbDocumento.TabIndex = 11;
            // 
            // btnEstablecer
            // 
            this.btnEstablecer.Location = new System.Drawing.Point(94, 508);
            this.btnEstablecer.Name = "btnEstablecer";
            this.btnEstablecer.Size = new System.Drawing.Size(92, 28);
            this.btnEstablecer.TabIndex = 13;
            this.btnEstablecer.Text = "Establecer atributos";
            this.btnEstablecer.UseVisualStyleBackColor = true;
            this.btnEstablecer.Click += new System.EventHandler(this.btnEstablecer_Click);
            // 
            // lblArma
            // 
            this.lblArma.AutoSize = true;
            this.lblArma.Location = new System.Drawing.Point(98, 455);
            this.lblArma.Name = "lblArma";
            this.lblArma.Size = new System.Drawing.Size(39, 15);
            this.lblArma.TabIndex = 14;
            this.lblArma.Text = "Arma:";
            // 
            // lblArmaSeleccionada
            // 
            this.lblArmaSeleccionada.AutoSize = true;
            this.lblArmaSeleccionada.Location = new System.Drawing.Point(147, 455);
            this.lblArmaSeleccionada.Name = "lblArmaSeleccionada";
            this.lblArmaSeleccionada.Size = new System.Drawing.Size(0, 15);
            this.lblArmaSeleccionada.TabIndex = 15;
            // 
            // btnCambiarArma
            // 
            this.btnCambiarArma.Location = new System.Drawing.Point(215, 451);
            this.btnCambiarArma.Name = "btnCambiarArma";
            this.btnCambiarArma.Size = new System.Drawing.Size(112, 23);
            this.btnCambiarArma.TabIndex = 16;
            this.btnCambiarArma.Text = "Cambiar Arma";
            this.btnCambiarArma.UseVisualStyleBackColor = true;
            this.btnCambiarArma.Click += new System.EventHandler(this.btnCambiarArma_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(215, 508);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(92, 28);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Location = new System.Drawing.Point(192, 199);
            this.dtpFechaNac.MaxDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(224, 23);
            this.dtpFechaNac.TabIndex = 18;
            this.dtpFechaNac.Value = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            // 
            // FrmModificarSoldado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 578);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCambiarArma);
            this.Controls.Add(this.lblArmaSeleccionada);
            this.Controls.Add(this.lblArma);
            this.Controls.Add(this.btnEstablecer);
            this.Controls.Add(this.txtbDocumento);
            this.Controls.Add(this.txtbApellido);
            this.Controls.Add(this.txtbNombre);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.cmbRango);
            this.Controls.Add(this.gpbClase);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarSoldado";
            this.Text = "Modificar Soldado";
            this.gpbClase.ResumeLayout(false);
            this.gpbClase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.GroupBox gpbClase;
        private System.Windows.Forms.RadioButton rbReconocimiento;
        private System.Windows.Forms.RadioButton rbMedico;
        private System.Windows.Forms.RadioButton rbTecnico;
        private System.Windows.Forms.RadioButton rbAsalto;
        private System.Windows.Forms.ComboBox cmbRango;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.TextBox txtbApellido;
        private System.Windows.Forms.TextBox txtbDocumento;
        private System.Windows.Forms.Button btnEstablecer;
        private System.Windows.Forms.Label lblArma;
        private System.Windows.Forms.Label lblArmaSeleccionada;
        private System.Windows.Forms.Button btnCambiarArma;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
    }
}