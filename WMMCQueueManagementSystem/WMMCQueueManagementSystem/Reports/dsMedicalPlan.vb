Partial Class dsMedicalPlan
    Partial Public Class dsDiagnosticRequestDataTable
        Private Sub dsDiagnosticRequestDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.diagnosticPreparationColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Public Class dsPrescriptionTableDataTable
        Private Sub dsPrescriptionTableDataTable_dsPrescriptionTableRowChanging(sender As Object, e As dsPrescriptionTableRowChangeEvent) Handles Me.dsPrescriptionTableRowChanging

        End Sub

    End Class

    Partial Public Class dsMedicalPlanDataTable
        Private Sub dsMedicalPlanDataTable_dsMedicalPlanRowChanging(sender As Object, e As dsMedicalPlanRowChangeEvent) Handles Me.dsMedicalPlanRowChanging

        End Sub

        Private Sub dsMedicalPlanDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.diagnosisColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
