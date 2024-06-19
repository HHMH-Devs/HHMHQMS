Imports System.ComponentModel
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class frmGenerateConsent
    Private pdfFile1 As String
    Private pdfFile2 As String
    Private _patientInfo As CustomerAssignCounter
    Private tmpOPDConsent As OPDConsentFields
    Private tmpOPD_PatientSignature As System.Drawing.Image = Nothing
    Private tmpOPD_WitnessSignature As System.Drawing.Image = Nothing
    Private tmpOPD_EmployeeSignature As System.Drawing.Image = Nothing
    Private CreatedConsent1 As String = Nothing
    Private CreatedConsent2 As String = Nothing

    Public Property ConsentFile1 As String
        Get
            Return CreatedConsent1
        End Get
        Private Set(value As String)
            CreatedConsent1 = value
        End Set
    End Property

    Public Property ConsentFile2 As String
        Get
            Return CreatedConsent2
        End Get
        Private Set(value As String)
            CreatedConsent2 = value
        End Set
    End Property

    Sub New(fileType As Integer, patient As CustomerAssignCounter)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.tmpOPD_PatientSignature = Nothing
        Me.tmpOPD_WitnessSignature = Nothing
        Me.tmpOPD_EmployeeSignature = Nothing
        Me.CreatedConsent1 = Nothing
        Me.CreatedConsent2 = Nothing
        If fileType = 1 Then
            Me.pdfFile1 = (WMMCQMSConfig.TemplateFormLocation() & "CONSENT FOR PATIENT PERSONAL INFORMATION.pdf")
            Me.pdfFile2 = (WMMCQMSConfig.TemplateFormLocation() & "CONSENT FOR BLOOD EXTRACTION.pdf")
            Me.pdfViewer1.Show()
        End If
        Me._patientInfo = patient
        Dim patientInfo As CustomerInfo = _patientInfo.Customer.CustomerInfo
        Dim opdConsentFields As New OPDConsentFields
        With opdConsentFields
            .PatientName1 = patientInfo.Lastname & ", " & patientInfo.FirstName & " " & patientInfo.Middlename & " " & patientInfo.Suffix
            .PatientAddress = patientInfo.StreetDrive & " " & patientInfo.Barangay & " " & patientInfo.CityMunicipality
            .PatientRelationship = ""
            .WitnessName = ""
            .DataPrivacy = True
            .ContactConsent = True
            .OPCareConsent = True
            .Email = If(Not IsNothing(patientInfo.Email), patientInfo.Email.Trim, "")
            .MobileNo = If(Not IsNothing(patientInfo.PhoneNumber), patientInfo.PhoneNumber.Trim, "")
            .PatientSignature = Me.tmpOPD_PatientSignature
            .WitnessSignature = Me.tmpOPD_WitnessSignature
            .EmployeeSignature = Me.tmpOPD_WitnessSignature
            .ConsentDate = Now
            .DateOfBirth = patientInfo.BirthDate
            .Gender = patientInfo.Sex
            .Age = GetCurrentAge(patientInfo.BirthDate)
            .CivilStatus = IIf(String.IsNullOrEmpty(patientInfo.CivilStatus), "Single", patientInfo.CivilStatus)
        End With
        tmpOPDConsent = opdConsentFields
        fillUpOutpatientConsentForm(tmpOPDConsent)
    End Sub

    Private Function ViewPDFToViewer(viewPDFFile1, viewPDFFile2) As Boolean
        Try
            pdfViewer1.LoadFromFile(viewPDFFile1)
            pdfViewer2.LoadFromFile(viewPDFFile2)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub fillUpOutpatientConsentForm(consentFields As OPDConsentFields)
        Dim time As Date = New APIController().GetCurrentServerDate_qms
        Dim filename As String = (Me._patientInfo.CustomerAssignCounter_ID) & time.ToString("MMddyyyyHHmmsstt")
        Dim path1 As String = (WMMCQMSConfig.SaveFormLocation() & "PERSONAL_INFO_CONSENT_" & filename & ".Pdf")
        Dim path2 As String = (WMMCQMSConfig.SaveFormLocation() & "BLOOD_EXTRACTION_CONSENT_" & filename & ".Pdf")
        Try
            Dim reader As New PdfReader(Me.pdfFile1)
            Dim stamper As New PdfStamper(reader, New FileStream(path1, FileMode.Create), "\"c, True)
            Dim acroFields As AcroFields = stamper.AcroFields
            Dim overContent As PdfContentByte = stamper.GetOverContent(1)
            If (consentFields.WitnessName.Trim.Length > 0) Then
                If Not Information.IsNothing(consentFields.WitnessSignature) Then
                    Dim converter As New ImageConverter
                    Dim imgb As Byte() = DirectCast(converter.ConvertTo(consentFields.WitnessSignature, GetType(Byte())), Byte())
                    Dim instance As Image = Image.GetInstance(imgb)
                    instance.ScalePercent(40.0!, 20.0!)
                    instance.SetAbsolutePosition(40.0!, 240.0!)
                    overContent.AddImage(instance)
                End If
            ElseIf Not Information.IsNothing(consentFields.PatientSignature) Then
                Dim converter2 As New ImageConverter
                Dim imgb As Byte() = DirectCast(converter2.ConvertTo(consentFields.PatientSignature, GetType(Byte())), Byte())
                Dim instance As Image = Image.GetInstance(imgb)
                instance.ScalePercent(40.0!, 20.0!)
                instance.SetAbsolutePosition(40.0!, 240.0!)
                overContent.AddImage(instance)
            End If
            If Not Information.IsNothing(consentFields.EmployeeSignature) Then
                Dim converter3 As New ImageConverter
                Dim imgb As Byte() = DirectCast(converter3.ConvertTo(consentFields.EmployeeSignature, GetType(Byte())), Byte())
                Dim instance As Image = Image.GetInstance(imgb)
                instance.ScalePercent(40.0!, 20.0!)
                instance.SetAbsolutePosition(370.0!, 110.0!)
                overContent.AddImage(instance)
            End If
            acroFields.SetField("PatientPrintedName", If((consentFields.WitnessName.Trim.Length > 0), consentFields.WitnessName, consentFields.PatientName1))
            acroFields.SetField("RelToPat", If((consentFields.WitnessName.Trim.Length > 0), consentFields.PatientRelationship, "SELF CONSENT"))
            acroFields.SetField("PatientName", consentFields.PatientName1)
            acroFields.SetField("txtv1WitnessOrPatient", If((consentFields.WitnessName.Trim.Length > 0), consentFields.WitnessName, consentFields.PatientName1))
            acroFields.SetField("Date", consentFields.ConsentDate)
            acroFields.SetField("txtv1EmployeeName", consentFields.EmployeeName)
            acroFields.SetField("Date", consentFields.ConsentDate)
            acroFields.SetField("DateOfBirth", consentFields.DateOfBirth)
            acroFields.SetField("ContactNo", consentFields.MobileNo)
            acroFields.SetField("PatientAge", consentFields.Age)
            acroFields.SetField("PatientAddress", consentFields.PatientAddress)
            acroFields.SetField("Gender", consentFields.Gender)
            acroFields.SetField("PatientCivilStatus", consentFields.CivilStatus)
            stamper.FormFlattening = False
            stamper.Close()
            Dim reader2 As New PdfReader(Me.pdfFile2)
            Dim stamper2 As New PdfStamper(reader2, New FileStream(path2, FileMode.Create), "\"c, True)
            Dim fields2 As AcroFields = stamper2.AcroFields
            Dim num2 As PdfContentByte = stamper2.GetOverContent(1)
            If (consentFields.WitnessName.Trim.Length > 0) Then
                If Not Information.IsNothing(consentFields.WitnessSignature) Then
                    Dim converter4 As New ImageConverter
                    Dim imgb As Byte() = DirectCast(converter4.ConvertTo(consentFields.WitnessSignature, GetType(Byte())), Byte())
                    Dim instance As Image = Image.GetInstance(imgb)
                    instance.ScalePercent(40.0!, 20.0!)
                    instance.SetAbsolutePosition(220.0!, 210.0!)
                    num2.AddImage(instance)
                End If
            ElseIf Not Information.IsNothing(consentFields.PatientSignature) Then
                Dim converter5 As New ImageConverter
                Dim imgb As Byte() = DirectCast(converter5.ConvertTo(consentFields.PatientSignature, GetType(Byte())), Byte())
                Dim instance As Image = Image.GetInstance(imgb)
                instance.ScalePercent(40.0!, 20.0!)
                instance.SetAbsolutePosition(220.0!, 210.0!)
                num2.AddImage(instance)
            End If
            If Not Information.IsNothing(consentFields.EmployeeSignature) Then
                Dim converter6 As New ImageConverter
                Dim imgb As Byte() = DirectCast(converter6.ConvertTo(consentFields.EmployeeSignature, GetType(Byte())), Byte())
                Dim instance As Image = Image.GetInstance(imgb)
                instance.ScalePercent(40.0!, 20.0!)
                instance.SetAbsolutePosition(220.0!, 150.0!)
                num2.AddImage(instance)
            End If
            fields2.SetField("txtv2PatientName", consentFields.PatientName1)
            fields2.SetField("txtv2PatientAddress", consentFields.PatientAddress)
            fields2.SetField("txtv2Day", consentFields.ConsentDate.ToString("dd"))
            fields2.SetField("txtv2Month", consentFields.ConsentDate.ToString("MMMM"))
            fields2.SetField("txtv2Year", consentFields.ConsentDate.ToString("yyyy"))
            fields2.SetField("txtv2PatientWatcher", If((consentFields.WitnessName.Trim.Length > 0), consentFields.WitnessName, consentFields.PatientName1))
            fields2.SetField("txtv2PhlebotomistName", consentFields.EmployeeName)
            fields2.SetField("txtv2DateExtracton", consentFields.ConsentDate)
            stamper2.FormFlattening = False
            stamper2.Close()
            Me.CreatedConsent1 = path1
            Me.CreatedConsent2 = path2
            Me.ViewPDFToViewer(path1, path2)
        Catch exception As Exception
            Me.CreatedConsent1 = Nothing
            Me.CreatedConsent2 = Nothing
            MessageBox.Show(exception.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            MessageBox.Show("Error while processing the consent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try

    End Sub

    Public Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Private Sub frmGenerateConsent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pdfViewer2.Hide()
        pdfViewer1.Show()
        ShowPageNo()
    End Sub

    Private Sub btnPatientSignature_Click(sender As Object, e As EventArgs)
        Dim patientInfo As CustomerInfo = _patientInfo.Customer.CustomerInfo
        Dim frm As New frmSignaturePad(patientInfo.Lastname.Trim.ToUpper & " " & patientInfo.FirstName.Trim.ToUpper, "PATIENT SIGNATURE")
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            If Not IsNothing(frm.SignatureBmp) Then
                Dim bmp As Bitmap = frm.SignatureBmp
                bmp.MakeTransparent()
                tmpOPD_PatientSignature = bmp
                Me.btnOPDConsent_Preview.PerformClick()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmGenerateConsent_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not Me.DialogResult = DialogResult.Yes Then
            If Not IsNothing(Me.CreatedConsent1) Then
                Try
                    If System.IO.File.Exists(Me.CreatedConsent1) = True Then
                        System.IO.File.Delete(Me.CreatedConsent1)
                    End If

                Catch ex As Exception

                End Try
            End If
            If Not IsNothing(Me.CreatedConsent2) Then
                Try
                    If System.IO.File.Exists(Me.CreatedConsent2) = True Then
                        System.IO.File.Delete(Me.CreatedConsent2)
                    End If

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub frmGenerateConsent_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        pdfViewer1.CloseDocument()
        Me.Dispose()
    End Sub

    Private Sub ShowPageNo()
        If pdfViewer1.Visible Then
            lblPage.Text = "PAGE: 1 of 2"
        ElseIf pdfViewer2.Visible Then
            lblPage.Text = "PAGE: 2 of 2"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If pdfViewer1.Visible Then
            pdfViewer1.Hide()
            pdfViewer2.Show()
        ElseIf pdfViewer2.Visible Then
            pdfViewer2.Hide()
            pdfViewer1.Show()
        End If
        ShowPageNo()
    End Sub

    Private Sub btnOPDConsent_EmployeeSignature_Click(sender As Object, e As EventArgs) Handles btnOPDConsent_EmployeeSignature.Click
        Dim customerInfo As CustomerInfo = Me._patientInfo.Customer.CustomerInfo
        Dim pad As New frmSignaturePad(Me.txtOPDConsent_Witness.Text.Trim.ToUpper, "WITNESS SIGNATURE")
        pad.ShowDialog()

        If ((pad.DialogResult = DialogResult.Yes) AndAlso Not Information.IsNothing(pad.SignatureBmp)) Then
            Dim signatureBmp As Bitmap = pad.SignatureBmp
            signatureBmp.MakeTransparent()
            Me.tmpOPD_EmployeeSignature = signatureBmp
            Me.btnOPDConsent_Preview.PerformClick()
        End If
    End Sub

    Private Sub btnOPDConsent_Preview_Click(sender As Object, e As EventArgs) Handles btnOPDConsent_Preview.Click
        Dim customerInfo As CustomerInfo = Me._patientInfo.Customer.CustomerInfo
        Dim consentFields As New OPDConsentFields
        Dim textArray1 As String() = New String() {customerInfo.Lastname, ", ", customerInfo.FirstName, " ", customerInfo.Middlename, " ", customerInfo.Suffix}
        consentFields.PatientName1 = String.Concat(textArray1).Trim.ToUpper
        Dim textArray2 As String() = New String() {customerInfo.StreetDrive, " ", customerInfo.Barangay, " ", customerInfo.CityMunicipality}
        consentFields.PatientAddress = String.Concat(textArray2).Trim.ToUpper
        consentFields.PatientRelationship = Me.cbOPDConsent_WitnessRelationShip.Text
        consentFields.WitnessName = Me.txtOPDConsent_Witness.Text
        consentFields.EmployeeName = Me.txtOPDConsent_EmployeeName.Text
        consentFields.PatientSignature = Me.tmpOPD_PatientSignature
        consentFields.WitnessSignature = Me.tmpOPD_WitnessSignature
        consentFields.EmployeeSignature = Me.tmpOPD_EmployeeSignature
        consentFields.ConsentDate = DateAndTime.Now
        Me.tmpOPDConsent = consentFields
        Me.fillUpOutpatientConsentForm(consentFields)
    End Sub

    Private Sub btnOPDConsent_PatientSignature_Click(sender As Object, e As EventArgs) Handles btnOPDConsent_PatientSignature.Click
        Dim customerInfo As CustomerInfo = Me._patientInfo.Customer.CustomerInfo
        Dim pad As New frmSignaturePad((customerInfo.Lastname.Trim.ToUpper & " " & customerInfo.FirstName.Trim.ToUpper), "PATIENT SIGNATURE")
        pad.ShowDialog()
        If ((pad.DialogResult = DialogResult.Yes) AndAlso Not Information.IsNothing(pad.SignatureBmp)) Then
            Dim signatureBmp As Bitmap = pad.SignatureBmp
            signatureBmp.MakeTransparent()
            Me.tmpOPD_PatientSignature = signatureBmp
            Me.btnOPDConsent_Preview.PerformClick()
        End If
    End Sub

    Private Sub btnOPDConsent_Done_Click(sender As Object, e As EventArgs) Handles btnOPDConsent_Done.Click
        If IsNothing(Me.CreatedConsent1) And IsNothing(Me.CreatedConsent2) Then
            Dim patientInfo As CustomerInfo = _patientInfo.Customer.CustomerInfo
            Dim opdConsentFields As New OPDConsentFields
            With opdConsentFields
                .PatientName1 = patientInfo.Lastname & ", " & patientInfo.FirstName & " " & patientInfo.Middlename & " " & patientInfo.Suffix
                .PatientAddress = (patientInfo.StreetDrive & " " & patientInfo.Barangay & " " & patientInfo.CityMunicipality).Trim.ToUpper
                .PatientRelationship = Me.cbOPDConsent_WitnessRelationShip.Text
                .WitnessName = Me.txtOPDConsent_Witness.Text
                .EmployeeName = Me.txtOPDConsent_EmployeeName.Text
                .PatientSignature = Me.tmpOPD_PatientSignature
                .WitnessSignature = Me.tmpOPD_WitnessSignature
                .EmployeeSignature = Me.tmpOPD_EmployeeSignature
                .ConsentDate = DateAndTime.Now
            End With
            tmpOPDConsent = opdConsentFields
            fillUpOutpatientConsentForm(opdConsentFields)
            Me.DialogResult = DialogResult.Yes
        ElseIf Me.CreatedConsent1.Length <= 0 And Me.CreatedConsent2.Length <= 0 Then
            Dim patientInfo As CustomerInfo = _patientInfo.Customer.CustomerInfo
            Dim opdConsentFields As New OPDConsentFields
            With opdConsentFields
                .PatientName1 = patientInfo.Lastname & ", " & patientInfo.FirstName & " " & patientInfo.Middlename & " " & patientInfo.Suffix
                .PatientAddress = .PatientAddress = (patientInfo.StreetDrive & " " & patientInfo.Barangay & " " & patientInfo.CityMunicipality).Trim.ToUpper
                .PatientRelationship = Me.cbOPDConsent_WitnessRelationShip.Text
                .WitnessName = Me.txtOPDConsent_Witness.Text
                .EmployeeName = Me.txtOPDConsent_EmployeeName.Text
                .PatientSignature = Me.tmpOPD_PatientSignature
                .WitnessSignature = Me.tmpOPD_WitnessSignature
                .EmployeeSignature = Me.tmpOPD_EmployeeSignature
                .ConsentDate = DateAndTime.Now
            End With
            tmpOPDConsent = opdConsentFields
            fillUpOutpatientConsentForm(opdConsentFields)
            Me.DialogResult = DialogResult.Yes
        Else
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub btnOPDConsent_WitnessSignature_Click_1(sender As Object, e As EventArgs) Handles btnOPDConsent_WitnessSignature.Click
        Dim patientInfo As CustomerInfo = _patientInfo.Customer.CustomerInfo
        Dim frm As New frmSignaturePad(txtOPDConsent_Witness.Text.Trim.ToUpper, "WITNESS SIGNATURE")
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.Yes Then
            If Not IsNothing(frm.SignatureBmp) Then
                Dim bmp As Bitmap = frm.SignatureBmp
                bmp.MakeTransparent()
                tmpOPD_WitnessSignature = bmp
                Me.btnOPDConsent_Preview.PerformClick()
            End If
        End If
    End Sub
End Class