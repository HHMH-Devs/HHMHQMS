Imports System.Data.SqlClient

Public Class AddressController

    Public Function GetPhListBrgy() As List(Of PhListBrgyModel)
        Try
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT a.regDesc, b.provDesc, c.citymunDesc, d.brgyDesc FROM dbo.refregion a 
                                INNER JOIN dbo.refprovince b on a.regCode = b.regCode 
                                INNER JOIN dbo.refcitymun c on c.provCode = b.provCode
                                INNER JOIN dbo.refbrgy d on d.citymunCode = c.citymunCode"
            }
            Dim table As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (table.Rows.Count > 0) Then
                Dim brgyList As New List(Of PhListBrgyModel)
                For Each rw As DataRow In table.Rows
                    brgyList.Add(New PhListBrgyModel With
                    {
                       .Region = rw.Item(0),
                       .Province = rw.Item(1),
                       .CityMun = rw.Item(2),
                       .Brgy = rw.Item(3)
                    })
                Next
                Return brgyList
            End If
            Return Nothing
        Catch exception As SqlException
            Return Nothing
        End Try
    End Function

    Public Function GetProvince() As List(Of String)
        Try
            Dim provList As New List(Of String)
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT provCode, provDesc from dbo.refprovince"
            }
            Dim table As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (table.Rows.Count > 0) Then
                For Each rw As DataRow In table.Rows
                    provList.Add(rw.Item("provDesc"))
                Next
            End If
            Return provList
        Catch exception As SqlException
            Return Nothing
        End Try
    End Function

    Public Function GetCityMun(provCode As String) As List(Of String)
        Try
            Dim ctymunList As New List(Of String)
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT a.citymunCode, a.citymunDesc FROM dbo.refcitymun a inner join dbo.refprovince b on a.provCode = b.provCode WHERE provDesc = @provCode"
            }
            cmd.Parameters.AddWithValue("@provCode", provCode)
            Dim table As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (table.Rows.Count > 0) Then
                For Each rw As DataRow In table.Rows
                    ctymunList.Add(rw.Item("citymunDesc"))
                Next
            End If
            Return ctymunList
        Catch exception As SqlException
            Return Nothing
        End Try
    End Function

    Public Function GetBrgy(citymunCode As String) As List(Of String)
        Try
            Dim brgyList As New List(Of String)
            Dim cmd As New SqlCommand With {
                .CommandText = "SELECT a.brgyDesc FROM dbo.refbrgy a inner join dbo.refcitymun b on a.citymunCode = b.citymunCode WHERE b.citymunDesc = @citymunCode"
            }
            cmd.Parameters.AddWithValue("@citymunCode", citymunCode)
            Dim table As DataTable = WMMCQMSConfig.fetchData(cmd).Tables(0)
            If (table.Rows.Count > 0) Then
                For Each rw As DataRow In table.Rows
                    brgyList.Add(rw.Item("brgyDesc"))
                Next
            End If
            Return brgyList
        Catch exception As SqlException
            Return Nothing
        End Try
    End Function

End Class
