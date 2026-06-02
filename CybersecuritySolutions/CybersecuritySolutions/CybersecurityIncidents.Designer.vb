<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CybersecurityIncidents
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
        btnAddIncident = New Button()
        btnUpdateIncident = New Button()
        btnViewIncidentTypes = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        cboIncidentType = New ComboBox()
        cboAccountName = New ComboBox()
        txtIncidentDescription = New TextBox()
        BacktoMainMenu = New Button()
        Label5 = New Label()
        cboCyberIncidentIDs = New ComboBox()
        Label6 = New Label()
        cboIncidentStatus = New ComboBox()
        dtpIncidentDate = New DateTimePicker()
        btnViewCybesecurityIncidents = New Button()
        Label7 = New Label()
        btnMainMenu = New Button()
        Label8 = New Label()
        cboClient = New ComboBox()
        SuspendLayout()
        ' 
        ' btnAddIncident
        ' 
        btnAddIncident.Location = New Point(535, 225)
        btnAddIncident.Name = "btnAddIncident"
        btnAddIncident.Size = New Size(252, 34)
        btnAddIncident.TabIndex = 0
        btnAddIncident.Text = "ADD"
        btnAddIncident.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateIncident
        ' 
        btnUpdateIncident.Location = New Point(535, 276)
        btnUpdateIncident.Name = "btnUpdateIncident"
        btnUpdateIncident.Size = New Size(252, 34)
        btnUpdateIncident.TabIndex = 1
        btnUpdateIncident.Text = "UPDATE"
        btnUpdateIncident.UseVisualStyleBackColor = True
        ' 
        ' btnViewIncidentTypes
        ' 
        btnViewIncidentTypes.Location = New Point(535, 316)
        btnViewIncidentTypes.Name = "btnViewIncidentTypes"
        btnViewIncidentTypes.Size = New Size(252, 34)
        btnViewIncidentTypes.TabIndex = 2
        btnViewIncidentTypes.Text = "View Incident Types"
        btnViewIncidentTypes.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(38, 213)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 25)
        Label1.TabIndex = 3
        Label1.Text = "Account Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(38, 269)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 25)
        Label2.TabIndex = 4
        Label2.Text = "Incident Date"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(38, 321)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 25)
        Label3.TabIndex = 5
        Label3.Text = "Incident Type"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(38, 404)
        Label4.Name = "Label4"
        Label4.Size = New Size(102, 25)
        Label4.TabIndex = 6
        Label4.Text = "Description"
        ' 
        ' cboIncidentType
        ' 
        cboIncidentType.FormattingEnabled = True
        cboIncidentType.Location = New Point(178, 318)
        cboIncidentType.Name = "cboIncidentType"
        cboIncidentType.Size = New Size(300, 33)
        cboIncidentType.TabIndex = 9
        ' 
        ' cboAccountName
        ' 
        cboAccountName.FormattingEnabled = True
        cboAccountName.Location = New Point(178, 213)
        cboAccountName.Name = "cboAccountName"
        cboAccountName.Size = New Size(300, 33)
        cboAccountName.TabIndex = 10
        ' 
        ' txtIncidentDescription
        ' 
        txtIncidentDescription.Location = New Point(178, 383)
        txtIncidentDescription.Multiline = True
        txtIncidentDescription.Name = "txtIncidentDescription"
        txtIncidentDescription.Size = New Size(300, 121)
        txtIncidentDescription.TabIndex = 11
        ' 
        ' BacktoMainMenu
        ' 
        BacktoMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        BacktoMainMenu.Location = New Point(562, 21)
        BacktoMainMenu.Name = "BacktoMainMenu"
        BacktoMainMenu.Size = New Size(112, 34)
        BacktoMainMenu.TabIndex = 12
        BacktoMainMenu.Text = "Back"
        BacktoMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(26, 26)
        Label5.Name = "Label5"
        Label5.Size = New Size(126, 25)
        Label5.TabIndex = 13
        Label5.Text = "IncidentID No."
        ' 
        ' cboCyberIncidentIDs
        ' 
        cboCyberIncidentIDs.FormattingEnabled = True
        cboCyberIncidentIDs.Location = New Point(148, 23)
        cboCyberIncidentIDs.Name = "cboCyberIncidentIDs"
        cboCyberIncidentIDs.Size = New Size(182, 33)
        cboCyberIncidentIDs.TabIndex = 14
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(38, 513)
        Label6.Name = "Label6"
        Label6.Size = New Size(128, 25)
        Label6.TabIndex = 15
        Label6.Text = "Incident Status"
        ' 
        ' cboIncidentStatus
        ' 
        cboIncidentStatus.FormattingEnabled = True
        cboIncidentStatus.Location = New Point(178, 510)
        cboIncidentStatus.Name = "cboIncidentStatus"
        cboIncidentStatus.Size = New Size(300, 33)
        cboIncidentStatus.TabIndex = 16
        ' 
        ' dtpIncidentDate
        ' 
        dtpIncidentDate.Location = New Point(178, 263)
        dtpIncidentDate.Name = "dtpIncidentDate"
        dtpIncidentDate.Size = New Size(300, 31)
        dtpIncidentDate.TabIndex = 17
        ' 
        ' btnViewCybesecurityIncidents
        ' 
        btnViewCybesecurityIncidents.Location = New Point(535, 361)
        btnViewCybesecurityIncidents.Name = "btnViewCybesecurityIncidents"
        btnViewCybesecurityIncidents.Size = New Size(252, 34)
        btnViewCybesecurityIncidents.TabIndex = 18
        btnViewCybesecurityIncidents.Text = "View Cybersecurity Incidents"
        btnViewCybesecurityIncidents.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(148, 108)
        Label7.Name = "Label7"
        Label7.Size = New Size(570, 50)
        Label7.TabIndex = 19
        Label7.Text = "CYBERSECURITY INCIDENTS"
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        btnMainMenu.Location = New Point(700, 21)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(136, 34)
        btnMainMenu.TabIndex = 20
        btnMainMenu.Text = "MAIN MENU"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(38, 178)
        Label8.Name = "Label8"
        Label8.Size = New Size(56, 25)
        Label8.TabIndex = 21
        Label8.Text = "Client"
        ' 
        ' cboClient
        ' 
        cboClient.FormattingEnabled = True
        cboClient.Location = New Point(178, 170)
        cboClient.Name = "cboClient"
        cboClient.Size = New Size(300, 33)
        cboClient.TabIndex = 22
        ' 
        ' CybersecurityIncidents
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(837, 612)
        Controls.Add(cboClient)
        Controls.Add(Label8)
        Controls.Add(btnMainMenu)
        Controls.Add(Label7)
        Controls.Add(btnViewCybesecurityIncidents)
        Controls.Add(dtpIncidentDate)
        Controls.Add(cboIncidentStatus)
        Controls.Add(Label6)
        Controls.Add(cboCyberIncidentIDs)
        Controls.Add(Label5)
        Controls.Add(BacktoMainMenu)
        Controls.Add(txtIncidentDescription)
        Controls.Add(cboAccountName)
        Controls.Add(cboIncidentType)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnViewIncidentTypes)
        Controls.Add(btnUpdateIncident)
        Controls.Add(btnAddIncident)
        Name = "CybersecurityIncidents"
        Text = "CybersecurityIncidents"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAddIncident As Button
    Friend WithEvents btnUpdateIncident As Button
    Friend WithEvents btnViewIncidentTypes As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboIncidentType As ComboBox
    Friend WithEvents cboAccountName As ComboBox
    Friend WithEvents txtIncidentDescription As TextBox
    Friend WithEvents BacktoMainMenu As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cboCyberIncidentIDs As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboIncidentStatus As ComboBox
    Friend WithEvents dtpIncidentDate As DateTimePicker
    Friend WithEvents btnViewCybesecurityIncidents As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents btnMainMenu As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cboClient As ComboBox
End Class
