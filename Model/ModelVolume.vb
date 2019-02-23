Public Class ModelVolume
    Private Property _kd_volume As String
    Private Property _kd_buku As String
    Private Property _judul As String
    Private Property _volume As Integer
    Private Property _jumlah As Integer
    Private Property _stok As Integer
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String
    Private Property _ket As String
    Private Property _buku As ModelBuku
    Private Property _tmpstok As Integer

    Public Property kd_volume() As String
        Set(ByVal value As String)
            _kd_volume = value
        End Set
        Get
            Return _kd_volume
        End Get
    End Property

    Public Property kd_buku() As String
        Set(ByVal value As String)
            _kd_buku = value
        End Set
        Get
            Return _kd_buku
        End Get
    End Property

    Public Property judul() As String
        Set(ByVal value As String)
            _judul = value
        End Set
        Get
            Return _judul
        End Get
    End Property

    Public Property volume() As Integer
        Set(ByVal value As Integer)
            _volume = value
        End Set
        Get
            Return _volume
        End Get
    End Property

    Public Property jumlah() As Integer
        Set(ByVal value As Integer)
            _jumlah = value
        End Set
        Get
            Return _jumlah
        End Get
    End Property

    Public Property stok() As String
        Set(ByVal value As String)
            _stok = value
        End Set
        Get
            Return _stok
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

    Public Property ket() As String
        Set(ByVal value As String)
            _ket = value
        End Set
        Get
            Return _ket
        End Get
    End Property

    Public Property buku() As ModelBuku
        Set(ByVal value As ModelBuku)
            _buku = value
        End Set
        Get
            Return _buku
        End Get
    End Property

    Public Property tmpstok() As Integer
        Set(value As Integer)
            _tmpstok = value
        End Set
        Get
            Return _tmpstok
        End Get
    End Property
End Class
