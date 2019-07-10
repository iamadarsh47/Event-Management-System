Imports System.data.sqlclient
Public Class StudentHome
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim passcom, namecmd, cmd As SqlCommand
    Dim password, checkPasswordQuery, checkuser, name, username As String
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Dim temp As Integer
    Dim dr As SqlDataReader

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator

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
        cmd.CommandText = "select * from AEventAdd"
        dr = cmd.ExecuteReader()
        DataGrid1.DataSource = dr
        DataGrid1.DataBind()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn = New SqlConnection
        conn.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        conn.Open()
        checkuser = "select count(*) from AEventAdd where College_Name='" + TextBox1.Text + "'"
        passcom = New SqlCommand(checkuser, conn)
        temp = Convert.ToInt16(passcom.ExecuteScalar().ToString())
        conn.Close()
        If temp = 1 Then
            conn.Open()
            checkPasswordQuery = "select Event_Name from AEventAdd where College_Name='" + TextBox1.Text + "'"

            passcom = New SqlCommand(checkPasswordQuery, conn)
            password = passcom.ExecuteScalar().ToString().Replace(" ", "")
            If (password = TextBox2.Text) Then


                Response.Write("Password is correct")
                Response.Redirect("StudentHome.aspx")


            Else
                Response.Write("Password is incorrect")
            End If
        Else
            Response.Write("College Name is INcorrect")
        End If

    End Sub

    Private Sub DataGrid1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
