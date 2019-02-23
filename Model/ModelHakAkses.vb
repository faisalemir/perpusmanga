Public Class ModelHakAkses
    Private Property _kd_akses As Boolean
    Private Property _akses As String

    Public Property kd_akses() As Boolean
        Set(ByVal value As Boolean)
            _kd_akses = value
        End Set
        Get
            Return _kd_akses
        End Get
    End Property

    Public Property akses() As String
        Set(ByVal value As String)
            _akses = value
        End Set
        Get
            Return _akses
        End Get
    End Property
End Class