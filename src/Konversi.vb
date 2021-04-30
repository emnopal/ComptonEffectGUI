Public Class Konversi

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Hasil As Decimal
        If ComboBox2.Text = "km" Then
            Hasil = CDec(TextBox3.Text * 1000000000000)
        ElseIf ComboBox2.Text = "m" Then
            Hasil = CDec(TextBox3.Text * 1000000000)
        ElseIf ComboBox2.Text = "mm" Then
            Hasil = CDec(TextBox3.Text * 1000000)
        ElseIf ComboBox2.Text = "µm" Then
            Hasil = CDec(TextBox3.Text * 1000)
        ElseIf ComboBox2.Text = "A" Then
            Hasil = CDec(TextBox3.Text * 0.1)
        ElseIf ComboBox2.Text = "pm" Then
            Hasil = CDec(TextBox3.Text * 0.001)
        End If
        TextBox4.Text = Hasil
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Hasil As Decimal
        If ComboBox3.Text = "km" Then
            Hasil = CDec(TextBox2.Text / 1000000000000.0)
        ElseIf ComboBox3.Text = "m" Then
            Hasil = CDec(TextBox2.Text / 1000000000.0)
        ElseIf ComboBox3.Text = "mm" Then
            Hasil = CDec(TextBox2.Text / 1000000.0)
        ElseIf ComboBox3.Text = "µm" Then
            Hasil = CDec(TextBox2.Text / 1000.0)
        ElseIf ComboBox3.Text = "A" Then
            Hasil = CDec(TextBox2.Text / 0.1)
        ElseIf ComboBox3.Text = "pm" Then
            Hasil = CDec(TextBox2.Text / 0.001)
        End If
        TextBox5.Text = Hasil
        TextBox6.Text = ComboBox3.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Panjang (satuan ke nm)" Then
            ComboBox2.Enabled = True
            TextBox3.Enabled = True
            Button1.Enabled = True
            TextBox4.Enabled = True
            ComboBox3.Enabled = False
            TextBox2.Enabled = False
            Button3.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox1.Enabled = False
            Button2.Enabled = False
            TextBox7.Enabled = False
            TextBox9.Enabled = False
            Button4.Enabled = False
            TextBox8.Enabled = False
        End If
        If ComboBox1.Text = "Panjang (nm ke satuan)" Then
            ComboBox2.Enabled = False
            TextBox3.Enabled = False
            Button1.Enabled = False
            TextBox4.Enabled = False
            ComboBox3.Enabled = True
            TextBox2.Enabled = True
            Button3.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox1.Enabled = False
            Button2.Enabled = False
            TextBox7.Enabled = False
            TextBox9.Enabled = False
            Button4.Enabled = False
            TextBox8.Enabled = False
        End If
        If ComboBox1.Text = "Sudut (radian ke derajat)" Then
            ComboBox2.Enabled = False
            TextBox3.Enabled = False
            Button1.Enabled = False
            TextBox4.Enabled = False
            ComboBox3.Enabled = False
            TextBox2.Enabled = False
            Button3.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox1.Enabled = True
            Button2.Enabled = True
            TextBox7.Enabled = True
            TextBox9.Enabled = False
            Button4.Enabled = False
            TextBox8.Enabled = False
        End If
        If ComboBox1.Text = "Sudut (derajat ke radian)" Then
            ComboBox2.Enabled = False
            TextBox3.Enabled = False
            Button1.Enabled = False
            TextBox4.Enabled = False
            ComboBox3.Enabled = False
            TextBox2.Enabled = False
            Button3.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox1.Enabled = False
            Button2.Enabled = False
            TextBox7.Enabled = False
            TextBox9.Enabled = True
            Button4.Enabled = True
            TextBox8.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pi As Decimal = 3.14159265358979
        Dim Hasil As Decimal
        Hasil = CDec(TextBox1.Text * 180 / pi)
        TextBox7.Text = Hasil
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim pi As Decimal = 3.14159265358979
        Dim Hasil As Decimal
        Hasil = CDec(TextBox9.Text * pi / 180)
        TextBox8.Text = Hasil
    End Sub
End Class