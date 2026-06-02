<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Subscriptions
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
        btnToMainMenu = New Button()
        Label1 = New Label()
        cboServiceList = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        cboClientList = New ComboBox()
        cboAccounts = New ComboBox()
        dtpStartDate = New DateTimePicker()
        dtpEndDate = New DateTimePicker()
        Label6 = New Label()
        btnAddSubscription = New Button()
        btnViewSubscriptions = New Button()
        btnMainMenu = New Button()
        SuspendLayout()
        ' 
        ' btnToMainMenu
        ' 
        btnToMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnToMainMenu.Location = New Point(673, 12)
        btnToMainMenu.Name = "btnToMainMenu"
        btnToMainMenu.Size = New Size(112, 34)
        btnToMainMenu.TabIndex = 0
        btnToMainMenu.Text = "Back"
        btnToMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(49, 263)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 25)
        Label1.TabIndex = 1
        Label1.Text = "Service"
        ' 
        ' cboServiceList
        ' 
        cboServiceList.FormattingEnabled = True
        cboServiceList.Location = New Point(140, 255)
        cboServiceList.Name = "cboServiceList"
        cboServiceList.Size = New Size(182, 33)
        cboServiceList.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(49, 199)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 25)
        Label2.TabIndex = 3
        Label2.Text = "Account"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(49, 136)
        Label3.Name = "Label3"
        Label3.Size = New Size(56, 25)
        Label3.TabIndex = 4
        Label3.Text = "Client"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(412, 144)
        Label4.Name = "Label4"
        Label4.Size = New Size(90, 25)
        Label4.TabIndex = 5
        Label4.Text = "Start Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(412, 255)
        Label5.Name = "Label5"
        Label5.Size = New Size(84, 25)
        Label5.TabIndex = 6
        Label5.Text = "End Date"
        ' 
        ' cboClientList
        ' 
        cboClientList.FormattingEnabled = True
        cboClientList.Location = New Point(140, 136)
        cboClientList.Name = "cboClientList"
        cboClientList.Size = New Size(182, 33)
        cboClientList.TabIndex = 7
        ' 
        ' cboAccounts
        ' 
        cboAccounts.FormattingEnabled = True
        cboAccounts.Location = New Point(140, 191)
        cboAccounts.Name = "cboAccounts"
        cboAccounts.Size = New Size(182, 33)
        cboAccounts.TabIndex = 8
        ' 
        ' dtpStartDate
        ' 
        dtpStartDate.Location = New Point(523, 136)
        dtpStartDate.Name = "dtpStartDate"
        dtpStartDate.Size = New Size(302, 31)
        dtpStartDate.TabIndex = 11
        ' 
        ' dtpEndDate
        ' 
        dtpEndDate.Location = New Point(525, 249)
        dtpEndDate.Name = "dtpEndDate"
        dtpEndDate.Size = New Size(300, 31)
        dtpEndDate.TabIndex = 12
        dtpEndDate.Value = New Date(2025, 5, 14, 0, 0, 0, 0)
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(280, 58)
        Label6.Name = "Label6"
        Label6.Size = New Size(338, 50)
        Label6.TabIndex = 13
        Label6.Text = "SUBSCRIPTIONS"
        ' 
        ' btnAddSubscription
        ' 
        btnAddSubscription.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnAddSubscription.Location = New Point(227, 310)
        btnAddSubscription.Name = "btnAddSubscription"
        btnAddSubscription.Size = New Size(112, 34)
        btnAddSubscription.TabIndex = 14
        btnAddSubscription.Text = "ADD"
        btnAddSubscription.UseVisualStyleBackColor = True
        ' 
        ' btnViewSubscriptions
        ' 
        btnViewSubscriptions.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnViewSubscriptions.Location = New Point(413, 310)
        btnViewSubscriptions.Name = "btnViewSubscriptions"
        btnViewSubscriptions.Size = New Size(205, 34)
        btnViewSubscriptions.TabIndex = 15
        btnViewSubscriptions.Text = "ViewSubscriptions"
        btnViewSubscriptions.UseVisualStyleBackColor = True
        ' 
        ' btnMainMenu
        ' 
        btnMainMenu.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnMainMenu.Location = New Point(791, 12)
        btnMainMenu.Name = "btnMainMenu"
        btnMainMenu.Size = New Size(143, 34)
        btnMainMenu.TabIndex = 16
        btnMainMenu.Text = "MAIN MENU"
        btnMainMenu.UseVisualStyleBackColor = True
        ' 
        ' Subscriptions
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(946, 398)
        Controls.Add(btnMainMenu)
        Controls.Add(btnViewSubscriptions)
        Controls.Add(btnAddSubscription)
        Controls.Add(Label6)
        Controls.Add(dtpEndDate)
        Controls.Add(dtpStartDate)
        Controls.Add(cboAccounts)
        Controls.Add(cboClientList)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(cboServiceList)
        Controls.Add(Label1)
        Controls.Add(btnToMainMenu)
        Name = "Subscriptions"
        Text = "Subscriptions"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnToMainMenu As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboServiceList As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboClientList As ComboBox
    Friend WithEvents cboAccounts As ComboBox
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddSubscription As Button
    Friend WithEvents btnViewSubscriptions As Button
    Friend WithEvents btnMainMenu As Button
End Class
