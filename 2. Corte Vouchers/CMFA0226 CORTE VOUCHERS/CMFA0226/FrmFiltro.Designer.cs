namespace CMFA0226
{
    partial class FrmFiltro
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label sucursalLabel;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFiltro));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblExecutable = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblSeparador1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblGrupo = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblUsuarioexee = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImprimecheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clsVouchersComboBox = new System.Windows.Forms.ComboBox();
            this.clsVouchersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btngenerar = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            sucursalLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clsVouchersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sucursalLabel
            // 
            sucursalLabel.AutoSize = true;
            sucursalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sucursalLabel.Location = new System.Drawing.Point(6, 61);
            sucursalLabel.Name = "sucursalLabel";
            sucursalLabel.Size = new System.Drawing.Size(30, 13);
            sucursalLabel.TabIndex = 42;
            sucursalLabel.Text = "Del:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(6, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 43;
            label3.Text = "Caja:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Navy;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblExecutable,
            this.slblSeparador1,
            this.slblUsuario,
            this.slblGrupo,
            this.slblFecha,
            this.toolStripStatusLabel2,
            this.tsslVersion,
            this.slblVersion,
            this.toolStripStatusLabel1,
            this.slblUsuarioexee});
            this.statusStrip1.Location = new System.Drawing.Point(0, 255);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 76;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblExecutable
            // 
            this.slblExecutable.ActiveLinkColor = System.Drawing.Color.White;
            this.slblExecutable.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblExecutable.ForeColor = System.Drawing.Color.White;
            this.slblExecutable.LinkColor = System.Drawing.Color.Black;
            this.slblExecutable.Name = "slblExecutable";
            this.slblExecutable.Size = new System.Drawing.Size(66, 17);
            this.slblExecutable.Text = "CMFA0226";
            this.slblExecutable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slblSeparador1
            // 
            this.slblSeparador1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblSeparador1.ForeColor = System.Drawing.Color.White;
            this.slblSeparador1.Name = "slblSeparador1";
            this.slblSeparador1.Size = new System.Drawing.Size(14, 17);
            this.slblSeparador1.Text = "|";
            // 
            // slblUsuario
            // 
            this.slblUsuario.ForeColor = System.Drawing.Color.White;
            this.slblUsuario.Name = "slblUsuario";
            this.slblUsuario.Size = new System.Drawing.Size(0, 17);
            // 
            // slblGrupo
            // 
            this.slblGrupo.ForeColor = System.Drawing.Color.White;
            this.slblGrupo.Name = "slblGrupo";
            this.slblGrupo.Size = new System.Drawing.Size(0, 17);
            // 
            // slblFecha
            // 
            this.slblFecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblFecha.ForeColor = System.Drawing.Color.White;
            this.slblFecha.Name = "slblFecha";
            this.slblFecha.Size = new System.Drawing.Size(0, 17);
            this.slblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslVersion
            // 
            this.tsslVersion.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslVersion.ForeColor = System.Drawing.Color.White;
            this.tsslVersion.Name = "tsslVersion";
            this.tsslVersion.Size = new System.Drawing.Size(0, 17);
            // 
            // slblVersion
            // 
            this.slblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblVersion.ForeColor = System.Drawing.Color.White;
            this.slblVersion.Name = "slblVersion";
            this.slblVersion.Size = new System.Drawing.Size(15, 17);
            this.slblVersion.Text = "0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // slblUsuarioexee
            // 
            this.slblUsuarioexee.ActiveLinkColor = System.Drawing.Color.White;
            this.slblUsuarioexee.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slblUsuarioexee.ForeColor = System.Drawing.Color.White;
            this.slblUsuarioexee.LinkColor = System.Drawing.Color.Black;
            this.slblUsuarioexee.Name = "slblUsuarioexee";
            this.slblUsuarioexee.Size = new System.Drawing.Size(0, 17);
            this.slblUsuarioexee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "CORTE DE VOUCHERS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ImprimecheckBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 146);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // ImprimecheckBox
            // 
            this.ImprimecheckBox.AutoSize = true;
            this.ImprimecheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImprimecheckBox.Location = new System.Drawing.Point(101, 122);
            this.ImprimecheckBox.Name = "ImprimecheckBox";
            this.ImprimecheckBox.Size = new System.Drawing.Size(90, 17);
            this.ImprimecheckBox.TabIndex = 40;
            this.ImprimecheckBox.Text = "En Reporte";
            this.ImprimecheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.clsVouchersComboBox);
            this.groupBox2.Controls.Add(sucursalLabel);
            this.groupBox2.Controls.Add(this.dtpFechaInicio);
            this.groupBox2.Location = new System.Drawing.Point(94, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // clsVouchersComboBox
            // 
            this.clsVouchersComboBox.DataSource = this.clsVouchersBindingSource;
            this.clsVouchersComboBox.DisplayMember = "DescripcionCaja";
            this.clsVouchersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clsVouchersComboBox.FormattingEnabled = true;
            this.clsVouchersComboBox.Location = new System.Drawing.Point(48, 19);
            this.clsVouchersComboBox.Name = "clsVouchersComboBox";
            this.clsVouchersComboBox.Size = new System.Drawing.Size(320, 21);
            this.clsVouchersComboBox.TabIndex = 39;
            this.clsVouchersComboBox.ValueMember = "Numcaja";
            // 
            // clsVouchersBindingSource
            // 
            this.clsVouchersBindingSource.DataSource = typeof(CMFA0226_BL.ClsVouchers);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(48, 54);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(245, 20);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(451, 184);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 40);
            this.btnSalir.TabIndex = 80;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btngenerar
            // 
            this.btngenerar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btngenerar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btngenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenerar.ForeColor = System.Drawing.Color.Black;
            this.btngenerar.Image = ((System.Drawing.Image)(resources.GetObject("btngenerar.Image")));
            this.btngenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngenerar.Location = new System.Drawing.Point(337, 184);
            this.btngenerar.Name = "btngenerar";
            this.btngenerar.Size = new System.Drawing.Size(105, 40);
            this.btngenerar.TabIndex = 79;
            this.btngenerar.Text = "GENERAR";
            this.btngenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngenerar.UseVisualStyleBackColor = true;
            this.btngenerar.Click += new System.EventHandler(this.btngenerar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 230);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(523, 19);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 81;
            this.progressBar1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 44);
            this.button1.TabIndex = 82;
            this.button1.Text = "PRUEBA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // FrmFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(570, 277);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btngenerar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmFiltro";
            this.Text = "Reporte Vouchers";
            this.Load += new System.EventHandler(this.FrmFiltro_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clsVouchersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblExecutable;
        private System.Windows.Forms.ToolStripStatusLabel slblSeparador1;
        private System.Windows.Forms.ToolStripStatusLabel slblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel slblGrupo;
        private System.Windows.Forms.ToolStripStatusLabel slblFecha;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslVersion;
        private System.Windows.Forms.ToolStripStatusLabel slblVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btngenerar;
        private System.Windows.Forms.ComboBox clsVouchersComboBox;
        private System.Windows.Forms.BindingSource clsVouchersBindingSource;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel slblUsuarioexee;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ImprimecheckBox;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

