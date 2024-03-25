Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text.pdf
Public Class frmGenerateMedicalCertificate
    Private PatientBizboxConsultation As Bizbox_Consultation = Nothing
    Private PatientBizboxRegistration As Bizbox_PatientDailyRegistration = Nothing
    Private isEditable As Boolean = False
    Private newFile As String = ""
    Private wasPrinted As Boolean = False
    Private tmp_DigitalSignature As Image = Nothing

    Public Sub New(ByVal consultation As Bizbox_Consultation, ByVal isEditable As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        Me.PatientBizboxConsultation = consultation
        Me.txtFullName.Text = (Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname & " " & Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName & " " & Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename).ToString.ToUpper.Trim
        Me.cbSex.Text = Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Sex
        Me.dtpBirthDate.Value = Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.BirthDate
        Me.txtCompleteAddress.Text = (Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.StreetDrive & " " & Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Barangay & " " & Me.PatientBizboxConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.CityMunicipality).ToString.ToUpper.Trim
        Me.txtImpresion.Text = Me.PatientBizboxConsultation.BizboxRegistration.Impression.Trim
        Me.txtRemarks.Text = Me.PatientBizboxConsultation.BizboxRegistration.FinalDiagnosis.Trim
        Me.txtPhysicianName.Text = Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.FullName.ToUpper.Trim
        Me.txtPRCNo.Text = Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.PRC.Trim
        Me.txtPTRNo.Text = Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.PTR.Trim
        Me.dtpIssuedDate.Value = Now.Date
        If (Not IsNothing(Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.SignatureLocation) AndAlso (Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.SignatureLocation.Trim.Length > 0)) Then
            Try
                If File.Exists(Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.SignatureLocation) Then
                    Me.tmp_DigitalSignature = Image.FromFile(Me.PatientBizboxConsultation.ServerTransaction.ServerAssignCounter.Server.SignatureLocation)
                End If
            Catch exception As Exception

            End Try
        End If
        Me.fillUpOutpatientConsentForm()
    End Sub

    Public Sub New(ByVal registration As Bizbox_PatientDailyRegistration, ByVal isEditable As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.PatientBizboxRegistration = registration
        Me.txtFullName.Text = Me.PatientBizboxRegistration.PatientData.FullName.ToString.ToUpper.Trim
        Me.cbSex.Text = Me.PatientBizboxRegistration.PatientData.Gender
        Me.dtpBirthDate.Value = Me.PatientBizboxRegistration.PatientData.BirthDate
        Me.txtCompleteAddress.Text = Me.PatientBizboxRegistration.PatientData.FullAddress.ToString.ToUpper.Trim
        Me.txtImpresion.Text = Me.PatientBizboxRegistration.Impression.Trim
        Me.txtRemarks.Text = Me.PatientBizboxRegistration.FinalDiagnosis.Trim
        Me.txtPhysicianName.Text = (Me.PatientBizboxRegistration.DoctorData.Lastname & ", " & Me.PatientBizboxRegistration.DoctorData.Firstname & " " & Me.PatientBizboxRegistration.DoctorData.MiddleName).ToUpper.Trim
        Me.txtPRCNo.Text = Me.PatientBizboxRegistration.DoctorData.PRC.Trim
        Me.txtPTRNo.Text = Me.PatientBizboxRegistration.DoctorData.PTR.Trim
        Me.dtpIssuedDate.Value = DateAndTime.Now.Date
        Me.fillUpOutpatientConsentForm()
    End Sub

    Private Sub fillUpOutpatientConsentForm()
        Dim consultation As Bizbox_PatientDailyRegistration = Nothing
        If Not Information.IsNothing(Me.PatientBizboxConsultation) Then
            consultation = Me.PatientBizboxConsultation.BizboxRegistration
        ElseIf Not Information.IsNothing(Me.PatientBizboxRegistration) Then
            consultation = Me.PatientBizboxRegistration
        End If
        If Not Information.IsNothing(consultation) Then
            Dim patientName As String = Me.txtFullName.Text
            Dim patientSex As String = Me.cbSex.Text
            Dim patientAge As Integer = DateDiff(DateInterval.Year, Me.dtpBirthDate.Value, consultation.RegistrationDate)
            Dim patientAddress As String = Me.txtCompleteAddress.Text
            Dim impression As String = Me.txtImpresion.Text
            Dim remark As String = txtRemarks.Text
            Dim dateIssued As String = Strings.Format(Me.dtpIssuedDate.Value, "MMM dd, yyyy")
            Dim doctorName As String = Me.txtPhysicianName.Text
            Dim doctorPRC As String = Me.txtPRCNo.Text
            Dim doctorPTR As String = Me.txtPTRNo.Text
            Dim serverDate As Date = New APIController().GetCurrentServerDate_qms()
            Dim pdfTemp As String = (WMMCQMSConfig.TemplateFormLocation() & "MEDICAL CERTIFICATE.pdf")
            Dim flag4 As Boolean = False
            If (Not Information.IsNothing(Me.newFile) AndAlso (Me.newFile.Trim.Length > 0)) Then
                flag4 = True
            End If
            If flag4 Then
                Try
                    If File.Exists(Me.newFile) Then
                        File.Delete(Me.newFile)
                    End If
                Catch exception1 As Exception
                End Try
            End If
            newFile = (WMMCQMSConfig.SaveFormLocation() & consultation.ConsultationID & serverDate.ToString("MMddyyyyHHmmsstt") & ".Pdf")
            Try
                ' ------ READING -------
                Dim pdfReader As New PdfReader(pdfTemp)
                ' ------ WRITING -------
                ' If you don’t specify version and append flag (last 2 params) in below line then you may receive “Extended Features” error when you open generated PDF
                Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)
                Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
                Dim PdfContentByte = pdfStamper.GetOverContent(1)
                If Not Information.IsNothing(Me.tmp_DigitalSignature) Then
                    Dim converter As New ImageConverter
                    Dim signByte1 As Byte() = DirectCast(converter.ConvertTo(Me.tmp_DigitalSignature, GetType(Byte())), Byte())
                    Dim pdfSign1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(signByte1)
                    pdfSign1.ScalePercent(40.0!, 20.0!)
                    pdfSign1.SetAbsolutePosition(380.0!, 140.0!)
                    PdfContentByte.AddImage(pdfSign1)
                    Dim pdfSign2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(signByte1)
                    pdfSign2.ScalePercent(40.0!, 20.0!)
                    pdfSign2.SetAbsolutePosition(370.0!, 570.0!)
                    PdfContentByte.AddImage(pdfSign2)
                End If
                pdfFormFields.SetField("txtDate1", dateIssued)
                pdfFormFields.SetField("txtPatientName1", patientName)
                pdfFormFields.SetField("txtAge1", (patientAge.ToString & " yr/s Old"))
                pdfFormFields.SetField("txtGender1", patientSex)
                pdfFormFields.SetField("txtCivilStatus1", "")
                pdfFormFields.SetField("txtAddress1", patientAddress)
                pdfFormFields.SetField("txtImpression1", impression)
                pdfFormFields.SetField("txtRemarks1", remark)
                pdfFormFields.SetField("txtPhysician1", ("Dr. " & doctorName))
                pdfFormFields.SetField("txtPRC1", doctorPRC)
                pdfFormFields.SetField("txtDate2", dateIssued)
                pdfFormFields.SetField("txtPatientName2", patientName)
                pdfFormFields.SetField("txtAge2", (patientAge.ToString & " yr/s Old"))
                pdfFormFields.SetField("txtGender2", patientSex)
                pdfFormFields.SetField("txtCivilStatus2", "")
                pdfFormFields.SetField("txtAddress2", patientAddress)
                pdfFormFields.SetField("txtImpression2", impression)
                pdfFormFields.SetField("txtRemarks2", remark)
                pdfFormFields.SetField("txtPhysician2", ("Dr. " & doctorName))
                pdfFormFields.SetField("txtPRC2", doctorPRC)
                pdfStamper.FormFlattening = False
                ' close the pdf
                pdfStamper.Close()
                ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
                ViewPDFToViewer(newFile)
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub

    Private Function ViewPDFToViewer(viewPDFFile) As Boolean
        Try
            pdfViewer.LoadFromFile(viewPDFFile)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub frmGenerateMedicalCertificate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFullName.Enabled = Me.isEditable
        Me.cbSex.Enabled = Me.isEditable
        Me.dtpBirthDate.Enabled = Me.isEditable
        Me.txtCompleteAddress.Enabled = Me.isEditable
        Me.txtImpresion.Enabled = Me.isEditable
        Me.dtpIssuedDate.Enabled = Me.isEditable
        Me.txtPhysicianName.Enabled = Me.isEditable
        Me.txtPRCNo.Enabled = Me.isEditable
        Me.txtPTRNo.Enabled = Me.isEditable
        Me.Button4.Enabled = Me.isEditable
    End Sub

    Private Sub frmGenerateMedicalCertificate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.pdfViewer.CloseDocument()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pd As New PrintDialog
            Dim pdoc As Printing.PrintDocument = pdfViewer.PrintDocument()
            pd.Document = pdoc
            If pd.ShowDialog = DialogResult.OK Then
                pdoc.Print()
                wasPrinted = True
            End If
        Catch ex As Exception
            MessageBox.Show("Something went wrong during printing. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Not wasPrinted Then
            Try
                My.Computer.FileSystem.DeleteFile(newFile)
            Catch ex As Exception

            End Try
        End If
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim consultant As New frmSelectConsultant
        consultant.ShowDialog()
        If (consultant.DialogResult = DialogResult.Yes) Then
            Dim selectedClinic As ServerAssignCounter = consultant.SelectedClinic
            Me.txtPhysicianName.Text = selectedClinic.Server.FullName.ToUpper.Trim
            Me.txtPRCNo.Text = selectedClinic.Server.PRC.ToUpper.Trim
            Me.txtPTRNo.Text = selectedClinic.Server.PTR.ToUpper.Trim
        End If
    End Sub
End Class