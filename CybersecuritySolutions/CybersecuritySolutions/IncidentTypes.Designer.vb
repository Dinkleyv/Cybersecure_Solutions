<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncidentTypes
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
        BacktoMainMenu = New Button()
        dvgViewIncidentTypes = New DataGridView()
        btnAddIncidentType = New Button()
        btnUpdateIncidentType = New Button()
        btnToCyberIncidents = New Button()
        txtIncidentType = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        cboIncidentTypeIDs = New ComboBox()
        Label3 = New Label()
        btndelete = New Button()
        CType(dvgViewIncidentTypes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BacktoMainMenu
        ' 
        BacktoMainMenu.Location = New Point(628, 15)
        BacktoMainMenu.Name = "BacktoMainMenu"
        BacktoMainMenu.Size = New Size(112, 34)
        BacktoMainMenu.TabIndex = 0
        BacktoMainMenu.Text = "Main Menu"
        BacktoMainMenu.UseVisualStyleBackColor = True
        ' 
        ' dvgViewIncidentTypes
        ' 
        dvgViewIncidentTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dvgViewIncidentTypes.Location = New Point(392, 148)
        dvgViewIncidentTypes.Name = "dvgViewIncidentTypes"
        dvgViewIncidentTypes.RowHeadersWidth = 62
        dvgViewIncidentTypes.Size = New Size(348, 235)
        dvgViewIncidentTypes.TabIndex = 1
        ' 
        ' btnAddIncidentType
        ' 
        btnAddIncidentType.Location = New Point(157, 402)
        btnAddIncidentType.Name = "btnAddIncidentType"
        btnAddIncidentType.Size = New Size(112, 34)
        btnAddIncidentType.TabIndex = 2
        btnAddIncidentType.Text = "Add"
        btnAddIncidentType.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateIncidentType
        ' 
        btnUpdateIncidentType.Location = New Point(290, 404)
        btnUpdateIncidentType.Name = "btnUpdateIncidentType"
        btnUpdateIncidentType.Size = New Size(112, 34)
        btnUpdateIncidentType.TabIndex = 3
        btnUpdateIncidentType.Text = "Update"
        btnUpdateIncidentType.UseVisualStyleBackColor = True
        ' 
        ' btnToCyberIncidents
        ' 
        btnToCyberIncidents.Location = New Point(497, 15)
        btnToCyberIncidents.Name = "btnToCyberIncidents"
        btnToCyberIncidents.Size = New Size(112, 34)
        btnToCyberIncidents.TabIndex = 5
        btnToCyberIncidents.Text = "Back"
        btnToCyberIncidents.UseVisualStyleBackColor = True
        ' 
        ' txtIncidentType
        ' 
        txtIncidentType.Location = New Point(143, 258)
        txtIncidentType.Name = "txtIncidentType"
        txtIncidentType.Size = New Size(243, 31)
        txtIncidentType.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 264)
        Label1.Name = "Label1"
        Label1.Size = New Size(125, 25)
        Label1.TabIndex = 7
        Label1.Text = "Incident Types"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(32, 24)
        Label2.Name = "Label2"
        Label2.Size = New Size(63, 25)
        Label2.TabIndex = 8
        Label2.Text = "ID No."
        ' 
        ' cboIncidentTypeIDs
        ' 
        cboIncidentTypeIDs.FormattingEnabled = True
        cboIncidentTypeIDs.Location = New Point(101, 24)
        cboIncidentTypeIDs.Name = "cboIncidentTypeIDs"
        cboIncidentTypeIDs.Size = New Size(99, 33)
        cboIncidentTypeIDs.TabIndex = 9
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(157, 83)
        Label3.Name = "Label3"
        Label3.Size = New Size(346, 50)
        Label3.TabIndex = 10
        Label3.Text = "INCIDENT TYPES"
        ' 
        ' btndelete
        ' 
        btndelete.Location = New Point(430, 404)
        btndelete.Name = "btndelete"
        btndelete.Size = New Size(112, 34)
        btndelete.TabIndex = 11
        btndelete.Text = "DELETE"
        btndelete.UseVisualStyleBackColor = True
        ' 
        ' IncidentTypes
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(738, 450)
        Controls.Add(btndelete)
        Controls.Add(Label3)
        Controls.Add(cboIncidentTypeIDs)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtIncidentType)
        Controls.Add(btnToCyberIncidents)
        Controls.Add(btnUpdateIncidentType)
        Controls.Add(btnAddIncidentType)
        Controls.Add(dvgViewIncidentTypes)
        Controls.Add(BacktoMainMenu)
        Name = "IncidentTypes"
        Text = "IncidentTypes"
        CType(dvgViewIncidentTypes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BacktoMainMenu As Button
    Friend WithEvents dvgViewIncidentTypes As DataGridView
    Friend WithEvents btnAddIncidentType As Button
    Friend WithEvents btnUpdateIncidentType As Button
    Friend WithEvents btnToCyberIncidents As Button
    Friend WithEvents txtIncidentType As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboIncidentTypeIDs As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btndelete As Button
End Class
