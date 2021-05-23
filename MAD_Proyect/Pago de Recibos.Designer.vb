<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Pago_de_Recibos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Boton_ConsumoHistorico = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Boton_GenerarReciboyConsulta = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Button_Pagar = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Totes_label = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Tasa_Label = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Todos = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Nombre = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Pendiente_Label = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Total_Label = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Subtotal_Label = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Tarifa_Label = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Consumo_Label = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.ListBox_RECIBOS = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBox_RecibosPagados = New System.Windows.Forms.ListBox()
        Me.PanelMenu.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.PanelMenu.Controls.Add(Me.Panel10)
        Me.PanelMenu.Controls.Add(Me.Boton_ConsumoHistorico)
        Me.PanelMenu.Controls.Add(Me.Panel3)
        Me.PanelMenu.Controls.Add(Me.Boton_GenerarReciboyConsulta)
        Me.PanelMenu.Controls.Add(Me.Panel9)
        Me.PanelMenu.Controls.Add(Me.Button_Pagar)
        Me.PanelMenu.Controls.Add(Me.PictureBox2)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 39)
        Me.PanelMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 541)
        Me.PanelMenu.TabIndex = 12
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel10.Location = New System.Drawing.Point(0, 194)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(5, 50)
        Me.Panel10.TabIndex = 59
        '
        'Boton_ConsumoHistorico
        '
        Me.Boton_ConsumoHistorico.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Boton_ConsumoHistorico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Boton_ConsumoHistorico.FlatAppearance.BorderSize = 0
        Me.Boton_ConsumoHistorico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Boton_ConsumoHistorico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.Boton_ConsumoHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_ConsumoHistorico.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_ConsumoHistorico.Image = Global.MAD_Proyect.My.Resources.Resources.compras
        Me.Boton_ConsumoHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_ConsumoHistorico.Location = New System.Drawing.Point(0, 194)
        Me.Boton_ConsumoHistorico.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Boton_ConsumoHistorico.Name = "Boton_ConsumoHistorico"
        Me.Boton_ConsumoHistorico.Size = New System.Drawing.Size(220, 50)
        Me.Boton_ConsumoHistorico.TabIndex = 58
        Me.Boton_ConsumoHistorico.Text = "Consum Historico"
        Me.Boton_ConsumoHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Boton_ConsumoHistorico.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel3.Location = New System.Drawing.Point(0, 121)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(5, 50)
        Me.Panel3.TabIndex = 57
        '
        'Boton_GenerarReciboyConsulta
        '
        Me.Boton_GenerarReciboyConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Boton_GenerarReciboyConsulta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Boton_GenerarReciboyConsulta.FlatAppearance.BorderSize = 0
        Me.Boton_GenerarReciboyConsulta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Boton_GenerarReciboyConsulta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.Boton_GenerarReciboyConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Boton_GenerarReciboyConsulta.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Boton_GenerarReciboyConsulta.Image = Global.MAD_Proyect.My.Resources.Resources.reportes
        Me.Boton_GenerarReciboyConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Boton_GenerarReciboyConsulta.Location = New System.Drawing.Point(0, 121)
        Me.Boton_GenerarReciboyConsulta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Boton_GenerarReciboyConsulta.Name = "Boton_GenerarReciboyConsulta"
        Me.Boton_GenerarReciboyConsulta.Size = New System.Drawing.Size(220, 50)
        Me.Boton_GenerarReciboyConsulta.TabIndex = 55
        Me.Boton_GenerarReciboyConsulta.Text = "Gen Rec/Consul"
        Me.Boton_GenerarReciboyConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Boton_GenerarReciboyConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Boton_GenerarReciboyConsulta.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel9.Location = New System.Drawing.Point(0, 267)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(5, 50)
        Me.Panel9.TabIndex = 53
        '
        'Button_Pagar
        '
        Me.Button_Pagar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_Pagar.FlatAppearance.BorderSize = 0
        Me.Button_Pagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button_Pagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.Button_Pagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_Pagar.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Pagar.Image = Global.MAD_Proyect.My.Resources.Resources.pagos
        Me.Button_Pagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button_Pagar.Location = New System.Drawing.Point(0, 267)
        Me.Button_Pagar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button_Pagar.Name = "Button_Pagar"
        Me.Button_Pagar.Size = New System.Drawing.Size(220, 50)
        Me.Button_Pagar.TabIndex = 46
        Me.Button_Pagar.Text = "Pagar"
        Me.Button_Pagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button_Pagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button_Pagar.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MAD_Proyect.My.Resources.Resources.CFE
        Me.PictureBox2.Location = New System.Drawing.Point(0, 6)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(220, 82)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 42
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Green
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1197, 39)
        Me.Panel1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.MAD_Proyect.My.Resources.Resources.Icono_cerrar_FN
        Me.Button1.Location = New System.Drawing.Point(1157, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 39)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Font = New System.Drawing.Font("Tw Cen MT", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.OldLace
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 39)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Pagos de recibos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Totes_label)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Tasa_Label)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Todos)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TextBox_Nombre)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Pendiente_Label)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Total_Label)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Subtotal_Label)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Tarifa_Label)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Consumo_Label)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Controls.Add(Me.ListBox_RECIBOS)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.ForeColor = System.Drawing.Color.OliveDrab
        Me.GroupBox2.Location = New System.Drawing.Point(227, 46)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(956, 388)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pagos"
        '
        'Totes_label
        '
        Me.Totes_label.AutoSize = True
        Me.Totes_label.ForeColor = System.Drawing.Color.Black
        Me.Totes_label.Location = New System.Drawing.Point(517, 223)
        Me.Totes_label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Totes_label.Name = "Totes_label"
        Me.Totes_label.Size = New System.Drawing.Size(218, 17)
        Me.Totes_label.TabIndex = 67
        Me.Totes_label.Text = "Favor de Seleccionar un contrato"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(420, 223)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 17)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "Total:"
        '
        'Tasa_Label
        '
        Me.Tasa_Label.AutoSize = True
        Me.Tasa_Label.ForeColor = System.Drawing.Color.Black
        Me.Tasa_Label.Location = New System.Drawing.Point(517, 149)
        Me.Tasa_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Tasa_Label.Name = "Tasa_Label"
        Me.Tasa_Label.Size = New System.Drawing.Size(218, 17)
        Me.Tasa_Label.TabIndex = 65
        Me.Tasa_Label.Text = "Favor de Seleccionar un contrato"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(424, 149)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 17)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Tasa Tarifa:"
        '
        'Todos
        '
        Me.Todos.BackColor = System.Drawing.Color.LightYellow
        Me.Todos.FlatAppearance.BorderSize = 0
        Me.Todos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Todos.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Todos.Location = New System.Drawing.Point(203, 294)
        Me.Todos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Todos.Name = "Todos"
        Me.Todos.Size = New System.Drawing.Size(157, 74)
        Me.Todos.TabIndex = 63
        Me.Todos.Text = "Pagar Todos"
        Me.Todos.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(519, 261)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "16%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(421, 261)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Iva:"
        '
        'TextBox_Nombre
        '
        Me.TextBox_Nombre.BackColor = System.Drawing.Color.Beige
        Me.TextBox_Nombre.Location = New System.Drawing.Point(523, 347)
        Me.TextBox_Nombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox_Nombre.Name = "TextBox_Nombre"
        Me.TextBox_Nombre.Size = New System.Drawing.Size(269, 22)
        Me.TextBox_Nombre.TabIndex = 60
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(421, 347)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 17)
        Me.Label15.TabIndex = 59
        Me.Label15.Text = "Importe:"
        '
        'Pendiente_Label
        '
        Me.Pendiente_Label.AutoSize = True
        Me.Pendiente_Label.ForeColor = System.Drawing.Color.Black
        Me.Pendiente_Label.Location = New System.Drawing.Point(551, 299)
        Me.Pendiente_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Pendiente_Label.Name = "Pendiente_Label"
        Me.Pendiente_Label.Size = New System.Drawing.Size(210, 17)
        Me.Pendiente_Label.TabIndex = 58
        Me.Pendiente_Label.Text = "Favor de Seleccionar un Recibo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(421, 299)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 17)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Pendiente Pago:"
        '
        'Total_Label
        '
        Me.Total_Label.AutoSize = True
        Me.Total_Label.ForeColor = System.Drawing.Color.Black
        Me.Total_Label.Location = New System.Drawing.Point(519, 198)
        Me.Total_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Total_Label.Name = "Total_Label"
        Me.Total_Label.Size = New System.Drawing.Size(218, 17)
        Me.Total_Label.TabIndex = 56
        Me.Total_Label.Text = "Favor de Seleccionar un contrato"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(421, 198)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 17)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Total:"
        '
        'Subtotal_Label
        '
        Me.Subtotal_Label.AutoSize = True
        Me.Subtotal_Label.ForeColor = System.Drawing.Color.Black
        Me.Subtotal_Label.Location = New System.Drawing.Point(519, 176)
        Me.Subtotal_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Subtotal_Label.Name = "Subtotal_Label"
        Me.Subtotal_Label.Size = New System.Drawing.Size(218, 17)
        Me.Subtotal_Label.TabIndex = 54
        Me.Subtotal_Label.Text = "Favor de Seleccionar un contrato"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(421, 176)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 17)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Subtotal:"
        '
        'Tarifa_Label
        '
        Me.Tarifa_Label.AutoSize = True
        Me.Tarifa_Label.ForeColor = System.Drawing.Color.Black
        Me.Tarifa_Label.Location = New System.Drawing.Point(519, 123)
        Me.Tarifa_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Tarifa_Label.Name = "Tarifa_Label"
        Me.Tarifa_Label.Size = New System.Drawing.Size(218, 17)
        Me.Tarifa_Label.TabIndex = 52
        Me.Tarifa_Label.Text = "Favor de Seleccionar un contrato"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(421, 123)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Tarifa:"
        '
        'Consumo_Label
        '
        Me.Consumo_Label.AutoSize = True
        Me.Consumo_Label.ForeColor = System.Drawing.Color.Black
        Me.Consumo_Label.Location = New System.Drawing.Point(517, 90)
        Me.Consumo_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Consumo_Label.Name = "Consumo_Label"
        Me.Consumo_Label.Size = New System.Drawing.Size(218, 17)
        Me.Consumo_Label.TabIndex = 50
        Me.Consumo_Label.Text = "Favor de Seleccionar un contrato"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(421, 90)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Consumo:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Efectivo", "Tarjeta de Credito", "Tarjeta de Debito", "Transferencia bancaria"})
        Me.ComboBox1.Location = New System.Drawing.Point(161, 30)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(197, 24)
        Me.ComboBox1.TabIndex = 44
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.LightYellow
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(19, 294)
        Me.Button9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(157, 74)
        Me.Button9.TabIndex = 43
        Me.Button9.Text = "Confirmar Pago"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'ListBox_RECIBOS
        '
        Me.ListBox_RECIBOS.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListBox_RECIBOS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox_RECIBOS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListBox_RECIBOS.Font = New System.Drawing.Font("Tw Cen MT", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox_RECIBOS.ForeColor = System.Drawing.Color.OliveDrab
        Me.ListBox_RECIBOS.FormattingEnabled = True
        Me.ListBox_RECIBOS.ItemHeight = 27
        Me.ListBox_RECIBOS.Location = New System.Drawing.Point(19, 90)
        Me.ListBox_RECIBOS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBox_RECIBOS.Name = "ListBox_RECIBOS"
        Me.ListBox_RECIBOS.Size = New System.Drawing.Size(353, 191)
        Me.ListBox_RECIBOS.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Tw Cen MT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Forma de Pago"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox_RecibosPagados)
        Me.GroupBox1.ForeColor = System.Drawing.Color.OliveDrab
        Me.GroupBox1.Location = New System.Drawing.Point(227, 441)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(849, 123)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Recibos Pagados"
        '
        'ListBox_RecibosPagados
        '
        Me.ListBox_RecibosPagados.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListBox_RecibosPagados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox_RecibosPagados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListBox_RecibosPagados.Font = New System.Drawing.Font("Tw Cen MT", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox_RecibosPagados.ForeColor = System.Drawing.Color.OliveDrab
        Me.ListBox_RecibosPagados.FormattingEnabled = True
        Me.ListBox_RecibosPagados.ItemHeight = 27
        Me.ListBox_RecibosPagados.Location = New System.Drawing.Point(12, 22)
        Me.ListBox_RecibosPagados.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListBox_RecibosPagados.Name = "ListBox_RecibosPagados"
        Me.ListBox_RecibosPagados.Size = New System.Drawing.Size(821, 56)
        Me.ListBox_RecibosPagados.TabIndex = 15
        '
        'Pago_de_Recibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 580)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Pago_de_Recibos"
        Me.Text = "Pago_de_Recibos"
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMenu As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button9 As Button
    Friend WithEvents ListBox_RECIBOS As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ListBox_RecibosPagados As ListBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Button_Pagar As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Boton_GenerarReciboyConsulta As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Boton_ConsumoHistorico As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Pendiente_Label As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Total_Label As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Subtotal_Label As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Tarifa_Label As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Consumo_Label As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_Nombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Todos As Button
    Friend WithEvents Tasa_Label As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Totes_label As Label
    Friend WithEvents Label10 As Label
End Class
