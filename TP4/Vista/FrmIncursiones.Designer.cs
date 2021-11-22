
namespace Vista
{
    partial class FrmIncursiones
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
            this.dgvIncursiones = new System.Windows.Forms.DataGridView();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnBorrarTodo = new System.Windows.Forms.Button();
            this.cmbBoxColumnas = new System.Windows.Forms.ComboBox();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.cmbEscuadrones = new System.Windows.Forms.ComboBox();
            this.lblColumnas = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncursiones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncursiones
            // 
            this.dgvIncursiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncursiones.Location = new System.Drawing.Point(37, 75);
            this.dgvIncursiones.Name = "dgvIncursiones";
            this.dgvIncursiones.RowTemplate.Height = 25;
            this.dgvIncursiones.Size = new System.Drawing.Size(1041, 489);
            this.dgvIncursiones.TabIndex = 0;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(337, 571);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(158, 29);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar seleccionado";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnBorrarTodo
            // 
            this.btnBorrarTodo.Location = new System.Drawing.Point(606, 570);
            this.btnBorrarTodo.Name = "btnBorrarTodo";
            this.btnBorrarTodo.Size = new System.Drawing.Size(157, 30);
            this.btnBorrarTodo.TabIndex = 2;
            this.btnBorrarTodo.Text = "Borrar todo";
            this.btnBorrarTodo.UseVisualStyleBackColor = true;
            this.btnBorrarTodo.Click += new System.EventHandler(this.btnBorrarTodo_Click);
            // 
            // cmbBoxColumnas
            // 
            this.cmbBoxColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxColumnas.FormattingEnabled = true;
            this.cmbBoxColumnas.Location = new System.Drawing.Point(162, 38);
            this.cmbBoxColumnas.Name = "cmbBoxColumnas";
            this.cmbBoxColumnas.Size = new System.Drawing.Size(121, 23);
            this.cmbBoxColumnas.TabIndex = 3;
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(316, 38);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(121, 23);
            this.cmbCriterio.TabIndex = 4;
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(37, 22);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(102, 39);
            this.btnConsulta.TabIndex = 5;
            this.btnConsulta.Text = "Hacer consulta";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // cmbEscuadrones
            // 
            this.cmbEscuadrones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEscuadrones.FormattingEnabled = true;
            this.cmbEscuadrones.Location = new System.Drawing.Point(477, 38);
            this.cmbEscuadrones.Name = "cmbEscuadrones";
            this.cmbEscuadrones.Size = new System.Drawing.Size(140, 23);
            this.cmbEscuadrones.TabIndex = 7;
            // 
            // lblColumnas
            // 
            this.lblColumnas.AutoSize = true;
            this.lblColumnas.Location = new System.Drawing.Point(162, 16);
            this.lblColumnas.Name = "lblColumnas";
            this.lblColumnas.Size = new System.Drawing.Size(74, 15);
            this.lblColumnas.TabIndex = 8;
            this.lblColumnas.Text = "Ordenar por:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(316, 17);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(49, 15);
            this.lblCriterio.TabIndex = 9;
            this.lblCriterio.Text = "Criterio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtrar por Escuadron:";
            // 
            // FrmIncursiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 621);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblColumnas);
            this.Controls.Add(this.cmbEscuadrones);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.cmbBoxColumnas);
            this.Controls.Add(this.btnBorrarTodo);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dgvIncursiones);
            this.Name = "FrmIncursiones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Incursiones";
            this.Load += new System.EventHandler(this.FrmIncursiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncursiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncursiones;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnBorrarTodo;
        private System.Windows.Forms.ComboBox cmbBoxColumnas;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.ComboBox cmbEscuadrones;
        private System.Windows.Forms.Label lblColumnas;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label label1;
    }
}