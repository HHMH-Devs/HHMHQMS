Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text.pdf

Public Class frmGenerateNurseNotes
    Private PatientConsultation As CustomerConsultation = Nothing
    Private isEditable As Boolean = False
    Private newFile As String = ""

    Sub New(consultation As CustomerConsultation, isEditable As Boolean)
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.PatientConsultation = consultation
        Me.isEditable = isEditable
        txtFirstName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName.Trim.ToUpper
        txtMiddleName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename.Trim.ToUpper
        txtLastName.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname.Trim.ToUpper
        dtpBirthDate.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate
        txtSex.Text = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex.Trim.ToUpper
        txtHospitalNo.Text = Me.PatientConsultation.NurseNotes.HospitalNo.Trim.ToUpper
        txtAttendingPhysician.Text = If(Not IsNothing(Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName), Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper, "NO SET ROD")
        txtRoomNo.Text = Me.PatientConsultation.RoomAdmitted.Trim.ToUpper
        txtWard.Text = Me.PatientConsultation.WardAdmitted.Trim.ToUpper
        Dim nurseOrderCount As Integer = 0
        If Not IsNothing(Me.PatientConsultation.NurseNotes) Then
            nurseOrderCount = Me.PatientConsultation.NurseNotes.NurseOrderItems.Count
        End If
        lblNurseOrderCount.Text = nurseOrderCount & vbCrLf & "NURSE PROGRESS NOTE/S"
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub fillUpOutpatientConsentForm()
        Dim consultDate As Date = Me.PatientConsultation.NurseNotes.DateCreated
        Dim patientName As String = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname).Trim.ToUpper
        Dim age As String = DateDiff(DateInterval.Year, Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate, Me.PatientConsultation.DateCreated)
        Dim hospitalNo As String = txtHospitalNo.Text.Trim.ToUpper
        Dim attendingPhycician As String = Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper
        Dim ward As String = Me.PatientConsultation.WardAdmitted.Trim.ToUpper
        Dim room As String = Me.PatientConsultation.RoomAdmitted.Trim.ToUpper
        Dim dates As String = ""
        Dim focuses As String = ""
        Dim dataAction As String = ""
        If Not IsNothing(Me.PatientConsultation.NurseNotes.NurseOrderItems) Then
            For Each items As NurseNoteItem In Me.PatientConsultation.NurseNotes.NurseOrderItems
                dates = dates & Format(items.DateCreated, "MM/dd/yy HH:mm") & vbCrLf
                focuses = focuses & items.Focus & vbCrLf & vbCrLf
                dataAction = dataAction & items.DataActions & vbCrLf & vbCrLf
            Next
        End If
        Dim apiControl As New APIController
        Dim serverDate As Date = apiControl.GetCurrentServerDate_qms()
        Dim forDeletion As Boolean = False
        If Not IsNothing(Me.PatientConsultation.NurseNotes.FileLocation) Then
            If Me.PatientConsultation.NurseNotes.FileLocation.Trim.Length > 0 Then
                forDeletion = True
            End If
        End If
        If forDeletion Then
            Try
                If System.IO.File.Exists(Me.PatientConsultation.NurseNotes.FileLocation) = True Then
                    System.IO.File.Delete(Me.PatientConsultation.NurseNotes.FileLocation)
                End If
            Catch ex As Exception

            End Try
        End If
        Dim pdfTemp As String = "\\10.5.19.237\wmmc_pcms\template_forms\NURSES PROGRESS NOTES.pdf"
        newFile = "\\10.5.19.237\wmmc_pcms\patient_nurse_notes\NURSE_PROGRESS_NOTE_FORM_" & PatientConsultation.Consultation_ID & serverDate.ToString("MMddyyyyHHmmsstt") & ".Pdf"
        Try
            ' ------ READING -------
            Dim pdfReader As New PdfReader(pdfTemp)
            ' ------ WRITING -------
            ' If you don’t specify version and append flag (last 2 params) in below line then you may receive “Extended Features” error when you open generated PDF
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)
            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            Dim PdfContentByte = pdfStamper.GetOverContent(1)
            pdfFormFields.SetField("txtFullName", patientName)
            pdfFormFields.SetField("txtAge", age)
            pdfFormFields.SetField("txtHospitalNo", hospitalNo)
            pdfFormFields.SetField("txtAttendingPhysician", attendingPhycician)
            pdfFormFields.SetField("txtWard", ward)
            pdfFormFields.SetField("txtRoomNo", room)
            pdfFormFields.SetField("txtDateTimeShift", dates)
            pdfFormFields.SetField("txtFocus", focuses)
            pdfFormFields.SetField("txtDataActionResponse", dataAction)
            pdfStamper.FormFlattening = False
            ' close the pdf
            pdfStamper.Close()
            ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
            ViewPDFToViewer(newFile)
        Catch ex As Exception

        Finally
            Dim nurseNote As New NurseNote
            nurseNote.Form_ID = Me.PatientConsultation.NurseNotes.Form_ID
            nurseNote.HospitalNo = txtHospitalNo.Text.Trim.ToUpper
            nurseNote.FileLocation = newFile
            Dim cusConsultationController As New CustomerConsultationController
            If cusConsultationController.SaveNurseNote(nurseNote) Then
                Me.PatientConsultation.NurseNotes.FileLocation = newFile
            End If
        End Try
    End Sub

    Private Function ViewPDFToViewer(viewPDFFile) As Boolean
        Try
            pdfViewer.LoadFromFile(viewPDFFile)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub frmGenerateNurseNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pd As New PrintDialog
            Dim pdoc As Printing.PrintDocument = pdfViewer.PrintDocument()
            pd.Document = pdoc
            If pd.ShowDialog = DialogResult.OK Then
                pdoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show("Something went wrong during printing. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim frm As New frmManageNurseNotes(Me.PatientConsultation.NurseNotes)
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            Dim consultationController As New CustomerConsultationController
            Me.PatientConsultation.NurseNotes.NurseOrderItems = consultationController.GetNurseNoteItems(Me.PatientConsultation.NurseNotes.Form_ID)
            Dim nurseOrderCount As Integer = 0
            If Not IsNothing(Me.PatientConsultation.NurseNotes) Then
                nurseOrderCount = Me.PatientConsultation.NurseNotes.NurseOrderItems.Count
            End If
            lblNurseOrderCount.Text = nurseOrderCount & vbCrLf & "NURSE PROGRESS NOTE/S"
            fillUpOutpatientConsentForm()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        fillUpOutpatientConsentForm()
    End Sub
End Class