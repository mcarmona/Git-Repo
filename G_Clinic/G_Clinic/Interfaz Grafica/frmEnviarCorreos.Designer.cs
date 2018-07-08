namespace G_Clinic.Interfaz_Grafica
{
    partial class frmEnviarCorreos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnviarCorreos));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.customizableContextMenuStrip1 = new CustomizableStrips.Strips.CustomizableContextMenuStrip();
            this.appearanceControl1 = new CustomizableStrips.Appearance.AppearanceControl();
            this.enviarCorreosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.customizableContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 350;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 129);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 25000;
            this.toolTip1.ReshowDelay = 1500;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Enviar Notificaciones";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(-19, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 9);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Dé doble click sobre el ícono indicado o sobre este globo para enviar por correo " +
                "los recordatorios pendientes de citas a los pacientes correspondientes en este m" +
                "omento o cuando usted así lo desee...";
            this.notifyIcon1.BalloonTipTitle = "SoftNet - Enviar Correos";
            this.notifyIcon1.ContextMenuStrip = this.customizableContextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SoftNet - Enviar correos de recordatorios de citas ";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(-12, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(2, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // customizableContextMenuStrip1
            // 
            this.customizableContextMenuStrip1.Appearance = this.appearanceControl1;
            this.customizableContextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.customizableContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(34, 22);
            this.customizableContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarCorreosToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.customizableContextMenuStrip1.Name = "customizableContextMenuStrip1";
            this.customizableContextMenuStrip1.Size = new System.Drawing.Size(171, 88);
            // 
            // appearanceControl1
            // 
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intBackground = -16273;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intBorderHighlight = -13410648;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intGradientBegin = -8294;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intGradientEnd = -22964;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intGradientMiddle = -15500;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intHighlight = -3878683;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intPressedBackground = -98242;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.CheckedAppearance.intSelectedBackground = -98242;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.Border = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intBorder = -16777088;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intBorderHighlight = -13410648;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intGradientBegin = -98242;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intGradientEnd = -8294;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intGradientMiddle = -20115;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.PressedAppearance.intHighlight = -6771246;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.Border = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.BorderHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intBorder = -16777088;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intBorderHighlight = -16777088;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intGradientBegin = -34;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intGradientEnd = -13432;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intGradientMiddle = -7764;
            this.appearanceControl1.CustomAppearance.ButtonAppearance.SelectedAppearance.intHighlight = -3878683;
            this.appearanceControl1.CustomAppearance.GripAppearance.intDark = -14204554;
            this.appearanceControl1.CustomAppearance.GripAppearance.intLight = -1;
            this.appearanceControl1.CustomAppearance.GripAppearance.Light = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Normal.intGradientBegin = -1839105;
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Normal.intGradientEnd = -8674080;
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Normal.intGradientMiddle = -3415556;
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Revealed.intGradientBegin = -3416586;
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Revealed.intGradientEnd = -9266217;
            this.appearanceControl1.CustomAppearance.ImageMarginAppearance.Revealed.intGradientMiddle = -6175239;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.Border = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intBorder = -16777088;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intPressedGradientBegin = -1839105;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intPressedGradientEnd = -8674080;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intPressedGradientMiddle = -6175239;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intSelected = -4414;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intSelectedGradientBegin = -34;
            this.appearanceControl1.CustomAppearance.MenuItemAppearance.intSelectedGradientEnd = -13432;
            this.appearanceControl1.CustomAppearance.MenuStripAppearance.intBorder = -16765546;
            this.appearanceControl1.CustomAppearance.MenuStripAppearance.intGradientBegin = -6373643;
            this.appearanceControl1.CustomAppearance.MenuStripAppearance.intGradientEnd = -3876102;
            this.appearanceControl1.CustomAppearance.OverflowButtonAppearance.intGradientBegin = -8408582;
            this.appearanceControl1.CustomAppearance.OverflowButtonAppearance.intGradientEnd = -16763503;
            this.appearanceControl1.CustomAppearance.OverflowButtonAppearance.intGradientMiddle = -11370544;
            this.appearanceControl1.CustomAppearance.RaftingContainerAppearance.intGradientBegin = -6373643;
            this.appearanceControl1.CustomAppearance.RaftingContainerAppearance.intGradientEnd = -3876102;
            this.appearanceControl1.CustomAppearance.SeparatorAppearance.intDark = -9794357;
            this.appearanceControl1.CustomAppearance.SeparatorAppearance.intLight = -919041;
            this.appearanceControl1.CustomAppearance.StatusStripAppearance.intGradientBegin = -6373643;
            this.appearanceControl1.CustomAppearance.StatusStripAppearance.intGradientEnd = -3876102;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intBorder = -12885604;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intContentPanelGradientBegin = -6373643;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intContentPanelGradientEnd = -3876102;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intDropDownBackground = -592138;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intGradientBegin = -1839105;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intGradientEnd = -8674080;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intGradientMiddle = -3415556;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intPanelGradientBegin = -6373643;
            this.appearanceControl1.CustomAppearance.ToolStripAppearance.intPanelGradientEnd = -3876102;
            this.appearanceControl1.Preset = CustomizableStrips.Appearance.AppearanceControl.enumPresetStyles.Office2007;
            this.appearanceControl1.Renderer.RoundedEdges = true;
            // 
            // enviarCorreosToolStripMenuItem
            // 
            this.enviarCorreosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarCorreosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enviarCorreosToolStripMenuItem.Image")));
            this.enviarCorreosToolStripMenuItem.Name = "enviarCorreosToolStripMenuItem";
            this.enviarCorreosToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.enviarCorreosToolStripMenuItem.Text = "Enviar Correos";
            this.enviarCorreosToolStripMenuItem.Click += new System.EventHandler(this.enviarCorreosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.salirToolStripMenuItem.Text = "Cerrar";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmEnviarCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(201, 134);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEnviarCorreos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmEnviarCorreos";
            this.Load += new System.EventHandler(this.frmEnviarCorreos_Load);
            this.VisibleChanged += new System.EventHandler(this.frmEnviarCorreos_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.customizableContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox txtPassword;
        private CustomizableStrips.Strips.CustomizableContextMenuStrip customizableContextMenuStrip1;
        private CustomizableStrips.Appearance.AppearanceControl appearanceControl1;
        private System.Windows.Forms.ToolStripMenuItem enviarCorreosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}