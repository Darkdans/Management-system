namespace RecoinssoFinal
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUser = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(550, 198);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(46, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario:";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(550, 268);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(64, 13);
            this.lblContraseña.TabIndex = 1;
            this.lblContraseña.Text = "Contraseña;";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(553, 328);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(205, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(553, 379);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(205, 23);
            this.btnNewUser.TabIndex = 3;
            this.btnNewUser.Text = "Crear cuenta nueva";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // txtUser
            // 
            this.txtUser.AcceptsTab = true;
            this.txtUser.Location = new System.Drawing.Point(553, 214);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(205, 20);
            this.txtUser.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsTab = true;
            this.txtPassword.Location = new System.Drawing.Point(553, 284);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(205, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciarSesion.Location = new System.Drawing.Point(553, 94);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(205, 72);
            this.lblIniciarSesion.TabIndex = 6;
            this.lblIniciarSesion.Text = "Iniciar Sesión";
            this.lblIniciarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RecoinssoFinal.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(513, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RecoinssoFinal.Properties.Resources.Portada;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(509, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(592, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 43);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reparaciones de computadoras e instalación y soporte de redes.";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblIniciarSesion);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.lblUser);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtUser;
    }
}

