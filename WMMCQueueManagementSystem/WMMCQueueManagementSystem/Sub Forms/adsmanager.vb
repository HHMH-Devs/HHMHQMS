Public Class adsmanager
    Private AdList As List(Of ADS)
    Private ViewableAdList As List(Of ViewableAds)
    Private maxViewableAdList As Long = 6
    Private isEditing = False
    Private tempViewableList As List(Of ViewableAds) = Nothing
    Private selectedViewableList As ViewableAds = Nothing

    Private Sub OpenMedia(fileUrl)
        Try
            Process.Start(fileUrl)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("File may be modified or missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub toogleReorderViewableList(flag As Boolean)
        If (flag) Then
            tempViewableList = ViewableAdList
            If Not IsNothing(tempViewableList) Then
                If tempViewableList.Count >= 2 Then
                    pb1Down.Visible = flag
                    pb2Up.Visible = flag
                End If
                If tempViewableList.Count >= 3 Then
                    pb2Down.Visible = flag
                    pb3Up.Visible = flag
                End If
                If tempViewableList.Count >= 4 Then
                    pb3Down.Visible = flag
                    pb4Up.Visible = flag
                End If
                If tempViewableList.Count >= 5 Then
                    pb4Down.Visible = flag
                    pb5Up.Visible = flag
                End If
                If tempViewableList.Count >= 6 Then
                    pb5Down.Visible = flag
                    pb6Up.Visible = flag
                End If
            End If
        Else
            pb1Down.Visible = flag
            pb2Down.Visible = flag
            pb2Up.Visible = flag
            pb3Down.Visible = flag
            pb3Up.Visible = flag
            pb4Down.Visible = flag
            pb4Up.Visible = flag
            pb5Down.Visible = flag
            pb5Up.Visible = flag
            pb6Up.Visible = flag
            tempViewableList = Nothing
        End If
        PictureBox5.Visible = Not flag
        btnReorderList.Visible = Not flag
        PictureBox4.Visible = Not flag
        btnRemove.Visible = Not flag
        PictureBox6.Visible = flag
        btnReorderSave.Visible = flag
        PictureBox7.Visible = flag
        btnReorderCancel.Visible = flag
        isEditing = flag
    End Sub

    Private Sub SelectViewableList(selectedItem As Long)
        If selectedItem = 1 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 1 Then
                    lbAd1.BackColor = Color.ForestGreen
                    pbAd1.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(0)
                Else
                    lbAd1.BackColor = Color.Maroon
                    pbAd1.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd1.BackColor = Color.Maroon
                pbAd1.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        ElseIf selectedItem = 2 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 2 Then
                    lbAd2.BackColor = Color.ForestGreen
                    pbAd2.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(1)
                Else
                    lbAd2.BackColor = Color.Maroon
                    pbAd2.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd2.BackColor = Color.Maroon
                pbAd2.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        ElseIf selectedItem = 3 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 3 Then
                    lbAd3.BackColor = Color.ForestGreen
                    pbAd3.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(2)
                Else
                    lbAd3.BackColor = Color.Maroon
                    pbAd3.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd3.BackColor = Color.Maroon
                pbAd3.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        ElseIf selectedItem = 4 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 4 Then
                    lbAd4.BackColor = Color.ForestGreen
                    pbAd4.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(3)
                Else
                    lbAd4.BackColor = Color.Maroon
                    pbAd4.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd4.BackColor = Color.Maroon
                pbAd4.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        ElseIf selectedItem = 5 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 5 Then
                    lbAd5.BackColor = Color.ForestGreen
                    pbAd5.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(4)
                Else
                    lbAd5.BackColor = Color.Maroon
                    pbAd5.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd5.BackColor = Color.Maroon
                pbAd5.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        ElseIf selectedItem = 6 Then
            If Not IsNothing(ViewableAdList) Then
                If ViewableAdList.Count >= 6 Then
                    lbAd6.BackColor = Color.ForestGreen
                    pbAd6.BackColor = Color.ForestGreen
                    selectedViewableList = ViewableAdList(4)
                Else
                    lbAd6.BackColor = Color.Maroon
                    pbAd6.BackColor = Color.Maroon
                    selectedViewableList = Nothing
                End If
            Else
                lbAd6.BackColor = Color.Maroon
                pbAd6.BackColor = Color.Maroon
                selectedViewableList = Nothing
            End If
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen
        Else
            selectedViewableList = Nothing
            lbAd1.BackColor = Color.LimeGreen
            pbAd1.BackColor = Color.LimeGreen

            lbAd2.BackColor = Color.LimeGreen
            pbAd2.BackColor = Color.LimeGreen

            lbAd3.BackColor = Color.LimeGreen
            pbAd3.BackColor = Color.LimeGreen

            lbAd4.BackColor = Color.LimeGreen
            pbAd4.BackColor = Color.LimeGreen

            lbAd5.BackColor = Color.LimeGreen
            pbAd5.BackColor = Color.LimeGreen

            lbAd6.BackColor = Color.LimeGreen
            pbAd6.BackColor = Color.LimeGreen
        End If
    End Sub


    Private Sub GetAds()
        Dim adscontroller As New adscontroller
        AdList = adscontroller.GetAllADS
        lstAds.Items.Clear()
        If Not IsNothing(AdList) Then
            For Each ad As ADS In AdList
                lstAds.Items.Add(ad.ADSName.ToUpper, ad.ADSType)
            Next
        End If
    End Sub

    Private Sub GetViewableAds()
        Dim adscontroller As New adscontroller
        ViewableAdList = adscontroller.GetViewableADS()
        If Not IsNothing(ViewableAdList) Then
            If ViewableAdList.Count >= 1 Then
                lbAd1.Text = ViewableAdList(0).Ads.ADSName.ToUpper
                pbAd1.BackgroundImage = imgList.Images(ViewableAdList(0).Ads.ADSType)
            Else
                lbAd1.Text = "NONE"
                pbAd1.BackgroundImage = imgList.Images(3)
            End If
            If ViewableAdList.Count >= 2 Then
                lbAd2.Text = ViewableAdList(1).Ads.ADSName.ToUpper
                pbAd2.BackgroundImage = imgList.Images(ViewableAdList(1).Ads.ADSType)
            Else
                lbAd2.Text = "NONE"
                pbAd2.BackgroundImage = imgList.Images(3)
            End If
            If ViewableAdList.Count >= 3 Then
                lbAd3.Text = ViewableAdList(2).Ads.ADSName.ToUpper
                pbAd3.BackgroundImage = imgList.Images(ViewableAdList(2).Ads.ADSType)
            Else
                lbAd3.Text = "NONE"
                pbAd3.BackgroundImage = imgList.Images(3)
            End If
            If ViewableAdList.Count >= 4 Then
                lbAd4.Text = ViewableAdList(3).Ads.ADSName.ToUpper
                pbAd4.BackgroundImage = imgList.Images(ViewableAdList(3).Ads.ADSType)
            Else
                lbAd4.Text = "NONE"
                pbAd4.BackgroundImage = imgList.Images(3)
            End If
            If ViewableAdList.Count >= 5 Then
                lbAd5.Text = ViewableAdList(4).Ads.ADSName.ToUpper
                pbAd5.BackgroundImage = imgList.Images(ViewableAdList(4).Ads.ADSType)
            Else
                lbAd5.Text = "NONE"
                pbAd5.BackgroundImage = imgList.Images(3)
            End If
            If ViewableAdList.Count >= 6 Then
                lbAd6.Text = ViewableAdList(5).Ads.ADSName.ToUpper
                pbAd6.BackgroundImage = imgList.Images(ViewableAdList(5).Ads.ADSType)
            Else
                lbAd6.Text = "NONE"
                pbAd6.BackgroundImage = imgList.Images(3)
            End If
        Else
            lbAd1.Text = "NONE"
            pbAd1.BackgroundImage = imgList.Images(3)
            lbAd2.Text = "NONE"
            pbAd2.BackgroundImage = imgList.Images(3)
            lbAd3.Text = "NONE"
            pbAd3.BackgroundImage = imgList.Images(3)
            lbAd4.Text = "NONE"
            pbAd4.BackgroundImage = imgList.Images(3)
            lbAd5.Text = "NONE"
            pbAd5.BackgroundImage = imgList.Images(3)
            lbAd6.Text = "NONE"
            pbAd6.BackgroundImage = imgList.Images(3)
        End If
        SelectViewableList(0)
    End Sub

    Private Sub DisplayTempOrderViewableAds()
        If Not IsNothing(tempViewableList) Then
            If tempViewableList.Count >= 1 Then
                lbAd1.Text = tempViewableList(0).Ads.ADSName.ToUpper
                pbAd1.BackgroundImage = imgList.Images(tempViewableList(0).Ads.ADSType)
            Else
                lbAd1.Text = "NONE"
                pbAd1.BackgroundImage = imgList.Images(3)
            End If
            If tempViewableList.Count >= 2 Then
                lbAd2.Text = tempViewableList(1).Ads.ADSName.ToUpper
                pbAd2.BackgroundImage = imgList.Images(tempViewableList(1).Ads.ADSType)
            Else
                lbAd2.Text = "NONE"
                pbAd2.BackgroundImage = imgList.Images(3)
            End If
            If tempViewableList.Count >= 3 Then
                lbAd3.Text = tempViewableList(2).Ads.ADSName.ToUpper
                pbAd3.BackgroundImage = imgList.Images(tempViewableList(2).Ads.ADSType)
            Else
                lbAd3.Text = "NONE"
                pbAd3.BackgroundImage = imgList.Images(3)
            End If
            If tempViewableList.Count >= 4 Then
                lbAd4.Text = tempViewableList(3).Ads.ADSName.ToUpper
                pbAd4.BackgroundImage = imgList.Images(tempViewableList(3).Ads.ADSType)
            Else
                lbAd4.Text = "NONE"
                pbAd4.BackgroundImage = imgList.Images(3)
            End If
            If tempViewableList.Count >= 5 Then
                lbAd5.Text = tempViewableList(4).Ads.ADSName.ToUpper
                pbAd5.BackgroundImage = imgList.Images(tempViewableList(4).Ads.ADSType)
            Else
                lbAd5.Text = "NONE"
                pbAd5.BackgroundImage = imgList.Images(3)
            End If
            If tempViewableList.Count >= 6 Then
                lbAd6.Text = tempViewableList(5).Ads.ADSName.ToUpper
                pbAd6.BackgroundImage = imgList.Images(tempViewableList(5).Ads.ADSType)
            Else
                lbAd6.Text = "NONE"
                pbAd6.BackgroundImage = imgList.Images(3)
            End If
        Else
            lbAd1.Text = "NONE"
            pbAd1.BackgroundImage = imgList.Images(3)
            lbAd2.Text = "NONE"
            pbAd2.BackgroundImage = imgList.Images(3)
            lbAd3.Text = "NONE"
            pbAd3.BackgroundImage = imgList.Images(3)
            lbAd4.Text = "NONE"
            pbAd4.BackgroundImage = imgList.Images(3)
            lbAd5.Text = "NONE"
            pbAd5.BackgroundImage = imgList.Images(3)
            lbAd6.Text = "NONE"
            pbAd6.BackgroundImage = imgList.Images(3)
        End If
    End Sub
    Private Sub adsmanager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAds()
        GetViewableAds()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If isEditing Then
            MessageBox.Show("Please finish re-ordering first.", "Re-Ordering List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim frm As New frmManageAds
            frm.ShowDialog(Me)
            If frm.DialogResult = DialogResult.Yes Then
                GetAds()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If isEditing Then
            MessageBox.Show("Please finish re-ordering first.", "Re-Ordering List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf lstAds.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete this video ads?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim forDeleteAds As New List(Of ADS)
                Dim adController As New adscontroller
                For i As Integer = 0 To lstAds.SelectedItems.Count - 1
                    Dim ad As New ADS
                    ad = AdList(lstAds.SelectedIndices(i))
                    forDeleteAds.Add(ad)
                Next
                If adController.DeleteAds(forDeleteAds) Then
                    For Each ad As ADS In forDeleteAds
                        Try
                            IO.File.Delete(ad.ADSLocation)
                        Catch ex As Exception

                        End Try
                    Next
                    GetAds()
                        MessageBox.Show("Ads deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Something went wrong on the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Else
            MessageBox.Show("Please select an item to delete", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAddToBoard_Click(sender As Object, e As EventArgs) Handles btnAddToBoard.Click
        If isEditing Then
            MessageBox.Show("Please finish re-ordering first.", "Re-Ordering List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf lstAds.SelectedItems.Count > 0 Then
            Dim isAllowed As Boolean = False
            If IsNothing(ViewableAdList) Then
                isAllowed = True
            ElseIf ViewableAdList.Count + lstAds.SelectedItems.Count <= maxViewableAdList Then
                isAllowed = True
            End If
            If isAllowed Then
                If MessageBox.Show("Do you want these ads to appear in all the qeueueing boards?", "Add To Boards", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim forViewableAd As New List(Of ViewableAds)
                    Dim adController As New adscontroller
                    For i As Integer = 0 To lstAds.SelectedItems.Count - 1
                        Dim ad As New ViewableAds
                        ad.Ads = AdList(lstAds.SelectedIndices(i))
                        forViewableAd.Add(ad)
                    Next
                    If adController.AddToViewableAds(forViewableAd, maxViewableAdList) Then
                        GetAds()
                        GetViewableAds()
                        MessageBox.Show("Ads was added to the queueing board successfuly", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Failed to add to queueing boards", "Not Added", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Cannot add to board. The limit of viewable ads reached.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please select an item to add to board", "No item selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lbAd1_Click(sender As Object, e As EventArgs) Handles lbAd1.Click
        SelectViewableList(1)
    End Sub

    Private Sub lbAd2_Click(sender As Object, e As EventArgs) Handles lbAd2.Click
        SelectViewableList(2)
    End Sub

    Private Sub lbAd3_Click(sender As Object, e As EventArgs) Handles lbAd3.Click
        SelectViewableList(3)
    End Sub

    Private Sub lbAd4_Click(sender As Object, e As EventArgs) Handles lbAd4.Click
        SelectViewableList(4)
    End Sub

    Private Sub lbAd6_Click(sender As Object, e As EventArgs) Handles lbAd6.Click
        SelectViewableList(6)
    End Sub

    Private Sub lbAd5_Click(sender As Object, e As EventArgs) Handles lbAd5.Click
        SelectViewableList(5)
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If isEditing Then
            MessageBox.Show("Please finish re-ordering first.", "Re-Ordering List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Not IsNothing(selectedViewableList) Then
            If MessageBox.Show("Are you sure to remove this ad from the board?", "Remove Ads", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim forRemoveAds As New List(Of ViewableAds)
                Dim adController As New adscontroller
                forRemoveAds.Add(selectedViewableList)
                If adController.RemoveViewableAds(forRemoveAds) Then
                    GetAds()
                    GetViewableAds()
                    MessageBox.Show("Ads removed from the board successfully", "Ads Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                End If
            End If
        Else
            MessageBox.Show("No Ad was Selected. Please select an ad you want to remove from the board", "No Selected Ads", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReorderList_Click(sender As Object, e As EventArgs) Handles btnReorderList.Click
        If isEditing Then
            MessageBox.Show("Please finish re-ordering first.", "Re-Ordering List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            toogleReorderViewableList(True)
        End If
    End Sub

    Private Sub btnReorderCancel_Click(sender As Object, e As EventArgs) Handles btnReorderCancel.Click
        If MessageBox.Show("Are you sure to cancel re-ordering the list?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            toogleReorderViewableList(False)
            GetViewableAds()
        End If
    End Sub

    Private Sub btnReorderSave_Click(sender As Object, e As EventArgs) Handles btnReorderSave.Click
        If MessageBox.Show("Do you want to save this viewable ads' order list?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim adsController As New adscontroller
            If adsController.UpdateVieableAdsOrder(tempViewableList) Then
                toogleReorderViewableList(False)
                GetViewableAds()
                MessageBox.Show("Viewable ads order was updates successfuly", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Something went wrong on the process. Please try again later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub pb1Down_Click(sender As Object, e As EventArgs) Handles pb1Down.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(0)
            tempViewableList(0) = tempViewableList(1)
            tempViewableList(1) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb2Up_Click(sender As Object, e As EventArgs) Handles pb2Up.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(1)
            tempViewableList(1) = tempViewableList(0)
            tempViewableList(0) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb2Down_Click(sender As Object, e As EventArgs) Handles pb2Down.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(1)
            tempViewableList(1) = tempViewableList(2)
            tempViewableList(2) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb3Up_Click(sender As Object, e As EventArgs) Handles pb3Up.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(2)
            tempViewableList(2) = tempViewableList(1)
            tempViewableList(1) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb3Down_Click(sender As Object, e As EventArgs) Handles pb3Down.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(2)
            tempViewableList(2) = tempViewableList(3)
            tempViewableList(3) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb4Up_Click(sender As Object, e As EventArgs) Handles pb4Up.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(3)
            tempViewableList(3) = tempViewableList(2)
            tempViewableList(2) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb4Down_Click(sender As Object, e As EventArgs) Handles pb4Down.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(3)
            tempViewableList(3) = tempViewableList(4)
            tempViewableList(4) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb5Up_Click(sender As Object, e As EventArgs) Handles pb5Up.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(4)
            tempViewableList(4) = tempViewableList(3)
            tempViewableList(3) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb5Down_Click(sender As Object, e As EventArgs) Handles pb5Down.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(4)
            tempViewableList(4) = tempViewableList(5)
            tempViewableList(5) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pb6Up_Click(sender As Object, e As EventArgs) Handles pb6Up.Click
        Try
            Dim tmp As ViewableAds = tempViewableList(5)
            tempViewableList(5) = tempViewableList(4)
            tempViewableList(4) = tmp
            DisplayTempOrderViewableAds()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lstAds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAds.SelectedIndexChanged

    End Sub

    Private Sub lstAds_DoubleClick(sender As Object, e As EventArgs) Handles lstAds.DoubleClick
        If lstAds.SelectedItems.Count > 0 Then
            OpenMedia(AdList(lstAds.SelectedItems(0).Index).ADSLocation)
        End If
    End Sub

    Private Sub lbAd1_DoubleClick(sender As Object, e As EventArgs) Handles lbAd1.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub

    Private Sub lbAd2_DoubleClick(sender As Object, e As EventArgs) Handles lbAd2.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub

    Private Sub lbAd3_DoubleClick(sender As Object, e As EventArgs) Handles lbAd3.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub

    Private Sub lbAd4_DoubleClick(sender As Object, e As EventArgs) Handles lbAd4.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub

    Private Sub lbAd5_DoubleClick(sender As Object, e As EventArgs) Handles lbAd5.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub

    Private Sub lbAd6_DoubleClick(sender As Object, e As EventArgs) Handles lbAd6.DoubleClick
        If Not IsNothing(selectedViewableList) Then
            OpenMedia(selectedViewableList.Ads.ADSLocation)
        End If
    End Sub
End Class
