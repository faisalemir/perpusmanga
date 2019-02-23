Imports Model
Imports Data

Public Class LogicKategori
    Public dataktg As New DataKategori

    Public Function FindNumber() As String
        Return dataktg.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return dataktg.GenerateNumber
    End Function

    Public Function insert(ByVal modelktg As ModelKategori) As Boolean
        Return dataktg.insert(modelktg)
    End Function

    Public Function update(ByVal modelktg As ModelKategori) As Boolean
        Return dataktg.update(modelktg)
    End Function

    Public Function delete(ByVal modelktg As ModelKategori) As Boolean
        Return dataktg.delete(modelktg)
    End Function

    Public Function selectall() As List(Of ModelKategori)
        Return dataktg.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelKategori
        Return dataktg.selectbykode(kode)
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelKategori)
        Return dataktg.pencarian(kode)
    End Function
End Class
