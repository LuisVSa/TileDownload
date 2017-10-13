<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ListMapServers = New System.Windows.Forms.ListBox()
        Me.cmdGetTile = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLongitude = New System.Windows.Forms.TextBox()
        Me.txtLatitude = New System.Windows.Forms.TextBox()
        Me.txtZoom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureTile = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CmdClearCache = New System.Windows.Forms.Button()
        CType(Me.PictureTile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Found Tile Plugins - choose one!"
        '
        'ListMapServers
        '
        Me.ListMapServers.FormattingEnabled = True
        Me.ListMapServers.Location = New System.Drawing.Point(299, 41)
        Me.ListMapServers.Name = "ListMapServers"
        Me.ListMapServers.Size = New System.Drawing.Size(161, 108)
        Me.ListMapServers.TabIndex = 17
        '
        'cmdGetTile
        '
        Me.cmdGetTile.Location = New System.Drawing.Point(387, 251)
        Me.cmdGetTile.Name = "cmdGetTile"
        Me.cmdGetTile.Size = New System.Drawing.Size(73, 25)
        Me.cmdGetTile.TabIndex = 16
        Me.cmdGetTile.Text = "Get Tile "
        Me.cmdGetTile.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(299, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Longitude:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 198)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Latitude:"
        '
        'txtLongitude
        '
        Me.txtLongitude.Location = New System.Drawing.Point(299, 256)
        Me.txtLongitude.Name = "txtLongitude"
        Me.txtLongitude.Size = New System.Drawing.Size(75, 20)
        Me.txtLongitude.TabIndex = 13
        Me.txtLongitude.Text = "-8.6397"
        Me.txtLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLatitude
        '
        Me.txtLatitude.Location = New System.Drawing.Point(299, 214)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(75, 20)
        Me.txtLatitude.TabIndex = 12
        Me.txtLatitude.Text = "41.0092"
        Me.txtLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtZoom
        '
        Me.txtZoom.Location = New System.Drawing.Point(299, 175)
        Me.txtZoom.Name = "txtZoom"
        Me.txtZoom.Size = New System.Drawing.Size(33, 20)
        Me.txtZoom.TabIndex = 11
        Me.txtZoom.Text = "12"
        Me.txtZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(299, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Zoom:"
        '
        'PictureTile
        '
        Me.PictureTile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureTile.Location = New System.Drawing.Point(21, 21)
        Me.PictureTile.Name = "PictureTile"
        Me.PictureTile.Size = New System.Drawing.Size(256, 256)
        Me.PictureTile.TabIndex = 19
        Me.PictureTile.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 26)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Error!"
        '
        'CmdClearCache
        '
        Me.CmdClearCache.Location = New System.Drawing.Point(387, 211)
        Me.CmdClearCache.Name = "CmdClearCache"
        Me.CmdClearCache.Size = New System.Drawing.Size(73, 25)
        Me.CmdClearCache.TabIndex = 21
        Me.CmdClearCache.Text = "Clear Cache"
        Me.CmdClearCache.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 298)
        Me.Controls.Add(Me.CmdClearCache)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureTile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListMapServers)
        Me.Controls.Add(Me.cmdGetTile)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLongitude)
        Me.Controls.Add(Me.txtLatitude)
        Me.Controls.Add(Me.txtZoom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        CType(Me.PictureTile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents ListMapServers As ListBox
    Friend WithEvents cmdGetTile As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLongitude As TextBox
    Friend WithEvents txtLatitude As TextBox
    Friend WithEvents txtZoom As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureTile As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CmdClearCache As Button
End Class
