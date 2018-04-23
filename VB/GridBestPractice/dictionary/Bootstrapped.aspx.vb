Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports AyurvedicDictionary.Code
Imports DevExpress.Web

Partial Public Class dictionary_Bootstrapped
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        gv.DataSource = AyurvedicDictionaryProvider.GetTerms()
        gv.DataBind()
    End Sub
    ' Trick for search panel text highlighting
    Protected Function GetHighlightedText(ByVal value As Object) As String
        If value Is Nothing Then ' bug fixed in 16.2.5
            Return ""
        End If
        Return HighlightSearchPanelText(value.ToString())
    End Function
    Private Function HighlightSearchPanelText(ByVal text As String) As String
        Dim gridView As ASPxGridView = gv

        Dim renderHelper As DevExpress.Web.Internal.GridRenderHelper = TryCast(gridView.GetType().BaseType.GetProperties(System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance).Where(Function(p) p.Name = "RenderHelper").FirstOrDefault().GetValue(gridView), DevExpress.Web.Internal.GridRenderHelper)

        Return renderHelper.HighlightSearchPanelText("Calculated", text, False, True, 0)
    End Function
End Class