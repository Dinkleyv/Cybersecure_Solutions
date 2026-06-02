<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServicesProvided
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
        btnBacktoMainMenu = New Button()
        Label1 = New Label()
        Label2 = New Label()
        txtServiceName = New TextBox()
        txtServiceDescription = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        cboServicesID = New ComboBox()
        btnViewServices = New Button()
        btnAddService = New Button()
        btnUpdateService = New Button()
        btnDeleteService = New Button()
        dgvShowServices = New DataGridView()
        btnMainMenu = New Button()
        CType(dgvShowServices, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnBacktoMainMenu
        ' 
        btnBacktoMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        btnBacktoMainMenu.Location = New Point(522, 12)
        btnBacktoMainMenu.Name = "btnBacktoMainMenu"
        btnBacktoMainMenu.Size = New Size(112, 34)
        btnBacktoMainMenu.TabIndex = 0
        btnBacktoMainMenu.Text = "Back"
        btnBacktoMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(64, 172)
        Label1.Name = "Label1"
        Label1.Size = New Size(119, 25)
        Label1.TabIndex = 1
        Label1.Text = "Service Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(64, 238)
        Label2.Name = "Label2"
        Label2.Size = New Size(102, 25)
        Label2.TabIndex = 2
        Label2.Text = "Description"
        ' 
        ' txtServiceName
        ' 
        txtServiceName.Location = New Point(189, 172)
        txtServiceName.Name = "txtServiceName"
        txtServiceName.Size = New Size(269, 31)
        txtServiceName.TabIndex = 3
        ' 
        ' txtServiceDescription
        ' 
        txtServiceDescription.Location = New Point(182, 238)
        txtServiceDescription.Multiline = True
        txtServiceDescription.Name = "txtServiceDescription"
        txtServiceDescription.Size = New Size(276, 130)
        txtServiceDescription.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(170, 68)
        Label3.Name = "Label3"
        Label3.Size = New Size(424, 50)
        Label3.TabIndex = 5
        Label3.Text = "SERVICES PROVIDED"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(126, 25)
        Label4.TabIndex = 6
        Label4.Text = "ServicesID No."
        ' 
        ' cboServicesID
        ' 
        cboServicesID.FormattingEnabled = True
        cboServicesID.Location = New Point(155, 12)
        cboServicesID.Name = "cboServicesID"
        cboServicesID.Size = New Size(96, 33)
        cboServicesID.TabIndex = 7
        ' 
        ' btnViewServices
        ' 
        btnViewServices.Location = New Point(566, 132)
        btnViewServices.Name = "btnViewServices"
        btnViewServices.Size = New Size(172, 34)
        btnViewServices.TabIndex = 8
        btnViewServices.Text = "View Services"
        btnViewServices.UseVisualStyleBackColor = True
        ' 
        ' btnAddService
        ' 
        btnAddService.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold)
        btnAddService.Location = New Point(96, 407)
        btnAddService.Name = "btnAddService"
        btnAddService.Size = New Size(112, 34)
        btnAddService.TabIndex = 9
        btnAddService.Text = "ADD"
        btnAddService.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateService
        ' 
        btnUpdateService.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold)
        btnUpdateService.Location = New Point(261, 407)
        btnUpdateService.Name = "btnUpdateService"
        btnUpdateService.Size = New Size(112, 34)
        btnUpdateService.TabIndex = 10
        btnUpdateService.Text = "UPDATE"
        btnUpdateService.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteService
        ' 
        btnDeleteService.Font = New Font("Segoe UI Black", 10F, FontStyle.Bold)
        btnDeleteService.Location = New Point(438, 407)
        btnDeleteService.Name = "btnDeleteService"
        btnDeleteService.Size = New Size(112, 34)
        btnDeleteService.TabIndex = 11
        btnDeleteService.Text = "DELETE"
        btnDeleteService.UseVisualStyleBackColor = True
        ' 
        ' dgvShowServices
        ' 
        dgvShowServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvShowServices.Location = New Point(497, 172)
        dgvShowServices.Name = "dgvShowServices"
        dgvShowServices.RowHeadersWidth = 62
        dgvShowServices.Size = New Size(304, 225)
        dgvShowServices.TabIndex = 12
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        btnMainMenu.Location = New Point(640, 12)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(148, 34)
        btnMainMenu.TabIndex = 13
        btnMainMenu.Text = "MAIN MENU"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' ServicesProvided
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(815, 450)
        Controls.Add(btnMainMenu)
        Controls.Add(dgvShowServices)
        Controls.Add(btnDeleteService)
        Controls.Add(btnUpdateService)
        Controls.Add(btnAddService)
        Controls.Add(btnViewServices)
        Controls.Add(cboServicesID)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(txtServiceDescription)
        Controls.Add(txtServiceName)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnBacktoMainMenu)
        Name = "ServicesProvided"
        Text = "ServicesProvided"
        CType(dgvShowServices, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBacktoMainMenu As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtServiceName As TextBox
    Friend WithEvents txtServiceDescription As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboServicesID As ComboBox
    Friend WithEvents btnViewServices As Button
    Friend WithEvents btnAddService As Button
    Friend WithEvents btnUpdateService As Button
    Friend WithEvents btnDeleteService As Button
    Friend WithEvents dgvShowServices As DataGridView
    Friend WithEvents btnMainMenu As Button
End Class
