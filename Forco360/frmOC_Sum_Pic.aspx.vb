Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI

Partial Public Class frmOC_Sum_Pic
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        'Metodo
        CType(Me.Master, MasterCRM3).PageTitle = "Documentos Soporte"
        If (Not IsPostBack) Then
            InitialInformation()
        End If
    End Sub
    Private Sub InitialInformation()
        ASPxImageSlider1.ImageSourceFolder = "~\Content\Images\photo_gallery\"
    End Sub
    Protected Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Response.Redirect("~/frmBienvenida.aspx")
    End Sub
End Class
