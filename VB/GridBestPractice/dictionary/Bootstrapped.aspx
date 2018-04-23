<%@ Page Title="Ayurvedic Dictionary - ASPxGridView Best Practice Sample" Language="vb"
    MasterPageFile="~/dictionary/BootstrapDX.master" AutoEventWireup="true" CodeFile="Bootstrapped.aspx.vb" Inherits="dictionary_Bootstrapped" EnableViewState="false" ValidateRequest="false" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <style>
        .dxbs-gridview {
            box-shadow:none;     
        }
        .dxbs-gridview > .panel-body:first-child {
            padding-left: 0;
            padding-right: 0;
        }
        .dxbs-gridview.panel {
            border: 0;
        }
            .dxbs-gridview.panel > table {
                border-left: 1px solid #ddd;
                border-right: 1px solid #ddd;
                border-bottom: 1px solid #ddd;
                border-radius: 5px;
                border-collapse: separate;
            }
            .dxbs-gridview.panel > table + .panel-body {
                border-top: 0;
            }
            .dxbs-gridview > table > tbody > tr > td {
                border: 0;
                padding-left:10px;
                padding-right:10px;
                padding-top:10px;
            }
            .dxbs-gridview > table > tbody > tr:not(:last-child) > td {
                padding-bottom: 12px;
            }
    </style>
    <dx:BootstrapGridView ID="gv" ClientIDMode="Static" ClientInstanceName="searchGridView" runat="server" Width="100%" KeyFieldName="Id" AutoGenerateColumns="False" EnableRowsCache="False"
        EnableViewState="False">
        <Columns>
            <dx:BootstrapGridViewDataTextColumn FieldName="Calculated" UnboundType="String"
                UnboundExpression="[Devanagari] + ' ' + [IAST] + ' ' + [HarvardKyoto] + ' ' + [EnglishText]">
                <DataItemTemplate>
                    <p><b><%#GetHighlightedText(Eval("IAST"))%></b> [<%#GetHighlightedText(Eval("HarvardKyoto"))%>]  —  <%#GetHighlightedText(Eval("Devanagari"))%></p>
                    <p><%#GetHighlightedText(Eval("EnglishText"))%></p>
                </DataItemTemplate>
            </dx:BootstrapGridViewDataTextColumn>
        </Columns>
        <Settings ShowColumnHeaders="false" />
        <SettingsBehavior AllowDragDrop="False" AllowGroup="False" AllowSort="False" />
        <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
        <SettingsSearchPanel Visible="true" />
        <SettingsPager PageSize="30" EnableAdaptivity="true" NumericButtonCount="3" SEOFriendly="Enabled">
            <Summary Text="Page {0} of {1}" />
        </SettingsPager>
    </dx:BootstrapGridView>
</asp:Content>