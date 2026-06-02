<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCybersecurityIncidents
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
        dgvShowCybersecurityIncidents = New DataGridView()
        btnDeleteIncident = New Button()
        btnResolveIncident = New Button()
        cboCbID = New ComboBox()
        Label1 = New Label()
        btnBack = New Button()
        btnMainMenu = New Button()
        Label2 = New Label()
        Label3 = New Label()
        cboIncidentIDList = New ComboBox()
        lblnoIncidents = New Label()
        CType(dgvShowCybersecurityIncidents, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvShowCybersecurityIncidents
        ' 
        dgvShowCybersecurityIncidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvShowCybersecurityIncidents.Location = New Point(50, 190)
        dgvShowCybersecurityIncidents.Name = "dgvShowCybersecurityIncidents"
        dgvShowCybersecurityIncidents.RowHeadersWidth = 62
        dgvShowCybersecurityIncidents.Size = New Size(797, 329)
        dgvShowCybersecurityIncidents.TabIndex = 0
        ' 
        ' btnDeleteIncident
        ' 
        btnDeleteIncident.Font = New Font("Segoe UI", 10F)
        btnDeleteIncident.Location = New Point(209, 541)
        btnDeleteIncident.Name = "btnDeleteIncident"
        btnDeleteIncident.Size = New Size(158, 34)
        btnDeleteIncident.TabIndex = 1
        btnDeleteIncident.Text = "DeleteIncident"
        btnDeleteIncident.UseVisualStyleBackColor = True
        ' 
        ' btnResolveIncident
        ' 
        btnResolveIncident.Font = New Font("Segoe UI", 10F)
        btnResolveIncident.Location = New Point(472, 541)
        btnResolveIncident.Name = "btnResolveIncident"
        btnResolveIncident.Size = New Size(175, 34)
        btnResolveIncident.TabIndex = 2
        btnResolveIncident.Text = "ResolveIncident"
        btnResolveIncident.UseVisualStyleBackColor = True
        ' 
        ' cboCbID
        ' 
        cboCbID.FormattingEnabled = True
        cboCbID.Location = New Point(164, 22)
        cboCbID.Name = "cboCbID"
        cboCbID.Size = New Size(111, 33)
        cboCbID.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(30, 30)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 25)
        Label1.TabIndex = 4
        Label1.Text = "AccountID No."
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(671, 12)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(112, 34)
        btnBack.TabIndex = 5
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Location = New Point(816, 12)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(112, 34)
        btnMainMenu.TabIndex = 6
        btnMainMenu.Text = "MainMenu"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(119, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(687, 50)
        Label2.TabIndex = 7
        Label2.Text = "VIEW CYBERSECURITY INCIDENTS"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(30, 79)
        Label3.Name = "Label3"
        Label3.Size = New Size(232, 25)
        Label3.TabIndex = 8
        Label3.Text = "CybersecurityIncidentID No."
        ' 
        ' cboIncidentIDList
        ' 
        cboIncidentIDList.FormattingEnabled = True
        cboIncidentIDList.Location = New Point(268, 71)
        cboIncidentIDList.Name = "cboIncidentIDList"
        cboIncidentIDList.Size = New Size(182, 33)
        cboIncidentIDList.TabIndex = 9
        ' 
        ' lblnoIncidents
        ' 
        lblnoIncidents.BackColor = SystemColors.ControlDark
        lblnoIncidents.Enabled = False
        lblnoIncidents.Location = New Point(254, 324)
        lblnoIncidents.Name = "lblnoIncidents"
        lblnoIncidents.Size = New Size(393, 25)
        lblnoIncidents.TabIndex = 10
        lblnoIncidents.Text = "THERE ARE NO INCIDENTS FOR THIS ACCOUNT"
        lblnoIncidents.TextAlign = ContentAlignment.MiddleCenter
        lblnoIncidents.Visible = False
        ' 
        ' ViewCybersecurityIncidents
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(940, 595)
        Controls.Add(lblnoIncidents)
        Controls.Add(cboIncidentIDList)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnMainMenu)
        Controls.Add(btnBack)
        Controls.Add(Label1)
        Controls.Add(cboCbID)
        Controls.Add(btnResolveIncident)
        Controls.Add(btnDeleteIncident)
        Controls.Add(dgvShowCybersecurityIncidents)
        Name = "ViewCybersecurityIncidents"
        Text = "ViewCybersecurityIncidents"
        CType(dgvShowCybersecurityIncidents, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvShowCybersecurityIncidents As DataGridView
    Friend WithEvents btnDeleteIncident As Button
    Friend WithEvents btnResolveIncident As Button
    Friend WithEvents cboCbID As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnMainMenu As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboIncidentIDList As ComboBox
    Friend WithEvents lblnoIncidents As Label
End Class
