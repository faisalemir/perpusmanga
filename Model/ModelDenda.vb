Public Class ModelDenda
    Private Property _kd_denda As String
    Private Property _denda As Integer
    Private Property _created_by As String
    Private Property _created_date As String
    Private Property _modified_by As String
    Private Property _modified_date As String

    Public Property kd_denda() As String
        Set(ByVal value As String)
            _kd_denda = value
        End Set
        Get
            Return _kd_denda
        End Get
    End Property

    Public Property denda() As Integer
        Set(ByVal value As Integer)
            _denda = value
        End Set
        Get
            Return _denda
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
