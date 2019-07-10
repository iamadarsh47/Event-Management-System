Imports System.data.sqlclient
Public Class StudentLogin
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim passcom, namecmd As SqlCommand
    Dim password, checkPasswordQuery, checkuser, name, username As String
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Dim temp As Integer


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn = New SqlConnection
        conn.ConnectionString = "server=vb; database=adarshvb; uid=14bcs003; pwd=7298917198"
        conn.Open()
        checkuser = "select count(*) from AStudentReg where Email_Id='" + TextBox1.Text + "'"
        passcom = New SqlCommand(checkuser, conn)
        temp = Convert.ToInt16(passcom.ExecuteScalar().ToString())
        conn.Close()
        If temp = 1 Then
            conn.Open()
            checkPasswordQuery = "select Student_Password from AStudentReg where Email_Id='" + TextBox1.Text + "'"

            passcom = New SqlCommand(checkPasswordQuery, conn)
            password = passcom.ExecuteScalar().ToString().Replace(" ", "")
            name = "select Student_Name from AStudentReg where Email_Id='" + TextBox1.Text + "'"
            namecmd = New SqlCommand(name, conn)
            username = namecmd.ExecuteScalar().ToString().Replace(" ", " ")

            If (password = TextBox2.Text) Then


                Session("Address") = username
                Session("id") = 1
                Session("email") = TextBox1.Text
                Response.Write("Password is correct")
                Response.Redirect("StudentHome.aspx")


            Else
                Response.Write("Password is incorrect")
            End If
        Else
            Response.Write("UserName is INcorrect")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
