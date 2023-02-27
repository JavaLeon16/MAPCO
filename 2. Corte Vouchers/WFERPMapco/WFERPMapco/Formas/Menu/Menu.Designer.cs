namespace WFERPMapco.Formas.Menu
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pnlHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSlide = new FontAwesome.Sharp.IconButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.tbcPages = new System.Windows.Forms.TabControl();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.AutoSize = true;
            this.pnlHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.pnlHead.Controls.Add(this.label1);
            this.pnlHead.Controls.Add(this.pictureBox1);
            this.pnlHead.Controls.Add(this.btnSlide);
            this.pnlHead.Location = new System.Drawing.Point(0, 31);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(263, 107);
            this.pnlHead.TabIndex = 2;
            this.pnlHead.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHead_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "MENU";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(68, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnSlide
            // 
            this.btnSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.btnSlide.FlatAppearance.BorderSize = 0;
            this.btnSlide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSlide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlide.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.btnSlide.IconColor = System.Drawing.Color.White;
            this.btnSlide.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSlide.IconSize = 30;
            this.btnSlide.Location = new System.Drawing.Point(216, 9);
            this.btnSlide.Margin = new System.Windows.Forms.Padding(2);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(37, 46);
            this.btnSlide.TabIndex = 4;
            this.btnSlide.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSlide.UseVisualStyleBackColor = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.pnlTop.Location = new System.Drawing.Point(0, -3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(801, 37);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(135)))));
            this.pnlMenu.Location = new System.Drawing.Point(0, 136);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(263, 327);
            this.pnlMenu.TabIndex = 5;
            // 
            // tbcPages
            // 
            this.tbcPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcPages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbcPages.Location = new System.Drawing.Point(263, 34);
            this.tbcPages.Name = "tbcPages";
            this.tbcPages.SelectedIndex = 0;
            this.tbcPages.Size = new System.Drawing.Size(538, 429);
            this.tbcPages.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcPages.TabIndex = 7;
            this.tbcPages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tbcPages_DrawItem);
            this.tbcPages.SelectedIndexChanged += new System.EventHandler(this.tbcPages_SelectedIndexChanged);
            this.tbcPages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbcPages_MouseDown);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.tbcPages);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "ERP Mapco";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlHead;
        private FontAwesome.Sharp.IconButton btnSlide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.FlowLayoutPanel pnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbcPages;
    }
}