namespace RecoinssoFinal.Presentación.Clientes
{
    partial class ClientesControl
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
            this.lblInformación = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInformación
            // 
            this.lblInformación.AutoSize = true;
            this.lblInformación.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblInformación.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformación.Location = new System.Drawing.Point(168, 18);
            this.lblInformación.Name = "lblInformación";
            this.lblInformación.Size = new System.Drawing.Size(83, 20);
            this.lblInformación.TabIndex = 33;
            this.lblInformación.Text = "CLIENTE";
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTop.Location = new System.Drawing.Point(0, -1);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(427, 58);
            this.lblTop.TabIndex = 32;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(11, 6);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(36, 40);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "<";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(137)))));
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregar.Location = new System.Drawing.Point(282, 299);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(134, 25);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(12, 85);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.Size = new System.Drawing.Size(404, 195);
            this.dgvClientes.TabIndex = 4;
            this.dgvClientes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Seleccionar);
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
            this.btnDetalle.Location = new System.Drawing.Point(12, 299);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(134, 25);
            this.btnDetalle.TabIndex = 2;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // ClientesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 347);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.lblInformación);
            this.Controls.Add(this.lblTop);
            this.Name = "ClientesControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientesControl";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInformación;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnDetalle;
    }
}