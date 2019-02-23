Imports Data
Imports Model

Public Class LogicVolume
    Public datadbu As New DataVolume

    Public Function FindNumber() As String
        Return datadbu.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return datadbu.GenerateNumber
    End Function

    Public Function insert(ByVal modeldbu As ModelVolume) As Boolean
        Return datadbu.insert(modeldbu)
    End Function

    Public Function update(ByVal modeldbu As ModelVolume) As Boolean
        Return datadbu.update(modeldbu)
    End Function

    Public Function updatestok(ByVal modeldbu As ModelVolume) As Boolean
        Return datadbu.updatestok(modeldbu)
    End Function

    Public Function rollbackstok(ByVal modeldbu As ModelVolume) As Boolean
        Return datadbu.rollbackstok(modeldbu)
    End Function

    Public Function delete(ByVal modeldbu As ModelVolume) As Boolean
        Return datadbu.delete(modeldbu)
    End Function

    Public Function selectall() As List(Of ModelVolume)
        Return datadbu.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelVolume
        Return datadbu.selectbykode(kode)
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelVolume)
        Return datadbu.pencarian(kode)
    End Function

    Public Function selectbyVolume(ByVal kode As String) As List(Of ModelVolume)
        Return datadbu.selectbyVolume(kode)
    End Function
End Class
