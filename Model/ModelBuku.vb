Public Class ModelBuku
    Private Property _kd_buku As String
    Private Property _kd_gambar As String
    Private Property _nama As String
    Private Property _tahun As Integer
    Private Property _pengarang As String
    Private Property _penulis As String
    Private Property _kategori As String
    Private Property _sinopsis As String
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String
    Private Property _gambar As ModelGambar

    Public Property kd_buku() As String
        Set(ByVal value As String)
            _kd_buku = value
        End Set
        Get
            Return _kd_buku
        End Get
    End Property

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

    Public Property tahun() As Integer
        Set(ByVal value As Integer)
            _tahun = value
        End Set
        Get
            Return _tahun
        End Get
    End Property

    Public Property pengarang() As String
        Set(ByVal value As String)
            _pengarang = value
        End Set
        Get
            Return _pengarang
        End Get
    End Property

    Public Property penulis() As String
        Set(ByVal value As String)
            _penulis = value
        End Set
        Get
            Return _penulis
        End Get
    End Property

    Public Property kategori() As String
        Set(ByVal value As String)
            _kategori = value
        End Set
        Get
            Return _kategori
        End Get
    End Property

    Public Property sinopsis() As String
        Set(ByVal value As String)
            _sinopsis = value
        End Set
        Get
            Return _sinopsis
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

    Public Property gambar() As ModelGambar
        Set(ByVal value As ModelGambar)
            _gambar = value
        End Set
        Get
            Return _gambar
        End Get
    End Property
End Class
