Public Class frmAdminHome
    Private subFormCtr As Integer
    Private Function MarkLabelSelected(btn As Button) As Boolean
        Try
            btnHome.BackColor = Color.LimeGreen
            btnAccounts.BackColor = Color.LimeGreen
            btnCounters.BackColor = Color.LimeGreen
            btnReporting.BackColor = Color.LimeGreen
            btnAdvert.BackColor = Color.LimeGreen

            btnHome.Font = New Font(btnHome.Font, FontStyle.Regular)
            btnAccounts.Font = New Font(btnAccounts.Font, FontStyle.Regular)
            btnCounters.Font = New Font(btnCounters.Font, FontStyle.Regular)
            btnReporting.Font = New Font(btnCounters.Font, FontStyle.Regular)
            btnAdvert.Font = New Font(btnCounters.Font, FontStyle.Regular)

            btn.BackColor = Color.ForestGreen
            btn.Font = New Font(btn.Font, FontStyle.Bold)
            Return True
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub frmAdminHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MarkLabelSelected(btnHome) Then
            lblTittleBox.Text = "MAIN MENU"
            Dim uc As New Dashboard
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub btnAccounts_Click(sender As Object, e As EventArgs) Handles btnAccounts.Click
        If MarkLabelSelected(btnAccounts) And Not subFormCtr = 1 Then
            lblTittleBox.Text = "USER ACCOUNTS"
            subFormCtr = 1
            Dim uc As New UserAccount
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click

        If MarkLabelSelected(btnHome) And Not subFormCtr = 0 Then
            lblTittleBox.Text = "MAIN MENU"
            subFormCtr = 0
            Dim uc As New Dashboard
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub btnCounters_Click(sender As Object, e As EventArgs) Handles btnCounters.Click
        If MarkLabelSelected(btnCounters) And Not subFormCtr = 2 Then
            lblTittleBox.Text = "COUNTERS"
            subFormCtr = 2
            Dim uc As New Counters
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub pnlUc_Paint(sender As Object, e As PaintEventArgs) Handles pnlUc.Paint

    End Sub

    Private Sub frmAdminHome_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not MessageBox.Show("Are you sure do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            e.Cancel = True
        Else
            frmAllQueueBoard_Test.Close()
            frmAllQueueBoardStandalone.Close()
        End If
    End Sub

    Private Sub btnReporting_Click(sender As Object, e As EventArgs) Handles btnReporting.Click
        If MarkLabelSelected(btnReporting) And Not subFormCtr = 3 Then
            lblTittleBox.Text = "REPORTING"
            subFormCtr = 3
            Dim uc As New Reporting
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub btnAdvert_Click(sender As Object, e As EventArgs) Handles btnAdvert.Click
        If MarkLabelSelected(btnAdvert) And Not subFormCtr = 4 Then
            lblTittleBox.Text = "ADVERTISEMENT"
            subFormCtr = 4
            Dim uc As New adsmanager
            uc.Dock = DockStyle.Fill
            pnlUc.Controls.Clear()
            pnlUc.Controls.Add(uc)
        End If
    End Sub

    Private Sub lblTittleBox_Click(sender As Object, e As EventArgs) Handles lblTittleBox.Click

    End Sub
End Class