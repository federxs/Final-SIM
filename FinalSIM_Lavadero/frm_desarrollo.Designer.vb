<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_desarrollo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_desarrollo))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_tiempoSim = New System.Windows.Forms.Label()
        Me.dgv_matriz = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_autos = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_relojCeldaSelec = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_porcUsoSecadora = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_promTiempoAtencion = New System.Windows.Forms.Label()
        Me.bnt_abreviaciones = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_eventoCelSelec = New System.Windows.Forms.Label()
        CType(Me.dgv_matriz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tiempo de simulación: "
        '
        'lbl_tiempoSim
        '
        Me.lbl_tiempoSim.AutoSize = True
        Me.lbl_tiempoSim.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lbl_tiempoSim.Location = New System.Drawing.Point(162, 0)
        Me.lbl_tiempoSim.Name = "lbl_tiempoSim"
        Me.lbl_tiempoSim.Size = New System.Drawing.Size(38, 17)
        Me.lbl_tiempoSim.TabIndex = 1
        Me.lbl_tiempoSim.Text = "label"
        '
        'dgv_matriz
        '
        Me.dgv_matriz.AllowUserToAddRows = False
        Me.dgv_matriz.AllowUserToDeleteRows = False
        Me.dgv_matriz.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_matriz.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_matriz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_matriz.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_matriz.Location = New System.Drawing.Point(12, 53)
        Me.dgv_matriz.Name = "dgv_matriz"
        Me.dgv_matriz.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_matriz.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_matriz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_matriz.Size = New System.Drawing.Size(1240, 725)
        Me.dgv_matriz.TabIndex = 3
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.lbl_tiempoSim)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(450, 779)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(326, 25)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.Label7.Location = New System.Drawing.Point(6, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(226, 18)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Cantidad de autos atendidos:"
        '
        'lbl_autos
        '
        Me.lbl_autos.AutoSize = True
        Me.lbl_autos.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.lbl_autos.Location = New System.Drawing.Point(232, 22)
        Me.lbl_autos.Name = "lbl_autos"
        Me.lbl_autos.Size = New System.Drawing.Size(0, 18)
        Me.lbl_autos.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 788)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(198, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Reloj de la celda seleccionada:"
        '
        'lbl_relojCeldaSelec
        '
        Me.lbl_relojCeldaSelec.AutoSize = True
        Me.lbl_relojCeldaSelec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_relojCeldaSelec.Location = New System.Drawing.Point(216, 788)
        Me.lbl_relojCeldaSelec.Name = "lbl_relojCeldaSelec"
        Me.lbl_relojCeldaSelec.Size = New System.Drawing.Size(0, 16)
        Me.lbl_relojCeldaSelec.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_porcUsoSecadora)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lbl_promTiempoAtencion)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lbl_autos)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 838)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 112)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estadísticas"
        '
        'lbl_porcUsoSecadora
        '
        Me.lbl_porcUsoSecadora.AutoSize = True
        Me.lbl_porcUsoSecadora.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.lbl_porcUsoSecadora.Location = New System.Drawing.Point(248, 60)
        Me.lbl_porcUsoSecadora.Name = "lbl_porcUsoSecadora"
        Me.lbl_porcUsoSecadora.Size = New System.Drawing.Size(0, 18)
        Me.lbl_porcUsoSecadora.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(242, 18)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Porcentaje de uso de secadora:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.Label9.Location = New System.Drawing.Point(6, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(263, 18)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Promedio del tiempo de atención:"
        '
        'lbl_promTiempoAtencion
        '
        Me.lbl_promTiempoAtencion.AutoSize = True
        Me.lbl_promTiempoAtencion.Font = New System.Drawing.Font("Lucida Sans Unicode", 11.0!)
        Me.lbl_promTiempoAtencion.Location = New System.Drawing.Point(275, 42)
        Me.lbl_promTiempoAtencion.Name = "lbl_promTiempoAtencion"
        Me.lbl_promTiempoAtencion.Size = New System.Drawing.Size(0, 18)
        Me.lbl_promTiempoAtencion.TabIndex = 12
        '
        'bnt_abreviaciones
        '
        Me.bnt_abreviaciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.bnt_abreviaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bnt_abreviaciones.Location = New System.Drawing.Point(1139, 784)
        Me.bnt_abreviaciones.Name = "bnt_abreviaciones"
        Me.bnt_abreviaciones.Size = New System.Drawing.Size(113, 25)
        Me.bnt_abreviaciones.TabIndex = 14
        Me.bnt_abreviaciones.Text = "Ver abreviaciones"
        Me.bnt_abreviaciones.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(485, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 31)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Simulación"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 804)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(208, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Evento de la celda seleccionada:"
        '
        'lbl_eventoCelSelec
        '
        Me.lbl_eventoCelSelec.AutoSize = True
        Me.lbl_eventoCelSelec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lbl_eventoCelSelec.Location = New System.Drawing.Point(220, 804)
        Me.lbl_eventoCelSelec.Name = "lbl_eventoCelSelec"
        Me.lbl_eventoCelSelec.Size = New System.Drawing.Size(0, 16)
        Me.lbl_eventoCelSelec.TabIndex = 17
        '
        'frm_desarrollo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1264, 882)
        Me.Controls.Add(Me.lbl_eventoCelSelec)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.bnt_abreviaciones)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_relojCeldaSelec)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.dgv_matriz)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_desarrollo"
        Me.Text = "Simulacion Lavadero - Desarrollo"
        CType(Me.dgv_matriz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_tiempoSim As System.Windows.Forms.Label
    Friend WithEvents dgv_matriz As System.Windows.Forms.DataGridView
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_autos As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl_relojCeldaSelec As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbl_promTiempoAtencion As System.Windows.Forms.Label
    Friend WithEvents bnt_abreviaciones As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_eventoCelSelec As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_porcUsoSecadora As System.Windows.Forms.Label
End Class
