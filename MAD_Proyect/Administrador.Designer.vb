<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Administrador
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button_UPD = New System.Windows.Forms.Button()
        Me.Button_Alta = New System.Windows.Forms.Button()
        Me.TextBox_ContUS = New System.Windows.Forms.TextBox()
        Me.TextBox_NombUS = New System.Windows.Forms.TextBox()
        Me.TextBox_CURP = New System.Windows.Forms.TextBox()
        Me.TextBox_RFC = New System.Windows.Forms.TextBox()
        Me.TextBox_Nombre = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.PanelMenu.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Green
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Green
        Me.Label2.Font = New System.Drawing.Font("Tw Cen MT", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.OldLace
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(493, 39)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Alta y modificacion de Empleados"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.MAD_Proyect.My.Resources.Resources.Icono_cerrar_FN
        Me.Button1.Location = New System.Drawing.Point(1060, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.PanelMenu.Controls.Add(Me.Panel2)
        Me.PanelMenu.Controls.Add(Me.Button2)
        Me.PanelMenu.Controls.Add(Me.PictureBox1)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 40)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(220, 540)
        Me.PanelMenu.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.Location = New System.Drawing.Point(0, 169)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 50)
        Me.Panel2.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.MAD_Proyect.My.Resources.Resources.clientes
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(0, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(220, 50)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Gest Empleados"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MAD_Proyect.My.Resources.Resources.CFE
        Me.PictureBox1.Location = New System.Drawing.Point(0, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(220, 83)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(549, 82)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(414, 148)
        Me.ListBox1.TabIndex = 38
        '
        'Button_UPD
        '
        Me.Button_UPD.BackColor = System.Drawing.Color.LightYellow
        Me.Button_UPD.FlatAppearance.BorderSize = 0
        Me.Button_UPD.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_UPD.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_UPD.Location = New System.Drawing.Point(975, 142)
        Me.Button_UPD.Name = "Button_UPD"
        Me.Button_UPD.Size = New System.Drawing.Size(113, 39)
        Me.Button_UPD.TabIndex = 37
        Me.Button_UPD.Text = "Modificacion"
        Me.Button_UPD.UseVisualStyleBackColor = False
        '
        'Button_Alta
        '
        Me.Button_Alta.BackColor = System.Drawing.Color.LightYellow
        Me.Button_Alta.FlatAppearance.BorderSize = 0
        Me.Button_Alta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button_Alta.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Alta.Location = New System.Drawing.Point(984, 82)
        Me.Button_Alta.Name = "Button_Alta"
        Me.Button_Alta.Size = New System.Drawing.Size(104, 39)
        Me.Button_Alta.TabIndex = 36
        Me.Button_Alta.Text = "Alta"
        Me.Button_Alta.UseVisualStyleBackColor = False
        '
        'TextBox_ContUS
        '
        Me.TextBox_ContUS.BackColor = System.Drawing.Color.Beige
        Me.TextBox_ContUS.Location = New System.Drawing.Point(772, 306)
        Me.TextBox_ContUS.Name = "TextBox_ContUS"
        Me.TextBox_ContUS.Size = New System.Drawing.Size(191, 22)
        Me.TextBox_ContUS.TabIndex = 31
        '
        'TextBox_NombUS
        '
        Me.TextBox_NombUS.BackColor = System.Drawing.Color.Beige
        Me.TextBox_NombUS.Location = New System.Drawing.Point(550, 306)
        Me.TextBox_NombUS.Name = "TextBox_NombUS"
        Me.TextBox_NombUS.Size = New System.Drawing.Size(182, 22)
        Me.TextBox_NombUS.TabIndex = 29
        '
        'TextBox_CURP
        '
        Me.TextBox_CURP.BackColor = System.Drawing.Color.Beige
        Me.TextBox_CURP.Location = New System.Drawing.Point(251, 300)
        Me.TextBox_CURP.Name = "TextBox_CURP"
        Me.TextBox_CURP.Size = New System.Drawing.Size(269, 22)
        Me.TextBox_CURP.TabIndex = 27
        '
        'TextBox_RFC
        '
        Me.TextBox_RFC.BackColor = System.Drawing.Color.Beige
        Me.TextBox_RFC.Location = New System.Drawing.Point(251, 245)
        Me.TextBox_RFC.Name = "TextBox_RFC"
        Me.TextBox_RFC.Size = New System.Drawing.Size(269, 22)
        Me.TextBox_RFC.TabIndex = 32
        '
        'TextBox_Nombre
        '
        Me.TextBox_Nombre.BackColor = System.Drawing.Color.Beige
        Me.TextBox_Nombre.Location = New System.Drawing.Point(251, 82)
        Me.TextBox_Nombre.Name = "TextBox_Nombre"
        Me.TextBox_Nombre.Size = New System.Drawing.Size(269, 22)
        Me.TextBox_Nombre.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tw Cen MT Condensed", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(546, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(371, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "* La fecha de Alta o modificacion, se agregan en automatico *"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(768, 283)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 20)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Contraseña"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(547, 283)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 20)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Usuario"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(247, 59)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 20)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Nombre Completo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(251, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 20)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fecha de Nacimiento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(247, 277)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 20)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "CURP"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(247, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 20)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "RFC"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(546, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(249, 24)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "* Actuales Empleados *"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightGreen
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Controls.Add(Me.ListBox2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.GroupBox1.Location = New System.Drawing.Point(549, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 220)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Desbloquear"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Tw Cen MT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 23)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Empleados bloqueados"
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.LightYellow
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.Font = New System.Drawing.Font("Tw Cen MT Condensed", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(410, 13)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(116, 39)
        Me.Button11.TabIndex = 43
        Me.Button11.Text = "Desbloquear"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListBox2.Font = New System.Drawing.Font("Tw Cen MT", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox2.ForeColor = System.Drawing.Color.OliveDrab
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 27
        Me.ListBox2.Location = New System.Drawing.Point(10, 68)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(516, 137)
        Me.ListBox2.TabIndex = 15
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.Color.LightYellow
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.Color.LightYellow
        Me.DateTimePicker1.Location = New System.Drawing.Point(251, 159)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(269, 22)
        Me.DateTimePicker1.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tw Cen MT", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(255, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(214, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Fecha de Alta o Modificacion"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarForeColor = System.Drawing.Color.LightYellow
        Me.DateTimePicker2.CalendarMonthBackground = System.Drawing.Color.LightYellow
        Me.DateTimePicker2.Location = New System.Drawing.Point(255, 394)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(269, 22)
        Me.DateTimePicker2.TabIndex = 46
        '
        'Administrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 580)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button_UPD)
        Me.Controls.Add(Me.Button_Alta)
        Me.Controls.Add(Me.TextBox_ContUS)
        Me.Controls.Add(Me.TextBox_NombUS)
        Me.Controls.Add(Me.TextBox_CURP)
        Me.Controls.Add(Me.TextBox_RFC)
        Me.Controls.Add(Me.TextBox_Nombre)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Administrador"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelMenu.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button_UPD As Button
    Friend WithEvents Button_Alta As Button
    Friend WithEvents TextBox_ContUS As TextBox
    Friend WithEvents TextBox_NombUS As TextBox
    Friend WithEvents TextBox_CURP As TextBox
    Friend WithEvents TextBox_RFC As TextBox
    Friend WithEvents TextBox_Nombre As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker2 As DateTimePicker
End Class
