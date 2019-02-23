Public Class ModelAdmin
    Private Property _kd_admin As String
    Private Property _kd_akses As Boolean
    Private Property _nama As String
    Private Property _alamat As String
    Private Property _jk As Boolean
    Private Property _tmpjk As String
    Private Property _ktp As String
    Private Property _telp As String
    Private Property _username As String = Nothing
    Private Property _password As String = Nothing
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String
    Private Property _hakakses As ModelHakAkses

    Public Property kd_admin() As String
        Set(ByVal value As String)
            _kd_admin = value
        End Set
        Get
            Return _kd_admin
        End Get
    End Property

    Public Property kd_akses() As Boolean
        Set(ByVal value As Boolean)
            _kd_akses = value
        End Set
        Get
            Return _kd_akses
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

    Public Property alamat() As String
        Set(ByVal value As String)
            _alamat = value
        End Set
        Get
            Return _alamat
        End Get
    End Property

    Public Property jk() As Boolean
        Set(ByVal value As Boolean)
            _jk = value
        End Set
        Get
            Return _jk
        End Get
    End Property

    Public Property tmpjk() As String
        Set(value As String)
            _tmpjk = value
        End Set
        Get
            Return _tmpjk
        End Get
    End Property

    Public Property ktp() As String
        Set(ByVal value As String)
            _ktp = value
        End Set
        Get
            Return _ktp
        End Get
    End Property

    Public Property telp() As String
        Set(ByVal value As String)
            _telp = value
        End Set
        Get
            Return _telp
        End Get
    End Property

    Public Property username() As String
        Set(ByVal value As String)
            _username = value
        End Set
        Get
            Return _username
        End Get
    End Property

    Public Property password() As String
        Set(ByVal value As String)
            _password = value
        End Set
        Get
            Return _password
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

    Public Property hakakses() As ModelHakAkses
        Set(ByVal value As ModelHakAkses)
            _hakakses = value
        End Set
        Get
            Return _hakakses
        End Get
    End Property
End Class
