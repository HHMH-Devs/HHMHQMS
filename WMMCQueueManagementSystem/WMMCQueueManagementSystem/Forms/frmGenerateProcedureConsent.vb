Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text.pdf

Public Class frmGenerateProcedureConsent
    Private PatientConsultation As CustomerConsultation = Nothing
    Private tmpOPD_PatientSignature As Image = Nothing
    Private isEditable As Boolean = False
    Private newFile As String = ""

    Sub New(consultation As CustomerConsultation, isEditable As Boolean)
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.PatientConsultation = consultation
        Me.isEditable = isEditable
        txtConcernGivenName.Text = Me.PatientConsultation.ProcedureConsent.WatchersGivenName.Trim.ToUpper()
        txtConcernSurname.Text = Me.PatientConsultation.ProcedureConsent.WatchersSurName.Trim.ToUpper()
        nubConcernAge.Text = Me.PatientConsultation.ProcedureConsent.WatchersAge
        cbOPDConsent_WitnessRelationShip.Text = Me.PatientConsultation.ProcedureConsent.WatchersRelationship
        txtPatientName.Text = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Suffix).Trim.ToUpper()
        txtProcedureDetail.Text = Me.PatientConsultation.ProcedureConsent.Procedures.Trim.ToUpper()
        txtExplainedBy.Text = Me.PatientConsultation.ProcedureConsent.ExplainedBy.Trim.ToUpper()
        txtWitnessName.Text = Me.PatientConsultation.ProcedureConsent.WitnessName.Trim.ToUpper()
        txtWitnessAddress.Text = Me.PatientConsultation.ProcedureConsent.WitnessAddress.Trim.ToUpper()
        txtInterpreterName.Text = Me.PatientConsultation.ProcedureConsent.InterpreterName.Trim.ToUpper()
        txtInterpreterAddress.Text = Me.PatientConsultation.ProcedureConsent.InterpreterAddress.Trim.ToUpper()
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub fillUpOutpatientConsentForm()
        Dim consultDate As Date = Me.PatientConsultation.ProcedureConsent.DateCreated
        Dim givenName As String = txtConcernGivenName.Text.Trim.ToUpper
        Dim Surname As String = txtConcernSurname.Text.Trim.ToUpper
        Dim age As String = nubConcernAge.Value
        Dim relation As String = cbOPDConsent_WitnessRelationShip.Text.Trim.ToUpper
        Dim patientName As String = (Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.FirstName & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Middlename & " " & Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo.Lastname).Trim.ToUpper
        Dim procedures As String = txtProcedureDetail.Text.Trim.ToUpper
        Dim explained As String = txtExplainedBy.Text.Trim.ToUpper
        Dim dayProcedure As String = consultDate.ToString("dd")
        Dim monthProcedure As String = consultDate.ToString("MM")
        Dim yearProcedure As String = consultDate.ToString("yy")
        Dim witnessName As String = txtWitnessName.Text.Trim.ToUpper
        Dim witnessAddress As String = txtWitnessAddress.Text.Trim.ToUpper
        Dim interpreterName As String = txtInterpreterName.Text.Trim.ToUpper
        Dim interpreterAddress As String = txtInterpreterAddress.Text.Trim.ToUpper
        Dim apiControl As New APIController
        Dim serverDate As Date = apiControl.GetCurrentServerDate_qms()
        Dim forDeletion As Boolean = False
        If Not IsNothing(Me.PatientConsultation.ProcedureConsent.FileLocation) Then
            If Me.PatientConsultation.ProcedureConsent.FileLocation.Trim.Length > 0 Then
                forDeletion = True
            End If
        End If
        If forDeletion Then
            Try
                If System.IO.File.Exists(Me.PatientConsultation.ProcedureConsent.FileLocation) = True Then
                    System.IO.File.Delete(Me.PatientConsultation.ProcedureConsent.FileLocation)
                End If
            Catch ex As Exception

            End Try
        End If
        Dim pdfTemp As String = "\\10.5.19.237\wmmc_pcms\template_forms\ER CONSENT FOR PROCEDURES.pdf"
        newFile = "\\10.5.19.237\wmmc_pcms\procedure_consent\PROCEDURE_CONSENT_" & PatientConsultation.Consultation_ID & serverDate.ToString("MMddyyyyHHmmsstt") & ".Pdf"
        Try
            ' ------ READING -------
            Dim pdfReader As New PdfReader(pdfTemp)
            ' ------ WRITING -------
            ' If you don’t specify version and append flag (last 2 params) in below line then you may receive “Extended Features” error when you open generated PDF
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create), "\6c", True)
            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            Dim PdfContentByte = pdfStamper.GetOverContent(1)
            pdfFormFields.SetField("txtGivenName", givenName)
            pdfFormFields.SetField("txtSurname", Surname)
            pdfFormFields.SetField("txtAge", age)
            pdfFormFields.SetField("txtNameOfPatient", patientName)
            pdfFormFields.SetField("txtRelation", relation)
            pdfFormFields.SetField("txtProcedures", procedures)
            pdfFormFields.SetField("txtExplained", explained)
            pdfFormFields.SetField("txtDay", dayProcedure)
            pdfFormFields.SetField("txtMonth", monthProcedure)
            pdfFormFields.SetField("txtYear", yearProcedure)
            pdfFormFields.SetField("txtSignatureName", patientName)
            pdfFormFields.SetField("txtWitness1", witnessName)
            pdfFormFields.SetField("txtAddress1", witnessAddress)
            pdfFormFields.SetField("txtWitness2", interpreterName)
            pdfFormFields.SetField("txtAddress2", interpreterAddress)
            If Not IsNothing(tmpOPD_PatientSignature) Then
                Dim converter As New ImageConverter
                Dim signByte1 As Byte() = converter.ConvertTo(tmpOPD_PatientSignature, GetType(Byte()))
                Dim pdfSign1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(signByte1)
                pdfSign1.ScalePercent(40, 20)
                pdfSign1.SetAbsolutePosition(340, 230)
                PdfContentByte.AddImage(pdfSign1)
            End If
            pdfStamper.FormFlattening = False
            ' close the pdf
            pdfStamper.Close()
            ' pdfReader.close() ---> DON"T EVER CLOSE READER IF YOU'RE GENERATING LOTS OF PDF FILES IN LOOP
            ViewPDFToViewer(newFile)
        Catch ex As Exception

        Finally
            Dim prodConsent As New ProcedureConsent
            prodConsent.Form_ID = Me.PatientConsultation.ProcedureConsent.Form_ID
            prodConsent.WatchersGivenName = givenName
            prodConsent.WatchersSurName = Surname
            prodConsent.WatchersAge = age
            prodConsent.WatchersRelationship = relation
            prodConsent.Procedures = procedures
            prodConsent.ExplainedBy = explained
            prodConsent.WitnessName = witnessName
            prodConsent.WitnessAddress = witnessAddress
            prodConsent.InterpreterName = interpreterName
            prodConsent.InterpreterAddress = interpreterAddress
            prodConsent.FileLocation = newFile
            Dim cusConsultationController As New CustomerConsultationController
            If cusConsultationController.SaveProceduresConsent(prodConsent) Then
                Me.PatientConsultation.ProcedureConsent.FileLocation = newFile
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

    Private Sub frmGenerateProcedureConsent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        fillUpOutpatientConsentForm()
    End Sub

    Private Sub btnOPDConsent_PatientSignature_Click_1(sender As Object, e As EventArgs) Handles btnOPDConsent_PatientSignature.Click
        Dim patientInfo As CustomerInfo = Me.PatientConsultation.ServedCustomer.CustomerAssignCounter.Customer.CustomerInfo
        Dim frm As New frmSignaturePad(patientInfo.Lastname.Trim.ToUpper & " " & patientInfo.FirstName.Trim.ToUpper, "PATIENT SIGNATURE")
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            If Not IsNothing(frm.SignatureBmp) Then
                Dim bmp As Bitmap = frm.SignatureBmp
                bmp.MakeTransparent()
                tmpOPD_PatientSignature = bmp
                Me.Button2_Click_1(sender, e)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class