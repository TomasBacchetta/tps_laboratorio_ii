
namespace Vista
{
    partial class FrmCuartel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpbTropas = new System.Windows.Forms.GroupBox();
            this.btnEcharSoldado = new System.Windows.Forms.Button();
            this.btnModifSoldado = new System.Windows.Forms.Button();
            this.btnAgregarSoldado = new System.Windows.Forms.Button();
            this.lstbSoldados = new System.Windows.Forms.ListBox();
            this.gpbEscuadrones = new System.Windows.Forms.GroupBox();
            this.lblIntegrantesEscua = new System.Windows.Forms.Label();
            this.btnVaciarEscuadron = new System.Windows.Forms.Button();
            this.btnDesplegar = new System.Windows.Forms.Button();
            this.btnVerEscuadron = new System.Windows.Forms.Button();
            this.lstbEscuadrones = new System.Windows.Forms.ListBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.gpbSoldado = new System.Windows.Forms.GroupBox();
            this.lblNombreSoldado = new System.Windows.Forms.Label();
            this.ptbSoldado = new System.Windows.Forms.PictureBox();
            this.rtbDatosSoldado = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.gpbTropas.SuspendLayout();
            this.gpbEscuadrones.SuspendLayout();
            this.gpbSoldado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSoldado)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ayudaToolStripMenuItem.Text = "Informe";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // gpbTropas
            // 
            this.gpbTropas.Controls.Add(this.btnEcharSoldado);
            this.gpbTropas.Controls.Add(this.btnModifSoldado);
            this.gpbTropas.Controls.Add(this.btnAgregarSoldado);
            this.gpbTropas.Controls.Add(this.lstbSoldados);
            this.gpbTropas.Location = new System.Drawing.Point(357, 51);
            this.gpbTropas.Name = "gpbTropas";
            this.gpbTropas.Size = new System.Drawing.Size(200, 500);
            this.gpbTropas.TabIndex = 1;
            this.gpbTropas.TabStop = false;
            this.gpbTropas.Text = "Lista de Tropas";
            // 
            // btnEcharSoldado
            // 
            this.btnEcharSoldado.Location = new System.Drawing.Point(32, 447);
            this.btnEcharSoldado.Name = "btnEcharSoldado";
            this.btnEcharSoldado.Size = new System.Drawing.Size(129, 39);
            this.btnEcharSoldado.TabIndex = 5;
            this.btnEcharSoldado.Text = "Excusar soldado";
            this.btnEcharSoldado.UseVisualStyleBackColor = true;
            this.btnEcharSoldado.Click += new System.EventHandler(this.btnEcharSoldado_Click);
            // 
            // btnModifSoldado
            // 
            this.btnModifSoldado.Location = new System.Drawing.Point(32, 401);
            this.btnModifSoldado.Name = "btnModifSoldado";
            this.btnModifSoldado.Size = new System.Drawing.Size(129, 40);
            this.btnModifSoldado.TabIndex = 4;
            this.btnModifSoldado.Text = "Modificar Soldado";
            this.btnModifSoldado.UseVisualStyleBackColor = true;
            this.btnModifSoldado.Click += new System.EventHandler(this.btnModifSoldado_Click);
            // 
            // btnAgregarSoldado
            // 
            this.btnAgregarSoldado.Location = new System.Drawing.Point(32, 353);
            this.btnAgregarSoldado.Name = "btnAgregarSoldado";
            this.btnAgregarSoldado.Size = new System.Drawing.Size(129, 42);
            this.btnAgregarSoldado.TabIndex = 3;
            this.btnAgregarSoldado.Text = "Reclutar nuevo soldado";
            this.btnAgregarSoldado.UseVisualStyleBackColor = true;
            this.btnAgregarSoldado.Click += new System.EventHandler(this.btnAgregarSoldado_Click);
            // 
            // lstbSoldados
            // 
            this.lstbSoldados.FormattingEnabled = true;
            this.lstbSoldados.ItemHeight = 15;
            this.lstbSoldados.Location = new System.Drawing.Point(17, 28);
            this.lstbSoldados.Name = "lstbSoldados";
            this.lstbSoldados.Size = new System.Drawing.Size(160, 319);
            this.lstbSoldados.TabIndex = 0;
            this.lstbSoldados.SelectedIndexChanged += new System.EventHandler(this.lstbSoldados_SelectedIndexChanged);
            // 
            // gpbEscuadrones
            // 
            this.gpbEscuadrones.Controls.Add(this.lblIntegrantesEscua);
            this.gpbEscuadrones.Controls.Add(this.btnVaciarEscuadron);
            this.gpbEscuadrones.Controls.Add(this.btnDesplegar);
            this.gpbEscuadrones.Controls.Add(this.btnVerEscuadron);
            this.gpbEscuadrones.Controls.Add(this.lstbEscuadrones);
            this.gpbEscuadrones.Location = new System.Drawing.Point(673, 60);
            this.gpbEscuadrones.Name = "gpbEscuadrones";
            this.gpbEscuadrones.Size = new System.Drawing.Size(257, 491);
            this.gpbEscuadrones.TabIndex = 2;
            this.gpbEscuadrones.TabStop = false;
            this.gpbEscuadrones.Text = "Escuadrones";
            // 
            // lblIntegrantesEscua
            // 
            this.lblIntegrantesEscua.AutoSize = true;
            this.lblIntegrantesEscua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIntegrantesEscua.Location = new System.Drawing.Point(38, 286);
            this.lblIntegrantesEscua.Name = "lblIntegrantesEscua";
            this.lblIntegrantesEscua.Size = new System.Drawing.Size(40, 15);
            this.lblIntegrantesEscua.TabIndex = 5;
            this.lblIntegrantesEscua.Text = "label1";
            // 
            // btnVaciarEscuadron
            // 
            this.btnVaciarEscuadron.Location = new System.Drawing.Point(64, 430);
            this.btnVaciarEscuadron.Name = "btnVaciarEscuadron";
            this.btnVaciarEscuadron.Size = new System.Drawing.Size(139, 47);
            this.btnVaciarEscuadron.TabIndex = 4;
            this.btnVaciarEscuadron.Text = "Vaciar Escuadrón";
            this.btnVaciarEscuadron.UseVisualStyleBackColor = true;
            this.btnVaciarEscuadron.Click += new System.EventHandler(this.btnVaciarEscuadron_Click);
            // 
            // btnDesplegar
            // 
            this.btnDesplegar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDesplegar.Location = new System.Drawing.Point(75, 40);
            this.btnDesplegar.Name = "btnDesplegar";
            this.btnDesplegar.Size = new System.Drawing.Size(118, 39);
            this.btnDesplegar.TabIndex = 3;
            this.btnDesplegar.Text = "Desplegar en la Zona";
            this.btnDesplegar.UseVisualStyleBackColor = true;
            this.btnDesplegar.Click += new System.EventHandler(this.btnDesplegar_Click);
            // 
            // btnVerEscuadron
            // 
            this.btnVerEscuadron.Location = new System.Drawing.Point(64, 369);
            this.btnVerEscuadron.Name = "btnVerEscuadron";
            this.btnVerEscuadron.Size = new System.Drawing.Size(139, 46);
            this.btnVerEscuadron.TabIndex = 1;
            this.btnVerEscuadron.Text = "Ver Escuadrón";
            this.btnVerEscuadron.UseVisualStyleBackColor = true;
            this.btnVerEscuadron.Click += new System.EventHandler(this.btnVerEscuadron_Click);
            // 
            // lstbEscuadrones
            // 
            this.lstbEscuadrones.FormattingEnabled = true;
            this.lstbEscuadrones.ItemHeight = 15;
            this.lstbEscuadrones.Location = new System.Drawing.Point(18, 99);
            this.lstbEscuadrones.Name = "lstbEscuadrones";
            this.lstbEscuadrones.Size = new System.Drawing.Size(222, 169);
            this.lstbEscuadrones.TabIndex = 0;
            this.lstbEscuadrones.SelectedIndexChanged += new System.EventHandler(this.lstbEscuadrones_SelectedIndexChanged);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(576, 219);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(72, 36);
            this.btnAsignar.TabIndex = 3;
            this.btnAsignar.Text = "Asignar ->";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // gpbSoldado
            // 
            this.gpbSoldado.Controls.Add(this.lblNombreSoldado);
            this.gpbSoldado.Controls.Add(this.ptbSoldado);
            this.gpbSoldado.Controls.Add(this.rtbDatosSoldado);
            this.gpbSoldado.Location = new System.Drawing.Point(24, 51);
            this.gpbSoldado.Name = "gpbSoldado";
            this.gpbSoldado.Size = new System.Drawing.Size(318, 405);
            this.gpbSoldado.TabIndex = 4;
            this.gpbSoldado.TabStop = false;
            this.gpbSoldado.Text = "Soldado";
            // 
            // lblNombreSoldado
            // 
            this.lblNombreSoldado.AutoSize = true;
            this.lblNombreSoldado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombreSoldado.Location = new System.Drawing.Point(20, 37);
            this.lblNombreSoldado.Name = "lblNombreSoldado";
            this.lblNombreSoldado.Size = new System.Drawing.Size(57, 21);
            this.lblNombreSoldado.TabIndex = 2;
            this.lblNombreSoldado.Text = "label1";
            // 
            // ptbSoldado
            // 
            this.ptbSoldado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbSoldado.Location = new System.Drawing.Point(189, 22);
            this.ptbSoldado.Name = "ptbSoldado";
            this.ptbSoldado.Size = new System.Drawing.Size(110, 101);
            this.ptbSoldado.TabIndex = 1;
            this.ptbSoldado.TabStop = false;
            // 
            // rtbDatosSoldado
            // 
            this.rtbDatosSoldado.Location = new System.Drawing.Point(20, 129);
            this.rtbDatosSoldado.Name = "rtbDatosSoldado";
            this.rtbDatosSoldado.ReadOnly = true;
            this.rtbDatosSoldado.Size = new System.Drawing.Size(279, 236);
            this.rtbDatosSoldado.TabIndex = 0;
            this.rtbDatosSoldado.Text = "";
            // 
            // FrmCuartel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Vista.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 563);
            this.Controls.Add(this.gpbSoldado);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.gpbEscuadrones);
            this.Controls.Add(this.gpbTropas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCuartel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuartel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpbTropas.ResumeLayout(false);
            this.gpbEscuadrones.ResumeLayout(false);
            this.gpbEscuadrones.PerformLayout();
            this.gpbSoldado.ResumeLayout(false);
            this.gpbSoldado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSoldado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.GroupBox gpbTropas;
        private System.Windows.Forms.ListBox lstbSoldados;
        private System.Windows.Forms.Button btnAgregarSoldado;
        private System.Windows.Forms.Button btnEcharSoldado;
        private System.Windows.Forms.Button btnModifSoldado;
        private System.Windows.Forms.GroupBox gpbEscuadrones;
        private System.Windows.Forms.ListBox lstbEscuadrones;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnVerEscuadron;
        private System.Windows.Forms.GroupBox gpbSoldado;
        private System.Windows.Forms.PictureBox ptbSoldado;
        private System.Windows.Forms.RichTextBox rtbDatosSoldado;
        private System.Windows.Forms.Button btnDesplegar;
        private System.Windows.Forms.Button btnVaciarEscuadron;
        private System.Windows.Forms.Label lblNombreSoldado;
        private System.Windows.Forms.Label lblIntegrantesEscua;
    }
}