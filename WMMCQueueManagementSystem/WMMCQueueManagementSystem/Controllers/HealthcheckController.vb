Imports System.Data
Imports System.Data.SqlClient

Public Class HealthcheckController

    Public Function MarkEligibilityOfPatient(hc As HealthCheck) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " UPDATE [dbo].[healthcheckdata] SET  [allowedToEnter] = @isAllowed WHERE healthcheck_id = @ID"
            cmd.Parameters.AddWithValue("@isAllowed", hc.isEligible)
            cmd.Parameters.AddWithValue("@ID", hc.HealthCheck_ID)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function MarkEligibilityOfPatient_WithCounterException(hc As HealthCheck, counterID As Long) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = " UPDATE [dbo].[healthcheckdata] SET  [allowedToEnter] = @isAllowed WHERE healthcheck_id = @ID"
            cmd.Parameters.AddWithValue("@isAllowed", hc.isEligible)
            cmd.Parameters.AddWithValue("@ID", hc.HealthCheck_ID)
            If excecuteCommand(cmd) Then
                If Not hc.isEligible Then
                    Dim cmd2 As New SqlCommand
                    cmd2.CommandText = "SELECT * FROM [wmmcqms].[customer] WHERE info_id = @ID and CONVERT(DATE,dateofvisit) = CONVERT(DATE,GETDATE())"
                    cmd2.Parameters.AddWithValue("@ID", hc.Info_ID)
                    Dim data As DataTable = fetchData(cmd2).Tables(0)
                    If Not IsNothing(data) Then
                        Dim CMDs As New List(Of SqlCommand)
                        For Each row As DataRow In data.Rows
                            Dim cmd3 As New SqlCommand
                            cmd3.CommandText = "DELETE FROM [wmmcqms].[customerassigncounter] WHERE customer_id = @ID AND counter_id != @ctrID"
                            cmd3.Parameters.AddWithValue("@ID", row("customer_id"))
                            cmd3.Parameters.AddWithValue("@ctrID", counterID)
                            CMDs.Add(cmd3)
                        Next
                        excecuteMultipleCommand(CMDs)
                    End If
                End If
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetCertainPatientHealthcheckHistory(infoID As Long) As List(Of HealthCheck)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT *, IIF(CONVERT(DATE,dateofassesment)=CONVERT(DATE,GETDATE()),1,0) as isCurrent FROM  [dbo].[healthcheckdata] WHERE info_id = @ID ORDER BY healthcheck_id DESC;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim healthcheckList As New List(Of HealthCheck)
                For Each row As DataRow In data.Rows
                    Dim healthcheckItem As New HealthCheck
                    healthcheckItem.HealthCheck_ID = row("healthcheck_id")
                    healthcheckItem.Fever = row("feverchills")
                    healthcheckItem.Cough = row("cough")
                    healthcheckItem.Sorethroat = row("sorethroat")
                    healthcheckItem.Diarrhea = row("diarrhea")
                    healthcheckItem.ShortnessOfBreathing = row("shortnessofbreathing")
                    healthcheckItem.Ageusia = row("ageusia")
                    healthcheckItem.Anosmia = row("anosmia")
                    healthcheckItem.Colds = row("colds")
                    healthcheckItem.CloseContactConfirmed = row("closecontactconfirmed")
                    healthcheckItem.CloseContactExhiting = row("closecontactpersonexhibiting")
                    healthcheckItem.PurposeOfVisit = row("VisitPurpose")
                    healthcheckItem.isCurrent = row("isCurrent")
                    If Not IsDBNull(row("allowedToEnter")) Then
                        healthcheckItem.isEligible = If(row("allowedToEnter") > 0, True, False)
                    Else
                        healthcheckItem.isEligible = Nothing
                    End If
                    Dim x = row("allowedToEnter")
                    healthcheckItem.DateOfAssesment = row("dateofassesment")
                    healthcheckItem.Fk_emdPatient = row("FK_emdPatients")
                    healthcheckItem.Info_ID = row("info_id")
                    healthcheckList.Add(healthcheckItem)
                Next
                Return healthcheckList
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EditHealthCheck(infoID As Long) As List(Of HealthCheck)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM  [dbo].[healthcheckdata] WHERE info_id = @ID ORDER BY healthcheck_id DESC;"
            cmd.Parameters.AddWithValue("@ID", infoID)
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim healthcheckList As New List(Of HealthCheck)
                For Each row As DataRow In data.Rows
                    Dim healthcheckItem As New HealthCheck
                    healthcheckItem.HealthCheck_ID = row("healthcheck_id")
                    healthcheckItem.Fever = row("feverchills")
                    healthcheckItem.Cough = row("cough")
                    healthcheckItem.Sorethroat = row("sorethroat")
                    healthcheckItem.Diarrhea = row("diarrhea")
                    healthcheckItem.ShortnessOfBreathing = row("shortnessofbreathing")
                    healthcheckItem.Ageusia = row("ageusia")
                    healthcheckItem.Anosmia = row("anosmia")
                    healthcheckItem.Colds = row("colds")
                    healthcheckItem.CloseContactConfirmed = row("closecontactconfirmed")
                    healthcheckItem.CloseContactExhiting = row("closecontactpersonexhibiting")
                    healthcheckItem.DateOfAssesment = row("dateofassesment")
                    healthcheckItem.Fk_emdPatient = row("FK_emdPatients")
                    healthcheckItem.Info_ID = row("info_id")
                    healthcheckList.Add(healthcheckItem)
                Next
                Return healthcheckList
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
