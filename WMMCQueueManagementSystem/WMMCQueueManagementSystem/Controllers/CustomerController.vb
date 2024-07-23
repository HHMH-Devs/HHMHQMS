Imports System.Data.SqlClient
Public Class CustomerController

    Public Function GetCertainCustomer(ID As Long) As Customer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT b.*, a.customer_id,a.fullname,a.address,a.dateofvisit,a.FK_emdPatients, c.* FROM [wmmcqms].[customer] as a LEFT JOIN [dbo].[customerinfo] as b ON a.FK_emdPatients = b.FK_emdPatients LEFT JOIN [dbo].[customerotherinfo] as c ON c.Info_ID = b.info_id WHERE [customer_id] = @ID;
                               SELECT b.*, a.customer_id,a.fullname,a.address,a.dateofvisit,a.FK_emdPatients, c.* FROM [wmmcqms].[customer] as a LEFT JOIN [dbo].[customerinfo] as b ON a.info_id = b.info_id LEFT JOIN [dbo].[customerotherinfo] as c ON c.Info_ID = b.info_id WHERE [customer_id] = @ID;"
            cmd.Parameters.AddWithValue("@ID", ID)
            Dim datas As DataSet = fetchData(cmd)
            Dim data1 As DataTable = datas.Tables(0)
            Dim data2 As DataTable = datas.Tables(1)
            If Not IsNothing(datas) Then
                Dim dataToUse As DataTable = Nothing
                If data1.Rows.Count > 0 And data1.Rows.Count = 1 Then
                    dataToUse = data1
                ElseIf data2.Rows.Count > 0 Then
                    dataToUse = data2
                End If
                If Not IsNothing(dataToUse) Then
                    Dim customer As New Customer
                    customer.Customer_ID = dataToUse.Rows(0)("customer_id")
                    customer.FullName = If(Not IsDBNull(dataToUse.Rows(0)("fullname")), dataToUse.Rows(0)("fullname"), "")
                    customer.Address = If(Not IsDBNull(dataToUse.Rows(0)("address")), dataToUse.Rows(0)("address"), "")
                    customer.PhoneNumber = If(Not IsDBNull(dataToUse.Rows(0)("phonenumber")), dataToUse.Rows(0)("phonenumber"), "")
                    customer.DateOfVisit = dataToUse.Rows(0)("dateofvisit")
                    customer.FK_emdPatients = If(Not IsDBNull(dataToUse.Rows(0)("FK_emdPatients")), dataToUse.Rows(0)("FK_emdPatients"), 0)
                    customer.CustomerInfo = New CustomerInfo
                    customer.CustomerInfo.Info_ID = If(Not IsDBNull(dataToUse.Rows(0)("info_id")), dataToUse.Rows(0)("info_id"), 0)
                    customer.CustomerInfo.FirstName = If(Not IsDBNull(dataToUse.Rows(0)("firstname")), dataToUse.Rows(0)("firstname"), "")
                    customer.CustomerInfo.Middlename = If(Not IsDBNull(dataToUse.Rows(0)("middlename")), dataToUse.Rows(0)("middlename"), "")
                    customer.CustomerInfo.Lastname = If(Not IsDBNull(dataToUse.Rows(0)("lastname")), dataToUse.Rows(0)("lastname"), "")
                    customer.CustomerInfo.Sex = If(Not IsDBNull(dataToUse.Rows(0)("sex")), dataToUse.Rows(0)("sex"), "")
                    customer.CustomerInfo.BirthDate = If(Not IsDBNull(dataToUse.Rows(0)("birthdate")), dataToUse.Rows(0)("birthdate"), Now)
                    customer.CustomerInfo.CivilStatus = If(Not IsDBNull(dataToUse.Rows(0)("civilstatus")), dataToUse.Rows(0)("civilstatus"), "")
                    customer.CustomerInfo.StreetDrive = If(Not IsDBNull(dataToUse.Rows(0)("street")), dataToUse.Rows(0)("street"), "")
                    customer.CustomerInfo.Barangay = If(Not IsDBNull(dataToUse.Rows(0)("barangay")), dataToUse.Rows(0)("barangay"), "")
                    customer.CustomerInfo.CityMunicipality = If(Not IsDBNull(dataToUse.Rows(0)("city")), dataToUse.Rows(0)("city"), "")
                    customer.CustomerInfo.Province = If(Not IsDBNull(dataToUse.Rows(0)("province")), dataToUse.Rows(0)("province"), "")
                    customer.CustomerInfo.PhoneNumber = If(Not IsDBNull(dataToUse.Rows(0)("phonenumber")), dataToUse.Rows(0)("phonenumber"), 0)
                    customer.CustomerInfo.Nationality = If(Not IsDBNull(dataToUse.Rows(0)("nationality")), dataToUse.Rows(0)("nationality"), "")
                    customer.CustomerInfo.Email = If(Not IsDBNull(dataToUse.Rows(0)("email")), dataToUse.Rows(0)("email"), "")
                    customer.CustomerInfo.PatientPicture = If(Not IsDBNull(dataToUse.Rows(0)("picturelocation")), dataToUse.Rows(0)("picturelocation"), "")
                    customer.CustomerInfo.FK_emdPatients = If(Not IsDBNull(dataToUse.Rows(0)("FK_emdPatients")), dataToUse.Rows(0)("FK_emdPatients"), 0)
                    Dim IdentificationInfo = New CustomerIdentificationInfo With {
                        .OtherInfo_ID = If(Not IsDBNull(dataToUse.Rows(0)("OtherInfo_ID")), dataToUse.Rows(0)("OtherInfo_ID"), 0),
                        .Info_ID = If(Not IsDBNull(dataToUse.Rows(0)("Info_ID")), dataToUse.Rows(0)("Info_ID"), 0),
                        .ID_Type = If(Not IsDBNull(dataToUse.Rows(0)("ID_Type")), dataToUse.Rows(0)("ID_Type"), 0),
                        .ID_Number = If(Not IsDBNull(dataToUse.Rows(0)("ID_Number")), dataToUse.Rows(0)("ID_Number"), 0),
                        .ValidUntil = If(Not IsDBNull(dataToUse.Rows(0)("Valid_Until")), dataToUse.Rows(0)("Valid_Until"), 0)
                    }
                    customer.CustomerInfo.IdentificationInfo = IdentificationInfo
                    Dim cmdHealthCheck As New SqlCommand
                    cmdHealthCheck.CommandText = "SELECT * FROM [dbo].[healthcheckdata] WHERE info_id = @ID AND CONVERT(DATE,dateofassesment) = CONVERT(DATE,GETDATE()) ORDER BY dateofassesment desc;"
                    cmdHealthCheck.Parameters.AddWithValue("@ID", dataToUse.Rows(0)("info_id"))
                    Dim dtHealthCheck As DataTable = fetchData(cmdHealthCheck).Tables(0)
                    If Not IsNothing(dtHealthCheck) Then
                        If dtHealthCheck.Rows.Count > 0 Then
                            customer.CustomerInfo.HealthCheck = New HealthCheck
                            customer.CustomerInfo.HealthCheck.HealthCheck_ID = dtHealthCheck.Rows(0)("healthcheck_id")
                            customer.CustomerInfo.HealthCheck.Fever = dtHealthCheck.Rows(0)("feverchills")
                            customer.CustomerInfo.HealthCheck.Cough = dtHealthCheck.Rows(0)("cough")
                            customer.CustomerInfo.HealthCheck.Sorethroat = dtHealthCheck.Rows(0)("sorethroat")
                            customer.CustomerInfo.HealthCheck.Diarrhea = dtHealthCheck.Rows(0)("diarrhea")
                            customer.CustomerInfo.HealthCheck.ShortnessOfBreathing = dtHealthCheck.Rows(0)("shortnessofbreathing")
                            customer.CustomerInfo.HealthCheck.Ageusia = dtHealthCheck.Rows(0)("ageusia")
                            customer.CustomerInfo.HealthCheck.Anosmia = dtHealthCheck.Rows(0)("anosmia")
                            customer.CustomerInfo.HealthCheck.Colds = dtHealthCheck.Rows(0)("colds")
                            customer.CustomerInfo.HealthCheck.CloseContactConfirmed = dtHealthCheck.Rows(0)("closecontactconfirmed")
                            customer.CustomerInfo.HealthCheck.CloseContactExhiting = dtHealthCheck.Rows(0)("closecontactpersonexhibiting")
                            customer.CustomerInfo.HealthCheck.DateOfAssesment = dtHealthCheck.Rows(0)("dateofassesment")
                            customer.CustomerInfo.HealthCheck.Fk_emdPatient = dtHealthCheck.Rows(0)("FK_emdPatients")
                            customer.CustomerInfo.HealthCheck.Info_ID = dtHealthCheck.Rows(0)("info_id")
                        End If
                    End If
                    Return customer
                End If
            End If
            Return Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return Nothing
        End Try
    End Function

    Public Function GetPatID(id As Integer) As Integer
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * from emdPatients where PK_emdPatients = @id"
            cmd.Parameters.AddWithValue("@id", id)
            Dim data = fetchData(cmd, WMMCQMSConfig.openDatabaseBizbox).Tables(0)
            Return data.Rows(0).Item("patid")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function NewCustomer(customer As Customer) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO  wmmcqms.customer ( fullname, address, phonenumber) VALUES (@fname, @addr, @phone);"
            cmd.Parameters.AddWithValue("@fname", If(IsNothing(customer.FullName), DBNull.Value, customer.FullName))
            cmd.Parameters.AddWithValue("@addr", If(IsNothing(customer.Address), DBNull.Value, customer.Address))
            cmd.Parameters.AddWithValue("@phone", If(IsNothing(customer.PhoneNumber), DBNull.Value, customer.PhoneNumber))

            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Function RenameCustomer(customer As Customer) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "UPDATE [wmmcqms].[customer] SET [fullname] = @name WHERE [customer_id] = @ID"
            cmd.Parameters.AddWithValue("@name", customer.FullName)
            cmd.Parameters.AddWithValue("@ID", customer.Customer_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

End Class
