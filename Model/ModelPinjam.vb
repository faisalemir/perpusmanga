Public Class ModelPinjam
    Private Property _kd_pinjam As String
    Private Property _kd_anggota As String
    Private Property _total As Integer
    Private Property _status_pinjam As Boolean
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String
    Private Property _anggota As ModelAnggota

    Public Property kd_pinjam() As String
        Set(ByVal value As String)
            _kd_pinjam = value
        End Set
        Get
            Return _kd_pinjam
        End Get
    End Property

    Public Property kd_anggota() As String
        Set(ByVal value As String)
            _kd_anggota = value
        End Set
        Get
            Return _kd_anggota
        End Get
    End Property

    Public Property total() As Integer
        Set(ByVal value As Integer)
            _total = value
        End Set
        Get
            Return _total
        End Get
    End Property

    Public Property status_pinjam() As Boolean
        Set(ByVal value As Boolean)
            _status_pinjam = value
        End Set
        Get
            Return _status_pinjam
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

    Public Property anggota() As ModelAnggota
        Set(ByVal value As ModelAnggota)
            _anggota = value
        End Set
        Get
            Return _anggota
        End Get
    End Property
End Class
