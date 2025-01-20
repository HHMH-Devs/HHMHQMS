Imports System.Data.SqlTypes
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json

Public Class WifiVoucherController

    Public Async Function GetAccessToken() As Task(Of HttpClientAccessToken)
        Dim httpClientAccessToken As New HttpClientAccessToken

        Using Client As New HttpClient()
            Client.BaseAddress = baseAddress
            Dim queryParameters As New Dictionary(Of String, String) From {
                {"appid", appID},
                {"secret", secret},
                {"account", "hubbardh972@gmail.com"},
                {"password", "Huward@2023"}
            }

            Dim dictFormUrlEncoded As New FormUrlEncodedContent(queryParameters)
            Dim queryString = Await dictFormUrlEncoded.ReadAsStringAsync()
            Dim request = Await Client.GetAsync($"service/api/login?{queryString}")

            If request.IsSuccessStatusCode Then
                Dim requestResponce = Await request.Content.ReadAsStringAsync()
                Dim access = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(requestResponce)

                For Each itm In access
                    If itm.Key = "access_token" Then
                        httpClientAccessToken.Access_Token = itm.Value
                    End If

                    If itm.Key = "refresh_token" Then
                        httpClientAccessToken.Refresh_Token = itm.Value
                    End If
                Next

            End If
        End Using

        Return httpClientAccessToken
    End Function


    Public Async Function GenerateVoucherAsync(Optional fname As String = "", Optional lname As String = "", Optional email As String = "", Optional phone As String = "") As Task(Of HttpClientGeneratedVoucher)
        Dim voucher = New HttpClientGeneratedVoucher

        Using Client As New HttpClient
            Client.BaseAddress = baseAddress
            Dim queryParameters As New Dictionary(Of String, String) From {
                {"access_token", accessToken}
            }

            Dim content = New StringContent(JsonConvert.SerializeObject(New Dictionary(Of String, Object) From {
                    {"quantity", 1},
                    {"profile", "91339200432870801210393306734436"},
                    {"userGroupId", 55332},
                    {"firstName", fname},
                    {"lastName", lname},
                    {"email", email},
                    {"phone", phone},
                    {"comment", "Guest"}
            }), Encoding.UTF8, "application/json")

            Dim dictFormUrlEncoded As New FormUrlEncodedContent(queryParameters)
            Dim queryString = Await dictFormUrlEncoded.ReadAsStringAsync()
            Dim request = Await Client.PostAsync($"service/api/intlSamVoucher/create/hubbardh972@gmail.com/hubbardh972@gmail.com/5421079?{queryString}", content)

            If request.IsSuccessStatusCode Then
                Dim requestResponce = Await request.Content.ReadAsStringAsync()
                voucher = JsonConvert.DeserializeObject(Of HttpClientGeneratedVoucher)(requestResponce)
            End If
        End Using

        Return voucher
    End Function

    Public Async Function RefreshAccessToken() As Task
        Using client As New HttpClient
            client.BaseAddress = baseAddress
            Dim queryParameters As New Dictionary(Of String, String) From {
                {"appid", appID},
                {"secret", secret},
                {"access_token", accessToken}
            }

            Dim dictFormUrlEncoded As New FormUrlEncodedContent(queryParameters)
            Dim queryString = Await dictFormUrlEncoded.ReadAsStringAsync()
            Dim request = Await client.GetAsync($"service/api/token/refresh?{queryString}")

            If request.IsSuccessStatusCode Then
                Dim requestResponse = Await request.Content.ReadAsStringAsync
                Dim token = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(requestResponse)
                If token.Keys.Contains("accessToken") Then
                    accessToken = token.Item("accessToken").ToString
                Else
                    Dim newAccessToken = Await GetAccessToken()
                    accessToken = newAccessToken.Access_Token
                End If

            End If
        End Using

    End Function
End Class
