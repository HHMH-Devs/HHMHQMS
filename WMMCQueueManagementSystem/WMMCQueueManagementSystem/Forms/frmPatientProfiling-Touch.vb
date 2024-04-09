Public Class frmPatientProfiling_Touch
    Private _customerInfo As CustomerInfo = Nothing
    Private _selectedGender As String = ""
    Private _selectedCivilStatus As String = ""
    Private bdateMonth As Integer = 0
    Private bdateDay As Integer = 0
    Private bdateYear As Integer = 0
    Private dateMonth As Integer = 0
    Private dateDay As Integer = 0
    Private dateYear As Integer = 0
    Private readOnlyItem As Boolean = False
    Dim longMonth() As String = {"JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "nOVEMBER", "DECEMBER"}
    Dim phListBrgy As New List(Of PhListBrgyModel)
    Dim provinces As New DataTable
    Dim countries() As String = My.Resources.Countries.Split(",")


    Public Property CustomerProfile As CustomerInfo
        Get
            Return _customerInfo
        End Get
        Private Set(value As CustomerInfo)
            _customerInfo = value
        End Set
    End Property

    Sub New()
        _customerInfo = Nothing
        readOnlyItem = False
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        SelectCivilStatus(0)
        txtcountryofbirth.AutoCompleteCustomSource.AddRange(countries)
        txtcountryofbirth.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcountryofbirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        pnlConfirmation.Hide()
        pnlNewProfile.Show()
    End Sub

    Sub New(fname As String, mname As String, lname As String, bday As Date)
        _customerInfo = Nothing
        readOnlyItem = False
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        txtfname.Text = fname
        txtmname.Text = mname
        txtlname.Text = lname
        bdateMonth = bday.Month
        bdateDay = bday.Day
        bdateYear = bday.Year
        SetBirthday()
        SelectCivilStatus(0)
        txtcountryofbirth.AutoCompleteCustomSource.AddRange(countries)
        txtcountryofbirth.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcountryofbirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        pnlConfirmation.Hide()
        pnlNewProfile.Show()
    End Sub

    Sub New(fname As String, mname As String, lname As String, bday As Date, suffix As String, sex As String, civilStat As String, contactNo As String)
        _customerInfo = Nothing
        readOnlyItem = False
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        txtfname.Text = fname
        txtmname.Text = mname
        txtlname.Text = lname
        txtSuffix.Text = suffix.Trim
        If sex.Trim.ToUpper = "M" Or sex.Trim.ToUpper = "MALE" Then
            SelectGender(0)
        ElseIf sex.Trim.ToUpper = "F" Or sex.Trim.ToUpper = "FEMALE" Then
            SelectGender(1)
        Else
            SelectGender(0)
        End If
        If civilStat.Trim.ToUpper = "SINGLE" Then
            SelectCivilStatus(0)
        ElseIf civilStat.Trim.ToUpper = "MARRIED" Then
            SelectCivilStatus(1)
        ElseIf civilStat.Trim.ToUpper = "SEPARATED" Then
            SelectCivilStatus(2)
        ElseIf civilStat.Trim.ToUpper = "WIDOWED" Then
            SelectCivilStatus(3)
        Else
            SelectCivilStatus(0)
        End If
        txtcontactno.Text = contactNo.Trim
        bdateMonth = bday.Month
        bdateDay = bday.Day
        bdateYear = bday.Year
        txtcountryofbirth.AutoCompleteCustomSource.AddRange(countries)
        txtcountryofbirth.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcountryofbirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        SetBirthday()
        pnlConfirmation.Hide()
        pnlNewProfile.Show()
    End Sub

    Sub New(customer As CustomerInfo)
        _customerInfo = customer
        Me.Tag = customer.Info_ID
        readOnlyItem = True
        ' This call is required by the designer.
        InitializeComponent()
        roundCorners(Me)
        txtfname.Text = _customerInfo.FirstName
        txtmname.Text = _customerInfo.Middlename
        txtlname.Text = _customerInfo.Lastname
        txtSuffix.Text = _customerInfo.Suffix
        If _customerInfo.Sex.ToUpper = "M" Or _customerInfo.Sex.ToUpper = "MALE" Then
            SelectGender(0)
        ElseIf _customerInfo.Sex.ToUpper = "F" Or _customerInfo.Sex.ToUpper = "FEMALE" Then
            SelectGender(1)
        End If
        If _customerInfo.CivilStatus.ToUpper = "SINGLE" Then
            SelectCivilStatus(0)
        ElseIf _customerInfo.CivilStatus.ToUpper = "MARRIED" Then
            SelectCivilStatus(1)
        ElseIf _customerInfo.CivilStatus.ToUpper = "SEPARATED" Then
            SelectCivilStatus(2)
        ElseIf _customerInfo.CivilStatus.ToUpper = "WIDOWED" Then
            SelectCivilStatus(3)
        End If
        bdateMonth = _customerInfo.BirthDate.Month
        bdateDay = _customerInfo.BirthDate.Day
        bdateYear = _customerInfo.BirthDate.Year
        SetBirthday()
        txtcontactno.Text = If(_customerInfo.PhoneNumber.Trim.Length > 0, _customerInfo.PhoneNumber, "09")
        txtemail.Text = _customerInfo.Email.ToLower
        If customer.Nationality.Split("-").Count > 1 Then
            txtcountryofbirth.Text = customer.Nationality.Split("-")(1).Trim
        End If
        txtnationality.Text = customer.Nationality.Split("-")(0).Trim
        txtidtype.Text = customer.IdentificationInfo.ID_Type
        txtidnum.Text = customer.IdentificationInfo.ID_Number
        txtidvaliduntil.Text = customer.IdentificationInfo.ValidUntil
        pnlNewProfile.Hide()
        pnlConfirmation.Show()
        Dim controller = New AddressController
        Dim prov = controller.GetProvince()
        txtprovince.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtprovince.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtprovince.AutoCompleteCustomSource.AddRange(prov.ToArray)
        txtcitymun.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtcitymun.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtbarangay.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtbarangay.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcountryofbirth.AutoCompleteCustomSource.AddRange(countries)
        txtcountryofbirth.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtcountryofbirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        txtprovince.Text = IIf(Not IsNothing(customer.Province), customer.Province.ToUpper, "")
        txtcitymun.Text = IIf(Not IsNothing(customer.CityMunicipality), customer.CityMunicipality.ToUpper, "")
        txtbarangay.Text = IIf(Not IsNothing(customer.Barangay), customer.Barangay.ToUpper, "")
        txtstreet.Text = IIf(Not IsNothing(customer.StreetDrive), customer.StreetDrive.ToUpper, "")
    End Sub

    Private Sub RoundButton(btn As Button)
        btn.FlatAppearance.BorderSize = 0
        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, btn.Width - 20, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(btn.Width - 20, 0, 20, 20), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(btn.Width, 20, btn.Width, btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(btn.Width - 25, btn.Height - 25, 25, 25), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(btn.Width - 10, btn.Width, 20, btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, btn.Height - 20, 20, 20), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        btn.Region = New Region(Raduis)
    End Sub

    Private Sub SelectCivilStatus(flag As Integer)
        _selectedCivilStatus = ""
        btnSingle.BackColor = Color.DarkGray
        btnMarried.BackColor = Color.DarkGray
        btnSeparated.BackColor = Color.DarkGray
        btnWidowed.BackColor = Color.DarkGray
        If flag = 0 Then
            _selectedCivilStatus = "SINGLE"
            btnSingle.BackColor = Color.DeepSkyBlue
            lblSelectedCivilStatus.Text = "SINGLE"
            lblSelectedCivilStatus.ForeColor = Color.DeepSkyBlue
        ElseIf flag = 1 Then
            _selectedCivilStatus = "MARRIED"
            btnMarried.BackColor = Color.FromArgb(13, 52, 145)
            lblSelectedCivilStatus.Text = "MARRIED"
            lblSelectedCivilStatus.ForeColor = Color.DeepSkyBlue
        ElseIf flag = 2 Then
            _selectedCivilStatus = "SEPARATED"
            btnSeparated.BackColor = Color.DeepSkyBlue
            lblSelectedCivilStatus.Text = "SEPARATED"
            lblSelectedCivilStatus.ForeColor = Color.DeepSkyBlue
        ElseIf flag = 3 Then
            _selectedCivilStatus = "WIDOWED"
            btnWidowed.BackColor = Color.DeepSkyBlue
            lblSelectedCivilStatus.Text = "WIDOWED"
            lblSelectedCivilStatus.ForeColor = Color.DeepSkyBlue
        End If
    End Sub

    Private Sub SelectGender(flag As Integer)
        pbFemale.BackColor = Color.DarkGray
        pbMale.BackColor = Color.DarkGray
        lblSelectedGender.Text = "NONE"
        lblSelectedGender.ForeColor = Color.DarkGray
        If flag = 0 Then
            _selectedGender = "MALE"
            pbMale.BackColor = Color.DeepSkyBlue
            lblSelectedGender.Text = "MALE"
            lblSelectedGender.ForeColor = Color.DeepSkyBlue
        ElseIf flag = 1 Then
            _selectedGender = "FEMALE"
            pbFemale.BackColor = Color.LightCoral
            lblSelectedGender.Text = "FEMALE"
            lblSelectedGender.ForeColor = Color.LightCoral
        End If
    End Sub

    Private Sub roundCorners(obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None
        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()
        'top left corner
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)
        'top right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)
        'buttom right corner
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
        'buttom left corner
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        DGP.CloseFigure()
        obj.Region = New Region(DGP)
    End Sub

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

    Private Sub GetIdValidUntil()
        Dim frm As New frmSelectBDayForTouch
        frm.ShowDialog(Me)
        If frm.DialogResult = DialogResult.Yes Then
            If frm.SelectedMonth > 0 And frm.SelectedDay > 0 And frm.SelectedYear > 0 Then
                dateMonth = frm.SelectedMonth
                dateDay = frm.SelectedDay
                dateYear = frm.SelectedYear
                SetValidUntil()
            End If
        End If
    End Sub

    Private Sub SetBirthday()
        Dim bdayString As String = ""
        If bdateMonth > 0 Then
            bdayString &= longMonth(bdateMonth - 1)
        Else
            bdayString &= "--"
        End If
        If bdateDay > 0 Then
            If bdateDay > 9 Then
                bdayString = bdayString & " " & bdateDay
            Else
                bdayString = bdayString & " 0" & bdateDay
            End If
        Else
            bdayString &= " --"
        End If
        If bdateYear > 0 Then
            bdayString = bdayString & " " & bdateYear
        Else
            bdayString &= " ----"
        End If
        txtbday.Text = bdayString.ToUpper()
    End Sub

    Private Sub SetValidUntil()
        Dim dayString As String = ""
        If dateMonth > 0 Then
            dayString &= longMonth(dateMonth - 1)
        Else
            dayString &= "--"
        End If
        If dateDay > 0 Then
            If dateDay > 9 Then
                dayString = dayString & " " & dateDay
            Else
                dayString = dayString & " 0" & dateDay
            End If
        Else
            dayString &= " --"
        End If
        If dateYear > 0 Then
            dayString = dayString & " " & dateYear
        Else
            dayString &= " ----"
        End If
        txtidvaliduntil.Text = dayString.ToUpper()
    End Sub

    Private Sub pbMale_Click(sender As Object, e As EventArgs) Handles pbMale.Click
        CloseOnScreenKeyboard()
        SelectGender(0)
    End Sub

    Private Sub pbFemale_Click(sender As Object, e As EventArgs) Handles pbFemale.Click
        CloseOnScreenKeyboard()
        SelectGender(1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not txtfname.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your first name", Me.txtfname)
            End With
        ElseIf Not txtlname.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your last name", Me.txtlname)
            End With
        ElseIf Not txtmname.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your middle name", Me.txtmname)
            End With
        ElseIf Not _selectedCivilStatus.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please select your civil status", Me.GroupBox1)
            End With
        ElseIf Not _selectedGender.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please select your gender", Me.gbsex)
            End With
        ElseIf Not txtcontactno.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your contact number", Me.txtcontactno)
            End With
        Else
            Dim idInfo As New CustomerIdentificationInfo With {
                .Info_ID = Me.Tag,
                .ID_Type = txtidtype.Text,
                .ID_Number = txtidnum.Text,
                .ValidUntil = txtidvaliduntil.Text
            }
            Dim birthdate As Date
            Try
                birthdate = New Date(bdateYear, bdateMonth, bdateDay)
            Catch ex As Exception
                MessageBox.Show("Please enter a valid birth date", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            If Not IsNothing(Me._customerInfo) Then
                With Me._customerInfo
                    .Info_ID = Me.Tag
                    .FirstName = txtfname.Text.ToUpper
                    .Middlename = txtmname.Text.ToUpper
                    .Lastname = txtlname.Text.ToUpper
                    .Suffix = txtSuffix.Text.ToUpper
                    .Sex = _selectedGender
                    .BirthDate = birthdate
                    .CivilStatus = _selectedCivilStatus
                    .PhoneNumber = txtcontactno.Text.ToUpper
                    .Nationality = txtnationality.Text.ToUpper & " - " & txtcountryofbirth.Text.ToUpper
                    .IdentificationInfo = idInfo
                    .Email = txtemail.Text
                    .Barangay = txtbarangay.Text.ToUpper
                    .CityMunicipality = txtcitymun.Text.ToUpper
                    .Province = txtprovince.Text.ToUpper
                    .StreetDrive = txtstreet.Text.ToUpper
                End With
            Else
                Dim customerInfo = New CustomerInfo
                With customerInfo
                    .Info_ID = Me.Tag
                    .FirstName = txtfname.Text.ToUpper
                    .Middlename = txtmname.Text.ToUpper
                    .Lastname = txtlname.Text.ToUpper
                    .Suffix = txtSuffix.Text.ToUpper
                    .Sex = _selectedGender
                    .BirthDate = birthdate
                    .CivilStatus = _selectedCivilStatus
                    .PhoneNumber = txtcontactno.Text.ToUpper
                    .Nationality = txtnationality.Text.ToUpper & " - " & txtcountryofbirth.Text.ToUpper
                    .IdentificationInfo = idInfo
                    .Email = txtemail.Text
                    .Barangay = txtbarangay.Text.ToUpper
                    .CityMunicipality = txtcitymun.Text.ToUpper
                    .Province = txtprovince.Text.ToUpper
                    .StreetDrive = txtstreet.Text.ToUpper
                End With
                Me._customerInfo = customerInfo
            End If
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not txtfname.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your first name", Me.txtfname)
            End With
        ElseIf Not txtlname.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your last name", Me.txtlname)
            End With
        ElseIf Not _selectedCivilStatus.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please select your civil status", Me.GroupBox1)
            End With
        ElseIf Not _selectedGender.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please select your gender", Me.gbsex)
            End With
        ElseIf Not txtcontactno.Text.Trim.Length > 0 Then
            Dim _tooltip As New ToolTip
            With _tooltip
                .AutomaticDelay = 100
                .AutoPopDelay = 500
                .InitialDelay = 50
                .ReshowDelay = 20
                .Show("Please enter your contact number", Me.txtcontactno)
            End With
        Else
            Dim birthdate As Date
            Try
                birthdate = New Date(bdateYear, bdateMonth, bdateDay)
            Catch ex As Exception
                MessageBox.Show("Please enter a valid birth date", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim idInfo As New CustomerIdentificationInfo With {
                .Info_ID = Me.Tag,
                .ID_Type = txtidtype.Text,
                .ID_Number = txtidnum.Text,
                .ValidUntil = txtidvaliduntil.Text
            }

            Dim customerProfile As New CustomerInfo With {
                .Info_ID = Me.Tag,
                .FirstName = txtfname.Text.ToUpper,
                .Middlename = txtmname.Text.ToUpper,
                .Lastname = txtlname.Text.ToUpper,
                .Suffix = txtSuffix.Text.ToUpper,
                .Sex = _selectedGender,
                .BirthDate = birthdate,
                .CivilStatus = _selectedCivilStatus,
                .PhoneNumber = txtcontactno.Text.ToUpper,
                .Nationality = txtnationality.Text,
                .IdentificationInfo = idInfo,
                .Email = txtemail.Text,
                .Barangay = txtbarangay.Text,
                .CityMunicipality = txtcitymun.Text,
                .Province = txtprovince.Text,
                .StreetDrive = txtstreet.Text
            }
            Me._customerInfo = customerProfile
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub txtbday_Click(sender As Object, e As EventArgs) Handles txtbday.Click
        CloseOnScreenKeyboard()
        GetBirthday()
    End Sub

    Private Sub txtfname_Click(sender As Object, e As EventArgs) Handles txtfname.Click
        OpenOnScreenKeyboard()
    End Sub
    Private Sub txtmname_Click(sender As Object, e As EventArgs) Handles txtmname.Click
        OpenOnScreenKeyboard()
    End Sub

    Private Sub txtlname_Click(sender As Object, e As EventArgs) Handles txtlname.Click
        OpenOnScreenKeyboard()
    End Sub
    Private Sub txtcontactno_Click(sender As Object, e As EventArgs) Handles txtcontactno.Click
        OpenOnScreenKeyboard()
    End Sub

    Private Sub btnSingle_Click(sender As Object, e As EventArgs) Handles btnSingle.Click
        SelectCivilStatus(0)
    End Sub

    Private Sub btnMarried_Click(sender As Object, e As EventArgs) Handles btnMarried.Click
        SelectCivilStatus(1)
    End Sub

    Private Sub btnSeparated_Click(sender As Object, e As EventArgs) Handles btnSeparated.Click
        SelectCivilStatus(2)
    End Sub

    Private Sub btnWidowed_Click(sender As Object, e As EventArgs) Handles btnWidowed.Click
        SelectCivilStatus(3)
    End Sub

    Private Sub txtidvaliduntil_Click(sender As Object, e As EventArgs) Handles txtidvaliduntil.Click
        CloseOnScreenKeyboard()
        GetIdValidUntil()
    End Sub

    Private Sub txtcitymun_TextChanged(sender As Object, e As EventArgs) Handles txtcitymun.TextChanged
        Dim controller = New AddressController
        Dim brgy = controller.GetBrgy(txtcitymun.Text)
        txtbarangay.AutoCompleteCustomSource.AddRange(brgy.ToArray)
    End Sub

    Private Sub txtprovince_TextChanged(sender As Object, e As EventArgs) Handles txtprovince.TextChanged
        Dim controller = New AddressController
        Dim brgy = controller.GetCityMun(txtprovince.Text)
        txtcitymun.AutoCompleteCustomSource.AddRange(brgy.ToArray)
    End Sub
End Class