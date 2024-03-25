Imports System.Data
Imports System.Data.SqlClient
Public Class administratoraccountcontroller

    Public Function AdminLogin(admininfo As administratoraccount) As Boolean
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[administatoraccount] WHERE adminusername = @uname AND adminpassword = @pass"
            cmd.Parameters.AddWithValue("@uname", admininfo.adminusername)
            cmd.Parameters.AddWithValue("@pass", admininfo.adminpassword)

            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetMghRooms() As List(Of mghroomstatus)
        Try
            Dim cmd As New SqlCommand
            cmd.CommandText = "SELECT * FROM [wmmcqms].[mghroomstatus] WHERE isFinished != 1 ORDER BY  RoomNo ASC"
            Dim data As DataTable = fetchData(cmd).Tables(0)
            If data.Rows.Count > 0 Then
                Dim MghRooms As New List(Of mghroomstatus)
                For Each rows As DataRow In data.Rows
                    Dim MghRoom As New mghroomstatus
                    MghRoom.Mgh_ID = rows("mgh_id")
                    MghRoom.Room_No = rows("RoomNo")
                    MghRoom.Bed_No = rows("bedno")
                    MghRoom.Station = rows("station")
                    MghRoom.Patient = rows("patient")
                    MghRoom.Admitted_Date = rows("admitteddate")
                    MghRoom.Mgh_Date = rows("mghdate")
                    MghRoom.Registry_Status = rows("registrystatus")
                    MghRoom.isOccupied = rows("isoocupied")
                    MghRoom.Status = rows("status")
                    MghRoom.isFinished = rows("isFinished")
                    MghRoom.Admission_ID = rows("admission_id")
                    MghRooms.Add(MghRoom)
                Next
                Return MghRooms
            End If
            Return Nothing
        Catch ex As SqlException
            Return Nothing
        End Try
    End Function


End Class
