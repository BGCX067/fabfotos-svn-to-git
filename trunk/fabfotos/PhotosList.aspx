<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PhotosList.aspx.cs" Inherits="PhotosList" Title="FabFotos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <h2>My Photos</h2>
    </div>
    <asp:UpdatePanel id="UpdatePanelPics" runat="server">
        <contenttemplate>
&nbsp; <asp:DataList id="DataListPics" runat="server" __designer:dtid="562949953421318" OnItemCommand="DataListPics_ItemCommand" CssClass="imagesList" RepeatDirection="Horizontal" RepeatColumns="3" OnItemDataBound="DataListPics_ItemDataBound" __designer:wfdid="w1">
        <ItemTemplate __designer:dtid="562949953421319">
            <asp:ImageButton __designer:dtid="562949953421320" ID="ImageButtonPics" runat="server"  />
        </ItemTemplate>
    </asp:DataList>
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;
    <div>
        <h2>My Favorites</h2>
    </div>
    <asp:UpdatePanel id="UpdatePanelFavs" runat="server">
        <contenttemplate>
<asp:DataList id="DataListFavs" runat="server" __designer:dtid="562949953421325" OnItemCommand="DataListFavs_ItemCommand" CssClass="imagesList" RepeatDirection="Horizontal" RepeatColumns="3" OnItemDataBound="DataListFavs_ItemDataBound" __designer:wfdid="w2">
        <ItemTemplate __designer:dtid="562949953421326">
            <asp:ImageButton __designer:dtid="562949953421327" ID="ImageButtonFavs" runat="server"  />
        </ItemTemplate>
    </asp:DataList>&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp; &nbsp;
      
</asp:Content>

