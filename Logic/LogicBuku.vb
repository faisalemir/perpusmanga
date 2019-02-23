Imports Data
Imports Model

Public Class LogicBuku
    Public databku As New DataBuku

    Public Function FindNumber() As String
        Return databku.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return databku.GenerateNumber
    End Function

    Public Function insert(ByVal modelbku As ModelBuku) As Boolean
        Return databku.insert(modelbku)
    End Function

    Public Function update(ByVal modelbku As ModelBuku) As Boolean
        Return databku.update(modelbku)
    End Function

    Public Function delete(ByVal modelbku As ModelBuku) As Boolean
        Return databku.delete(modelbku)
    End Function

    Public Function truedelete(ByVal modelbku As ModelBuku) As Boolean
        Return databku.truedelete(modelbku)
    End Function

    Public Function selectall() As List(Of ModelBuku)
        Return databku.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelBuku
        Return databku.selectbykode(kode)
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelBuku)
        Return databku.pencarian(kode)
    End Function
End Class
