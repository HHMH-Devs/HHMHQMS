Public Class frmManageNurseNotes
    Private NurseNote As NurseNote

    Sub New(nurseNote As NurseNote)
        ' This call is required by the designer.
        InitializeComponent()
        Me.NurseNote = nurseNote
    End Sub

    Private Sub frmManageNurseNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each nurseNoteItem As NurseNoteItem In Me.NurseNote.NurseOrderItems
            dgvClinicList.Rows.Add(nurseNoteItem.Item_ID, Format(nurseNoteItem.DateCreated, "MMM dd, yyyy HH:mm tt"), nurseNoteItem.Focus, nurseNoteItem.DataActions)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim index As Integer = -1
        Try
            index = dgvClinicList.SelectedCells.Item(0).RowIndex
            If index = dgvClinicList.Rows.Count - 1 Then
                index = -1
            End If
        Catch ex As Exception
            index = -1
        End Try
        If index >= 0 Then
            dgvClinicList.Rows.Remove(dgvClinicList.Rows(index))
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Are you sure to save the changes made?", "Save Nurse Notes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim nurseNotes As New List(Of NurseNoteItem)
            For i As Integer = 0 To dgvClinicList.Rows.Count - 1
                Dim nurseNote As New NurseNoteItem
                If Not IsNothing(dgvClinicList.Rows(i).Cells("focus").Value) Or Not IsNothing(dgvClinicList.Rows(i).Cells("dataaction").Value) Then
                    nurseNote.Item_ID = If(Not IsNothing(dgvClinicList.Rows(i).Cells("id").Value), dgvClinicList.Rows(i).Cells("id").Value, 0)
                    nurseNote.DateCreated = If(Not IsNothing(dgvClinicList.Rows(i).Cells("dateShift").Value), dgvClinicList.Rows(i).Cells("dateShift").Value, Today)
                    nurseNote.Focus = If(Not IsNothing(dgvClinicList.Rows(i).Cells("focus").Value), dgvClinicList.Rows(i).Cells("focus").Value.ToString.Trim.ToUpper, "")
                    nurseNote.DataActions = If(Not IsNothing(dgvClinicList.Rows(i).Cells("dataaction").Value), dgvClinicList.Rows(i).Cells("dataaction").Value.ToString.Trim.ToUpper, "")
                    nurseNote.FK_FormID = Me.NurseNote.Form_ID
                    nurseNotes.Add(nurseNote)
                End If
            Next
            Dim consultController As New CustomerConsultationController
            If consultController.SaveNurseNoteItems(Me.NurseNote.Form_ID, nurseNotes) Then
                Me.DialogResult = DialogResult.Yes
            End If
        End If
    End Sub

    Private Sub dgvClinicList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClinicList.CellContentClick

    End Sub

    Private Sub dgvClinicList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClinicList.CellDoubleClick

    End Sub

    Private Sub dgvClinicList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClinicList.CellClick
        If e.ColumnIndex = 1 Then
            Dim frm As New frmDatePicker2
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Yes Then
                dgvClinicList.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = frm.SelectedDate
            End If
        End If
    End Sub
End Class