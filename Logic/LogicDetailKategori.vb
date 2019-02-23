Imports Model
Imports Data

Public Class LogicDetailKategori
    Public datadkg As New DataDetailKategori

    Public Function insert(ByVal modeldkg As ModelDetailKategori) As Boolean
        Return datadkg.insert(modeldkg)
    End Function

    Public Function update(ByVal modeldkg As ModelDetailKategori) As Boolean
        Return datadkg.update(modeldkg)
    End Function

    Public Function delete(ByVal modeldkg As ModelDetailKategori) As Boolean
        Return datadkg.delete(modeldkg)
    End Function

    Public Function undelete(ByVal modeldkg As ModelDetailKategori) As Boolean
        Return datadkg.undelete(modeldkg)
    End Function

    Public Function selectall() As List(Of ModelDetailKategori)
        Return datadkg.selectall
    End Function

    Public Function selectbykode(ByVal kd_buku As String, ByVal kd_volume As String) As ModelDetailKategori
        Return datadkg.selectbykode(kd_buku, kd_volume)
    End Function

    Public Function selectbyKategori(ByVal kd_kategori As String) As List(Of ModelDetailKategori)
        Return datadkg.selectbykategori(kd_kategori)
    End Function

    Public Function selectbyBuku(ByVal kd_buku As String) As List(Of ModelDetailKategori)
        Return datadkg.selectbyBuku(kd_buku)
    End Function
End Class
