Imports MySql.Data.MySqlClient
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json

Public Class PassengerInfoDTO
    Public Property LastName As String
    Public Property Status As String
    Public Property DateOfBirth As String
    Public Property Nationality As String
End Class

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Get the values from TextBox controls
        Dim name As String = TextBox1.Text
        Dim email As String = TextBox2.Text
        Dim telephone As String = TextBox3.Text

        ' Get the passenger ID from TextBoxPassengerId
        Dim passengerId As Integer
        If Integer.TryParse(TextBoxPassengerId.Text, passengerId) Then
            ' Call the external API for passenger information
            Dim passengerInfo As PassengerInfoDTO = GetPassengerInfo(passengerId)

            If passengerInfo IsNot Nothing Then
                ' Construct the connection string
                Dim connectionString As String = "server=localhost;user=root;password=;database=test;"

                ' Create a MySqlConnection
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Construct the SQL query for insertion
                    Dim query As String = "INSERT INTO user (Name, Email, TelephoneN, LastName, Status, DateOfBirth, Nationality) VALUES (@Name, @Email, @Telephone, @LastName, @Status, @DateOfBirth, @Nationality)"

                    ' Create a MySqlCommand
                    Using command As New MySqlCommand(query, connection)
                        ' Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Name", name)
                        command.Parameters.AddWithValue("@Email", email)
                        command.Parameters.AddWithValue("@Telephone", telephone)
                        command.Parameters.AddWithValue("@LastName", passengerInfo.LastName)
                        command.Parameters.AddWithValue("@Status", passengerInfo.Status)
                        command.Parameters.AddWithValue("@DateOfBirth", passengerInfo.DateOfBirth)
                        command.Parameters.AddWithValue("@Nationality", passengerInfo.Nationality)

                        ' Execute the insertion query
                        command.ExecuteNonQuery()
                    End Using
                End Using

                ' Optionally, you can redirect the user to another page or display a success message
                Response.Redirect("SuccessPage.aspx")
            Else
                ' Handle the case where the API call did not return valid information
                ' You may display an error message or take other appropriate actions
            End If
        Else
            ' Handle the case where TextBoxPassengerId does not contain a valid integer
            ' You may display an error message or take other appropriate actions
        End If
    End Sub

    Protected Sub ButtonShowData_Click(sender As Object, e As EventArgs) Handles ButtonShowData.Click
        ' Get the passenger ID from TextBoxPassengerId
        Dim passengerId As Integer
        If Integer.TryParse(TextBoxPassengerId.Text, passengerId) Then
            ' Call the external API for passenger information
            Dim passengerInfo As PassengerInfoDTO = GetPassengerInfo(passengerId)

            If passengerInfo IsNot Nothing Then
                ' Display passenger information
                LabelName.Text = "Last Name: " & passengerInfo.LastName
                LabelStatus.Text = "Status: " & passengerInfo.Status
                LabelDateOfBirth.Text = "Date of Birth: " & passengerInfo.DateOfBirth

                ' Optionally, you can redirect the user to another page or display a success message
                ' Response.Redirect("SuccessPage.aspx")
            Else
                ' Handle the case where the API call did not return valid information
                ' You may display an error message or take other appropriate actions
            End If
        Else
            ' Handle the case where TextBoxPassengerId does not contain a valid integer
            ' You may display an error message or take other appropriate actions
        End If
    End Sub

    Private Function GetPassengerInfo(passengerId As Integer) As PassengerInfoDTO
        ' Specify the API endpoint with the passengerId
        Dim apiUrl As String = $"http://localhost:9090/passengers/{passengerId}"

        ' Use HttpClient to make the API call
        Using client As New HttpClient()
            client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            ' Make the API call and get the response
            Dim response = client.GetAsync(apiUrl).Result

            ' Check if the API call was successful (status code 200)
            If response.IsSuccessStatusCode Then
                ' Read the response content as a JSON object
                Dim jsonContent As String = response.Content.ReadAsStringAsync().Result
                Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of PassengerInfoDTO)(jsonContent)
            End If
        End Using

        ' Return null if the API call was not successful
        Return Nothing
    End Function
End Class
