Partial Class dsReport
    Partial Public Class dtReportDataTable
        Private Sub dtReportDataTable_dtReportRowChanging(sender As Object, e As dtReportRowChangeEvent) Handles Me.dtReportRowChanging

        End Sub

        Private Sub dtReportDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.totalCountersColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class dtDoctorCensusDataTable
        Private Sub dtDoctorCensusDataTable_dtDoctorCensusRowChanging(sender As Object, e As dtDoctorCensusRowChangeEvent) Handles Me.dtDoctorCensusRowChanging

        End Sub

    End Class
End Class
