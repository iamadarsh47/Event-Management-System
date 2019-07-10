Imports System.data.sqlclient
Public Class AdminHome
    Inherits System.Web.UI.Page
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Dim dst As DataSet

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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
        con = New SqlConnection

        con.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        con.Open()
        dst = New DataSet
        da = New SqlDataAdapter("select * from AStudentReg", con)
        da.Fill(dst, "AStudentReg")
        da.SelectCommand() = New SqlCommand("Select * from ACollegeReg", con)
        da.Fill(dst, "ACollegereg")
        da.SelectCommand() = New SqlCommand("select * from AEventAdd", con)
        da.Fill(dst, "AEventAdd")
        con.Close()







    End Sub
    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGrid1.DataSource() = dst
        DataGrid1.DataMember() = "AStudentReg"
        DataGrid1.DataBind()




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGrid1.DataSource() = dst
        DataGrid1.DataMember() = "ACollegeReg"
        DataGrid1.DataBind()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGrid1.DataSource() = dst
        DataGrid1.DataMember() = "AEventAdd"
        DataGrid1.DataBind()
    End Sub
End Class
