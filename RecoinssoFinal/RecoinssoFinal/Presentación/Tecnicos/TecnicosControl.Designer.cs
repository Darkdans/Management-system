namespace RecoinssoFinal.Presentación.Tecnicos
{
    partial class TecnicosControl
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
            this.btnDetalle = new System.Windows.Forms.Button();
            this.dgvTecnicos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblInformación = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnDetalle.Enabled = false;
            this.btnDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnDetalle.FlatAppearance.BorderSize = 0;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDetalle.Location = new System.Drawing.Point(12, 300);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(134, 25);
            this.btnDetalle.TabIndex = 1;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // dgvTecnicos
            // 
            this.dgvTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTecnicos.Location = new System.Drawing.Point(12, 86);
            this.dgvTecnicos.Name = "dgvTecnicos";
            this.dgvTecnicos.Size = new System.Drawing.Size(404, 195);
            this.dgvTecnicos.TabIndex = 4;
            this.dgvTecnicos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Seleccionar);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(137)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregar.Location = new System.Drawing.Point(282, 300);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(134, 25);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(11, 7);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(36, 40);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "<";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // lblInformación
            // 
            this.lblInformación.AutoSize = true;
            this.lblInformación.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblInformación.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformación.Location = new System.Drawing.Point(168, 19);
            this.lblInformación.Name = "lblInformación";
            this.lblInformación.Size = new System.Drawing.Size(86, 20);
            this.lblInformación.TabIndex = 39;
            this.lblInformación.Text = "TÉCNICO";
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(427, 58);
            this.lblTop.TabIndex = 38;
            // 
            // TecnicosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 346);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dgvTecnicos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblInformación);
            this.Controls.Add(this.lblTop);
            this.Name = "TecnicosControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TecnicosControl";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTecnicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.DataGridView dgvTecnicos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblInformación;
        private System.Windows.Forms.Label lblTop;
    }
}