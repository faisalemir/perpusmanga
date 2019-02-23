Public Class ModelDetailKategori
    Private Property _kd_buku As String
    Private Property _kd_kategori As String
    Private Property _created_by As String = Nothing
    Private Property _created_date As String = Nothing
    Private Property _modified_by As String = Nothing
    Private Property _modified_date As String = Nothing
    Private Property _kategori As ModelKategori
    Private Property _buku As ModelBuku

    Public Property kd_buku() As String
        Set(ByVal value As String)
            _kd_buku = value
        End Set
        Get
            Return _kd_buku
        End Get
    End Property

    Public Property kd_kategori() As String
        Set(ByVal value As String)
            _kd_kategori = value
        End Set
        Get
            Return _kd_kategori
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

    Public Property kategori() As ModelKategori
        Set(ByVal value As ModelKategori)
            _kategori = value
        End Set
        Get
            Return _kategori
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
End Class
