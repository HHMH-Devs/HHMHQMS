Imports System.ComponentModel

Public Class frmPatientProfiling
    Private imageChanged As Boolean = False
    Private _isRequired As Boolean = False
    Private isTouch As Boolean = False
    Private _customerInfo As CustomerInfo = Nothing
    Private bdateMonth As Integer = 0
    Private bdateDay As Integer = 0
    Private bdateYear As Integer = 0
    Dim longMonth() As String = {"JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "nOVEMBER", "DECEMBER"}


    Sub New(isRequired As Boolean, touch As Boolean)
        _customerInfo = Nothing
        _isRequired = isRequired
        isTouch = touch
        ' This call is required by the designer.
        InitializeComponent()
    End Sub
    Sub New(customer As CustomerInfo, isRequired As Boolean, touch As Boolean, _readOnly As Boolean)
        _customerInfo = customer
        _isRequired = isRequired
        isTouch = touch
        ' This call is required by the designer.
        InitializeComponent()
        txtfname.ReadOnly = _readOnly
        txtmname.ReadOnly = _readOnly
        txtlname.ReadOnly = _readOnly
        txtSuffix.Enabled = Not _readOnly
        gbsex.Enabled = Not _readOnly
        gbcivilstatus.Enabled = Not _readOnly
        txtbday_month.ReadOnly = _readOnly
        txtbday_day.ReadOnly = _readOnly
        txtbday_year.ReadOnly = _readOnly
        txtcontactno.ReadOnly = _readOnly
        txtstreet.ReadOnly = _readOnly
        txtbarangay.ReadOnly = _readOnly
        txtcity.ReadOnly = _readOnly
        If _readOnly Then
            lbnote.Text = "Note: Details that marked with * (asterisk) must be filled." & vbCrLf &
                          "Click any box or field to enter the details."
        Else
            lbnote.Text = "Note: Details that marked with * (asterisk) must be filled." & vbCrLf &
                          "Click any box or field to enter the details."
        End If
    End Sub

    Public Property CustomerProfile As CustomerInfo
        Get
            Return _customerInfo
        End Get
        Private Set(value As CustomerInfo)
            _customerInfo = value
        End Set
    End Property

    Private Sub GetBirthday()
        Dim frm As New frmSelectBDayForTouch
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            If frm.SelectedMonth > 0 And frm.SelectedDay > 0 And frm.SelectedYear > 0 Then
                bdateMonth = frm.SelectedMonth
                bdateDay = frm.SelectedDay
                bdateYear = frm.SelectedYear
                SetBirthday()
            End If
        End If
    End Sub

    Private Sub SetBirthday()
        If bdateMonth > 0 Then
            txtbday_month.Text = longMonth(bdateMonth - 1)
        Else
            txtbday_month.Text = "Click to Select"
        End If
        If bdateDay > 0 Then
            If bdateDay > 9 Then
                txtbday_day.Text = bdateDay
            Else
                txtbday_day.Text = "0" & bdateDay
            End If
        Else
            txtbday_day.Text = "Click to Select"
        End If
        If bdateYear > 0 Then
            txtbday_year.Text = bdateYear
        Else
            txtbday_year.Text = "Click to Select"
        End If
    End Sub

    Private Sub frmCustomerProfiling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imageChanged = False
        If Not IsNothing(CustomerProfile) Then
            txtstreet.Text = CustomerProfile.StreetDrive
            txtbarangay.Text = CustomerProfile.Barangay
            txtcity.Text = CustomerProfile.CityMunicipality
            txtfname.Text = CustomerProfile.FirstName
            txtmname.Text = CustomerProfile.Middlename
            txtlname.Text = CustomerProfile.Lastname
            txtSuffix.Text = CustomerProfile.Suffix
            If CustomerProfile.Sex.ToUpper = "M" Or CustomerProfile.Sex.ToUpper = "MALE" Then
                sex_female.Checked = False
                sex_male.Checked = True
            Else
                sex_male.Checked = False
                sex_female.Checked = True
            End If
            bdateMonth = CustomerProfile.BirthDate.Month
            bdateDay = CustomerProfile.BirthDate.Day
            bdateYear = CustomerProfile.BirthDate.Year
            txtbday_month.Text = longMonth(CustomerProfile.BirthDate.Month - 1)
            txtbday_day.Text = CustomerProfile.BirthDate.Day
            txtbday_year.Text = CustomerProfile.BirthDate.Year
            If CustomerProfile.CivilStatus.ToUpper = "SINGLE" Then
                cs_single.Checked = True
            ElseIf CustomerProfile.CivilStatus.ToUpper = "MARRIED" Then
                cs_married.Checked = True
            ElseIf CustomerProfile.CivilStatus.ToUpper = "SEPARATED" Then
                cs_separated.Checked = True
            ElseIf CustomerProfile.CivilStatus.ToUpper = "WIDOWED" Then
                cs_widowed.Checked = True
            End If
            txtcontactno.Text = CustomerProfile.PhoneNumber
            txtEmail.Text = CustomerProfile.Email
            If Not IsNothing(CustomerProfile.PatientPicture) Then
                If CustomerProfile.PatientPicture.Trim.Length > 0 Then
                    Try
                        pbProfilePicture.Image = Image.FromFile(CustomerProfile.PatientPicture)
                    Catch ex As Exception
                        pbProfilePicture.Image = Nothing
                    End Try
                End If
            End If
        End If
        If _isRequired Then
            pnlRequiredSaving.Show()
            pnlOptionalSaving.Hide()
        Else
            pnlRequiredSaving.Hide()
            pnlOptionalSaving.Show()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not txtfname.Text.Length > 0 Then
            MessageBox.Show("First name is empty. Please enter your first name", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not txtlname.Text.Length > 0 Then
            MessageBox.Show("Middle name is empty. Please enter your middle name", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not bdateYear > 0 Or Not bdateMonth > 0 Or Not bdateYear > 0 Then
            MessageBox.Show("Birthday is empty. Please enter your Birthday", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim customerProfile As New CustomerInfo
            If Not IsNothing(Me.CustomerProfile) Then
                customerProfile = Me.CustomerProfile
            End If
            Dim birthdate As Date
            Try
                birthdate = New Date(bdateYear, bdateMonth, bdateDay)
            Catch ex As Exception
                MessageBox.Show("Please enter a valid birth date", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            customerProfile.FirstName = txtfname.Text.ToUpper
            customerProfile.Middlename = txtmname.Text.ToUpper
            customerProfile.Lastname = txtlname.Text.ToUpper
            customerProfile.Suffix = txtSuffix.Text.ToUpper
            If sex_male.Checked Then
                customerProfile.Sex = "MALE"
            Else
                customerProfile.Sex = "FEMALE"
            End If
            If cs_single.Checked Then
                customerProfile.CivilStatus = "SINGLE"
            ElseIf cs_married.Checked Then
                customerProfile.CivilStatus = "MARRIED"
            ElseIf cs_separated.Checked Then
                customerProfile.CivilStatus = "SEPARATED"
            ElseIf cs_widowed.Checked Then
                customerProfile.CivilStatus = "WIDOWED"
            End If
            customerProfile.StreetDrive = txtstreet.Text.ToUpper
            customerProfile.Barangay = txtbarangay.Text.ToUpper
            customerProfile.CityMunicipality = txtcity.Text.ToUpper
            customerProfile.BirthDate = birthdate
            customerProfile.PhoneNumber = txtcontactno.Text.ToUpper
            customerProfile.Nationality = ""
            customerProfile.Email = txtEmail.Text
            Me.CustomerProfile = customerProfile
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub btnSkip_Click(sender As Object, e As EventArgs) Handles btnSkip.Click
        If IsNothing(Me.CustomerProfile) Then
            Dim customerProfile As New CustomerInfo
            customerProfile.FirstName = ""
            customerProfile.Middlename = ""
            customerProfile.Lastname = ""
            customerProfile.Suffix = ""
            customerProfile.Suffix = ""
            customerProfile.Sex = ""
            customerProfile.CivilStatus = ""
            customerProfile.BirthDate = Now
            customerProfile.PhoneNumber = ""
            customerProfile.StreetDrive = ""
            customerProfile.Barangay = ""
            customerProfile.CityMunicipality = ""
            customerProfile.Nationality = ""
            customerProfile.Email = ""
            Me.CustomerProfile = customerProfile
        End If
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        CustomerProfile = Nothing
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CustomerProfile = Nothing
        Me.DialogResult = DialogResult.Cancel
    End Sub


    Private Sub txtbday_month_Click(sender As Object, e As EventArgs) Handles txtbday_month.Click
        GetBirthday()
    End Sub

    Private Sub txtbday_day_Click(sender As Object, e As EventArgs) Handles txtbday_day.Click
        GetBirthday()
    End Sub

    Private Sub txtbday_year_Click(sender As Object, e As EventArgs) Handles txtbday_year.Click
        GetBirthday()
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        If Not txtfname.Text.Length > 0 Then
            MessageBox.Show("First name is empty. Please enter your first name", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not txtlname.Text.Length > 0 Then
            MessageBox.Show("Middle name is empty. Please enter your middle name", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not bdateYear > 0 Or Not bdateMonth > 0 Or Not bdateYear > 0 Then
            MessageBox.Show("Birthday is empty. Please enter your Birthday", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not txtcontactno.Text.Length > 0 Then
            MessageBox.Show("Contact number is empty. Please enter your contact number", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim customerProfile As New CustomerInfo
            If Not IsNothing(Me.CustomerProfile) Then
                customerProfile = Me.CustomerProfile
            End If
            Dim birthdate As New Date(bdateYear, bdateMonth, bdateDay)
            customerProfile.FirstName = txtfname.Text.ToUpper
            customerProfile.Middlename = txtmname.Text.ToUpper
            customerProfile.Lastname = txtlname.Text.ToUpper
            customerProfile.Suffix = txtSuffix.Text.ToUpper
            If sex_male.Checked Then
                customerProfile.Sex = "MALE"
            Else
                customerProfile.Sex = "FEMALE"
            End If
            If cs_single.Checked Then
                customerProfile.CivilStatus = "SINGLE"
            ElseIf cs_married.Checked Then
                customerProfile.CivilStatus = "MARRIED"
            ElseIf cs_separated.Checked Then
                customerProfile.CivilStatus = "SEPARATED"
            ElseIf cs_widowed.Checked Then
                customerProfile.CivilStatus = "WIDOWED"
            End If
            customerProfile.StreetDrive = txtstreet.Text
            customerProfile.Barangay = txtbarangay.Text
            customerProfile.CityMunicipality = txtcity.Text
            customerProfile.BirthDate = birthdate
            customerProfile.PhoneNumber = txtcontactno.Text
            customerProfile.Nationality = ""
            customerProfile.Email = txtEmail.Text
            If Not imageChanged Then
                If Not IsNothing(customerProfile.PatientPicture) Then
                    If Not customerProfile.PatientPicture.Trim.Length > 0 Then
                        customerProfile.PatientPicture = ""
                    End If
                End If
            ElseIf IsNothing(pbProfilePicture.Image) Then
                customerProfile.PatientPicture = ""
            Else
                Dim apiControl As New APIController
                Dim imgFileLocation As String = "\\10.5.19.237\wmmc_pcms\patient_profile\"
                Dim fileCount As Long = IO.Directory.GetFiles(imgFileLocation).Count
                Dim serverDate As Date = apiControl.GetCurrentServerDate_qms()
                If Not IsNothing(serverDate) Then
                    Try
                        imgFileLocation = "\\10.5.19.237\wmmc_pcms\patient_profile\" & fileCount & serverDate.ToString("MMddyyyyHHmmsstt") & ".jpg"
                        pbProfilePicture.Image.Save(imgFileLocation)
                    Catch ex As Exception
                        imgFileLocation = ""
                    End Try
                End If
                customerProfile.PatientPicture = imgFileLocation
            End If
            Me.CustomerProfile = customerProfile
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub txtbday_month_TextChanged(sender As Object, e As EventArgs) Handles txtbday_month.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmCaptureImage()
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            imageChanged = True
            pbProfilePicture.Image = frm.CapturedImage
        End If
    End Sub
End Class