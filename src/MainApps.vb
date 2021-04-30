Imports System.IO
Public Class MainApps
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        About.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Chart1.Series(0).Points.Clear()
        Dim compton_wavelengthnM As Decimal = 0.00242
        Dim pi As Decimal = 3.14159265358979
        Dim Result As Decimal
        Dim i As Integer
        Dim j As Integer
        Dim Wavelength As String
        Dim Angle As String
        Dim Angle_Rad As Decimal
        If ComboBox2.Text = "Linear" Then
            Wavelength = TextBox1.Text
            Angle = TextBox2.Text
            Angle_Rad = CDec((TextBox2.Text) * 180 / pi)
            Result = CDec(compton_wavelengthnM * (1 - Math.Cos(Angle_Rad)) + Wavelength)
            TextBox3.Text = Math.Round(Result, 20)
        End If
        If ComboBox2.Text = "Gelombang" Then
            Angle = TextBox2.Text
            Angle_Rad = CDec(Angle * 180 / pi)
            For i = 1 To CInt((TextBox12.Text - TextBox1.Text) / TextBox4.Text)
                Dim l As ListViewItem
                Wavelength = CDec((TextBox1.Text - 1) + i * TextBox4.Text)
                Result = CDec(compton_wavelengthnM * (1 - Math.Cos(Angle_Rad)) + Wavelength)
                l = ListView2.Items.Add("")
                For j = 1 To 4
                    l.SubItems.Add("")
                Next
                ListView2.Items(i - 1).SubItems(3).Text = Result
                ListView2.Items(i - 1).SubItems(2).Text = Angle
                ListView2.Items(i - 1).SubItems(1).Text = Wavelength
                ListView2.Items(i - 1).SubItems(0).Text = i
                With Chart1.ChartAreas(0)
                    .AxisX.Title = "Panjang Gelombang Akhir (nm)"
                    .AxisY.Title = "Panjang Gelombang Awal (nm)"
                End With
                Chart1.Series(0).Points.AddXY(Result, Wavelength)
            Next
        End If
        If ComboBox2.Text = "Sudut" Then
            Wavelength = TextBox1.Text
            For i = 1 To CInt(((TextBox11.Text - TextBox2.Text) / TextBox4.Text) + 1)
                Dim l As ListViewItem
                Angle = CDec((TextBox2.Text - 1) + i * TextBox4.Text)
                Angle_Rad = CDec(Angle * 180 / pi)
                Result = CDec(compton_wavelengthnM * (1 - Math.Cos(Angle_Rad)) + Wavelength)
                l = ListView2.Items.Add("")
                For j = 1 To 4
                    l.SubItems.Add("")
                Next
                ListView2.Items(i - 1).SubItems(3).Text = Result
                ListView2.Items(i - 1).SubItems(2).Text = Angle
                ListView2.Items(i - 1).SubItems(1).Text = Wavelength
                ListView2.Items(i - 1).SubItems(0).Text = i
                With Chart1.ChartAreas(0)
                    .AxisX.Title = "Sudut (derajat)"
                    .AxisY.Title = "Panjang Gelombang Akhir (nm)"
                    .AxisY.Minimum = Wavelength - (0.00242 * 0.5)
                    .AxisY.Maximum = Wavelength + (0.00242 * 2.2)
                End With
                Chart1.Series(0).Points.AddXY(Angle, Result)
            Next
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Linear" Then
            TextBox4.Enabled = False
            TextBox12.Enabled = False
            TextBox11.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        End If
        If ComboBox2.Text = "Gelombang" Then
            TextBox4.Enabled = True
            TextBox12.Enabled = True
            TextBox11.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = False
        End If
        If ComboBox2.Text = "Sudut" Then
            TextBox4.Enabled = True
            TextBox12.Enabled = False
            TextBox11.Enabled = True
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = False
        End If
    End Sub
    Private Sub KonversiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KonversiToolStripMenuItem.Click
        Konversi.Show()
    End Sub
    Private Sub KonstantaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KonstantaToolStripMenuItem.Click
        Konstanta.Show()
    End Sub
    Private Sub DokumentasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokumentasiToolStripMenuItem.Click
        Dim FILE_NAME As String = "data\doc.pdf"
        If System.IO.File.Exists(FILE_NAME) = True Then
            Process.Start(FILE_NAME)
        End If
    End Sub
    Private Sub WebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebsiteToolStripMenuItem.Click
        Dim url As String = "https://github.com/emnopal/ComptonEffectGUI"
        Process.Start(url)
    End Sub
    Private Function ExportListViewToCSV(ByVal filename As String, ByVal lv As ListView) As Boolean
        Try
            Dim os As New StreamWriter(filename)
            For i As Integer = 0 To lv.Columns.Count - 1
                os.Write("""" & lv.Columns(i).Text.Replace("""", """""") & """,")
            Next
            os.WriteLine()
            For i As Integer = 0 To lv.Items.Count - 1
                For j As Integer = 0 To lv.Columns.Count - 1
                    os.Write("""" & lv.Items(i).SubItems(j).Text.Replace("""", """""") + """,")
                Next
                os.WriteLine()
            Next
            os.Close()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
    Private Sub TestExportToCSV()
        Dim dlg As New SaveFileDialog
        dlg.Filter = "CSV files (*.CSV)|*.csv"
        dlg.FilterIndex = 1
        dlg.RestoreDirectory = True
        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ExportListViewToCSV(dlg.FileName, ListView2) Then
                Process.Start(dlg.FileName)
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TestExportToCSV()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Chart1.SaveImage(My.Application.Info.DirectoryPath & "\Chart1.png", System.Drawing.Imaging.ImageFormat.Png)
        MessageBox.Show("Sukses!")
    End Sub

End Class