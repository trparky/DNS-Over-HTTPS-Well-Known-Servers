Imports System.Runtime.CompilerServices

Module StringExtensions
    ''' <summary>This function uses an IndexOf call to do a case-insensitive search. This function operates a lot like Contains().</summary>
    ''' <param name="needle">The String containing what you want to search for.</param>
    ''' <return>Returns a Boolean value.</return>
    <Extension()>
    Public Function CaseInsensitiveContains(haystack As String, needle As String) As Boolean
        If String.IsNullOrWhiteSpace(haystack) Or String.IsNullOrWhiteSpace(needle) Then Return False
        Dim index As Integer = haystack.IndexOf(needle, StringComparison.OrdinalIgnoreCase)
        Return index <> -1
    End Function
End Module