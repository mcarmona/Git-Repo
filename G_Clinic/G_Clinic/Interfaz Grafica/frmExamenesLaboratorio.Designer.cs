namespace G_Clinic.Interfaz_Grafica
{
    partial class frmExamenesLaboratorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamenesLaboratorio));
            this.lstGabinete = new System.Windows.Forms.ListView();
            this.id_categoria = new System.Windows.Forms.ColumnHeader();
            this.id_gabinete = new System.Windows.Forms.ColumnHeader();
            this.id_Nombre_Categoria = new System.Windows.Forms.ColumnHeader();
            this.descripcion_Gabinete = new System.Windows.Forms.ColumnHeader();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tobGuardarDatosMadre = new System.Windows.Forms.ToolStripButton();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategorias = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tobGuardarCategoria = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tobModificarCategoria = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.iniciarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarConsultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new G_Clinic.ImagenCambiantePictureBox();
            this.btnSalir = new G_Clinic.ImagenCambiantePictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tobNuevo = new System.Windows.Forms.ToolStripButton();
            this.tobModificar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tobGuardar = new System.Windows.Forms.ToolStripButton();
            this.tobCancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tobEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tobIniciarConsulta = new System.Windows.Forms.ToolStripButton();
            this.tobEjecutarConsulta = new System.Windows.Forms.ToolStripButton();
            this.tobCancelarConsulta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tobSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstGabinete
            // 
            this.lstGabinete.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id_categoria,
            this.id_gabinete,
            this.id_Nombre_Categoria,
            this.descripcion_Gabinete});
            this.lstGabinete.FullRowSelect = true;
            this.lstGabinete.HideSelection = false;
            this.lstGabinete.Location = new System.Drawing.Point(169, 219);
            this.lstGabinete.MultiSelect = false;
            this.lstGabinete.Name = "lstGabinete";
            this.lstGabinete.Size = new System.Drawing.Size(457, 234);
            this.lstGabinete.TabIndex = 3;
            this.lstGabinete.UseCompatibleStateImageBehavior = false;
            this.lstGabinete.View = System.Windows.Forms.View.Details;
            this.lstGabinete.SelectedIndexChanged += new System.EventHandler(this.lstGabinete_SelectedIndexChanged);
            // 
            // id_categoria
            // 
            this.id_categoria.Text = "Id_Categoría";
            this.id_categoria.Width = 0;
            // 
            // id_gabinete
            // 
            this.id_gabinete.Text = "Id Examen";
            this.id_gabinete.Width = 0;
            // 
            // id_Nombre_Categoria
            // 
            this.id_Nombre_Categoria.Text = "Nombre de Estudio";
            this.id_Nombre_Categoria.Width = 151;
            // 
            // descripcion_Gabinete
            // 
            this.descripcion_Gabinete.Text = "Descripción";
            this.descripcion_Gabinete.Width = 302;
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobGuardarDatosMadre});
            this.toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip4.Location = new System.Drawing.Point(547, 188);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(59, 29);
            this.toolStrip4.TabIndex = 203;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tobGuardarDatosMadre
            // 
            this.tobGuardarDatosMadre.Enabled = false;
            this.tobGuardarDatosMadre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobGuardarDatosMadre.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardarDatosMadre.Image")));
            this.tobGuardarDatosMadre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardarDatosMadre.Name = "tobGuardarDatosMadre";
            this.tobGuardarDatosMadre.Size = new System.Drawing.Size(26, 26);
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.White;
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescripcion.Location = new System.Drawing.Point(276, 128);
            this.TxtDescripcion.MaxLength = 200;
            this.TxtDescripcion.Multiline = true;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(350, 57);
            this.TxtDescripcion.TabIndex = 1;
            this.TxtDescripcion.Tag = "descripcion";
            this.TxtDescripcion.Enter += new System.EventHandler(this.TxtDescripcion_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(166, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "Nombre Examen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(166, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 147;
            this.label3.Text = "Categoría:";
            // 
            // cmbCategorias
            // 
            this.cmbCategorias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCategorias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCategorias.FormattingEnabled = true;
            this.cmbCategorias.Location = new System.Drawing.Point(276, 192);
            this.cmbCategorias.MaxLength = 100;
            this.cmbCategorias.Name = "cmbCategorias";
            this.cmbCategorias.Size = new System.Drawing.Size(268, 21);
            this.cmbCategorias.TabIndex = 2;
            this.cmbCategorias.Leave += new System.EventHandler(this.cmbCategorias_Leave);
            this.cmbCategorias.Enter += new System.EventHandler(this.cmbCategorias_Enter);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(550, 215);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 2);
            this.label14.TabIndex = 206;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(545, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 2);
            this.label6.TabIndex = 206;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobGuardarCategoria,
            this.toolStripSeparator5,
            this.tobModificarCategoria});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(547, 188);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(61, 29);
            this.toolStrip2.TabIndex = 203;
            this.toolStrip2.Text = "toolStrip4";
            // 
            // tobGuardarCategoria
            // 
            this.tobGuardarCategoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tobGuardarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardarCategoria.Image")));
            this.tobGuardarCategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardarCategoria.Name = "tobGuardarCategoria";
            this.tobGuardarCategoria.Size = new System.Drawing.Size(26, 26);
            this.tobGuardarCategoria.ToolTipText = "Guardar Nueva Categoría";
            this.tobGuardarCategoria.Click += new System.EventHandler(this.tobGuardarCategoria_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 22);
            // 
            // tobModificarCategoria
            // 
            this.tobModificarCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.tobModificarCategoria.Image = ((System.Drawing.Image)(resources.GetObject("tobModificarCategoria.Image")));
            this.tobModificarCategoria.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tobModificarCategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificarCategoria.Name = "tobModificarCategoria";
            this.tobModificarCategoria.Size = new System.Drawing.Size(27, 26);
            this.tobModificarCategoria.ToolTipText = "Editar los valores de las categorías";
            this.tobModificarCategoria.Click += new System.EventHandler(this.tobModificarCategoria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(166, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 148;
            this.label2.Text = "Descripción:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(276, 101);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(350, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Tag = "descripcion";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 79);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 207;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // archivolToolStripMenuItem
            // 
            this.archivolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.toolStripSeparator6,
            this.guardarToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripSeparator7,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator8,
            this.iniciarConsultaToolStripMenuItem,
            this.ejecutarConsultaToolStripMenuItem,
            this.cancelarConsultaToolStripMenuItem,
            this.toolStripSeparator9,
            this.salirToolStripMenuItem});
            this.archivolToolStripMenuItem.Name = "archivolToolStripMenuItem";
            this.archivolToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivolToolStripMenuItem.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(186, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cancelarToolStripMenuItem.Text = "Cancelar";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(186, 6);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.tobEliminar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(186, 6);
            // 
            // iniciarConsultaToolStripMenuItem
            // 
            this.iniciarConsultaToolStripMenuItem.Name = "iniciarConsultaToolStripMenuItem";
            this.iniciarConsultaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.iniciarConsultaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.iniciarConsultaToolStripMenuItem.Text = "Iniciar Consulta";
            this.iniciarConsultaToolStripMenuItem.Click += new System.EventHandler(this.tobIniciarConsulta_Click);
            // 
            // ejecutarConsultaToolStripMenuItem
            // 
            this.ejecutarConsultaToolStripMenuItem.Name = "ejecutarConsultaToolStripMenuItem";
            this.ejecutarConsultaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.ejecutarConsultaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ejecutarConsultaToolStripMenuItem.Text = "Ejecutar Consulta";
            this.ejecutarConsultaToolStripMenuItem.Click += new System.EventHandler(this.tobEjecutarConsulta_Click);
            // 
            // cancelarConsultaToolStripMenuItem
            // 
            this.cancelarConsultaToolStripMenuItem.Name = "cancelarConsultaToolStripMenuItem";
            this.cancelarConsultaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.cancelarConsultaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cancelarConsultaToolStripMenuItem.Text = "Cancelar Consulta";
            this.cancelarConsultaToolStripMenuItem.Click += new System.EventHandler(this.tobCancelarConsulta_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(186, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 79);
            this.panel2.TabIndex = 155;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 111;
            this.pictureBox2.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.HighlightedImage")));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(562, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(24, 17);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 116;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.HighlightedImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.HighlightedImage")));
            this.btnSalir.Image = global::G_Clinic.Properties.Resources.close;
            this.btnSalir.Location = new System.Drawing.Point(585, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 17);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSalir.TabIndex = 116;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(0, 74);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(5, 406);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 152;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(636, 77);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(5, 403);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 154;
            this.pictureBox5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.statusStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 465);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 33);
            this.panel3.TabIndex = 153;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 5);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(641, 28);
            this.statusStrip1.TabIndex = 47;
            this.statusStrip1.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(626, 23);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 23);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-32, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 304);
            this.panel1.TabIndex = 151;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tobNuevo,
            this.tobModificar,
            this.toolStripSeparator1,
            this.tobGuardar,
            this.tobCancelar,
            this.toolStripSeparator3,
            this.tobEliminar,
            this.toolStripSeparator2,
            this.tobIniciarConsulta,
            this.tobEjecutarConsulta,
            this.tobCancelarConsulta,
            this.toolStripSeparator4,
            this.tobSalir});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(44, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(144, 306);
            this.toolStrip1.TabIndex = 88;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tobNuevo
            // 
            this.tobNuevo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobNuevo.ForeColor = System.Drawing.Color.White;
            this.tobNuevo.Image = global::G_Clinic.Properties.Resources.Nuevo;
            this.tobNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobNuevo.Name = "tobNuevo";
            this.tobNuevo.Size = new System.Drawing.Size(142, 28);
            this.tobNuevo.Text = "Nuevo";
            this.tobNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobNuevo.ToolTipText = "Agregar Nuevo (Ctrl + N)";
            this.tobNuevo.Click += new System.EventHandler(this.tobNuevo_Click);
            // 
            // tobModificar
            // 
            this.tobModificar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobModificar.ForeColor = System.Drawing.Color.White;
            this.tobModificar.Image = global::G_Clinic.Properties.Resources.Modificar;
            this.tobModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobModificar.Name = "tobModificar";
            this.tobModificar.Size = new System.Drawing.Size(142, 28);
            this.tobModificar.Text = "Modificar";
            this.tobModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobModificar.ToolTipText = "Modificar Registro Existente (Ctrl + M)";
            this.tobModificar.Click += new System.EventHandler(this.tobModificar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // tobGuardar
            // 
            this.tobGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobGuardar.ForeColor = System.Drawing.Color.White;
            this.tobGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tobGuardar.Image")));
            this.tobGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobGuardar.Name = "tobGuardar";
            this.tobGuardar.Size = new System.Drawing.Size(142, 28);
            this.tobGuardar.Text = "Guardar";
            this.tobGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobGuardar.ToolTipText = "Guardar Cambios (Ctrl + G)";
            this.tobGuardar.Click += new System.EventHandler(this.tobGuardar_Click);
            // 
            // tobCancelar
            // 
            this.tobCancelar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelar.ForeColor = System.Drawing.Color.White;
            this.tobCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelar.Image")));
            this.tobCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelar.Name = "tobCancelar";
            this.tobCancelar.Size = new System.Drawing.Size(142, 28);
            this.tobCancelar.Text = "Cancelar";
            this.tobCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobCancelar.ToolTipText = "Cancelar Cambios (Ctrl + C)";
            this.tobCancelar.Click += new System.EventHandler(this.tobCancelar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // tobEliminar
            // 
            this.tobEliminar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobEliminar.ForeColor = System.Drawing.Color.White;
            this.tobEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tobEliminar.Image")));
            this.tobEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEliminar.Name = "tobEliminar";
            this.tobEliminar.Size = new System.Drawing.Size(142, 28);
            this.tobEliminar.Text = "Eliminar";
            this.tobEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobEliminar.ToolTipText = "Eliminar Registro (Ctrl + E)";
            this.tobEliminar.Click += new System.EventHandler(this.tobEliminar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // tobIniciarConsulta
            // 
            this.tobIniciarConsulta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobIniciarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobIniciarConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tobIniciarConsulta.Image")));
            this.tobIniciarConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobIniciarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobIniciarConsulta.Name = "tobIniciarConsulta";
            this.tobIniciarConsulta.Size = new System.Drawing.Size(142, 28);
            this.tobIniciarConsulta.Text = "Iniciar Consulta";
            this.tobIniciarConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobIniciarConsulta.ToolTipText = "Iniciar Consulta (F5)";
            this.tobIniciarConsulta.Click += new System.EventHandler(this.tobIniciarConsulta_Click);
            // 
            // tobEjecutarConsulta
            // 
            this.tobEjecutarConsulta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobEjecutarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobEjecutarConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tobEjecutarConsulta.Image")));
            this.tobEjecutarConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobEjecutarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobEjecutarConsulta.Name = "tobEjecutarConsulta";
            this.tobEjecutarConsulta.Size = new System.Drawing.Size(142, 28);
            this.tobEjecutarConsulta.Text = "Ejecutar Consulta";
            this.tobEjecutarConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobEjecutarConsulta.ToolTipText = "Ejecutar Consulta (F6)";
            this.tobEjecutarConsulta.Click += new System.EventHandler(this.tobEjecutarConsulta_Click);
            // 
            // tobCancelarConsulta
            // 
            this.tobCancelarConsulta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobCancelarConsulta.ForeColor = System.Drawing.Color.White;
            this.tobCancelarConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tobCancelarConsulta.Image")));
            this.tobCancelarConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobCancelarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobCancelarConsulta.Name = "tobCancelarConsulta";
            this.tobCancelarConsulta.Size = new System.Drawing.Size(142, 28);
            this.tobCancelarConsulta.Text = "Cancelar Consulta";
            this.tobCancelarConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobCancelarConsulta.ToolTipText = "Cancelar Consulta (F7)";
            this.tobCancelarConsulta.Click += new System.EventHandler(this.tobCancelarConsulta_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(155, 6);
            // 
            // tobSalir
            // 
            this.tobSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tobSalir.ForeColor = System.Drawing.Color.White;
            this.tobSalir.Image = ((System.Drawing.Image)(resources.GetObject("tobSalir.Image")));
            this.tobSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tobSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tobSalir.Name = "tobSalir";
            this.tobSalir.Size = new System.Drawing.Size(142, 28);
            this.tobSalir.Text = "Salir";
            this.tobSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tobSalir.ToolTipText = "Salir (Alt + F4)";
            this.tobSalir.Click += new System.EventHandler(this.tobSalir_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 2);
            this.label1.TabIndex = 70;
            // 
            // frmExamenesLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(3)))), ((int)(((byte)(3)))));
            this.ClientSize = new System.Drawing.Size(641, 498);
            this.Controls.Add(this.cmbCategorias);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstGabinete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExamenesLaboratorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Examenes_de_Laboratorio";
            this.Text = "Examenes de Laboratorio";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Load += new System.EventHandler(this.frmGabinete_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExamenesLaboratorio_FormClosed);
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstGabinete;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tobGuardarDatosMadre;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tobNuevo;
        private System.Windows.Forms.ToolStripButton tobModificar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tobGuardar;
        private System.Windows.Forms.ToolStripButton tobCancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tobEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tobIniciarConsulta;
        private System.Windows.Forms.ToolStripButton tobEjecutarConsulta;
        private System.Windows.Forms.ToolStripButton tobCancelarConsulta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tobSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ImagenCambiantePictureBox btnMinimize;
        private ImagenCambiantePictureBox btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategorias;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader id_gabinete;
        private System.Windows.Forms.ColumnHeader descripcion_Gabinete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tobGuardarCategoria;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tobModificarCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ColumnHeader id_categoria;
        private System.Windows.Forms.ColumnHeader id_Nombre_Categoria;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem iniciarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarConsultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}