Imports Data
Imports Model

Public Class LogicAnggota
    Public dataagt As New Dataanggota

    Public Function FindNumber() As String
        Return dataagt.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return dataagt.GenerateNumber
    End Function

    Public Function insert(ByVal modelagt As ModelAnggota) As Boolean
        Return dataagt.insert(modelagt)
    End Function

    Public Function update(ByVal modelagt As ModelAnggota) As Boolean
        Return dataagt.update(modelagt)
    End Function

    Public Function delete(ByVal modelagt As ModelAnggota) As Boolean
        Return dataagt.delete(modelagt)
    End Function

    Public Function truedelete(ByVal modelagt As ModelAnggota) As Boolean
        Return dataagt.truedelete(modelagt)
    End Function

    Public Function selectall() As List(Of ModelAnggota)
        Return dataagt.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelAnggota
        Return dataagt.selectbykode(kode)
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelAnggota)
        Return dataagt.pencarian(kode)
    End Function
End Class
