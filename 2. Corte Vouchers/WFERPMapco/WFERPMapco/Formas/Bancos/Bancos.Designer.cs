namespace WFERPMapco.Formas.Bancos
{
    partial class Bancos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.btnCancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuardar = new Guna.UI2.WinForms.Guna2Button();
            this.txtComisionBancaria = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.chkCapturaManual = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkMapco = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkUsaTerminal = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cmbBancoContable = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomBanco = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdBanco = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridBancos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.idbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBancoContableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usaTerminalDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mapcoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comisionBancariaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capturaManualDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.estatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fechaInsertDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioInsertDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioBajaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.bancosEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guna2ContainerControl1.SuspendLayout();
            this.guna2ContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComisionBancaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(16)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Captura de Bancos";
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(16)))));
            this.guna2ContainerControl1.BorderThickness = 1;
            this.guna2ContainerControl1.Controls.Add(this.guna2ContainerControl2);
            this.guna2ContainerControl1.Controls.Add(this.gridBancos);
            this.guna2ContainerControl1.Location = new System.Drawing.Point(16, 36);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(770, 536);
            this.guna2ContainerControl1.TabIndex = 15;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(16)))));
            this.guna2ContainerControl2.BorderThickness = 1;
            this.guna2ContainerControl2.Controls.Add(this.btnCancelar);
            this.guna2ContainerControl2.Controls.Add(this.btnGuardar);
            this.guna2ContainerControl2.Controls.Add(this.txtComisionBancaria);
            this.guna2ContainerControl2.Controls.Add(this.chkCapturaManual);
            this.guna2ContainerControl2.Controls.Add(this.label5);
            this.guna2ContainerControl2.Controls.Add(this.chkMapco);
            this.guna2ContainerControl2.Controls.Add(this.chkUsaTerminal);
            this.guna2ContainerControl2.Controls.Add(this.cmbBancoContable);
            this.guna2ContainerControl2.Controls.Add(this.label3);
            this.guna2ContainerControl2.Controls.Add(this.txtNomBanco);
            this.guna2ContainerControl2.Controls.Add(this.label4);
            this.guna2ContainerControl2.Controls.Add(this.txtIdBanco);
            this.guna2ContainerControl2.Controls.Add(this.label2);
            this.guna2ContainerControl2.Location = new System.Drawing.Point(12, 14);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(744, 239);
            this.guna2ContainerControl2.TabIndex = 16;
            this.guna2ContainerControl2.Text = "guna2ContainerControl2";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(133)))));
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(453, 179);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 39);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(133)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(593, 179);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(134, 39);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtComisionBancaria
            // 
            this.txtComisionBancaria.BackColor = System.Drawing.Color.Transparent;
            this.txtComisionBancaria.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComisionBancaria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComisionBancaria.Location = new System.Drawing.Point(141, 133);
            this.txtComisionBancaria.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtComisionBancaria.Name = "txtComisionBancaria";
            this.txtComisionBancaria.Size = new System.Drawing.Size(90, 36);
            this.txtComisionBancaria.TabIndex = 3;
            this.txtComisionBancaria.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(165)))), ((int)(((byte)(16)))));
            // 
            // chkCapturaManual
            // 
            this.chkCapturaManual.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCapturaManual.CheckedState.BorderRadius = 0;
            this.chkCapturaManual.CheckedState.BorderThickness = 0;
            this.chkCapturaManual.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkCapturaManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkCapturaManual.Location = new System.Drawing.Point(593, 101);
            this.chkCapturaManual.Name = "chkCapturaManual";
            this.chkCapturaManual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCapturaManual.Size = new System.Drawing.Size(134, 30);
            this.chkCapturaManual.TabIndex = 6;
            this.chkCapturaManual.Text = ":Captura Manual";
            this.chkCapturaManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCapturaManual.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkCapturaManual.UncheckedState.BorderRadius = 0;
            this.chkCapturaManual.UncheckedState.BorderThickness = 0;
            this.chkCapturaManual.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Comisión Bancaria:";
            // 
            // chkMapco
            // 
            this.chkMapco.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkMapco.CheckedState.BorderRadius = 0;
            this.chkMapco.CheckedState.BorderThickness = 0;
            this.chkMapco.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkMapco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkMapco.Location = new System.Drawing.Point(593, 65);
            this.chkMapco.Name = "chkMapco";
            this.chkMapco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkMapco.Size = new System.Drawing.Size(134, 30);
            this.chkMapco.TabIndex = 5;
            this.chkMapco.Text = ":Mapco";
            this.chkMapco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMapco.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkMapco.UncheckedState.BorderRadius = 0;
            this.chkMapco.UncheckedState.BorderThickness = 0;
            this.chkMapco.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // chkUsaTerminal
            // 
            this.chkUsaTerminal.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkUsaTerminal.CheckedState.BorderRadius = 0;
            this.chkUsaTerminal.CheckedState.BorderThickness = 0;
            this.chkUsaTerminal.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chkUsaTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkUsaTerminal.Location = new System.Drawing.Point(593, 29);
            this.chkUsaTerminal.Name = "chkUsaTerminal";
            this.chkUsaTerminal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUsaTerminal.Size = new System.Drawing.Size(134, 30);
            this.chkUsaTerminal.TabIndex = 4;
            this.chkUsaTerminal.Text = ":Usa Terminal";
            this.chkUsaTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUsaTerminal.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkUsaTerminal.UncheckedState.BorderRadius = 0;
            this.chkUsaTerminal.UncheckedState.BorderThickness = 0;
            this.chkUsaTerminal.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cmbBancoContable
            // 
            this.cmbBancoContable.BackColor = System.Drawing.Color.Transparent;
            this.cmbBancoContable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBancoContable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBancoContable.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBancoContable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbBancoContable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbBancoContable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbBancoContable.ItemHeight = 30;
            this.cmbBancoContable.Location = new System.Drawing.Point(141, 49);
            this.cmbBancoContable.Name = "cmbBancoContable";
            this.cmbBancoContable.Size = new System.Drawing.Size(415, 36);
            this.cmbBancoContable.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Banco Contable:";
            // 
            // txtNomBanco
            // 
            this.txtNomBanco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNomBanco.DefaultText = "";
            this.txtNomBanco.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNomBanco.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNomBanco.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomBanco.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNomBanco.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomBanco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNomBanco.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNomBanco.Location = new System.Drawing.Point(141, 91);
            this.txtNomBanco.Name = "txtNomBanco";
            this.txtNomBanco.PasswordChar = '\0';
            this.txtNomBanco.PlaceholderText = "";
            this.txtNomBanco.SelectedText = "";
            this.txtNomBanco.Size = new System.Drawing.Size(415, 36);
            this.txtNomBanco.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre Banco:";
            // 
            // txtIdBanco
            // 
            this.txtIdBanco.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdBanco.DefaultText = "";
            this.txtIdBanco.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIdBanco.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIdBanco.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdBanco.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIdBanco.Enabled = false;
            this.txtIdBanco.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdBanco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIdBanco.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIdBanco.Location = new System.Drawing.Point(141, 7);
            this.txtIdBanco.Name = "txtIdBanco";
            this.txtIdBanco.PasswordChar = '\0';
            this.txtIdBanco.PlaceholderText = "";
            this.txtIdBanco.SelectedText = "";
            this.txtIdBanco.Size = new System.Drawing.Size(90, 36);
            this.txtIdBanco.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Id Banco:";
            // 
            // gridBancos
            // 
            this.gridBancos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.gridBancos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridBancos.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(133)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBancos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridBancos.ColumnHeadersHeight = 22;
            this.gridBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridBancos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbancoDataGridViewTextBoxColumn,
            this.idBancoContableDataGridViewTextBoxColumn,
            this.bancoDataGridViewTextBoxColumn,
            this.usaTerminalDataGridViewCheckBoxColumn,
            this.ordenDataGridViewTextBoxColumn,
            this.mapcoDataGridViewCheckBoxColumn,
            this.comisionBancariaDataGridViewTextBoxColumn,
            this.capturaManualDataGridViewCheckBoxColumn,
            this.estatusDataGridViewCheckBoxColumn,
            this.fechaInsertDataGridViewTextBoxColumn,
            this.fechaUpdateDataGridViewTextBoxColumn,
            this.fechaBajaDataGridViewTextBoxColumn,
            this.usuarioInsertDataGridViewTextBoxColumn,
            this.usuarioUpdateDataGridViewTextBoxColumn,
            this.usuarioBajaDataGridViewTextBoxColumn,
            this.Editar,
            this.Eliminar});
            this.gridBancos.DataSource = this.bancosEntityBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBancos.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridBancos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridBancos.Location = new System.Drawing.Point(12, 259);
            this.gridBancos.Name = "gridBancos";
            this.gridBancos.RowHeadersVisible = false;
            this.gridBancos.RowHeadersWidth = 51;
            this.gridBancos.Size = new System.Drawing.Size(744, 262);
            this.gridBancos.TabIndex = 9;
            this.gridBancos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gridBancos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gridBancos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gridBancos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gridBancos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gridBancos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gridBancos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridBancos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(133)))));
            this.gridBancos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridBancos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBancos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gridBancos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gridBancos.ThemeStyle.HeaderStyle.Height = 22;
            this.gridBancos.ThemeStyle.ReadOnly = false;
            this.gridBancos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gridBancos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridBancos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBancos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridBancos.ThemeStyle.RowsStyle.Height = 22;
            this.gridBancos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gridBancos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gridBancos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBancos_CellContentClick);
            // 
            // idbancoDataGridViewTextBoxColumn
            // 
            this.idbancoDataGridViewTextBoxColumn.DataPropertyName = "Idbanco";
            this.idbancoDataGridViewTextBoxColumn.FillWeight = 47.69844F;
            this.idbancoDataGridViewTextBoxColumn.HeaderText = "Idbanco";
            this.idbancoDataGridViewTextBoxColumn.Name = "idbancoDataGridViewTextBoxColumn";
            // 
            // idBancoContableDataGridViewTextBoxColumn
            // 
            this.idBancoContableDataGridViewTextBoxColumn.DataPropertyName = "IdBancoContable";
            this.idBancoContableDataGridViewTextBoxColumn.HeaderText = "IdBancoContable";
            this.idBancoContableDataGridViewTextBoxColumn.Name = "idBancoContableDataGridViewTextBoxColumn";
            this.idBancoContableDataGridViewTextBoxColumn.Visible = false;
            // 
            // bancoDataGridViewTextBoxColumn
            // 
            this.bancoDataGridViewTextBoxColumn.DataPropertyName = "Banco";
            this.bancoDataGridViewTextBoxColumn.FillWeight = 280.4152F;
            this.bancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.bancoDataGridViewTextBoxColumn.Name = "bancoDataGridViewTextBoxColumn";
            // 
            // usaTerminalDataGridViewCheckBoxColumn
            // 
            this.usaTerminalDataGridViewCheckBoxColumn.DataPropertyName = "UsaTerminal";
            this.usaTerminalDataGridViewCheckBoxColumn.HeaderText = "UsaTerminal";
            this.usaTerminalDataGridViewCheckBoxColumn.Name = "usaTerminalDataGridViewCheckBoxColumn";
            this.usaTerminalDataGridViewCheckBoxColumn.Visible = false;
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "Orden";
            this.ordenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            this.ordenDataGridViewTextBoxColumn.Visible = false;
            // 
            // mapcoDataGridViewCheckBoxColumn
            // 
            this.mapcoDataGridViewCheckBoxColumn.DataPropertyName = "Mapco";
            this.mapcoDataGridViewCheckBoxColumn.HeaderText = "Mapco";
            this.mapcoDataGridViewCheckBoxColumn.Name = "mapcoDataGridViewCheckBoxColumn";
            this.mapcoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // comisionBancariaDataGridViewTextBoxColumn
            // 
            this.comisionBancariaDataGridViewTextBoxColumn.DataPropertyName = "ComisionBancaria";
            this.comisionBancariaDataGridViewTextBoxColumn.HeaderText = "ComisionBancaria";
            this.comisionBancariaDataGridViewTextBoxColumn.Name = "comisionBancariaDataGridViewTextBoxColumn";
            this.comisionBancariaDataGridViewTextBoxColumn.Visible = false;
            // 
            // capturaManualDataGridViewCheckBoxColumn
            // 
            this.capturaManualDataGridViewCheckBoxColumn.DataPropertyName = "CapturaManual";
            this.capturaManualDataGridViewCheckBoxColumn.HeaderText = "CapturaManual";
            this.capturaManualDataGridViewCheckBoxColumn.Name = "capturaManualDataGridViewCheckBoxColumn";
            this.capturaManualDataGridViewCheckBoxColumn.Visible = false;
            // 
            // estatusDataGridViewCheckBoxColumn
            // 
            this.estatusDataGridViewCheckBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewCheckBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewCheckBoxColumn.Name = "estatusDataGridViewCheckBoxColumn";
            this.estatusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // fechaInsertDataGridViewTextBoxColumn
            // 
            this.fechaInsertDataGridViewTextBoxColumn.DataPropertyName = "FechaInsert";
            this.fechaInsertDataGridViewTextBoxColumn.HeaderText = "FechaInsert";
            this.fechaInsertDataGridViewTextBoxColumn.Name = "fechaInsertDataGridViewTextBoxColumn";
            this.fechaInsertDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaUpdateDataGridViewTextBoxColumn
            // 
            this.fechaUpdateDataGridViewTextBoxColumn.DataPropertyName = "FechaUpdate";
            this.fechaUpdateDataGridViewTextBoxColumn.HeaderText = "FechaUpdate";
            this.fechaUpdateDataGridViewTextBoxColumn.Name = "fechaUpdateDataGridViewTextBoxColumn";
            this.fechaUpdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaBajaDataGridViewTextBoxColumn
            // 
            this.fechaBajaDataGridViewTextBoxColumn.DataPropertyName = "FechaBaja";
            this.fechaBajaDataGridViewTextBoxColumn.HeaderText = "FechaBaja";
            this.fechaBajaDataGridViewTextBoxColumn.Name = "fechaBajaDataGridViewTextBoxColumn";
            this.fechaBajaDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioInsertDataGridViewTextBoxColumn
            // 
            this.usuarioInsertDataGridViewTextBoxColumn.DataPropertyName = "UsuarioInsert";
            this.usuarioInsertDataGridViewTextBoxColumn.HeaderText = "UsuarioInsert";
            this.usuarioInsertDataGridViewTextBoxColumn.Name = "usuarioInsertDataGridViewTextBoxColumn";
            this.usuarioInsertDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioUpdateDataGridViewTextBoxColumn
            // 
            this.usuarioUpdateDataGridViewTextBoxColumn.DataPropertyName = "UsuarioUpdate";
            this.usuarioUpdateDataGridViewTextBoxColumn.HeaderText = "UsuarioUpdate";
            this.usuarioUpdateDataGridViewTextBoxColumn.Name = "usuarioUpdateDataGridViewTextBoxColumn";
            this.usuarioUpdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioBajaDataGridViewTextBoxColumn
            // 
            this.usuarioBajaDataGridViewTextBoxColumn.DataPropertyName = "UsuarioBaja";
            this.usuarioBajaDataGridViewTextBoxColumn.HeaderText = "UsuarioBaja";
            this.usuarioBajaDataGridViewTextBoxColumn.Name = "usuarioBajaDataGridViewTextBoxColumn";
            this.usuarioBajaDataGridViewTextBoxColumn.Visible = false;
            // 
            // Editar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.NullValue = null;
            this.Editar.DefaultCellStyle = dataGridViewCellStyle3;
            this.Editar.FillWeight = 35.3383F;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::WFERPMapco.Properties.Resources.pencil2_24;
            this.Editar.MinimumWidth = 6;
            this.Editar.Name = "Editar";
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Eliminar
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.NullValue = null;
            this.Eliminar.DefaultCellStyle = dataGridViewCellStyle4;
            this.Eliminar.FillWeight = 36.54824F;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::WFERPMapco.Properties.Resources.delete_bin_18;
            this.Eliminar.MinimumWidth = 6;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bancosEntityBindingSource
            // 
            this.bancosEntityBindingSource.DataSource = typeof(WFERPMapco.Clases.BancosEntity);
            // 
            // Bancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 584);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bancos";
            this.Text = "Banco";
            this.Load += new System.EventHandler(this.Bancos_Load);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComisionBancaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bancosEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.BindingSource bancosEntityBindingSource;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2DataGridView gridBancos;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtNomBanco;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtIdBanco;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cmbBancoContable;
        private Guna.UI2.WinForms.Guna2CheckBox chkUsaTerminal;
        private Guna.UI2.WinForms.Guna2CheckBox chkMapco;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtComisionBancaria;
        private Guna.UI2.WinForms.Guna2CheckBox chkCapturaManual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBancoContableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn usaTerminalDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mapcoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comisionBancariaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn capturaManualDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn estatusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaInsertDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioInsertDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioBajaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private Guna.UI2.WinForms.Guna2Button btnGuardar;
        private Guna.UI2.WinForms.Guna2Button btnCancelar;
    }
}