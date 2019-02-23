Imports Data
Imports Model

Public Class LogicPinjam
    Public datapjm As New DataPinjam

    Public Function FindNumber() As String
        Return datapjm.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return datapjm.GenerateNumber
    End Function

    Public Function insert(ByVal modelpjm As ModelPinjam) As Boolean
        Return datapjm.insert(modelpjm)
    End Function

    Public Function update(ByVal modelpjm As ModelPinjam) As Boolean
        Return datapjm.update(modelpjm)
    End Function

    Public Function rollback(ByVal modelpjm As ModelPinjam) As Boolean
        Return datapjm.rollback(modelpjm)
    End Function

    Public Function delete(ByVal modelpjm As ModelPinjam) As Boolean
        Return datapjm.delete(modelpjm)
    End Function

    Public Function truedelete(ByVal modelpjm As ModelPinjam) As Boolean
        Return datapjm.truedelete(modelpjm)
    End Function

    Public Function selectStatFalse() As List(Of ModelPinjam)
        Return datapjm.selectStatFalse
    End Function

    Public Function selectStatTrue() As List(Of ModelPinjam)
        Return datapjm.selectStatTrue
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelPinjam
        Return datapjm.selectbykode(kode)
    End Function

    Public Function pencarianFalse(ByVal kode As String) As List(Of ModelPinjam)
        Return datapjm.pencarianFalse(kode)
    End Function

    Public Function pencarianTrue(ByVal kode As String) As List(Of ModelPinjam)
        Return datapjm.pencarianTrue(kode)
    End Function

    Public Function selectbyAnggota(ByVal kode As String) As List(Of ModelPinjam)
        Return datapjm.selectbyAnggota(kode)
    End Function
End Class
