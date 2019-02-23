Public Class ModelGambar
    Private Property _kd_gambar As String
    Private Property _nama As String
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String

    Public Property kd_gambar() As String
        Set(ByVal value As String)
            _kd_gambar = value
        End Set
        Get
            Return _kd_gambar
        End Get
    End Property

    Public Property nama() As String
        Set(ByVal value As String)
            _nama = value
        End Set
        Get
            Return _nama
        End Get
    End Property

    Public Property created_by() As String
        Set(ByVal value As String)
            _created_by = value
        End Set
        Get
            Return _created_by
        End Get
    End Property

    Public Property created_date() As String
        Set(ByVal value As String)
            _created_date = value
        End Set
        Get
            Return _created_date
        End Get
    End Property

    Public Property modified_by() As String
        Set(ByVal value As String)
            _modified_by = value
        End Set
        Get
            Return _modified_by
        End Get
    End Property

    Public Property modified_date() As String
        Set(ByVal value As String)
            _modified_date = value
        End Set
        Get
            Return _modified_date
        End Get
    End Property
End Class
