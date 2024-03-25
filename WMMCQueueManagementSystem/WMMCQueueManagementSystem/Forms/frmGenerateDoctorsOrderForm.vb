Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text.pdf

Public Class frmGenerateDoctorsOrderForm
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
        txtHospitalNo.Text = Me.PatientConsultation.ERDoctorsOrder.HospitalNo.Trim.ToUpper
        txtAttendingPhysician.Text = If(Not IsNothing(Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName), Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper, "NO SET ROD")
        txtRoomNo.Text = Me.PatientConsultation.RoomAdmitted.Trim.ToUpper
        txtWard.Text = Me.PatientConsultation.WardAdmitted.Trim.ToUpper
        nuptemp.Text = Me.PatientConsultation.Temperature
        nubPulse.Text = Me.PatientConsultation.PulseRate
        nubRespiRate.Text = Me.PatientConsultation.RespiratoryRate
        nubBp.Text = Me.PatientConsultation.Systolic & "/" & Me.PatientConsultation.Diastolic
        nubWeight.Text = Me.PatientConsultation.Weight & " " & Me.PatientConsultation.WeightUnit
        nubO2Sat.Text = Me.PatientConsultation.Oxygen
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub fillUpOutpatientConsentForm()
        Dim consultDate As Date = Me.PatientConsultation.ERDoctorsOrder.DateCreated
        Dim patientName As String = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname).Trim.ToUpper
        Dim age As String = DateDiff(DateInterval.Year, Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate, Me.PatientConsultation.DateCreated)
        Dim hospitalNo As String = txtHospitalNo.Text.Trim.ToUpper
        Dim attendingPhycician As String = Me.PatientConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.Trim.ToUpper
        Dim ward As String = Me.PatientConsultation.WardAdmitted.Trim.ToUpper
        Dim room As String = Me.PatientConsultation.RoomAdmitted.Trim.ToUpper
        Dim sex As String = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex.Trim.ToUpper
        Dim temparature As String = Me.PatientConsultation.Temperature
        Dim pulse As String = Me.PatientConsultation.PulseRate
        Dim respi As String = Me.PatientConsultation.RespiratoryRate
        Dim bp As String = Me.PatientConsultation.Systolic & "/" & Me.PatientConsultation.Diastolic
        Dim weight As String = Me.PatientConsultation.Weight & " " & Me.PatientConsultation.WeightUnit
        Dim o2 As String = Me.PatientConsultation.Oxygen
        Dim o2Mask As String = nubO2Mask.Text.Trim.ToUpper
        Dim progressNote As String = Me.PatientConsultation.AdmittedProgressNote.Trim.ToUpper
        Dim doctorOrder As String = Me.PatientConsultation.AdmittedDoctorsOrder.Trim.ToUpper
        Dim remarks As String = Me.PatientConsultation.AdmittedRemarks.Trim.ToUpper
        Dim apiControl As New APIController
        Dim serverDate As Date = apiControl.GetCurrentServerDate_qms()
        Dim forDeletion As Boolean = False
        If Not IsNothing(Me.PatientConsultation.ERDoctorsOrder.FileLocation) Then
            If Me.PatientConsultation.ERDoctorsOrder.FileLocation.Trim.Length > 0 Then
                forDeletion = True
            End If
        End If
        If forDeletion Then
            Try
                If System.IO.File.Exists(Me.PatientConsultation.ERDoctorsOrder.FileLocation) = True Then
                    System.IO.File.Delete(Me.PatientConsultation.ERDoctorsOrder.FileLocation)
                End If
            Catch ex As Exception

            End Try
        End If
        Dim pdfTemp As String = "\\10.5.19.237\wmmc_pcms\template_forms\ER DOCTORS ORDER.pdf"
        newFile = "\\10.5.19.237\wmmc_pcms\patient_er_doctors_order_form\ER_DOCTORS_ORDER_FORM_" & PatientConsultation.Consultation_ID & serverDate.ToString("MMddyyyyHHmmsstt") & ".Pdf"
        Try
            ' ------ READING -------
            Dim pdfReader As New PdfReader(pdfTemp)
            ' ------ WRITING -------
            ' If you don’t specify version and append flag (last 2 params) in below line then you may receive “Extended Features” error when you open generated PDF
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)
            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            Dim PdfContentByte = pdfStamper.GetOverContent(1)
            pdfFormFields.SetField("txtName", patientName)
            pdfFormFields.SetField("txtAge", age)
            pdfFormFields.SetField("txtHospitalNo", hospitalNo)
            pdfFormFields.SetField("txtAttendingPhysician", attendingPhycician)
            pdfFormFields.SetField("txtWard", ward)
            pdfFormFields.SetField("txtRoomNo", room)
            pdfFormFields.SetField("cbMale", If(sex.Trim.ToUpper = "MALE", "Yes", "No"))
            pdfFormFields.SetField("cbFemale", If(sex.Trim.ToUpper = "FEMALE", "Yes", "No"))
            pdfFormFields.SetField("txtTemperature", temparature)
            pdfFormFields.SetField("txtPulse", pulse)
            pdfFormFields.SetField("txtRespiratory", respi)
            pdfFormFields.SetField("txtBP", bp)
            pdfFormFields.SetField("txtWeight", weight)
            pdfFormFields.SetField("txto2Sat", o2)
            pdfFormFields.SetField("txto2Type", o2Mask)
            pdfFormFields.SetField("txtOtherAddiotionalItem", "")
            pdfFormFields.SetField("txtProgressNote", progressNote)
            pdfFormFields.SetField("txtDoctorsOrder", doctorOrder)
            pdfStamper.FormFlattening = False
            ' close the pdf
            pdfStamper.Close()
            ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
            ViewPDFToViewer(newFile)
        Catch ex As Exception

        Finally
            Dim ERDoctorOrder As New ERDoctorsOrder
            ERDoctorOrder.Form_ID = Me.PatientConsultation.ERDoctorsOrder.Form_ID
            ERDoctorOrder.HospitalNo = txtHospitalNo.Text.Trim.ToUpper
            ERDoctorOrder.FileLocation = newFile
            Dim cusConsultationController As New CustomerConsultationController
            If cusConsultationController.SaveERDoctorsOrder(ERDoctorOrder) Then
                Me.PatientConsultation.ERDoctorsOrder.FileLocation = newFile
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

    Private Sub frmGenerateDoctorsOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        fillUpOutpatientConsentForm()
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

End Class