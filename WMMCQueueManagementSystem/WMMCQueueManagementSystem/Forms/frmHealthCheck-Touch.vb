Public Class frmHealthCheck_Touch
    Private _patientHealthCheck As HealthCheck = Nothing
    Private Fever As Boolean = False
    Private Cough As Boolean = False
    Private Colds As Boolean = False
    Private Sorethroat As Boolean = False
    Private Diarrhea As Boolean = False
    Private ShortnessOfBreathing As Boolean = False
    Private Aguesia As Boolean = False
    Private Anosmia As Boolean = False
    Private CloseContactConfirmed As Boolean = False
    Private CloseContactExhibiting As Boolean = False

    Public Property PatientHealthCheck As HealthCheck
        Get
            Return _patientHealthCheck
        End Get
        Private Set(value As HealthCheck)
            _patientHealthCheck = value
        End Set
    End Property

    Private Sub frmHealthCheck_Touch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pbFever_Click(sender As Object, e As EventArgs) Handles pbFever.Click
        Me.Fever = Not Me.Fever
        If Me.Fever Then
            pbFever.Image = checkImg.Images(0)
        Else
            pbFever.Image = Nothing
        End If
    End Sub

    Private Sub pbCough_Click(sender As Object, e As EventArgs) Handles pbCough.Click
        Me.Cough = Not Me.Cough
        If Me.Cough Then
            pbCough.Image = checkImg.Images(0)
        Else
            pbCough.Image = Nothing
        End If
    End Sub

    Private Sub pbColds_Click(sender As Object, e As EventArgs) Handles pbColds.Click
        Me.Colds = Not Me.Colds
        If Me.Colds Then
            pbColds.Image = checkImg.Images(0)
        Else
            pbColds.Image = Nothing
        End If
    End Sub

    Private Sub pbSorethroat_Click(sender As Object, e As EventArgs) Handles pbSorethroat.Click
        Me.Sorethroat = Not Me.Sorethroat
        If Me.Sorethroat Then
            pbSorethroat.Image = checkImg.Images(0)
        Else
            pbSorethroat.Image = Nothing
        End If
    End Sub

    Private Sub pbDiarrhea_Click(sender As Object, e As EventArgs) Handles pbDiarrhea.Click
        Me.Diarrhea = Not Me.Diarrhea
        If Me.Diarrhea Then
            pbDiarrhea.Image = checkImg.Images(0)
        Else
            pbDiarrhea.Image = Nothing
        End If
    End Sub

    Private Sub pbShortnessBreathing_Click(sender As Object, e As EventArgs) Handles pbShortnessBreathing.Click
        Me.ShortnessOfBreathing = Not Me.ShortnessOfBreathing
        If Me.ShortnessOfBreathing Then
            pbShortnessBreathing.Image = checkImg.Images(0)
        Else
            pbShortnessBreathing.Image = Nothing
        End If
    End Sub

    Private Sub pbAgeusia_Click(sender As Object, e As EventArgs) Handles pbAgeusia.Click
        Me.Aguesia = Not Me.Aguesia
        If Me.Aguesia Then
            pbAgeusia.Image = checkImg.Images(0)
        Else
            pbAgeusia.Image = Nothing
        End If
    End Sub

    Private Sub pbAnosmia_Click(sender As Object, e As EventArgs) Handles pbAnosmia.Click
        Me.Anosmia = Not Me.Anosmia
        If Me.Anosmia Then
            pbAnosmia.Image = checkImg.Images(0)
        Else
            pbAnosmia.Image = Nothing
        End If
    End Sub

    Private Sub pbCloseContactConfirmed_Click(sender As Object, e As EventArgs) Handles pbCloseContactConfirmed.Click
        Me.CloseContactConfirmed = Not Me.CloseContactConfirmed
        If Me.CloseContactConfirmed Then
            pbCloseContactConfirmed.Image = checkImg.Images(0)
        Else
            pbCloseContactConfirmed.Image = Nothing
        End If
    End Sub

    Private Sub pbCloseContactExhibiting_Click(sender As Object, e As EventArgs) Handles pbCloseContactExhibiting.Click
        Me.CloseContactExhibiting = Not Me.CloseContactExhibiting
        If Me.CloseContactExhibiting Then
            pbCloseContactExhibiting.Image = checkImg.Images(0)
        Else
            pbCloseContactExhibiting.Image = Nothing
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim healthCheck As New HealthCheck
        healthCheck.Fever = Me.Fever
        healthCheck.Cough = Me.Cough
        healthCheck.Colds = Me.Colds
        healthCheck.Sorethroat = Me.Sorethroat
        healthCheck.Diarrhea = Me.Diarrhea
        healthCheck.ShortnessOfBreathing = Me.ShortnessOfBreathing
        healthCheck.Ageusia = Me.Aguesia
        healthCheck.Anosmia = Me.Anosmia
        healthCheck.CloseContactConfirmed = Me.CloseContactConfirmed
        healthCheck.CloseContactExhiting = Me.CloseContactExhibiting
        PatientHealthCheck = healthCheck
        Me.DialogResult = DialogResult.Yes
    End Sub
End Class