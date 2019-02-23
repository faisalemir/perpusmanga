Imports Model
Imports Logic
Imports System.Data
Imports System.Data.SqlClient

Public Class gambar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

        If fud_gambar.PostedFile IsNot Nothing Then

            Dim imageSize As Byte() = New Byte(fud_gambar.PostedFile.ContentLength - 1) {}

            Dim uploadedImage__1 As HttpPostedFile = fud_gambar.PostedFile

            uploadedImage__1.InputStream.Read(imageSize, 0, CInt(fud_gambar.PostedFile.ContentLength))

            ' Create SQL Connection 
            Dim con As New SqlConnection()
            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString

            ' Create SQL Command 

            Dim cmd As New SqlCommand()
            cmd.CommandText = "INSERT INTO Gambar VALUES (@ImageName,@Image)"
            cmd.CommandType = CommandType.Text
            cmd.Connection = con

            Dim UploadedImage__2 As New SqlParameter("@Image", SqlDbType.Image, imageSize.Length)
            UploadedImage__2.Value = imageSize
            cmd.Parameters.Add(UploadedImage__2)
            con.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub
End Class