Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace AyurvedicDictionary.Code
    Public Class AyurvedicDictionaryProvider
        Public Const NiaMdbFilePath As String = "~\App_Data\NIA_AyurvedicDictionary2015.mdb"

        Public Property Terms() As List(Of AyurvedicDictionaryTerm)
        Private Shared ReadOnly lockObject As New Object()

        Private Shared cachedProvider_Renamed As AyurvedicDictionaryProvider
        Private Shared ReadOnly Property CachedProvider() As AyurvedicDictionaryProvider
            Get
                SyncLock lockObject
                    If cachedProvider_Renamed Is Nothing Then
                        cachedProvider_Renamed = New AyurvedicDictionaryProvider()
                        cachedProvider_Renamed.Terms = New List(Of AyurvedicDictionaryTerm)()

                        PopulateTerms(cachedProvider_Renamed.Terms)
                    End If
                    Return cachedProvider_Renamed
                End SyncLock
            End Get
        End Property

        Public Shared Function GetTerms() As List(Of AyurvedicDictionaryTerm)
            Return CachedProvider.Terms
        End Function
        Public Shared Sub RefreshTerms()
            SyncLock lockObject
                If cachedProvider_Renamed IsNot Nothing Then
                    cachedProvider_Renamed.Terms.Clear()
                End If
                cachedProvider_Renamed = Nothing
            End SyncLock
        End Sub

        Private Shared Sub PopulateTerms(ByVal terms As List(Of AyurvedicDictionaryTerm))
            ' In this sample, we use a local database (MS Access) for demo purposes, because 
            ' it is easy to deploy. 
            ' You can use the Entity Framework or other ORM (Object-Relational Mapping) technology 
            ' to retrieve all items (Terms) from a data table.
            Dim ds As New AccessDataSource()
            ds.DataFile = NiaMdbFilePath
            ds.SelectCommand = "SELECT * FROM [Terms] ORDER BY [DEVANAGARI]"
            Dim data As IEnumerable = ds.Select(New DataSourceSelectArguments())
            If TypeOf data Is DataView Then
                Dim dataView As DataView = TryCast(data, DataView)
                For i As Integer = 0 To dataView.Count - 1
                    Dim item As New AyurvedicDictionaryTerm()
                    item.Id = CInt((dataView(i)("ID")))
                    item.Devanagari = CStr(dataView(i)("DEVANAGARI"))
                    item.IAST = CStr(dataView(i)("IAST"))
                    item.HarvardKyoto = CStr(dataView(i)("HarvardKyoto"))
                    item.EnglishText = CStr(dataView(i)("ENGLISH"))
                    terms.Add(item)
                Next i
            End If
        End Sub
    End Class

    Public Class AyurvedicDictionaryTerm
        Public Property Id() As Integer
        Public Property Devanagari() As String
        Public Property IAST() As String
        Public Property HarvardKyoto() As String
        Public Property EnglishText() As String
    End Class
End Namespace