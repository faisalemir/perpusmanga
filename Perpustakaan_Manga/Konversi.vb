Module Konversi
    Function jk(ByVal bit As Boolean)
        Dim hasil As String = Nothing
        If bit = False Then
            hasil = "Laki-Laki"
        Else
            hasil = "Perempuan"
        End If
        Return hasil
    End Function

    Function stok(ByVal int As Integer)
        Dim hasil As String = Nothing
        If int > 0 Then
            hasil = "Tersedia"
        Else
            hasil = "Tidak Tersedia"
        End If
        Return hasil
    End Function
End Module
