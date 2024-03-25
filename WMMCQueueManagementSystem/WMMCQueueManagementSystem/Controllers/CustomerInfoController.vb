Imports System.Data
Imports System.Data.SqlClient
Public Class CustomerInfoController

    Public Function EditCustomerInfo(servingCustomer As ServedCustomer, newCustomerInfo As CustomerInfo) As ServedCustomer
        Try
            Dim cmdUpdateCustomerInfo As New SqlCommand
            Dim proceed As Boolean = False
            If newCustomerInfo.Info_ID > 0 Then
                cmdUpdateCustomerInfo.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname ,[middlename] = @mnanme ,[lastname] = @lname ,[sex] = @sex,[birthdate] = @bday ,[civilstatus] = @cstat ,[street] = @street ,[barangay] = @brgy ,[city] = @city ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email, [picturelocation] = @imgloc WHERE info_id = @ID"
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@fname", newCustomerInfo.FirstName)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@mnanme", newCustomerInfo.Middlename)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@lname", newCustomerInfo.Lastname)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@sex", newCustomerInfo.Sex)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@bday", newCustomerInfo.BirthDate)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@cstat", newCustomerInfo.CivilStatus)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@street", newCustomerInfo.StreetDrive)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@brgy", newCustomerInfo.Barangay)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@city", newCustomerInfo.CityMunicipality)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@cp", newCustomerInfo.PhoneNumber)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@nat", newCustomerInfo.Nationality)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@email", newCustomerInfo.Email)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@imgloc", newCustomerInfo.PatientPicture)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@ID", newCustomerInfo.Info_ID)
                proceed = excecuteCommand(cmdUpdateCustomerInfo)
            Else
                cmdUpdateCustomerInfo.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname] ,[middlename] ,[lastname] ,[sex] ,[birthdate] ,[civilstatus] ,[street] ,[barangay] ,[city] ,[phonenumber] ,[nationality] ,[email] ,[FK_emdPatients]) VALUES (@fname ,@mname ,@lname ,@sex ,@bday ,@cstat ,@street ,@brgy ,@city ,@cp ,@nat ,@email ,@fkemd); SELECT @@IDENTITY"
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@fname", newCustomerInfo.FirstName)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@mname", newCustomerInfo.Middlename)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@lname", newCustomerInfo.Lastname)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@sex", newCustomerInfo.Sex)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@bday", newCustomerInfo.BirthDate)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@cstat", newCustomerInfo.CivilStatus)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@street", newCustomerInfo.StreetDrive)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@brgy", newCustomerInfo.Barangay)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@city", newCustomerInfo.CityMunicipality)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@cp", newCustomerInfo.PhoneNumber)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@nat", newCustomerInfo.Nationality)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@email", newCustomerInfo.Email)
                cmdUpdateCustomerInfo.Parameters.AddWithValue("@fkemd", newCustomerInfo.FK_emdPatients)
                newCustomerInfo.Info_ID = excecuteCommandReturnID(cmdUpdateCustomerInfo)
                If newCustomerInfo.Info_ID > 0 Then
                    proceed = True
                End If
            End If
            If proceed Then
                Dim cmdUpdateCustomer As New SqlCommand
                Dim newCustomer As New Customer
                newCustomer.FullName = newCustomerInfo.Lastname.ToUpper & " " & newCustomerInfo.FirstName.ToUpper & " " & newCustomerInfo.Suffix.ToUpper & " " & newCustomerInfo.Middlename.ToUpper
                newCustomer.PhoneNumber = newCustomerInfo.PhoneNumber
                newCustomer.FK_emdPatients = newCustomerInfo.FK_emdPatients
                cmdUpdateCustomer.CommandText = "UPDATE [wmmcqms].[customer] SET [fullname] = @funame,[phonenumber] = @cp,[FK_emdPatients] = @fkid, [info_id] = @infid WHERE [customer_id] = @ID"
                cmdUpdateCustomer.Parameters.AddWithValue("@funame", newCustomer.FullName)
                cmdUpdateCustomer.Parameters.AddWithValue("@cp", newCustomer.PhoneNumber)
                cmdUpdateCustomer.Parameters.AddWithValue("@fkid", newCustomer.FK_emdPatients)
                cmdUpdateCustomer.Parameters.AddWithValue("@infid", newCustomerInfo.Info_ID)
                cmdUpdateCustomer.Parameters.AddWithValue("@ID", servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                If excecuteCommand(cmdUpdateCustomer) Then
                    Dim customerController As New CustomerController
                    newCustomer = customerController.GetCertainCustomer(servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                    servingCustomer.CustomerAssignCounter.Customer = newCustomer
                    Return servingCustomer
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return Nothing
        End Try
    End Function

    Public Function SyncCustomerInfo(servingCustomer As ServedCustomer, newCustomerInfo As CustomerInfo) As ServedCustomer
        Try
            Dim cmdIfExistCustomerInfo As New SqlCommand
            cmdIfExistCustomerInfo.CommandText = "SELECT * FROM [dbo].[customerinfo] WHERE FK_emdPatients = @ID"
            cmdIfExistCustomerInfo.Parameters.AddWithValue("@ID", newCustomerInfo.FK_emdPatients)
            Dim data As DataTable = fetchData(cmdIfExistCustomerInfo).Tables(0)
            If Not IsNothing(data) Then
                If data.Rows.Count > 0 Then 'Checks if New Patient already Exist on the Customer Info Table
                    'If Exist
                    Dim cmdUpdateCustomerInfo As New SqlCommand
                    cmdUpdateCustomerInfo.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname ,[middlename] = @mnanme ,[lastname] = @lname ,[sex] = @sex,[birthdate] = @bday ,[civilstatus] = @cstat ,[street] = @street ,[barangay] = @brgy ,[city] = @city ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email WHERE info_id = @ID"
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@fname", newCustomerInfo.FirstName)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@mnanme", newCustomerInfo.Middlename)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@lname", newCustomerInfo.Lastname)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@sex", newCustomerInfo.Sex)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@bday", newCustomerInfo.BirthDate)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@cstat", newCustomerInfo.CivilStatus)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@street", newCustomerInfo.StreetDrive)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@brgy", newCustomerInfo.Barangay)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@city", newCustomerInfo.CityMunicipality)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@cp", newCustomerInfo.PhoneNumber)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@nat", newCustomerInfo.Nationality)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@email", newCustomerInfo.Email)
                    cmdUpdateCustomerInfo.Parameters.AddWithValue("@ID", newCustomerInfo.Info_ID)
                    If excecuteCommand(cmdUpdateCustomerInfo) Then
                        Dim cmdUpdateCustomer As New SqlCommand
                        Dim newCustomer As New Customer
                        newCustomer.FullName = newCustomerInfo.Lastname.ToUpper & " " & newCustomerInfo.FirstName.ToUpper & " " & newCustomerInfo.Suffix.ToUpper & " " & newCustomerInfo.Middlename.ToUpper
                        newCustomer.PhoneNumber = newCustomerInfo.PhoneNumber
                        newCustomer.FK_emdPatients = newCustomerInfo.FK_emdPatients
                        cmdUpdateCustomer.CommandText = "UPDATE [wmmcqms].[customer] SET [fullname] = @funame,[phonenumber] = @cp,[FK_emdPatients] = @fkid, [info_id] = @infid WHERE [customer_id] = @ID"
                        cmdUpdateCustomer.Parameters.AddWithValue("@funame", newCustomer.FullName)
                        cmdUpdateCustomer.Parameters.AddWithValue("@cp", newCustomer.PhoneNumber)
                        cmdUpdateCustomer.Parameters.AddWithValue("@fkid", newCustomer.FK_emdPatients)
                        cmdUpdateCustomer.Parameters.AddWithValue("@infid", newCustomerInfo.Info_ID)
                        cmdUpdateCustomer.Parameters.AddWithValue("@ID", servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                        If excecuteCommand(cmdUpdateCustomer) Then
                            Dim customerController As New CustomerController
                            newCustomer = customerController.GetCertainCustomer(servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                            If Me.SyncCustomerTransactions(servingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.FK_emdPatients) Then
                                servingCustomer.CustomerAssignCounter.Customer = newCustomer
                                Return servingCustomer
                            End If
                        End If
                    End If
                Else
                    'If Not Exist
                    Dim cmdUpdateCustomerInfo As New SqlCommand
                    If servingCustomer.CustomerAssignCounter.Customer.FK_emdPatients > 0 Then 'Checks if the old patient was already sync
                        'if already sync
                        cmdUpdateCustomerInfo.CommandText = "INSERT INTO [dbo].[customerinfo] ([firstname] ,[middlename] ,[lastname] ,[sex] ,[birthdate] ,[civilstatus] ,[street] ,[barangay] ,[city] ,[phonenumber] ,[nationality] ,[email] ,[FK_emdPatients]) VALUES (@fname ,@mname ,@lname ,@sex ,@bday ,@cstat ,@street ,@brgy ,@city ,@cp ,@nat ,@email ,@fkemd); SELECT @@IDENTITY"
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@fname", newCustomerInfo.FirstName)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@mname", newCustomerInfo.Middlename)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@lname", newCustomerInfo.Lastname)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@sex", newCustomerInfo.Sex)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@bday", newCustomerInfo.BirthDate)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@cstat", newCustomerInfo.CivilStatus)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@street", newCustomerInfo.StreetDrive)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@brgy", newCustomerInfo.Barangay)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@city", newCustomerInfo.CityMunicipality)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@cp", newCustomerInfo.PhoneNumber)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@nat", newCustomerInfo.Nationality)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@email", newCustomerInfo.Email)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@fkemd", newCustomerInfo.FK_emdPatients)
                        Dim insertedCustomerInfo As Long = excecuteCommandReturnID(cmdUpdateCustomerInfo)
                        If insertedCustomerInfo > -1 Then
                            Dim cmdUpdateCustomer As New SqlCommand
                            Dim newCustomer As New Customer
                            newCustomer.FullName = newCustomerInfo.Lastname.ToUpper & " " & newCustomerInfo.FirstName.ToUpper & " " & newCustomerInfo.Suffix.ToUpper & " " & newCustomerInfo.Middlename.ToUpper
                            newCustomer.PhoneNumber = newCustomerInfo.PhoneNumber
                            newCustomer.FK_emdPatients = newCustomerInfo.FK_emdPatients
                            cmdUpdateCustomer.CommandText = "UPDATE [wmmcqms].[customer] SET [fullname] = @funame,[phonenumber] = @cp,[FK_emdPatients] = @fkid, [info_id] = @infid WHERE [customer_id] = @ID"
                            cmdUpdateCustomer.Parameters.AddWithValue("@funame", newCustomer.FullName)
                            cmdUpdateCustomer.Parameters.AddWithValue("@cp", newCustomer.PhoneNumber)
                            cmdUpdateCustomer.Parameters.AddWithValue("@fkid", newCustomer.FK_emdPatients)
                            cmdUpdateCustomer.Parameters.AddWithValue("@infid", insertedCustomerInfo)
                            cmdUpdateCustomer.Parameters.AddWithValue("@ID", servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                            If excecuteCommand(cmdUpdateCustomer) Then
                                Dim customerController As New CustomerController
                                newCustomer = customerController.GetCertainCustomer(servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                                If Me.SyncCustomerTransactions(servingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.FK_emdPatients) Then
                                    servingCustomer.CustomerAssignCounter.Customer = newCustomer
                                    Return servingCustomer
                                End If
                            End If
                        End If
                    Else
                        'if not yet sync
                        cmdUpdateCustomerInfo.CommandText = "UPDATE [dbo].[customerinfo] SET [firstname] = @fname ,[middlename] = @mnanme ,[lastname] = @lname ,[sex] = @sex,[birthdate] = @bday ,[civilstatus] = @cstat ,[street] = @street ,[barangay] = @brgy ,[city] = @city ,[phonenumber] = @cp ,[nationality] = @nat ,[email] = @email ,[FK_emdPatients] = @fkemd WHERE info_id = @ID"
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@fname", newCustomerInfo.FirstName)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@mnanme", newCustomerInfo.Middlename)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@lname", newCustomerInfo.Lastname)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@sex", newCustomerInfo.Sex)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@bday", newCustomerInfo.BirthDate)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@cstat", newCustomerInfo.CivilStatus)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@street", newCustomerInfo.StreetDrive)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@brgy", newCustomerInfo.Barangay)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@city", newCustomerInfo.CityMunicipality)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@cp", newCustomerInfo.PhoneNumber)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@nat", newCustomerInfo.Nationality)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@email", newCustomerInfo.Email)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@fkemd", newCustomerInfo.FK_emdPatients)
                        cmdUpdateCustomerInfo.Parameters.AddWithValue("@ID", servingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                        If excecuteCommand(cmdUpdateCustomerInfo) Then
                            Dim cmdUpdateCustomer As New SqlCommand
                            Dim newCustomer As New Customer
                            newCustomer.FullName = newCustomerInfo.Lastname.ToUpper & " " & newCustomerInfo.FirstName.ToUpper & " " & newCustomerInfo.Suffix.ToUpper & " " & newCustomerInfo.Middlename.ToUpper
                            newCustomer.PhoneNumber = newCustomerInfo.PhoneNumber
                            newCustomer.FK_emdPatients = newCustomerInfo.FK_emdPatients
                            cmdUpdateCustomer.CommandText = "UPDATE [wmmcqms].[customer] SET [fullname] = @funame,[phonenumber] = @cp,[FK_emdPatients] = @fkid WHERE [info_id] = @ID"
                            cmdUpdateCustomer.Parameters.AddWithValue("@funame", newCustomer.FullName)
                            cmdUpdateCustomer.Parameters.AddWithValue("@cp", newCustomer.PhoneNumber)
                            cmdUpdateCustomer.Parameters.AddWithValue("@fkid", newCustomer.FK_emdPatients)
                            cmdUpdateCustomer.Parameters.AddWithValue("@ID", servingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID)
                            If excecuteCommand(cmdUpdateCustomer) Then
                                Dim customerController As New CustomerController
                                newCustomer = customerController.GetCertainCustomer(servingCustomer.CustomerAssignCounter.Customer.Customer_ID)
                                If Me.SyncCustomerTransactions(servingCustomer.CustomerAssignCounter.Customer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.Info_ID, newCustomer.CustomerInfo.FK_emdPatients) Then
                                    servingCustomer.CustomerAssignCounter.Customer = newCustomer
                                    Return servingCustomer
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return Nothing
        End Try
    End Function

    Private Function SyncCustomerTransactions(oldInfoID As Long, newInfoID As Long, newFkID As Long) As Boolean
        'This Function is just to copy every patient's Transaction to the sync patient; NOTE. Only transcations for the Day can be copied.
        Try
            Dim cmdSyncQRY As New List(Of SqlCommand)
            Dim cmdConsultation As New SqlCommand
            cmdConsultation.CommandText = "INSERT INTO [dbo].[customervitals]
                                            ([weight] ,[weightunit] ,[height] ,[heightunit] ,[systolic] ,[diastolic] ,[temperature] ,[pulserate] ,[respiratoryrate] ,[oxygen] ,[chiefcomplaint] ,[illnesshistory] ,[diagnosis] ,[doctorsorder] ,[datecreated] ,[datemodified] ,[FK_emdPatients] ,[servertransaction_id] ,[info_id])
                                           SELECT 
                                            [weight] ,[weightunit] ,[height] ,[heightunit] ,[systolic] ,[diastolic] ,[temperature] ,[pulserate] ,[respiratoryrate] ,[oxygen] ,[chiefcomplaint] ,[illnesshistory] ,[diagnosis] ,[doctorsorder] ,[datecreated] ,[datemodified] ,@fkid ,[servertransaction_id] ,@newID
                                           FROM [dbo].[customervitals] 
                                           WHERE [info_id] = @oldID AND (CONVERT(DATE,datecreated) = CONVERT(DATE,GETDATE()) or  CONVERT(DATE,datemodified) = CONVERT(DATE,GETDATE()))"
            cmdConsultation.Parameters.AddWithValue("@oldID", oldInfoID)
            cmdConsultation.Parameters.AddWithValue("@newID", newInfoID)
            cmdConsultation.Parameters.AddWithValue("@fkid", newFkID)
            cmdSyncQRY.Add(cmdConsultation)
            Dim cmdDiagnostics As New SqlCommand
            cmdDiagnostics.CommandText = "INSERT INTO [dbo].[diagnosticrequests]
                                            ([diagnostic] ,[remarks] ,[ItemDescription] ,[requestDate] ,[modifiedDate] ,[doneDate] ,[FK_emdPatients] ,[FK_diagnostic_id] ,[servertransaction_id] ,[info_id])
                                           SELECT 
                                            [diagnostic] ,[remarks] ,[ItemDescription] ,[requestDate] ,[modifiedDate] ,[doneDate] ,[FK_emdPatients] ,@fkid ,[servertransaction_id] ,@newID
                                           FROM [dbo].[diagnosticrequests]
                                           WHERE [info_id] = @oldID AND (CONVERT(DATE,requestDate) = CONVERT(DATE,GETDATE()) or  CONVERT(DATE,modifiedDate) = CONVERT(DATE,GETDATE()))"
            cmdDiagnostics.Parameters.AddWithValue("@oldID", oldInfoID)
            cmdDiagnostics.Parameters.AddWithValue("@newID", newInfoID)
            cmdDiagnostics.Parameters.AddWithValue("@fkid", newFkID)
            cmdSyncQRY.Add(cmdDiagnostics)
            Dim cmdPrescription As New SqlCommand
            cmdPrescription.CommandText = "INSERT INTO [dbo].[customerprescription]
                                            ([productcode] ,[productdescription] ,[genericname] ,[qty] ,[strength] ,[instruction] ,[unitprice] ,[unitcost] ,[onhand] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime] ,[sentdate] ,[requestdate] ,[modifieddate] ,[FK_emdPatients] ,[servertransaction_id] ,[info_id])
                                           SELECT
                                            [productcode] ,[productdescription] ,[genericname] ,[qty] ,[strength] ,[instruction] ,[unitprice] ,[unitcost] ,[onhand] ,[beforebreakfast] ,[beforelunch] ,[beforedinner] ,[afterbreakfast] ,[afterlunch] ,[afterdinner] ,[atbedtime] ,[sentdate] ,[requestdate] ,[modifieddate] ,@fkid ,[servertransaction_id] ,@newID
                                           FROM
                                            [dbo].[customerprescription]
                                           WHERE [info_id] = @oldID AND (CONVERT(DATE,requestDate) = CONVERT(DATE,GETDATE()) or  CONVERT(DATE,modifiedDate) = CONVERT(DATE,GETDATE())) AND sentdate is null"
            cmdPrescription.Parameters.AddWithValue("@oldID", oldInfoID)
            cmdPrescription.Parameters.AddWithValue("@newID", newInfoID)
            cmdPrescription.Parameters.AddWithValue("@fkid", newFkID)
            cmdSyncQRY.Add(cmdPrescription)
            Return excecuteMultipleCommand(cmdSyncQRY)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString)
            End If
            Return False
        End Try
    End Function
End Class
