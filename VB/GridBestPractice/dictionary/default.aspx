<%@ Page Title="Ayurvedic Dictionary - ASPxGridView Best Practice Sample" Language="vb"
    MasterPageFile="~/dictionary/Bootstrap.master" AutoEventWireup="true" CodeFile="default.aspx.vb" Inherits="dictionary_default" EnableViewState="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <dx:ASPxGridView ID="gv" ClientIDMode="Static" ClientInstanceName="searchGridView" runat="server" Width="100%" KeyFieldName="Id" AutoGenerateColumns="False" EnableRowsCache="False"
        EnablePagingGestures="False" EnableViewState="False">
        <Columns>
            <dx:GridViewDataTextColumn FieldName="Calculated" UnboundType="String"
                UnboundExpression="[Devanagari] + ' ' + [IAST] + ' ' + [HarvardKyoto] + ' ' + [EnglishText]">
                <DataItemTemplate>
                    <p><b><%#GetHighlightedText(Eval("IAST"))%></b> [<%#GetHighlightedText(Eval("HarvardKyoto"))%>]  —  <%#GetHighlightedText(Eval("Devanagari"))%></p>
                    <p><%#GetHighlightedText(Eval("EnglishText"))%></p>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowColumnHeaders="false" />
        <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSort="False" />
        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        <SettingsSearchPanel Visible="true" />
        <SettingsPager PageSize="30" EnableAdaptivity="true" NumericButtonCount="3" SEOFriendly="Enabled">
            <Summary Text="Page {0} of {1}" />
        </SettingsPager>
        <Styles>
            <Cell BorderBottom-BorderWidth="0px">
                <BorderBottom BorderWidth="0px"></BorderBottom>
            </Cell>
        </Styles>
    </dx:ASPxGridView>
</asp:Content>