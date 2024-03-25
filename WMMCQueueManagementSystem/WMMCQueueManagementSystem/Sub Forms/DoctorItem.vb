Public Class DoctorItem
    Private DoctorsClinic As ServerAssignCounter = Nothing

    Sub New(doctorClinic As ServerAssignCounter)
        Me.DoctorsClinic = doctorClinic
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub DoctorItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(DoctorsClinic) Then
            lblDoctorName.Text = (Me.DoctorsClinic.Server.LastName & ", " & Me.DoctorsClinic.Server.FirstName).ToUpper
            lblDoctorBio.Text = (Me.DoctorsClinic.Server.Specialization &
                                 Environment.NewLine &
                                 "ROOM: " & Me.DoctorsClinic.Counter.Department &
                                 Environment.NewLine &
                                 Me.DoctorsClinic.Counter.Section).ToUpper
        End If
    End Sub

    Private Sub SendMyClinicInfo()
        If Application.OpenForms().OfType(Of frmHomeMainCounterForTouch).Any Then
            If Me.ParentForm.Name = frmHomeMainCounterForTouch.Name Then
                Dim frm As frmHomeMainCounterForTouch = Me.ParentForm
                frm.GenerateClinicNumber(Me.DoctorsClinic)
            End If
        End If
    End Sub

    Private Sub DoctorItem_Click(sender As Object, e As EventArgs) Handles Me.Click
        SendMyClinicInfo()
    End Sub

    Private Sub pbDoctorImage_Click(sender As Object, e As EventArgs) Handles pbDoctorImage.Click
        SendMyClinicInfo()
    End Sub

    Private Sub lblDoctorName_Click(sender As Object, e As EventArgs) Handles lblDoctorName.Click
        SendMyClinicInfo()
    End Sub

    Private Sub lblDoctorBio_Click(sender As Object, e As EventArgs) Handles lblDoctorBio.Click
        SendMyClinicInfo()
    End Sub

    Private Sub lblIsActive_Click(sender As Object, e As EventArgs) Handles lblIsActive.Click
        SendMyClinicInfo()
    End Sub
End Class
