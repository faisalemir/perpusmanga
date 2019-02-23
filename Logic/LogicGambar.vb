Imports Data
Imports Model

Public Class LogicGambar
    Public datagbr As New DataGambar

    Public Function FindNumber() As String
        Return datagbr.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return datagbr.GenerateNumber
    End Function

    Public Function insert(ByVal modelgbr As ModelGambar) As Boolean
        Return datagbr.insert(modelgbr)
    End Function

    Public Function update(ByVal modelgbr As ModelGambar) As Boolean
        Return datagbr.update(modelgbr)
    End Function

    Public Function delete(ByVal modelgbr As ModelGambar) As Boolean
        Return datagbr.delete(modelgbr)
    End Function

    Public Function undelete(ByVal modelgbr As ModelGambar) As Boolean
        Return datagbr.undelete(modelgbr)
    End Function

    Public Function truedelete(ByVal modelgbr As ModelGambar) As Boolean
        Return datagbr.truedelete(modelgbr)
    End Function

    Public Function selectall() As List(Of ModelGambar)
        Return datagbr.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelGambar
        Return datagbr.selectbykode(kode)
    End Function
End Class
