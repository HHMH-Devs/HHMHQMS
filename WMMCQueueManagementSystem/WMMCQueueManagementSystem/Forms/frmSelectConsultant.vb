Public Class frmSelectConsultant
    Private DoctorsClinic As List(Of ServerAssignCounter)
    Private isEKonsulta As Boolean = False
    Private _defaultList As Integer = 0

    Public Property SelectedClinic As ServerAssignCounter = Nothing

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Sub New(defaultList As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _defaultList = defaultList
    End Sub

    Sub New(eKonsultaOnly As Boolean)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.isEKonsulta = eKonsultaOnly
    End Sub

    Private Sub getMABClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllMABClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub getMABHybridClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllMABHybridClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub getPCCClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllPCCClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub getPCCHybirdClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllPCCHybridClinicQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub getERDoctors()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllERPhysicianQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub geteKonsultaClinics()
        Dim counterController As New CounterController
        DoctorsClinic = counterController.GetAllEKonsultaQueuingCounters()
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub frmSelectConsultant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If isEKonsulta Then
            ComboBox1.SelectedIndex = 4
            ComboBox1.Enabled = False
        Else
            ComboBox1.SelectedIndex = _defaultList
        End If
    End Sub

    Private Sub cbAvailabilityOfClinic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAvailabilityOfClinic.SelectedIndexChanged
        dgvDoctorsList.Rows.Clear()
        If Not IsNothing(DoctorsClinic) Then
            If cbAvailabilityOfClinic.SelectedIndex = 2 Then  'OFFLINE
                For Each doctor In DoctorsClinic
                    If Not doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            ElseIf cbAvailabilityOfClinic.SelectedIndex = 1 Then  'ONLINE
                For Each doctor In DoctorsClinic
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    End If
                Next
            Else 'ALL
                For Each doctor In DoctorsClinic
                    dgvDoctorsList.Rows.Add(doctor.Counter.Counter_ID, "", doctor.Server.FullName.ToUpper, doctor.Server.Specialization.ToUpper, doctor.Counter.Department.ToUpper, doctor.Counter.Section.ToUpper)
                    dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Height = 30
                    If doctor.isAvailable Then
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Green
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "ONLINE"
                    Else
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.BackColor = Color.Maroon
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Style.ForeColor = Color.White
                        dgvDoctorsList.Rows(dgvDoctorsList.Rows.Count - 1).Cells("clinicDoctorAvailability").Value = "OFFLINE"
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub txtFindDoctor_TextChanged(sender As Object, e As EventArgs) Handles txtFindDoctor.TextChanged

    End Sub

    Private Sub txtFindDoctor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFindDoctor.KeyDown
        If e.KeyCode = Keys.Enter Then
            For x As Integer = 0 To dgvDoctorsList.Rows.Count - 1
                If dgvDoctorsList.Rows(x).Cells("clinicDoctorName").Value.ToString.ToLower.Contains(txtFindDoctor.Text.ToLower) Or dgvDoctorsList.Rows(x).Cells("clinicRoom").Value.ToString.ToLower.Contains(txtFindDoctor.Text.ToLower) Then
                    dgvDoctorsList.Rows(x).Visible = True
                Else
                    dgvDoctorsList.Rows(x).Visible = False
                End If
            Next
        End If
    End Sub

    Private Sub dgvDoctorsList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctorsList.CellContentClick

    End Sub

    Private Sub dgvDoctorsList_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDoctorsList.KeyDown

    End Sub

    Private Sub dgvDoctorsList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDoctorsList.CellDoubleClick
        Dim index As Integer = dgvDoctorsList.SelectedRows(0).Cells("clinicCounterID").Value
        Dim selectedClinic As ServerAssignCounter = Nothing
        For Each clinicCounter In DoctorsClinic
            If clinicCounter.Counter.Counter_ID = index Then
                selectedClinic = clinicCounter
            End If
        Next
        If Not IsNothing(selectedClinic) Then
            Me.SelectedClinic = selectedClinic
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            getPCCClinics()
        ElseIf ComboBox1.SelectedIndex = 1 Then
            getPCCHybirdClinics()
        ElseIf ComboBox1.SelectedIndex = 2 Then
            getMABClinics()
        ElseIf ComboBox1.SelectedIndex = 3 Then
            getMABHybridClinics()
        ElseIf ComboBox1.SelectedIndex = 4 Then
            geteKonsultaClinics()
        ElseIf ComboBox1.SelectedIndex = 5 Then
            getERDoctors()
        End If
    End Sub

    Private Sub pnlDoctors_Paint(sender As Object, e As PaintEventArgs) Handles pnlDoctors.Paint

    End Sub
End Class