Public Class frmBrowseLogo
    Private _index As Integer

    Public Property SelectedIcons As Integer
        Get
            Return _index
        End Get
        Private Set(value As Integer)
            _index = value
        End Set
    End Property

    Sub New(imgicons As ImageList)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lstListIcons.LargeImageList = imgicons
        For i As Integer = 0 To imgicons.Images.Count - 1
            lstListIcons.Items.Add("", i)
        Next
    End Sub

    Private Sub SelectIcon()
        If lstListIcons.SelectedItems.Count > 0 Then
            SelectedIcons = lstListIcons.SelectedIndices(0)
            Me.DialogResult = DialogResult.Yes
        End If
    End Sub

    Private Sub frmBrowseLogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        SelectIcon()
    End Sub

    Private Sub lstListIcons_KeyDown(sender As Object, e As KeyEventArgs) Handles lstListIcons.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectIcon()
        End If
    End Sub

    Private Sub lstListIcons_DockChanged(sender As Object, e As EventArgs) Handles lstListIcons.DockChanged

    End Sub

    Private Sub lstListIcons_DoubleClick(sender As Object, e As EventArgs) Handles lstListIcons.DoubleClick
        SelectIcon()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class