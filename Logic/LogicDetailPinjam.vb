Imports Data
Imports Model

Public Class LogicDetailPinjam
    Public datapjm As New DataDetailPinjam

    Public Function insert(ByVal modeldpm As ModelDetailPinjam) As Boolean
        Return datapjm.insert(modeldpm)
    End Function

    Public Function update(ByVal modeldpm As ModelDetailPinjam) As Boolean
        Return datapjm.update(modeldpm)
    End Function

    Public Function rollback(ByVal modeldpm As ModelDetailPinjam) As Boolean
        Return datapjm.rollback(modeldpm)
    End Function

    Public Function delete(ByVal modeldpm As ModelDetailPinjam) As Boolean
        Return datapjm.delete(modeldpm)
    End Function

    Public Function selectall() As List(Of ModelDetailPinjam)
        Return datapjm.selectall
    End Function

    Public Function selectbykode(ByVal kd_pinjam As String, ByVal kd_volume As String) As ModelDetailPinjam
        Return datapjm.selectbykode(kd_pinjam, kd_volume)
    End Function

    Public Function selectbyVolume(ByVal kode As String) As List(Of ModelDetailPinjam)
        Return datapjm.selectbyVolume(kode)
    End Function

    Public Function selectbyPinjam(ByVal kode As String) As List(Of ModelDetailPinjam)
        Return datapjm.selectbyPinjam(kode)
    End Function

    Public Function selectbyPinjamNull(ByVal kode As String) As List(Of ModelDetailPinjam)
        Return datapjm.selectbyPinjamNull(kode)
    End Function

    Public Function selectbyPinjamNotNull(ByVal kode As String) As List(Of ModelDetailPinjam)
        Return datapjm.selectbyPinjamNotNull(kode)
    End Function

    Public Function selectbyDenda(ByVal kode As String) As List(Of ModelDetailPinjam)
        Return datapjm.selectbyDenda(kode)
    End Function
End Class
