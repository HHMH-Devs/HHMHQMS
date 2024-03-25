Imports MySqlConnector

Public Class PatientHealthCheckController

    Public Function GetPatientHealthCheckData(refNo As String) As PatientHealthCheckData
        Try
            Dim cmd As New MySqlCommand
            cmd.CommandText = "SET time_zone='+08:00'; SELECT *, DATE_FORMAT(dateofassesment, '%b %e %Y') as `assessdate`,DATE_FORMAT(`birthday`, '%b %e %Y') as `birthdate`, IF(DATE(dateofvisit) = CURRENT_DATE , TRUE, FALSE) as 'isValid' FROM `visitation` JOIN `patient` ON `visitation`.`fk_patient` = `patient`.`pk_patient` JOIN `assesment` ON  `visitation`.`fk_assessment` = `assesment`.`pk_assessment` WHERE generetedcode = @ref;"
            cmd.Parameters.AddWithValue("@ref", refNo)
            Dim data As DataTable = fetchData(cmd, openDatabaseWeb).Tables(0)
            If Not IsNothing(data) Then
                Dim patientData As New PatientHealthCheckData
                patientData.VisitationID = data.Rows(0)("pk_visitation")
                patientData.PatientID = data.Rows(0)("fk_patient")
                patientData.AssessmentID = data.Rows(0)("fk_assessment")
                patientData.Purpose = data.Rows(0)("purpose")
                patientData.Details = data.Rows(0)("detail")
                patientData.NotSelf = data.Rows(0)("notself")
                patientData.HasSeen = data.Rows(0)("hasAsses")
                patientData.HasScreen = data.Rows(0)("hasScreen")
                patientData.DateOfVisit = data.Rows(0)("dateofvisit")
                patientData.ReferenceNo = data.Rows(0)("generetedcode")
                patientData.FirstName = data.Rows(0)("firstname")
                patientData.MiddleName = data.Rows(0)("middlename")
                patientData.LastName = data.Rows(0)("lastname")
                patientData.Suffix = data.Rows(0)("suffix")
                patientData.BirthDate = data.Rows(0)("birthday")
                patientData.Sex = data.Rows(0)("sex")
                patientData.CivilStatus = data.Rows(0)("civilstatus")
                patientData.Region = data.Rows(0)("region")
                patientData.Province = data.Rows(0)("province")
                patientData.City = data.Rows(0)("citymunicipality")
                patientData.Barangay = data.Rows(0)("barangay")
                patientData.MobileNumber = data.Rows(0)("mobileno")
                patientData.Email = data.Rows(0)("email")
                patientData.Occupation = data.Rows(0)("occupation")
                patientData.Company = data.Rows(0)("company")
                patientData.ProfileDate = data.Rows(0)("profiledate")
                patientData.FeverChills = data.Rows(0)("feverchills")
                patientData.Cough = data.Rows(0)("cough")
                patientData.SoreThroat = data.Rows(0)("sorethroat")
                patientData.Diarrhea = data.Rows(0)("diarrhea")
                patientData.ShortnessOfBreathing = data.Rows(0)("shortnessofbreathing")
                patientData.Ageusia = data.Rows(0)("ageusia")
                patientData.Anosmia = data.Rows(0)("anosmia")
                patientData.Colds = data.Rows(0)("colds")
                patientData.CloseContactConfirmed = data.Rows(0)("closecontactconfirmed")
                patientData.CloseContactPersonExhibiting = data.Rows(0)("closecontactpersonexhibiting")
                patientData.DateOfAssesment = data.Rows(0)("dateofassesment")
                patientData.isValid = data.Rows(0)("isValid")
                Return patientData
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
