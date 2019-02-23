Public Class ModelAnggota
    Private Property _kd_anggota As String
    Private Property _nama As String
    Private Property _alamat As String
    Private Property _jk As Boolean
    Private Property _tmpjk As String
    Private Property _ktp As String
    Private Property _telp As String
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String

    Public Property kd_anggota() As String
        Set(ByVal value As String)
            _kd_anggota = value
        End Set
        Get
            Return _kd_anggota
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
