<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.Close_Login = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.INGRESAR_LOG = New System.Windows.Forms.Button()
        Me.TextBox_Contraseña = New System.Windows.Forms.TextBox()
        Me.TextBox_Usuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Picture_Log = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox_RecordarCont = New System.Windows.Forms.CheckBox()
        Me.PanelCabecera.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Picture_Log, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.Green
        Me.PanelCabecera.Controls.Add(Me.Close_Login)
        Me.PanelCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCabecera.Location = New System.Drawing.Point(0, 0)
        Me.PanelCabecera.Name = "PanelCabecera"
        Me.PanelCabecera.Size = New System.Drawing.Size(1100, 73)
        Me.PanelCabecera.TabIndex = 0
        '
        'Close_Login
        '
        Me.Close_Login.FlatAppearance.BorderSize = 0
        Me.Close_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Close_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.Close_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Close_Login.Image = Global.MAD_Proyect.My.Resources.Resources.Icono_cerrar_FN
        Me.Close_Login.Location = New System.Drawing.Point(1027, 0)
        Me.Close_Login.Name = "Close_Login"
        Me.Close_Login.Size = New System.Drawing.Size(73, 73)
        Me.Close_Login.TabIndex = 0
        Me.Close_Login.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Controls.Add(Me.CheckBox_RecordarCont)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.INGRESAR_LOG)
        Me.Panel1.Controls.Add(Me.TextBox_Contraseña)
        Me.Panel1.Controls.Add(Me.TextBox_Usuario)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Picture_Log)
        Me.Panel1.Location = New System.Drawing.Point(334, 79)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(433, 449)
        Me.Panel1.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Lavender
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Empleado Administrador", "Empleado General ", "Cliente"})
        Me.ComboBox1.Location = New System.Drawing.Point(51, 186)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(334, 24)
        Me.ComboBox1.TabIndex = 4
        '
        'INGRESAR_LOG
        '
        Me.INGRESAR_LOG.BackColor = System.Drawing.Color.PaleTurquoise
        Me.INGRESAR_LOG.FlatAppearance.BorderSize = 0
        Me.INGRESAR_LOG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen
        Me.INGRESAR_LOG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.INGRESAR_LOG.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.INGRESAR_LOG.Font = New System.Drawing.Font("MS Reference Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INGRESAR_LOG.Location = New System.Drawing.Point(157, 395)
        Me.INGRESAR_LOG.Name = "INGRESAR_LOG"
        Me.INGRESAR_LOG.Size = New System.Drawing.Size(117, 37)
        Me.INGRESAR_LOG.TabIndex = 3
        Me.INGRESAR_LOG.Text = "INGRESAR"
        Me.INGRESAR_LOG.UseVisualStyleBackColor = False
        '
        'TextBox_Contraseña
        '
        Me.TextBox_Contraseña.BackColor = System.Drawing.Color.Lavender
        Me.TextBox_Contraseña.Location = New System.Drawing.Point(51, 326)
        Me.TextBox_Contraseña.Name = "TextBox_Contraseña"
        Me.TextBox_Contraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_Contraseña.Size = New System.Drawing.Size(334, 22)
        Me.TextBox_Contraseña.TabIndex = 2
        '
        'TextBox_Usuario
        '
        Me.TextBox_Usuario.BackColor = System.Drawing.Color.Lavender
        Me.TextBox_Usuario.Location = New System.Drawing.Point(51, 262)
        Me.TextBox_Usuario.Name = "TextBox_Usuario"
        Me.TextBox_Usuario.Size = New System.Drawing.Size(334, 22)
        Me.TextBox_Usuario.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Adobe Gothic Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Thistle
        Me.Label2.Location = New System.Drawing.Point(158, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Adobe Gothic Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Thistle
        Me.Label3.Location = New System.Drawing.Point(119, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 25)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Iniciar secion como:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Adobe Gothic Std B", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Thistle
        Me.Label1.Location = New System.Drawing.Point(167, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USUARIO"
        '
        'Picture_Log
        '
        Me.Picture_Log.Image = Global.MAD_Proyect.My.Resources.Resources.descarga
        Me.Picture_Log.Location = New System.Drawing.Point(124, 18)
        Me.Picture_Log.Name = "Picture_Log"
        Me.Picture_Log.Size = New System.Drawing.Size(177, 105)
        Me.Picture_Log.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture_Log.TabIndex = 0
        Me.Picture_Log.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MAD_Proyect.My.Resources.Resources.CFE
        Me.PictureBox1.Location = New System.Drawing.Point(34, 79)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(245, 89)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'CheckBox_RecordarCont
        '
        Me.CheckBox_RecordarCont.AutoSize = True
        Me.CheckBox_RecordarCont.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CheckBox_RecordarCont.Font = New System.Drawing.Font("Britannic Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_RecordarCont.ForeColor = System.Drawing.Color.Thistle
        Me.CheckBox_RecordarCont.Location = New System.Drawing.Point(113, 363)
        Me.CheckBox_RecordarCont.Name = "CheckBox_RecordarCont"
        Me.CheckBox_RecordarCont.Size = New System.Drawing.Size(221, 26)
        Me.CheckBox_RecordarCont.TabIndex = 5
        Me.CheckBox_RecordarCont.Text = "Recordar Contraseña"
        Me.CheckBox_RecordarCont.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1100, 580)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PanelCabecera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.Text = "Form1"
        Me.PanelCabecera.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Picture_Log, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelCabecera As Panel
    Friend WithEvents Close_Login As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Picture_Log As PictureBox
    Friend WithEvents INGRESAR_LOG As Button
    Friend WithEvents TextBox_Contraseña As TextBox
    Friend WithEvents TextBox_Usuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckBox_RecordarCont As CheckBox
End Class
