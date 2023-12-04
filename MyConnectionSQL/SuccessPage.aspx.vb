Imports MySql.Data.MySqlClient

Public Class SuccessPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Fetch data from the database and bind it to the GridView
            BindGridView()
        End If
    End Sub

    Private Sub BindGridView()
        ' Construct the connection string
        Dim connectionString As String = "server=localhost;user=root;password=;database=test;"

        ' Create a MySqlConnection
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Construct the SQL query to select data from the user table
            Dim query As String = "SELECT Name, Email, TelephoneN, LastName, Status, DateOfBirth, Nationality FROM user"

            ' Create a MySqlCommand
            Using command As New MySqlCommand(query, connection)
                ' Create a DataTable to store the data
                Dim dataTable As New DataTable()

                ' Create a MySqlDataAdapter to fill the DataTable
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using

                ' Bind the DataTable to the GridView
                GridView1.DataSource = dataTable
                GridView1.DataBind()
            End Using
        End Using
    End Sub
End Class