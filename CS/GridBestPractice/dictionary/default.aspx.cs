using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AyurvedicDictionary.Code;
using DevExpress.Web;

public partial class dictionary_default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        gv.DataSource = AyurvedicDictionaryProvider.GetTerms();
        gv.DataBind();
    }
    // Trick for search panel text highlighting
    protected string GetHighlightedText(object value) {
        return HighlightSearchPanelText(value.ToString());
    }
    string HighlightSearchPanelText(string text) {
        ASPxGridView gridView = gv;
        DevExpress.Web.Internal.GridRenderHelper renderHelper = gridView.GetType().BaseType.GetProperty("RenderHelper",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .GetValue(gridView) as DevExpress.Web.Internal.GridRenderHelper;
        return renderHelper.HighlightSearchPanelText("Calculated", text, false, true, 0);
    }
}