Option Explicit On
Option Infer Off

Imports System
Imports System.Runtime.InteropServices '   DllImport
Imports System.Security.Principal '  WindowsImpersonationContext

Public Class clsAuthenticator

    ' group type enum
    Enum SECURITY_IMPERSONATION_LEVEL As Integer
        SecurityAnonymous = 0
        SecurityIdentification = 1
        SecurityImpersonation = 2
        SecurityDelegation = 3
    End Enum

    Public Enum LogonType As Integer
        'This logon type is intended for users who will be interactively using the computer, such as a user being logged on
        'by a terminal server, remote shell, or similar process.
        'This logon type has the additional expense of caching logon information for disconnected operations;
        'therefore, it is inappropriate for some client/server applications,
        'such as a mail server.
        LOGON32_LOGON_INTERACTIVE = 2

        'This logon type is intended for high performance servers to authenticate plaintext passwords.
        'The LogonUser function does not cache credentials for this logon type.
        LOGON32_LOGON_NETWORK = 3

        'This logon type is intended for batch servers, where processes may be executing on behalf of a user without
        'their direct intervention. This type is also for higher performance servers that process many plaintext
        'authentication attempts at a time, such as mail or Web servers.
        'The LogonUser function does not cache credentials for this logon type.
        LOGON32_LOGON_BATCH = 4

        'Indicates a service-type logon. The account provided must have the service privilege enabled.
        LOGON32_LOGON_SERVICE = 5

        'This logon type is for GINA DLLs that log on users who will be interactively using the computer.
        'This logon type can generate a unique audit record that shows when the workstation was unlocked.
        LOGON32_LOGON_UNLOCK = 7

        'This logon type preserves the name and password in the authentication package, which allows the server to make
        'connections to other network servers while impersonating the client. A server can accept plaintext credentials
        'from a client, call LogonUser, verify that the user can access the system across the network, and still
        'communicate with other servers.
        'NOTE: Windows NT:  This value is not supported.
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8

        'This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
        'The new logon session has the same local identifier but uses different credentials for other network connections.
        'NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
        'NOTE: Windows NT:  This value is not supported.
        LOGON32_LOGON_NEW_CREDENTIALS = 9
    End Enum

    Public Enum LogonProvider As Integer
        'Use the standard logon provider for the system.
        'The default security provider is negotiate, unless you pass NULL for the domain name and the user name
        'is not in UPN format. In this case, the default provider is NTLM.
        'NOTE: Windows 2000/NT:   The default security provider is NTLM.
        LOGON32_PROVIDER_DEFAULT = 0
        LOGON32_PROVIDER_WINNT35 = 1
        LOGON32_PROVIDER_WINNT40 = 2
        LOGON32_PROVIDER_WINNT50 = 3
    End Enum

    ' obtains user token
    Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As String, ByVal lpszDomain As String, ByVal lpszPassword As String, ByVal dwLogonType As LogonType, ByVal dwLogonProvider As LogonProvider, ByRef phToken As IntPtr) As Integer


    ' closes open handles returned by LogonUser
    Declare Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean

    ' creates duplicate token handle
    Declare Auto Function DuplicateToken Lib "advapi32.dll" (ExistingTokenHandle As IntPtr, SECURITY_IMPERSONATION_LEVEL As Short, ByRef DuplicateTokenHandle As IntPtr) As Boolean

    'WindowsImpersonationContext newUser;
    Private newUser As WindowsImpersonationContext


    ' 
    ' Attempts to impersonate a user.  If successful, returns 
    ' a WindowsImpersonationContext of the new user's identity.
    ' 
    ' Username you want to impersonate
    ' Logon domain
    ' User's password to logon with
    ' 
    Public Sub Impersonator(ByVal sDomain As String, ByVal sUsername As String, ByVal sPassword As String)
        ' initialize tokens

        Dim pExistingTokenHandle As New IntPtr(0)
        Dim pDuplicateTokenHandle As New IntPtr(0)

        If sDomain = "" Then
            sDomain = System.Environment.MachineName
        End If

        Try

            Const LOGON32_PROVIDER_DEFAULT As Integer = 0
            Const LOGON32_LOGON_NEW_CREDENTIALS = 9

            Dim bImpersonated As Boolean = LogonUser(sUsername, sDomain, sPassword, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_DEFAULT, pExistingTokenHandle)

            If bImpersonated = False Then
                Dim nErrorCode As Integer = Marshal.GetLastWin32Error()
                Throw New ApplicationException("LogonUser() failed with error code: " & nErrorCode.ToString)
            End If

            Dim bRetVal As Boolean = DuplicateToken(pExistingTokenHandle, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, pDuplicateTokenHandle)
            If bRetVal = False Then
                Dim nErrorCode As Integer = Marshal.GetLastWin32Error
                CloseHandle(pExistingTokenHandle)
                Throw New ApplicationException("DuplicateToken() failed with error code: " & nErrorCode)
            Else
                Dim newId As New WindowsIdentity(pDuplicateTokenHandle)
                Dim impersonatedUser As WindowsImpersonationContext = newId.Impersonate
                newUser = impersonatedUser
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If pExistingTokenHandle <> IntPtr.Zero Then
                CloseHandle(pExistingTokenHandle)
            End If
            If pDuplicateTokenHandle <> IntPtr.Zero Then
                CloseHandle(pDuplicateTokenHandle)
            End If
        End Try

    End Sub

    Public Sub Undo()
        newUser.Undo()
    End Sub
End Class