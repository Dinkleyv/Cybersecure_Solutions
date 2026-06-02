<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubAccounts
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
        btnAddSubscription = New Button()
        btnDeleteSubscription = New Button()
        Label1 = New Label()
        Label2 = New Label()
        dgvShowSubscriptions = New DataGridView()
        cboClientList = New ComboBox()
        cboAccountList = New ComboBox()
        btnBacktoAccounts = New Button()
        btnMainMenu = New Button()
        Label3 = New Label()
        lblNoSubscriptions = New Label()
        CType(dgvShowSubscriptions, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAddSubscription
        ' 
        btnAddSubscription.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddSubscription.Location = New Point(116, 553)
        btnAddSubscription.Name = "btnAddSubscription"
        btnAddSubscription.Size = New Size(198, 75)
        btnAddSubscription.TabIndex = 0
        btnAddSubscription.Text = "ADD SUBSCRIPTIONS"
        btnAddSubscription.UseVisualStyleBackColor = True
        ' 
        ' btnDeleteSubscription
        ' 
        btnDeleteSubscription.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteSubscription.Location = New Point(364, 553)
        btnDeleteSubscription.Name = "btnDeleteSubscription"
        btnDeleteSubscription.Size = New Size(224, 75)
        btnDeleteSubscription.TabIndex = 1
        btnDeleteSubscription.Text = "REMOVE SUBSCRIPTIONS"
        btnDeleteSubscription.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(62, 197)
        Label1.Name = "Label1"
        Label1.Size = New Size(56, 25)
        Label1.TabIndex = 2
        Label1.Text = "Client"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(440, 197)
        Label2.Name = "Label2"
        Label2.Size = New Size(85, 25)
        Label2.TabIndex = 3
        Label2.Text = "Accounts"
        ' 
        ' dgvShowSubscriptions
        ' 
        dgvShowSubscriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvShowSubscriptions.Location = New Point(51, 257)
        dgvShowSubscriptions.Name = "dgvShowSubscriptions"
        dgvShowSubscriptions.RowHeadersWidth = 62
        dgvShowSubscriptions.Size = New Size(857, 275)
        dgvShowSubscriptions.TabIndex = 4
        ' 
        ' cboClientList
        ' 
        cboClientList.FormattingEnabled = True
        cboClientList.Location = New Point(151, 192)
        cboClientList.Name = "cboClientList"
        cboClientList.Size = New Size(182, 33)
        cboClientList.TabIndex = 5
        ' 
        ' cboAccountList
        ' 
        cboAccountList.FormattingEnabled = True
        cboAccountList.Location = New Point(551, 189)
        cboAccountList.Name = "cboAccountList"
        cboAccountList.Size = New Size(182, 33)
        cboAccountList.TabIndex = 6
        ' 
        ' btnBacktoAccounts
        ' 
        btnBacktoAccounts.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        btnBacktoAccounts.Location = New Point(538, 12)
        btnBacktoAccounts.Name = "btnBacktoAccounts"
        btnBacktoAccounts.Size = New Size(227, 34)
        btnBacktoAccounts.TabIndex = 7
        btnBacktoAccounts.Text = "BACK TO ACCOUNTS"
        btnBacktoAccounts.UseVisualStyleBackColor = True
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold)
        btnMainMenu.Location = New Point(782, 12)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(126, 34)
        btnMainMenu.TabIndex = 8
        btnMainMenu.Text = "Main Menu"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.Highlight
        Label3.Location = New Point(192, 98)
        Label3.Name = "Label3"
        Label3.Size = New Size(586, 50)
        Label3.TabIndex = 10
        Label3.Text = "VIEW SERVICE BY ACCOUNTS"
        ' 
        ' lblNoSubscriptions
        ' 
        lblNoSubscriptions.BackColor = SystemColors.ButtonShadow
        lblNoSubscriptions.Font = New Font("Algerian", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNoSubscriptions.Location = New Point(343, 374)
        lblNoSubscriptions.Name = "lblNoSubscriptions"
        lblNoSubscriptions.Size = New Size(386, 25)
        lblNoSubscriptions.TabIndex = 12
        lblNoSubscriptions.Text = "NO SUBSCRIPTIONS FOUND "
        lblNoSubscriptions.TextAlign = ContentAlignment.MiddleCenter
        lblNoSubscriptions.Visible = False
        ' 
        ' SubAccounts
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(920, 640)
        Controls.Add(lblNoSubscriptions)
        Controls.Add(Label3)
        Controls.Add(btnMainMenu)
        Controls.Add(btnBacktoAccounts)
        Controls.Add(cboAccountList)
        Controls.Add(cboClientList)
        Controls.Add(dgvShowSubscriptions)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnDeleteSubscription)
        Controls.Add(btnAddSubscription)
        Name = "SubAccounts"
        Text = "SubAccounts"
        CType(dgvShowSubscriptions, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAddSubscription As Button
    Friend WithEvents btnDeleteSubscription As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvShowSubscriptions As DataGridView
    Friend WithEvents cboClientList As ComboBox
    Friend WithEvents cboAccountList As ComboBox
    Friend WithEvents btnBacktoAccounts As Button
    Friend WithEvents btnMainMenu As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNoSubscriptions As Label
End Class
