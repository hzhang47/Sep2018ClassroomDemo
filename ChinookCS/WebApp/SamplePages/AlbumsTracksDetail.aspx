<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumsTracksDetail.aspx.cs" Inherits="WebApp.SamplePages.AlbumsTracksDetail" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:Repeater ID="AlbumTracksList" runat="server" 
        DataSourceID="AlbumTracksListODS"
        ItemType="Chinook.Data.DTOs.AlbumInfo">
        <HeaderTemplate>
            <h4>Playlist Summary</h4>
            <table class="table">
                <tr>
                    <th>Artist</th>
                    <th>Title</th>
                    <th>Song</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.artist %> </td>
                <td><%# Item.title %> </td>
                <td><%# foreach (var item in Item.song) { }%> </td>
                <th>Name</th>
                <th>Length</th>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            &copy; Chinook reserves all right to this data.
        </FooterTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="AlbumTracksListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Album_GetAlbumDetail" 
        TypeName="ChinookSystem.BLL.AlbumDetailController"
        OnSelected="CheckForException"></asp:ObjectDataSource>
</asp:Content>
