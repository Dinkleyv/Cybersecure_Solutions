<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnOpenClients = New Button()
        btnOpenAccounts = New Button()
        btnOpenServices = New Button()
        btnOpencyberIncidents = New Button()
        btnSubscriptions = New Button()
        btnTestConnection = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' btnOpenClients
        ' 
        btnOpenClients.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnOpenClients.Location = New Point(141, 165)
        btnOpenClients.Name = "btnOpenClients"
        btnOpenClients.Size = New Size(188, 39)
        btnOpenClients.TabIndex = 0
        btnOpenClients.Text = "CLIENTS"
        btnOpenClients.UseVisualStyleBackColor = True
        ' 
        ' btnOpenAccounts
        ' 
        btnOpenAccounts.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnOpenAccounts.Location = New Point(141, 233)
        btnOpenAccounts.Name = "btnOpenAccounts"
        btnOpenAccounts.Size = New Size(188, 39)
        btnOpenAccounts.TabIndex = 1
        btnOpenAccounts.Text = "ACCOUNTS"
        btnOpenAccounts.UseVisualStyleBackColor = True
        ' 
        ' btnOpenServices
        ' 
        btnOpenServices.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnOpenServices.Location = New Point(418, 165)
        btnOpenServices.Name = "btnOpenServices"
        btnOpenServices.Size = New Size(188, 39)
        btnOpenServices.TabIndex = 2
        btnOpenServices.Text = "SERVICES PROVIDED"
        btnOpenServices.UseVisualStyleBackColor = True
        ' 
        ' btnOpencyberIncidents
        ' 
        btnOpencyberIncidents.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnOpencyberIncidents.Location = New Point(221, 301)
        btnOpencyberIncidents.Name = "btnOpencyberIncidents"
        btnOpencyberIncidents.Size = New Size(287, 39)
        btnOpencyberIncidents.TabIndex = 3
        btnOpencyberIncidents.Text = "CYBER INCIDENTS"
        btnOpencyberIncidents.UseVisualStyleBackColor = True
        ' 
        ' btnSubscriptions
        ' 
        btnSubscriptions.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        btnSubscriptions.Location = New Point(418, 233)
        btnSubscriptions.Name = "btnSubscriptions"
        btnSubscriptions.Size = New Size(188, 39)
        btnSubscriptions.TabIndex = 4
        btnSubscriptions.Text = "SUBSCRIPTIONS"
        btnSubscriptions.UseVisualStyleBackColor = True
        ' 
        ' btnTestConnection
        ' 
        btnTestConnection.Location = New Point(12, 403)
        btnTestConnection.Name = "btnTestConnection"
        btnTestConnection.Size = New Size(58, 35)
        btnTestConnection.TabIndex = 5
        btnTestConnection.Text = "test connection"
        btnTestConnection.UseVisualStyleBackColor = True
        btnTestConnection.Visible = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Showcard Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HotTrack
        Label1.Location = New Point(255, 80)
        Label1.Name = "Label1"
        Label1.Size = New Size(244, 50)
        Label1.TabIndex = 6
        Label1.Text = "MAIN MENU"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(btnTestConnection)
        Controls.Add(btnSubscriptions)
        Controls.Add(btnOpencyberIncidents)
        Controls.Add(btnOpenServices)
        Controls.Add(btnOpenAccounts)
        Controls.Add(btnOpenClients)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnOpenClients As Button
    Friend WithEvents btnOpenAccounts As Button
    Friend WithEvents btnOpenServices As Button
    Friend WithEvents btnOpencyberIncidents As Button
    Friend WithEvents btnSubscriptions As Button
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents Label1 As Label

End Class
