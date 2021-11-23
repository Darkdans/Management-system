namespace RecoinssoFinal.Presentación.Servicios
{
    partial class ServiciosAlta
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblInformación = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SubpanelIzquierdo = new System.Windows.Forms.Panel();
            this.PictureFoto = new System.Windows.Forms.PictureBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SubpanelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(187)))), ((int)(((byte)(137)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnGuardar.Location = new System.Drawing.Point(359, 304);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(15);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 25);
            this.btnGuardar.TabIndex = 38;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblInformación
            // 
            this.lblInformación.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInformación.AutoSize = true;
            this.lblInformación.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.lblInformación.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformación.ForeColor = System.Drawing.Color.White;
            this.lblInformación.Location = new System.Drawing.Point(200, 18);
            this.lblInformación.Name = "lblInformación";
            this.lblInformación.Size = new System.Drawing.Size(189, 20);
            this.lblInformación.TabIndex = 48;
            this.lblInformación.Text = "ALTA  DEL SERVICIO";
            this.lblInformación.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(308, 46);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(250, 20);
            this.txtCosto.TabIndex = 35;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNombre.Location = new System.Drawing.Point(23, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 20);
            this.txtNombre.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 134);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.label3.Size = new System.Drawing.Size(81, 28);
            this.label3.TabIndex = 42;
            this.label3.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 40;
            this.label1.Text = "Nombre:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.lblInformación);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 53);
            this.panel1.TabIndex = 50;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SubpanelIzquierdo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 353);
            this.panel2.TabIndex = 51;
            // 
            // SubpanelIzquierdo
            // 
            this.SubpanelIzquierdo.Controls.Add(this.txtDias);
            this.SubpanelIzquierdo.Controls.Add(this.label2);
            this.SubpanelIzquierdo.Controls.Add(this.PictureFoto);
            this.SubpanelIzquierdo.Controls.Add(this.txtDescripcion);
            this.SubpanelIzquierdo.Controls.Add(this.btnAgregarImagen);
            this.SubpanelIzquierdo.Controls.Add(this.btnLimpiar);
            this.SubpanelIzquierdo.Controls.Add(this.btnGuardar);
            this.SubpanelIzquierdo.Controls.Add(this.label4);
            this.SubpanelIzquierdo.Controls.Add(this.label1);
            this.SubpanelIzquierdo.Controls.Add(this.txtNombre);
            this.SubpanelIzquierdo.Controls.Add(this.txtCosto);
            this.SubpanelIzquierdo.Controls.Add(this.label3);
            this.SubpanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.SubpanelIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.SubpanelIzquierdo.Name = "SubpanelIzquierdo";
            this.SubpanelIzquierdo.Size = new System.Drawing.Size(586, 353);
            this.SubpanelIzquierdo.TabIndex = 47;
            // 
            // PictureFoto
            // 
            this.PictureFoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureFoto.BackColor = System.Drawing.Color.White;
            this.PictureFoto.Location = new System.Drawing.Point(356, 89);
            this.PictureFoto.Name = "PictureFoto";
            this.PictureFoto.Size = new System.Drawing.Size(150, 150);
            this.PictureFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureFoto.TabIndex = 45;
            this.PictureFoto.TabStop = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(23, 165);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(250, 121);
            this.txtDescripcion.TabIndex = 48;
            this.txtDescripcion.Text = "";
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarImagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnAgregarImagen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnAgregarImagen.FlatAppearance.BorderSize = 0;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarImagen.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregarImagen.Location = new System.Drawing.Point(356, 249);
            this.btnAgregarImagen.Margin = new System.Windows.Forms.Padding(15);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(153, 25);
            this.btnAgregarImagen.TabIndex = 47;
            this.btnAgregarImagen.Text = "Examinar";
            this.btnAgregarImagen.UseVisualStyleBackColor = false;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(142)))), ((int)(((byte)(236)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnLimpiar.Location = new System.Drawing.Point(69, 304);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(15);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 25);
            this.btnLimpiar.TabIndex = 46;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(299, 15);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.label4.Size = new System.Drawing.Size(52, 28);
            this.label4.TabIndex = 43;
            this.label4.Text = "Costo:";
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(23, 111);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(250, 20);
            this.txtDias.TabIndex = 53;
            this.txtDias.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Tiempo (Días):";
            // 
            // ServiciosAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(586, 406);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiciosAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta del servicio";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.SubpanelIzquierdo.ResumeLayout(false);
            this.SubpanelIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblInformación;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.PictureBox PictureFoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel SubpanelIzquierdo;
        public System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        public System.Windows.Forms.TextBox txtDias;
        private System.Windows.Forms.Label label2;
    }
}