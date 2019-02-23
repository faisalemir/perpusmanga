Imports Model
Imports Data

Public Class LogicDenda
    Public datadnd As New DataDenda

    Public Function FindNumber() As String
        Return datadnd.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return datadnd.GenerateNumber
    End Function

    Public Function insert(ByVal dnd As ModelDenda) As Boolean
        Return datadnd.insert(dnd)
    End Function

    Public Function update(ByVal dnd As ModelDenda) As Boolean
        Return datadnd.update(dnd)
    End Function

    Public Function rollback(ByVal dnd As ModelDenda) As Boolean
        Return datadnd.rollback(dnd)
    End Function

    Public Function truedelete(ByVal dnd As ModelDenda) As Boolean
        Return datadnd.truedelete(dnd)
    End Function

    Public Function selectFalse() As ModelDenda
        Return datadnd.selectFalse()
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelDenda
        Return datadnd.selectbykode(kode)
    End Function
End Class
