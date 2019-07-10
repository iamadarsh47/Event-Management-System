Imports System.Data.SqlClient

Public Class WebForm4
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader

    Dim password, checkPasswordQuery, checkuser, name, username As String
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Dim temp As Integer


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        conn = New SqlConnection
        conn.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        conn.Open()
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select College_Name from AEventAdd "
        dr = cmd.ExecuteReader()
        DataGrid1.DataSource = dr
        DataGrid1.DataBind()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn = New SqlConnection
        conn.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        conn.Open()
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select College_Name from AEventAdd where College_Name='" & TextBox1.Text & "'"
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            Response.Redirect("EventAdd.aspx")
        End If
            

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        conn = New SqlConnection
        conn.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        conn.Open()
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandText = "select College_Name from AEventAdd where College_Name='" & TextBox1.Text & "'"
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            Response.Redirect("~/DeleteEvent.aspx")
        End If





    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
