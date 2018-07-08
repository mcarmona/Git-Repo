namespace G_Clinic
{
    partial class FrmMenusXRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenusXRol));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tobSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstDestino = new System.Windows.Forms.ListView();
            this.LstOrigen = new System.Windows.Forms.ListView();
            this.BtnQuitaTodo = new System.Windows.Forms.Button();
            this.BtnQuitaUno = new System.Windows.Forms.Button();
            this.BtnAgregaUno = new System.Windows.Forms.Button();
            this.BtnAgregaTodo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NuevotoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 105;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(673, 16);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Tag = "Seleccione el rol deseado y luego de la lista origen agregue menús a la lista des" +
                "tino";
            this.toolStripStatusLabel1.Text = "Agregue o elimine opciones de menú como ud considere necesario para modificar el " +
                "Rol: Administrador";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 0);
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 100;
            this.label4.Text = "Roles";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.tobModificar,
            this.toolStripSeparator2,
            this.tobGuardar,
            this.tobCancelar,
            this.toolStripSeparator8,
            this.tobSalir});
            this.toolStrip1.Location = new System.Drawing.Point(181, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(272, 53);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobNuevo
            // 
            this.tobNuevo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevo.ForeColor = System.Drawing.Color.White;
            this.tobNuevo.Image = global::G_Clinic.Properties.Resources.Nuevo;
            this.tobNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tobNuevo.Size = new System.Drawing.Size(45, 50);
            this.tobNuevo.Text = "Nuevo";
            this.tobNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // tobModificar
            // 
            this.tobModificar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobModificar.ForeColor = System.Drawing.Color.White;
            this.tobModificar.Image = global::G_Clinic.Properties.Resources.Modificar;
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(62, 50);
            this.tobModificar.Text = "Modificar";
            this.tobModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // tobGuardar
            // 
            this.tobGuardar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobGuardar.ForeColor = System.Drawing.Color.White;
            this.tobGuardar.Image = global::G_Clinic.Properties.Resources.Guardar;
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(55, 50);
            this.tobGuardar.Text = "Guardar";
            this.tobGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tobGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelar.ForeColor = System.Drawing.Color.White;
            this.tobCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelar.Image")));
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(59, 50);
            this.tobCancelar.Text = "Cancelar";
            this.tobCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 53);
            // 
            // tobSalir
            // 
            this.tobSalir.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobSalir.ForeColor = System.Drawing.Color.White;
            this.tobSalir.Image = global::G_Clinic.Properties.Resources.Salir;
            this.tobSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSalir.Name = "tobSalir";
            this.tobSalir.Size = new System.Drawing.Size(36, 50);
            this.tobSalir.Text = "Salir";
            this.tobSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tobSalir.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.LstDestino);
            this.groupBox1.Controls.Add(this.LstOrigen);
            this.groupBox1.Controls.Add(this.BtnQuitaTodo);
            this.groupBox1.Controls.Add(this.BtnQuitaUno);
            this.groupBox1.Controls.Add(this.BtnAgregaUno);
            this.groupBox1.Controls.Add(this.BtnAgregaTodo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Procesos Existentes";
            // 
            // LstDestino
            // 
            this.LstDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstDestino.ForeColor = System.Drawing.Color.Black;
            this.LstDestino.FullRowSelect = true;
            this.LstDestino.Location = new System.Drawing.Point(354, 17);
            this.LstDestino.Name = "LstDestino";
            this.LstDestino.Size = new System.Drawing.Size(252, 264);
            this.LstDestino.TabIndex = 5;
            this.LstDestino.UseCompatibleStateImageBehavior = false;
            // 
            // LstOrigen
            // 
            this.LstOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstOrigen.ForeColor = System.Drawing.Color.Black;
            this.LstOrigen.FullRowSelect = true;
            this.LstOrigen.Location = new System.Drawing.Point(10, 17);
            this.LstOrigen.MultiSelect = false;
            this.LstOrigen.Name = "LstOrigen";
            this.LstOrigen.Size = new System.Drawing.Size(252, 264);
            this.LstOrigen.TabIndex = 0;
            this.LstOrigen.UseCompatibleStateImageBehavior = false;
            // 
            // BtnQuitaTodo
            // 
            this.BtnQuitaTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitaTodo.ForeColor = System.Drawing.Color.Black;
            this.BtnQuitaTodo.Location = new System.Drawing.Point(282, 193);
            this.BtnQuitaTodo.Name = "BtnQuitaTodo";
            this.BtnQuitaTodo.Size = new System.Drawing.Size(52, 44);
            this.BtnQuitaTodo.TabIndex = 4;
            this.BtnQuitaTodo.Text = "<<";
            this.toolTip1.SetToolTip(this.BtnQuitaTodo, "Elimine todo los menús de la Lista Destino");
            this.BtnQuitaTodo.UseVisualStyleBackColor = true;
            this.BtnQuitaTodo.Click += new System.EventHandler(this.BtnQuitaTodo_Click);
            // 
            // BtnQuitaUno
            // 
            this.BtnQuitaUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuitaUno.ForeColor = System.Drawing.Color.Black;
            this.BtnQuitaUno.Location = new System.Drawing.Point(282, 146);
            this.BtnQuitaUno.Name = "BtnQuitaUno";
            this.BtnQuitaUno.Size = new System.Drawing.Size(52, 41);
            this.BtnQuitaUno.TabIndex = 3;
            this.BtnQuitaUno.Text = "<";
            this.toolTip1.SetToolTip(this.BtnQuitaUno, "Elimine un menú a la vez de la Lista Destino, debe\r\n seleccionar primero el menú " +
                    "a eliminar de la Lista Destino");
            this.BtnQuitaUno.UseVisualStyleBackColor = true;
            this.BtnQuitaUno.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnAgregaUno
            // 
            this.BtnAgregaUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregaUno.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregaUno.Location = new System.Drawing.Point(282, 100);
            this.BtnAgregaUno.Name = "BtnAgregaUno";
            this.BtnAgregaUno.Size = new System.Drawing.Size(52, 40);
            this.BtnAgregaUno.TabIndex = 2;
            this.BtnAgregaUno.Text = ">";
            this.toolTip1.SetToolTip(this.BtnAgregaUno, "Agregue un menú a la vez a la Lista Destino, debe \r\nseleccionar primero el elemen" +
                    "to deseado de la lista Origen");
            this.BtnAgregaUno.UseVisualStyleBackColor = true;
            this.BtnAgregaUno.Click += new System.EventHandler(this.BtnAgregaUno_Click);
            // 
            // BtnAgregaTodo
            // 
            this.BtnAgregaTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregaTodo.ForeColor = System.Drawing.Color.Black;
            this.BtnAgregaTodo.Location = new System.Drawing.Point(282, 54);
            this.BtnAgregaTodo.Name = "BtnAgregaTodo";
            this.BtnAgregaTodo.Size = new System.Drawing.Size(52, 40);
            this.BtnAgregaTodo.TabIndex = 1;
            this.BtnAgregaTodo.Text = ">>";
            this.toolTip1.SetToolTip(this.BtnAgregaTodo, "Agregue todos los menús a la Lista Destino");
            this.BtnAgregaTodo.UseVisualStyleBackColor = true;
            this.BtnAgregaTodo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Location = new System.Drawing.Point(359, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Procesos con Acceso Permitido";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(60, 67);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(210, 21);
            this.cmbRol.TabIndex = 0;
            this.cmbRol.SelectedValueChanged += new System.EventHandler(this.cmbRol_SelectedValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 114;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NuevotoolStripMenuItem1,
            this.modificarToolStripMenuItem,
            this.toolStripSeparator1,
            this.guardarToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripSeparator3,
            this.salirToolStripMenuItem,
            this.aToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nuevoToolStripMenuItem.Text = "Archivo";
            // 
            // NuevotoolStripMenuItem1
            // 
            this.NuevotoolStripMenuItem1.Name = "NuevotoolStripMenuItem1";
            this.NuevotoolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NuevotoolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.NuevotoolStripMenuItem1.Text = "Nuevo";
            this.NuevotoolStripMenuItem1.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // aToolStripMenuItem
            // 
            this.aToolStripMenuItem.Name = "aToolStripMenuItem";
            this.aToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aToolStripMenuItem.Text = "Ayuda";
            this.aToolStripMenuItem.Click += new System.EventHandler(this.aToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(524, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 115;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = global::G_Clinic.Properties.Resources.close;
            this.btnSalir.Location = new System.Drawing.Point(575, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 118;
            this.btnSalir.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSalir, "Cerrar");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(180, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 2);
            this.label2.TabIndex = 116;
            // 
            // FrmMenusXRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(632, 423);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbRol);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenusXRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menus por Roles de Usuario";
            this.Load += new System.EventHandler(this.FrmMenusXRol_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tobSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnQuitaTodo;
        private System.Windows.Forms.Button BtnQuitaUno;
        private System.Windows.Forms.Button BtnAgregaUno;
        private System.Windows.Forms.Button BtnAgregaTodo;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ListView LstDestino;
        private System.Windows.Forms.ListView LstOrigen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NuevotoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label2;
        private ImagenCambiantePictureBox btnSalir;

    }
}