
namespace WFERPMapco.Formas.Mensajes
{
    partial class Mensaje
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
            this.components = new System.ComponentModel.Container();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.ipcIcon = new FontAwesome.Sharp.IconPictureBox();
            this.timeout = new System.Windows.Forms.Timer(this.components);
            this.tickProgress = new System.Windows.Forms.Timer(this.components);
            this.pnlbar = new System.Windows.Forms.Panel();
            this.timerclose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipcIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(39, 9);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(279, 73);
            this.lblMensaje.TabIndex = 5;
            this.lblMensaje.Text = "SE GUARDO CORRECTAMENTE";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMensaje.Click += new System.EventHandler(this.lblMensaje_Click);
            this.lblMensaje.MouseHover += new System.EventHandler(this.lblMensaje_MouseHover);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnCerrar.IconColor = System.Drawing.Color.White;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 19;
            this.btnCerrar.Location = new System.Drawing.Point(338, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(19, 22);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ipcIcon
            // 
            this.ipcIcon.BackColor = System.Drawing.Color.Transparent;
            this.ipcIcon.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.ipcIcon.IconColor = System.Drawing.Color.White;
            this.ipcIcon.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ipcIcon.Location = new System.Drawing.Point(1, 29);
            this.ipcIcon.Name = "ipcIcon";
            this.ipcIcon.Size = new System.Drawing.Size(32, 32);
            this.ipcIcon.TabIndex = 3;
            this.ipcIcon.TabStop = false;
            this.ipcIcon.Click += new System.EventHandler(this.ipcIcon_Click);
            this.ipcIcon.MouseHover += new System.EventHandler(this.ipcIcon_MouseHover);
            // 
            // timeout
            // 
            this.timeout.Enabled = true;
            this.timeout.Interval = 5000;
            this.timeout.Tick += new System.EventHandler(this.timeout_Tick);
            // 
            // tickProgress
            // 
            this.tickProgress.Enabled = true;
            this.tickProgress.Interval = 200;
            this.tickProgress.Tick += new System.EventHandler(this.tickProgress_Tick);
            // 
            // pnlbar
            // 
            this.pnlbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlbar.BackColor = System.Drawing.Color.LawnGreen;
            this.pnlbar.Location = new System.Drawing.Point(1, 85);
            this.pnlbar.Name = "pnlbar";
            this.pnlbar.Size = new System.Drawing.Size(10, 10);
            this.pnlbar.TabIndex = 7;
            this.pnlbar.Click += new System.EventHandler(this.pnlbar_Click);
            this.pnlbar.MouseHover += new System.EventHandler(this.pnlbar_MouseHover);
            // 
            // timerclose
            // 
            this.timerclose.Enabled = true;
            this.timerclose.Interval = 60000;
            this.timerclose.Tick += new System.EventHandler(this.timerclose_Tick);
            // 
            // Alerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(359, 91);
            this.Controls.Add(this.pnlbar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.ipcIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Alerta";
            this.Opacity = 0.9D;
            this.Text = "Alerta";
            this.Load += new System.EventHandler(this.Alerta_Load);
            this.Click += new System.EventHandler(this.Alerta_Click);
            this.MouseHover += new System.EventHandler(this.Alerta_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipcIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox ipcIcon;
        private System.Windows.Forms.Timer timeout;
        private System.Windows.Forms.Timer tickProgress;
        private System.Windows.Forms.Panel pnlbar;
        private System.Windows.Forms.Timer timerclose;
    }
}