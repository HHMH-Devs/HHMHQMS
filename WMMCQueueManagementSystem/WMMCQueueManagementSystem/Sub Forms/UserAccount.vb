Public Class UserAccount

    Private Sub DeleteUserAccount()
        If dgvServer.SelectedRows.Count > 0 Then
            If dgvServer.SelectedRows.Count > 1 Then
                MessageBox.Show("Deleting all these user will also delete all other informations and transaction of all these user", "Delete Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Are you sure you want to delete these user?", "Delete Multiple User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim ids As New List(Of Long)
                    For Each rows As DataGridViewRow In dgvServer.SelectedRows
                        ids.Add(rows.Cells("serverid").Value)
                    Next
                    Dim serverController As New ServerController
                    If serverController.DeleteMultipleServer(ids) Then
                        LoadServers()
                        MessageBox.Show("User accounts deleted successfuly", "Multiple Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("There was an error during the process.", "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Else
                MessageBox.Show("Deleting this user will also delete all other informations and transaction of this user", "Delete Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                If MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim serverController As New ServerController
                    If serverController.DeleteServer(dgvServer.SelectedRows(0).Cells("serverid").Value) Then
                        LoadServers()
                        MessageBox.Show("User account deleted successfuly", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("There was an error during the process.", "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Else
            MessageBox.Show("Select a user you want to delete", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub UserAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadServers()
    End Sub

    Private Sub LoadServers()
        Dim serverController As New ServerController
        Dim servers As List(Of Server) = serverController.GetAllServers
        dgvServer.Rows.Clear()
        If Not IsNothing(servers) Then
            Dim ctr As Long = 0
            For Each server As Server In servers
                Dim acctype As String = ""
                If server.AccountType = 1 Then
                    acctype = "CLINICAL DOCTOR"
                Else
                    acctype = "EMPLOYEE"
                End If
                dgvServer.Rows.Add(server.Server_ID, server.EmmployeeID, server.FullName, server.AssignDepartment, acctype)
                dgvServer.Rows(ctr).Height = 50
                ctr += 1
            Next
        End If
    End Sub

    Private Sub NewServer()
        Dim frm As New frmManageServer
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            LoadServers()
        End If
    End Sub

    Private Sub UpdateUser()
        If dgvServer.SelectedRows.Count > 0 Then
            Dim serverController As New ServerController
            Dim server As server = serverController.GetCertainServer(dgvServer.SelectedRows(0).Cells("serverid").Value)
            Dim frm As New frmManageServer(server)
            frm.ShowDialog()
            If frm.DialogResult = DialogResult.Yes Then
                LoadServers()
            End If
        End If
    End Sub

    Private Sub ManageCounters()
        If dgvServer.SelectedRows.Count > 0 Then
            Dim serverController As New ServerController
            Dim server As Server = serverController.GetCertainServer(dgvServer.SelectedRows(0).Cells("serverid").Value)
            If Not IsNothing(server) Then
                If server.AccountType = 0 Then
                    Dim frm As New frmManageServerAssignCounter(server)
                    frm.ShowDialog()
                    If frm.DialogResult = DialogResult.Yes Then
                        LoadServers()
                    End If
                ElseIf server.AccountType = 1 Then
                    Dim frm As New frmManageDoctorsClinic(server)
                    frm.ShowDialog(Me)
                End If
            Else
                MessageBox.Show("The selected user cannot be found. Please try again", "No User Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("There was an errror during the process", "Counter Assignment", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtTextFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTextFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dgvServer.Rows.Count - 1
                If dgvServer.Rows(x).Cells("employeeid").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Or dgvServer.Rows(x).Cells("fullname").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Or dgvServer.Rows(x).Cells("assigndeparment").Value.ToString.ToLower.Contains(txtTextFilter.Text.ToLower) Then
                    dgvServer.Rows(x).Visible = True
                Else
                    dgvServer.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateUser()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteUserAccount()
    End Sub

    Private Sub dvgServers_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvServer.MouseClick
        If e.Button = MouseButtons.Right Then
            If dgvServer.SelectedRows.Count > 0 Then
                UserAccountStrip.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub DeleteUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteUserToolStripMenuItem.Click
        DeleteUserAccount()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        NewServer()
    End Sub

    Private Sub UpdateUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateUserToolStripMenuItem.Click
        UpdateUser()
    End Sub

    Private Sub NewUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewUserToolStripMenuItem.Click
        NewServer()
    End Sub

    Private Sub ManageAssignedCountesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageAssignedCountesToolStripMenuItem.Click
        ManageCounters()
    End Sub

    Private Sub btnManageCounter_Click(sender As Object, e As EventArgs) Handles btnManageCounter.Click
        ManageCounters()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
