Imports Data
Imports Model

Public Class LogicAdmin
    Public dataadm As New DataAdmin

    Public Function FindNumber() As String
        Return dataadm.FindNumber
    End Function

    Public Function GenerateNumber() As String
        Return dataadm.GenerateNumber
    End Function

    Public Function insert(ByVal modeladm As ModelAdmin) As Boolean
        Return dataadm.insert(modeladm)
    End Function

    Public Function update(ByVal modeladm As ModelAdmin) As Boolean
        Return dataadm.update(modeladm)
    End Function

    Public Function delete(ByVal modeladm As ModelAdmin) As Boolean
        Return dataadm.delete(modeladm)
    End Function

    Public Function selectall() As List(Of ModelAdmin)
        Return dataadm.selectall
    End Function

    Public Function selectbykode(ByVal kode As String) As ModelAdmin
        Return dataadm.selectbykode(kode)
    End Function

    Public Function pencarian(ByVal kode As String) As List(Of ModelAdmin)
        Return dataadm.pencarian(kode)
    End Function

    Public Function login(ByVal user As String, ByVal pass As String) As ModelAdmin
        Return dataadm.login(user, pass)
    End Function
End Class
