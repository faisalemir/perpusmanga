Public Class ModelDetailPinjam
    Private Property _kd_pinjam As String
    Private Property _kd_volume As String
    Private Property _kd_denda As String
    Private Property _jumlah As Integer
    Private Property _tgl_kembali As String
    Private Property _tgl_pengembalian As String
    Private Property _sub_total As Integer
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String
    Private Property _volume As ModelVolume
    Private Property _pinjam As ModelPinjam
    Private Property _denda As ModelDenda
    Private Property _tmpstok As Integer

    Public Property kd_pinjam() As String
        Set(ByVal value As String)
            _kd_pinjam = value
        End Set
        Get
            Return _kd_pinjam
        End Get
    End Property

    Public Property kd_volume() As String
        Set(ByVal value As String)
            _kd_volume = value
        End Set
        Get
            Return _kd_volume
        End Get
    End Property

    Public Property kd_denda() As String
        Set(ByVal value As String)
            _kd_denda = value
        End Set
        Get
            Return _kd_denda
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

    Public Property tgl_kembali() As String
        Set(ByVal value As String)
            _tgl_kembali = value
        End Set
        Get
            Return _tgl_kembali
        End Get
    End Property

    Public Property tgl_pengembalian() As String
        Set(ByVal value As String)
            _tgl_pengembalian = value
        End Set
        Get
            Return _tgl_pengembalian
        End Get
    End Property

    Public Property sub_total() As Integer
        Set(ByVal value As Integer)
            _sub_total = value
        End Set
        Get
            Return _sub_total
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

    Public Property volume() As ModelVolume
        Set(ByVal value As ModelVolume)
            _volume = value
        End Set
        Get
            Return _volume
        End Get
    End Property

    Public Property pinjam() As ModelPinjam
        Set(ByVal value As ModelPinjam)
            _pinjam = value
        End Set
        Get
            Return _pinjam
        End Get
    End Property

    Public Property denda() As ModelDenda
        Set(ByVal value As ModelDenda)
            _denda = value
        End Set
        Get
            Return _denda
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
