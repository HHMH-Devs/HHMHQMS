Imports System.Data
Imports System.Data.SqlClient
Public Class adscontroller

    Public Function NewAds(ad As ADS) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "INSERT INTO [dbo].[queueingads] ([ads_name] ,[ads_locaton] ,[ads_type]) VALUES (@name, @loc, @type)"
            cmd.Parameters.AddWithValue("@name", ad.ADSName)
            cmd.Parameters.AddWithValue("@loc", ad.ADSLocation)
            cmd.Parameters.AddWithValue("@type", ad.ADSType)
            Return excecuteCommand(cmd)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function DeleteAds(ads As List(Of ADS)) As Boolean
        Try
            Dim CMDS As New List(Of SqlCommand)
            For Each ad As ADS In ads
                Dim cmd As New SqlCommand
                cmd.CommandText = "DELETE FROM [dbo].[queueingads] WHERE [ads_id] = @ID"
                cmd.Parameters.AddWithValue("@ID", ad.ADSID)
                CMDS.Add(cmd)
            Next
            Return excecuteMultipleCommand(CMDS)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function AddToViewableAds(viewableAds As List(Of ViewableAds), max As Integer) As Boolean
        Try
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "SELECT COUNT([vieableads_id]) as adCount FROM [dbo].[viewableads]"
            Dim adCount As Integer = fetchData(cmd1).Tables(0).Rows(0)("adCount")
            If adCount + viewableAds.Count > max Then
                MessageBox.Show("Cannot add to board. The limit of viewable ads reached.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Dim cmds As New List(Of SqlCommand)
                For Each ad As ViewableAds In viewableAds
                    Dim cmd As New SqlCommand
                    cmd.CommandText = "INSERT INTO [dbo].[viewableads] ([ads_id]) VALUES (@ID)"
                    cmd.Parameters.AddWithValue("@ID", ad.Ads.ADSID)
                    cmds.Add(cmd)
                Next
                Return excecuteMultipleCommand(cmds)
            End If
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function RemoveViewableAds(ads As List(Of ViewableAds)) As Boolean
        Try
            Dim CMDS As New List(Of SqlCommand)
            For Each ad As ViewableAds In ads
                Dim cmd As New SqlCommand
                cmd.CommandText = "DELETE FROM [dbo].[viewableads]  WHERE [vieableads_id] = @ID"
                cmd.Parameters.AddWithValue("@ID", ad.ViewableAds_ID)
                CMDS.Add(cmd)
            Next
            Return excecuteMultipleCommand(CMDS)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function UpdateVieableAdsOrder(ads As List(Of ViewableAds)) As Boolean
        Try
            Dim CMDs As New List(Of SqlCommand)
            Dim cmd1 As New SqlCommand
            cmd1.CommandText = "TRUNCATE TABLE [dbo].[viewableads]"
            CMDs.Add(cmd1)
            For Each ad As ViewableAds In ads
                Dim cmd As New SqlCommand
                cmd.CommandText = "INSERT INTO [dbo].[viewableads] ([ads_id]) VALUES (@ID)"
                cmd.Parameters.AddWithValue("@ID", ad.Ads.ADSID)
                CMDs.Add(cmd)
            Next
            Return excecuteMultipleCommand(CMDs)
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return False
        End Try
    End Function

    Public Function GetViewableADS() As List(Of ViewableAds)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[viewableads] as a join [dbo].[queueingads] as b ON a.ads_id = b.ads_id ORDER BY [vieableads_id] ASC "
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim viewableAds As New List(Of ViewableAds)
                For Each rows As DataRow In data.Rows
                    Dim ad As New ViewableAds
                    ad.ViewableAds_ID = rows("vieableads_id")
                    ad.Ads_ID = rows("ads_id")
                    ad.Ads = New ADS()
                    ad.Ads.ADSID = rows("ads_id")
                    ad.Ads.ADSName = rows("ads_name")
                    ad.Ads.ADSLocation = rows("ads_locaton")
                    ad.Ads.ADSType = rows("ads_type")
                    ad.Ads.DateUpload = rows("date_uploaded")
                    viewableAds.Add(ad)
                Next
                Return viewableAds
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetAllADS() As List(Of ADS)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [dbo].[queueingads] WHERE ads_id NOT IN (SELECT ads_id FROM [dbo].[viewableads]) ORDER BY [ads_id] DESC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim ads As New List(Of ADS)
                For Each rows As DataRow In data.Rows
                    Dim ad As New ADS
                    ad.ADSID = rows("ads_id")
                    ad.ADSName = rows("ads_name")
                    ad.ADSLocation = rows("ads_locaton")
                    ad.ADSType = rows("ads_type")
                    ad.DateUpload = rows("date_uploaded")
                    ads.Add(ad)
                Next
                Return ads
            End If
            Return Nothing
        Catch ex As Exception
            If My.Settings.showAdvanceError Then
                MessageBox.Show(ex.ToString, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return Nothing
        End Try
    End Function


End Class
