Public Class frmNoGenerated
    Private _ticketNumber As String = ""
    Private _patientName As String = ""
    Private _counterName As String = ""
    Private _notes As String = ""

    Sub New(ticketNumber As String, patientName As String, counterName As String, notes As String)
        InitializeComponent()
        _ticketNumber = ticketNumber
        _patientName = patientName
        _counterName = counterName
        _notes = notes
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmNoGenerated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblGeneratedNumber.Text = _ticketNumber
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Do you want to print the number?", "Print Number", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Try
                Dim reportDocs As New ticketNoReport
                Dim dt As New DataTable
                With dt.Columns
                    .Add("ticketNo")
                    .Add("patName")
                    .Add("counter")
                    .Add("note")
                End With
                dt.Rows.Add(_ticketNumber, _patientName, _counterName, _notes)
                reportDocs.SetDataSource(dt)
                reportDocs.PrintToPrinter(1, False, 0, 0)
                reportDocs.Close()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("Printing Error. Please check your printer", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class