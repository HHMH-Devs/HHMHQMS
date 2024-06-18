Imports System.Drawing.Imaging
Imports System.IO
Imports Spire.Barcode

Public Class frmNoGenerated
    Private _ticketNumber As String = ""
    Private _patientName As String = ""
    Private _counterName As String = ""
    Private _notes As String = ""
    Private _fk_emdPatients As String = ""

    Sub New(ticketNumber As String, patientName As String, counterName As String, notes As String, fkemdpat As String)
        InitializeComponent()
        _ticketNumber = ticketNumber
        _patientName = patientName
        _counterName = counterName
        _notes = notes
        _fk_emdPatients = fkemdpat
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
                    .Add("ticketNo", GetType(String))
                    .Add("patName", GetType(String))
                    .Add("counter", GetType(String))
                    .Add("note", GetType(String))
                    .Add("Barcode", GetType(Byte()))
                End With

                Dim bs As New BarcodeSettings With {
                    .Type = BarCodeType.Code128,
                    .Data = _fk_emdPatients,
                    .AutoResize = True,
                    .CodabarStartChar = CodabarChar.A,
                    .CodabarStopChar = CodabarChar.A,
                    .ShowText = False,
                    .ShowStartCharAndStopChar = False
                }

                Dim bg = New BarCodeGenerator(bs)
                Dim image = bg.GenerateImage()
                Using ms As New MemoryStream
                    image.Save(ms, ImageFormat.Png)
                    Dim imageData = ms.ToArray
                    dt.Rows.Add(_ticketNumber, _patientName, _counterName, _notes, imageData)
                End Using

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