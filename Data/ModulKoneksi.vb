Imports System.Data
Imports System.Data.SqlClient

Module ModulKoneksi
    Public konek As SqlConnection = Nothing
    Public dtAdapter As SqlDataAdapter = Nothing
    Public dtReader As SqlDataReader = Nothing
    Public dtRow As DataRow = Nothing
    Public dtSet As DataSet = Nothing
    Public dtTable As DataTable = Nothing
    Public cmd As SqlCommand = Nothing
    Public sql As String = Nothing
    Public sqlerr As String = Nothing
    Public posisi As Integer

    Public Sub koneksidatabase()
        'Dim con As String

        Try
            Dim connectionstring As String = "Data Source=EMIR\EMIR3; Initial Catalog = Manga; Integrated security = true"
            konek = New SqlConnection(connectionstring)
            konek.Open()
            konek.Close()

        Catch ex As Exception

        End Try
    End Sub
End Module
