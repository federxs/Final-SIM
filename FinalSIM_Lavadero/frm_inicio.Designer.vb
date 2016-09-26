<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_inicio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_inicio))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_aceptar = New System.Windows.Forms.Button()
        Me.txt_tiempoSim = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_desde = New System.Windows.Forms.TextBox()
        Me.txt_hasta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.group_mensajes = New System.Windows.Forms.GroupBox()
        Me.lbl_mensajes = New System.Windows.Forms.TextBox()
        Me.btn_consigna = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.group_mensajes.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(41, 103)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tiempo de simulación:"
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Location = New System.Drawing.Point(353, 389)
        Me.btn_aceptar.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(125, 49)
        Me.btn_aceptar.TabIndex = 2
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'txt_tiempoSim
        '
        Me.txt_tiempoSim.Location = New System.Drawing.Point(214, 95)
        Me.txt_tiempoSim.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_tiempoSim.Name = "txt_tiempoSim"
        Me.txt_tiempoSim.Size = New System.Drawing.Size(164, 32)
        Me.txt_tiempoSim.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 11.0!)
        Me.Label2.Location = New System.Drawing.Point(30, 143)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Intervalo a mostrar:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Lucida Sans", 11.0!)
        Me.Label3.Location = New System.Drawing.Point(158, 171)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Desde:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Lucida Sans", 11.0!)
        Me.Label4.Location = New System.Drawing.Point(163, 211)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Hasta:"
        '
        'txt_desde
        '
        Me.txt_desde.Location = New System.Drawing.Point(214, 163)
        Me.txt_desde.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_desde.Name = "txt_desde"
        Me.txt_desde.Size = New System.Drawing.Size(164, 32)
        Me.txt_desde.TabIndex = 7
        '
        'txt_hasta
        '
        Me.txt_hasta.Location = New System.Drawing.Point(214, 203)
        Me.txt_hasta.Margin = New System.Windows.Forms.Padding(5)
        Me.txt_hasta.Name = "txt_hasta"
        Me.txt_hasta.Size = New System.Drawing.Size(164, 32)
        Me.txt_hasta.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Sans", 14.0!)
        Me.Label5.Location = New System.Drawing.Point(23, 59)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(278, 22)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Ingrese los siguientes datos:"
        '
        'group_mensajes
        '
        Me.group_mensajes.Controls.Add(Me.lbl_mensajes)
        Me.group_mensajes.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.group_mensajes.Location = New System.Drawing.Point(15, 247)
        Me.group_mensajes.Margin = New System.Windows.Forms.Padding(5)
        Me.group_mensajes.Name = "group_mensajes"
        Me.group_mensajes.Padding = New System.Windows.Forms.Padding(5)
        Me.group_mensajes.Size = New System.Drawing.Size(474, 132)
        Me.group_mensajes.TabIndex = 26
        Me.group_mensajes.TabStop = False
        Me.group_mensajes.Text = "Mensajes"
        '
        'lbl_mensajes
        '
        Me.lbl_mensajes.Location = New System.Drawing.Point(12, 16)
        Me.lbl_mensajes.Margin = New System.Windows.Forms.Padding(5)
        Me.lbl_mensajes.Multiline = True
        Me.lbl_mensajes.Name = "lbl_mensajes"
        Me.lbl_mensajes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lbl_mensajes.Size = New System.Drawing.Size(451, 106)
        Me.lbl_mensajes.TabIndex = 0
        '
        'btn_consigna
        '
        Me.btn_consigna.Location = New System.Drawing.Point(15, 389)
        Me.btn_consigna.Margin = New System.Windows.Forms.Padding(5)
        Me.btn_consigna.Name = "btn_consigna"
        Me.btn_consigna.Size = New System.Drawing.Size(142, 49)
        Me.btn_consigna.TabIndex = 27
        Me.btn_consigna.Text = "Caso de Estudio"
        Me.btn_consigna.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Lucida Sans Unicode", 22.25!, System.Drawing.FontStyle.Underline)
        Me.Label6.Location = New System.Drawing.Point(36, 9)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(424, 37)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Examen Final de Simulación"
        '
        'frm_inicio
        '
        Me.AcceptButton = Me.btn_aceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 447)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btn_consigna)
        Me.Controls.Add(Me.group_mensajes)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_hasta)
        Me.Controls.Add(Me.txt_desde)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_tiempoSim)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frm_inicio"
        Me.Text = "Simulacion Lavadero - Inicio"
        Me.group_mensajes.ResumeLayout(False)
        Me.group_mensajes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents txt_tiempoSim As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_desde As System.Windows.Forms.TextBox
    Friend WithEvents txt_hasta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents group_mensajes As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_mensajes As System.Windows.Forms.TextBox
    Friend WithEvents btn_consigna As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
