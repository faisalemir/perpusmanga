Imports Data
Imports Model

Public Class LogicHakAkses
    Public dataaks As New DataHakAkses

    Public Function selectall() As List(Of ModelHakAkses)
        Return dataaks.selectall
    End Function

    Public Function selectbykode(ByVal kode As Boolean) As ModelHakAkses
        Return dataaks.selectbykode(kode)
    End Function

End Class
